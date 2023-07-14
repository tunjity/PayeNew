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

public partial class BusinessDetails : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        string val = "";
        if (Request.QueryString["BusinessDet"] != null)
        {
            val = Request.QueryString["BusinessDet"].ToString();
            Session["Business_val"] = val;
            Response.Redirect("BusinessDetails.aspx");
        }

        if (Session["Business_val"] == null || Session["token"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        string[] val1 = Session["Business_val"].ToString().Split('|');
        txt_Business_RIN.Text = val1[0].ToString().Trim();
        txt_business_name.Text = val1[1].ToString().Trim();
        txt_Address.Text = val1[2].ToString().Trim();
        txt_Sector.Text = val1[3].ToString().Trim().Replace("*--*", "&").ToString();
        int businessId = Convert.ToInt32(val1[4].ToString().Trim());
        DataTable dt_business_det = new DataTable();
        dt_business_det = get_Individual(businessId);
       // SqlDataAdapter Adp = new SqlDataAdapter("select * from vw_BusinessDetails where AssetRIN='" + val1[0].ToString().Trim() + "'", con);
        
       // Adp.Fill(dt_business_det);

        Session["dt_l"] = dt_business_det;
        grd_ind.DataSource = dt_business_det;
        grd_ind.DataBind();

        int pagesize = grd_ind.Rows.Count;
        int from_pg = 1;
        int to = grd_ind.Rows.Count;
        int totalcount = dt_business_det.Rows.Count;
        lblpagefrom.Text = from_pg.ToString();
        lblpageto.Text = (from_pg + pagesize - 1).ToString();
        lbltoal.Text = totalcount.ToString();

        if (totalcount <= grd_ind.PageSize)
            div_paging.Style.Add("margin-top", "0px");
        else
            div_paging.Style.Add("margin-top", "-60px");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_ind.PageIndex = e.NewPageIndex;
        grd_ind.DataSource = Session["dt_l"];
        grd_ind.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_ind.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_ind.Rows.Count).ToString();
    }



    public DataTable get_Individual(int asset_id)
    {

        /********************************************************************************************************************/
        string[] res;
        string URI = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/GetAssetTaxPayer?AssetTypeID=3 &AssetID=" + asset_id;
        URI = PAYEClass.URL_API + "TaxPayer/Company/GetAssetTaxPayer?AssetTypeID=3 &AssetID=" + asset_id;
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
        return dt_list;
    }
}