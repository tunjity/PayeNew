using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt_list = new DataTable();

            SqlDataAdapter Adp = new SqlDataAdapter("SELECT  [AdminUserId],P.UserType,R.Role,[Password],[Username],[Email],[FirstName] + ' ' +[MiddleName] +' '+ [LastName] as FullName,[Designation],[Phone]  FROM [pinscher_spike].[dbo].[AdminUser] A LEFT JOIN PayeRole R on A.RoleId = R.RoleId  LEFT JOIN PayeUserType P on A.PayeUserTypeId = P.UserTypeId", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);
            Session["dt_l"] = dt_list;
            grd_user_management_check.DataSource = dt_list;
            grd_user_management_check.DataBind();

            int pagesize = grd_user_management_check.Rows.Count;
            int from_pg = 1;
            int to = grd_user_management_check.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_user_management_check.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-60px");
        }

    }
}