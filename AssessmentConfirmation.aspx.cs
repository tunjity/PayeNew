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

public partial class AssessmentConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {

        if (txt_enter_ass_ref_no.Text == "")
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Please Fill Assessment Ref. No.')", true);
        }

        string dataqry = "select company_rin, company_name, company_tin, assessment_ref, assessment_date from vw_assessment_search where assessment_ref='" + txt_enter_ass_ref_no.Text + "'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(dataqry);

        if (dt.Rows.Count > 0)
        {
            // box.Attributes.Add("display", "block");
            box1.Attributes.Add("style", "display:block");
            gvCompany.DataSource = dt;
            gvCompany.DataBind();
        }

        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('No Record Found.')", true);
        }
    }
    protected void gvCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvCompany.SelectedRow;
        string dataqry = "select * from vw_ind_details where company_tin='" + row.Cells[0].Text + "'";
        Session["company_rin"] = row.Cells[0].Text;
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(dataqry);

        if (dt.Rows.Count > 0)
        {
           // Table1.Attributes.Add("display", "block");
            Table1.Attributes.Add("style", "display:block");
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();
        }
    }

    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvCompany, "Select$" + e.Row.RowIndex);
            e.Row.Attributes["style"] = "cursor:pointer";
        }
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        string qry = "update Assessments set AssessmentStatus=1 where assessment_ref='" + txt_enter_ass_ref_no.Text + "'";
         int status = PAYEClass.insertupdateordelete(qry);
         if (status > 0)
         {
             ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Record Has Been Updated Successfully.')", true);
         }
    }
}