using System;
using System.Collections.Generic;
using System.Linq;
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

public partial class AssessmentApprovalProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        


        if (!IsPostBack)
        {
           // string qry = "Select * from Assessment_Status";

            string qry = "Select * from Assessment_Status a, Eirs_User b where a.group_id=b.GroupId and active=1 and b.user_id=" + Session["user_id"].ToString() + " or (a.Ass_st_id=0 and b.user_id=" + Session["user_id"].ToString() + ") ";
           DataTable dt_dpd = new DataTable();
            dt_dpd = PAYEClass.fetchdata(qry);
            dpd_status.DataSource = dt_dpd;
            dpd_status.DataTextField = "Assessment_status";
            dpd_status.DataValueField = "Ass_st_id";
            dpd_status.DataBind();

            DataTable dt_Ass_next_st = new DataTable();
            string qry_next = "select ass_st_id, Assessment_status from Assessment_Status where Ass_st_id in (Select ass_next_st_id from Assessment_Status a, Eirs_User b where a.group_id=b.GroupId and b.user_id=" + Session["user_id"].ToString() + ") and active=1";
            dt_Ass_next_st = PAYEClass.fetchdata(qry_next);
            txt_status.DataSource = dt_Ass_next_st;
            txt_status.DataTextField = "Assessment_status";
            txt_status.DataValueField = "Ass_st_id";
            txt_status.DataBind();


            tbl_details.Attributes.Add("style", "display:none");

            string dataqry = "select * from vw_assessment_search where AssessmentApprovalStatus in (Select Ass_st_id from Assessment_Status a, Eirs_User b where a.group_id=b.GroupId and b.user_id=" + Session["user_id"].ToString() + ")";
            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(dataqry);

           // grvEmployee.DataSource = dt;
           // grvEmployee.DataBind();


            if (dt.Rows.Count > 0)
            {
                tbl_grd.Attributes.Add("style", "display:block");
                grvEmployee.DataSource = dt;
                grvEmployee.DataBind();
            }

            else
            {
                tbl_grd.Attributes.Add("style", "display:none");
                showmsg(11, "No Records Available");
                //  divmsg.Style.Add("display", "");
                //  divmsg.InnerText = "No Records Available";
                //  divmsg.Attributes.Add("class", "msg-information");


            }

        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        //if (txt_enter_ass_ref_no.Text != "" || dpd_status.SelectedValue != "--Select--")
        {
            string dataqry = "select * from vw_assessment_search";
            if (txt_enter_ass_ref_no.Text != "")
                dataqry = "select * from vw_assessment_search where assessment_ref='" + txt_enter_ass_ref_no.Text + "'";

            if (txt_enter_ass_ref_no.Text != "" && dpd_status.SelectedValue != "ALL")
                dataqry = "select * from vw_assessment_search where assessment_ref='" + txt_enter_ass_ref_no.Text + "' and Assessment_status='" + dpd_status.SelectedValue + "'";

            if (txt_enter_ass_ref_no.Text == "" && dpd_status.SelectedValue == "ALL")
                dataqry = "select * from vw_assessment_search where AssessmentStatus in (Select Ass_st_id from Assessment_Status a, Eirs_User b where a.group_id=b.GroupId and b.user_id=" + Session["user_id"].ToString() + ")";

            if (txt_enter_ass_ref_no.Text == "" && dpd_status.SelectedValue != "ALL")
                dataqry = "select * from vw_assessment_search where Assessment_status='" + dpd_status.SelectedValue + "'";


            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(dataqry);

            if (dt.Rows.Count > 0)
            {
                tbl_grd.Attributes.Add("style", "display:block");
                grvEmployee.DataSource = dt;
                grvEmployee.DataBind();
            }

            else

            {
                tbl_grd.Attributes.Add("style", "display:none");
                showmsg(11, "No Records Available");
                  //  divmsg.Style.Add("display", "");
                  //  divmsg.InnerText = "No Records Available";
                  //  divmsg.Attributes.Add("class", "msg-information");
                
            
            }
        }
    }
    protected void grvEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = grvEmployee.SelectedRow;

        //now get the labels if you use Template Fields 
       // Label _LabelId = row.FindControl("LabelId") as Label;
        tbl_details.Attributes.Add("style", "display:block");
        tbl_grd.Attributes.Add("style", "display:none");
        tbl_search.Attributes.Add("style", "display:none"); 
        txt_ARN.Text=row.Cells[2].Text;
        txt_ass_year.Text = row.Cells[0].Text;
        txt_company.Text = row.Cells[5].Text;
        txt_TIN.Text = row.Cells[3].Text;
        txt_RIN.Text = row.Cells[4].Text;
        txt_amt.Text = row.Cells[6].Text;
        txt_tax_agent.Text = row.Cells[7].Text;
        txt_type.Text = row.Cells[1].Text;
       // txt_status.Text = row.Cells[8].Text;

        if (row.Cells[8].Text == "1")
        {
            btn_confirm.Text = "Confirm";
        }

        if (row.Cells[8].Text == "3")
        {
            btn_confirm.Text = "Approved";
        }

        if (row.Cells[8].Text == "4")
        {
            btn_confirm.Text = "Payment";
        }


        if (row.Cells[8].Text == "7")
        {
            btn_confirm.Text = "Generate Clearance Certificate";
        }



    }

    protected void grvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.grvEmployee, "Select$" + e.Row.RowIndex);

            //if(e.Row.

        }
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        if (btn_confirm.Text == "Payment")
        {
            try
            {
                Response.Redirect("PaymentInterface.aspx?q=" + txt_RIN.Text);
            }
            catch (Exception ex)
            {
                
            }
        }

        else if (btn_confirm.Text == "Generate Clearance Certificate")
        {
            try
            {
                Response.Redirect("ClearanceCertificates.aspx?q=" + txt_RIN.Text);
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            string val = txt_status.SelectedValue;
            if (val == "2")
                val = "3";
           // string qry = "update Assessments set AssessmentApprovalStatus='" + txt_status.SelectedValue + "' where assessment_ref='" + txt_ARN.Text + "'";

            string qry = "update Assessments set AssessmentApprovalStatus='" + val + "' where assessment_ref='" + txt_ARN.Text + "'";
            int status = PAYEClass.insertupdateordelete(qry);

            if (status == 1)
            {
                // divmsg.Style.Add("display", "");
                // divmsg.InnerText = "Assessment Updated Successfully";
                // divmsg.Attributes.Add("class", "msg");
                showmsg(1, "Assessment Updated Successfully");
            }
            else
            {
                // divmsg.Style.Add("display", "");
                // divmsg.InnerText = "Error Occured";
                // divmsg.Attributes.Add("class", "msg-error");

                showmsg(2, "Error Occured.");
            }
        }
    }
   
    protected void btn_back_Click(object sender, EventArgs e)
    {
        tbl_details.Attributes.Add("style", "display:none");
        tbl_grd.Attributes.Add("style", "display:block");
        tbl_search.Attributes.Add("style", "display:block");

        divmsg.Attributes.Add("style", "display:none");

        /************************************************************************/
        string dataqry = "select * from vw_assessment_search where AssessmentApprovalStatus in (Select Ass_st_id from Assessment_Status a, Eirs_User b where a.group_id=b.GroupId and b.user_id=" + Session["user_id"].ToString() + ")";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(dataqry);

        // grvEmployee.DataSource = dt;
        // grvEmployee.DataBind();


        if (dt.Rows.Count > 0)
        {
            tbl_grd.Attributes.Add("style", "display:block");
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();
        }

        else
        {
            tbl_grd.Attributes.Add("style", "display:none");
            showmsg(11, "No Records Available");
            //  divmsg.Style.Add("display", "");
            //  divmsg.InnerText = "No Records Available";
            //  divmsg.Attributes.Add("class", "msg-information");


        }

        /************************************************************************/
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