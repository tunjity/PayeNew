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
using System.Globalization;

public partial class PaymentInterface : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    string rin = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");

        }

        if (!IsPostBack)
        {
            string qry = "Select * from Companies ";
            DataTable dt_dpd = new DataTable();
            dt_dpd = PAYEClass.fetchdata(qry);
            dpd_company.DataSource = dt_dpd;
            dpd_company.DataTextField = "company_name";
            dpd_company.DataValueField = "company_rin";
            dpd_company.DataBind();
            dpd_company.Items.Insert(0, "----Select----");
        }

       
        if (Request.QueryString["q"] != null)
        {
            rin = Request.QueryString["q"].ToString();
            tr_dpd.Attributes.Add("style", "display:none");
            tr2.Attributes.Add("style", "display:none");
            tr3.Attributes.Add("style", "display:none");
        }
        else
        {
            tr_dpd.Attributes.Add("style", "display:");
            tr2.Attributes.Add("style", "display:");
            tr3.Attributes.Add("style", "display:");
            rin = dpd_company.SelectedValue;
        }
        string dataqry = "select * from vw_payment where MonthTax<= MONTH (GETDATE()) and company_rin='" + rin.Trim() + "'";
       
        dt = PAYEClass.fetchdata(dataqry);

      //  if (dt.Rows.Count > 0 && Request.QueryString["q"] != null)
        if (Request.QueryString["q"] != null)
        {
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();
        }

        int sum = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if(dt.Rows[i]["Status"].ToString()=="Unpaid")
            sum = sum + Convert.ToInt32(dt.Rows[i]["Amount"].ToString());

        }
        lbl_bal.Text = sum.ToString();

        if (sum == 0)
        {
            btn_Pay.Visible = false;
        }
    }
    protected void grvEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvEmployee.SelectedRow;

        Session["val"] = row.Cells[0].Text + "," + row.Cells[1].Text + "," + row.Cells[2].Text + "," + row.Cells[3].Text + "," + row.Cells[4].Text;


        Session["child_ass_ref"] = "";
        Session["amount"] = "";
        Session["month"] = "";
        Session["year"] = "";
        Session["child_ass_ref"] = row.Cells[3].Text;

        Session["month"] = DateTimeFormatInfo.CurrentInfo.GetMonthName(Convert.ToInt32(row.Cells[4].Text));
            // Session["year"] = Session["year"].ToString() + "," + dt.Rows[i]["YearTax"].ToString();




        Session["year"] = row.Cells[5].Text;

        //Session["amount"] = lbl_bal.Text;
        Session["amount"] = row.Cells[6].Text;

        DataTable dt_settle_amt = new DataTable();
        string dataqry = "SELECT SUM(settlement_amount) AS settlement_amount FROM dbo.Settlements where assessment_ref='" + row.Cells[3].Text + "' GROUP BY assessment_ref";

        dt_settle_amt = PAYEClass.fetchdata(dataqry);
        Session["SettlementAmt"] = "0";
        if (dt_settle_amt.Rows.Count > 0)
            Session["SettlementAmt"] = dt_settle_amt.Rows[0][0].ToString();

        Response.Redirect("PayTax.aspx?q=" + row.Cells[0].Text.Trim());


    }
    protected void grvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Unpaid" || dt.Rows[e.Row.RowIndex]["Status"].ToString() == "Partially Paid")
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    e.Row.ToolTip = "Click to select row";
                    e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grvEmployee, "Select$" + e.Row.RowIndex);
                }
            }

        }
    }
    protected void grvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btn_Pay_Click(object sender, EventArgs e)
    {

        Session["child_ass_ref"] = "";
        Session["amount"]="";
        Session["month"] = "";
        Session["year"] = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Session["child_ass_ref"] = Session["child_ass_ref"].ToString() +","+ dt.Rows[i][3].ToString();

            Session["month"] = Session["month"].ToString() + "," + DateTimeFormatInfo.CurrentInfo.GetMonthName(Convert.ToInt32(dt.Rows[i]["MonthTax"].ToString()));
           // Session["year"] = Session["year"].ToString() + "," + dt.Rows[i]["YearTax"].ToString();
            

        }

        Session["year"] =  dt.Rows[0]["YearTax"].ToString();
        
        //Session["amount"] = lbl_bal.Text;
        Session["amount"] = dt.Rows[0]["Amount"].ToString();
        Session["child_ass_ref"] = Session["child_ass_ref"].ToString().Trim(',');

        Session["month"] = Session["month"].ToString().Trim(',');
        Session["year"] = Session["year"].ToString().Trim(',');
        
        Response.Redirect("PayTax.aspx?q=" + dt.Rows[0][2].ToString());

       
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        if (!lblnabusiness.Visible)
        {
            rin = drpBusiness.SelectedValue;
        }
        else
        {
            rin = dpd_company.SelectedValue;
        }
        string dataqry = "select * from vw_payment where MonthTax<= MONTH (GETDATE()) and company_rin='" + rin.Trim() + "'";

        dt = PAYEClass.fetchdata(dataqry);

      //  if (dt.Rows.Count > 0)
        {
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();
        }

        int sum = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Status"].ToString() == "Unpaid")
                sum = sum + Convert.ToInt32(dt.Rows[i]["Amount"].ToString());

        }
        lbl_bal.Text = sum.ToString();

        if (sum == 0)
        {
            btn_Pay.Visible = false;
        }
    }
    protected void dpd_company_SelectedIndexChanged(object sender, EventArgs e)
    {
        string qry = "Select business_name,business_rin from Businesses where companyRin='" + dpd_company.SelectedValue.Trim() + "'";
        DataTable dtbusiness = new DataTable();
        dtbusiness = PAYEClass.fetchdata(qry);
        if (dtbusiness.Rows.Count > 0)
        {
            drpBusiness.DataSource = dtbusiness;
            drpBusiness.DataTextField = "business_name";
            drpBusiness.DataValueField = "business_rin";
            drpBusiness.DataBind();
            lblnabusiness.Visible = false;
            drpBusiness.Visible = true;
        }
        else
        {
            lblnabusiness.Visible = true;
            drpBusiness.Visible = false;
        }
    }
}