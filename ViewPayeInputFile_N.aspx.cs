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

public partial class ViewPayeInputFile_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

                    Response.Redirect("ViewPayeInputFile_N.aspx");
                }



                if (Session["compRIN"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                DataTable dt_list = new DataTable();
                SqlDataAdapter Adp = new SqlDataAdapter("select *,(FirstName+' '+SurName) as Name from PayeInputFile where EmployeeRIN='" + Session["empRIN_edit"].ToString() + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
                Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
                Adp.Fill(dt_list);

                if (dt_list.Rows.Count == 0)
                {
                    con.Open();
            //        SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
            //"'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, convert(numeric(18,0),case when Tp_TIN='' then '0' else Tp_TIN end) as EmployeeTIN," +
            //"Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
            //"LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+Pension) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + Session["empRIN_edit"].ToString() + "' and Tax_Year='" + Session["TaxYear_edit"].ToString() + "' and CompanyRIN='" + Session["compRIN_edit"].ToString() + "'", con);

                    SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
            "'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, case  when Tp_TIN=TaxPayerRIN then  '' else Tp_Tin end as EmployeeTIN," +
            "Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
            "LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+Pension) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + Session["empRIN_edit"].ToString() + "' and Tax_Year='" + Session["TaxYear_edit"].ToString() + "' and CompanyRIN='" + Session["compRIN_edit"].ToString() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();



                    //      SqlDataAdapter Adp = new SqlDataAdapter("select *,(firstname+' '+lastname) as Name ,'' as title,'' as nationality,'0' as AnnualUtility,'0' as AnnualMeal, (basic+rent+trans+ltg+others+pension) as AnnualGross from vw_InputFile where TaxMonth='January' and TaxPayerRIN='"+Session["empRIN_edit"].ToString()+"' and CompanyRIN='" +Session["compRIN_edit"].ToString()  + "' and Tax_year='" +  Session["Tax_Year"].ToString() + "'", con);

                    Adp = new SqlDataAdapter("select *,(FirstName+' '+SurName) as Name from PayeInputFile where EmployeeRIN='" + Session["empRIN_edit"].ToString() + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
                    Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
                    Adp.Fill(dt_list);
                }
                Session["dt_l"] = dt_list;

                txt_employee_name.Text = dt_list.Rows[0]["Name"].ToString();
                txt_employee_RIN.Text = dt_list.Rows[0]["EmployeeRIN"].ToString();
                txt_employee_TIN.Text = dt_list.Rows[0]["EmployeeTIN"].ToString();
                txt_tax_year.Text = dt_list.Rows[0]["Assessment_Year"].ToString();
                // txt_start_month.Text = dt_list.Rows[0]["TaxMonth"].ToString();
                txt_AnnualBasic.Text = dt_list.Rows[0]["AnnualBasic"].ToString();
                txt_Annual_Trans.Text = dt_list.Rows[0]["AnnualTransport"].ToString();
                txt_AnnualRent.Text = dt_list.Rows[0]["AnnualRent"].ToString();
                txt_Annual_Utility.Text = dt_list.Rows[0]["AnnualUtility"].ToString(); ;
                txt_Annual_Meal.Text = dt_list.Rows[0]["AnnualMeal"].ToString();
                txt_Leave_Trans_Grant.Text = dt_list.Rows[0]["LeaveTransport_Annual"].ToString();
                txt_Pension.Text = dt_list.Rows[0]["Pension"].ToString();
                txt_NHF.Text = dt_list.Rows[0]["NHF"].ToString();
                txt_NHIS.Text = dt_list.Rows[0]["NHIS"].ToString();
                txt_AnnualGross.Text = dt_list.Rows[0]["AnnualGross"].ToString();

                txt_start_month.SelectedItem.Text = dt_list.Rows[0]["StartMonth"].ToString();
                txt_end_month.SelectedItem.Text = dt_list.Rows[0]["EndMonth"].ToString();

            }
        }
        catch (Exception ex)
        {
            showmsg(2, "Something wrong with this EmployeeRIN.");

        }
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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowLegacyDataEmpInput.aspx");
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

    }
}