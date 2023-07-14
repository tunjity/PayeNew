using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MonthlyTax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["empid"] !=null)
        {
            string emp_id = Request.QueryString["empid"].ToString().Trim();
            string qry = "SELECT [Jan],[Feb],[Mar],[Apr],[May],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec] FROM [vw_monthly_tax_emp_wise] where sal_employee_id='" + emp_id + "' ";
            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(qry);
            if (dt.Rows.Count > 0)
            {
                grdmonthlytax.DataSource = dt;
                grdmonthlytax.DataBind();
            }

        }
    }
}