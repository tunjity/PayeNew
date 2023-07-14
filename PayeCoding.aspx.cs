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
using System.Linq;
using System.ComponentModel;

public partial class PayeCoding : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["EditEMPFlag"] = "0";
            DataTable dt_list = new DataTable();

            txt_tax_year.Items.Add("--Select Year--");
            for (int i = DateTime.Now.Year; i >= 2014; i--)
            {
                txt_tax_year.Items.Add(i.ToString());
            }

            Session["dt_l"] = dt_list;
            grd_Company.DataSource = dt_list;
            grd_Company.DataBind();

            int pagesize = grd_Company.Rows.Count;
            int from_pg = 1;
            int to = grd_Company.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_Company.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-60px");
        }
    }
    public class MyClass
    {
        public string Tax_Year { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public string EmployeeCount { get; set; }
        public int Id { get; set; }
        public string CompanyRIN { get; set; }
        public string CompanyName { get; set; }
        public string BusinessRIN { get; set; }
    }
    public class Query1
    {
        public int Id { get; set; }
        public string Tax_Year { get; set; }
        public string CompanyRIN { get; set; }
        public string CompanyName { get; set; }
        public string BusinessRIN { get; set; }
    }
    public class YearCounter
    {
        public int Year { get; set; }

    }
    public class Query2
    {
        public string Tax_Year { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public string EmployeeCount { get; set; }
    }


    public class PayeOuputFile
    {
        public string EmployerName { get; set; }
        public string AssetRin { get; set; }
        public int ApiId { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerRin { get; set; }
        public string StartMonth { get; set; }
        public string Nationality { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string EmployeeRin { get; set; }
        public string EmployeeTin { get; set; }
        public double AnnualGross { get; set; }
        public double Cra { get; set; }
        public double ValidatedPension { get; set; }
        public double ValidatedNhf { get; set; }
        public double ValidatedNhis { get; set; }
        public double TaxFreePay { get; set; }
        public double ChargeableIncome { get; set; }
        public double AnnualTax { get; set; }
        public double MonthlyTax { get; set; }
        public string AssessmentYear { get; set; }
        public int Status { get; set; }
        public string EndMonth { get; set; }
        public DateTime DateCreated { get; set; }


    }
    private DataTable GetEmployeeCompanies(string assetRin, string comRin)
    {
        DataTable responseDt = new DataTable();
        DataTable responseDt2 = new DataTable();
        DataTable responseDt3 = new DataTable();


        // var q1= "SELECT distinct EmployerRIN as CompanyRIN,EmployerName as CompanyName,Assessment_Year as Tax_Year,AssetRIN as BusinessRIN \r\nfrom PayeInputFile where AssetRIN ='FOR49743' and EmployerRIN = 'CMP49743' and StatusId > 1"
        var q1 = "SELECT distinct EmployerRIN as CompanyRIN,EmployerName as CompanyName,Assessment_Year as Tax_Year,AssetRIN as BusinessRIN from PayeInputFile where AssetRIN ='" + assetRin + "' and EmployerRIN = '" + comRin + "' and StatusId > 1";

        SqlCommand cmd = new SqlCommand(q1, con);

        con.Open();

        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            cmd.CommandTimeout = PAYEClass.defaultTimeout;
            adapter.Fill(responseDt2);
        }

        List<Query1> que1 = new List<Query1>();
        List<MyClass> que3 = new List<MyClass>();
        List<Query2> que2 = new List<Query2>();
        List<YearCounter> que4 = new List<YearCounter>();
        for (int i = 0; i < responseDt2.Rows.Count; i++)
        {
            Query1 student = new Query1();
            student.Id = i + 1;
            student.Tax_Year = responseDt2.Rows[i]["Tax_Year"].ToString();
            student.BusinessRIN = responseDt2.Rows[i]["BusinessRIN"].ToString();
            student.CompanyName = responseDt2.Rows[i]["CompanyName"].ToString();
            student.CompanyRIN = responseDt2.Rows[i]["CompanyRIN"].ToString();
            que1.Add(student);
        }
        string CompanyRIN = "0";
        var ret = que1.FindLast(o => o.Id == 1);
        if (ret != null)
        {

            CompanyRIN = ret.CompanyRIN;
        }
        var q2 = "select count(EmployeeRIN) TotalCount,StatusId,Assessment_Year from PayeInputFile where AssetRIN='" + assetRin + "' and  EmployerRIN ='" + CompanyRIN + "' and StatusId > 1 group by Assessment_Year,AssetRin,StatusId";

        SqlCommand cmd2 = new SqlCommand(q2, con);
        using (SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2))
        {
            cmd2.CommandTimeout = PAYEClass.defaultTimeout;
            adapter2.Fill(responseDt3);
        }

        for (int i = 0; i < responseDt3.Rows.Count; i++)
        {
            Query2 student = new Query2();
            student.Tax_Year = responseDt3.Rows[i]["Assessment_Year"].ToString();
            student.StatusId = responseDt3.Rows[i]["StatusId"].ToString();

            student.EmployeeCount = responseDt3.Rows[i]["TotalCount"].ToString();
            que2.Add(student);
        }

        foreach (var student in que2)
        {
            if (student.StatusId == "2")
                student.Status = "Not Coded";
            else
                student.Status = "Coded";
        }

        var viewModels = (from m in que1
                          join r in que2 on m.Tax_Year equals r.Tax_Year
                          select new MyClass()
                          {
                              BusinessRIN = m.BusinessRIN,
                              CompanyName = m.CompanyName,
                              CompanyRIN = m.CompanyRIN,
                              Tax_Year = m.Tax_Year,
                              StatusId = r.StatusId,
                              Status = r.Status,
                              EmployeeCount = r.EmployeeCount
                          }).ToList();

        con.Close();
        con.Dispose();

        Session["responseDt"] = responseDt;
        responseDt = ListToDataTable(viewModels);
        return responseDt;

    }

    public static DataTable ListToDataTable<T>(IList<T> data)
    {
        DataTable table = new DataTable();

        //special handling for value types and string
        if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
        {

            DataColumn dc = new DataColumn("Value", typeof(T));
            table.Columns.Add(dc);
            foreach (T item in data)
            {
                DataRow dr = table.NewRow();
                dr[0] = item;
                table.Rows.Add(dr);
            }
        }
        else
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    try
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    catch (Exception ex)
                    {
                        row[prop.Name] = DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }
        }
        return table;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_Company.PageIndex = e.NewPageIndex;
        grd_Company.DataSource = Session["dt_l"];

        grd_Company.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_Company.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_Company.Rows.Count).ToString();

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        DataTable dt_list_s = new DataTable();
        dt_list_s = (DataTable)Session["dt_l"];
        DataTable dt_filtered = new DataTable();
        DataView dt_v = dt_list_s.DefaultView;
        Session["searched_Asset_RIN"] = txt_employer_RIN.Text;
        Session["searched_company_RIN"] = txt_cmp_RIN.Text;
        //var assetRin = txt_employer_RIN.Text;
        var comRin = txt_cmp_RIN.Text;
        if (txt_employer_RIN.Text != "")
        {
            var assetRin = txt_employer_RIN.Text;
            dt_filtered = GetEmployeeCompanies(assetRin, comRin);

        }

        grd_Company.DataSource = dt_filtered;
        grd_Company.DataBind();

        int pagesize = grd_Company.Rows.Count;
        int from_pg = 1;
        int to = grd_Company.Rows.Count;
        int totalcount = dt_v.Count;
        lblpagefrom.Text = from_pg.ToString();
        lblpageto.Text = (from_pg + pagesize - 1).ToString();
        lbltoal.Text = totalcount.ToString();

        if (totalcount < grd_Company.PageSize)
            div_paging.Style.Add("margin-top", "0px");
        else
            div_paging.Style.Add("margin-top", "-60px");
    }
    protected void btn_file_selected_Click(object sender, EventArgs e)
    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "confirm('Unable to locate your search item. Do you want to search the closest match from your item?');", true);
        int check = 0;

        foreach (GridViewRow gvrow in grd_Company.Rows)
        {
            string stat = gvrow.Cells[6].Text;
            stat = stat.ToLower();
            System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvrow.FindControl("chkchkbox");
            if (chk != null & chk.Checked)
            {
                if (stat == "coded")
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Company Already Coded.');</script>", false);
                    return;
                }

                check = 1;
            }

            //System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvrow.FindControl("chkchkbox");
            //if (chk != null & chk.Checked)
            //{
            //    check = 1;
            //}
        }

        if (check == 0)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Please Select a Company.');</script>", false);
            return;
        }


        string confirmValue = Request.Form["confirm_value"];

        confirmValue = hidden1.Value;
        if (confirmValue == "Yes")
        {

            DataTable responseDt = new DataTable();
            DataTable responseDt2 = new DataTable();
            foreach (GridViewRow gvrow in grd_Company.Rows)
            {
                System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvrow.FindControl("chkchkbox");
                if (chk != null & chk.Checked)
                {
                    // var q1 = "insert into PayeOuputFile()"
                    SqlCommand delete = new SqlCommand("Update PayeInputFile set StatusId=4 where EmployerRIN='" + gvrow.Cells[0].Text + "' and AssetRin = '" + gvrow.Cells[3].Text + "'and Assessment_Year='" + gvrow.Cells[2].Text + "'", con);
                    con.Open();
                    delete.ExecuteNonQuery();
                    con.Close();

                    // DataTable responseDt3 = new DataTable();

                    var q1 = "SELECT * from PayeInputFile where EmployerRIN ='" + gvrow.Cells[0].Text + "'and Assessment_Year='" + gvrow.Cells[2].Text + "'";

                    SqlCommand cmd = new SqlCommand(q1, con);

                    con.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandTimeout = PAYEClass.defaultTimeout;
                        adapter.Fill(responseDt2);
                    }
                    double[] sal_brkup = new double[8];
                    List<PayeOuputFile> que4 = new List<PayeOuputFile>();
                    for (int i = 0; i < responseDt2.Rows.Count; i++)
                    {
                        PayeOuputFile student = new PayeOuputFile();
                        double basic = 0;
                        if (responseDt2.Rows[i]["AnnualBasic"].ToString().Trim() != string.Empty)
                        {
                            basic = double.Parse(responseDt2.Rows[i]["AnnualBasic"].ToString().Trim());
                        }
                        else
                        {
                            basic = 0;
                        }
                        double rent = 0;
                        if (responseDt2.Rows[i]["AnnualRent"].ToString().Trim() != string.Empty)
                        {
                            rent = double.Parse(responseDt2.Rows[i]["AnnualRent"].ToString().Trim());
                        }
                        else
                        {
                            rent = 0;
                        }
                        double trans = 0;
                        if (responseDt2.Rows[i]["AnnualTransport"].ToString().Trim() != string.Empty)
                        {
                            trans = double.Parse(responseDt2.Rows[i]["AnnualTransport"].ToString().Trim());
                        }
                        else
                        {
                            trans = 0;
                        }
                        double utility = 0;
                        if (responseDt2.Rows[i]["AnnualUtility"].ToString().Trim() != string.Empty)
                        {
                            utility = double.Parse(responseDt2.Rows[i]["AnnualUtility"].ToString().Trim());
                        }
                        else
                        {
                            utility = 0;
                        }
                        double meal = 0;
                        if (responseDt2.Rows[i]["AnnualMeal"].ToString().Trim() != string.Empty)
                        {
                            meal = double.Parse(responseDt2.Rows[i]["AnnualMeal"].ToString().Trim());
                        }
                        else
                        {
                            meal = 0;
                        }
                        double othall = 0;
                        if (responseDt2.Rows[i]["OtherAllowances_Annual"].ToString().Trim() != string.Empty)
                        {
                            othall = double.Parse(responseDt2.Rows[i]["OtherAllowances_Annual"].ToString().Trim());
                        }
                        else
                        {
                            othall = 0;
                        }
                        double ltg = 0;
                        if (responseDt2.Rows[i]["LeaveTransport_Annual"].ToString().Trim() != string.Empty)
                        {
                            ltg = double.Parse(responseDt2.Rows[i]["LeaveTransport_Annual"].ToString().Trim());
                        }
                        else
                        {
                            ltg = 0;
                        }
                        double gross = 0;
                        if (responseDt2.Rows[i]["AnnualGross"].ToString().Trim() != string.Empty)
                        {
                            gross = double.Parse(responseDt2.Rows[i]["AnnualGross"].ToString().Trim());
                        }
                        else
                        {
                            gross = basic + rent + trans + utility + meal + othall + ltg;
                        }
                        double pension = 0;
                        double pension_declared = 0;
                        if (responseDt2.Rows[i]["Pension"].ToString().Trim() != string.Empty)
                        {
                            pension_declared = double.Parse(responseDt2.Rows[i]["Pension"].ToString().Trim());
                        }
                        else
                        {
                            pension_declared = 0;

                        }

                        double nhf = 0;
                        double nhf_declared = 0;
                        if (responseDt2.Rows[i]["NHF"].ToString().Trim() != string.Empty)
                        {
                            nhf_declared = double.Parse(responseDt2.Rows[i]["NHF"].ToString().Trim());
                        }
                        else
                        {
                            nhf_declared = 0;
                        }

                        double nhis = 0;
                        double nhis_declared = 0;
                        if (responseDt2.Rows[i]["NHIS"].ToString().Trim() != string.Empty)
                        {
                            nhis_declared = double.Parse(responseDt2.Rows[i]["NHIS"].ToString().Trim());
                        }
                        else
                        {
                            nhis_declared = 0;
                        }
                        string startMonth = responseDt2.Rows[i]["StartMonth"].ToString();
                        string endMonth = responseDt2.Rows[i]["EndMonth"].ToString();
                        int numberOfMonths = CalculateTaxMonths(startMonth, endMonth);
                        sal_brkup = PAYEClass.calculatetax(gross, basic, rent, trans, pension, pension_declared, nhf, nhf_declared, nhis, nhis_declared, numberOfMonths);
                        
                        if(sal_brkup[6] == 0)
                        {
                            sal_brkup[6] = sal_brkup[7] * 12;
                        }
                        student.EmployeeRin = responseDt2.Rows[i]["EmployeeRin"].ToString();
                        student.EmployerRin = responseDt2.Rows[i]["EmployerRin"].ToString();
                        student.AssetRin = responseDt2.Rows[i]["AssetRin"].ToString();
                        student.EmployeeTin = responseDt2.Rows[i]["EmployeeTin"].ToString();
                        student.EmployerName = responseDt2.Rows[i]["EmployerName"].ToString();
                        student.Cra = sal_brkup[0];
                        student.ValidatedPension = sal_brkup[1];
                        student.ValidatedNhf = sal_brkup[2];
                        student.ValidatedNhis = sal_brkup[3];
                        student.TaxFreePay = sal_brkup[4];
                        student.ChargeableIncome = sal_brkup[5];
                        student.AnnualTax = sal_brkup[6];
                        student.MonthlyTax = sal_brkup[7];
                        student.Status = 4;
                        student.EmployerAddress = responseDt2.Rows[i]["EmployerAddress"].ToString();
                        student.StartMonth = responseDt2.Rows[i]["StartMonth"].ToString();
                        student.Title = responseDt2.Rows[i]["Title"].ToString();
                        student.FirstName = responseDt2.Rows[i]["FirstName"].ToString();
                        student.Surname = responseDt2.Rows[i]["Surname"].ToString();
                        student.AssessmentYear = responseDt2.Rows[i]["Assessment_Year"].ToString();
                        student.EndMonth = responseDt2.Rows[i]["EndMonth"].ToString();
                        student.MiddleName = responseDt2.Rows[i]["MiddleName"].ToString();
                        student.Nationality = responseDt2.Rows[i]["Nationality"].ToString();
                        student.AnnualGross = Convert.ToDouble(responseDt2.Rows[i]["AnnualGross"]);
                        student.ApiId = 0;
                        student.DateCreated = DateTime.Now;
                        //student.Ap = DateTime.Now;
                        que4.Add(student);
                    }
                    responseDt = ListToDataTable(que4);

                    SqlConnection con1 = new SqlConnection(PAYEClass.connection);

                    con1.Open();
                    foreach (DataRow row in responseDt.Rows)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO PayeOuputFile ([EmployerName],[EmployerAddress],[EmployerRIN],[StartMonth],[Nationality],[Title],[FirstName],[MiddleName],[Surname],[EmployeeRIN],[EmployeeTIN],[AnnualGross],[CRA],[ValidatedPension],[ValidatedNHF],[ValidatedNHIS],[TaxFreePay],[ChargeableIncome],[AnnualTax],[MonthlyTax],[Assessment_Year],[Status],[EndMonth],[AssetRin],[ApiId]) values (@EmployerName,@EmployerAddress,@EmployerRIN,@StartMonth,@Nationality,@Title,@FirstName,@MiddleName,@Surname,@EmployeeRIN,@EmployeeTIN,@AnnualGross,@CRA,@ValidatedPension,@ValidatedNHF,@ValidatedNHIS,@TaxFreePay,@ChargeableIncome,@AnnualTax,@MonthlyTax,@Assessment_Year,@Status,@EndMonth,@AssetRin,@ApiId)", con1);
                        cmd2.Parameters.AddWithValue("@EmployerName", row.Field<string>("EmployerName"));
                        cmd2.Parameters.AddWithValue("@EmployerAddress", row.Field<string>("EmployerAddress"));
                        cmd2.Parameters.AddWithValue("@EmployerRIN", row.Field<string>("EmployerRIN"));
                        cmd2.Parameters.AddWithValue("@StartMonth", row.Field<string>("StartMonth"));
                        cmd2.Parameters.AddWithValue("@Nationality", row.Field<string>("Nationality"));
                        cmd2.Parameters.AddWithValue("@Title", row.Field<string>("Title"));
                        cmd2.Parameters.AddWithValue("@FirstName", row.Field<string>("FirstName"));
                        cmd2.Parameters.AddWithValue("@MiddleName", row.Field<string>("MiddleName"));
                        cmd2.Parameters.AddWithValue("@Surname", row.Field<string>("Surname"));
                        cmd2.Parameters.AddWithValue("@EmployeeRIN", row.Field<string>("EmployeeRIN"));
                        cmd2.Parameters.AddWithValue("@EmployeeTIN", row.Field<string>("EmployeeTIN"));
                        cmd2.Parameters.AddWithValue("@AnnualGross", row.Field<Double>("AnnualGross"));
                        cmd2.Parameters.AddWithValue("@CRA", row.Field<Double>("CRA"));
                        cmd2.Parameters.AddWithValue("@ValidatedPension", row.Field<Double>("ValidatedPension"));
                        cmd2.Parameters.AddWithValue("@ValidatedNHF", row.Field<Double>("ValidatedNHF"));
                        cmd2.Parameters.AddWithValue("@ValidatedNHIS", row.Field<Double>("ValidatedNHIS"));
                        cmd2.Parameters.AddWithValue("@TaxFreePay", row.Field<Double>("TaxFreePay"));
                        cmd2.Parameters.AddWithValue("@ChargeableIncome", row.Field<Double>("ChargeableIncome"));
                        cmd2.Parameters.AddWithValue("@AnnualTax", row.Field<Double>("AnnualTax"));
                        cmd2.Parameters.AddWithValue("@MonthlyTax", row.Field<Double>("MonthlyTax"));
                        cmd2.Parameters.AddWithValue("@Assessment_Year", row.Field<string>("AssessmentYear"));
                        cmd2.Parameters.AddWithValue("@Status", row.Field<int>("Status"));
                        cmd2.Parameters.AddWithValue("@EndMonth", row.Field<string>("EndMonth"));
                        cmd2.Parameters.AddWithValue("@AssetRin", row.Field<string>("AssetRin"));
                        cmd2.Parameters.AddWithValue("@ApiId", row.Field<int>("ApiId"));

                        cmd2.ExecuteNonQuery();
                    }


                    Session["redirectedRIN"] = gvrow.Cells[3].Text;
                }
            }
            Response.Redirect("PayeOutputFile_N.aspx");
            DataTable dt_list = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("select  CompanyName, CompanyRIN, CompanyTIN, BusinessRIN, BusinessName, totalcount as employeecount,Tax_Year,CompanyRIN, Status,FiledStatus,CodedStatus  from vw_ShowBusiness_PayeInputFile where FiledStatus='Filed' order by CodedStatus desc", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);

            Session["dt_l"] = dt_list;
            grd_Company.DataSource = dt_list;
            grd_Company.DataBind();
        }

    }

    public int CalculateTaxMonths(string startMonth, string endMonth)
    {
        int sM, eM, tM = 0;
        startMonth = startMonth.Trim().ToLower();
        endMonth = endMonth.Trim().ToLower();
        sM = ReturnStartMonths(startMonth);
        eM = ReturnEndMonths(endMonth);

        tM = (sM - eM) + 1;
        return tM;
    }
    private int ReturnStartMonths(string startMonth)
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
    private int ReturnEndMonths(string endMonth)
    {
        if (endMonth == "january")
            return 12;
        else if (endMonth == "february")
            return 11;
        else if (endMonth == "march")
            return 10;
        else if (endMonth == "april")
            return 9;
        else if (endMonth == "may")
            return 8;
        else if (endMonth == "june")
            return 7;
        else if (endMonth == "july")
            return 6;
        else if (endMonth == "august")
            return 5;
        else if (endMonth == "september")
            return 4;
        else if (endMonth == "october")
            return 3;
        else if (endMonth == "november")
            return 2;
        else if (endMonth == "december")
            return 1;
        else
            return 0;
    }

    public void checkbox()
    {
    }
    protected void grd_Company_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //check RDM
            DataTable dt_RDM = new DataTable();
            SqlConnection conn = new SqlConnection(PAYEClass.connection);

            // SqlDataAdapter Adp_RDM = new SqlDataAdapter("select  1  from vw_ShowBusiness_PayeInputFile where ('" + e.Row.Cells[0].Text + "') in (select TaxPayerRIN from vw_PreAssessmentRDM) and ('"+ e.Row.Cells[4].Text + "') in (select AssetRIN from vw_PreAssessmentRDM) and ('" + e.Row.Cells[3].Text + "') in (select TaxYear from vw_PreAssessmentRDM)", con);

            SqlDataAdapter Adp_RDM = new SqlDataAdapter("select  1  from vw_PreAssessmentRDM where TaxPayerRIN='" + e.Row.Cells[0].Text + "' and AssetRIN='" + e.Row.Cells[3].Text + "' and TaxYear='" + e.Row.Cells[2].Text + "'", conn);
            Adp_RDM.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp_RDM.Fill(dt_RDM);


            CheckBox chkbox = (CheckBox)e.Row.FindControl("chkchkbox");
            LinkButton lnk_SubmitFiling = (LinkButton)e.Row.FindControl("lnksendtoinputfile");

            if (e.Row.Cells[7].Text == "Coded")
            {

                chkbox.Enabled = false;
                lnk_SubmitFiling.Visible = false;


            }

            else
            {

                chkbox.Enabled = true;
                lnk_SubmitFiling.Visible = true;

            }



        }
    }


    protected void btn_file_reverse_Click(object sender, EventArgs e)
    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "confirm('Unable to locate your search item. Do you want to search the closest match from your item?');", true);
        int check = 0;
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        string rin = grd_Company.Rows[clickedRow.RowIndex].Cells[0].Text.ToString();
        string yname = grd_Company.Rows[clickedRow.RowIndex].Cells[1].Text.ToString();
        string year = grd_Company.Rows[clickedRow.RowIndex].Cells[2].Text.ToString();
        string assetRin = grd_Company.Rows[clickedRow.RowIndex].Cells[3].Text.ToString();
        string status = grd_Company.Rows[clickedRow.RowIndex].Cells[6].Text.ToString();


        string confirmValue = Request.Form["confirm_value"];

        confirmValue = hidden1.Value;
        if (confirmValue == "Yes")
        {
            if (status != "Coded")
            {
                SqlCommand update_reverse = new SqlCommand("Update PayeInputFile set StatusId=1 where EmployerRIN='" + rin + "' and Assessment_Year='" + year + "'", con);
                con.Open();
                update_reverse.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Cannot Reverse Coded Inputs');</script>", false);

            }
            DataTable dt_list = new DataTable();
            DataTable responseDt2 = new DataTable();
            DataTable responseDt3 = new DataTable();

            var q1 = "SELECT distinct EmployerRIN as CompanyRIN,EmployerName as CompanyName,Assessment_Year as Tax_Year,AssetRIN as BusinessRIN from PayeInputFile where AssetRIN ='" + assetRin + "' and StatusId > 1";

            SqlCommand cmd = new SqlCommand(q1, con);

            con.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandTimeout = PAYEClass.defaultTimeout;
                adapter.Fill(responseDt2);
            }

            List<Query1> que1 = new List<Query1>();
            List<MyClass> que3 = new List<MyClass>();
            List<Query2> que2 = new List<Query2>();
            List<YearCounter> que4 = new List<YearCounter>();
            for (int i = 0; i < responseDt2.Rows.Count; i++)
            {
                Query1 student = new Query1();
                student.Id = i + 1;
                student.Tax_Year = responseDt2.Rows[i]["Tax_Year"].ToString();
                student.BusinessRIN = responseDt2.Rows[i]["BusinessRIN"].ToString();
                student.CompanyName = responseDt2.Rows[i]["CompanyName"].ToString();
                student.CompanyRIN = responseDt2.Rows[i]["CompanyRIN"].ToString();
                que1.Add(student);
            }

            var q2 = "select count(EmployeeRIN) TotalCount,StatusId,Assessment_Year from PayeInputFile where AssetRIN='" + assetRin + "' and  EmployerRIN ='" + rin + "' and StatusId > 1 group by Assessment_Year,AssetRin,StatusId";

            SqlCommand cmd2 = new SqlCommand(q2, con);
            using (SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2))
            {
                cmd2.CommandTimeout = PAYEClass.defaultTimeout;
                adapter2.Fill(responseDt3);
            }

            for (int i = 0; i < responseDt3.Rows.Count; i++)
            {
                Query2 student = new Query2();
                student.Tax_Year = responseDt3.Rows[i]["Assessment_Year"].ToString();
                student.StatusId = responseDt3.Rows[i]["StatusId"].ToString();

                student.EmployeeCount = responseDt3.Rows[i]["TotalCount"].ToString();
                que2.Add(student);
            }

            foreach (var student in que2)
            {
                if (student.StatusId == "2")
                    student.Status = "Not Coded";
                else
                    student.Status = "Coded";
            }

            var viewModels = (from m in que1
                              join r in que2 on m.Tax_Year equals r.Tax_Year
                              select new MyClass()
                              {
                                  BusinessRIN = m.BusinessRIN,
                                  CompanyName = m.CompanyName,
                                  CompanyRIN = m.CompanyRIN,
                                  Tax_Year = m.Tax_Year,
                                  StatusId = r.StatusId,
                                  Status = r.Status,
                                  EmployeeCount = r.EmployeeCount
                              }).ToList();

            con.Close();
            con.Dispose();
            dt_list = ListToDataTable(viewModels);
            Session["dt_l"] = dt_list;
            grd_Company.DataSource = dt_list;
            grd_Company.DataBind();
        }

    }
}