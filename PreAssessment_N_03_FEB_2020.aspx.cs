using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Xls;
using System.Linq;

public partial class PreAssessment_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
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

    public class AssessmentAmt
    {
        public int AssessmentItemID { get; set; } 
        public double TaxBaseAmount { get; set; } 
    }

    public class AssessmetDet
    {
        public int TaxPayerTypeID { get; set; }
        public int TaxPayerID { get; set; }
        public string Notes { get; set; }
        public int AssetTypeID { get; set; }
        public int AssetID { get; set; }
        public int ProfileID { get; set; }
        public int AssessmentRuleID { get; set; }
        public int TaxYear { get; set; }
        public List<AssessmentAmt> LstAssessmentItem { get; set; }

    }


    public void bindgrid()
    {
        DataTable dtempcollection = new DataTable();
        dtempcollection.Columns.Add("EmployerRIN", typeof(string));
        dtempcollection.Columns.Add("EmployerName", typeof(string));
        dtempcollection.Columns.Add("Asset", typeof(string));
        dtempcollection.Columns.Add("Rule", typeof(string));
        dtempcollection.Columns.Add("Item", typeof(string));
        dtempcollection.Columns.Add("TaxMonthYear", typeof(string));
        dtempcollection.Columns.Add("TaxBaseAmount", typeof(string));
        dtempcollection.Columns.Add("AssessmentNotes", typeof(string));

        dtempcollection.Columns.Add("TaxPayerTypeId", typeof(string));
        dtempcollection.Columns.Add("TaxPayerID", typeof(string));
        dtempcollection.Columns.Add("AssetTypeId", typeof(string));

        dtempcollection.Columns.Add("AssetId", typeof(string));
        dtempcollection.Columns.Add("ProfileID", typeof(string));
        dtempcollection.Columns.Add("AssessmentItemID", typeof(string));
        dtempcollection.Columns.Add("AssessmentRuleID", typeof(string));
       // dtempcollection.Columns.Add("TMonth", typeof(string));


        
        string qryempcollection = "select * from (select employerName,EmployerRIN,StartMonth,monthlyTax,Assessment_Year,AssessmentItemID,AssessmentItemName,AssessmentRuleID,AssessmentRuleName,AssetRIN,TaxMonth,TaxYear,ProfileID,AssetId,AssetTypeId, TaxPayerID,TaxPayerTypeId from (select employerName,EmployerRIN,StartMonth,sum(MonthlyTax) as monthlyTax,Assessment_Year from Payeouputfile ";
        qryempcollection += " where status=3 group by employerName,EmployerRIN,StartMonth,Assessment_Year) a, (select b.AssessmentRuleName, b.AssessmentRuleID, b.AssetRIN,AssessmentItemName,AssessmentItemID,Taxyear,TaxMonth,b.TaxpayerRIN,a.ProfileID, a.AssetId,a.AssetTypeId,a.TaxPayerID, a.TaxPayerTypeId from Assessment_Item_API a, ";
        qryempcollection += " Assessment_Rules_API b where b.AssessmentRuleID=a.AssessmentRuleId and b.taxpayerRIN=a.taxpayerRIN ) b where a.EmployerRIN=b.TaxpayerRIN and a.Assessment_Year=b.TaxYear) k where k.EmployerRIN+'-'+AssessmentItemName not in (select TaxPayer+'-'+AssessmentItems from submissions)";// and a.Assessment_year=b.taxYear and DATEPART(MM,a.StartMonth+'01 1900') = b.taxMonth";

	//sourabh kaushik select EmployerRIN,EmployerName,BusinessRIN as AssetRIN,AssessmentRuleName,AssessmentItemName,AssessmentYear as TaxYear, Month as TaxMonth, TaxAmt as monthlyTax,TaxPayerTypeId,TaxPayerID,AssetTypeId,AssetId,ProfileID,AssessmentItemID,AssessmentRuleID from vw_tax_computation_finals order by EmployerRIN,Month,AssessmentYear
        qryempcollection = "select * from vw_GetPreAssessment where EmployerRIN is not null order by EmployerRIN";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qryempcollection);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               // if (int.Parse(dt.Rows[i]["TaxMonth"].ToString()) < DateTime.Now.Month)
                {
                    //dtempcollection.Rows.Add(dt.Rows[i]["EmployerRIN"].ToString(), dt.Rows[i]["employerName"].ToString(), dt.Rows[i]["AssetRIN"].ToString(), dt.Rows[i]["AssessmentRuleName"].ToString(),
                    //    dt.Rows[i]["AssessmentItemName"].ToString(), (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dt.Rows[i]["TaxMonth"].ToString())) + '-' + dt.Rows[i]["TaxYear"].ToString()), dt.Rows[i]["monthlyTax"].ToString(), dt.Rows[i]["AssessmentItemName"].ToString() +" - "+ dt.Rows[i]["TaxYear"].ToString() + "(N" + dt.Rows[i]["monthlyTax"].ToString() + ")",
                    //    dt.Rows[i]["TaxPayerTypeId"].ToString(), dt.Rows[i]["TaxPayerID"].ToString(), dt.Rows[i]["AssetTypeId"].ToString(), dt.Rows[i]["AssetId"].ToString(), dt.Rows[i]["ProfileID"].ToString(), dt.Rows[i]["AssessmentItemID"].ToString(), dt.Rows[i]["AssessmentRuleID"].ToString());  //dt.Rows[i]["TaxMonth"].ToString()

                    dtempcollection.Rows.Add(dt.Rows[i]["EmployerRIN"].ToString(), dt.Rows[i]["employerName"].ToString(), dt.Rows[i]["AssetRIN"].ToString(), dt.Rows[i]["AssessmentRuleName"].ToString(),
                       dt.Rows[i]["AssessmentItemName"].ToString(), (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dt.Rows[i]["TaxMonth"].ToString())) + '-' + dt.Rows[i]["TaxYear"].ToString()), dt.Rows[i]["monthlyTax"].ToString(), dt.Rows[i]["AssessmentItemName"].ToString() + " - " + dt.Rows[i]["TaxYear"].ToString() + "(N" + dt.Rows[i]["monthlyTax"].ToString() + ")",
                       dt.Rows[i]["TaxPayerTypeId"].ToString(), dt.Rows[i]["TaxPayerID"].ToString(), dt.Rows[i]["AssetTypeId"].ToString(), dt.Rows[i]["AssetId"].ToString(), dt.Rows[i]["ProfileID"].ToString(), dt.Rows[i]["AssessmentItemID"].ToString(), dt.Rows[i]["AssessmentRuleID"].ToString());  //dt.Rows[i]["TaxMonth"].ToString()

                }

                //if (int.Parse(dt.Rows[i]["TaxYear"].ToString()) < DateTime.Now.Year)
                //{
                //    dtempcollection.Rows.Add(dt.Rows[i]["EmployerRIN"].ToString(), dt.Rows[i]["employerName"].ToString(), dt.Rows[i]["AssetRIN"].ToString(), dt.Rows[i]["AssessmentRuleName"].ToString(),
                //        dt.Rows[i]["AssessmentItemName"].ToString(), (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dt.Rows[i]["TaxMonth"].ToString())) + '-' + dt.Rows[i]["TaxYear"].ToString()), dt.Rows[i]["monthlyTax"].ToString(), dt.Rows[i]["AssessmentItemName"].ToString() + " - " + dt.Rows[i]["TaxYear"].ToString() + "(N" + dt.Rows[i]["monthlyTax"].ToString() + ")",
                //        dt.Rows[i]["TaxPayerTypeId"].ToString(), dt.Rows[i]["TaxPayerID"].ToString(), dt.Rows[i]["AssetTypeId"].ToString(), dt.Rows[i]["AssetId"].ToString(), dt.Rows[i]["ProfileID"].ToString(), dt.Rows[i]["AssessmentItemID"].ToString(), dt.Rows[i]["AssessmentRuleID"].ToString());  //dt.Rows[i]["TaxMonth"].ToString()
                //}
            }
            //CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dt.Rows[i]["TaxMonth"].ToString()))
        }

       // string qrysubmissons = "SELECT [TaxPayer],[Asset],[AssessmentRule],([TaxMonth]+'-'+[TaxYear]) as TaxMonthYear,[AssessmentItems],[TaxBaseAmount],[CompanyName] FROM vw_Submission_View";
        string qrysubmissons = "SELECT  [TaxPayer],[Asset],[AssessmentRule],[TaxYear],[TaxMonth],[AssessmentItems],[TaxBaseAmount],[CompanyName],Replace(REPLACE(AssessmentRule, 'Pay As You Earn - ', ''),'Collections','') as  TMonth,SubmissionNotes, TaxPayerID, TaxPayerTypeID, AssessmentItemID,AssessmentRuleID,BusinessID as AssetID, AssetTypeID, 1277 as ProfileID FROM vw_Submission_View";
        DataTable dtsubmission = new DataTable();
        dtsubmission = PAYEClass.fetchdata(qrysubmissons);
        if (dtsubmission.Rows.Count > 0)
        {
            for (int i = 0; i < dtsubmission.Rows.Count; i++)
            {
                dtempcollection.Rows.Add(dtsubmission.Rows[i]["TaxPayer"].ToString(), dtsubmission.Rows[i]["CompanyName"].ToString(),
                    dtsubmission.Rows[i]["Asset"].ToString(), dtsubmission.Rows[i]["AssessmentRule"].ToString(), dtsubmission.Rows[i]["AssessmentItems"].ToString(),
                    (dtsubmission.Rows[i]["TMonth"].ToString() + '-' + dtsubmission.Rows[i]["TaxYear"].ToString()), dtsubmission.Rows[i]["TaxBaseAmount"].ToString(), dtsubmission.Rows[i]["SubmissionNotes"].ToString() + "(" + dtsubmission.Rows[i]["TaxBaseAmount"].ToString() + ")", dtsubmission.Rows[i]["TaxPayerTypeId"].ToString(), dtsubmission.Rows[i]["TaxPayerID"].ToString(), dtsubmission.Rows[i]["AssetTypeId"].ToString(), dtsubmission.Rows[i]["AssetId"].ToString(), dtsubmission.Rows[i]["ProfileID"].ToString(), dtsubmission.Rows[i]["AssessmentItemID"].ToString(), dtsubmission.Rows[i]["AssessmentRuleID"].ToString());
            }
        }

        DataView dv = dtempcollection.DefaultView;
        dv.Sort = "EmployerRIN";

        Session["dtempcollection"] = dv;
        grdempcollection.DataSource = dv;
        grdempcollection.DataBind();

    }


    protected void grdempcollection_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdempcollection.PageIndex = e.NewPageIndex;
        grdempcollection.DataSource = (DataView)Session["dtempcollection"];
        grdempcollection.DataBind();
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            int check = 0;

            int taxpayerTypeID1 = 1;
            int TaxPayerID1 = 1;
            int AssetTypeID1 = 1;
            int AssetID1 = 1;

            string Notes1 = "sss";

            int ProfileId1 = 1;
            int AssesmentRuleId1 = 1;
            int TaxYear1 = 2018;
            int AssessmentItemId1 = 1;
            int taxBaseAmt1 = 10;

            string msg = "";
            foreach (GridViewRow gvrow in grdempcollection.Rows)
            {

                System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvrow.FindControl("chkrdm");
                if (chk != null & chk.Checked)
                {
                    check = 1;

                    AssessmentAmt amt = new AssessmentAmt
                    {
                        AssessmentItemID = Convert.ToInt32(gvrow.Cells[5].Text),
                        TaxBaseAmount = Convert.ToDouble(gvrow.Cells[12].Text),
                    };

                    AssessmetDet Assessment = new AssessmetDet
                    {
                        TaxPayerTypeID = Convert.ToInt32(gvrow.Cells[0].Text),

                        TaxPayerID = Convert.ToInt32(gvrow.Cells[1].Text),

                        AssetTypeID = Convert.ToInt32(gvrow.Cells[2].Text),

                        AssetID = Convert.ToInt32(gvrow.Cells[3].Text),

                        ProfileID = Convert.ToInt32(gvrow.Cells[4].Text),

                        //   AssessmentItemID = Convert.ToInt32(grdempcollection.Rows[0].Cells[5].Text),

                        AssessmentRuleID = Convert.ToInt32(gvrow.Cells[6].Text),

                        Notes = "-",
                        TaxYear = Convert.ToInt32(gvrow.Cells[11].Text.Split('-')[1]),

                        LstAssessmentItem = new List<AssessmentAmt>()

                        // TaxBaseAmount = 1000
                    };

                    Assessment.LstAssessmentItem.Add(amt);
                    taxpayerTypeID1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[0].Text);

                    TaxPayerID1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[1].Text);

                    AssetTypeID1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[2].Text);

                    AssetID1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[3].Text);

                    ProfileId1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[4].Text);

                    AssessmentItemId1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[5].Text);

                    AssesmentRuleId1 = Convert.ToInt32(grdempcollection.Rows[0].Cells[6].Text);

                    string[] res;
                    string URI = "https://stage-api.eirsautomation.xyz/RevenueData/Assessment/Insert";
                    URI = PAYEClass.URL_API + "RevenueData/Assessment/Insert";
                    //  string myParameters = "{ \"TaxPayerTypeID\": " + taxpayerTypeID + ", \"TaxPayerID\": " + TaxPayerID + ", \"Notes\": \"" + Notes + "\", \"AssetTypeID\": "+AssetTypeID+", \"AssetID\": "+AssetID+", \"ProfileID\": "+ProfileId+", \"AssessmentRuleID\": "+AssesmentRuleId+", \"TaxYear\": "+TaxYear+", \"LstAssessmentItem\": [ { \"AssessmentItemID\": "+AssessmentItemId+", \"TaxBaseAmount\": "+taxBaseAmt+" } ] }";

                    string myParameters = "{ \"TaxPayerTypeID\": " + taxpayerTypeID1 + ", \"TaxPayerID\": " + TaxPayerID1 + ", \"Notes\": \"" + Notes1 + "\", \"AssetTypeID\": " + AssetTypeID1 + ", \"AssetID\": " + AssetID1 + ", \"ProfileID\": " + ProfileId1 + ", \"AssessmentRuleID\": " + AssesmentRuleId1 + ", \"TaxYear\": " + TaxYear1 + ", \"LstAssessmentItem\": [ { \"AssessmentItemID\": " + AssessmentItemId1 + ", \"TaxBaseAmount\": " + taxBaseAmt1 + " } ] }";
                    Session["AssetId"] = "0";
                    string InsCompRes = "";
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                        wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                        string json = JsonConvert.SerializeObject(Assessment);
                        InsCompRes = wc.UploadString(URI, json);

                        res = InsCompRes.Split('"');

                    }

                    if (res[2].ToString().Contains("true"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into PreAssessmentRDM ([Assessment_RefNo],[TaxPayerTypeID],[TaxPayerID],[AssetTypeID],[AssetID],[ProfileID],[AssessmentRuleID]" +
                        ",[TaxYear],[AssessmentItemID],[TaxBaseAmount],[create_by],[create_at],status) values('" + res[9].ToString() + "','" + Assessment.TaxPayerTypeID + "','" + Assessment.TaxPayerID + "','" + Assessment.AssetTypeID + "','" + Assessment.AssetID + "','" + Assessment.ProfileID + "','" + Assessment.AssessmentRuleID + "','" + Assessment.TaxYear + "','" + Assessment.LstAssessmentItem[0].AssessmentItemID + "','" + Assessment.LstAssessmentItem[0].TaxBaseAmount + "', '" + Session["user_id"] + "', '" + DateTime.Now.ToString() + "', 'Success')", con);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        msg = msg + "Assessment Added Successfully. Ref. No. " + res[9].ToString() + " For TaxPayer " + gvrow.Cells[7].Text + "(" + gvrow.Cells[11].Text + ") " +System.Environment.NewLine;
                       // showmsg(1, "Assessment Added Successfully. Ref. No. " + res[9].ToString());
                    }

                    if (res[2].ToString().Contains("false"))
                    {
                        msg = msg + res[5].ToString() + " For TaxPayer" + gvrow.Cells[7].Text + "(" + gvrow.Cells[11].Text + ")  " + System.Environment.NewLine;
                        //showmsg(2, res[5].ToString());
                    }

                }

                //if (check == 0)
                //{
                //    ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Please Select a Company');</script>", false);
                //    return;
                //}



            }

            showmsg(1, "" + msg);
        }
        catch (Exception ex)
        {
            showmsg(2, "Error Occured. Contact to Administrator.");
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
    protected void grdempcollection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text != "&nbsp;")
                {
                    DataTable dt_list = new DataTable();
                    SqlDataAdapter Adp = new SqlDataAdapter("select * from PreAssessmentRDM where taxpayertypeid=" + e.Row.Cells[0].Text + " and TaxPayerID=" + e.Row.Cells[1].Text + " and AssetId=" + e.Row.Cells[3].Text + " and ProfileID=" + e.Row.Cells[4].Text + " and AssessmentRuleID=" + e.Row.Cells[6].Text + " and AssessmentItemID=" + e.Row.Cells[5].Text + " and TaxYear=" + e.Row.Cells[11].Text.Split('-')[1], con);
                    Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
                    Adp.Fill(dt_list);

                    CheckBox chkbox = (CheckBox)e.Row.FindControl("chkrdm");
                    Label lbl_status = (Label)e.Row.FindControl("lbl_status");

                    if (dt_list.Rows.Count > 0)
                    {

                        chkbox.Visible = false;
                        lbl_status.Visible = true;
                        lbl_status.Text = "Done";

                    }

                    else
                    {

                        chkbox.Visible = true;
                        lbl_status.Visible = false;
                        lbl_status.Text = "";
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        DataView dt_list_s = new DataView();
        dt_list_s = (DataView)Session["dtempcollection"];
        
        DataView dt_v = dt_list_s;
        if (txt_employer_RIN.Text != "")
        {
            dt_v.RowFilter = "EmployerRIN like '%" + txt_employer_RIN.Text + "%' or Asset like '%" + txt_employer_RIN.Text + "%' or Rule like '%" + txt_employer_RIN.Text + "%' or EmployerName like '%" + txt_employer_RIN.Text + "%'";

            if (txt_tax_year.SelectedItem.Text != "--Select Year--")
                dt_v.RowFilter = "(EmployerRIN like '%" + txt_employer_RIN.Text + "%' or Asset like '%" + txt_employer_RIN.Text + "%' or Rule like '%" + txt_employer_RIN.Text + "%' or EmployerName like '%" + txt_employer_RIN.Text + "%') and (TaxMonthYear like '%" + txt_tax_year.SelectedItem.Text + "%')";


        }
        if (txt_tax_year.SelectedItem.Text != "--Select Year--" && txt_employer_RIN.Text == "")
            dt_v.RowFilter = "TaxMonthYear like '%" + txt_tax_year.SelectedItem.Text + "%'";



        grdempcollection.DataSource = dt_v;
        grdempcollection.DataBind();

        int pagesize = grdempcollection.Rows.Count;
        int from_pg = 1;
        int to = grdempcollection.Rows.Count;
        int totalcount = dt_v.Count;
    }
}