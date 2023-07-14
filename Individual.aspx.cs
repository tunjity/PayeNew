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

public partial class Individual : System.Web.UI.Page
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

            string token = PAYEClass.getToken();
            /**************************************************************/
            string a = get_json();



            string URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";
            URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";

            // URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_TaxPayer";
            // URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_Asset";
            string myParameters1 = "";
            string saveLoc = @"/project1/home_image";
            string InsCompRes = "";
            //using (var wc = new WebClient())
            //{
            //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //    wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + TokenObj.access_token;

            //    string path = HttpContext.Current.Server.MapPath("~/App_Code/Individuals.txt");
            //    //path = "ftp://pinscher.eirsautomation.xyz/App_Code/Individuals.txt";
            //    if (!File.Exists(path))
            //    {
            //        File.Create(path).Dispose();

            //        InsCompRes = wc.DownloadString(URI1);

            //        TextWriter tw = new StreamWriter(path);
            //        tw.WriteLine(InsCompRes);
            //        tw.Close();
            //    }
            //    else if (File.Exists(path))
            //    {
            //        string text = File.ReadAllText(path, Encoding.UTF8);                    
            //        InsCompRes = text;
            //    }


            //}


            InsCompRes = a;
            DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + InsCompRes.Split('[')[2].Replace("}]", "") + "]", (typeof(DataTable)));
            insert(dt_list);

            //SqlDataAdapter Adp = new SqlDataAdapter("select * from Individuals_API", con);
            //DataTable Dt_database = new DataTable();
            //Adp.Fill(Dt_database);

            Session["dt_ind"] = dt_list;
            grd_ind.DataSource = dt_list;
            grd_ind.DataBind();

            int pagesize = grd_ind.Rows.Count;
            int from_pg = 1;
            int to = grd_ind.Rows.Count;
            int totalcount = dt_list.Rows.Count;
            lblpagefrom.Text = from_pg.ToString();
            lblpageto.Text = (from_pg + pagesize - 1).ToString();
            lbltoal.Text = totalcount.ToString();

            if (totalcount < grd_ind.PageSize)
                div_paging.Style.Add("margin-top", "0px");
            else
                div_paging.Style.Add("margin-top", "-60px");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd_ind.PageIndex = e.NewPageIndex;
        grd_ind.DataSource = Session["dt_ind"];

        grd_ind.DataBind();

        if (e.NewPageIndex + 1 == 1)
        {
            lblpagefrom.Text = "1";
        }
        else
        {
            lblpagefrom.Text = ((grd_ind.Rows.Count * e.NewPageIndex) + 1).ToString();
        }

        lblpageto.Text = ((e.NewPageIndex + 1) * grd_ind.Rows.Count).ToString();

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        DataTable dt_list_s = new DataTable();
        dt_list_s = (DataTable)Session["dt_ind"];
        // DataRow[] filteredRows = dt_list_s.Select("TaxPayerRIN LIKE '" + txt_RIN.Text + "'");
        DataTable dt_filtered = new DataTable();
        DataView dt_v = dt_list_s.DefaultView;
        if (txt_RIN.Text != "")
            dt_v.RowFilter = "TaxPayerRIN='" + txt_RIN.Text + "'";

        if (txt_name.Text != "")
            dt_v.RowFilter = "TaxPayerName='" + txt_name.Text + "'";

        if (txt_mobile.Text != "")
            dt_v.RowFilter = "MobileNumber='" + txt_mobile.Text + "'";

        grd_ind.DataSource = dt_v;
        grd_ind.DataBind();

        int pagesize = grd_ind.Rows.Count;
        int from_pg = 1;
        int to = grd_ind.Rows.Count;
        int totalcount = dt_v.Count;
        lblpagefrom.Text = from_pg.ToString();
        lblpageto.Text = (from_pg + pagesize - 1).ToString();
        lbltoal.Text = totalcount.ToString();

        if (totalcount < grd_ind.PageSize)
            div_paging.Style.Add("margin-top", "0px");
        else
            div_paging.Style.Add("margin-top", "-60px");
    }

    public string get_json()
    {
        WebClient request = new WebClient();

        string url = PAYEClass.uploadurltxtfile + "Individuals.txt";
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
        URI1 = PAYEClass.URL_API + "SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";

       // URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Collection_Multiple_Employees_BS_A_F_TaxPayer";
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




        string url = PAYEClass.uploadurltxtfile + "Individuals.txt";
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


    public void insert(DataTable table)
    {
        try
        {
            if (table.Rows.Count > 0)
            {

                SqlConnection con1 = new SqlConnection(PAYEClass.connection);
                SqlConnection con = new SqlConnection(PAYEClass.connection);
                SqlCommand truncate = new SqlCommand("TRUNCATE TABLE Individuals_API", con);
                con.Open();
                truncate.ExecuteNonQuery();
                con.Close();

                Array.ForEach<DataRow>(table.Select("TaxPayerRIN IS NULL"), row => row.Delete());
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
                    bulkCopy.DestinationTableName = "Individuals_API";
                    bulkCopy.WriteToServer(table);
                }
            }
        }
        catch (Exception e)
        {
        }
    }
}