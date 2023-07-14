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

public partial class ShowLegacyDataEmp : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    // static string redirect = "";
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
                Response.Redirect("ShowLegacyDataEmp.aspx");
            }

            if (Session["compRIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            SqlConnection con = new SqlConnection(PAYEClass.connection);
            string query1 = "";
            DataTable dt_list = new DataTable();
            //   SqlDataAdapter Adp = new SqlDataAdapter("select *,(firstname+' '+lastname) as Name ,'' as title,'' as nationality,'0' as AnnualUtility,'0' as AnnualMeal, (basic+rent+trans+ltg+others+pension) as AnnualGross,(case when AssessmentAmount=0 then 'No' else 'Yes' end)  as Status from vw_InputFile left outer join EmployeeAnnualTax on TaxPayerRIN=EmployeeRIN where TaxMonth='January' and BusinessRIN='" + Session["compRIN"].ToString() + "' and Tax_year='" + Session["Tax_Year"].ToString() + "'", con);
            lbl_employername.Text = Session["Employer"].ToString() + "-" + Session["Tax_Year"].ToString();
            //SqlDataAdapter Adp = new SqlDataAdapter("select (firstname+' '+surname) as Name, EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN, Assessment_Year as Tax_Year, AnnualGross, EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,AnnualTax,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active from payeOuputfile  where EmployerRIN='" + Session["compRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'and Status <>0", con);
            query1 = "select DISTINCT (firstname+' '+surname) as Name, EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN, Assessment_Year as Tax_Year, AnnualGross, EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,AnnualTax,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active from payeOuputfile  where EmployerRIN='" + Session["compRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'and Status <>0";
           
            SqlCommand cmd_lga = new SqlCommand(query1, con);
            DataTable dt_lga_detail = new DataTable();
            con.Open();
            SqlDataAdapter adpp = new SqlDataAdapter(cmd_lga);
            dt_lga_detail.Clear();
            adpp.Fill(dt_lga_detail);
            //Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            //Adp.Fill(dt_list);
            con.Close();
            //Session["dt_l"] = dt_list;
            //grd_emp_list.DataSource = dt_list;
            Session["dt_lga_detaill"] = dt_lga_detail;
            grd_emp_list.DataSource = dt_lga_detail;    
            grd_emp_list.DataBind();

            int pagesize = grd_emp_list.Rows.Count;
            int from_pg = 1;
            int to = grd_emp_list.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_emp_list.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-5px");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_emp_list.PageIndex = e.NewPageIndex;
        grd_emp_list.DataSource = Session["dt_l"];

        grd_emp_list.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_emp_list.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_emp_list.Rows.Count).ToString();

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {

    }

    protected void btn_compute_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt_main = (DataTable)(Session["dt_l"]);
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("employername", typeof(string));
            dtfinal.Columns.Add("employerAddress", typeof(string));
            dtfinal.Columns.Add("employerRIN", typeof(string));
            dtfinal.Columns.Add("startmonth", typeof(string));
            dtfinal.Columns.Add("nationality", typeof(string));
            dtfinal.Columns.Add("title", typeof(string));

            dtfinal.Columns.Add("firstname", typeof(string));
            dtfinal.Columns.Add("middlename", typeof(string));
            dtfinal.Columns.Add("surname", typeof(string));
            dtfinal.Columns.Add("EmployeeRIN", typeof(string));
            dtfinal.Columns.Add("EmployeeTIN", typeof(string));
            dtfinal.Columns.Add("AnnualGross", typeof(string));

            dtfinal.Columns.Add("CRA", typeof(string));
            dtfinal.Columns.Add("ValidatedPension", typeof(string));
            dtfinal.Columns.Add("ValidatedNHF", typeof(string));
            dtfinal.Columns.Add("ValidatedNHIS", typeof(string));

            dtfinal.Columns.Add("TaxFreePay", typeof(string));
            dtfinal.Columns.Add("ChargableIncome", typeof(string));
            dtfinal.Columns.Add("AnnualTax", typeof(string));
            dtfinal.Columns.Add("MonthlyTax", typeof(string));
            dtfinal.Columns.Add("Assessment_Year", typeof(string));


            for (int i = 0; i < dt_main.Rows.Count; i++)
            {
                string employer_name = dt_main.Rows[i]["BusinessName"].ToString();
                string employer_address = dt_main.Rows[i]["ContactAddress"].ToString();

                string employer_RIN = dt_main.Rows[i]["BusinessRIN"].ToString();
                string startMonth = dt_main.Rows[i]["TaxMonth"].ToString();

                string nationality = dt_main.Rows[i]["nationality"].ToString();
                string title = dt_main.Rows[i]["title"].ToString();

                string firstname = dt_main.Rows[i]["firstname"].ToString();
                string middlename = dt_main.Rows[i]["middlename"].ToString();

                string surname = dt_main.Rows[i]["lastname"].ToString();
                string employee_RIN = dt_main.Rows[i]["taxpayerRIN"].ToString();

                string employee_TIN = dt_main.Rows[i]["tp_tin"].ToString();
                string Basic = dt_main.Rows[i]["Basic"].ToString();

                string CRA = dt_main.Rows[i]["BusinessName"].ToString();
                string rent = dt_main.Rows[i]["Rent"].ToString();
                string trans = dt_main.Rows[i]["trans"].ToString();
                string annualutility = dt_main.Rows[i]["AnnualUtility"].ToString();
                string annualmeal = dt_main.Rows[i]["AnnualMeal"].ToString();
                string others = dt_main.Rows[i]["others"].ToString();

                string LTG = dt_main.Rows[i]["ltg"].ToString();
                string AnnualGross = dt_main.Rows[i]["AnnualGross"].ToString();
                string pension = dt_main.Rows[i]["Pension"].ToString();

                string NHF = dt_main.Rows[i]["NHF"].ToString();
                string NHIS = dt_main.Rows[i]["NHIS"].ToString();
                string AssessmentYear = dt_main.Rows[i]["Tax_Year"].ToString();


                double[] sal_brkup = new double[8];

                // dummy changes on 16th jan 2019
                sal_brkup = PAYEClass.calculatetax(Convert.ToDouble(AnnualGross), Convert.ToDouble(Basic), Convert.ToDouble(rent), Convert.ToDouble(trans), 0, Convert.ToDouble(pension), 0, Convert.ToDouble(NHF), 0, Convert.ToDouble(NHIS), 12);

                dtfinal.Rows.Add(employer_name, employer_address, employer_RIN, startMonth, nationality, title, firstname, middlename, surname, employee_RIN, employee_TIN, AnnualGross, sal_brkup[0], sal_brkup[1], sal_brkup[2], sal_brkup[3], sal_brkup[4], sal_brkup[5], sal_brkup[6], sal_brkup[7], AssessmentYear);

                SqlCommand truncate = new SqlCommand("delete from Payeouputfile where EmployeeRIN='" + employee_RIN + "' and Assessment_Year='" + dtfinal.Rows[i][20].ToString().Replace("'", "''") + "'", con);
                con.Open();
                truncate.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Payeouputfile values('" + dtfinal.Rows[i][0].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][1].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][2].ToString() + "','" + dtfinal.Rows[i][3].ToString() + "','" + dtfinal.Rows[i][4].ToString() + "','" + dtfinal.Rows[i][5].ToString() + "','" + dtfinal.Rows[i][6].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][7].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][8].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][9].ToString() + "','" + dtfinal.Rows[i][10].ToString() + "','" + dtfinal.Rows[i][11].ToString() + "','" + dtfinal.Rows[i][12].ToString() + "','" + dtfinal.Rows[i][13].ToString() + "','" + dtfinal.Rows[i][14].ToString() + "','" + dtfinal.Rows[i][15].ToString() + "','" + dtfinal.Rows[i][16].ToString() + "','" + dtfinal.Rows[i][17].ToString() + "','" + dtfinal.Rows[i][18].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][20].ToString() + "');", con);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand delete = new SqlCommand("delete from EmployeeContributionOutputFile where EmployeRIN='" + employee_RIN + "' and AssessmentYear='" + dtfinal.Rows[i][20].ToString().Replace("'", "''") + "'", con);
                con.Open();
                delete.ExecuteNonQuery();
                con.Close();

                con.Open();

                SqlCommand cmd1 = new SqlCommand();
                if (DateTime.Now.Year == Convert.ToInt32(dtfinal.Rows[i][20].ToString().Replace("'", "''")))
                {
                    cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dtfinal.Rows[i][9].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][20].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][19].ToString() + "',CASE WHEN month(getdate())>1 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>2 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>3 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>4 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>5 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>6 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>7 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>8 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>9 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>10 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END,CASE WHEN month(getdate())>11 THEN '" + dtfinal.Rows[i][19].ToString() + "' ELSE '0' END);", con);

                }
                else
                {
                    cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dtfinal.Rows[i][9].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][20].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][19].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][19].ToString().Replace("'", "''") + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "','" + dtfinal.Rows[i][19].ToString() + "');", con);
                }
                cmd1.ExecuteNonQuery();
                con.Close();
            }


        }
        catch (Exception e11)
        {
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Response.Redirect("ShowLegacyDataComp.aspx");
        if (Convert.ToString(Session["redirect"]) == "I")
        {
            Response.Redirect("PayeInputFile_N.aspx");
        }
        if (Convert.ToString(Session["redirect"]) == "O")
        {
            Response.Redirect("PayeOutputFile_N.aspx");
        }
        if (Convert.ToString(Session["redirect"]) == "C")
        {
            Response.Redirect("PayeCoding.aspx");
        }

    }
    protected void grd_emp_list_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //LinkButton lbtn = new LinkButton();
            //lbtn = (LinkButton)e.Row.FindControl("lnkDetails");

            LinkButton lbtn = (LinkButton)e.Row.FindControl("lnkDetails");
            if (Session["EditEMPFlag"].ToString() == "1")
            {
                lbtn.Visible = true;
            }
            else
            {
                lbtn.Visible = false;
            }
        }
    }
}