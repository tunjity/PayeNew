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
using System.Net.Security;
using DocumentFormat.OpenXml.Spreadsheet;

public partial class ShowLegacyDataEmpInput : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);

    protected void Page_Load(object sender, EventArgs e)
    {
        string val = "";
        System.Web.UI.ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExport);
        if (!IsPostBack)
        {

            if (Request.QueryString["compRIN"] != null)
            {
                val = Request.QueryString["compRIN"].ToString();
                Session["compRIN"] = val;
                Session["Tax_Year"] = Request.QueryString["year"].ToString();
                Session["redirect"] = Request.QueryString["Redirect"];
                Session["Employer"] = Request.QueryString["Employer"];
                Session["BusinessRIN"] = Request.QueryString["BusinessRIN"];
                Session["FiledStatus"] = Request.QueryString["FiledStatus"];
                Response.Redirect("ShowLegacyDataEmpInput.aspx");
            }

            if (Session["compRIN"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            DataTable dt_list = new DataTable();
            //   SqlDataAdapter Adp = new SqlDataAdapter("select *,(firstname+' '+lastname) as Name ,'' as title,'' as nationality,'0' as AnnualUtility,'0' as AnnualMeal, (basic+rent+trans+ltg+others+pension) as AnnualGross,(case when AssessmentAmount=0 then 'No' else 'Yes' end)  as Status from vw_InputFile left outer join EmployeeAnnualTax on TaxPayerRIN=EmployeeRIN where TaxMonth='January' and BusinessRIN='" + Session["compRIN"].ToString() + "' and Tax_year='" + Session["Tax_Year"].ToString() + "'", con);
            lbl_employername.Text = Session["Employer"].ToString() + "-" + Session["Tax_Year"].ToString();

            var q1 = "select(firstname+' '+surname) as Name,EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN,Assessment_Year as Tax_Year, AnnualGross,  EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active FROM PayeInputFile where EmployerRIN='" + Session["compRIN"].ToString() + "' and AssetRIN='" + Session["BusinessRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'";
            SqlDataAdapter Adp = new SqlDataAdapter("select(firstname+' '+surname) as Name,EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN,Assessment_Year as Tax_Year, AnnualGross,  EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active FROM PayeInputFile where EmployerRIN='" + Session["compRIN"].ToString() + "' and AssetRIN='" + Session["BusinessRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);
            Session["dt_l"] = dt_list;
            grd_emp_list.DataSource = dt_list;
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
    protected void btn_compute_Click(object sender, EventArgs e)
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
            LinkButton lbtn_drop_emp = (LinkButton)e.Row.FindControl("lnk_drop_employee");
            //string k = Session["FiledStatus"].ToString();
            //if ( k.ToLower()== "Unfiled".ToLower())
            //{
            //    lbtn_drop_emp.Visible = true;
            //}
            //else
            //{
            //    lbtn_drop_emp.Visible = false;
            //}

            if (Convert.ToString(Session["EditEMPFlag"]) == "1")
            {
                lbtn.Visible = true;
            }
            else
            {
                lbtn.Visible = false;
            }
        }
    }
    protected void btn_Add_Employees_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddEmployee_N.aspx");
    }
    protected void btn_upload_inputfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("UploadNewInputFile_N.aspx");
    }

    protected void btn_load_emp_Click(object sender, EventArgs e)
    {
        try
        {
            string comp_rin = Session["compRIN"].ToString();
            string business_rin = Session["BusinessRIN"].ToString();
            string current_year = Session["Tax_Year"].ToString();
            int x = 0;

            Int32.TryParse(current_year, out x);
            x = x - 1;
            string previous_year = x + "";

            SqlParameter[] pram = new SqlParameter[4];
            pram[0] = new SqlParameter("@currentyear", current_year);
            pram[1] = new SqlParameter("@previousyear", previous_year);
            pram[2] = new SqlParameter("@companyRIN", comp_rin);
            pram[3] = new SqlParameter("@businessRIN", business_rin);
            SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "[ADM_INS_PREV_Employee]", pram);
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Sync complete.');</script>", false);
            DataTable dt_list = new DataTable();

            SqlDataAdapter Adp = new SqlDataAdapter("select  (firstname+' '+surname) as Name, EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN, Assessment_Year as Tax_Year, AnnualGross, EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,AnnualTax,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active  from PayeInputFile EmployerRIN='" + Session["compRIN"].ToString() + "' and AssetRIN='" + Session["BusinessRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);
            Session["dt_l"] = dt_list;
            grd_emp_list.DataSource = dt_list;
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
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Something Went Wrong.');</script>", false);
        }

    }

    protected void btn_download_file(object sender, EventArgs e)
    {
        DataTable dt_list = (DataTable)Session["dt_l"];
        if (dt_list.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('No Employee Data');</script>", false);
            return;
        }
        dt_list = new DataTable();
        SqlDataAdapter Adp = new SqlDataAdapter("select  B.[EmployerName],B.[EmployerRIN],B.[AssetRin],B.[StartMonth],B.[EndMonth],B.[Nationality],B.[Title],B.[FirstName],B.[MiddleName],B.[Surname],B.[EmployeeRIN],B.[EmployeeTIN],B.[AnnualBasic],B.[AnnualRent],B.[AnnualTransport],B.[AnnualUtility],B.[AnnualMeal],B.[OtherAllowances_Annual],B.[LeaveTransport_Annual],B.[AnnualGross],B.[Pension],B.[NHF],B.[NHIS],B.[Assessment_Year],I.MobileNumber from PayeInputFile B LEFT JOIN Individuals_API I on  B.EmployeeRIN= I.TaxpayerRIN  where B.EmployerRIN='" + Session["compRIN"].ToString() + "' and B.AssetRIN='" + Session["BusinessRIN"].ToString() + "' and B.Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
  Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
  Adp.Fill(dt_list);
        try
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            MemoryStream memory = PAYEClass.DataTableToExcelXlsx(dt_list, "EmployeesRecord");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment;filename=EmployeesRecord.xlsx");
            memory.WriteTo(Response.OutputStream);
            Response.StatusCode = 200;
            Response.End();

        }
        catch (Exception exc)
        {

        }


    }
    protected void btn_drop_employee_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        string rin = grd_emp_list.Rows[clickedRow.RowIndex].Cells[0].Text.ToString();
        string tax_year = grd_emp_list.Rows[clickedRow.RowIndex].Cells[3].Text.ToString();
        string comp_rin = Session["compRIN"].ToString();

        string confirmValue = Request.Form["confirm_value"];

        confirmValue = hidden1.Value;
        if (confirmValue == "Yes")
        {

            string a;
            string main_ret = "";

            SqlConnection cn = new SqlConnection(PAYEClass.connection.ToString());

            try
            {
                cn.Open();
                string deleteQuery = "Delete From PayeInputFile Where EmployerRIN = @Comp_RIN and EmployeeRIN =@Emp_RIN and Assessment_Year =@TaxYear ";
                SqlCommand cmd = new SqlCommand(deleteQuery, cn);
                cmd.Parameters.AddWithValue("@Comp_RIN", comp_rin);
                cmd.Parameters.AddWithValue("@Emp_RIN", rin);
                cmd.Parameters.AddWithValue("@TaxYear", tax_year);
                int res =cmd.ExecuteNonQuery();
                cn.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideImage()", true);
                if (res == 0)
                {
                    main_ret = main_ret + "{\"Result\":\"Success\"}";

                    DataTable dt_list = new DataTable();
                    //   SqlDataAdapter Adp = new SqlDataAdapter("select *,(firstname+' '+lastname) as Name ,'' as title,'' as nationality,'0' as AnnualUtility,'0' as AnnualMeal, (basic+rent+trans+ltg+others+pension) as AnnualGross,(case when AssessmentAmount=0 then 'No' else 'Yes' end)  as Status from vw_InputFile left outer join EmployeeAnnualTax on TaxPayerRIN=EmployeeRIN where TaxMonth='January' and BusinessRIN='" + Session["compRIN"].ToString() + "' and Tax_year='" + Session["Tax_Year"].ToString() + "'", con);
                    lbl_employername.Text = Session["Employer"].ToString() + "-" + Session["Tax_Year"].ToString();
                    SqlDataAdapter Adp = new SqlDataAdapter("select (firstname+' '+surname) as Name, EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN, Assessment_Year as Tax_Year, AnnualGross, EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,AnnualTax,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active from payeInputfile  where EmployerRIN='" + Session["compRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
                    Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
                    Adp.Fill(dt_list);
                    Session["dt_l"] = dt_list;
                    grd_emp_list.DataSource = dt_list;
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
                else

                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Something Went Wrong.');</script>", false);
                cn.Close();


            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideImage()", true);
                cn.Close();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Connection Problem.');</script>", false);
                return;


            }

        }
    }
}