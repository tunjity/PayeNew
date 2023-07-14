using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session.Timeout = 1;
        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");
            
        }

      //  Response.Redirect("FileReturns.aspx");

    }
}