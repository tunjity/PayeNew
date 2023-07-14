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
using System.IO;
using System.Web.UI.HtmlControls;


public partial class PeriodicAssessmentReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }



         tbl_xl.Attributes.Add("style", "display:none");
        
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    //base.VerifyRenderingInServerForm(control);
    //}

    protected void btn_generate_Click(object sender, EventArgs e)
    {

        if (txt_start_date.Text == "" && txt_end_date.Text == "")
        {
            tbl_grd.Attributes.Add("style", "display:none");
            showmsg(11, "Please Fill Start-Date & End-Date.");
            return;
        }

        if (txt_start_date.Text == "")
        {
            tbl_grd.Attributes.Add("style", "display:none");
            showmsg(11, "Please Fill Start-Date.");
            return;
        }

        if (txt_end_date.Text == "")
        {
            tbl_grd.Attributes.Add("style", "display:none");
            showmsg(11, "Please Fill End-Date");
            return;
        }

        if (Convert.ToDateTime(txt_start_date.Text) > Convert.ToDateTime(txt_end_date.Text))
        {
            tbl_grd.Attributes.Add("style", "display:none");
            showmsg(11, "Start-Date must be less than End-Date");
            return;
        }
        
        string dataqry = "select * from vw_assessment_search where Assessment_date>='" + txt_start_date.Text + "' and Assessment_date<='" + txt_end_date.Text + "'";
        

        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(dataqry);

        if (dt.Rows.Count > 0)
        {
            divmsg.Style.Add("display", "none");
            tbl_grd.Attributes.Add("style", "display:block");
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();
            tbl_xl.Attributes.Add("style", "display:");
        }

        else
        {
            tbl_grd.Attributes.Add("style", "display:none");
            showmsg(11, "No Records Returned for the Search Criteria.");
            return;
            //  divmsg.Style.Add("display", "");
            //  divmsg.InnerText = "No Records Available";
            //  divmsg.Attributes.Add("class", "msg-information");


        }
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

    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Prosperity.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grvEmployee.AllowPaging = false;

        grvEmployee.HeaderRow.Style.Add("background-color", "#FFFFFF");

        for (int a = 0; a < grvEmployee.HeaderRow.Cells.Count; a++)
        {
            grvEmployee.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
        }
        int j = 1;
        foreach (GridViewRow gvrow in grvEmployee.Rows)
        {

            if (j <= grvEmployee.Rows.Count)
            {
                if (j % 2 != 0)
                {
                    for (int k = 0; k < gvrow.Cells.Count; k++)
                    {
                        gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                    }
                }
            }
            j++;
        }

        HtmlForm frm = new HtmlForm();
        grvEmployee.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(grvEmployee);
        frm.RenderControl(htw);
        //grvEmployee.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 


       // string attachment = "attachment; filename=Export.xls";
       // Response.ClearContent();
       // Response.AddHeader("content-disposition", attachment);
       // Response.ContentType = "application/ms-excel";
       // StringWriter sw = new StringWriter();
       // HtmlTextWriter htw = new HtmlTextWriter(sw);
       // // Create a form to contain the grid
       // HtmlForm frm = new HtmlForm();
       // grvEmployee.Parent.Controls.Add(frm);
       // frm.Attributes["runat"] = "server";
       // frm.Controls.Add(grvEmployee);
       // frm.RenderControl(htw);

       //// grvEmployee.RenderControl(htw);
       // Response.Write(sw.ToString());
       // Response.End();
    }
}