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
using DocumentFormat.OpenXml.Wordprocessing;
using System.Reflection;
using DocumentFormat.OpenXml.Spreadsheet;

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
    public class BusinessesApiMain
    {
        public int Id { get; set; }
        public long BusinessID { get; set; }
        public string BusinessRIN { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public int BusinessTypeID { get; set; }
        public string BusinessTypeName { get; set; }
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
        public int ApiId { get; set; }
        public DateTime DateCreated { get; set; }
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
            wr.Timeout = 6000000; // timeout in milliseconds (ms)
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

    public class MainResponseAssetTaxPayerDetailsApi
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public List<AssetTaxPayerDetailsApi> Result { get; set; }
    }

    public class NewAssetTaxPayerDetailsApi
    {
        public int TPAID { get; set; }
        public int Id { get; set; }
        public int TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public int TaxPayerID { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerRINNumber { get; set; }
        public string TaxPayerEmailAddress { get; set; }
        public string TaxPayerMobileNumber { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }

        public int AssetID { get; set; }
        public string AssetLGA { get; set; }
        public string AssetRIN { get; set; }
        public string AssetName { get; set; }

        public int ApiId { get; set; }
        public int TaxPayerRoleID { get; set; }
        public string TaxPayerRoleName { get; set; }
        public string BuildingUnitID { get; set; }
        public string UnitNumber { get; set; }
        public string Active { get; set; }
        public string ActiveText { get; set; }
        public DateTime DateCreated { get; set; }
        //public int Id { get; set; }


        ///
       // [NotMapped]
        //public string Year { get; set; }
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

    public partial class AssetTaxPayerDetailsApi
    {
        public int TPAID { get; set; }
        public int TaxPayerTypeID { get; set; }
        public string TaxPayerTypeName { get; set; }
        public int TaxPayerID { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerRINNumber { get; set; }
        public string TaxPayerEmailAddress { get; set; }
        public string TaxPayerMobileNumber { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public int TaxPayerRoleID { get; set; }
        public string TaxPayerRoleName { get; set; }
        public int AssetID { get; set; }
        public string AssetLGA { get; set; }
        public string AssetRIN { get; set; }
        public string AssetName { get; set; }
        public string BuildingUnitID { get; set; }
        public string UnitNumber { get; set; }
        public string Active { get; set; }
        public string ActiveText { get; set; }
        public DateTime DateCreated { get; set; }
        public int Id { get; set; }
        public int ApiId { get; set; }
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

        foreach (DataRow row in table.Rows)
        {
            //""
            //con1.Open();
            string qry = "insert into assessment_rules(rule_code,profile,assessment_rule_name,rule_run,frequency,assessment_amount,tax_year,payment_options,AssessmentRuleId" +
         ") values (" +
             "'" + row.Field<string>("AssessmentRuleCode") + "'," +
             "'" + row.Field<string>("ProfileID") + "'," +
             "'" + row.Field<string>("AssessmentRuleName") + "'," +
             "'" + row.Field<string>("RuleRunID") + "'," +
             "'" + row.Field<string>("PaymentFrequencyID") + "'," +
             "'" + row.Field<string>("AssessmentAmount") + "'," +
             "'" + row.Field<string>("TaxYear") + "'," +
             //"'" + row.Field<string>("TaxYear") + "'," +
             "'" + row.Field<string>("PaymentOptionID") + "'," +
             "'" + row.Field<string>("AssessmentRuleID") + "'" +
             ")";
            SqlCommand cmd = new SqlCommand(qry, con1);
            con1.Open();
            int status = cmd.ExecuteNonQuery();
            con1.Close();
        }

        //SqlCommand cmd3 = new SqlCommand("select * from vw_Assessment_Rules", con1);

        // SqlCommand cmd1 = new SqlCommand("truncate table Assessment_Rules_API", con1);
        // cmd1.ExecuteNonQuery();

        // SqlConnection co1 = new SqlConnection(PAYEClass.connection);
        // SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        //using (var bulkCopy = new SqlBulkCopy(PAYEClass.connection, SqlBulkCopyOptions.KeepIdentity))
        //{
        //    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
        //    }
        //    bulkCopy.BulkCopyTimeout = 600;
        //    bulkCopy.DestinationTableName = "Assessment_Rules";
        //    bulkCopy.WriteToServer(table);
        //    //  showmsg(1, "items synced successfully");
        //}
        //using (var bulkCopy = new SqlBulkCopy(co1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
        //{
        //    // my DataTable column names match my SQL Column names, so I simply made this loop.
        //    However if your column names don't match,
        //    // just pass in which datatable name matches the SQL column name in Column Mappings
        //    for (int i = 0; i < rdr.FieldCount; i++)
        //    {
        //        bulkCopy.ColumnMappings.Add(rdr.GetName(i), rdr.GetName(i));
        //    }
        //    bulkCopy.BulkCopyTimeout = 600;
        //    bulkCopy.DestinationTableName = "Assessment_Rules_API";
        //    bulkCopy.WriteToServer(rdr);
        //    //  showmsg(1, "items synced successfully");
        //}

        // con1.Close();
    }

    public static string start_Api_hits_assets(int page_number, String token, int pageSize, int ApiId)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = "";
        if (ApiId == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_Asset?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else if (ApiId == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_Asset?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_Asset?pageNumber=" + page_number + "&pageSize=" + 10000;

        MainResponseAsset mainResponse = new MainResponseAsset { };
        mainResponse.Result = new List<AssestResult>();

        MainResponseAssetTaxPayerDetailsApi mainResponseAssetDetail = new MainResponseAssetTaxPayerDetailsApi { };
        mainResponseAssetDetail.Result = new List<AssetTaxPayerDetailsApi>();

        using (var wc = new WebClientWithTimeout())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            String InsCompRes = wc.DownloadString(URL);

            MainResponseAsset response = JsonConvert.DeserializeObject<MainResponseAsset>(InsCompRes);

            List<AssestResult> lisCorporates = new List<AssestResult>();
            lisCorporates = response.Result;
            var time = DateTime.Now.Date.ToString("yy-MM-dd").Replace("-", "");
            // string all = response.Result.ToString();
            LogToText2(InsCompRes.ToString(), "RecordPulledToday+ " + time + "", "PulledRecords/");

            //SavePullTracker(URL, all);
            mainResponse.Message = response.Message;
            mainResponse.Success = response.Success;
            mainResponse.Result.AddRange(lisCorporates);
            var retVal = mainResponse.Result.ToList();
            DataTable dt_lists = Complier(retVal, ApiId);

            //checking if next page is available

            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();
            if (nextpage != "Yes")
                AssetCount = 0;

            return headers;


        }
    }
    public class user
    {
        public string Lastid { get; set; }
    }
    public class user2
    {
        public string Lastid { get; set; }
    }

    public static void LogToText2(string message = "", string fileName = "", string path = "")
    {

        StreamWriter sw = null;
        string _serverPath = (string)AppDomain.CurrentDomain.GetData("ContentRootPath") ?? "C:\\Inetpub\\vhosts\\eirs.gov.ng\\pinscher.eirs.gov.ng\\spike\\";
        try
        {
            string filePath = Path.Combine(_serverPath, path);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = filePath + (string.IsNullOrWhiteSpace(fileName) ? DateTime.Today.ToString("dd-MMM-yyyy") : fileName) + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            sw = File.AppendText(filePath);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }
        catch (Exception e)
        {
            e.ToString();
        }
    }

    private static int AssetCount = 0;
    private static int AssetCount2 = 0;


    public static DataTable Complier(List<AssestResult> retVal, int caler)
    {
        if (AssetCount != AssetCount2)
        {
            AssetCount = 0;
            AssetCount2 = 0;
        }
        SqlConnection con2 = new SqlConnection(PAYEClass.connection);
        if (AssetCount < 1)
        {
            con2.Open();
            SqlCommand comm = new SqlCommand("Delete from Businesses_API_Main where ApiId = " + caler, con2);
            comm.ExecuteNonQuery();
            con2.Close();
        }

        if (AssetCount2 < 1)
        {
            con2.Open();
            SqlCommand comm1 = new SqlCommand("Delete from AssetTaxPayerDetails_API where ApiId = " + caler, con2);
            comm1.ExecuteNonQuery();
            con2.Close();
        }
        int lastId = 0;
        int asslastId = 0;
        List<user> Users = new List<user>();
        List<user2> Users2 = new List<user2>();
        using (SqlConnection con1 = new SqlConnection(PAYEClass.connection))
        {
            con1.Open();
            var query = "Select MAX(Id) Id  from Businesses_API_Main";
            var query2 = "Select Max(Id) Id from AssetTaxPayerDetails_API";


            DataTable responseDt = new DataTable();
            DataTable responseDt2 = new DataTable();
            // var query = "SELECT  A.AssetID,B.AssetName, A.ProfileID,A.AssessmentRuleID,A.TaxYear,A.AssessmentItemID,A.Status,A.TaxPayerID,A.TaxPayerTypeID,A.AssetID,A.AssetTypeID,AssessmentRuleID,A.TaxBaseAmount,A.AssessmentItemName,A.AssessmentRuleName,A.AssetRin,A.TaxPayerRin FROM PreAssessmentRDM A left join AssetTaxPayerDetails_API B on A.AssetID = B.AssetID WHERE A.AssetRin = '" + companyRIN + "' And Status is null order by a.TaxYear desc, a.AssessmentItemID";

            SqlCommand cmd = new SqlCommand(query, con1);
            SqlCommand cmd2 = new SqlCommand(query2, con1);

            // con.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.CommandTimeout = PAYEClass.defaultTimeout;
                adapter.Fill(responseDt);
            }
            using (SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2))
            {
                cmd2.CommandTimeout = PAYEClass.defaultTimeout;
                adapter2.Fill(responseDt2);
            }

            con1.Close();
            con1.Dispose();
            foreach (DataRow dr in responseDt.Rows)  // dt is a DataTable
            {
                user user = new user { Lastid = dr["Id"].ToString() };
                Users.Add(user);
            }
            foreach (DataRow dr in responseDt2.Rows)  // dt is a DataTable
            {
                user2 user = new user2 { Lastid = dr["Id"].ToString() };
                Users2.Add(user);
            }
        }
        if (Users.Count > 0)
        {
            var ret = Users.FirstOrDefault();
            if (ret.Lastid != "")
            {
                lastId = Convert.ToInt32(ret.Lastid);
            }
            else
            {
                lastId = 0;
            }
        }
        else
        {
            lastId = 0;

        }
        if (Users2.Count > 0)
        {
            var ret = Users2.FirstOrDefault();
            //asslastId = Convert.ToInt32(ret.Lastid);
            if (ret.Lastid != "")
            {
                asslastId = Convert.ToInt32(ret.Lastid);
            }
            else
            {
                asslastId = 0;
            }
        }
        else
        {
            asslastId = 0;

        }
        List<BusinessesApiMain> bsApi = new List<BusinessesApiMain>();
        List<NewAssetTaxPayerDetailsApi> atpApi = new List<NewAssetTaxPayerDetailsApi>();
        foreach (var ret in retVal)
        {
            if(ret.TaxPayerName.Contains("WESTVIEW"))
            {

            }
            var cos = new BusinessesApiMain()
            {
                Id = lastId + 1,
                BusinessID = ret.BusinessID,
                BusinessRIN = ret.BusinessRIN,
                AssetTypeID = ret.AssetTypeID,
                AssetTypeName = ret.AssetTypeName,
                BusinessTypeID = ret.BusinessTypeID,
                BusinessTypeName = ret.BusinessTypeName,
                BusinessName = ret.BusinessName,
                LGAID = ret.LGAID,
                LGAName = ret.LGAName,
                DateCreated = DateTime.Now,
                BusinessCategoryID = ret.BusinessCategoryID,
                BusinessCategoryName = ret.BusinessCategoryName,
                BusinessSectorID = ret.BusinessSectorID,
                BusinessSectorName = ret.BusinessSectorName,
                BusinessSubSectorID = ret.BusinessSubSectorID,
                BusinessSubSectorName = ret.BusinessSubSectorName,
                BusinessOperationID = ret.BusinessOperationID,
                BusinessOperationName = ret.BusinessOperationName,
                SizeID = ret.SizeID,
                BusinessStructureID = ret.BusinessStructureID,
                BusinessStructureName = ret.BusinessStructureName,
                SizeName = ret.SizeName,
                ContactName = ret.ContactName,
                BusinessNumber = ret.BusinessNumber,
                BusinessAddress = ret.BusinessAddress,
                ApiId = caler
            };
            bsApi.Add(cos);
            lastId++;
            var cosMap = new NewAssetTaxPayerDetailsApi
            {
                //Id=0,

                Id = asslastId + 1,
                TPAID = 0,
                TaxPayerRoleID = 0,
                TaxPayerRoleName = "",
                BuildingUnitID = "",
                UnitNumber = "",
                Active = "",
                ActiveText = "",
                DateCreated = DateTime.Now,
                TaxPayerTypeID = ret.TaxPayerTypeID,
                TaxPayerTypeName = ret.TaxPayerTypeName,
                TaxPayerName = ret.TaxPayerName,
                TaxPayerID = ret.TaxPayerID,
                TaxPayerRINNumber = ret.TaxPayerRIN,
                TaxPayerEmailAddress = "",
                TaxPayerMobileNumber = ret.BusinessNumber,
                AssetTypeID = ret.AssetTypeID,
                AssetTypeName = ret.AssetTypeName,
                AssetID = ret.BusinessID,
                AssetLGA = ret.LGAName,
                AssetName = ret.BusinessName,
                AssetRIN = ret.BusinessRIN,
                ApiId = caler

            };
            atpApi.Add(cosMap);
            asslastId++;
        }
        //DataTable dataTable = ListToDataTable(bsApi);
        DataTable dataTable = ToDataTable(bsApi);
        DataTable dataTable2 = ToDataTable(atpApi);
       // DataTable dataTable2 = ListToDataTable(atpApi);
        bluck_inset_Assets(dataTable, caler);
        bluck_inset_Assets2(dataTable2, caler);
        AssetCount++;
        AssetCount2++;
        return dataTable2;
    }

    public static bool SavePullTracker(string url, string records)
    {
        // SqlConnection con1 = new SqlConnection(PAYEClass.connection);

        SqlParameter[] pram = new SqlParameter[1];
        //@url,@record
        pram[0] = new SqlParameter("@url", url);
        pram[1] = new SqlParameter("@record", records);

        pram[1].Direction = System.Data.ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "spSavePullTracker", pram);
        return true;
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

    public static string start_Api_hits_corporate(int page_number, String token, int pageSize, int ApiId)
    {
        SqlConnection con = new SqlConnection(PAYEClass.connection);
        string URL = "";
        if (ApiId == 1)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_TaxPayer?pageNumber=" + page_number + "&pageSize=" + pageSize;
        else if (ApiId == 2)
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_G_TaxPayer?pageNumber=" + page_number + " &pageSize=" + pageSize;
        else
            URL = PAYEClass.URL_API + "SupplierData/PAYE_Collection_Multiple_Employees_BS_H_Z_TaxPayer?pageNumber=" + page_number + "&pageSize=" + pageSize;


        CorporateResponse mainResponse = new CorporateResponse { };
        mainResponse.Result = new List<ResultCorporate>();
        using (var wc = new WebClientWithTimeout())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;

            string bearer = wc.Headers[HttpRequestHeader.Authorization];
            // setting value in model
            String InsCompRes = wc.DownloadString(URL);
            // DataTable dt_list = (DataTable)PAYEClass.ToDataTable(mainResponse.Result);

            CorporateResponse response = JsonConvert.DeserializeObject<CorporateResponse>(InsCompRes);
            List<ResultCorporate> lisCorporates = new List<ResultCorporate>();
            lisCorporates = response.Result;
            mainResponse.Message = response.Message;
            mainResponse.Success = response.Success;
            mainResponse.Result.AddRange(lisCorporates);

            DataTable dt_lists = (DataTable)PAYEClass.ToDataTable(response.Result);
            string[] distinct = { "TaxPayerID", "TaxPayerTypeID", "TaxPayerTypeName", "TaxPayerName", "TaxPayerRIN", "MobileNumber", "ContactAddress", "EmailAddress", "TIN", "TaxOffice" };
            DataTable dtDistinct_insert = GetDistinctRecords(dt_lists, distinct);

            //inserting data in DB
            string deserializeResponse = JsonConvert.SerializeObject(dtDistinct_insert);
            DataTable dt_list = (DataTable)JsonConvert.DeserializeObject(deserializeResponse, (typeof(DataTable)));

            System.Data.DataColumn newColumn = new System.Data.DataColumn("ApiId", typeof(System.Int32));
            newColumn.DefaultValue = ApiId;
            dt_list.Columns.Add(newColumn);


            bluck_inset_Corporate(dt_list, ApiId);

            //checking if next page is available
            string headers = wc.ResponseHeaders.GetValues("Paging-Headers")[0].ToString();

            DataTable dttt = (DataTable)JsonConvert.DeserializeObject("[" + headers + "]", (typeof(DataTable)));

            string nextpage = dttt.Rows[0]["nextPage"].ToString();
            if (nextpage != "Yes")
                CorporateCount = 0;

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

    public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);
        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }

    public static DataTable ListToDataTable<T>(IList<T> data)
    {
        DataTable table = new DataTable();

        //special handling for value types and string
        if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
        {

            DataColumn dc = new DataColumn("Value", typeof(T));
            table.Columns.Add(dc);
            foreach (T item in data)
            {
                DataRow dr = table.NewRow();
                dr[0] = item;
                table.Rows.Add(dr);
            }
        }
        else
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    try
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    catch (Exception ex)
                    {
                        row[prop.Name] = DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }
        }
        return table;
    }

    public static void bluck_inset_Assets(DataTable table, int ApiId)
    {
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        try
        {

            SqlConnection con2 = new SqlConnection(PAYEClass.connection);
            //con2.Open();
            using (var bulkCopy = new SqlBulkCopy(con2.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                //to get the whole table columns
                //using (SqlCommand command = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'Businesses_API_Main'", con2))
                //{
                //    DataTable columnNames = new DataTable();
                //    columnNames.Load(command.ExecuteReader());

                //    int i = 0;
                //    foreach (DataColumn column in table.Columns)
                //    {
                //        string columnNameInDB = columnNames.Rows[i++]["COLUMN_NAME"].ToString();
                //        Console.WriteLine("{0}\t{1}\t{2}", column.ColumnName, columnNameInDB, columnNameInDB == column.ColumnName);
                //    }
                //}

                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = "Businesses_API_Main";
                bulkCopy.WriteToServer(table);
                //  showmsg(1, "items synced successfully");
            }

        }
        catch (Exception ex) { }
        finally { con1.Close(); }


    }
    //private static int AssetCount2 = 0;
    public static void bluck_inset_Assets2(DataTable table, int ApiId)
    {
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);
        try
        {
            SqlConnection con2 = new SqlConnection(PAYEClass.connection);
            //con2.Open();
            using (var bulkCopy = new SqlBulkCopy(con2.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = "AssetTaxPayerDetails_API";
                bulkCopy.WriteToServer(table);
                //  showmsg(1, "items synced successfully");
            }

        }
        catch (Exception ex) { }
        finally { con1.Close(); }
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




    private static int CorporateCount = 0;
    public static void bluck_inset_Corporate(DataTable table, int ApiId)
    {
        Array.ForEach<DataRow>(table.Select("TaxPayerTypeID IS NULL"), row => row.Delete());
        Array.ForEach<DataRow>(table.Select("TaxPayerID IS NULL"), row => row.Delete());
        SqlConnection con1 = new SqlConnection(PAYEClass.connection);

        using (var bulkCopy = new SqlBulkCopy(con1.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
        {

            if (CorporateCount < 1)
            {
                con1.Open();
                SqlCommand comm = new SqlCommand("Delete from CompanyList_API where ApiId = " + ApiId, con1);
                comm.ExecuteNonQuery();
                con1.Close();
            }

            CorporateCount++;

            // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings


            con1.Open();
            foreach (DataColumn col in table.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = 600;
            bulkCopy.DestinationTableName = "CompanyList_API";
            try
            {
                bulkCopy.WriteToServer(table);
            }
            catch (Exception ex) { }
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