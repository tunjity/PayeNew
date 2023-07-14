using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayTax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["q"] != null)
            {
                string rin = Request.QueryString["q"].ToString();
                loaddata(rin);
            }
        }
    }

    public void loaddata(string rin)
    {
        try
        {
            string qry = "Select * from vw_business_comp_relation  where company_rin='" + rin.Trim() + "'";
            DataTable dt = new DataTable();
            dt = PAYEClass.fetchdata(qry);
            if (dt.Rows.Count > 0)
            {
                lblcompname.Text = dt.Rows[0]["company_name"].ToString();
                lblemailid.Text = dt.Rows[0]["email_address_1"].ToString();
                lblmobilenumber.Text = dt.Rows[0]["mobile_number_1"].ToString();
                lblamount.Text = (Convert.ToInt32(Session["amount"].ToString())).ToString();
                txttsa.Text = (Convert.ToInt32(Session["SettlementAmt"].ToString())).ToString();
                txtba.Text = txtatp.Text = (double.Parse(lblamount.Text.ToString()) - double.Parse(txttsa.Text.ToString())).ToString();

                lblyear.Text = Session["year"].ToString();
                lblassessmentref.Text = Session["child_ass_ref"].ToString();
                bindgrid();
                txtMonth.Text = Session["month"].ToString();
                Random rnd = new Random();
                string txnid = rin.Substring(0, 4) + DateTime.Now.ToString("yyyy") + rnd.Next(1111, 9999);
                lbltxnid.Text = txnid;
                lblcomprin.Text = rin.Trim();

                Session["rin"] = rin.Trim();
                Session["tax_year"] = lblyear.Text.ToString().Trim();
                Session["assessment_ref"] = lblassessmentref.Text;
                Session["txnid"] = txnid;

                Session["year"] = Session["child_ass_ref"] = Session["month"] = null;

            }
        }
        catch (Exception ex)
        {
            Response.Redirect("PaymentInterface.aspx");
        }
    }

    public void bindgrid()
    {
        string qry = "Select * from vw_settlements where assessment_ref='" + lblassessmentref.Text.ToString().Trim() + "'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        if (dt.Rows.Count > 0)
        {
            grdsettlements.DataSource = dt;
            grdsettlements.DataBind();
        }
        else
        {
            grdsettlements.DataSource = null;
            grdsettlements.DataBind();
        }
    }

    protected void btnScratch_Click(object sender, EventArgs e)
    {
        makepayment(2);
    }
    protected void btnpaywithdc_Click(object sender, EventArgs e)
    {
        makepayment(1);
    }

    public void makepayment(int method)
    {
        if (txtatp.Text.Length > 0)
        {
            lblmsg.Visible = false;
            int status = 0;
            if (double.Parse(txtba.Text) < double.Parse(txtatp.Text))
            {
                return;
            }
            else if (double.Parse(txtba.Text) > double.Parse(txtatp.Text))
            {
                status = 2;
            }
            else if (double.Parse(txtba.Text) == double.Parse(txtatp.Text))
            {
                status = 1;
            }
            Session["amountpaid"] = txtatp.Text.ToString();
            Response.Redirect("PaymentResponse.aspx?res=" + status + "-" + method + "-" + lbltxnid.Text.Trim());
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Enter Amount to pay";
        }
    }
   
}