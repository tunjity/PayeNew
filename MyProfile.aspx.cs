using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Request.QueryString["emailEMP"] != null)
            {
                string email = Request.QueryString["emailEMP"].ToString();
                drpusername_SelectedIndexChanged(email);
            }
            else
                drpusername_SelectedIndexChanged("");
        }
    }
    protected void drpusername_SelectedIndexChanged(string em)
    {
        string id = Session["user_id"].ToString(); string loginqry = "";
        if (em == "" || em == null)
            loginqry = "SELECT  [AdminUserId],P.UserType,R.Role,[Password],[Username],[Email],[FirstName] ,[LastName],IsActive,[Designation],[Phone]  FROM [AdminUser] A LEFT JOIN PayeRole R on A.RoleId = R.RoleId  LEFT JOIN PayeUserType P on A.PayeUserTypeId = P.UserTypeId  WHERE A.AdminUserId ='" + id + "'";
        else
            loginqry = "SELECT  [AdminUserId],P.UserType,R.Role,[Password],[Username],[Email],[FirstName] ,[LastName],IsActive,[Designation],[Phone]  FROM [AdminUser] A LEFT JOIN PayeRole R on A.RoleId = R.RoleId  LEFT JOIN PayeUserType P on A.PayeUserTypeId = P.UserTypeId  WHERE A.Email ='" + em + "'";

        SqlConnection con = new SqlConnection(PAYEClass.connection);
        SqlCommand cmd = new SqlCommand(loginqry, con);
        DataTable dt = new DataTable();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
            txt_fname.Text = dt.Rows[0]["FirstName"].ToString();
            txt_lname.Text = dt.Rows[0]["LastName"].ToString();
            txt_phn.Text = dt.Rows[0]["Phone"].ToString();
            txt_email.Text = dt.Rows[0]["Email"].ToString();
            txt_password.Text = dt.Rows[0]["Password"].ToString();
        }
        else
        {
            txt_fname.Text = "";
            txt_lname.Text = "";
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string id = Session["user_id"].ToString();
        SqlConnection con = new SqlConnection(PAYEClass.connection.ToString());

        string password = txt_new_password.Text.ToString().Trim();
        string conpassword = txt_con_password.Text.ToString().Trim();
        if (password != conpassword)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Unable To Update user As Confirm Password Not Same With Password');</script>", false);
            return;
        }
        try
        {
            string q1 = "update AdminUser set Password =@Password WHERE A.AdminUserId ='" + id + "'  ";
            SqlCommand cmd2 = new SqlCommand(q1, con);
            cmd2.Parameters.AddWithValue("@Password", password);
            cmd2.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('User Updated Successfully');</script>", false);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "hideImage()", true);
            con.Close();
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "AlertMessage", "<script language=\"javascript\"  type=\"text/javascript\">;alert('Unable To Update user');</script>", false);
            return;
        }
    }
}