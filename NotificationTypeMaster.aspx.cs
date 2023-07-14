using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotificationTypeMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int status = submitrecord();
        if (status == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Insert Successfull";
            divmsg.Attributes.Add("class", "msg");
        }
        else if (status == 2)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Insert Rolledback. Item already exists";
            divmsg.Attributes.Add("class", "msg-error");
        }
        else
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Error in insertion";
            divmsg.Attributes.Add("class", "msg-error");
        }
    }

    public int submitrecord()
    {
        SqlParameter[] pram = new SqlParameter[6];
        pram[0] = new SqlParameter("@nottype", txtnottype.Text.Trim());
        pram[1] = new SqlParameter("@notdesc", txtnotdesc.Text.Trim());
        pram[2] = new SqlParameter("@firstesc", txtfirstesc.Text.Trim());
        pram[3] = new SqlParameter("@secondesc", txtsecondesc.Text.Trim());
        pram[4] = new SqlParameter("@userid", "1");
        pram[5] = new SqlParameter("@SucessId", "1");
        pram[5].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_NotificationType", pram);
        return int.Parse(pram[5].Value.ToString());
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int status = updaterecord();
        if (status == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Update Successfull";
            divmsg.Attributes.Add("class", "msg");
        }
        else if (status == 2)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Update Rolledback. No Item found to update";
            divmsg.Attributes.Add("class", "msg-error");
        }
        else
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Error in updation";
            divmsg.Attributes.Add("class", "msg-error");
        }
    }

    public int updaterecord()
    {
        SqlParameter[] pram = new SqlParameter[6];
        pram[0] = new SqlParameter("@notid", drpnotificationtype.SelectedValue.Trim());
        pram[1] = new SqlParameter("@notdesc", txtupdnotdesc.Text.Trim());
        pram[2] = new SqlParameter("@firstesc", txtupdfirstesc.Text.Trim());
        pram[3] = new SqlParameter("@secondesc", txtupdsecesc.Text.Trim());
        pram[4] = new SqlParameter("@userid", "1");
        pram[5] = new SqlParameter("@SucessId", "1");
        pram[5].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_UPD_NotificationType", pram);
        return int.Parse(pram[5].Value.ToString());
    }

    protected void radopt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radopt.SelectedValue.Trim() == "1")
        {
            divsubmit.Style.Add("display", "");
            divupdate.Style.Add("display", "none");
        }
        else
        {
            divsubmit.Style.Add("display", "none");
            divupdate.Style.Add("display", "");
            binddrp();
        }
    }

    public void binddrp()
    {
        string qry = "Select nott,notification_types from notification_types";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        if (dt.Rows.Count > 0)
        {
            drpnotificationtype.DataSource = dt;
            drpnotificationtype.DataTextField = "notification_types";
            drpnotificationtype.DataValueField = "nott";
            drpnotificationtype.DataBind();
            drpnotificationtype.Items.Insert(0, "----Select----");
        }
    }
    protected void drpnotificationtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string qry = "Select * from notification_types where nott='"+drpnotificationtype.SelectedValue.Trim()+"'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        if (dt.Rows.Count > 0)
        {
            txtupdnotdesc.Text = dt.Rows[0]["type_description"].ToString().Trim();
            txtupdfirstesc.Text = dt.Rows[0]["FirstEscalation"].ToString().Trim();
            txtupdsecesc.Text = dt.Rows[0]["SecondEscalation"].ToString().Trim();
        }
    }
}