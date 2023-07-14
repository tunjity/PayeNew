using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageNew : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session.Timeout = 20;
        //if (Session["user_id"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        //else
        //{
        //    username.Text = Session["username"].ToString();
        //}
    }
}
