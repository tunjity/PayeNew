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

public partial class FileReturns : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Timeout = 1;
        //if (Session["user_id"] == null)
        //{
        //    Response.Redirect("Login.aspx");

        //}

     
    }
    protected void btn_search_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lbl_private_business_A_G_Click(object sender, EventArgs e)
    {
        try
        {
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from CompanyList_API where TaxPayerName not like '[H-Z]%' order by TaxPayerName asc", con);

            SqlDataAdapter Adp = new SqlDataAdapter("select * from CompanyList_API where TaxPayerName not like '[H-Z]%' and TaxPayerRIN in (select CompanyRIN from vw_ShowBusiness_PayeInputFile) order by TaxPayerName asc", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            DataTable dt_list = new DataTable();
            Adp.Fill(dt_list);

            Session["dt_list"] = dt_list;
            grd_company.DataSource = dt_list;
            grd_company.DataBind();

            Session["dt_val"] = "A-G";

            Response.Redirect("frmCompanyFileRet.aspx");
        }

        catch (Exception ex)
        {
            showmsg(2, "Something Went Wrong.");
        }
    }
    protected void lbl_private_business_H_Z_Click(object sender, EventArgs e)
    {
        try
        {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from CompanyList_API where TaxPayerName like '[H-Z]%' order by TaxPayerName asc", con);
            DataTable dt_list = new DataTable();
            Adp.Fill(dt_list);

            Session["dt_list"] = dt_list;
            grd_company.DataSource = dt_list;
            grd_company.DataBind();

            Session["dt_val"] = "H-Z";

            Response.Redirect("frmCompanyFileRet.aspx");
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
           // e.Row.Cells[1].Attributes["onclick"] = "javascript:showcompanyloaderafterselect(" + e.Row.RowIndex + ")";

          

        }
    }
    protected void grd_company_SelectedIndexChanged(object sender, EventArgs e)
    {

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