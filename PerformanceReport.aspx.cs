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

public partial class PerformanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbl_grd.Attributes.Add("style", "display:none");
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

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

        string path = @"C:\Paye_SS";  // Give the specific path

        if (!(Directory.Exists(path)))
        {

            Directory.CreateDirectory(path);

           

        }

       // string dataqry = "select * from vw_Performance_Report where Ass_date>='" + txt_start_date.Text + "' and Ass_date<='" + txt_end_date.Text + "'";

        string dataqry = "SELECT assessment_date,Assessm_date,sum(AmountAccessed) as AmountAccessed,sum(ActualAssessmentAmt) as ActualAssessmentAmt, sum(settlement_amount) as settlement_amount FROM vw_Performance_Report where Assessm_date>='" + txt_start_date.Text + "' and Assessm_date<='" + txt_end_date.Text + "' group by assessment_date, Assessm_date";

        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(dataqry);

        if (dt.Rows.Count > 0)
        {
            divmsg.Style.Add("display", "none");
            tbl_grd.Attributes.Add("style", "display:block");
            grvEmployee.DataSource = dt;
            grvEmployee.DataBind();

            Chart1.DataSource = dt;
            Chart1.DataBind();

            
            


            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            int[] z = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i]["assessment_date"].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i]["ActualAssessmentAmt"]);
                z[i] = Convert.ToInt32(dt.Rows[i]["settlement_amount"]);

            }
            Chart1.Series[0].Points.DataBindXY(x, y);

            Chart1.Series[1].Points.DataBindXY(x, z);

            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

            Chart1.SaveImage("c:/Paye_SS/xx.jpg");
          //  img_chart.ImageUrl = "c:/Paye_SS/xx.jpg";
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
}