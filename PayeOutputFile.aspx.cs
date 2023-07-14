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


public partial class PayeOutputFile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt_list = new DataTable();

            // SqlDataAdapter Adp = new SqlDataAdapter("SELECT [TaxPayerRIN],[CompanyRIN],[CompanyName],ContactAddress,[AssetRIN],[BusinessRIN],[BusinessName],[AssessmentRuleName],[TaxMonth],[TaxYear],[AssessmentAmount],(case when AssessmentAmount=0 then 'No' else 'Yes' end)  as Status, '0' as AnnualBasic,'0' as AnnualRent, '0' as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, '0' as OtherAllounces_Annual, '0' as LeaveTransport_Annual, '0' as AnnualGross,'0' as Pension, '0' as NHF, '0' as NHIS,'' as title, '' as firstname, '' as midname, '' as surname, '' as nationality, '' as emp_rin, '' as emp_tin  FROM [pinscher_paye-ctec].[dbo].[vw_Rules_Check] where AssessmentAmount=0 order by TaxPayerRIN, cast(TaxMonth1 as int) asc", con);

            SqlDataAdapter Adp = new SqlDataAdapter("select * from PayeOuputfile where employeeRIN is not null", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp.Fill(dt_list);

            Session["dt_l"] = dt_list;
            grd_rules_check.DataSource = dt_list;
            grd_rules_check.DataBind();

            int pagesize = grd_rules_check.Rows.Count;
            int from_pg = 1;
            int to = grd_rules_check.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_rules_check.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-60px");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_rules_check.PageIndex = e.NewPageIndex;
        grd_rules_check.DataSource = Session["dt_l"];

        grd_rules_check.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_rules_check.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_rules_check.Rows.Count).ToString();

    }

    protected void lnkCustDetails_Click(object sender, EventArgs e)
    {
        // divTaxPayerModal.Style.Add("display", "");
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {

    }
}