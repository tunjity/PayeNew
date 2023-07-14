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

public partial class AddAsset : System.Web.UI.Page
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
            if (Session["comp_rin"] != null)
            {
                string[] val = new string[2];
                val = Session["comp_rin"].ToString().Trim().Split(',');
               



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
                    dt_Asset_list.Columns.Add("FullValue", typeof(string), "AssetName + '--' + AssetRIN + '--' + AssetTypeID + '--' + AssetTypeName");

                    dpd_associated_business_list.DataSource = dt_Asset_list;
                    dpd_associated_business_list.DataTextField = "FullValue";
                    dpd_associated_business_list.DataValueField = "AssetID";
                    dpd_associated_business_list.DataBind();

                    box1.Style.Add("display", "none");
                    box.Style.Add("display", "");
                    showmsg(1, val[0].ToString());
                }
                else
                {
                    box1.Style.Add("display", "");
                    box.Style.Add("display", "none");
                    showmsg(1, val[0].ToString() + ". No Asset Associated. Please Add Asset Form Here.");
                }

                
            }
         }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (txt_enter_RIN.Text == "")
        {
            tr_yess.Style.Add("display", "");
            tr_yes.Style.Add("display", "none");
            showmsg(11, "Please Fill Business RIN No.");
            return;
        }

        divmsg.Style.Add("display", "none");
        /***************************************************************/
        string[] res;
        string URI = "https://api.eirsautomation.xyz/Asset/Business/List";

        string myParameters = "";

        string InsCompRes = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();

            InsCompRes = wc.UploadString(URI, myParameters);

            res = InsCompRes.Split('"');

        }


        DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));

        DataRow[] filteredRows = dt_list.Select("BusinessRIN LIKE '" + txt_enter_RIN.Text + "'");
        DataTable dt_filtered = new DataTable();

        
        /**************************************************************/

        if (filteredRows.Length > 0)
        {
            dt_filtered = filteredRows.CopyToDataTable();
            txt_Business_RIN.Text = dt_filtered.Rows[0]["BusinessRIN"].ToString();
            txt_BusinessName.Text = dt_filtered.Rows[0]["BusinessName"].ToString();

            txt_AssetType.SelectedValue = dt_filtered.Rows[0]["AssetTypeID"].ToString();
            txt_BusinessType.SelectedValue = dt_filtered.Rows[0]["BusinessTypeID"].ToString();

            txt_BusinessCategory.SelectedValue = dt_filtered.Rows[0]["BusinessCategoryID"].ToString();
            txt_LGAName.SelectedValue = dt_filtered.Rows[0]["LGAID"].ToString();

            txt_BusinessSectorName.SelectedValue = dt_filtered.Rows[0]["BusinessSectorID"].ToString();
            txt_BusinessSubSectorName.SelectedValue = dt_filtered.Rows[0]["BusinessSubSectorID"].ToString();

            txt_BusinessStructureName.SelectedValue = dt_filtered.Rows[0]["BusinessStructureID"].ToString();
            txt_BusinessOperationName.SelectedValue = dt_filtered.Rows[0]["BusinessOperationID"].ToString();
            divmsg.Style.Add("display", "none");
            tr_yes.Style.Add("display", "");
            tr_yess.Style.Add("display", "none");
        }
        else
        {
            tr_yess.Style.Add("display", "");
            tr_yes.Style.Add("display", "none");
            showmsg(11, "Business Rin does not exists.");
            txt_Business_RIN.Text = "";
            txt_BusinessName.Text = "";
            return;
        }

    }

    public void binddropdowns()
    {
        string qry = "Select * from Asset_Type";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_AssetType.DataSource = dt;
        txt_AssetType.DataTextField = "asset_type";
        txt_AssetType.DataValueField = "asset_id";
        txt_AssetType.DataBind();
        // txt_tax_ofc.Items.Insert(0, new ListItem("--Select--", "0", true));




        qry = "Select * from Business_Type";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_BusinessType.DataSource = dt;
        txt_BusinessType.DataTextField = "Business_type";
        txt_BusinessType.DataValueField = "Business_type_id";
        txt_BusinessType.DataBind();
        // txt_tax_payer_type.Items.Insert(0, new ListItem("--Select--", "0", true));



        qry = "Select * from Business_Category";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_BusinessCategory.DataSource = dt;
        txt_BusinessCategory.DataTextField = "business_category";
        txt_BusinessCategory.DataValueField = "bs_ct_id";
        txt_BusinessCategory.DataBind();

        qry = "Select * from Local_Government_Areas";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_LGAName.DataSource = dt;
        txt_LGAName.DataTextField = "lga";
        txt_LGAName.DataValueField = "lga_id";
        txt_LGAName.DataBind();

        qry = "Select * from Business_sectors";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_BusinessSectorName.DataSource = dt;
        txt_BusinessSectorName.DataTextField = "business_sector";
        txt_BusinessSectorName.DataValueField = "bs_sc_id";
        txt_BusinessSectorName.DataBind();

        

        qry = "Select * from Business_Sub_Sectors";

        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_BusinessSubSectorName.DataSource = dt;
        txt_BusinessSubSectorName.DataTextField = "business_sub_sector";
        txt_BusinessSubSectorName.DataValueField = "bs_sb_id";
        txt_BusinessSubSectorName.DataBind();
        //        dpd_asset_type.Items.Add(new ListItem("--Select--", "0", true));
       // dpd_asset_type.Items.Insert(0, new ListItem("--Select--", "0", true));



        qry = "Select * from Business_Structure";

        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_BusinessStructureName.DataSource = dt;
        txt_BusinessStructureName.DataTextField = "business_structure";
        txt_BusinessStructureName.DataValueField = "bs_st_id";
        txt_BusinessStructureName.DataBind();

        qry = "Select * from Business_Operations";

        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txt_BusinessOperationName.DataSource = dt;
        txt_BusinessOperationName.DataTextField = "business_operations";
        txt_BusinessOperationName.DataValueField = "bs_op_id";
        txt_BusinessOperationName.DataBind();

    }

    public void showmsg(int id, string msg)
    {
        if (id == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-check-circle' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-success");
        }
        else
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-warning");
        }
    }

    protected void btn_yes_Click(object sender, EventArgs e)
    {
        SqlParameter[] pram = new SqlParameter[14];

        pram[0] = new SqlParameter("@business_name", txt_BusinessName.Text.Trim());
        pram[1] = new SqlParameter("@business_RIN", txt_Business_RIN.Text.Trim());
        pram[2] = new SqlParameter("@asset_type", txt_AssetType.SelectedValue.Trim());
        pram[3] = new SqlParameter("@business_type", txt_BusinessType.SelectedValue.Trim());
        pram[4] = new SqlParameter("@business_category", txt_BusinessCategory.SelectedValue.Trim());
        pram[5] = new SqlParameter("@business_structure", txt_BusinessStructureName.SelectedValue.Trim());
        pram[6] = new SqlParameter("@business_sector", txt_BusinessSectorName.SelectedValue.Trim());
        pram[7] = new SqlParameter("@business_sub_sector", txt_BusinessSubSectorName.SelectedValue.Trim());
        pram[8] = new SqlParameter("@business_operations", txt_BusinessOperationName.SelectedValue.Trim());
        pram[9] = new SqlParameter("@LGA", txt_LGAName.SelectedValue.Trim());

        pram[10] = new SqlParameter("@Company_Rin", Session["Rin"].ToString().Trim());
        pram[11] = new SqlParameter("@business_Create_by", Session["user_id"].ToString().Trim());
        
        /***************************************************************************/

        pram[12] = new SqlParameter("@SucessID", 1);
        pram[12].Direction = System.Data.ParameterDirection.Output;
        int status = SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_CompanyBusiness", pram);
        if (status == 1)
        {
            redirect("The Business Establishment Successfully Associated to the Company.");
        }
        else
        {
            showmsg(2, "Error Occured.");
        }
    }

    protected void btn_no_Click(object sender, EventArgs e)
    {
        redirect("No Business Associated with this company");
    }

    protected void btn_yess_Click(object sender, EventArgs e)
    {
        divmsg.Style.Add("display", "none");
        tr_submit.Style.Add("display", "");
        tr_enter_TIN.Style.Add("display", "none");
        tr_yess.Style.Add("display", "none");
        txt_Business_RIN.Enabled = true;
        txt_BusinessName.Enabled = true;
        txt_BusinessCategory.Enabled = true;
        txt_BusinessSectorName.Enabled = true;
        txt_BusinessStructureName.Enabled = true;
        txt_AssetType.Enabled = true;
        txt_BusinessType.Enabled = true;
        txt_LGAName.Enabled = true;
        txt_BusinessSubSectorName.Enabled = true;
        txt_BusinessOperationName.Enabled = true;
        
    }

    protected void btn_noo_Click(object sender, EventArgs e)
    {
        redirect("No Business Associated with this company");
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (txt_Business_RIN.Text == "")
        {
            showmsg(11, "Please Fill Business RIN No.");
            return;
        }

        if (txt_BusinessName.Text == "")
        {
            showmsg(11, "Please Fill Business Name");
            return;
        }

        SqlParameter[] pram = new SqlParameter[14];

        pram[0] = new SqlParameter("@business_name", txt_BusinessName.Text.Trim());
        pram[1] = new SqlParameter("@business_RIN", txt_Business_RIN.Text.Trim());
        pram[2] = new SqlParameter("@asset_type", txt_AssetType.SelectedValue.Trim());
        pram[3] = new SqlParameter("@business_type", txt_BusinessType.SelectedValue.Trim());
        pram[4] = new SqlParameter("@business_category", txt_BusinessCategory.SelectedValue.Trim());
        pram[5] = new SqlParameter("@business_structure", txt_BusinessStructureName.SelectedValue.Trim());
        pram[6] = new SqlParameter("@business_sector", txt_BusinessSectorName.SelectedValue.Trim());
        pram[7] = new SqlParameter("@business_sub_sector", txt_BusinessSubSectorName.SelectedValue.Trim());
        pram[8] = new SqlParameter("@business_operations", txt_BusinessOperationName.SelectedValue.Trim());
        pram[9] = new SqlParameter("@LGA", txt_LGAName.SelectedValue.Trim());

        pram[10] = new SqlParameter("@Company_Rin", Session["Rin"].ToString().Trim());
        pram[11] = new SqlParameter("@business_Create_by", Session["user_id"].ToString().Trim());

        /***************************************************************************/

        pram[12] = new SqlParameter("@SucessID", 1);
        pram[12].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_CompanyBusiness", pram);

        redirect("The Business Establishment Successfully Associated to the Company.");
    }

    public void redirect(string msg)
    {
        Session["comp_rin"] = null;
        Session["comp_rin"] = msg + "," + Session["Rin"].ToString().Trim();
        Response.Redirect("AddEmployee.aspx");
    }


    protected void btn_proceed_Click(object sender, EventArgs e)
    {
        SqlParameter[] pram = new SqlParameter[14];

        pram[0] = new SqlParameter("@business_name", dpd_associated_business_list.SelectedItem.Text.Trim());
        pram[1] = new SqlParameter("@business_RIN", dpd_associated_business_list.SelectedItem.Text.Split(new string[] {"--"},StringSplitOptions.None)[1].ToString());
        pram[2] = new SqlParameter("@asset_type", "");
        pram[3] = new SqlParameter("@business_type", "");
        pram[4] = new SqlParameter("@business_category", "");
        pram[5] = new SqlParameter("@business_structure", "");
        pram[6] = new SqlParameter("@business_sector", "");
        pram[7] = new SqlParameter("@business_sub_sector", "");
        pram[8] = new SqlParameter("@business_operations", "");
        pram[9] = new SqlParameter("@LGA", "");

        pram[10] = new SqlParameter("@Company_Rin", Session["Rin"].ToString().Trim());
        pram[11] = new SqlParameter("@business_Create_by", Session["user_id"].ToString().Trim());

        /***************************************************************************/

        pram[12] = new SqlParameter("@SucessID", 1);
        pram[12].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_CompanyBusiness", pram);


        Session["Asset_Det"] = dpd_associated_business_list.SelectedItem.Text + "--" + dpd_associated_business_list.SelectedValue;
        redirect("");
    }
}