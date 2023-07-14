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

public partial class ShowLegacyDataComp : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt_list = new DataTable();

            
          //  SqlDataAdapter Adp = new SqlDataAdapter("select  BusinessRIN, BusinessName, count(*) as totalcount,Tax_Year,CompanyRIN, Status  from vw_InputFile where TaxMonth='January' group by BusinessRIN ,BusinessName,Tax_Year,CompanyRIN", con);

            SqlDataAdapter Adp = new SqlDataAdapter("select  BusinessRIN, BusinessName, totalcount,Tax_Year,CompanyRIN, Status  from vw_ShowBusiness order by status", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);

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

    protected void lnkCustDetails_Click(object sender, EventArgs e)
    {
        // divTaxPayerModal.Style.Add("display", "");
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {

    }
}