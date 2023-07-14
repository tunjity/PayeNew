using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class IndividualAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        binddropdown();
    }

    public void binddropdown()
    {
        string token = Session["token"].ToString();
       // drptaxoffice.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/TaxOffice/List","",token);

        drptaxoffice.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/TaxOffice/List", "", token);
        drptaxoffice.DataTextField = "TaxOfficeName";
        drptaxoffice.DataValueField = "TaxOfficeID";
        drptaxoffice.DataBind();

        //drpprefnotification.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/NotificationMethod/List", "",token);

        drpprefnotification.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/NotificationMethod/List", "", token);
        drpprefnotification.DataTextField = "NotificationMethodName";
        drpprefnotification.DataValueField = "NotificationMethodID";
        drpprefnotification.DataBind();

       // drpeconomicactivity.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/EconomicActivities/List?TaxPayerTypeID=1", "",token);

        drpeconomicactivity.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/EconomicActivities/List?TaxPayerTypeID=1", "", token);
        drpeconomicactivity.DataTextField = "EconomicActivitiesName";
        drpeconomicactivity.DataValueField = "EconomicActivitiesID";
        drpeconomicactivity.DataBind();
    }
}