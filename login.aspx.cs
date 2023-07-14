//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

public partial class login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string access_token = PAYEClass.getToken();
        string loginqry = "Select * from Eirs_user where user_name=@a and password=@b";
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        SqlCommand cmd = new SqlCommand(loginqry, con);
        cmd.Parameters.AddWithValue("@a", txtusername.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@b", txtpassword.Text.ToString().Trim());
        DataTable dt = new DataTable();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
            Session["token"] = access_token;
            Session["user_id"] = dt.Rows[0]["user_id"].ToString();
            Session["username"] = dt.Rows[0]["user_name"].ToString();

            Response.Redirect("dashboard.aspx");
        }
        else
        {
            divmsg.Style.Add("display", "");
        }

        Session.Timeout = 1;
    }

   
}