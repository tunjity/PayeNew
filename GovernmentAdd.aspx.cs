using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class GovernmentAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        binddropdown();
    }

    public void binddropdown()
    {
        string token = Session["token"].ToString();
       // drpgovttaxoffice.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/TaxOffice/List","",token);

        drpgovttaxoffice.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/TaxOffice/List", "", token);
        drpgovttaxoffice.DataTextField = "TaxOfficeName";
        drpgovttaxoffice.DataValueField = "TaxOfficeID";
        drpgovttaxoffice.DataBind();

        //drpgovtprefnotification.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/NotificationMethod/List", "",token);

        drpgovtprefnotification.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/NotificationMethod/List", "", token);
        drpgovtprefnotification.DataTextField = "NotificationMethodName";
        drpgovtprefnotification.DataValueField = "NotificationMethodID";
        drpgovtprefnotification.DataBind();

   }
}