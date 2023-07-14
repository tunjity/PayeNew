using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TaxBaseComputation_N : System.Web.UI.Page
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
        DataTable dtempcollection = new DataTable();
        dtempcollection.Columns.Add("EmployerRIN", typeof(string));
        dtempcollection.Columns.Add("EmployerName", typeof(string));
        dtempcollection.Columns.Add("Asset", typeof(string));
        dtempcollection.Columns.Add("Rule", typeof(string));
        dtempcollection.Columns.Add("Item", typeof(string));
        dtempcollection.Columns.Add("TaxYear", typeof(string));
        dtempcollection.Columns.Add("Month", typeof(string));
        dtempcollection.Columns.Add("TaxBaseAmount", typeof(string));
        dtempcollection.Columns.Add("TaxAmount", typeof(string));


        //string qryempcollection = "select * from (select employerName,EmployerRIN,StartMonth,monthlyTax,Assessment_Year,AssessmentItemName,AssessmentRuleName,AssetRIN,TaxMonth,TaxYear from (select employerName,EmployerRIN,StartMonth,sum(MonthlyTax) as monthlyTax,Assessment_Year from Payeouputfile ";
        //qryempcollection += " where status=3 group by employerName,EmployerRIN,StartMonth,Assessment_Year) a, (select b.AssessmentRuleName,b.AssetRIN,AssessmentItemName,Taxyear,TaxMonth,b.TaxpayerRIN from Assessment_Item_API a, ";
        //qryempcollection += " Assessment_Rules_API b where b.AssessmentRuleID=a.AssessmentRuleId and b.taxpayerRIN=a.taxpayerRIN ) b where a.EmployerRIN=b.TaxpayerRIN) k where k.EmployerRIN not in (select TaxPayer from submissions)";// and a.Assessment_year=b.taxYear and DATEPART(MM,a.StartMonth+'01 1900') = b.taxMonth";

        //string qryempcollection = "select * from (select employerName,EmployerRIN,StartMonth,monthlyTax,Assessment_Year,AssessmentItemID,AssessmentItemName,AssessmentRuleID,AssessmentRuleName,AssetRIN,TaxMonth,TaxYear,ProfileID,AssetId,AssetTypeId, TaxPayerID,TaxPayerTypeId from (select employerName,EmployerRIN,StartMonth,sum(MonthlyTax) as monthlyTax,Assessment_Year from Payeouputfile ";
        //qryempcollection += " where status=3 group by employerName,EmployerRIN,StartMonth,Assessment_Year) a, (select b.AssessmentRuleName, b.AssessmentRuleID, b.AssetRIN,AssessmentItemName,AssessmentItemID,Taxyear,TaxMonth,b.TaxpayerRIN,a.ProfileID, a.AssetId,a.AssetTypeId,a.TaxPayerID, a.TaxPayerTypeId from Assessment_Item_API a, ";
        //qryempcollection += " Assessment_Rules_API b where b.AssessmentRuleID=a.AssessmentRuleId and b.taxpayerRIN=a.taxpayerRIN ) b where a.EmployerRIN=b.TaxpayerRIN and a.Assessment_Year=b.TaxYear and a.StartMonth= DateName( month , DateAdd( month , cast(TaxMonth as int) , -1 )) ) k where k.EmployerRIN+'-'+AssessmentItemName not in (select TaxPayer+'-'+AssessmentItems from submissions)";// and a.Assessment_year=b.taxYear and DATEPART(MM,a.StartMonth+'01 1900') = b.taxMonth";

        string qryempcollection = "select EmployerRIN,EmployerName,BusinessRIN as AssetRIN,AssessmentRuleName,AssessmentItemName,AssessmentYear as TaxYear, Month as TaxMonth, TaxAmt as monthlyTax from vw_tax_computation_finals order by EmployerRIN,Month,AssessmentYear";

        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qryempcollection);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

               // if (int.Parse(dt.Rows[i]["TaxMonth"].ToString()) < DateTime.Now.Month)
                {
                    dtempcollection.Rows.Add(dt.Rows[i]["EmployerRIN"].ToString(), dt.Rows[i]["employerName"].ToString(), dt.Rows[i]["AssetRIN"].ToString(), dt.Rows[i]["AssessmentRuleName"].ToString(),
                        dt.Rows[i]["AssessmentItemName"].ToString(), dt.Rows[i]["TaxYear"].ToString(), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dt.Rows[i]["TaxMonth"].ToString())),
                        dt.Rows[i]["monthlyTax"].ToString(), "-");
                }

            }
          
        }

        string qrysubmissons = "SELECT [TaxPayer],[Asset],[AssessmentRule],[TaxYear],[TaxMonth],[AssessmentItems],[TaxBaseAmount],[CompanyName],Replace(REPLACE(AssessmentRule, 'Pay As You Earn - ', ''),'Collections','') as  TMonth FROM vw_Submission_View";
        DataTable dtsubmission = new DataTable();
        dtsubmission = PAYEClass.fetchdata(qrysubmissons);
        if (dtsubmission.Rows.Count > 0)
        {
            for (int i = 0; i < dtsubmission.Rows.Count; i++)
            {
                dtempcollection.Rows.Add(dtsubmission.Rows[i]["TaxPayer"].ToString(), dtsubmission.Rows[i]["CompanyName"].ToString(),
                    dtsubmission.Rows[i]["Asset"].ToString(), dtsubmission.Rows[i]["AssessmentRule"].ToString(), dtsubmission.Rows[i]["AssessmentItems"].ToString(),
                    dtsubmission.Rows[i]["TaxYear"].ToString(), dtsubmission.Rows[i]["TMonth"].ToString(), dtsubmission.Rows[i]["TaxBaseAmount"].ToString());
            }
        }

        Session["dtempcollection"] = dtempcollection;
        grdempcollection.DataSource = dtempcollection;
        grdempcollection.DataBind();

    }

    
    protected void grdempcollection_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdempcollection.PageIndex = e.NewPageIndex;
        grdempcollection.DataSource = (DataTable)Session["dtempcollection"];
        grdempcollection.DataBind();
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
            dt_v.RowFilter = "EmployerRIN like '%" + txt_employer_RIN.Text + "%' or Asset like '%" + txt_employer_RIN.Text + "%' or Rule like '%" + txt_employer_RIN.Text + "%' or EmployerName like '%" + txt_employer_RIN.Text + "%'";

            if (txt_tax_year.SelectedItem.Text != "--Select Year--")
                dt_v.RowFilter = "(EmployerRIN like '%" + txt_employer_RIN.Text + "%' or Asset like '%" + txt_employer_RIN.Text + "%' or Rule like '%" + txt_employer_RIN.Text + "%' or EmployerName like '%" + txt_employer_RIN.Text + "%') and (TaxYear like '%" + txt_tax_year.SelectedItem.Text + "%')";


        }
        if (txt_tax_year.SelectedItem.Text != "--Select Year--" && txt_employer_RIN.Text == "")
            dt_v.RowFilter = "TaxYear like '%" + txt_tax_year.SelectedItem.Text + "%'";



        grdempcollection.DataSource = dt_v;
        grdempcollection.DataBind();

        int pagesize = grdempcollection.Rows.Count;
        int from_pg = 1;
        int to = grdempcollection.Rows.Count;
        int totalcount = dt_v.Count;
    }
}