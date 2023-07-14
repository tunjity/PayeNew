using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Xml.Linq;
using System.Net;
using Newtonsoft.Json;

public partial class Submissions_Action : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["Sub_Action"]==null)
            Session["Sub_Action"] = "I";

            if (Request.QueryString["TaxPayer"] != null)
            {
                Session["Sub_TaxPayer"] = Request.QueryString["TaxPayer"].ToString();
                Session["Sub_CompanyName"] = Request.QueryString["CompanyName"].ToString();
                Session["Sub_Asset"] = Request.QueryString["Asset"].ToString();
                Session["Sub_AssessmentRule"] = Request.QueryString["AssessmentRule"].ToString();
                Session["Sub_AssessmentItems"] = Request.QueryString["AssessmentItems"].ToString();
                Session["Sub_Action"] = Request.QueryString["Action"].ToString();
                Session["Sub_TaxBaseAmount"] = Request.QueryString["TaxBaseAmount"];
                Session["Sub_TaxYear"] = Request.QueryString["TaxYear"];
                Session["Sub_SubmissionNotes"] = Request.QueryString["SubmissionNotes"].ToString();

                Response.Redirect("Submissions_Action.aspx");
            }

            binddrop();

            if (Session["Sub_Action"].ToString() == "E")
            {
                txtEmpName.Text = Session["Sub_TaxPayer"].ToString() + "--" + Session["Sub_CompanyName"].ToString();
                txtEmpName.Enabled = false;

                DataTable dt_E = new DataTable();
                dt_E = null;
                string qry_E = "Select distinct BusinessRIN,BusinessName from Businesses_Full_API where TaxPayerRIN='" + Session["Sub_TaxPayer"].ToString() + "'";
                dt_E = PAYEClass.fetchdata(qry_E);
                drpempbusiness.DataSource = dt_E;
                drpempbusiness.DataTextField = "BusinessName";
                drpempbusiness.DataValueField = "BusinessRIN";
                drpempbusiness.DataBind();
                drpempbusiness.Enabled = false;

                drpassessmentrule.SelectedValue= Session["Sub_AssessmentRule"].ToString();
                drpassessmentrule.Enabled = false;

                drpassessmentitems.SelectedValue = Session["Sub_AssessmentItems"].ToString();
                drpassessmentitems.Enabled = false;

                drpTaxyear.SelectedValue = Session["Sub_TaxYear"].ToString();
                drpTaxyear.Enabled = false;

                txtsubmissionamt.Text = Session["Sub_TaxBaseAmount"].ToString();
                //txtsubmissionamt.Enabled = false;

                txtsubmissionnotes.Text = Session["Sub_SubmissionNotes"].ToString();
                //txtsubmissionnotes.Enabled = false;
            }
        }
    }

    public void binddrop()
    {
        string qry = "Select top 100 CompanyName,CompanyRIN from Companies_API";
        DataTable dt = new DataTable();
        //dt = PAYEClass.fetchdata(qry);
        //drpemployer.DataSource = dt;
        //drpemployer.DataTextField = "CompanyName";
        //drpemployer.DataValueField = "CompanyRIN";
        //drpemployer.DataBind();

        dt = null;
        //qry = "Select top 100 BusinessRIN,BusinessName from Businesses_API";
        //dt = PAYEClass.fetchdata(qry);
        //drpempbusiness.DataSource = dt;
        //drpempbusiness.DataTextField = "BusinessName";
        //drpempbusiness.DataValueField = "BusinessRIN";
        //drpempbusiness.DataBind();

        dt = null;
        qry = "Select top 100 AssessmentRuleName,AssessmentRuleID,TaxYear from Assessment_Rules_API";
        dt = PAYEClass.fetchdata(qry);
        drpassessmentrule.DataSource = dt;
        drpassessmentrule.DataTextField = "AssessmentRuleName";
        drpassessmentrule.DataValueField = "AssessmentRuleName";
        drpassessmentrule.DataBind();

        dt = null;
        qry = "Select top 100 AssessmentItemName,AssessmentItemID from Assessment_Item_API";
        dt = PAYEClass.fetchdata(qry);
        drpassessmentitems.DataSource = dt;
        drpassessmentitems.DataTextField = "AssessmentItemName";
        drpassessmentitems.DataValueField = "AssessmentItemName";
        drpassessmentitems.DataBind();

        dt = null;

        for (int i = DateTime.Now.Year; i >= 2014; i--)
        {
            drpTaxyear.Items.Add(i.ToString());
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string selectedValue = Request.Form[drpempbusiness.UniqueID];
        string[] taxPayer = txtEmpName.Text.Split(new[] { "--" }, StringSplitOptions.None);
        SqlParameter[] pram = new SqlParameter[10];
     //   pram[0] = new SqlParameter("@taxpayer", drpemployer.SelectedValue.ToString().Trim());
        pram[0] = new SqlParameter("@taxpayer", taxPayer[0].ToString());
        pram[1] = new SqlParameter("@asset", selectedValue.Trim());// Session["brin"].ToString().Trim()
        pram[2] = new SqlParameter("@assessmentrule", drpassessmentrule.SelectedValue.ToString().Trim());
        pram[3] = new SqlParameter("@taxyear", drpTaxyear.SelectedValue.Trim());
        pram[4] = new SqlParameter("@assessmentitems", drpassessmentitems.SelectedValue.ToString().Trim());
        pram[5] = new SqlParameter("@taxbaseamount", txtsubmissionamt.Text.ToString().Trim());
        pram[6] = new SqlParameter("@submissionnotes", txtsubmissionnotes.Text.ToString().Trim());
        pram[7] = new SqlParameter("@month", Convert.ToDateTime("01-" + (drpassessmentitems.SelectedValue.Replace("Pay As You Earn - PAYE ", "").Replace("Collections", "").Trim()) + "-2011").Month);
        pram[8] = new SqlParameter("@action", Session["Sub_Action"].ToString());
        pram[9] = new SqlParameter("@SucessId", 1);
        pram[10] = new SqlParameter("@assessmentruleid", drpassessmentrule.SelectedValue.ToString().Trim());
        pram[9].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_SUBMISSIONS", pram);
        int status  = int.Parse(pram[9].Value.ToString());

        if (status == 1)
        {
            lblmsg.Text = "Submission Added Successfully.";
            lblmsg.CssClass = "alert alert-success";
            lblmsg.Visible = true;
        }

        if (status == 11)
        {
            lblmsg.Text = "Submission Updated Successfully.";
            lblmsg.CssClass = "alert alert-success";
            lblmsg.Visible = true;
        }


        if (status == 2)
        {
            lblmsg.Text = "Submitted Record Already In List.";
            lblmsg.CssClass = "alert alert-warning";
            lblmsg.Visible = true;
        }

        if (status == -1)
        {
            lblmsg.Text = "Error Occured!! Contact to Administrator.";
            lblmsg.CssClass = "alert alert-warning";
            lblmsg.Visible = true;
        }


    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Session["Sub_Action"] = null;
        Response.Redirect("Submission_N.aspx");
    }


    [WebMethod]
    public static List<string> GetCustomers(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
          //  conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            conn.ConnectionString = PAYEClass.connection;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select top 100 (CompanyRIN--CompanyName) as CompanyName,CompanyRIN from Companies_API where CompanyName like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["CompanyName"], sdr["CompanyRIN"]));
                    }
                }
                conn.Close();
            }
        }
        return customers;
    }

    [WebMethod]
    public void Bind_Business_Dropdown()
    {
        DataTable dt = new DataTable();
        dt = null;
        string qry = "Select top 100 BusinessRIN,BusinessName from Businesses_API where ";
        dt = PAYEClass.fetchdata(qry);
        drpempbusiness.DataSource = dt;
        drpempbusiness.DataTextField = "BusinessName";
        drpempbusiness.DataValueField = "BusinessRIN";
        drpempbusiness.DataBind();
    }



    [WebMethod]
    public static List<string> GetEmployeeName(string empName)
    {
        List<string> empResult = new List<string>();
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = PAYEClass.connection;
            using (SqlCommand cmd = new SqlCommand())
            {
               // cmd.CommandText = "Select top 100 (CompanyRIN+'--'+CompanyName) as CompanyName,CompanyRIN from Companies_API where CompanyName LIKE ''+@SearchEmpName+'%'";

                cmd.CommandText = "Select distinct (CompanyRIN+'--'+CompanyName) as CompanyName,CompanyRIN from vw_InputFile where CompanyName LIKE ''+@SearchEmpName+'%'";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@SearchEmpName", empName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empResult.Add(dr["CompanyName"].ToString());
                }
                con.Close();
                return empResult;
            }
        }
    }


    //[System.Web.Services.WebMethod(EnableSession = true)]
    [WebMethod(EnableSession = true)]
    public static void GetBusinesses()
    {
        string compRIN = "";
        
       
        
        Page page = (Page)HttpContext.Current.Handler;
        DropDownList drpempbusiness = (DropDownList)page.FindControl("drpempbusiness");
        TextBox txtEmpName = (TextBox)page.FindControl("txtEmpName");
        
        string[] taxPayer = txtEmpName.Text.Split(new[] { "--" }, StringSplitOptions.None);
        compRIN = taxPayer[0].ToString();
        
        /***************************************************************/
        string[] res;
        //string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/List";
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/Search";
        string myParameters = "CompanyRIN=" + compRIN.Trim();

        string InsCompRes = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + HttpContext.Current.Session["token"].ToString();

            InsCompRes = wc.UploadString(URI, myParameters);

            res = InsCompRes.Split('"');

        }


        DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

        DataRow[] filteredRows = dt_list.Select("CompanyRIN LIKE '" + compRIN.Trim() + "'");
        DataTable dt_filtered = new DataTable();

        if (filteredRows.Length > 0)
        {
            dt_filtered = filteredRows.CopyToDataTable();
            HttpContext.Current.Session["CompanyId"] = dt_filtered.Rows[0]["CompanyID"].ToString();
        }
        else
        {
            HttpContext.Current.Session["CompanyId"] = "0";
        }

        /**************************************************************/
        // Session["CompanyId"] = drpfupcomapny.SelectedValue;

        string[] res1;
        string URI1 = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetPayeAsset?companyId=" + HttpContext.Current.Session["CompanyId"];
        //  string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetPayeAsset?companyId=120";
        string myParameters1 = "";
        HttpContext.Current.Session["AssetId"] = "0";
        string InsCompRes1 = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + HttpContext.Current.Session["token"].ToString();

            InsCompRes1 = wc.DownloadString(URI);

            res1 = InsCompRes1.Split('"');

        }

        if (res1[6].ToString() != ":[]}")
        {
            DataTable dt_Asset_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes1.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

            if (dt_Asset_list.Rows.Count > 0)
            {
                drpempbusiness.DataSource = dt_Asset_list;
                drpempbusiness.DataTextField = "AssetName";
                drpempbusiness.DataValueField = "AssetRIN";
                drpempbusiness.DataBind();
                drpempbusiness.Visible = true;
                drpempbusiness.Visible = false;
                HttpContext.Current.Session["AssetId"] = dt_Asset_list.Rows[0]["AssetID"].ToString();
            }
            else
            {
                drpempbusiness.DataSource = null;
                drpempbusiness.Visible = false;
                drpempbusiness.Visible = true;
            }
        }

        else
        {
            string qry = "Select business_name, business_rin from Businesses where companyRIN='" + compRIN.ToString().Trim() + "' ";
            DataTable dtbusiness = new DataTable();
            dtbusiness = PAYEClass.fetchdata(qry);
            if (dtbusiness.Rows.Count > 0)
            {
                drpempbusiness.DataSource = dtbusiness;
                drpempbusiness.DataTextField = "business_name";
                drpempbusiness.DataValueField = "business_rin";
                drpempbusiness.DataBind();
                drpempbusiness.Visible = true;
                drpempbusiness.Visible = false;
            }
            else
            {
                drpempbusiness.DataSource = null;
                drpempbusiness.Visible = false;
                drpempbusiness.Visible = true;
            }
        }
       // return compRIN;
    }




    [WebMethod(EnableSession = true)]
    public static List<ListItem> GetBusinesses(string empName)
    {
        /*****************************/
        string compRIN = "";
        string[] taxPayer = empName.Split(new[] { "--" }, StringSplitOptions.None);
        compRIN = taxPayer[0].ToString();
        /****************************/

        string query = "Select distinct BusinessRIN_1,BusinessName from vw_InputFile where CompanyRIN='" + compRIN + "'";
        
        
        string constr = PAYEClass.connection;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                List<ListItem> customers = new List<ListItem>();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new ListItem
                        {
                            Value = sdr["BusinessRIN_1"].ToString(),
                            Text = sdr["BusinessName"].ToString()
                        });
                    }
                }
                con.Close();
                return customers;
            }
        }
    }


    public void get_compid()
    {
       

    }
    //[System.Web.Script.Services.ScriptMethod()]

    //[System.Web.Services.WebMethod]

    //public static List<string> GetListofCountries(string prefixText)
    //{

    //    using (SqlConnection sqlconn = new SqlConnection())
    //    {
    //        sqlconn.ConnectionString = PAYEClass.connection;
    //        sqlconn.Open();

    //        SqlCommand cmd = new SqlCommand("Select top 100 CompanyName,CompanyRIN from Companies_API where CompanyName like '" + prefixText + "%' ", sqlconn);

    //        cmd.Parameters.AddWithValue("@Country", prefixText);

    //        SqlDataAdapter da = new SqlDataAdapter(cmd);

    //        DataTable dt = new DataTable();

    //        da.Fill(dt);

    //        List<string> CountryNames = new List<string>();

    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {

    //            CountryNames.Add(dt.Rows[i]["country"].ToString());

    //        }

    //        return CountryNames;

    //    }

    //}

    protected void txtEmpName_TextChanged(object sender, EventArgs e)
    {
        
        
    }
    protected void drpempbusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["brin"] = drpempbusiness.SelectedValue.ToString();
    }
    protected void drpempbusiness_SelectedIndexChanged1(object sender, EventArgs e)
    {
      //  lbl_business_val.Text = drpempbusiness.SelectedValue;
    }
}
