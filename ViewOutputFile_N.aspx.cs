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

public partial class ViewOutputFile_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string val = "";
            if (Request.QueryString["compRIN"] != null)
            {
                val = Request.QueryString["compRIN"].ToString();
                Session["compRIN_edit"] = val;
                Session["TaxYear_edit"] = Request.QueryString["TaxYear"].ToString();
                Session["empTIN_edit"] = Request.QueryString["empTIN"];
                Session["empRIN_edit"] = Request.QueryString["empRIN"];

                Response.Redirect("ViewOutputFile_N.aspx");
            }

            DataTable dt_list = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("select *,(FirstName+' '+SurName) as Name from PayeOuputFile where EmployeeRIN='" + Session["empRIN_edit"].ToString() + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);

            if(dt_list.Rows.Count>0)
            {
                txt_employee_name.Text = dt_list.Rows[0]["Name"].ToString();
                txt_employee_RIN.Text = dt_list.Rows[0]["EmployeeRIN"].ToString();
                txt_employee_TIN.Text = dt_list.Rows[0]["EmployeeTIN"].ToString();
                txt_tax_year.Text = dt_list.Rows[0]["Assessment_Year"].ToString();
                txt_AnnualGross.Text = dt_list.Rows[0]["AnnualGross"].ToString();
                txt_AnnualCRA.Text = dt_list.Rows[0]["CRA"].ToString();
                txt_ValidatedPension.Text = dt_list.Rows[0]["ValidatedPension"].ToString();

                txt_NHF.Text = dt_list.Rows[0]["ValidatedNHF"].ToString();
                txt_NHIS.Text = dt_list.Rows[0]["ValidatedNHIS"].ToString();

                txt_tax_free_pay.Text = dt_list.Rows[0]["TaxFreePay"].ToString();

                txt_ChargableIncome.Text = dt_list.Rows[0]["ChargeableIncome"].ToString();
                txt_AnnualTax.Text = dt_list.Rows[0]["AnnualTax"].ToString();

                txt_MonthlyTax.Text = dt_list.Rows[0]["MonthlyTax"].ToString();

            }

            if (Session["compRIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowLegacyDataEmp.aspx");
    }
}