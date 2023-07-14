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

public partial class PayeSubmissions : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt_list = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("select * from vw_Legacy_Submissions", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            // DataTable Dt_database = new DataTable();
            Adp.Fill(dt_list);

            Session["dt_l"] = dt_list;
            grd_legacy_submissions.DataSource = dt_list;
            grd_legacy_submissions.DataBind();

            int pagesize = grd_legacy_submissions.Rows.Count;
            int from_pg = 1;
            int to = grd_legacy_submissions.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_legacy_submissions.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-60px");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_legacy_submissions.PageIndex = e.NewPageIndex;
        grd_legacy_submissions.DataSource = Session["dt_l"];
        grd_legacy_submissions.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_legacy_submissions.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_legacy_submissions.Rows.Count).ToString();
    }

    protected void grd_legacy_submissions_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        DataTable dt_list_s = new DataTable();
        dt_list_s = (DataTable)Session["dt_l"];
        // DataRow[] filteredRows = dt_list_s.Select("TaxPayerRIN LIKE '" + txt_RIN.Text + "'");
        DataTable dt_filtered = new DataTable();
        DataView dt_v = dt_list_s.DefaultView;
        if (txt_RIN.Text != "")
            dt_v.RowFilter = "BusinessRIN like '%" + txt_RIN.Text + "%'";

        if (txt_tin.Text != "")
            dt_v.RowFilter = "Tp_TIN like '%" + txt_tin.Text + "%'";

        if (txt_payer_RIN.Text != "")
            dt_v.RowFilter = "TaxPayerRIN like '%" + txt_payer_RIN.Text + "%'";


        grd_legacy_submissions.DataSource = dt_v;
        grd_legacy_submissions.DataBind();


        int pagesize = grd_legacy_submissions.Rows.Count;
        int from_pg = 1;
        int to = grd_legacy_submissions.Rows.Count;
        int totalcount = dt_v.Count;
        lblpagefrom.Text = from_pg.ToString();
        lblpageto.Text = (from_pg + pagesize - 1).ToString();
        lbltoal.Text = totalcount.ToString();

        if (totalcount < grd_legacy_submissions.PageSize)
            div_paging.Style.Add("margin-top", "0px");
        else
            div_paging.Style.Add("margin-top", "-60px");
    }
}