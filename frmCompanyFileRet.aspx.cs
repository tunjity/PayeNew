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

public partial class frmCompanyFileRet : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 1;
            //if (Session["user_id"] == null)
            //{
            //    Response.Redirect("Login.aspx");

            //}
            Label lbl_govt = (Label)Page.Master.FindControl("lbl_govt");
            lbl_govt.Visible = false;
            //and TaxPayerRIN in (select CompanyRIN from vw_ShowBusiness_PayeInputFile_All)
            lbl_name.Text = Session["dt_val"].ToString();
            string qry = "";
            if (Session["dt_val"] == "A-G")
                qry = "select * from CompanyList_API where TaxPayerName not like '[H-Z]%' and TaxPayerRIN in (select CompanyRIN from vw_ShowBusiness_PayeInputFile) order by TaxPayerName asc";
            else
                qry = "select * from CompanyList_API where TaxPayerName  like '[H-Z]%' and TaxPayerRIN in (select CompanyRIN from vw_ShowBusiness_PayeInputFile) order by TaxPayerName asc";

            SqlDataAdapter Adp = new SqlDataAdapter(qry, con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            DataTable dt_list = new DataTable();
            Adp.Fill(dt_list);

            Session["dt_list"] = dt_list;
            grd_company.DataSource = dt_list;
            grd_company.DataBind();

            int pagesize = grd_company.Rows.Count;
            int from_pg = 1;
            int to = grd_company.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_company.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-60px");
        }
        catch (Exception ex)
        {
            showmsg(2, "Something Went Wrong.");
        }
    }
    protected void grd_company_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Cells[1].Attributes["onmouseover"] = "this.style.cursor='pointer';";

            //  e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            string a = this.Page.ClientScript.GetPostBackClientHyperlink(this.grd_company, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to select row";
           // e.Row.Cells[0].Attributes["onclick"] = "javascript:showcompanyloaderafterselect(" + e.Row.RowIndex + ")";
            //e.Row.Cells[1].Attributes["onclick"] = "javascript:showcompanyloaderafterselect(" + e.Row.RowIndex + ")";

            e.Row.Attributes["onClick"] = "location.href='SubmitInputFile.aspx?TaxPayerRIN=" + DataBinder.Eval(e.Row.DataItem, "TaxPayerRIN") + "'";
        }
    }
    protected void grd_company_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grd_company_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_company.PageIndex = e.NewPageIndex;
        grd_company.DataSource = Session["dt_list"];
        grd_company.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_company.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_company.Rows.Count).ToString();
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
}