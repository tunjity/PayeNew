﻿using System;
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

public partial class IndividualList : System.Web.UI.Page
{
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

    SqlConnection con = new SqlConnection(PAYEClass.connection);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /***************************************************************/

            // string URI = "https://stage-api.eirsautomation.xyz/Account/Login";
            // // string myParameters = "UserName=Contec&Password=3Uhf7j~4&grant_type=password";
            // string user = "Contec";
            // string myParameters = "UserName=" + user + "&Password=Znal821*&grant_type=password";
            // string BearerToken = "";
            // using (WebClient wc = new WebClient())
            // {
            //     wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //     BearerToken = wc.UploadString(URI, myParameters);
            // }         

            // Token TokenObj = JsonConvert.DeserializeObject<Token>(BearerToken);
            // /**************************************************************/
            //// string a = get_json();

            // DataTable dt_updated = new DataTable();
            // SqlDataAdapter Adp_updated = new SqlDataAdapter("SELECT DATEDIFF(minute, CAST(lastUpdatedOn as DATETIME), GETDATE()) as diff, frequency FROM tables_API_Updated where TableName='Individuals_API'", con);
            // // DataTable Dt_database = new DataTable();
            // Adp_updated.Fill(dt_updated);
            // string a = "";
            // if (Convert.ToInt32(dt_updated.Rows[0]["diff"].ToString()) > Convert.ToInt32(dt_updated.Rows[0]["frequency"].ToString()))
            // {
            //     a = upload_json("");
            // }
            // var des = (Receiver)JsonConvert.DeserializeObject(a, typeof(Receiver));
            // string InsCompRes = "";
            // InsCompRes = a;
            DataTable dt_list = new DataTable();

            // if (des != null && (des.Success).ToLower().ToString() == "true")
            // {
            //     if (a != "" && InsCompRes.Split('[')[1].ToString() != "]}")
            //     {

            //         dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + InsCompRes.Split('[')[2].Replace("}]", "") + "]", (typeof(DataTable)));

            //         // DataTable dt_list = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));
            //         insert(dt_list);
            //     }
            //     else
            //     {
            //         SqlDataAdapter Adp = new SqlDataAdapter("select * from Individuals_API", con);
            //         // DataTable Dt_database = new DataTable();
            //         Adp.Fill(dt_list);
            //     }

            // }
            // else
            // {
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Individuals_API", con);
            Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            // DataTable Dt_database = new DataTable();
            Adp.Fill(dt_list);
            //}
           // DataTable final = new DataTable();
           // final.ImportRow(dt_list.Rows[1]);

            Session["dt_l"] = dt_list;
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
        grd_ind.DataSource = Session["dt_l"];
      
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
        dt_list_s = (DataTable)Session["dt_l"];
        // DataRow[] filteredRows = dt_list_s.Select("TaxPayerRIN LIKE '" + txt_RIN.Text + "'");
        DataTable dt_filtered = new DataTable();
        DataView dt_v = dt_list_s.DefaultView;
        if (txt_RIN.Text != "")
            dt_v.RowFilter = "TaxPayerRIN like '%" + txt_RIN.Text + "%'";

        if (txt_name.Text != "")
            dt_v.RowFilter = "TaxPayerName like '%" + txt_name.Text + "%'";

        if (txt_mobile.Text != "")
            dt_v.RowFilter = "MobileNumber like '%" + txt_mobile.Text + "%'";

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
      
        try
        {      
             FtpWebRequest reqFTP;
             reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
             reqFTP.UseBinary = true;
             reqFTP.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);
             reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;
             FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
             DateTime result = DateTime.MinValue;
             result = response.LastModified;
             if (result.Day > 10 || fileString == "")
             {
                 upload_json("");
             }

             byte[] newFileData = request.DownloadData(new Uri(url));
             fileString = System.Text.Encoding.UTF8.GetString(newFileData);
        }
        catch (WebException e)
        {

        }
        return fileString;
    }

    public string upload_json(string json)
    {
        /***************************************************************/

        string token = PAYEClass.getToken();
        /**************************************************************/
        string URI1 = "https://stage-api.eirsautomation.xyz/SupplierData/PAYE_Contribution_Formal_Business_Employee_BS_A_F_TaxPayer";
       
        string myParameters1 = "";
       
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
          //  byte[] data = Encoding.ASCII.GetBytes(json);
          //  request.UploadData(new Uri(url), data);
          
          
        }

        catch (WebException e)
        {

        }
        return json;
    }


    public void insert(DataTable table)
    {
        try
        {
            if (table.Rows.Count > 0)
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