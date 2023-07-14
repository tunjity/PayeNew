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
using Newtonsoft.Json;
using System.IO;

public partial class Dashboard : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {




       if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");

        }

       
}

}