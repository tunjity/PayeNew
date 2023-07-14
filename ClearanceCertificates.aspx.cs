using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClearanceCertificates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddropdown();
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string qyr = "Select * from vw_clearanceCertReq where company_rin='" + txtcomptin.Text.ToString().Trim() + "' and IsPaid='1' and MonthTax='"+drpMonth.SelectedValue.ToString().Trim()+"' and YearTax = '"+drpYear.SelectedValue.ToString().Trim()+"'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qyr);
        if (dt.Rows.Count > 0)
        {
            grdclrcert.DataSource = dt;
            grdclrcert.DataBind();
        }
        else
        {
            showmsg(2, "The tax for this month and year has not been paid by the company. The request cannot be proceesed.");
        }
    }

    public void binddropdown()
    {
        DataTable dtmonths = new DataTable();
        dtmonths.Columns.Add("MonthName", typeof(string));
        dtmonths.Columns.Add("Month", typeof(int));
        for (int i = 1; i <= 12; i++)
        {
            string month = DateTimeFormatInfo.CurrentInfo.GetMonthName(i);
            dtmonths.Rows.Add(month, i);
        }
        drpMonth.DataSource = dtmonths;
        drpMonth.DataTextField = "MonthName";
        drpMonth.DataValueField = "Month";
        drpMonth.DataBind();

        for (int j = DateTime.Now.AddYears(-10).Year; j <= DateTime.Now.Year; j++)
        {
            drpYear.Items.Add(new ListItem(j.ToString()));
        }
    }

    protected void grdclrcert_SelectedIndexChanged(object sender, EventArgs e)
    {
        divconfirm.Style.Add("display", "");
        GridViewRow row = grdclrcert.SelectedRow;
        lblconfirm.Text = "You have requested for the clearence certificate of " + row.Cells[2].Text + " with RIN number " + row.Cells[1].Text + " for the year " + row.Cells[3].Text + " and month " + DateTimeFormatInfo.CurrentInfo.GetMonthName(int.Parse(row.Cells[4].Text)) + ". Are you sure you want to submit the request?";
        Session["rin"] = row.Cells[1].Text;
        Session["year"] = row.Cells[3].Text;
        Session["compname"] = row.Cells[2].Text;
        Session["month"] = row.Cells[4].Text;
        divconfirm.Style.Add("display", "");
    }

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdclrcert , "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        string first_five = Session["rin"].ToString().Substring(0, 4);
        string middle_fout = Session["year"].ToString()+Session["month"].ToString();
        Random rnd = new Random();
        string last_five = rnd.Next(11111, 99999).ToString();
        string finalref = first_five + middle_fout + last_five;
        SqlParameter[] pram = new SqlParameter[7];
        pram[0] = new SqlParameter("@cc_create_by", "1");
        pram[1] = new SqlParameter("@certificate_ref", finalref);
        pram[2] = new SqlParameter("@financial_year", Session["year"].ToString());
        pram[3] = new SqlParameter("@MonthTax", Session["month"].ToString().Trim());
        pram[4] = new SqlParameter("@companyRIN", Session["rin"].ToString().Trim());
        pram[5] = new SqlParameter("@companyname", Session["compname"].ToString().Trim());
        pram[6] = new SqlParameter("@SucessID", "1");
        pram[6].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_CLRCERT", pram);
        int status = int.Parse(pram[6].Value.ToString());
        if (status == 1)
        {
            Session["rin"] = null;
            Session["year"] = null;
            Session["compname"] = null;
            Session["month"] = null;
            divconfirm.Style.Add("display", "none");
            showmsg(1, "Clearance Certificate request submitted successfully.");
        }
        else if (status == 2)
        {
            Session["rin"] = null;
            Session["year"] = null;
            Session["compname"] = null;
            Session["month"] = null;
            showmsg(2, "A request for the same certificate was already placed and is under process.");
            divconfirm.Style.Add("display", "none");
        }
        else
        {
            showmsg(2, "Error Occured while placing request. Please contact technical staff.");
            divconfirm.Style.Add("display", "");
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        divconfirm.Style.Add("display", "none");
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
}