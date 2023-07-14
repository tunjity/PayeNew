using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentResponse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["res"] != null)
        {
            string response = Request.QueryString["res"].ToString();
            string[] val = new string[3];
            val = response.Split('-');
            int resresult = int.Parse(val[0].ToString());
            int method = int.Parse(val[1].ToString());
            string txnid = val[2].ToString();
            if (insertsetllement(resresult,method) == 1)
            {
                Session["txnid"] = null;
                Session["assessment_ref"] = null;
                divshow.InnerHtml = "<i class='fa fa-check-circle-o' style='font-size:200px;color:#2bab5c;'></i>";
                divsuccess.Style.Add("display", "");
                divfail.Style.Add("display", "none");
                divsuccess.InnerHtml = "<h3><i class='fa fa-check'></i>&nbsp;Your payment is successfully done. Your transaction id is " + txnid + ". Please keep transaction id for future refrence.</h3>";
            }
            else
            {
                divshow.InnerHtml = "<i class='fa fa-check-circle-o' style='font-size:200px;color:#2bab5c;'></i>";
                divsuccess.Style.Add("display", "");
                divfail.Style.Add("display", "none");
                divsuccess.InnerHtml = "<h3><i class='fa fa-check'></i>&nbsp;Your payment is successfully done but there was some error from server. Please contact administrator with your transaction id(" + txnid + ").</h3>";
            }

            
        }
    }

    public int insertsetllement(int result,int method)
    {
        String assessments_ref = Session["assessment_ref"].ToString();
        int status = 0;
        SqlParameter[] pram = new SqlParameter[8];
        pram[0] = new SqlParameter("@settle_create_by", "1");
        pram[1] = new SqlParameter("@settlement_ref", Session["txnid"].ToString());
        pram[2] = new SqlParameter("@assessment_ref", assessments_ref.ToString());
        pram[3] = new SqlParameter("@settlement_status", result);
        pram[4] = new SqlParameter("@settlement_amount", Session["amountpaid"].ToString().Trim());
        pram[5] = new SqlParameter("@settlement_notes", "Payment Success");
        pram[6] = new SqlParameter("@settlement_method", method);
        pram[7] = new SqlParameter("@SucessId", 1);
        pram[7].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_SETTLEMENT", pram);
        return status = int.Parse(pram[7].Value.ToString());
    }
}

#region faltucode
//if (resresult == 1)
//{
//    if (Session["txnid"] != null)
//    {

//        if (txnid.ToString().Trim() == Session["txnid"].ToString().Trim())
//        {

//        }
//        else
//        {
//            divshow.InnerHtml = "<i class='fa fa-times-circle-o' style='font-size:200px;color:#de6a62;'></i>";
//            divsuccess.Style.Add("display", "none");
//            divfail.Style.Add("display", "");
//            divfail.InnerHtml = "<h3><i class='fa fa-warning (alias)'></i>&nbsp;Oops! ! The page is invalid.</h3>";

//        }
//    }
//    else
//    {
//        divshow.InnerHtml = "<i class='fa fa-times-circle-o' style='font-size:200px;color:#de6a62;'></i>";
//        divsuccess.Style.Add("display", "none");
//        divfail.Style.Add("display", "");
//        divfail.InnerHtml = "<h3><i class='fa fa-warning (alias)'></i>&nbsp;Oops! ! The request cannot be processed.</h3>";
//    }
//}
//else
//{
//    divshow.InnerHtml = "<i class='fa fa-times-circle-o' style='font-size:200px;color:#de6a62;'></i>";
//    divsuccess.Style.Add("display", "none");
//    divfail.Style.Add("display", "");
//    divfail.InnerHtml = "<h3><i class='fa fa-warning (alias)'></i>&nbsp;There was some problem in processing your payment.Please contact your bank if money is deducted from your account.</h3>";
//}
#endregion