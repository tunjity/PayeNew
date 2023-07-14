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

public partial class AddEmployee_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["compRIN"] == null)
        {
            Response.Redirect("Login.aspx");
        }
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

                Response.Redirect("AddEmployee_N.aspx");
            }
        }
        txt_tax_year.Text = Session["Tax_Year"].ToString();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowLegacyDataEmpInput.aspx");
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (txt_employee_RIN.Text == "")
        {
            showmsg(1, "Please Fill EmployeeRIN");
            return;
        }

        if (txt_employee_TIN.Text == "")
        {
            showmsg(1, "Please Fill EmployeeTIN");
            return;
        }

        if (txt_employee_Fname.Text == "")
        {
            showmsg(1, "Please Fill Employee Name");
            return;
        }


        if (insertindividual() >= 1)
        {
            showmsg(1, "Employee Created Successfully");
            ClearAllTextBox();
           
        }
        else
        {
            showmsg(2, "Error occured. Please contact technical support for help");
           
        }
    }

    public int insertindividual()
    {
        int status = 0;

        SqlParameter[] pram = new SqlParameter[26];
        pram[0] = new SqlParameter("@employer_name", Session["Employer"].ToString());
        pram[1] = new SqlParameter("@employer_address", "");
        pram[2] = new SqlParameter("@employer_rin", Session["compRIN"].ToString());
        pram[3] = new SqlParameter("@startMonth", txt_start_month.SelectedValue);
        pram[4] = new SqlParameter("@nationality", "");
        pram[5] = new SqlParameter("@title", "");
        pram[6] = new SqlParameter("@first_name", txt_employee_Fname.Text);
        pram[7] = new SqlParameter("@middle_name", txt_employee_Mname.Text);
        pram[8] = new SqlParameter("@last_name", txt_employee_Lname.Text);
        pram[9] = new SqlParameter("@employee_rin", txt_employee_RIN.Text);
        pram[10] = new SqlParameter("@employee_tin", txt_employee_TIN.Text);
        pram[11] = new SqlParameter("@sal_basic", txt_AnnualBasic.Text);
        pram[12] = new SqlParameter("@sal_rent", txt_AnnualRent.Text);
        pram[13] = new SqlParameter("@sal_trans", txt_Annual_Trans.Text);
        pram[14] = new SqlParameter("@sal_utility", txt_Annual_Utility.Text);
        pram[15] = new SqlParameter("@sal_meal", txt_Annual_Meal.Text);
        pram[16] = new SqlParameter("@sal_otherallowances", txt_otherIncome.Text);
        pram[17] = new SqlParameter("@sal_ltg", txt_Leave_Trans_Grant.Text);
        pram[18] = new SqlParameter("@sal_pension", txt_Pension.Text);
        pram[19] = new SqlParameter("@sal_nhf", txt_NHF.Text);
        pram[20] = new SqlParameter("@sal_nhis", txt_NHIS.Text);
        pram[21] = new SqlParameter("@sal_gross", txt_AnnualGross.Text);
        pram[22] = new SqlParameter("@Assessment_Year", txt_tax_year.Text);
        pram[23] = new SqlParameter("@endMonth", txt_end_month.SelectedValue);
        pram[24] = new SqlParameter("@businessRIN", Session["BusinessRIN"].ToString());

        pram[25] = new SqlParameter("@SucessID", 1);
        pram[25].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_Employee", pram);
        status += int.Parse(pram[25].Value.ToString());

        return status;

    }

    public void ClearAllTextBox()
    {
        //foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
        //{
        //    if (item is TextBox)
        //    {
        //        ((TextBox)item).Text = string.Empty;
        //    }
        //}

        txt_Annual_Meal.Text = "";
        txt_Annual_Trans.Text = "";
        txt_Annual_Utility.Text = "";
        txt_AnnualBasic.Text = "";
        txt_AnnualGross.Text = "";
        txt_AnnualRent.Text = "";
        txt_employee_Fname.Text = "";
        txt_employee_Lname.Text = "";
        txt_employee_Mname.Text = "";
        txt_employee_RIN.Text = "";
        txt_employee_TIN.Text = "";
        txt_Leave_Trans_Grant.Text = "";
        txt_NHF.Text = "";
        txt_NHIS.Text = "";
        txt_otherIncome.Text = "";
        txt_Pension.Text = "";
        
    }

    public void showmsg(int id, string msg)
    {
        if (id == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-check-circle' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-success");
        }
        else if (id == 2)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-warning");
        }
        else
        {
            divmsg.Style.Add("display", "none");
        }
    }
}