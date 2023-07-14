using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Submission_N : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txt_tax_year.Items.Add("--Select Year--");
            for (int i = DateTime.Now.Year; i >= 2014; i--)
            {
                txt_tax_year.Items.Add(i.ToString());
            }

            bindgrid();
        }
    }

    public void bindgrid()
    {
        string qry = "Select distinct TaxPayer,CompanyName,Asset,AssessmentRule,AssessmentItems,TaxBaseAmount,TaxYear,SubmissionNotes from vw_Submission_View";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);

     //   string qry_other = "Select TaxPayer,CompanyName,Asset,AssessmentRuleName as AssessmentRule,AssessmentItemName as AssessmentItems,TaxBaseAmount,TaxYear from vw_Submission_View_otherMonths";

        string qry_other = "select EmployerRIN as TaxPayer,employerName as CompanyName, AssetRIN as Asset, AssessmentRuleName as AssessmentRule, AssessmentItemName as AssessmentItems, CONVERT(varchar(100), Cast(monthlyTax as decimal(38, 2))) as TaxBaseAmount, CAST(TaxYear AS INT) as TaxYear from (select employerName,EmployerRIN,StartMonth,monthlyTax,Assessment_Year,AssessmentItemID,AssessmentItemName,AssessmentRuleID,AssessmentRuleName,AssetRIN,TaxMonth,TaxYear,ProfileID,AssetId,AssetTypeId, TaxPayerID,TaxPayerTypeId from (select employerName,EmployerRIN,StartMonth,sum(MonthlyTax) as monthlyTax,Assessment_Year from Payeouputfile"
+ " where status=3 group by employerName,EmployerRIN,StartMonth,Assessment_Year) a, (select b.AssessmentRuleName, b.AssessmentRuleID, b.AssetRIN,AssessmentItemName,AssessmentItemID,Taxyear,TaxMonth,b.TaxpayerRIN,a.ProfileID, a.AssetId,a.AssetTypeId,a.TaxPayerID, a.TaxPayerTypeId from Assessment_Item_API a, "
+ "Assessment_Rules_API b where b.AssessmentRuleID=a.AssessmentRuleId and b.taxpayerRIN=a.taxpayerRIN ) b where a.EmployerRIN=b.TaxpayerRIN) k where k.EmployerRIN+'-'+AssessmentItemName not in (select TaxPayer+'-'+AssessmentItems from submissions)";

        DataTable dt_other = new DataTable();
        dt_other = PAYEClass.fetchdata(qry_other);
        DataTable dt_all = new DataTable();

        dt_all.Merge(dt);
        dt_all.Merge(dt_other);

        Session["dtempcollection"] = dt;
        if (dt.Rows.Count > 0)
        {
            grd_submissions.DataSource = dt;
            grd_submissions.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Submissions_Action.aspx");
    }
    protected void grd_submissions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_submissions.PageIndex = e.NewPageIndex;
        grd_submissions.DataSource = (DataTable)Session["dtempcollection"];
        grd_submissions.DataBind();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        DataTable dt_list_s = new DataTable();
        dt_list_s = (DataTable)Session["dtempcollection"];
        // DataRow[] filteredRows = dt_list_s.Select("TaxPayerRIN LIKE '" + txt_RIN.Text + "'");
        DataTable dt_filtered = new DataTable();
        DataView dt_v = dt_list_s.DefaultView;
        if (txt_employer_RIN.Text != "")
        {
            dt_v.RowFilter = "TaxPayer like '%" + txt_employer_RIN.Text + "%' or Asset like '%" + txt_employer_RIN.Text + "%' or AssessmentRule like '%" + txt_employer_RIN.Text + "%' or CompanyName like '%" + txt_employer_RIN.Text + "%'";

            if (txt_tax_year.SelectedItem.Text != "--Select Year--")
                dt_v.RowFilter = "(TaxPayer like '%" + txt_employer_RIN.Text + "%' or Asset like '%" + txt_employer_RIN.Text + "%' or AssessmentRule like '%" + txt_employer_RIN.Text + "%' or CompanyName like '%" + txt_employer_RIN.Text + "%') and (TaxYear = " + txt_tax_year.SelectedItem.Text + ")";


        }
        if (txt_tax_year.SelectedItem.Text != "--Select Year--" && txt_employer_RIN.Text == "")
            dt_v.RowFilter = "TaxYear = " + txt_tax_year.SelectedItem.Text + "";



        grd_submissions.DataSource = dt_v;
        grd_submissions.DataBind();

        int pagesize = grd_submissions.Rows.Count;
        int from_pg = 1;
        int to = grd_submissions.Rows.Count;
        int totalcount = dt_v.Count;
    }
}