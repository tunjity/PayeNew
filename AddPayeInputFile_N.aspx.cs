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

public partial class AddPayeInputFile_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            binddropdowns();
        }
    }

    public void binddropdowns()
    {
        string qry = "Select distinct TaxPayerRIN as CompanyRIN, TaxPayerName as CompanyName  from CompanyList_API where TaxPayerRIN is not null ORDER BY TaxPayerName";
        //string qry = "Select distinct CompanyRIN,CompanyName  from vw_InputFile where CompanyRIN is not null and (CompanyRIN+Tax_Year) not in (select EmployerRIN+Assessment_Year from PayeOuputFile)";
        
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        dpd_employer_RIN.DataSource = dt;
        dpd_employer_RIN.DataTextField = "CompanyName";
        dpd_employer_RIN.DataValueField = "CompanyRIN";
        dpd_employer_RIN.DataBind();
        dpd_Business_RIN.Items.Insert(0, "---Select---");

       // qry = "select distinct BusinessRIN,BusinessName from vw_Rules_Check where CompanyRIN='" + dpd_employer_RIN.SelectedValue + "'";
       // dt = new DataTable();
       // dt = PAYEClass.fetchdata(qry);
       // dpd_Business_RIN.DataSource = dt;
       // dpd_Business_RIN.DataTextField = "BusinessName";
       // dpd_Business_RIN.DataValueField = "BusinessRIN";
       // dpd_Business_RIN.DataBind();
       //// dpd_Business_RIN.DataBind();
       // dpd_Business_RIN.Items.Insert(0, "---Select---");


        dt = new DataTable();
        dt.Columns.Add("tax_year", typeof(int));
        for (int i = 2014; i <= DateTime.Now.Year; i++)
        {
            dt.Rows.Add(i);
        }
        dpd_Tax_Year.DataSource = dt;
        dpd_Tax_Year.DataTextField = "tax_year";
        dpd_Tax_Year.DataValueField = "tax_year";
        dpd_Tax_Year.DataBind();

    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            if (dpd_Business_RIN.SelectedValue == "---Select---")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Please Select Business!');</script>", false);
                return;
            }
            string qry = "Insert into AddPayeInputFile(CompanyRIN,BusinessRIN,TaxYear) values('" + dpd_employer_RIN.SelectedValue.Trim() + "','" + dpd_Business_RIN.SelectedValue.Trim() + "'," + dpd_Tax_Year.SelectedValue.Trim() + ")";
            int status = PAYEClass.insertupdateordelete(qry);
            if (status > 0)
            {
               // Response.Write("<script>alert('Selected Employer Added Successfully!');</script>");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Selected Employer Added Successfully for the Selected Year!');</script>", false);
              //  Response.Redirect("PayeInputFile_N.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Error Occured!');</script>", false);
            }
        }
        catch (Exception e11)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Error Occured!');</script>", false);
        }

    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayeInputFile_N.aspx");
    }

    protected void dpd_employer_RIN_SelectedIndexChanged(object sender, EventArgs e)
    {
        string qry = "select distinct BusinessRIN,BusinessName from vw_Rules_Check where CompanyRIN='" + dpd_employer_RIN.SelectedValue + "'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        dpd_Business_RIN.DataSource = dt;
        dpd_Business_RIN.DataTextField = "BusinessName";
        dpd_Business_RIN.DataValueField = "BusinessRIN";
        dpd_Business_RIN.DataBind();
       // dpd_Business_RIN.DataBind();
        dpd_Business_RIN.Items.Insert(0, "---Select---");
    }
    protected void dpd_Business_RIN_SelectedIndexChanged(object sender, EventArgs e)
    {
       // string qry = "Select distinct tax_year from vw_ShowBusiness_PayeInputFile_All where BusinessRIN='" + dpd_Business_RIN.SelectedValue + "'";
       //DataTable dt = new DataTable();
       // dt = PAYEClass.fetchdata(qry);
       // dpd_Tax_Year.DataSource = dt;
       // dpd_Tax_Year.DataTextField = "tax_year";
       // dpd_Tax_Year.DataValueField = "tax_year";
       // dpd_Tax_Year.DataBind();
    }
}