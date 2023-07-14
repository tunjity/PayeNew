using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Net.Security;

public partial class TaxAnalysis_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    private string returString(string comm)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(comm, con);
        string str = (string)cmd.ExecuteScalar();
        con.Close();
        return str;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = "";
        if (!IsPostBack)
        {
            
            if (Request.QueryString["compRIN"] != null)
            {
                val = Request.QueryString["compRIN"].ToString();
                Session["compRIN"] = val;
                Session["BusinessRIN"] = Request.QueryString["BusinessRIN"].ToString();



                Session["Tax_Year"] = Request.QueryString["year"].ToString();
                Session["redirect"] = Request.QueryString["Redirect"];
                //Session["Employer"] = Request.QueryString["Employer"];
                Session["Employer"] = returString("select TaxPayerName from companylist_API where taxpayerrin='" + val + "'");//str;
                Session["BusinessR"] = Request.QueryString["BusinessRIN"].ToString();
                Session["BusinessN"] = returString("select BusinessName from businesses_API where businessrin='" + Request.QueryString["BusinessRIN"].ToString() + "'"); //
                //Response.Redirect("TaxAnalysis_N.aspx",false);
            }

            if (Session["compRIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            DataTable dt_list = new DataTable();
           // SqlDataAdapter Adp = new SqlDataAdapter("select  *  from PayeOuputFile where Status=3 and EmployerRIN='" + Session["compRIN"].ToString() + "'", con);

// commented on 24th jan 19
            // SqlDataAdapter Adp = new SqlDataAdapter("select  ROW_NUMBER() OVER (ORDER BY EmployerRIN) AS serial,*  from PayeOuputFile where Status=3 and EmployerRIN='" + Session["compRIN"].ToString() + "'", con);

      //      SqlDataAdapter Adp = new SqlDataAdapter("select  [EmployerName],[EmployerAddress],[EmployerRIN],[StartMonth],[Nationality],[Title],[FirstName],[MiddleName],[Surname],[EmployeeRIN] "+
      //",[EmployeeTIN],FORMAT(AnnualGross, 'N', 'en-us') as AnnualGross,FORMAT(CRA, 'N', 'en-us') as CRA,FORMAT(ValidatedPension, 'N', 'en-us') as ValidatedPension,FORMAT(ValidatedNHF, 'N', 'en-us') as ValidatedNHF,FORMAT(ValidatedNHIS, 'N', 'en-us') as ValidatedNHIS,FORMAT(TaxFreePay, 'N', 'en-us') as TaxFreePay,FORMAT(ChargeableIncome, 'N', 'en-us') as ChargeableIncome"+
      //",FORMAT(AnnualTax, 'N', 'en-us') as AnnualTax,FORMAT(MonthlyTax, 'N', 'en-us') as MonthlyTax,[Assessment_Year],[Status],[EndMonth] , AnnualGross as AnnualGross_Actual,MonthlyTax as MonthlyTax_Actual, AnnualTax as AnnualTax_Actual,([FirstName]+' '+[Surname]) as names from PayeOuputFile where Status=3  and EmployerRIN='" + Session["compRIN"].ToString() + "'", con);

            //add business rin filter coz total number of extra employees show while genrate pdf
            SqlDataAdapter Adp = new SqlDataAdapter("select ROW_NUMBER() OVER (ORDER BY EmployerRIN) AS serial,* from vw_taxAnalysis where EmployerRIN='" + Session["compRIN"].ToString() + "' and BusinessRIN='"+ Session["BusinessRIN"].ToString() + "'",con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);
            lbl_tax_payer_RIN.Text = Session["compRIN"].ToString();
            lbl_tax_payer_name.Text = Session["Employer"].ToString();
            Console.WriteLine(dt_list.Rows.Count);
            lbl_business_RIN.Text = Session["BusinessR"].ToString();
            lbl_business_name.Text = Session["BusinessN"].ToString();
            lbl_year.Text = Session["Tax_Year"].ToString();
            if (dt_list.Rows.Count > 0)
            {

                
                grd_tax_analysis.DataSource = dt_list;
                lbl_address.Text = dt_list.Rows[0]["ContactAddress"].ToString();
                Session["dt_3"] = dt_list;
                grd_tax_analysis.DataBind();


                grd_tax_analysis.FooterRow.Cells[0].Text = "Total";
                grd_tax_analysis.FooterRow.Cells[0].ColumnSpan = 5;
                grd_tax_analysis.FooterRow.Cells.RemoveAt(1);
                grd_tax_analysis.FooterRow.Cells.RemoveAt(2);
                grd_tax_analysis.FooterRow.Cells.RemoveAt(3);
                grd_tax_analysis.FooterRow.Cells.RemoveAt(4);

                // decimal AnnualGross = dt_list.AsEnumerable().Sum(row => row.Field<decimal>("AnnualGross"));

                object AnnualGross;
                AnnualGross = dt_list.Compute("Sum(AnnualGross_Actual)", string.Empty);

                object MonthlyTax;
                MonthlyTax = dt_list.Compute("Sum(MonthlyTax_Actual)", string.Empty);

                object AnnualTax;
                AnnualTax = dt_list.Compute("Sum(AnnualTax_Actual)", string.Empty);



                grd_tax_analysis.FooterRow.Cells[1].Text = String.Format("{0:n}", AnnualGross);
                grd_tax_analysis.FooterRow.Cells[8].Text = String.Format("{0:n}", MonthlyTax);
                grd_tax_analysis.FooterRow.Cells[9].Text = String.Format("{0:n}", AnnualTax);
            }

        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_tax_analysis.PageIndex = e.NewPageIndex;
        grd_tax_analysis.DataSource = Session["dt_3"];

        grd_tax_analysis.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_tax_analysis.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_tax_analysis.Rows.Count).ToString();

    }
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        try
        {
		     ServicePointManager.ServerCertificateValidationCallback = new
RemoteCertificateValidationCallback
(
   delegate { return true; }
);
            DataTable dt_list = (DataTable)(Session["dt_3"]);
           
            grd_tax_analysis.Visible = false;
            grd_tax_analysis.AllowPaging = false;
            grd_tax_analysis.DataSource = (DataTable)(Session["dt_3"]);

            grd_tax_analysis.DataBind();
            HeadingDiv.Style.Add("font-weight", "200");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(14);

            Font brown = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);
            //Set the column widths 
            int[] widths = new int[14];
            for (int x = 0; x < grd_tax_analysis.Columns.Count; x++)
            {
                widths[x] = (int)grd_tax_analysis.Columns[x].ItemStyle.Width.Value;
                string cellText = grd_tax_analysis.HeaderRow.Cells[x].Text;
                PdfPCell theCell = new PdfPCell(new Paragraph(cellText, brown));
                table.AddCell(theCell);
            }
            table.SetWidths(widths);

           
           
            //Transfer rows from GridView to table
            for (int i = 0; i < grd_tax_analysis.Rows.Count; i++)
            {
                
                    for (int j = 0; j < grd_tax_analysis.Columns.Count; j++)
                    {
                        string cellText = grd_tax_analysis.Rows[i].Cells[j].Text;


                        PdfPCell theCell = new PdfPCell(new Paragraph(cellText, brown));
                        table.AddCell(theCell);
                    }
                    table.CompleteRow();
                
            }

            object AnnualGross;
            AnnualGross = dt_list.Compute("Sum(AnnualGross_Actual)", string.Empty);

            object MonthlyTax;
            MonthlyTax = dt_list.Compute("Sum(MonthlyTax_Actual)", string.Empty);

            object AnnualTax;
            AnnualTax = dt_list.Compute("Sum(AnnualTax_Actual)", string.Empty);
            Font bold = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.BOLD);
            String ann = String.Format("{0:n}", AnnualGross);
            String month = String.Format("{0:n}", MonthlyTax);
            String tax = String.Format("{0:n}", AnnualTax);

            PdfPCell total = new PdfPCell(new Paragraph("Total", bold));
            table.AddCell(total);
           
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            PdfPCell annualG = new PdfPCell(new Paragraph(ann, bold));
            table.AddCell(annualG);
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");
            table.AddCell("");

            PdfPCell FontM = new PdfPCell(new Paragraph(month, bold));
            
            table.AddCell(FontM);
            PdfPCell fontTax = new PdfPCell(new Paragraph(tax, bold));
            table.AddCell(fontTax);
            
            table.CompleteRow();
            

            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
           
            var style = new StyleSheet();
            style.LoadTagStyle("body", "size", "5px");
            table.WidthPercentage = 100;
            main.RenderControl(htmlTextWriter);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document Doc = new Document(PageSize.A4, 20, 13, 20, 0);
            Doc.SetPageSize(PageSize.A4.Rotate());
            //Document Doc = new Document(new Rectangle(1000f, 1000f));
            HTMLWorker htmlparser = new HTMLWorker(Doc);
           
            PdfWriter.GetInstance(Doc, Response.OutputStream);
            Doc.Open();
           
            htmlparser.SetStyleSheet(style);
            
            htmlparser.Parse(stringReader);
            Doc.Add(table);
            Doc.Close();

            Response.Write(Doc);
            Response.End();
            grd_tax_analysis.AllowPaging = true;
            grd_tax_analysis.DataSource = (DataTable)(Session["dt_3"]);

            grd_tax_analysis.DataBind();
        }
        catch (Exception e1)
        {
        }
    }

    public override void VerifyRenderingInServerForm(Control control) { }  
}