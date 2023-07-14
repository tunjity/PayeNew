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

public partial class BusinessList : System.Web.UI.Page
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        //  public string Content-type { get; set; }
    }

    class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Result> Result { get; set; }
    }
    class Result
    {
        public string TaxPayerID { get; set; }
        public string TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerRIN { get; set; }

        public string BusinessID { get; set; }
        public string AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public string BusinessTypeID { get; set; }
        public string BusinessTypeName { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /***************************************************************/
            string token = PAYEClass.getToken();
            /**************************************************************/
            //  var a = get_json();

            // string URI1 = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/List";

            // string URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";

            string URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Asset";
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Asset";

            string myParameters1 = "";
            string saveLoc = @"/project1/home_image";
            var InsCompRes = "";
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

                string path = HttpContext.Current.Server.MapPath("~/App_Code/Business.txt");
               // path = "ftp://pinscher.eirsautomation.xyz/App_Code/Business.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                InsCompRes = wc.DownloadString(URI1);

                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(InsCompRes);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                //string text = File.ReadAllText(path, Encoding.UTF8);
                string text = System.IO.File.ReadAllText(path);
                var videogames = JsonConvert.DeserializeObject<Response>(text);
                InsCompRes = text;
             //   Console.WriteLine(text);
                
            }

                
            }
            string path1 = HttpContext.Current.Server.MapPath("~/App_Code/Business.txt");
            string text1 = System.IO.File.ReadAllText(path1);
            var videogames1 = JsonConvert.DeserializeObject<Response>(text1);
            InsCompRes = System.IO.File.ReadAllText(path1); ;
            DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") +  "]", (typeof(DataTable)));
            //InsCompRes.Split('[')[2].Replace("}]", "") +
            //  return JObject.Parse(@"{""SpecialList"" :" + InsCompRes + "}");

            //    DataRow[] filteredRows = dt_list.Select("TaxPayerRIN LIKE '" + RIN + "'");
            DataTable dt_filtered = new DataTable();
            //dt_filtered.Columns.AddRange(new DataColumn[] { new DataColumn("CompanyID"), new DataColumn("CompanyRIN"), new DataColumn("CompanyName"), new DataColumn("tin"), 
            //        new DataColumn("MobileNumber1"), new DataColumn("MobileNumber2"), new DataColumn("EmailAddress1"), new DataColumn("EmailAddress2"), new DataColumn("TaxOfficeID"), new DataColumn("TaxOfficeName"), new DataColumn("TaxPayerTypeID"), new DataColumn("TaxPayerTypeName"),
            //        new DataColumn("EconomicActivitiesID"), new DataColumn("EconomicActivitiesName"), new DataColumn("NotificationMethodID"), new DataColumn("NotificationMethodName"), new DataColumn("ContactAddress"), new DataColumn("Active"), new DataColumn("ActiveText")});


            string[] TobeDistinct = { "BusinessRIN", "BusinessName", "BusinessAddress", "BusinessSectorName", "BusinessSubSectorName" };
            DataTable dtDistinct = GetDistinctRecords(dt_list, TobeDistinct);


            Session["dt_l"] = dt_list;
            grd_ind.DataSource = dt_list;
            grd_ind.DataBind();
        }
    }

    public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
    {
        DataTable dtUniqRecords = new DataTable();
        dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
        return dtUniqRecords;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_ind.PageIndex = e.NewPageIndex;
        grd_ind.DataSource = Session["dt_l"];
        grd_ind.DataBind();
    }

    public string get_json()
    {
        WebClient request = new WebClient();

        string version = "";
        string fileString = "";
        request.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);
        //  FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        try
        {
            // byte[] data = Encoding.ASCII.GetBytes("dd");
            // request.UploadData(new Uri("ftp://pinscher.eirsautomation.xyz/App_Code/") + "Individuals.txt",data);
            byte[] newFileData = request.DownloadData(new Uri(PAYEClass.uploadurltxtfile) + "Business.txt");
            fileString = System.Text.Encoding.UTF8.GetString(newFileData);

            DateTime result = DateTime.MinValue;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(PAYEClass.uploadurltxtfile) + "Business.txt");
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);
            reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            result = response.LastModified;

            if (result.Day > 10 || fileString == "")
            {
                upload_json("");
            }
        }
        catch (WebException e)
        {

        }
        return fileString;
    }

    public void upload_json(string json)
    {
        /***************************************************************/

        string token = PAYEClass.getToken();
        /**************************************************************/
        string URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";

         URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Asset";
         URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Asset";

        string myParameters1 = "";
        string saveLoc = @"/project1/home_image";
        string InsCompRes = "";
        using (var wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            InsCompRes = wc.DownloadString(URI1);
        }

        json = InsCompRes;

        WebClient request = new WebClient();

        string url = PAYEClass.uploadurltxtfile + "Business.txt";
        string version = "";
        string fileString = "";
        request.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);

        try
        {
            byte[] data = Encoding.ASCII.GetBytes(json);
            request.UploadData(new Uri(PAYEClass.uploadurltxtfile) + "Business.txt", data);
            //  byte[] newFileData = request.DownloadData(new Uri("ftp://pinscher.eirsautomation.xyz/App_Code/") + "Individuals.txt");
            // fileString = System.Text.Encoding.UTF8.GetString(newFileData);
        }
        catch (WebException e)
        {

        }

    }

    public void CallAPI()
    {

    }
    protected void drpAction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lnkCustDetails_Click(object sender, EventArgs e)
    {
        // divTaxPayerModal.Style.Add("display", "");
    }
}