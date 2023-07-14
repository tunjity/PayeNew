using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCompany : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user_id"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        if (!IsPostBack)
        {
            binddropdowns();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if (insertcompany() == 1)
        {
            txtcompname.Text = "";
            txtcompanytin.Text = "";
            txtmobile1.Text = "";
            txtmobile2.Text = "";
            txtemail1.Text = "";
            txtemail2.Text = "";
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Company Created Successfully";
            divmsg.Attributes.Add("class", "msg");
        }
        else
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerText = "Error Occured";
            divmsg.Attributes.Add("class", "msg-error");
        }
    }

    public int insertcompany()
    {
        SqlParameter[] pram = new SqlParameter[13];
        pram[0] = new SqlParameter("@company_create_by", 1);
        pram[1] = new SqlParameter("@company_name", txtcompname.Text.ToString().Trim());
        pram[2] = new SqlParameter("@company_tin", txtcompanytin.Text.Trim());
        pram[3] = new SqlParameter("@mobile_number_1", txtmobile1.Text.Trim());
        pram[4] = new SqlParameter("@mobile_number_2", txtmobile2.Text.Trim());
        pram[5] = new SqlParameter("@email_address_1", txtemail1.Text.Trim());
        pram[6] = new SqlParameter("@email_address_2", txtemail2.Text.Trim());
        pram[7] = new SqlParameter("@tax_office", txttaxoffice.SelectedValue.Trim());
        pram[8] = new SqlParameter("@tax_payer_type", txttaxpayertype.SelectedValue.Trim());
        pram[9] = new SqlParameter("@economic_activity", txteconomicactivity.SelectedValue.Trim());
        pram[10] = new SqlParameter("@preffered_notification_method", txtpreferrednotification.SelectedValue.Trim());
        pram[11] = new SqlParameter("@tax_payer_status", txttaxpayerstatus.SelectedValue.Trim());
        pram[12] = new SqlParameter("@SucessID", 1);
        pram[12].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_Company", pram);
        return int.Parse(pram[12].Value.ToString());
    }

    public void binddropdowns()
    {
        string qry = "Select * from Tax_Offices";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txttaxoffice.DataSource = dt;
        txttaxoffice.DataTextField = "tax_office";
        txttaxoffice.DataValueField = "to_id";
        txttaxoffice.DataBind();

        qry = "Select * from Tax_Payer_types";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txttaxpayertype.DataSource = dt;
        txttaxpayertype.DataTextField = "tax_payer_type";
        txttaxpayertype.DataValueField = "tptype_id";
        txttaxpayertype.DataBind();

        qry = "Select * from Economic_Activities";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txteconomicactivity.DataSource = dt;
        txteconomicactivity.DataTextField = "economic_activity";
        txteconomicactivity.DataValueField = "ea_id";
        txteconomicactivity.DataBind();

        qry = "Select * from Notification_Types";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txtpreferrednotification.DataSource = dt;
        txtpreferrednotification.DataTextField = "notification_types";
        txtpreferrednotification.DataValueField = "nott";
        txtpreferrednotification.DataBind();

        qry = "Select * from Tax_Payer_Roles";
        dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        txttaxpayerstatus.DataSource = dt;
        txttaxpayerstatus.DataTextField = "tpt_status";
        txttaxpayerstatus.DataValueField = "tpt_id";
        txttaxpayerstatus.DataBind();
    }
}