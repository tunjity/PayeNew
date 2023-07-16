using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            drpusername_SelectedIndexChanged();
            //String getLgaQuery = "";
            //if (int.Parse(Session["type_code"].ToString()) == 100)
            //{
            //    getLgaQuery = "select * from Local_Government_Areas";
            //}
            //else
            //{
            //    getLgaQuery = "select * from Local_Government_Areas Where lga_id = " + Session["lga"].ToString();
            //}
            //  binddrop();
            //  // BindDropDownList(lgaList, getLgaQuery, "Lga", "Id", "Select LGA");
        }

        //int i = 0;
        //if (ddlStates.Items.Count == 0)
        //{
        //    //var countryId = ddlStates.Items[0].ToString();
        //    String loginqry = "";
        //    if (int.Parse(Session["type_code"].ToString()) == 100 || int.Parse(Session["type_code"].ToString()) == 104 || int.Parse(Session["type_code"].ToString()) == 114)
        //    {
        //        // string qry = "select Id, Town from BeatTown where Lga =" + " '" + countryId.ToString() + "' ";
        //        loginqry = " select distinct (select top 1 id from Beat t2 where t1.town= t2.town) as id, Town from [Beat] t1";
        //    }

        //    SqlCommand cmd = new SqlCommand(loginqry, con);
        //    DataTable dt = new DataTable();
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    con.Close();

        //    i = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {

        //        String type = dr["Id"].ToString();
        //        ddlStates.Items.Insert(i, new ListItem(dr["Town"].ToString(), type));
        //        i++;
        //    }
        //}
        //if (Accesstype.Items.Count == 0)
        //{
        //    string loginqry = "";
        //    if (int.Parse(Session["type_code"].ToString()) == 104)
        //    {
        //        loginqry = "select distinct [type_code],[description] from [oyo_user_types] where [Priveledge] = 104 ";
        //    }
        //    else
        //    {
        //        loginqry = "select distinct [type_code],[description] from [oyo_user_types]";
        //    }

        //    SqlCommand cmd = new SqlCommand(loginqry, con);
        //    DataTable dt = new DataTable();
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    con.Close();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        String type = dr["type_code"].ToString();
        //        Accesstype.Items.Insert(i, new ListItem(dr["description"].ToString(), type));
        //       // Accesstype.Items.Insert(i, new ListItem(dr["description"].ToString(), type));
        //        i++;
        //    }
        //}
    }

    //public void binddrop()
    //{
    //    string qry = "";
    //    if (int.Parse(Session["type_code"].ToString()) == 100)
    //    {
    //        qry = "Select first_name+' '+ last_name as user_name,id as user_id from oyo_Registration where mobile_no <> '" + Session["user_id"] + "'";
    //    }
    //    else
    //    {
    //        qry = "Select first_name+' '+ last_name as user_name,id as user_id from oyo_Registration where mobile_no <> '" + Session["user_id"] + "' and lga_id=" + Session["lga"].ToString();
    //    }

    //    DataTable dt = new DataTable();
    //    dt = OYOClass.fetchdata(qry);
    //    if (dt.Rows.Count > 0)
    //    {
    //        drpusername.DataSource = dt;
    //        drpusername.DataTextField = "user_name";
    //        drpusername.DataValueField = "user_id";
    //        drpusername.DataBind();
    //        drpusername.Items.Insert(0, "---Select---");
    //    }

    //}
    protected void drpusername_SelectedIndexChanged()
    {
        //if (drpusername.SelectedIndex != 0)
        //{
        string id = Session["user_id"].ToString();
        string loginqry = "SELECT  [AdminUserId],P.UserType,R.Role,[Password],[Username],[Email],[FirstName] ,[LastName],IsActive,[Designation],[Phone]  FROM [AdminUser] A LEFT JOIN PayeRole R on A.RoleId = R.RoleId  LEFT JOIN PayeUserType P on A.PayeUserTypeId = P.UserTypeId  WHERE A.AdminUserId ='" + id + "'";
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
            TextBox1.Text = dt.Rows[0]["Password"].ToString();
            //txt_entityid.Text = dtuser.Rows[0]["EntityId"].ToString();
            //txt_mobileno.Text = dtuser.Rows[0]["mobile_no"].ToString();
            //drp_gender.SelectedValue = dtuser.Rows[0]["gender"].ToString();
            //lgaList.Items.FindByValue(dtuser.Rows[0]["lga_id"].ToString()).Selected = true;
            //txt_dob.Text = kkg;
            ////= dtuser.Rows[0]["designation"].ToString();              
            //txt_address.Text = dtuser.Rows[0]["address"].ToString();
            //txt_email.Text = dtuser.Rows[0]["email"].ToString();
            //beatCode.Items.FindByValue(dtuser.Rows[0]["beat_code"].ToString()).Selected=true;
            //  txt_secured_pin.Text = (dtuser.Rows[0]["mpin"].ToString());

            //string mpin = decrypt(dtuser.Rows[0]["mpin"].ToString());
        }
        else
        {
            //txt_designation.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
        }

        //else
        //{
        //    //txt_designation.Text = "";
        //    txt_address.Text = "";
        //    txt_mobileno.Text = "";
        //}
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //txt_dob.Visible = true;
        //string startDate = txt_dob.Text;

        //HtmlContainerControl modalinfo = this.Page.FindControl("modalinfo") as HtmlContainerControl;
        //Label lblmodalbody = this.Page.FindControl("lblmodalbody") as Label;
        //string securedPIN = CreateMD5(txt_secured_pin.Text.ToString());

        //System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
        //string qry = "Update oyo_Registration set lga_id='" + lgaList.SelectedValue.ToString().Trim() + "', " +
        //    "beat_code='" + beatCode.Text.ToString() + "'," + "dob='" + DateTime.ParseExact(txt_dob.Text.ToString(), "yyyy-MM-dd", provider) + "',modified_by='" + Session["user_id"] + "', address='" + txt_address.Text.Trim() + "',email='" + txt_email.Text.Trim() + "',mpin='" + securedPIN + "',type_code='" + txt_DesignationDropDown.SelectedValue.ToString().Trim() + "' where id='" + drpusername.SelectedValue.ToString().Trim() + "'";
        //int status = OYOClass.insertupdateordelete(qry);
        //if (status > 0)
        //{
        //    string script = "alert('User updated Successfully!! (" + status + ")');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "successAlert", script, true);
        //    return;
        //}
        //else
        //{
        //    string script = "alert('User updated Not Successf!! (" + status + ")');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "successAlert", script, true);
        //    return;

        //}
    }
}