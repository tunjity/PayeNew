using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;

public partial class CalculateTax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            binddrop();
            if (Session["comprin"] != null)
            {
                drpcomp.SelectedValue = Session["comprin"].ToString().Trim();
                drpcomp_SelectedIndexChanged(null, null);
                drpcomp.Enabled = false;
                Session["comprin"] = null;
            }
        }
        

    }

    protected void drpcomp_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        /***************************************************************/
        string[] res;
        //string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/List";
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/Search";
        URI = PAYEClass.URL_API + "TaxPayer/Company/Search";
        string myParameters = "CompanyRIN=" + drpcomp.SelectedValue.Trim();

        string InsCompRes = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();

            InsCompRes = wc.UploadString(URI, myParameters);

            res = InsCompRes.Split('"');

        }


        DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

        DataRow[] filteredRows = dt_list.Select("CompanyRIN LIKE '" + drpcomp.SelectedValue.Trim() + "'");
        DataTable dt_filtered = new DataTable();

        if (filteredRows.Length > 0)
        {
            dt_filtered = filteredRows.CopyToDataTable();
            Session["CompanyId"] = dt_filtered.Rows[0]["CompanyID"].ToString();
        }
        else
        {
            Session["CompanyId"] = "0";
        }

        /**************************************************************/
      
        binddrop_business();
        lblRin.Text = drpcomp.SelectedValue.Trim();
        lblAddress.Text = getaddress();


    }

    public string getaddress()
    {
        string address = "";
        string qryaddress = "Select  (Add1_hno +' ' + Add2_street + ' '+Add3_offstreet_town) as Address from Companies where company_rin='" + drpcomp.SelectedValue.Trim() + "'";
        DataTable dtadd = new DataTable();
        dtadd = PAYEClass.fetchdata(qryaddress);
        if (dtadd.Rows.Count > 0)
        {
            address = dtadd.Rows[0]["Address"].ToString();
        }
        else
        {
            address = "NA";
        }
        return address;
    }

    public void binddrop()
    {
        string qry = "Select * from Companies";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        drpcomp.DataSource = dt;
        drpcomp.DataTextField = "company_name";
        drpcomp.DataValueField = "company_rin";
        drpcomp.DataBind();
        drpcomp.Items.Insert(0, "-------select------");
    }

    public void binddrop_business()
    {
        string[] res;
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetPayeAsset?companyId=" + Session["CompanyId"];
        URI = PAYEClass.URL_API + "TaxPayer/Company/GetPayeAsset?companyId=" + Session["CompanyId"];

        //  string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetPayeAsset?companyId=120";
        string myParameters = "";

        string InsCompRes = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();

            InsCompRes = wc.DownloadString(URI);

            res = InsCompRes.Split('"');

        }

        if (res[6].ToString() != ":[]}")
        {
            DataTable dt_Asset_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

            if (dt_Asset_list.Rows.Count > 0)
            {
                dpd_business.DataSource = dt_Asset_list;
                dpd_business.DataTextField = "AssetName";
                dpd_business.DataValueField = "AssetRIN";
                dpd_business.DataBind();
                dpd_business.Items.Insert(0, "-------select------");
                tr_dpd_business.Style.Add("display", "");

            }
            else
            {
                tr_dpd_business.Style.Add("display", "none");
                cal_tax(drpcomp.SelectedValue);
            }
        }

        else
        {
            string qry = "Select * from Businesses where CompanyRIN='" + drpcomp.SelectedValue + "'";
            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(qry);
            dpd_business.DataSource = dt;
            dpd_business.DataTextField = "business_name";
            dpd_business.DataValueField = "business_rin";
            dpd_business.DataBind();
            dpd_business.Items.Insert(0, "-------select------");

            if (dt.Rows.Count > 0)
            {
                tr_dpd_business.Style.Add("display", "");
            }
            else
            {
                tr_dpd_business.Style.Add("display", "none");
                cal_tax(drpcomp.SelectedValue);
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        grdEmpConfirm.Visible = false;
        divasses.Style.Add("display", "none");
        divmsg.Style.Add("display", "");
        lblassessref.InnerText = lblassesno.Text.ToString();
        lblmonthtax.InnerText = lblmonthlytax.Text.ToString();
        Session["comptin"] = null;
        if (insassess() == 1)
        {
            
        }
        
    }

    public int insassess()
    {
        SqlParameter[] pram = new SqlParameter[5];
        pram[0] = new SqlParameter("@assess_create_by", 1);
        pram[1] = new SqlParameter("@assessment_ref", lblassesno.Text.ToString());
        pram[2] = new SqlParameter("@assessment_amount", lbltaxcalc.Text.ToString());

        if (dpd_business.SelectedValue == "-------select------")
            pram[3] = new SqlParameter("@company_rin", drpcomp.SelectedValue.Trim());
        else
            pram[3] = new SqlParameter("@company_rin", dpd_business.SelectedValue.Trim());

       
        pram[4] = new SqlParameter("@SucessId", 1);
        pram[4].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_Assessment", pram);
        return int.Parse(pram[4].Value.ToString());
    }

    public double annualtax()
    {
        double ann_tax = 0;
        if (dpd_business.SelectedValue == "-------select------")
            ann_tax = increement_case(lblRin.Text) - refund_case(lblRin.Text);
        else
            ann_tax = increement_case(dpd_business.SelectedValue) - refund_case(dpd_business.SelectedValue);

       

        return ann_tax;
    }

    public double increement_case(string companyrin)
    {
        double total_increment_case = 0;
        string qry = "select Sum(Jan+Feb+Mar+Apr+May+Jun+Jul+Aug+Sep+Oct+Nov+Dec) as Total,company_rin  from vw_sal_bkup_increment_case where company_rin='" + companyrin.Trim() + "' group by (company_rin)";
        DataTable dtincrement = new DataTable();
        dtincrement = PAYEClass.fetchdata(qry);
        if (dtincrement.Rows.Count > 0)
        {
            total_increment_case = double.Parse(dtincrement.Rows[0]["Total"].ToString());
        }
        else
        {
            total_increment_case = 0;
        }
        return total_increment_case;
    }

    public double refund_case(string companyrin)
    {
        double total_refund_case = 0;
        string qry = "SELECT [assessment_amount] -([IncCase]+[AfterJoin]) as FinalRefundAmount FROM vw_Refund_Final where company_rin='" + companyrin.Trim() + "'";
        DataTable dtincrement = new DataTable();
        dtincrement = PAYEClass.fetchdata(qry);
        if (dtincrement.Rows.Count > 0)
        {
            total_refund_case = double.Parse(dtincrement.Rows[0]["FinalRefundAmount"].ToString());
        }
        else
        {
            total_refund_case = 0;
        }
        return total_refund_case;
    }

    protected void grdEmpConfirm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkmonthly");
                string lblindid = ((Label)e.Row.FindControl("lblindid")).Text.ToString().Trim();
                string url = "MonthlyTax.aspx?empid=" + lblindid;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=200px,height=100px,left=0,top=0')");
            }
        }
        catch (Exception)
        { 

        }
    }
    protected void dpd_business_SelectedIndexChanged(object sender, EventArgs e)
    {
        cal_tax(dpd_business.SelectedValue);
    }

    public void cal_tax(string RIN)
    {

        divassessmentdone.Style.Add("display", "none");
        string qry = "SELECT [company_id],[ind_id],[first_name],[last_name],[tin],[nationality],[sal_id],[sal_calc_tax],[company_name],[company_tin],[gender],[title],";
        qry += "ROUND([sal_gross]/12,2) as sal_gross,Round([sal_basic]/12,2) as sal_basic,Round([sal_rent]/12,2) as sal_rent,round([sal_trans]/12,2) as sal_trans";
        qry += ",round([sal_pension]/12,2) as sal_pension,round([sal_nhf]/12,2) as sal_nhf,round([sal_nhis]/12,2) as sal_nhis,round([sal_ch_income]/12,2) as sal_ch_income";
        qry += ",[sal_tax_free_pay],[sal_calc_tax_monthly],[start_date],[sal_employee_id],Address,company_rin_ok,user_rin FROM [vw_comp_ind_sal] where company_rin_ok='" + RIN + "'";

        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        if (dt.Rows.Count > 0)
        {
            // lblRin.Text = drpcomp.SelectedValue.ToString().Trim();
            lblRin.Text = RIN;
            lblAddress.Text = dt.Rows[0]["Address"].ToString().Trim();
            grdEmpConfirm.DataSource = dt;
            grdEmpConfirm.DataBind();
            grdEmpConfirm.Visible = true;
            divmsg.Style.Add("display", "none");
            divasses.Style.Add("display", "");

            lbltaxcalc.Text = annualtax().ToString();
            lblmonthlytax.Text = (Math.Round((annualtax() / 12), 2)).ToString();
            lblassesno.Text = PAYEClass.generateAssessmentNo(drpcomp.SelectedValue.Trim());

            currency.InnerHtml = PAYEClass.currency;
            currencymonth.InnerHtml = PAYEClass.currency;

            string qrycheck = "select 1 from Assessments where company_rin='" + RIN + "' and tax_year=YEAR(GETDATE())";
            DataTable dtcheck = new DataTable();
            dtcheck = PAYEClass.fetchdata(qrycheck);
            if (dtcheck.Rows.Count > 0)
            {
                divassessmentdone.Style.Add("display", "");
                divassessmentdone.InnerText = "Assessment has already been done for this Employer for this year";
                btnsubmit.Visible = false;
            }
            else
            {
                divassessmentdone.Style.Add("display", "none");
                btnsubmit.Visible = true;
            }
        }
        else
        {

            DataTable dt1 = new DataTable();
            grdEmpConfirm.Visible = true;
            grdEmpConfirm.DataSource = dt1;
            grdEmpConfirm.DataBind();
            divmsg.Style.Add("display", "none");
            divasses.Style.Add("display", "none");
            lblRin.Text = drpcomp.SelectedValue.Trim();
            lblAddress.Text = getaddress();
        }

    }
}