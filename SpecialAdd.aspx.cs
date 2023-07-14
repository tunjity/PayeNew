using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class SpecialAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        binddropdown();
    }

    public void binddropdown()
    {
        string token = Session["token"].ToString();
        drpspecialtaxoffice.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/TaxOffice/List","",token);
        drpspecialtaxoffice.DataTextField = "TaxOfficeName";
        drpspecialtaxoffice.DataValueField = "TaxOfficeID";
        drpspecialtaxoffice.DataBind();

        drpspecialprefnotification.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/NotificationMethod/List", "", token);
        drpspecialprefnotification.DataTextField = "NotificationMethodName";
        drpspecialprefnotification.DataValueField = "NotificationMethodID";
        drpspecialprefnotification.DataBind();

    }
}