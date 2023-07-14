using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class AssessmentList : System.Web.UI.Page
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        //  public string Content-type { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /***************************************************************/

            //string URI = "https://stage-api.eirsautomation.xyz/Account/Login";
            //// string myParameters = "UserName=Contec&Password=3Uhf7j~4&grant_type=password";
            //string user = "Contec";
            //string myParameters = "UserName=" + user + "&Password=Znal821*&grant_type=password";
            //string BearerToken = "";
            //using (WebClient wc = new WebClient())
            //{
            //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    BearerToken = wc.UploadString(URI, myParameters);
            //}

            //// Token[] jsonObject = JsonReader.Deserialize<Token[]>(BearerToken);
            //Token TokenObj = JsonConvert.DeserializeObject<Token>(BearerToken);
            ///**************************************************************/
            //string a = get_json();

            //// string URI1 = "https://stage-api.eirsautomation.xyz/TaxPayer/Company/List";

            //string URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";

            //URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_AssessmentItem";
            //string myParameters1 = "";
            //string saveLoc = @"/project1/home_image";
            //string InsCompRes = "";
            //InsCompRes = a;

            //DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));
            //DataTable dt_filtered = new DataTable();

            //string[] TobeDistinct = { "AssessmentItemReferenceNo", "AssessmentItemName", "RevenueStreamName", "RevenueSubStreamName", "AssessmentItemCategoryName", "AgencyName", "ComputationName" };
            //DataTable dtDistinct = GetDistinctRecords(dt_list, TobeDistinct);

            //Session["dt_l"] = dtDistinct;
            //grd_rules.DataSource = dtDistinct;
            //grd_rules.DataBind();

            //int pagesize = grd_rules.Rows.Count;
            //int from_pg = 1;
            //int to = grd_rules.Rows.Count;
            //int totalcount = dtDistinct.Rows.Count;
            //lblpagefrom.Text = from_pg.ToString();
            //lblpageto.Text = (from_pg + pagesize - 1).ToString();
            //lbltoal.Text = totalcount.ToString();

            //if (totalcount < grd_rules.PageSize)
            //    div_paging.Style.Add("margin-top", "0px");
            //else
            //    div_paging.Style.Add("margin-top", "-60px");
            DataTable dtnull = new DataTable();
            dtnull = null;
            grd_rules.DataSource = dtnull;
            grd_rules.DataBind();
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
        grd_rules.PageIndex = e.NewPageIndex;
        grd_rules.DataSource = Session["dt_l"];
        grd_rules.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_rules.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_rules.Rows.Count).ToString();
    }

    public string get_json()
    {
        WebClient request = new WebClient();

        string url = PAYEClass.uploadurltxtfile + "Assessment.txt";
        string version = "";
        string fileString = "";
        request.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);
        //  FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        try
        {
            // byte[] data = Encoding.ASCII.GetBytes("dd");
            // request.UploadData(new Uri("ftp://pinscher.eirsautomation.xyz/App_Code/") + "Individuals.txt",data);
            byte[] newFileData = request.DownloadData(new Uri(url));
            fileString = System.Text.Encoding.UTF8.GetString(newFileData);

            DateTime result = DateTime.MinValue;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
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

        URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Assessment";
        URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Assessment";

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

        string url = PAYEClass.uploadurltxtfile + "Assessment.txt";
        string version = "";
        string fileString = "";
        request.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);

        try
        {
            byte[] data = Encoding.ASCII.GetBytes(json);
            request.UploadData(new Uri(url), data);
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