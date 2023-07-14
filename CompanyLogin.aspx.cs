using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompanyLogin : System.Web.UI.Page
{
    public String year = "2021";
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime curretnDate = DateTime.Today; ; // random date
        year = curretnDate.ToString("yyyy");
    }
}