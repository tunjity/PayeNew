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
using System.Linq;

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
                Session["Tax_Year"] = Request.QueryString["year"].ToString();
                Session["redirect"] = Request.QueryString["Redirect"];
                Session["Employer"] = Request.QueryString["Employer"];

                Response.Redirect("TaxAnalysis_N.aspx");
            }

            if (Session["compRIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            DataTable dt_list = new DataTable();
            var year = Session["Tax_Year"].ToString();
            var compRIN = Session["compRIN"].ToString();

            string assetRin = Session["redirectedRIN"].ToString();
            if(assetRin == null) { Response.Redirect("Login.aspx"); }
            if (year == null) { Response.Redirect("Login.aspx"); }
            //var kk = "select (select ROW_NUMBER() OVER (ORDER BY A.EmployeeRIN)) AS serial,A.StartMonth,A.EndMonth, (A.firstname+' '+A.surname) as Name,B.BusinessAddress,B.BusinessNumber,B.BusinessRIN,A.MonthlyTax,A.CRA,A.ValidatedPension,B.BusinessName, A.ValidatedNHF, A.ValidatedNHIS,A.TaxFreePay,A.ChargeableIncome,A.MonthlyTax,A.AnnualTax, A.EmployeeRIN as taxpayerRIN,A.EmployeeTIN as tp_TIN, A.Assessment_Year as Tax_Year, A.AnnualGross, A.EmployerName as CompanyName, A.EmployerRIN as CompanyRIN, A.EmployerAddress as ContactAddress,A.AnnualTax,(CASE WHEN (A.endmonth is NULL) then 'Active' else 'Active' end) as Active from payeOuputfile A left join Businesses_API_Main B on A.AssetRin = B.BusinessRIN where EmployerRIN='" + Session["compRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'and AnnualTax<>0";
            var kk = "SELECT (SELECT ROW_NUMBER() OVER (ORDER BY A.EmployeeRIN)) AS serial, A.StartMonth, A.EndMonth, (A.firstname+' '+A.surname) AS Name, B.BusinessAddress, B.BusinessNumber, B.BusinessRIN, A.MonthlyTax, A.CRA, A.ValidatedPension, B.BusinessName, A.ValidatedNHF, A.ValidatedNHIS, A.TaxFreePay, A.ChargeableIncome, A.MonthlyTax, A.AnnualTax, A.EmployeeRIN AS taxpayerRIN, A.EmployeeTIN AS tp_TIN, A.Assessment_Year AS Tax_Year, A.AnnualGross, A.EmployerName AS CompanyName, A.EmployerRIN AS CompanyRIN, A.EmployerAddress AS ContactAddress, A.AnnualTax, (CASE WHEN (A.endmonth IS NULL) THEN 'Active' ELSE 'Active' END) AS Active FROM payeOuputfile A LEFT JOIN Businesses_API_Main B ON A.AssetRin = B.BusinessRIN WHERE  AssetRin='" + assetRin + "'and EmployerRIN='" + Session["compRIN"].ToString() + "' AND Assessment_Year='" + Session["Tax_Year"].ToString() + "' AND AnnualTax<>0 AND B.BusinessAddress IS NOT NULL";


            SqlDataAdapter Adp = new SqlDataAdapter(kk, con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);

            dt_list = dt_list.DefaultView.ToTable( /*distinct*/ true);


            DataTable dtempcollection1 = new DataTable();
            dtempcollection1.Columns.Add("taxpayerRIN", typeof(string));
            dtempcollection1.Columns.Add("serial", typeof(string));
            dtempcollection1.Columns.Add("Name", typeof(string));
            dtempcollection1.Columns.Add("StartMonth", typeof(string));
            dtempcollection1.Columns.Add("EndMonth", typeof(string));
            dtempcollection1.Columns.Add("AnnualGross", typeof(string));
            dtempcollection1.Columns.Add("CRA", typeof(string));
            dtempcollection1.Columns.Add("ValidatedPension", typeof(string));
            dtempcollection1.Columns.Add("ValidatedNHF", typeof(string));
            dtempcollection1.Columns.Add("ValidatedNHIS", typeof(string));
            dtempcollection1.Columns.Add("TaxFreePay", typeof(string));
            dtempcollection1.Columns.Add("ChargeableIncome", typeof(string));
            dtempcollection1.Columns.Add("MonthlyTax", typeof(string));
            dtempcollection1.Columns.Add("AnnualTax", typeof(string));



            lbl_tax_payer_RIN.Text = Session["compRIN"].ToString();
            lbl_tax_payer_name.Text = Session["Employer"].ToString();
            Console.WriteLine(dt_list.Rows.Count);
            //lbl_business_RIN.Text = Session["BusinessR"].ToString();
            //lbl_business_name.Text = Session["BusinessN"].ToString();

            lbl_year.Text = Session["Tax_Year"].ToString();

            if (dt_list.Rows.Count > 0)
            {
                for (int i = 0; i < dt_list.Rows.Count; i++)
                {
                    int ses = i + 1;
                    dtempcollection1.Rows.Add(dt_list.Rows[i]["TaxPayerRIN"].ToString(), ses.ToString(),
                        dt_list.Rows[i]["Name"].ToString(),
                        dt_list.Rows[i]["StartMonth"].ToString(),
                        dt_list.Rows[i]["EndMonth"].ToString(),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["AnnualGross"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["CRA"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["ValidatedPension"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["ValidatedNHF"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["ValidatedNHIS"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["TaxFreePay"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["ChargeableIncome"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["MonthlyTax"])),
                        String.Format("{0:n2}", Convert.ToDecimal(dt_list.Rows[i]["AnnualTax"]))
                       ); ;
                }

                //if (dt_list.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt_list.Rows.Count; i++)
                //    {
                //        int ses = i + 1;
                //        string taxPayerRIN = dt_list.Rows[i]["TaxPayerRIN"].ToString();
                //        string startMonth = dt_list.Rows[i]["StartMonth"].ToString();
                //        string endMonth = dt_list.Rows[i]["EndMonth"].ToString();
                //        bool isDuplicate = false;


                //        foreach (DataRow row in dtempcollection1.Rows)
                //        {
                //            if (row["taxpayerRIN"].ToString() == taxPayerRIN && row["StartMonth"].ToString() == startMonth && row["EndMonth"].ToString() == endMonth)
                //            {
                //                isDuplicate = true;

                //                break;
                //            }
                //        }
                //        if (isDuplicate)
                //        {
                //            dtempcollection1.Rows.RemoveAt(Session["taxpayerRIN"]= taxpayerRIN && Session["Name"]= Name);
                //        }
                //    }
                //}

                //if (dt_list.Rows.Count > 0)
                //{
                //    foreach (DataRow dtRow in dt_list.Rows)
                //    {
                //        string taxPayerRIN = dtRow["TaxPayerRIN"].ToString();
                //        string startMonth = dtRow["StartMonth"].ToString();
                //        string endMonth = dtRow["EndMonth"].ToString();
                //        bool isDuplicate = false;

                //        foreach (DataRow dcRow in dtempcollection1.Rows)
                //        {
                //            if (dcRow["taxpayerRIN"].ToString() == taxPayerRIN &&
                //                dcRow["StartMonth"].ToString() == startMonth &&
                //                dcRow["EndMonth"].ToString() == endMonth)
                //            {
                //                isDuplicate = true;
                               
                //                break;
                //                Console.WriteLine(dtempcollection1.Rows.Count);
                //            }
                //        }
                //        if (!isDuplicate)
                //        {
                //            DataRow newRow = dtempcollection1.NewRow();
                //            newRow["taxpayerRIN"] = taxPayerRIN;
                //            newRow["StartMonth"] = startMonth;
                //            newRow["EndMonth"] = endMonth;
                //            dtempcollection1.Rows.Add(newRow);
                //        }
                //    }
                //}


                grd_tax_analysis.DataSource = dtempcollection1;
                lbl_address.Text = dt_list.Rows[0]["BusinessAddress"].ToString();
                lbl_business_RIN.Text = dt_list.Rows[0]["BusinessRIN"].ToString();
                lbl_business_name.Text = dt_list.Rows[0]["BusinessName"].ToString();
                lbl_phone.Text = "+234" + dt_list.Rows[0]["BusinessNumber"].ToString();
                Session["dt_3"] = dtempcollection1;



                grd_tax_analysis.DataBind();

                grd_tax_analysis.FooterRow.Cells[0].Text = "Total";
                grd_tax_analysis.FooterRow.Cells[0].ColumnSpan = 5;
                grd_tax_analysis.FooterRow.Cells.RemoveAt(1);
                grd_tax_analysis.FooterRow.Cells.RemoveAt(2);
                grd_tax_analysis.FooterRow.Cells.RemoveAt(3);
                grd_tax_analysis.FooterRow.Cells.RemoveAt(4);

                // decimal AnnualGross = dt_list.AsEnumerable().Sum(row => row.Field<decimal>("AnnualGross"));

                object AnnualGross;
                AnnualGross = dt_list.Compute("Sum(AnnualGross)", string.Empty);
                Session["Ag"] = AnnualGross;
                Session["Nametxp"] = dt_list.Rows[0]["BusinessName"].ToString();

                object MonthlyTax;
                MonthlyTax = dt_list.Compute("Sum(MonthlyTax)", string.Empty);
                Session["Mt"] = MonthlyTax;
                object AnnualTax;
                AnnualTax = dt_list.Compute("Sum(AnnualTax)", string.Empty);
                Session["At"] = AnnualTax;

                grd_tax_analysis.FooterRow.Cells[1].Text = String.Format("{0:n}", AnnualGross);
                grd_tax_analysis.FooterRow.Cells[8].Text = String.Format("{0:n}", MonthlyTax);
                grd_tax_analysis.FooterRow.Cells[9].Text = String.Format("{0:n}", AnnualTax);
            }

        }
    }
   
    public int CalculateTaxMonths(string startMonth)
    {
        if (startMonth == "january")
            return 12;
        else if (startMonth == "february")
            return 11;
        else if (startMonth == "march")
            return 10;
        else if (startMonth == "april")
            return 9;
        else if (startMonth == "may")
            return 8;
        else if (startMonth == "june")
            return 7;
        else if (startMonth == "july")
            return 6;
        else if (startMonth == "august")
            return 5;
        else if (startMonth == "september")
            return 4;
        else if (startMonth == "october")
            return 3;
        else if (startMonth == "november")
            return 2;
        else if (startMonth == "december")
            return 1;
        else
            return 0;
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

            string pdfName = Session["Nametxp"].ToString();
            pdfName = pdfName.Replace(",", "").Replace("&", "");
            grd_tax_analysis.Visible = false;
            grd_tax_analysis.AllowPaging = false;
            grd_tax_analysis.DataSource = (DataTable)(Session["dt_3"]);

            grd_tax_analysis.DataBind();
            HeadingDiv.Style.Add("font-weight", "200");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + pdfName + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(14);

            Font brown = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);
            Font bold = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.BOLD);
            //Set the column widths 
            int[] widths = new int[14];
            for (int x = 0; x < grd_tax_analysis.Columns.Count; x++)
            {
                widths[x] = (int)grd_tax_analysis.Columns[x].ItemStyle.Width.Value;
                string cellText = grd_tax_analysis.HeaderRow.Cells[x].Text;
                PdfPCell theCell = new PdfPCell(new Paragraph(cellText, bold));
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
            AnnualGross = Session["Ag"];

            // AnnualGross = dt_list.Compute("Sum(AnnualGross)", string.Empty);

            object MonthlyTax;
            MonthlyTax = Session["Mt"];
            //MonthlyTax = dt_list.Compute("Sum(MonthlyTax)", string.Empty);

            object AnnualTax;
            AnnualTax = Session["At"];
            //AnnualTax = dt_list.Compute("Sum(AnnualTax)", string.Empty);
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
            HTMLWorker htmlparser = new HTMLWorker(Doc);

            PdfWriter.GetInstance(Doc, Response.OutputStream);
            Doc.Open();

            htmlparser.SetStyleSheet(style);

            htmlparser.Parse(stringReader);
            Doc.Add(table);
            Doc.Close();

            Response.Write(Doc);
            //Response.End();
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