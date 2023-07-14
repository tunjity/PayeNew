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

public partial class CorporateAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bind_dropdowns();
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

    }

    public void bind_dropdowns()
    {
        string token = Session["token"].ToString();
       // txt_tax_office.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/TaxOffice/List","",token);
        txt_tax_office.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/TaxOffice/List","",token);
        
        txt_tax_office.DataTextField = "TaxOfficeName";
        txt_tax_office.DataValueField = "TaxOfficeID";
        txt_tax_office.DataBind();

       // txt_pre_notification.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/NotificationMethod/List", "",token);

        txt_pre_notification.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/NotificationMethod/List", "", token);
        txt_pre_notification.DataTextField = "NotificationMethodName";
        txt_pre_notification.DataValueField = "NotificationMethodID";
        txt_pre_notification.DataBind();

       // txt_economic_activity.DataSource = PAYEClass.processAPI("https://stage-api.eirsautomation.xyz/ReferenceData/EconomicActivities/List?TaxPayerTypeID=1", "",token);

        txt_economic_activity.DataSource = PAYEClass.processAPI(PAYEClass.URL_API + "ReferenceData/EconomicActivities/List?TaxPayerTypeID=1", "", token);
        txt_economic_activity.DataTextField = "EconomicActivitiesName";
        txt_economic_activity.DataValueField = "EconomicActivitiesID";
        txt_economic_activity.DataBind();
       
    }
}