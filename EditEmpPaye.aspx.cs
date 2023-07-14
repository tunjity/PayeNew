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
using System.Globalization;

public partial class EditEmpPaye : System.Web.UI.Page
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

                    Response.Redirect("EditEmpPaye.aspx");
                }



                if (Session["compRIN"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                DataTable dt_list = new DataTable();
                SqlDataAdapter Adp = new SqlDataAdapter("select *,(FirstName+' '+SurName) as Name from PayeInputFile where EmployeeRIN='" + Session["empRIN_edit"].ToString() + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);

                Adp.Fill(dt_list);

                if (dt_list.Rows.Count == 0)
                {
                    con.Open();

                    //        SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
                    //"'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, convert(numeric(18,0),Tp_TIN) as EmployeeTIN," +
                    //"Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
                    //"LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+Pension) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + Session["empRIN_edit"].ToString() + "' and Tax_Year='" + Session["TaxYear_edit"].ToString() + "' and CompanyRIN='" + Session["compRIN_edit"].ToString() + "'", con);

            //        SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
            //"'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, Tp_TIN as EmployeeTIN," +
            //"Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
            //"LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+Pension) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + Session["empRIN_edit"].ToString() + "' and Tax_Year='" + Session["TaxYear_edit"].ToString() + "' and CompanyRIN='" + Session["compRIN_edit"].ToString() + "'", con);

                    SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
           "'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, case  when Tp_TIN=TaxPayerRIN then  '' else Tp_Tin end as EmployeeTIN," +
           "Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
           "LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+AnnualUtility+AnnualMeal) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + Session["empRIN_edit"].ToString() + "' and Tax_Year='" + Session["TaxYear_edit"].ToString() + "' and CompanyRIN='" + Session["compRIN_edit"].ToString() + "'", con);



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

                txt_otherIncome.Text = dt_list.Rows[0]["OtherAllowances_Annual"].ToString();
            }
        }
        catch (Exception ex)
        {
            showmsg(2, "Something wrong with this EmployeeRIN.");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowLegacyDataEmpInput.aspx");
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            //        SqlCommand truncate = new SqlCommand("delete from PayeInputfile where EmployeeRIN='" + txt_employee_RIN.Text + "' and Assessment_Year='" + txt_tax_year.Text + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "'", con);
            //        con.Open();
            //        truncate.ExecuteNonQuery();
            //        con.Close();

            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
            //"'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, convert(numeric(18,0),Tp_TIN) as EmployeeTIN," +
            //"Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
            //"LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+Pension) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + txt_employee_RIN.Text + "' and Tax_Year='" + txt_tax_year.Text + "' and CompanyRIN='" + Session["compRIN_edit"].ToString() + "'", con);

            //        cmd.ExecuteNonQuery();
            //        con.Close();

            if (txt_AnnualBasic.Text == "0" || txt_AnnualBasic.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Please Fill atleast Annual Basic.');</script>", false);
                return;
            }



            con.Open();
            SqlCommand cmd_update = new SqlCommand("update payeinputfile set AnnualBasic='" + txt_AnnualBasic.Text + "', AnnualTransport='" + txt_Annual_Trans.Text + "', AnnualRent='" + txt_AnnualRent.Text + "', AnnualUtility='" + txt_Annual_Utility.Text + "', AnnualMeal='" + txt_Annual_Meal.Text + "', LeaveTransport_Annual='" + txt_Leave_Trans_Grant.Text + "', Pension='" + txt_Pension.Text + "', NHF='" + txt_NHF.Text + "', NHIS='" + txt_NHIS.Text + "', AnnualGross='" + txt_AnnualGross.Text + "', OtherAllowances_Annual='" + txt_otherIncome.Text + "', StartMonth='" + txt_start_month.SelectedValue.ToString() + "', EndMonth='" + txt_end_month.SelectedValue.ToString() + "' where EmployeeRIN='" + txt_employee_RIN.Text + "' and Assessment_Year='" + txt_tax_year.Text + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "'", con);

            cmd_update.ExecuteNonQuery();
            con.Close();

            double nhf_cal_flag = 0, nhis_cal_flag = 0, pension_cal_flag = 0;

            if (chk_NHF.Checked == true)
                nhf_cal_flag = 1;
            if (chk_NHIS.Checked == true)
                nhis_cal_flag = 1;
            if (chk_pension.Checked == true)
                pension_cal_flag = 1;

            int no_of_months = Math.Abs((Convert.ToInt32(txt_tax_year.Text) * 12 + (DateTime.ParseExact(txt_start_month.SelectedItem.Text.ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month)) - (Convert.ToInt32(txt_tax_year.Text) * 12 + (DateTime.ParseExact(txt_end_month.SelectedItem.Text.Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month - 1)));
            double[] sal_brkup = new double[8];
            sal_brkup = PAYEClass.calculatetax(Convert.ToDouble(txt_AnnualGross.Text), Convert.ToDouble(txt_AnnualBasic.Text), Convert.ToDouble(txt_AnnualRent.Text), Convert.ToDouble(txt_Annual_Trans.Text), pension_cal_flag, Convert.ToDouble(txt_Pension.Text), nhf_cal_flag, Convert.ToDouble(txt_NHF.Text), nhis_cal_flag, Convert.ToDouble(txt_NHIS.Text), no_of_months);

            con.Open();
            string validatedNHF = txt_NHF.Text;
            string validatedNHIS = txt_NHIS.Text;
            string validatedPension = txt_Pension.Text;

            //if (chk_NHF.Checked == true)
            //    validatedNHF = sal_brkup[2].ToString();
            //if (chk_NHIS.Checked == true)
            //    validatedNHIS = sal_brkup[3].ToString();
            //if (chk_pension.Checked == true)
            //    validatedPension = sal_brkup[1].ToString();


            SqlCommand cmd_update_outputFile = new SqlCommand("update payeouputfile set AnnualGross='" + txt_AnnualGross.Text + "', CRA='" + sal_brkup[0] + "', ValidatedPension='" + sal_brkup[1] + "', ValidatedNHF='" + sal_brkup[2] + "', ValidatedNHIS='" + sal_brkup[3] + "', TaxFreePay='" + sal_brkup[4] + "', ChargeableIncome='" + sal_brkup[5] + "', AnnualTax='" + sal_brkup[6] + "', MonthlyTax='" + sal_brkup[7] + "', StartMonth='" + txt_start_month.SelectedValue.ToString() + "', EndMonth='" + txt_end_month.SelectedValue.ToString() + "' where EmployeeRIN='" + txt_employee_RIN.Text + "' and Assessment_Year='" + txt_tax_year.Text + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "'", con);
            //        SqlCommand cmd_update_outputFile = new SqlCommand("update payeouputfile set AnnualGross='" + txt_AnnualGross.Text + "', CRA='" + sal_brkup[0] + "', ValidatedPension='" + validatedPension + "', ValidatedNHF='" + validatedNHF + "', ValidatedNHIS='" + validatedNHIS + "', TaxFreePay='" + sal_brkup[4] + "', ChargeableIncome='" + sal_brkup[5] + "', AnnualTax='" + sal_brkup[6] + "', MonthlyTax='" + sal_brkup[7] + "' where EmployeeRIN='" + txt_employee_RIN.Text + "' and Assessment_Year='" + txt_tax_year.Text + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "'", con);

            cmd_update_outputFile.ExecuteNonQuery();
            con.Close();


            /*************************************Employee Contribution******************************/

            int start_mon = (DateTime.ParseExact(txt_start_month.SelectedItem.Text.ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month);
            int end_mon = (DateTime.ParseExact(txt_end_month.SelectedItem.Text.ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month);


            SqlCommand delete = new SqlCommand("delete from EmployeeContributionOutputFile where EmployeRIN='" + txt_employee_RIN.Text + "' and AssessmentYear='" + txt_tax_year.Text + "'", con);
            con.Open();
            delete.ExecuteNonQuery();
            con.Close();

            con.Open();

            SqlCommand cmd1 = new SqlCommand();
            if (DateTime.Now.Year == Convert.ToInt32(txt_tax_year.Text))
            {
                //cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dtfinal.Rows[i][9].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][20].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][19].ToString() + "',CASE WHEN month(getdate())>1 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>2 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>3 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>4 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>5 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>6 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>7 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>8 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>9 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>10 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>11 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END);", con);

              //  cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + txt_employee_RIN.Text.Replace("'", "''") + "','" + txt_tax_year.Text.Replace("'", "''") + "',CASE WHEN month(getdate())>1 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>2 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>3 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>4 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>5 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>6 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>7 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>8 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>9 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>10 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>11 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>11 THEN '" + sal_brkup[7] + "' ELSE '0' END);", con);
                cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + txt_employee_RIN.Text.Replace("'", "''") + "','" + txt_tax_year.Text.Replace("'", "''") + "',CASE WHEN (1>=" + start_mon + " and 1<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (2>=" + start_mon + " and 2<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (3>=" + start_mon + " and 3<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (4>=" + start_mon + " and 4<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (5>=" + start_mon + " and 5<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (6>=" + start_mon + " and 6<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (7>=" + start_mon + " and 7<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (8>=" + start_mon + " and 8<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (9>=" + start_mon + " and 9<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (10>=" + start_mon + " and 10<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (11>=" + start_mon + " and 11<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (12>=" + start_mon + " and 12<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END);", con);
            }
            else
            {
              //  cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + txt_employee_RIN.Text.Replace("'", "''") + "','" + txt_tax_year.Text.Replace("'", "''") + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "');", con);
                cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + txt_employee_RIN.Text.Replace("'", "''") + "','" + txt_tax_year.Text.Replace("'", "''") + "',CASE WHEN (1>=" + start_mon + " and 1<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (2>=" + start_mon + " and 2<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (3>=" + start_mon + " and 3<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (4>=" + start_mon + " and 4<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (5>=" + start_mon + " and 5<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (6>=" + start_mon + " and 6<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (7>=" + start_mon + " and 7<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (8>=" + start_mon + " and 8<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (9>=" + start_mon + " and 9<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (10>=" + start_mon + " and 10<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (11>=" + start_mon + " and 11<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (12>=" + start_mon + " and 12<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END);", con);
            }
            cmd1.ExecuteNonQuery();
            con.Close();

            /***************************************END**********************************************/



            Response.Redirect("ShowLegacyDataEmpInput.aspx");
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

    protected void txt_AnnualBasic_TextChanged(object sender, EventArgs e)
    {
        txt_AnnualGross.Text = (Convert.ToInt32(txt_AnnualBasic.Text) + Convert.ToInt32(txt_AnnualRent.Text) + Convert.ToInt32(txt_Annual_Trans.Text) + Convert.ToInt32(txt_AnnualRent.Text)).ToString();
    }
}