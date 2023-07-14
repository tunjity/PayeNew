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
using System.Threading;
using System.Linq;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Collections;

public partial class PullData_N : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(PAYEClass.connection);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }


        if (Session["user_id"] == null)
        {
            Response.Redirect("Login.aspx");

        }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ResultProfile
    {
        public int TaxPayerID { get; set; }
        public int TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerRIN { get; set; }
        public int AssetID { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public string AssetRIN { get; set; }
        public int ProfileID { get; set; }
        public string ProfileReferenceNo { get; set; }
        public string ProfileDescription { get; set; }
        public int TaxPayerRoleID { get; set; }
        public string TaxPayerRoleName { get; set; }
    }

    public class ProfileResponse
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public List<ResultProfile> Result { get; set; }
    }









    public class ResultCorporate
    {
        public int TaxPayerID { get; set; }
        public int TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerRIN { get; set; }
        public string MobileNumber { get; set; }
        public string ContactAddress { get; set; }
        public string EmailAddress { get; set; }
        public string TIN { get; set; }
        public string TaxOffice { get; set; }
    }

    public class CorporateResponse
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public List<ResultCorporate> Result { get; set; }
    }





    public class WebClientWithTimeout : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest wr = base.GetWebRequest(address);
            wr.Timeout = 60000; // timeout in milliseconds (ms)
            return wr;
        }
    }


    public class ResultIndividual
    {
        public int TaxPayerID { get; set; }
        public int TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerRIN { get; set; }
        public string MobileNumber { get; set; }
        public string ContactAddress { get; set; }
        public string EmailAddress { get; set; }
        public string TIN { get; set; }
        public string TaxOffice { get; set; }
    }

    public class IndividualResponse
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public List<ResultIndividual> Result { get; set; }
    }




















    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        //  public string Content-type { get; set; }
    }
    public class Receiver
    {
        public string Success { get; set; }
        //public string Message { get; set; }
        //public string Result { get; set; }

    }
    public class AssestResult
    {
        public int TaxPayerID { get; set; }
        public int TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerRIN { get; set; }
        public int BusinessID { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public int BusinessTypeID { get; set; }
        public string BusinessTypeName { get; set; }
        public string BusinessRIN { get; set; }
        public string BusinessName { get; set; }
        public int LGAID { get; set; }
        public string LGAName { get; set; }
        public int BusinessCategoryID { get; set; }
        public string BusinessCategoryName { get; set; }
        public int BusinessSectorID { get; set; }
        public string BusinessSectorName { get; set; }
        public int BusinessSubSectorID { get; set; }
        public string BusinessSubSectorName { get; set; }
        public int BusinessStructureID { get; set; }
        public string BusinessStructureName { get; set; }
        public int BusinessOperationID { get; set; }
        public string BusinessOperationName { get; set; }
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public string ContactName { get; set; }
        public string BusinessNumber { get; set; }
        public string BusinessAddress { get; set; }
    }

    public class Result
    {

        public string TaxPayerID { get; set; }
        public string TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerRIN { get; set; }
        public string AssetID { get; set; }
        public string AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public string AssetRIN { get; set; }
        public string ProfileID { get; set; }
        public string ProfileReferenceNo { get; set; }
        public string ProfileDescription { get; set; }
        public string AssessmentRuleID { get; set; }
        public string AssessmentRuleCode { get; set; }
        public string AssessmentRuleName { get; set; }
        public string AssessmentItemID { get; set; }
        public string AssessmentItemReferenceNo { get; set; }
        public string AssessmentGroupID { get; set; }
        public string AssessmentGroupName { get; set; }
        public string AssessmentSubGroupID { get; set; }
        public string AssessmentSubGroupName { get; set; }
        public string RevenueStreamID { get; set; }
        public string RevenueStreamName { get; set; }
        public string RevenueSubStreamID { get; set; }
        public string RevenueSubStreamName { get; set; }
        public string AssessmentItemCategoryID { get; set; }
        public string AssessmentItemCategoryName { get; set; }
        public string AssessmentItemSubCategoryID { get; set; }
        public string AssessmentItemSubCategoryName { get; set; }
        public string AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string AssessmentItemName { get; set; }
        public string ComputationID { get; set; }
        public string ComputationName { get; set; }
        public string TaxBaseAmount { get; set; }
        public string Percentage { get; set; }
        public string TaxAmount { get; set; }

    }
    public class MainResponse
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public List<Result> Result { get; set; }

    }
    public class MainResponseAsset
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public List<AssestResult> Result { get; set; }

    }

    public class MainResponseRules
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public List<RulesResult> Result { get; set; }

    }

    public class RulesResult
    {
        public string TaxPayerID { get; set; }
        public string TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public string TaxPayerRIN { get; set; }
        public string AssetID { get; set; }
        public string AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public string AssetRIN { get; set; }
        public string ProfileID { get; set; }
        public string ProfileReferenceNo { get; set; }
        public string ProfileDescription { get; set; }
        public string AssessmentRuleID { get; set; }
        public string AssessmentRuleCode { get; set; }
        public string AssessmentRuleName { get; set; }
        public string RuleRunID { get; set; }
        public string RuleRunName { get; set; }
        public string PaymentFrequencyID { get; set; }
        public string PaymentFrequencyName { get; set; }
        public string AssessmentAmount { get; set; }
        public string TaxYear { get; set; }
        public string PaymentOptionID { get; set; }
        public string PaymentOptionName { get; set; }
        public string TaxMonth { get; set; }
    }

    public string upload_json_Corporates(string json)
    {
        /***************************************************************/
        string token = PAYEClass.getToken();
        /**************************************************************/

        string URI1 = "";

        if (json == "Corporates")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_TaxPayer";
        }
        if (json == "CorporatesB")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_TaxPayer";
        }
        if (json == "CorporatesC")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_TaxPayer";
        }
        if (json == "Business")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_Asset";
        }
        if (json == "Rules")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_AssessmentRule?pageNumber=1&pageSize=140000";
        }

        if (json == "Items")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_AssessmentItem?pageNumber=1&pageSize=1000";

        }
        if (json == "Profile")
        {
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_Profile";
        }
        if (json == "Individuals")
        {

            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";

        }
        string myParameters1 = "";

        string InsCompRes = "";
        string headers = "";
        MainResponseRules mainResponse = new MainResponseRules { };
        mainResponse.Result = new List<RulesResult>();
        using (var wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            InsCompRes = wc.DownloadString(URI1);

            if (json == "Rules")
            {
                MainResponseRules response = JsonConvert.DeserializeObject<MainResponseRules>(InsCompRes);
                List<RulesResult> listAssetItems = new List<RulesResult>();
                listAssetItems = response.Result;
                mainResponse.Message = response.Message;
                mainResponse.Success = response.Success;
                mainResponse.Result.AddRange(listAssetItems);
                headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();
            }
        }

        //|| json == "Individuals"
        if (json == "Rules")
        {

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));
            int total_pages = Convert.ToInt32(dttt.Rows[0]["totalPages"].ToString());
            string nextpage = dttt.Rows[0]["nextPage"].ToString();

            // int i = 1; SSS
            for (int i = 2; i <= total_pages; i++)
            {


                URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_AssessmentRule?pageNumber=" + i + "&pageSize=140000";


                using (var wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

                    //  InsCompRes = InsCompRes + wc.DownloadString(URI1);

                    InsCompRes = wc.DownloadString(URI1);

                    MainResponseRules response = JsonConvert.DeserializeObject<MainResponseRules>(InsCompRes);
                    List<RulesResult> listAssetItems = new List<RulesResult>();
                    listAssetItems = response.Result;
                    mainResponse.Message = response.Message;
                    mainResponse.Success = response.Success;
                    mainResponse.Result.AddRange(listAssetItems);
                    //headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

                    //dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));
                    //nextpage = dttt.Rows[0]["nextPage"].ToString();
                }


            }


            json = JsonConvert.SerializeObject(mainResponse);
        }
        else
        {
            json = InsCompRes;
        }






        WebClient request = new WebClient();




        //string url = PAYEClass.uploadurltxtfile + "AssessmentRules.txt";
        //string version = "";
        //string fileString = "";
        //request.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);

        //try
        //{
        //    //  byte[] data = Encoding.ASCII.GetBytes(json);
        //    //  request.UploadData(new Uri(url), data);

        //    StringBuilder sw = new StringBuilder();
        //  //  sw.Append(System.IO.File.ReadAllText(Server.MapPath("~") + "/App_Code/AssessmentRules.txt"));

        //    byte[] data = request.DownloadData(new Uri(url));
        //    InsCompRes = Encoding.UTF8.GetString(data);

        //    json = InsCompRes;
        //}

        //catch (WebException e)
        //{
        //    div_loading.Attributes.Add("display", "none");
        //}
        return json;
    }

    public void insert_corporates(DataTable table)
    {
        try
        {

            SqlConnection con1 = new SqlConnection(PAYEClass.connection);

            SqlCommand truncate = new SqlCommand("TRUNCATE TABLE CompanyList_API", con);
            con.Open();
            truncate.ExecuteNonQuery();
            con.Close();

            SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='CompanyList_API'", con);
            con.Open();
            update_tables_API_Updated.ExecuteNonQuery();
            con.Close();



            // Array.ForEach<DataRow>(table.Select("TaxPayerRIN IS NULL"), row => row.Delete());
            Array.ForEach<DataRow>(table.Select("TaxPayerTypeID IS NULL"), row => row.Delete());
            Array.ForEach<DataRow>(table.Select("TaxPayerID IS NULL"), row => row.Delete());


            using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                //con.Open();
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = "CompanyList_API";
                bulkCopy.WriteToServer(table);
            }

            showmsg(1, "TaxPayer-Corporats Synced Successfully");
        }
        catch (Exception ex)
        {
            showmsg(2, "Error Occured. Contact to Administrator.");
        }
    }




    public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
    {
        return dt.DefaultView.ToTable(true, Columns);
    }




    public void showmsg(int id, string msg)
    {
        if (id == 1)
        {
            divmsg.Style.Add("display", "block");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-check-circle' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-success");
        }
        else if (id == 2)
        {
            divmsg.Style.Add("display", "block");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-warning");
        }
        else
        {
            divmsg.Style.Add("display", "none");
        }
    }



    [System.Web.Services.WebMethod]
    public static void truncate_data()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Assessment_Item_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Assessment_Item_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }

    [System.Web.Services.WebMethod]
    public static void truncate_dataB()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Assessment_Item_API", con); //I need to check this query
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Assessment_Item_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }
    [System.Web.Services.WebMethod]
    public static void truncate_dataC()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Assessment_Item_API", con); //I need to check this query
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Assessment_Item_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }

    [System.Web.Services.WebMethod]
    public static void truncate_assets_data()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Businesses_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Businesses_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }
    [System.Web.Services.WebMethod]
    public static void truncate_assets_dataB()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Businesses_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Businesses_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }
    [System.Web.Services.WebMethod]
    public static void truncate_assets_dataC()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Businesses_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Businesses_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }
    [System.Web.Services.WebMethod]
    public static void truncate_Individual_data()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Individuals_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Individuals_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }


    [System.Web.Services.WebMethod]
    public static void truncate_profile_data()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Profiles_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Profiles_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }
    [System.Web.Services.WebMethod]
    public static void truncate_profile_dataB()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Profiles_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Profiles_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }
    [System.Web.Services.WebMethod]
    public static void truncate_profile_dataC()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Profiles_API", con);
        con.Open();
        truncate.ExecuteNonQuery();
        con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Profiles_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }

    [System.Web.Services.WebMethod]
    public static void truncate_corporate_data()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        //truncating items table to insert new data
        //SqlCommand truncate = new SqlCommand("TRUNCATE TABLE CompanyList_API", con);
        //con.Open();
        //truncate.ExecuteNonQuery();
        //con.Close();

        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='CompanyList_API'", con);
        con.Open();
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }


    [System.Web.Services.WebMethod]
    public static void truncate_Rules_data()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        con.Open();
        DateTime curretnDate = DateTime.Today; ; // random date
        string year = curretnDate.ToString("yyyy");
        //truncating items table to insert new data
        if (PAYEClass.URL_API.Contains("stage"))
        {
            SqlCommand truncate = new SqlCommand("DELETE FROM AssessmentRules WHERE TaxYear =  '2019'", con);

            truncate.ExecuteNonQuery();
        }
        else
        {
            SqlCommand truncate = new SqlCommand("DELETE FROM AssessmentRules WHERE TaxYear =  " + year, con);
            truncate.ExecuteNonQuery();
        }



        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='AssessmentRules'", con);
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }

    [System.Web.Services.WebMethod]
    public static void truncate_Rules_dataB()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        con.Open();
        DateTime curretnDate = DateTime.Today; ; // random date
        string year = curretnDate.ToString("yyyy");
        //truncating items table to insert new data
        if (PAYEClass.URL_API.Contains("stage"))
        {
            SqlCommand truncate = new SqlCommand("DELETE FROM AssessmentRules WHERE TaxYear =  '2019'", con);

            truncate.ExecuteNonQuery();
        }
        else
        {
            SqlCommand truncate = new SqlCommand("DELETE FROM AssessmentRules WHERE TaxYear =  " + year, con);
            truncate.ExecuteNonQuery();
        }



        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='AssessmentRules'", con);
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }

    [System.Web.Services.WebMethod]
    public static void truncate_Rules_dataC()
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        con.Open();
        DateTime curretnDate = DateTime.Today; ; // random date
        string year = curretnDate.ToString("yyyy");
        //truncating items table to insert new data
        if (PAYEClass.URL_API.Contains("stage"))
        {
            SqlCommand truncate = new SqlCommand("DELETE FROM AssessmentRules WHERE TaxYear =  '2019'", con);

            truncate.ExecuteNonQuery();
        }
        else
        {
            SqlCommand truncate = new SqlCommand("DELETE FROM AssessmentRules WHERE TaxYear =  " + year, con);
            truncate.ExecuteNonQuery();
        }



        //updating items table last updated date
        SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='AssessmentRules'", con);
        update_tables_API_Updated.ExecuteNonQuery();
        con.Close();

    }


    public static string initialize_syncing_items(int pageNumber, int pageSize, int det)
    {

        //hitting login API to get token
        string token = PAYEClass.getToken();

        //starting recursive api hits
        if (det == 1)
            return start_Api_hits_items(pageNumber, token, pageSize, 1);

        else if (det == 2)
            return start_Api_hits_items(pageNumber, token, pageSize, 2);

        return start_Api_hits_items(pageNumber, token, pageSize, 3);




    }
    public static string initialize_syncing_Assets(int pageNumber, int pageSize, int det)
    {

        //hitting login API to get token
        string token = PAYEClass.getToken();
        if (det == 1)
        {
            return start_Api_hits_assets(pageNumber, token, pageSize, 1);
        }
        else if (det == 2)
        {
            return start_Api_hits_assets(pageNumber, token, pageSize, 2);

        }
        //starting recursive api hits
        return start_Api_hits_assets(pageNumber, token, pageSize, 3);
    }
    public static string initialize_syncing_profile(int pageNumber, int pageSize, int det)
    {

        //hitting login API to get token
        string token = PAYEClass.getToken();

        //starting recursive api hits
        if (det == 1)
            return start_Api_hits_profile(pageNumber, token, pageSize, 1);
        else if (det == 2)
            return start_Api_hits_profile(pageNumber, token, pageSize, 2);
        else
            return start_Api_hits_profile(pageNumber, token, pageSize, 3);

    }


    public static string initialize_syncing_Corporate(int pageNumber, int pageSize, int det)
    {

        //hitting login API to get token
        string token = PAYEClass.getToken();

        if (det == 1)
        {
            return start_Api_hits_corporate(pageNumber, token, pageSize, 1);
        }
        else if (det == 2)
        {
            return start_Api_hits_corporate(pageNumber, token, pageSize, 2);

        }

        return start_Api_hits_corporate(pageNumber, token, pageSize, 3);
    }


    public static string initialize_syncing_Individual(int pageNumber, int pageSize)
    {

        //hitting login API to get token
        string token = PAYEClass.getToken();

        //starting recursive api hits
        return start_Api_hits_individual(pageNumber, token, pageSize);




    }




    [System.Web.Services.WebMethod]
    public static string checkProgress(int pageNumber, int pageSize)
    {
        return initialize_syncing_items(pageNumber, pageSize, 1);
    }

    [System.Web.Services.WebMethod]
    public static string checkProgressB(int pageNumber, int pageSize)
    {
        return initialize_syncing_items(pageNumber, pageSize, 2);
    }
    [System.Web.Services.WebMethod]
    public static string checkProgressC(int pageNumber, int pageSize)
    {
        return initialize_syncing_items(pageNumber, pageSize, 3);
    }


    [System.Web.Services.WebMethod]
    public static string AssetcheckProgress(int pageNumber, int pageSize)
    {
        return initialize_syncing_Assets(pageNumber, pageSize, 1); ;
    }
    [System.Web.Services.WebMethod]
    public static string AssetcheckProgressB(int pageNumber, int pageSize)
    {
        return initialize_syncing_Assets(pageNumber, pageSize, 2); ;
    }
    [System.Web.Services.WebMethod]
    public static string AssetcheckProgressC(int pageNumber, int pageSize)
    {
        return initialize_syncing_Assets(pageNumber, pageSize, 3); ;
    }


    [System.Web.Services.WebMethod]
    public static string CorporatecheckProgress(int pageNumber, int pageSize)
    {
        return initialize_syncing_Corporate(pageNumber, pageSize, 1);
    }
    [System.Web.Services.WebMethod]
    public static string CorporatecheckProgressB(int pageNumber, int pageSize)
    {
        return initialize_syncing_Corporate(pageNumber, pageSize, 2);
    }
    [System.Web.Services.WebMethod]
    public static string CorporatecheckProgressC(int pageNumber, int pageSize)
    {
        return initialize_syncing_Corporate(pageNumber, pageSize, 3);
    }


    [System.Web.Services.WebMethod]
    public static string IndividualcheckProgress(int pageNumber, int pageSize)
    {
        return initialize_syncing_Individual(pageNumber, pageSize); ;
    }



    [System.Web.Services.WebMethod]
    public static string ProfilecheckProgress(int pageNumber, int pageSize)
    {
        return initialize_syncing_profile(pageNumber, pageSize, 1); ;
    }

    [System.Web.Services.WebMethod]
    public static string ProfilecheckProgressB(int pageNumber, int pageSize)
    {
        return initialize_syncing_profile(pageNumber, pageSize, 2); ;
    }

    [System.Web.Services.WebMethod]
    public static string ProfilecheckProgressC(int pageNumber, int pageSize)
    {
        return initialize_syncing_profile(pageNumber, pageSize, 3); ;
    }



    [System.Web.Services.WebMethod]
    public static string rulesCheckProgress(int pageNumber, int pageSize)
    {
        return initialize_rules_syncing_items(pageNumber, pageSize, 1); ;
    }

    [System.Web.Services.WebMethod]
    public static string rulesCheckProgressB(int pageNumber, int pageSize)
    {
        return initialize_rules_syncing_items(pageNumber, pageSize, 2); ;
    }

    [System.Web.Services.WebMethod]
    public static string rulesCheckProgressC(int pageNumber, int pageSize)
    {
        return initialize_rules_syncing_items(pageNumber, pageSize, 3); ;
    }

    public static string initialize_rules_syncing_items(int pageNumber, int pageSize, int det)
    {

        //hitting login API to get token
        string token = PAYEClass.getToken();

        //starting recursive api hits
        if (det == 1)
            return start_Api_hits_rules(pageNumber, token, pageSize, 1);
        else if (det == 2)
            return start_Api_hits_rules(pageNumber, token, pageSize, 2);
        else
            return start_Api_hits_rules(pageNumber, token, pageSize, 3);
    }


    public static string start_Api_hits_rules(int page_number, String token, int pageSize, int det)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);

        string URL = "";
        if (det == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_AssessmentRule?pageNumber=" + page_number + "&pageSize=" + pageSize;
        if (det == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_AssessmentRule?pageNumber=" + page_number + "&pageSize=" + pageSize;
        if (det == 3)
            URL = PAYEClass.URL_API + "SupplierData//PAYE_Collection_Multiple_Employees_BS_H_Z_AssessmentRule?pageNumber=" + page_number + "&pageSize=" + pageSize;

        MainResponseRules mainResponse = new MainResponseRules { };
        mainResponse.Result = new List<RulesResult>();
        using (var wc = new WebClientWithTimeout())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            // setting value in model

            string InsCompRes = wc.DownloadString(URL);

            MainResponseRules response = JsonConvert.DeserializeObject<MainResponseRules>(InsCompRes);
            List<RulesResult> listAssetItems = new List<RulesResult>();
            listAssetItems = response.Result;
            mainResponse.Message = response.Message;
            mainResponse.Success = response.Success;
            mainResponse.Result.AddRange(listAssetItems);

            //inserting data in DB
            string deserializeResponse = JsonConvert.SerializeObject(mainResponse);
            DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + deserializeResponse.Split('[')[1].Replace("}]", "").Replace(deserializeResponse.Split('[')[0].Replace("}]", ""), "") + "]", (typeof(DataTable)));
            System.Data.DataColumn newColumn = new System.Data.DataColumn("Active", typeof(System.String));
            newColumn.DefaultValue = "1";
            dt_list.Columns.Add(newColumn);
            bluck_inset_rules(dt_list);

            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();
            return headers;
        }
    }

    //check if it exist in db update else insert where taxpayerid, is same if assest assetid, profile profileid
    public static void bluck_inset_rules(DataTable table)
    {
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        con1.Open();
        foreach (DataRow row in table.Rows)
        {
            SqlCommand cmd = new SqlCommand("insert into AssessmentRules (AssessmentRuleID,AssessmentRuleCode,profileID,AssessmentRuleName" +
             ",RuleRunID,PaymentFrequencyID,AssessmentAmount,TaxYear,TaxMonth,PaymentOptionID,Active) values (" +
             "'" + row.Field<string>("AssessmentRuleID") + "'," +
             "'" + row.Field<string>("AssessmentRuleCode") + "'," +
             "'" + row.Field<string>("ProfileID") + "'," +
             "'" + row.Field<string>("AssessmentRuleName") + "'," +
             "'" + row.Field<string>("RuleRunID") + "'," +
             "'" + row.Field<string>("PaymentFrequencyID") + "'," +
             "'" + row.Field<string>("AssessmentAmount") + "'," +
             "'" + row.Field<string>("TaxYear") + "'," +
             "'" + row.Field<string>("TaxMonth") + "'," +
             "'" + row.Field<string>("PaymentOptionID") + "'," +
             "'" + row.Field<string>("Active") + "'" +
             ")", con1);

            cmd.ExecuteNonQuery();
        }

        SqlCommand cmd3 = new SqlCommand("select * from vw_Assessment_Rules", con1);

        SqlCommand cmd1 = new SqlCommand("truncate table Assessment_Rules_API", con1);
        cmd1.ExecuteNonQuery();

        SqlConnection co1 = new SqlConnection(PAYEClass.connection);
        using (SqlDataReader rdr = cmd3.ExecuteReader())
        {
            using (var bulkCopy = new SqlBulkCopy(co1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    bulkCopy.ColumnMappings.Add(rdr.GetName(i), rdr.GetName(i));
                }
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = "Assessment_Rules_API";
                bulkCopy.WriteToServer(rdr);
                //  showmsg(1, "items synced successfully");
            }
        }

        con1.Close();
    }

    public static string start_Api_hits_assets(int page_number, String token, int pageSize, int det)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = "";
        if (det == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_Asset?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else if (det == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_Asset?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_Asset?pageNumber=" + page_number + "&pageSize=" + pageSize;


        using (var wc = new WebClientWithTimeout())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            // setting value in model
            String InsCompRes = wc.DownloadString(URL);

            MainResponseAsset response = JsonConvert.DeserializeObject<MainResponseAsset>(InsCompRes);
            //inserting data in DB
            string deserializeResponse = JsonConvert.SerializeObject(response);
            DataTable dt_list = (DataTable)PAYEClass.ToDataTable(response.Result);
            bluck_inset_Assets(dt_list);


            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();


            return headers;


        }
    }
    public static string start_Api_hits_profile(int page_number, String token, int pageSize, int det)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = "";
        if (det == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_Profile?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else if (det == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_Profile?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else
            URL = URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_Profile?pageNumber=" + page_number + "&pageSize=" + pageSize;


        using (var wc = new WebClientWithTimeout())
        {


            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            // setting value in model
            String InsCompRes = wc.DownloadString(URL);
            ProfileResponse mainResponse = JsonConvert.DeserializeObject<ProfileResponse>(InsCompRes);
            DataTable dt_list = (DataTable)PAYEClass.ToDataTable(mainResponse.Result);

            string[] TobeDistinct = { "ProfileID", "ProfileReferenceNo", "ProfileDescription" };
            string[] distinct = { "ProfileID", "ProfileReferenceNo", "ProfileDescription" };

            DataTable dtDistinct_insert = GetDistinctRecords(dt_list, distinct);
            bluck_inset_Profile(dtDistinct_insert);
            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();


            return headers;


        }
    }

    public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }

    public static string start_Api_hits_corporate(int page_number, String token, int pageSize, int det)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = "";
        if (det == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_TaxPayer?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else if (det == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_TaxPayer?pageNumber=" + page_number + " &pageSize=" + pageSize;
        else
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_TaxPayer?pageNumber=" + page_number + "&pageSize=" + pageSize;


        using (var wc = new WebClientWithTimeout())
        {


            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            // setting value in model
            String InsCompRes = wc.DownloadString(URL);
            CorporateResponse mainResponse = JsonConvert.DeserializeObject<CorporateResponse>(InsCompRes);
            DataTable dt_list = (DataTable)PAYEClass.ToDataTable(mainResponse.Result);
            bluck_inset_Corporate(dt_list);
            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();


            return headers;


        }
    }


    public static string start_Api_hits_individual(int page_number, String token, int pageSize)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer?pageNumber=" + page_number + "&pageSize=" + pageSize;

        using (var wc = new WebClientWithTimeout())
        {


            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            // setting value in model
            String InsCompRes = wc.DownloadString(URL);
            IndividualResponse mainResponse = JsonConvert.DeserializeObject<IndividualResponse>(InsCompRes);
            DataTable dt_list = (DataTable)PAYEClass.ToDataTable(mainResponse.Result);
            bluck_inset_individual(dt_list);
            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();


            return headers;


        }
    }



    public static string start_Api_hits_items(int page_number, String token, int pageSize, int det)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = "";
        if (det == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_AssessmentItem?pageNumber=" + page_number + "&pageSize=" + pageSize;

        else if (det == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_AssessmentItem?pageNumber=" + page_number + "&pageSize=" + pageSize;

        else
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_AssessmentItem?pageNumber=" + page_number + "&pageSize=" + pageSize;


        MainResponse mainResponse = new MainResponse { };
        mainResponse.Result = new List<Result>();
        using (var wc = new WebClientWithTimeout())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            // setting value in model

            string InsCompRes = wc.DownloadString(URL);

            MainResponse response = JsonConvert.DeserializeObject<MainResponse>(InsCompRes);
            List<Result> listAssetItems = new List<Result>();
            listAssetItems = response.Result;
            mainResponse.Message = response.Message;
            mainResponse.Success = response.Success;
            mainResponse.Result.AddRange(listAssetItems);

            //inserting data in DB
            string deserializeResponse = JsonConvert.SerializeObject(mainResponse);
            DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + deserializeResponse.Split('[')[1].Replace("}]", "").Replace(deserializeResponse.Split('[')[0].Replace("}]", ""), "") + "]", (typeof(DataTable)));
            bluck_inset_items(dt_list);

            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();


            return headers;


        }
    }



    public static void bluck_inset_items(DataTable table)
    {

        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
        {
            // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
            foreach (DataColumn col in table.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = 600;
            bulkCopy.DestinationTableName = "Assessment_Item_API";
            bulkCopy.WriteToServer(table);
            //  showmsg(1, "items synced successfully");
        }
    }


    public static void bluck_inset_Assets(DataTable table)
    {
        string[] TobeDistinct = { "BusinessID", "BusinessRIN", "AssetTypeID", "AssetTypeName", "BusinessTypeID", "BusinessTypeName", "BusinessName", "LGAID", "LGAName", "BusinessCategoryID", "BusinessCategoryName", "BusinessSectorID", "BusinessSectorName", "BusinessSubSectorID", "BusinessSubSectorName", "BusinessStructureID", "BusinessStructureName", "BusinessOperationID", "BusinessOperationName", "SizeID", "SizeName", "ContactName", "BusinessNumber", "BusinessAddress" };
        DataTable dtDistinct = GetDistinctRecords(table, TobeDistinct);
        dtDistinct = RemoveDuplicateRows(dtDistinct, "BusinessID");
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        SqlConnection con2 = new SqlConnection(PAYEClass.connection);
        try
        {
            using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in dtDistinct.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;

                bulkCopy.DestinationTableName = "Businesses_API_Main";
                bulkCopy.WriteToServer(dtDistinct);
                //  showmsg(1, "items synced successfully");
            }
        }
        catch (Exception e)
        {
            //dbug here if assets not being saved
            String s = e.Message;
        }
        try
        {
            string TaxPayerTypeId, TaxPayerName, TaxPayerTypeName, TaxPayerId, TaxPayerRinnumber, TaxPayerEmailAddress,
                TaxPayerMobileNumber, AssetTypeId, AssetTypeName, AssetId, AssetLga, AssetRin, AssetName;


            string[] TobeDistinct2 = { "TaxPayerTypeId", "TaxPayerName", "TaxPayerTypeName", "TaxPayerId", "TaxPayerRinnumber",
                "TaxPayerEmailAddress", "TaxPayerMobileNumber", "AssetTypeId", "AssetTypeName", "AssetId", "AssetLga", "AssetRin", "AssetName" };
            DataTable dtDistinct2 = GetDistinctRecords(table, TobeDistinct);

            dtDistinct2 = RemoveDuplicateRows(dtDistinct2, "TaxPayerId");

            //for (int i = 0; i < dtDistinct2.Columns.Count; i++)
            //{

            //    DataRow item = table.Rows[i];
            //    var dr = table.Rows[i].ItemArray;
            //    TaxPayerTypeId = item["TaxPayerTypeID"].ToString();
            //    TaxPayerId = item["TaxPayerID"].ToString();
            //    TaxPayerTypeName = item["TaxPayerTypeName"].ToString();
            //    TaxPayerName = item["TaxPayerName"].ToString();
            //    TaxPayerRinnumber = item["TaxPayerRIN"].ToString();
            //    TaxPayerMobileNumber = item["BusinessNumber"].ToString();
            //    AssetTypeId = item["AssetTypeId"].ToString();
            //    AssetTypeName = item["AssetTypeName"].ToString();
            //    AssetId = item["BusinessID"].ToString();
            //    TaxPayerEmailAddress = item["EmailAddress"].ToString();
            //    AssetLga = item["LGAName"].ToString();
            //    AssetRin = item["BusinessRIN"].ToString();
            //    AssetName = item["BusinessName"].ToString();
            //    int totalRow = 0;


            //    dtDistinct2.Rows.Add(item);
            //}
            using (var bulkCopy2 = new SqlBulkCopy(con2.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in dtDistinct2.Columns)
                {
                    bulkCopy2.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy2.BulkCopyTimeout = 600;

                bulkCopy2.DestinationTableName = "AssetTaxPayerDetails_API";
                bulkCopy2.WriteToServer(dtDistinct2);
            }
        }
        catch (Exception)
        {

            throw;
        }


    }

    public static void bluck_inset_Profile(DataTable table)
    {

        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        Array.ForEach<DataRow>(table.Select("ProfileID IS NULL"), row => row.Delete());
        Array.ForEach<DataRow>(table.Select("ProfileReferenceNo IS NULL"), row => row.Delete());
        Array.ForEach<DataRow>(table.Select("ProfileDescription IS NULL"), row => row.Delete());
        using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
        {
            //con.Open();
            // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
            foreach (DataColumn col in table.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = 600;
            bulkCopy.DestinationTableName = "Profiles_API";
            bulkCopy.WriteToServer(table);
        }

    }


    public static void bluck_inset_individual(DataTable table)
    {
        Array.ForEach<DataRow>(table.Select("TaxPayerTypeID IS NULL"), row => row.Delete());
        Array.ForEach<DataRow>(table.Select("TaxPayerID IS NULL"), row => row.Delete());
        Array.ForEach<DataRow>(table.Select("TaxPayerRIN IS NULL"), row => row.Delete());
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
        {
            //con.Open();
            // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
            foreach (DataColumn col in table.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = 1600;
            bulkCopy.DestinationTableName = "Individuals_API";
            bulkCopy.WriteToServer(table);
        }

    }





    public static void bluck_inset_Corporate(DataTable table)
    {
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
        {

            var list2 = table.Rows;

            Array.ForEach<DataRow>(table.Select("TaxPayerTypeID IS NULL"), row => row.Delete());
            Array.ForEach<DataRow>(table.Select("TaxPayerID IS NULL"), row => row.Delete());

            string tx;
            string tx2, TaxPayerName, TaxPayerTypeName, TaxPayerRIN, MobileNumber, ContactAddress, EmailAddress, TIN, TaxOffice, CompanyListID;
            con1.Open();
            for (int i = 0; i < table.Columns.Count; i++)
            {

                DataRow item = table.Rows[i];
                var dr = table.Rows[i].ItemArray;
                tx = item["TaxPayerTypeID"].ToString();
                tx2 = item["TaxPayerID"].ToString();
                TaxPayerTypeName = item["TaxPayerTypeName"].ToString();
                TaxPayerName = item["TaxPayerName"].ToString();
                TaxPayerRIN = item["TaxPayerRIN"].ToString();
                MobileNumber = item["MobileNumber"].ToString();
                ContactAddress = item["ContactAddress"].ToString();
                EmailAddress = item["EmailAddress"].ToString();
                TIN = item["TIN"].ToString();
                TaxOffice = item["TaxOffice"].ToString();
                int totalRow = 0;
                SqlCommand list = new SqlCommand("select * from CompanyList_API where TaxPayerID =" + tx2 + " ;select @@ROWCOUNT;", con1);
                //var listCount = list.ExecuteScalar();


                list.ExecuteNonQuery();

                using (var reader = list.ExecuteReader())
                {

                    reader.NextResult();
                    if (reader.Read())
                    {
                        totalRow = (int)reader[0];
                    }
                }
                if (totalRow > 0)
                {

                    //SqlCommand Updated = new SqlCommand("update CompanyList_API set TaxPayerID =" + tx2 + ",TaxPayerTypeID="+tx + ",TaxPayerTypeName=" + TaxPayerTypeName + ",TaxPayerName=" +'+ TaxPayerName + '+ ",TaxPayerRIN=" + TaxPayerRIN + ",MobileNumber=" + MobileNumber + ",ContactAddress=" + ContactAddress + ",EmailAddress=" + EmailAddress + ",TIN=" + TIN + ",TaxOffice=" + TaxOffice + " where TaxPayerID =" + tx2 , con1);
                    //Updated.ExecuteReader();
                }
                else
                {
                    DataTable dt = new DataTable();


                    dt.Rows.Add(item);
                    foreach (DataColumn col in table.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }

                    bulkCopy.BulkCopyTimeout = 6000;
                    bulkCopy.DestinationTableName = "CompanyList_API";
                    bulkCopy.WriteToServer(dt);
                }

            }
            // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
            //foreach (DataColumn col in table.Columns)
            //{
            //    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            //}

            //bulkCopy.BulkCopyTimeout = 6000;
            //bulkCopy.DestinationTableName = "CompanyList_API";
            //bulkCopy.WriteToServer(table);
        }

    }



    public void insert_Individuals(DataTable table)
    {
        try
        {

            SqlConnection con1 = new SqlConnection(PAYEClass.connection);

            SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Individuals_API", con);
            con.Open();
            truncate.ExecuteNonQuery();
            con.Close();

            SqlCommand update_tables_API_Updated = new SqlCommand("update tables_API_Updated set LastUpdatedOn=getdate() where TableName='Individuals_API'", con);
            con.Open();
            update_tables_API_Updated.ExecuteNonQuery();
            con.Close();

            Array.ForEach<DataRow>(table.Select("TaxPayerTypeID IS NULL"), row => row.Delete());
            Array.ForEach<DataRow>(table.Select("TaxPayerID IS NULL"), row => row.Delete());
            Array.ForEach<DataRow>(table.Select("TaxPayerRIN IS NULL"), row => row.Delete());

            using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                //con.Open();
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 1600;
                bulkCopy.DestinationTableName = "Individuals_API";
                bulkCopy.WriteToServer(table);
            }

            //DataTable dt_fetch = new DataTable();
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    SqlDataAdapter Adp = new SqlDataAdapter("SELECT * from Individuals_API where TaxPayerId=" + table.Rows[i]["TaxPayerId"].ToString() + " and TaxPayerTypeID=" + table.Rows[i]["TaxPayerTypeID"].ToString() + " and TaxPayerRIN='" + table.Rows[i]["TaxPayerRIN"].ToString() + "' and TIN=" + table.Rows[i]["TIN"].ToString() + "", con);
            //    Adp.Fill(dt_fetch);

            //    if (dt_fetch.Rows.Count == 0)
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("insert into Individuals_API values('" + table.Rows[i]["TaxPayerID"].ToString() + "','" + table.Rows[i]["TaxPayerTypeID"].ToString().Replace("'", "''") + "','" + table.Rows[i]["TaxPayerTypeName"].ToString() + "','" + table.Rows[i]["TaxPayerName"].ToString() + "','" + table.Rows[i]["TaxPayerRIN"].ToString() + "','" + table.Rows[i]["MobileNumber"].ToString() + "'," +
            //         "'" + table.Rows[i]["ContactAddress"].ToString().Replace("'", "''") + "','" + table.Rows[i]["EmailAddress"].ToString().Replace("'", "''") + "','" + table.Rows[i]["TIN"].ToString().Replace("'", "''") + "','" + table.Rows[i]["TaxOffice"].ToString() + "');", con);
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}


            showmsg(1, "Individuals Synced Successfully");
        }
        catch (Exception eI)
        {
            showmsg(2, "Error Occured. Contact to Administrator.");
        }
    }
}