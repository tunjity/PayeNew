using Newtonsoft.Json;
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

public partial class AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            binddropdowns();
            tblupdemp.Style.Add("display", "none");
            if (Session["comp_rin"] != null)
            {
                string[] val = new string[2];
                val = Session["comp_rin"].ToString().Trim().Split(',');
                drpfupcomapny.SelectedValue = val[1].ToString().Trim();
                drpfupcomapny_SelectedIndexChanged(null, null);
                drpfupcomapny.Enabled = false;
              //  showmsg(1, val[0].ToString());
                LinkButton_Click(null, null);
                addindividual.Style.Add("display", "none");
                Session["comp_rin"] = null;
            }
        }
        
    }

    protected void drpfupcomapny_SelectedIndexChanged(object sender, EventArgs e)
    {

        get_compid();
       // Session["CompanyId"] = drpfupcomapny.SelectedValue;
       
            string[] res;
            string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetPayeAsset?companyId=" + Session["CompanyId"];
            URI = PAYEClass.URL_API + "TaxPayer/Company/GetPayeAsset?companyId=" + Session["CompanyId"];

            //  string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetPayeAsset?companyId=120";
            string myParameters = "";
            Session["AssetId"] = "0";
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
                    drpbusiness.DataSource = dt_Asset_list;
                    drpbusiness.DataTextField = "AssetName";
                    drpbusiness.DataValueField = "AssetRIN";
                    drpbusiness.DataBind();
                    drpbusiness.Visible = true;
                    lblnabusiness.Visible = false;
                    Session["AssetId"] = dt_Asset_list.Rows[0]["AssetID"].ToString();
                }
                else
                {
                    drpbusiness.DataSource = null;
                    drpbusiness.Visible = false;
                    lblnabusiness.Visible = true;
                }
            }

            else
            {
                string qry = "Select business_name, business_rin from Businesses where companyRIN='" + drpfupcomapny.SelectedValue.ToString().Trim() + "' ";
                DataTable dtbusiness = new DataTable();
                dtbusiness = PAYEClass.fetchdata(qry);
                if (dtbusiness.Rows.Count > 0)
                {
                    drpbusiness.DataSource = dtbusiness;
                    drpbusiness.DataTextField = "business_name";
                    drpbusiness.DataValueField = "business_rin";
                    drpbusiness.DataBind();
                    drpbusiness.Visible = true;
                    lblnabusiness.Visible = false;
                }
                else
                {
                    drpbusiness.DataSource = null;
                    drpbusiness.Visible = false;
                    lblnabusiness.Visible = true;
                }
            }

    }

    public void ClearAllTextBox()
    {
        foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Text = string.Empty;
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      
        if (insertindividual() >= 1)
        {
            showmsg(1,"Employee Created Successfully");
            ClearAllTextBox();
            pnlEmp.Visible = true;
        }
        else
        {
            showmsg(2, "Error occured. Please contact technical support for help");
            pnlEmp.Visible = false;
        }
    }

    public void showmsg(int id,string msg)
    {
        if (id == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-check-circle' style='font-size:20px !important;'></i>&nbsp;"+msg+"";
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

    public int insertindividual()
    {
        double total_ch_sal = 0;
        double total_annual_tax = 0;
        double gross = double.Parse(txtgross.Text.Trim());
        double basic = double.Parse(txtbasic.Text.Trim());
        double rent = double.Parse(txtRent.Text.Trim());
        double trans = double.Parse(txttrans.Text.Trim());
        double pension = 0;
        double pension_declared = 0;
        if (double.Parse(txtpensiondeclared.Text.Trim()) == 0 && chkpensionadd.Checked)
        {
            pension = 1;
        }
        else
        {
            pension_declared = double.Parse(txtpensiondeclared.Text.Trim());
        }

        double nhf = 0;//PAYEClass.computeformula(basic, rent, trans, "NHF");
        double nhf_declared = 0;// double.Parse(txtnhfdeclared.Text.Trim());
        if (double.Parse(txtnhfdeclared.Text.Trim()) == 0 && chknhfadd.Checked)
        {
            nhf = 1;
        }
        else
        {
            nhf_declared = double.Parse(txtnhfdeclared.Text.Trim());
        }


        double nhis = 0;// PAYEClass.computeformula(basic, rent, trans, "NHIS");
        double nhis_declared = 0;// double.Parse(txtnhisdeclared.Text.Trim());
        if (double.Parse(txtnhisdeclared.Text.Trim()) == 0 && chknhisadd.Checked)
        {
            nhis = 1;
        }
        else
        {
            nhis_declared = double.Parse(txtnhisdeclared.Text.Trim());
        }

        string gender = radgender.SelectedValue.ToString().Trim();
        string title = drptitle.SelectedValue.Trim();
        string first_name = txtfirstname.Text.Trim();
        string last_name=txtlastname.Text.Trim();
        string lbltin = txtemptin.Text.Trim();
        string company_rin = drpfupcomapny.SelectedValue.Trim();
        string mobile_number = txtmobile.Text.Trim();
        string emailaddress = txtemail.Text.Trim();
        string lblnationality = txtnationality.Text.Trim();
        string lblgross = txtgross.Text.Trim();
        string lblbasic = txtbasic.Text.Trim();
        string lblrent = txtRent.Text.Trim();
        string lbltrans = txttrans.Text.Trim();
        string lblpension = txtpensiondeclared.Text.Trim();
        string lblnhf = txtnhfdeclared.Text.Trim();
        string lblnhis = txtnhisdeclared.Text.Trim();
        string utility = txtutilityadd.Text.Trim();
        string meal = txtmealadd.Text.Trim();
        string othall = txtothalladd.Text.Trim();
        string ltg = txtltgadd.Text.Trim();
        string user_rin  = txtRINadd.Text.Trim();
        string lbldob = txtdob.Text.Trim();
        string lblstart_date = txtsalarystartdate.Text.Trim();
        
        double[] sal_brkup = new double[8];
        sal_brkup = PAYEClass.calculatetax(gross, basic, rent, trans, pension, pension_declared, nhf, nhf_declared, nhis, nhis_declared, 12);
        
        DataTable dtfinal = new DataTable();

        dtfinal.Columns.Add("gender", typeof(string));
        dtfinal.Columns.Add("title", typeof(string));
        dtfinal.Columns.Add("first_name", typeof(string));
        dtfinal.Columns.Add("last_name", typeof(string));
        dtfinal.Columns.Add("tin", typeof(string));
        dtfinal.Columns.Add("company_rin", typeof(string));
        dtfinal.Columns.Add("mobile_number", typeof(string));
        dtfinal.Columns.Add("email_address", typeof(string));
        dtfinal.Columns.Add("nationality", typeof(string));
        dtfinal.Columns.Add("sal_gross", typeof(double));
        dtfinal.Columns.Add("sal_basic", typeof(double));
        dtfinal.Columns.Add("sal_rent", typeof(double));
        dtfinal.Columns.Add("sal_trans", typeof(double));
        dtfinal.Columns.Add("sal_pension", typeof(double));
        dtfinal.Columns.Add("sal_pension_declared", typeof(double));
        dtfinal.Columns.Add("sal_nhf", typeof(double));
        dtfinal.Columns.Add("sal_nhf_declared", typeof(double));
        dtfinal.Columns.Add("sal_nhis", typeof(double));
        dtfinal.Columns.Add("sal_nhis_declared", typeof(double));
        dtfinal.Columns.Add("sal_ch_income", typeof(double));
        dtfinal.Columns.Add("sal_tax_free_pay", typeof(double));
        dtfinal.Columns.Add("sal_calc_tax", typeof(double));
        dtfinal.Columns.Add("sal_calc_tax_monthly", typeof(double));
        dtfinal.Columns.Add("sal_cra", typeof(double));
        dtfinal.Columns.Add("sal_utility", typeof(double));
        dtfinal.Columns.Add("sal_meal", typeof(double));
        dtfinal.Columns.Add("sal_otherallowances", typeof(double));
        dtfinal.Columns.Add("sal_ltg", typeof(double));
        dtfinal.Columns.Add("rin", typeof(string));
        dtfinal.Columns.Add("date_of_birth", typeof(string));
        dtfinal.Columns.Add("start_date", typeof(string));


        dtfinal.Rows.Add(gender, title, first_name, last_name, lbltin, company_rin, mobile_number, emailaddress, lblnationality, lblgross, lblbasic,
               lblrent, lbltrans, sal_brkup[1], lblpension, sal_brkup[2], lblnhf, sal_brkup[3], lblnhis, sal_brkup[5], sal_brkup[4], sal_brkup[6],
               sal_brkup[7], sal_brkup[0], utility, meal, othall, ltg, user_rin, DateTime.Parse(lbldob.Trim()).ToString("yyyy-MM-dd"),
               DateTime.Parse(lblstart_date.Trim()).ToString("yyyy-MM-dd"));

        Session["dtfinal"] = dtfinal;
        return upemp();
    }

    public void binddropdowns()
    {
        string qry = "Select * from nationality";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txtnationality.DataSource = dt;
        txtnationality.DataTextField = "adjective";
        txtnationality.DataValueField = "adjective";
        txtnationality.DataBind();

        qry = "Select * from Companies";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        drpcompany.DataSource = drpfupcomapny.DataSource = dt;
        drpcompany.DataTextField = drpfupcomapny.DataTextField =  "company_name";
        drpcompany.DataValueField = drpfupcomapny.DataValueField = "company_rin";
        drpcompany.DataBind();
        drpfupcomapny.DataBind();
        drpfupcomapny.Items.Insert(0, "---Select---");

        qry = "Select * from Titles";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        drptitle.DataSource = dt;
        drptitle.DataTextField = "title";
        drptitle.DataValueField = "title";
        drptitle.DataBind();
                
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        showmsg(3, "");
        if (fpemp.HasFile)
        {
            if (fpemp.PostedFile.FileName.Contains(".xlsx"))
            {
                ///////////////////////////New Changes Start////////////////////////////////
                HttpPostedFile fileToUpload = fpemp.PostedFile;
                string uploadUrl = PAYEClass.uploadurl;
                string uploadFileName = drpfupcomapny.SelectedValue.Trim() + ".xlsx"; //fpemp.PostedFile.FileName;
                Stream streamObj = fileToUpload.InputStream;
                Byte[] buffer = new Byte[fileToUpload.ContentLength];
                streamObj.Read(buffer, 0, buffer.Length);
                streamObj.Close();
                streamObj = null;

                string ftpUrl = string.Format("{0}/{1}", uploadUrl, uploadFileName);
                FtpWebRequest requestObj = FtpWebRequest.Create(ftpUrl) as FtpWebRequest;
                requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                requestObj.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);
                Stream requestStream = requestObj.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
                requestObj = null;

                addindividual.Style.Add("display", "none");
                uploademployee();

            }
            else
            {
                showmsg(2, "Please upload .xlsx file");
                pnltax.Visible = false;
            }
        }
        else
        {
            showmsg(2, "Please upload a file");
            pnltax.Visible = false;
        }
    }

    public DataTable getdatatable(string filename)
    {
        DataTable dt = new DataTable();
        Workbook workbook = new Workbook();
        workbook.LoadFromFile(filename);
        Worksheet sheet = workbook.Worksheets[0];
        dt = sheet.ExportDataTable();
        return dt;
    }

    public int upemp()
    {
        int status = 0;
        DataTable dt = new DataTable();
        dt = (DataTable)Session["dtfinal"];
        DataTable dtapilist = new DataTable();
        dtapilist = getindividuallistfromapi();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int isValidated = validaterinfromapi(dt.Rows[i]["rin"].ToString().Trim(), dtapilist);
            SqlParameter[] pram = new SqlParameter[35];
            pram[0] = new SqlParameter("@ind_create_by", 1);
            pram[1] = new SqlParameter("@gender", gettitlegender(dt.Rows[i]["gender"].ToString().Trim(), "g"));
            pram[2] = new SqlParameter("@title", gettitlegender(dt.Rows[i]["title"].ToString().Trim(), "t"));
            pram[3] = new SqlParameter("@first_name", dt.Rows[i]["first_name"].ToString().Trim());
            pram[4] = new SqlParameter("@last_name", dt.Rows[i]["last_name"].ToString().Trim());
            pram[5] = new SqlParameter("@tin", dt.Rows[i]["tin"].ToString().Trim());
            pram[6] = new SqlParameter("@company_rin", drpfupcomapny.SelectedValue.Trim());
            pram[7] = new SqlParameter("@mobile_number", dt.Rows[i]["mobile_number"].ToString().Trim());
            pram[8] = new SqlParameter("@email_address", dt.Rows[i]["email_address"].ToString().Trim());
            pram[9] = new SqlParameter("@nationality", gettitlegender(dt.Rows[i]["nationality"].ToString().Trim(), "n"));
            pram[10] = new SqlParameter("@sal_gross",dt.Rows[i]["sal_gross"].ToString());
            pram[11] = new SqlParameter("@sal_basic", dt.Rows[i]["sal_basic"].ToString());
            pram[12] = new SqlParameter("@sal_rent", dt.Rows[i]["sal_rent"].ToString());
            pram[13] = new SqlParameter("@sal_trans", dt.Rows[i]["sal_trans"].ToString());
            pram[14] = new SqlParameter("@sal_pension", dt.Rows[i]["sal_pension"].ToString());
            pram[15] = new SqlParameter("@sal_pension_declared", dt.Rows[i]["sal_pension_declared"].ToString());
            pram[16] = new SqlParameter("@sal_nhf", dt.Rows[i]["sal_nhf"].ToString());
            pram[17] = new SqlParameter("@sal_nhf_declared", dt.Rows[i]["sal_nhf_declared"].ToString());
            pram[18] = new SqlParameter("@sal_nhis", dt.Rows[i]["sal_nhis"].ToString());
            pram[19] = new SqlParameter("@sal_nhis_declared", dt.Rows[i]["sal_nhis_declared"].ToString());
            pram[20] = new SqlParameter("@sal_ch_income", dt.Rows[i]["sal_ch_income"].ToString());
            pram[21] = new SqlParameter("@sal_tax_free_pay", dt.Rows[i]["sal_tax_free_pay"].ToString());
            pram[22] = new SqlParameter("@sal_calc_tax", dt.Rows[i]["sal_calc_tax"].ToString());
            pram[23] = new SqlParameter("@sal_calc_tax_monthly", dt.Rows[i]["sal_calc_tax_monthly"].ToString());

            if (dt.Rows[i]["date_of_birth"].ToString().Trim()=="")
                pram[24] = new SqlParameter("@date_of_birth", dt.Rows[i]["date_of_birth"].ToString().Trim());
            else
            pram[24] = new SqlParameter("@date_of_birth", DateTime.Parse(dt.Rows[i]["date_of_birth"].ToString().Trim()).ToString("yyyy-MM-dd"));
            
            pram[25] = new SqlParameter("@start_date", DateTime.Parse(dt.Rows[i]["start_date"].ToString().Trim()).ToString("yyyy-MM-dd"));
            pram[26] = new SqlParameter("@sal_cra", dt.Rows[i]["sal_cra"].ToString());
            pram[27] = new SqlParameter("@user_rin", dt.Rows[i]["rin"].ToString());
            pram[28] = new SqlParameter("@sal_utility", dt.Rows[i]["sal_utility"].ToString());
            pram[29] = new SqlParameter("@sal_meal", dt.Rows[i]["sal_meal"].ToString());
            pram[30] = new SqlParameter("@sal_otherallowances", dt.Rows[i]["sal_otherallowances"].ToString());
            pram[31] = new SqlParameter("@sal_ltg", dt.Rows[i]["sal_ltg"].ToString());
            pram[32] = new SqlParameter("@isValidated", isValidated);
            pram[33] = new SqlParameter("@business_rin", drpbusiness.SelectedValue.ToString().Trim());
            pram[34] = new SqlParameter("@SucessID", 1);
            pram[34].Direction = System.Data.ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_Individual", pram);
            status += int.Parse(pram[34].Value.ToString());
        }

        return status;
    }

    public void uploademployee()
    {

        /********************************************************************************************************************/
        string[] res;
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetAssetTaxPayer?AssetTypeID=3 &AssetID=" + Session["AssetId"];

        URI = PAYEClass.URL_API + "TaxPayer/Company/GetAssetTaxPayer?AssetTypeID=3 &AssetID=" + Session["AssetId"];

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

        DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

       
        /********************************************************************************************************************/

        //string filepath = Server.MapPath("~") + "/docs/testbookforpaye.xlsx";
        string filepath = Server.MapPath("~") + "/docs/" + drpfupcomapny.SelectedValue.Trim() + ".xlsx";
        DataTable dt = new DataTable();
        dt = getdatatable(filepath);
        try
        {
            DataTable dtfinal = new DataTable();
            dtfinal.Columns.Add("gender", typeof(string));
            dtfinal.Columns.Add("title", typeof(string));
            dtfinal.Columns.Add("first_name", typeof(string));
            dtfinal.Columns.Add("last_name", typeof(string));
            dtfinal.Columns.Add("tin", typeof(string));
            dtfinal.Columns.Add("company_rin", typeof(string));
            dtfinal.Columns.Add("mobile_number", typeof(string));
            dtfinal.Columns.Add("email_address", typeof(string));
            dtfinal.Columns.Add("nationality", typeof(string));
            dtfinal.Columns.Add("sal_gross", typeof(double));
            dtfinal.Columns.Add("sal_basic", typeof(double));
            dtfinal.Columns.Add("sal_rent", typeof(double));
            dtfinal.Columns.Add("sal_trans", typeof(double));
            dtfinal.Columns.Add("sal_pension", typeof(double));
            dtfinal.Columns.Add("sal_pension_declared", typeof(double));
            dtfinal.Columns.Add("sal_nhf", typeof(double));
            dtfinal.Columns.Add("sal_nhf_declared", typeof(double));
            dtfinal.Columns.Add("sal_nhis", typeof(double));
            dtfinal.Columns.Add("sal_nhis_declared", typeof(double));
            dtfinal.Columns.Add("sal_ch_income", typeof(double));
            dtfinal.Columns.Add("sal_tax_free_pay", typeof(double));
            dtfinal.Columns.Add("sal_calc_tax", typeof(double));
            dtfinal.Columns.Add("sal_calc_tax_monthly", typeof(double));
            dtfinal.Columns.Add("sal_cra", typeof(double));
            dtfinal.Columns.Add("sal_utility", typeof(double));
            dtfinal.Columns.Add("sal_meal", typeof(double));
            dtfinal.Columns.Add("sal_otherallowances", typeof(double));
            dtfinal.Columns.Add("sal_ltg", typeof(double));
            dtfinal.Columns.Add("rin", typeof(string));
            dtfinal.Columns.Add("date_of_birth", typeof(string));
            dtfinal.Columns.Add("start_date", typeof(string));


            int status = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow[] filteredRows = dt_list.Select("TaxPayerRINNumber LIKE '" + dt.Rows[i]["RIN"].ToString() + "'");
                DataTable dt_filtered = new DataTable();
                string ind_name = dt.Rows[i]["FirstName"].ToString().Trim();

                if (filteredRows.Length > 0 && ind_name == "")
                {
                    dt_filtered = filteredRows.CopyToDataTable();
                    ind_name = dt_filtered.Rows[0]["TaxPayerName"].ToString();

                }

                if (dt.Rows[i]["RIN"].ToString().Trim() != string.Empty)
                {
                    double basic = 0;
                    if (dt.Rows[i]["Basic"].ToString().Trim() != string.Empty)
                    {
                        basic = double.Parse(dt.Rows[i]["Basic"].ToString().Trim());
                    }
                    else
                    {
                        basic = 0;
                    }
                    double rent = 0;
                    if (dt.Rows[i]["Rent"].ToString().Trim() != string.Empty)
                    {
                        rent = double.Parse(dt.Rows[i]["Rent"].ToString().Trim());
                    }
                    else
                    {
                        rent = 0;
                    }
                    double trans = 0;
                    if (dt.Rows[i]["AnnualTransport"].ToString().Trim() != string.Empty)
                    {
                        trans = double.Parse(dt.Rows[i]["AnnualTransport"].ToString().Trim());
                    }
                    else
                    {
                        trans = 0;
                    }
                    double utility = 0;
                    if (dt.Rows[i]["Utility"].ToString().Trim() != string.Empty)
                    {
                        utility = double.Parse(dt.Rows[i]["Utility"].ToString().Trim());
                    }
                    else
                    {
                        utility = 0;
                    }
                    double meal = 0;
                    if (dt.Rows[i]["Meal"].ToString().Trim() != string.Empty)
                    {
                        meal = double.Parse(dt.Rows[i]["Meal"].ToString().Trim());
                    }
                    else
                    {
                        meal = 0;
                    }
                    double othall = 0;
                    if (dt.Rows[i]["OtherAllowances"].ToString().Trim() != string.Empty)
                    {
                        othall = double.Parse(dt.Rows[i]["OtherAllowances"].ToString().Trim());
                    }
                    else
                    {
                        othall = 0;
                    }
                    double ltg = 0;
                    if (dt.Rows[i]["LTG"].ToString().Trim() != string.Empty)
                    {
                        ltg = double.Parse(dt.Rows[i]["LTG"].ToString().Trim());
                    }
                    else
                    {
                        ltg = 0;
                    }
                    double gross = 0;
                    if (dt.Rows[i]["Gross"].ToString().Trim() != string.Empty)
                    {
                        gross = double.Parse(dt.Rows[i]["Gross"].ToString().Trim());
                    }
                    else
                    {
                        gross = basic + rent + trans + utility + meal + othall + ltg;
                    }
                    double pension = 0;
                    double pension_declared = 0;
                    if (dt.Rows[i]["PensionDeclared"].ToString().Trim() != string.Empty)
                    {
                        pension_declared = double.Parse(dt.Rows[i]["PensionDeclared"].ToString().Trim());
                    }
                    else
                    {
                        pension_declared = 0;

                    }

                    double nhf = 0;
                    double nhf_declared = 0;
                    if (dt.Rows[i]["NHFDeclared"].ToString().Trim() != string.Empty)
                    {
                        nhf_declared = double.Parse(dt.Rows[i]["NHFDeclared"].ToString().Trim());
                    }
                    else
                    {
                        nhf_declared = 0;
                    }

                    double nhis = 0;
                    double nhis_declared = 0;
                    if (dt.Rows[i]["NHISDeclared"].ToString().Trim() != string.Empty)
                    {
                        nhis_declared = double.Parse(dt.Rows[i]["NHISDeclared"].ToString().Trim());
                    }
                    else
                    {
                        nhis_declared = 0;
                    }

                    double[] sal_brkup = new double[8];
                    sal_brkup = PAYEClass.calculatetax(gross, basic, rent, trans, pension, pension_declared, nhf, nhf_declared, nhis, nhis_declared,12);


                    if (dt.Rows[i]["DateofBirth"].ToString().Trim() == "")
                    {
                        dtfinal.Rows.Add(dt.Rows[i]["Gender"].ToString().Trim(), dt.Rows[i]["Title"].ToString().Trim(), ind_name,
                                   dt.Rows[i]["LastName"].ToString().Trim(), dt.Rows[i]["TIN"].ToString().Trim(), drpfupcomapny.SelectedValue.Trim(),
                                   dt.Rows[i]["Mobile"].ToString().Trim(), dt.Rows[i]["EmailAddress"].ToString().Trim(), dt.Rows[i]["Nationality"].ToString().Trim(),
                                   gross, basic, rent, trans, sal_brkup[1], pension_declared, sal_brkup[2], nhf_declared, sal_brkup[3], nhis_declared, sal_brkup[5], sal_brkup[4],
                                   sal_brkup[6], sal_brkup[7], sal_brkup[0], utility, meal, othall, ltg, dt.Rows[i]["RIN"].ToString(), dt.Rows[i]["DateofBirth"].ToString().Trim(),
                                   DateTime.Parse(dt.Rows[i]["SalaryStartDate"].ToString().Trim()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        dtfinal.Rows.Add(dt.Rows[i]["Gender"].ToString().Trim(), dt.Rows[i]["Title"].ToString().Trim(), ind_name,
                                dt.Rows[i]["LastName"].ToString().Trim(), dt.Rows[i]["TIN"].ToString().Trim(), drpfupcomapny.SelectedValue.Trim(),
                                dt.Rows[i]["Mobile"].ToString().Trim(), dt.Rows[i]["EmailAddress"].ToString().Trim(), dt.Rows[i]["Nationality"].ToString().Trim(),
                                gross, basic, rent, trans, sal_brkup[1], pension_declared, sal_brkup[2], nhf_declared, sal_brkup[3], nhis_declared, sal_brkup[5], sal_brkup[4],
                                sal_brkup[6], sal_brkup[7], sal_brkup[0], utility, meal, othall, ltg, dt.Rows[i]["RIN"].ToString(), DateTime.Parse(dt.Rows[i]["DateofBirth"].ToString().Trim()).ToString("yyyy-MM-dd"),
                                DateTime.Parse(dt.Rows[i]["SalaryStartDate"].ToString().Trim()).ToString("yyyy-MM-dd"));
                    }
                }
            }
            Session["dtfinal"] = dtfinal;
            pnltax.Visible = true;
            grdemp.DataSource = dtfinal;
            grdemp.DataBind();
        }
        catch (Exception ex)
        {
            showmsg(2, "Error Occured:" + ex.Message.ToString());
        }
    }

    public DataTable getindividuallistfromapi()
    {
        string[] res;
        string[] asset_det = Session["Asset_Det"].ToString().Split(new string[] { "--" }, StringSplitOptions.None);
       // string URI = "https://api.eirsautomation.xyz/TaxPayer/Individual/List";
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetAssetTaxPayer?AssetTypeID=" + asset_det[2].ToString() + " &AssetID=" + asset_det[4].ToString();
        URI = PAYEClass.URL_API + "TaxPayer/Company/GetAssetTaxPayer?AssetTypeID=" + asset_det[2].ToString() + " &AssetID=" + asset_det[4].ToString();

        string myParameters = "";

        string InsCompRes = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();

            InsCompRes = wc.DownloadString(URI);

            res = InsCompRes.Split('"');

        }

           DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));
          return dt_list;          
    }

    public int validaterinfromapi(string rin, DataTable dtapitable)
    {
        int result = 0;
        //DataRow[] dr = dtapitable.Select("IndividualRIN='" + rin.ToString() + "'");
        DataRow[] dr = dtapitable.Select("TaxPayerRinNumber='" + rin.ToString() + "'");
        if (dr.Length > 0)
        {
            result = 1;
        }
        else
        {
            result = 0;
        }

        return result;

    }

    protected void btncompute_Click(object sender, EventArgs e)
    {
        Session["dtfinal"] = null;
        DataTable dtfinal = new DataTable();
        dtfinal.Columns.Add("gender", typeof(string));
        dtfinal.Columns.Add("title", typeof(string));
        dtfinal.Columns.Add("first_name", typeof(string));
        dtfinal.Columns.Add("last_name", typeof(string));
        dtfinal.Columns.Add("tin", typeof(string));
        dtfinal.Columns.Add("company_rin", typeof(string));
        dtfinal.Columns.Add("mobile_number", typeof(string));
        dtfinal.Columns.Add("email_address", typeof(string));
        dtfinal.Columns.Add("nationality", typeof(string));
        dtfinal.Columns.Add("sal_gross", typeof(double));
        dtfinal.Columns.Add("sal_basic", typeof(double));
        dtfinal.Columns.Add("sal_rent", typeof(double));
        dtfinal.Columns.Add("sal_trans", typeof(double));
        dtfinal.Columns.Add("sal_pension", typeof(double));
        dtfinal.Columns.Add("sal_pension_declared", typeof(double));
        dtfinal.Columns.Add("sal_nhf", typeof(double));
        dtfinal.Columns.Add("sal_nhf_declared", typeof(double));
        dtfinal.Columns.Add("sal_nhis", typeof(double));
        dtfinal.Columns.Add("sal_nhis_declared", typeof(double));
        dtfinal.Columns.Add("sal_ch_income", typeof(double));
        dtfinal.Columns.Add("sal_tax_free_pay", typeof(double));
        dtfinal.Columns.Add("sal_calc_tax", typeof(double));
        dtfinal.Columns.Add("sal_calc_tax_monthly", typeof(double));
        dtfinal.Columns.Add("sal_cra", typeof(double));
        dtfinal.Columns.Add("sal_utility", typeof(double));
        dtfinal.Columns.Add("sal_meal", typeof(double));
        dtfinal.Columns.Add("sal_otherallowances", typeof(double));
        dtfinal.Columns.Add("sal_ltg", typeof(double));
        dtfinal.Columns.Add("rin", typeof(string));
        dtfinal.Columns.Add("date_of_birth", typeof(string));
        dtfinal.Columns.Add("start_date", typeof(string));

        for (int i = 0; i < grdemp.Rows.Count; i++)
        {
            string gender = ((Label)grdemp.Rows[i].FindControl("lblgender")).Text.ToString();
            string title = ((Label)grdemp.Rows[i].FindControl("lbltitle")).Text.ToString();
            string first_name = ((Label)grdemp.Rows[i].FindControl("lblfirst_name")).Text.ToString();
            string last_name = ((Label)grdemp.Rows[i].FindControl("lbllast_name")).Text.ToString();
            string lbltin = ((Label)grdemp.Rows[i].FindControl("lbltin")).Text.ToString();
            string company_rin = ((Label)grdemp.Rows[i].FindControl("lblcompany_rin")).Text.ToString();
            string mobile_number = ((Label)grdemp.Rows[i].FindControl("lblmobilenumber")).Text.ToString();
            string emailaddress = ((Label)grdemp.Rows[i].FindControl("lblemailaddress")).Text.ToString();
            string lblname = ((Label)grdemp.Rows[i].FindControl("lblname")).Text.ToString();
            string lblnationality = ((Label)grdemp.Rows[i].FindControl("lblnationality")).Text.ToString();
            double lblgross = double.Parse(((Label)grdemp.Rows[i].FindControl("lblgross")).Text.ToString());
            double lblbasic = double.Parse(((Label)grdemp.Rows[i].FindControl("lblbasic")).Text.ToString());
            double lblrent = double.Parse(((Label)grdemp.Rows[i].FindControl("lblrent")).Text.ToString());
            double lbltrans = double.Parse(((Label)grdemp.Rows[i].FindControl("lbltrans")).Text.ToString());
            double lblpension = double.Parse(((Label)grdemp.Rows[i].FindControl("lblpension")).Text.ToString());
            double lblnhf = double.Parse(((Label)grdemp.Rows[i].FindControl("lblnhf")).Text.ToString());
            double lblnhis = double.Parse(((Label)grdemp.Rows[i].FindControl("lblnhis")).Text.ToString());
            double utility = double.Parse(((Label)grdemp.Rows[i].FindControl("lblutility")).Text.ToString());
            double meal = double.Parse(((Label)grdemp.Rows[i].FindControl("lblmeal")).Text.ToString());
            double othall = double.Parse(((Label)grdemp.Rows[i].FindControl("lblothall")).Text.ToString());
            double ltg = double.Parse(((Label)grdemp.Rows[i].FindControl("lblltg")).Text.ToString());
            string lbldob = ((Label)grdemp.Rows[i].FindControl("lbldob")).Text.ToString();
            string lblstart_date = ((Label)grdemp.Rows[i].FindControl("lblstart_date")).Text.ToString();
            string user_rin = ((Label)grdemp.Rows[i].FindControl("lbluserrin")).Text.ToString();
            CheckBox chkemp = (CheckBox)grdemp.Rows[i].FindControl("chkemp");

            double pension = lblpension;
            if (chkemp.Checked && chkPension.Checked)
            {
                if (pension == 0)
                {
                    pension = 1;
                }
            }

            double nhf = lblnhf;
            if (chkemp.Checked && chkNHF.Checked)
            {
                if (nhf == 0)
                {
                    nhf = 1;
                }
            }

            double nhis = lblnhis;
            if (chkemp.Checked && chkNHIS.Checked)
            {
                if (nhis == 0)
                {
                    nhis = 1;
                }
            }

            double[] sal_brkup = new double[8];
            sal_brkup = PAYEClass.calculatetax(lblgross, lblbasic, lblrent, lbltrans, pension, lblpension, nhf, lblnhf, nhis, lblnhis,12);

            if (lbldob.Trim() == "")
            {
                dtfinal.Rows.Add(gender, title, first_name, last_name, lbltin, company_rin, mobile_number, emailaddress, lblnationality, lblgross, lblbasic,
                    lblrent, lbltrans, sal_brkup[1], lblpension, sal_brkup[2], lblnhf, sal_brkup[3], lblnhis, sal_brkup[5], sal_brkup[4], sal_brkup[6],
                    sal_brkup[7], sal_brkup[0], utility, meal, othall, ltg, user_rin, lbldob.Trim(),
                    DateTime.Parse(lblstart_date.Trim()).ToString("yyyy-MM-dd"));
            }
            else
            {
                dtfinal.Rows.Add(gender, title, first_name, last_name, lbltin, company_rin, mobile_number, emailaddress, lblnationality, lblgross, lblbasic,
                   lblrent, lbltrans, sal_brkup[1], lblpension, sal_brkup[2], lblnhf, sal_brkup[3], lblnhis, sal_brkup[5], sal_brkup[4], sal_brkup[6],
                   sal_brkup[7], sal_brkup[0], utility, meal, othall, ltg, user_rin, DateTime.Parse(lbldob.Trim()).ToString("yyyy-MM-dd"),
                   DateTime.Parse(lblstart_date.Trim()).ToString("yyyy-MM-dd"));
            }
        }


        Session["dtfinal"] = dtfinal;
        grdemp.DataSource = dtfinal;
        grdemp.DataBind();
    }

    public string gettitlegender(string value, string flag)
    {
        string qry = "";
        if (flag == "t")
        {
            qry = "Select title_id from Titles where title='" + value.Trim() + "'";
            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(qry);
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["title_id"].ToString().Trim();
            }
            else
            {
                return "";
            }
        }
        else if (flag == "n")
        {
            qry = "Select nationality_id from nationality where adjective='" + value.Trim() + "'";
            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(qry);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["nationality_id"].ToString();
            }
            else
            {
                return "";
            }
        }
        else
        {
            if (value == "M" || value.ToUpper() == "male".ToUpper())
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }
    }

    protected void LinkButton_Click(object sender, EventArgs e)
    {
        string dataqry = "select * from vw_ind_details where company_rin='" + drpfupcomapny.SelectedValue.ToString().Trim() + "'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(dataqry);
        if (dt.Rows.Count > 0)
        {
            gvEmployee.DataSource = dt;
            gvEmployee.DataBind();
            tblupdemp.Style.Add("display", "");
        }
        else
        {
            tblupdemp.Style.Add("display", "none");
            //showmsg(2, "No Record found");
        }
    }

    protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvEmployee.SelectedRow;
        string dataqry = "select * from Salary_BreakUp where sal_employee_id='" + row.Cells[0].Text + "'";
        div_update.Visible = true;
        DataTable dt_sal_breakup = new DataTable();

        dt_sal_breakup = PAYEClass.fetchdata(dataqry);
        lbl_emp_id.Text = dt_sal_breakup.Rows[0]["sal_employee_id"].ToString();
        txt_gross.Text = dt_sal_breakup.Rows[0]["sal_gross"].ToString();
        txt_annual_basic.Text = dt_sal_breakup.Rows[0]["sal_basic"].ToString();
        txt_rent.Text = dt_sal_breakup.Rows[0]["sal_rent"].ToString();
        txt_annual_transport.Text = dt_sal_breakup.Rows[0]["sal_trans"].ToString();
        txt_pension_declared.Text = dt_sal_breakup.Rows[0]["sal_pension_declared"].ToString();
        txt_NHF_declared.Text = dt_sal_breakup.Rows[0]["sal_nhf_declared"].ToString();
        txt_NHIS_declared.Text = dt_sal_breakup.Rows[0]["sal_nhis_declared"].ToString();
        txtutilityupd.Text = dt_sal_breakup.Rows[0]["sal_utility"].ToString();
        txtmealupd.Text = dt_sal_breakup.Rows[0]["sal_meal"].ToString();
        txtothallupd.Text = dt_sal_breakup.Rows[0]["sal_otherallowances"].ToString();
        txtltgupd.Text = dt_sal_breakup.Rows[0]["sal_ltg"].ToString();
        txt_start_date.Text = "";
        txt_end_date.Text = "";
        chkpensionupd.Checked = false;
        chknhfupd.Checked = false;
        chknhisupd.Checked = false;

    }

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvEmployee, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        float gross = float.Parse(txt_gross.Text.Trim());
        float basic = float.Parse(txt_annual_basic.Text.Trim());
        float rent = float.Parse(txt_rent.Text.Trim());
        float trans = float.Parse(txt_annual_transport.Text.Trim());
        float utility = float.Parse(txtutilityupd.Text.ToString().Trim());
        float meal  = float.Parse(txtmealupd.Text.ToString().Trim());
        float othall = float.Parse(txtothallupd.Text.ToString().Trim());
        float ltg = float.Parse(txtltgupd.Text.ToString().Trim());
        double pension = 0;
        double pension_declared = 0;
        if (double.Parse(txt_pension_declared.Text.Trim()) == 0 && chkpensionupd.Checked)
        {
            pension = 1;
        }
        else
        {
            pension_declared = double.Parse(txt_pension_declared.Text.Trim());
        }

        double nhf = 0;//PAYEClass.computeformula(basic, rent, trans, "NHF");
        double nhf_declared = 0;// double.Parse(txtnhfdeclared.Text.Trim());
        if (double.Parse(txt_NHF_declared.Text.Trim()) == 0 && chknhfupd.Checked)
        {
            nhf = 1;
        }
        else
        {
            nhf_declared = double.Parse(txt_NHF_declared.Text.Trim());
        }


        double nhis = 0;// PAYEClass.computeformula(basic, rent, trans, "NHIS");
        double nhis_declared = 0;// double.Parse(txtnhisdeclared.Text.Trim());
        if (double.Parse(txt_NHIS_declared.Text.Trim()) == 0 && chknhisupd.Checked)
        {
            nhis = 1;
        }
        else
        {
            nhis_declared = double.Parse(txt_NHIS_declared.Text.Trim());
        }

        double[] sal_brkup = new double[8];
        sal_brkup = PAYEClass.calculatetax(gross, basic, rent, trans, pension, pension_declared, nhf, nhf_declared, nhis, nhis_declared,12);


        SqlParameter[] pram = new SqlParameter[24];

        pram[0] = new SqlParameter("@sal_create_by", "1");
        pram[1] = new SqlParameter("@sal_employee_id", lbl_emp_id.Text.Trim());
        pram[2] = new SqlParameter("@sal_gross", gross);
        pram[3] = new SqlParameter("@sal_basic", basic);
        pram[4] = new SqlParameter("@sal_rent", rent);
        pram[5] = new SqlParameter("@sal_trans", trans);
        pram[6] = new SqlParameter("@sal_pension", sal_brkup[1]);
        pram[7] = new SqlParameter("@sal_pension_declared", txt_pension_declared.Text.Trim());
        pram[8] = new SqlParameter("@sal_nhf", sal_brkup[2]);
        pram[9] = new SqlParameter("@sal_nhf_declared", txt_NHF_declared.Text.Trim());
        pram[10] = new SqlParameter("@sal_nhis", sal_brkup[3]);
        pram[11] = new SqlParameter("@sal_nhis_declared", txt_NHIS_declared.Text.Trim());
        pram[12] = new SqlParameter("@sal_ch_income", sal_brkup[5].ToString());
        pram[13] = new SqlParameter("@sal_tax_free_pay", sal_brkup[4].ToString());
        pram[14] = new SqlParameter("@sal_calc_tax", sal_brkup[6].ToString());
        pram[15] = new SqlParameter("@sal_calc_tax_monthly", sal_brkup[7].ToString());
        pram[16] = new SqlParameter("@sal_utility", utility);
        pram[17] = new SqlParameter("@sal_meal", meal);
        pram[18] = new SqlParameter("@sal_otherallowances", othall);
        pram[19] = new SqlParameter("@sal_ltg", ltg);
        pram[20] = new SqlParameter("@start_date", DateTime.Parse(txt_start_date.Text).ToString("yyyy-MM-dd"));
        pram[21] = new SqlParameter("@end_date", DateTime.Parse(txt_end_date.Text).ToString("yyyy-MM-dd"));
        pram[22] = new SqlParameter("@sal_cra", sal_brkup[0]);
        pram[23] = new SqlParameter("@SuccessID", 1);
        pram[23].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "Update_Salary_Breakup", pram);
        int status = int.Parse(pram[23].Value.ToString());
        if (status == 1)
        {
            showmsg(1, "Employee Updated Successfully");
            div_update.Visible = false;
        }
        else
        {
            showmsg(2, "Error occured in updating employee");
            
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        uploademployee();
    }

    protected void btncnfrmregis_Click(object sender, EventArgs e)
    {
        if (upemp() > 0)
        {
            showmsg(1, "Employee Uploaded Successfully");
            Session["comprin"] = drpfupcomapny.SelectedValue.ToString().Trim();
            string qry = "SELECT [user_rin],[gender],[title],[first_name],[last_name],[date_of_birth],[mobile_number_1],[email_address_1],[nationality],[company_rin],[IsValidated] FROM [Individuals] where company_rin='" + drpfupcomapny.SelectedValue.ToString().Trim() + "' and isValidated='0' ";
            DataTable dtnotvalidated = new DataTable();
            dtnotvalidated = PAYEClass.fetchdata(qry);
            if (dtnotvalidated.Rows.Count > 0)
            {
                divmain.Style.Add("display", "none");
                divconfirm.Style.Add("display", "none");
                divnotvalidated.Style.Add("display", "");
                grdnotvalidated.DataSource = dtnotvalidated;
                grdnotvalidated.DataBind();
            }
            else
            {                
                Response.Redirect("CalculateTax.aspx");
            }

        }
        else
        {
            showmsg(2, "Error Occured.Please contact technical staff for help");
            pnltax.Visible = false;
        }
    }

    protected void btnregister_Click(object sender, EventArgs e)
    {
        divmain.Style.Add("display", "none");
        divconfirm.Style.Add("display", "");
        divnotvalidated.Style.Add("display", "none");
        grdEmpConfirm.DataSource = (DataTable)Session["dtfinal"];
        grdEmpConfirm.DataBind();
        lblanntax.Text = annualtax().ToString();
        lblmonttax.Text = (Math.Round((annualtax() / 12),2)).ToString();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divmain.Style.Add("display", "");
        divconfirm.Style.Add("display", "none");
        divnotvalidated.Style.Add("display", "none");
    }

    public double annualtax()
    {
        double ann_tax = 0;
        for (int i = 0; i < grdEmpConfirm.Rows.Count; i++)
        {
            ann_tax += Double.Parse(((Label)grdEmpConfirm.Rows[i].FindControl("lblannualtax")).Text.ToString());
        }
        return ann_tax;
    }

    protected void btnproceed_Click(object sender, EventArgs e)
    {
        Session["comprin"] = drpfupcomapny.SelectedValue.ToString().Trim();
        Response.Redirect("CalculateTax.aspx");
    }

    protected void btnaddemployeeapi_Click(object sender, EventArgs e)
    {
        int count = 0;
        for (int i = 0; i < grdnotvalidated.Rows.Count; i++)
        {
            CheckBox chkb = (CheckBox)grdnotvalidated.Rows[i].FindControl("chkempnv");
            if (chkb.Checked)
            {
                count += 1;
                string rin = ((Label)grdnotvalidated.Rows[i].FindControl("lbluser_rin")).Text.ToString().Trim();
                string updatecommand = "Update Individuals set isValidated='1' where user_rin='" + rin.Trim() + "'";
                int status = PAYEClass.insertupdateordelete(updatecommand);
            }
        }

        if (count > 0)
        {
            Response.Redirect("CalculateTax.aspx");
        }
        else
        {
            showmsg(2, "Please select atleast one employee to validate ");
            return;
        }
    }

    public void get_compid()
    {
        /***************************************************************/
        string[] res;
        //string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/List";
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/Search";
        URI = PAYEClass.URL_API + "TaxPayer/Company/Search";

        string myParameters = "CompanyRIN=" + drpfupcomapny.SelectedValue.Trim();

        string InsCompRes = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();

            InsCompRes = wc.UploadString(URI, myParameters);

            res = InsCompRes.Split('"');

        }


        DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

        DataRow[] filteredRows = dt_list.Select("CompanyRIN LIKE '" + drpfupcomapny.SelectedValue.Trim() + "'");
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

    }
    
}