using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Xls;
using Newtonsoft.Json;

public partial class SubmitInputFile : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(PAYEClass.connection);

    public class Receiver
    {
        public string Success { get; set; }
        // public string Message { get; set; }
        // public string Result { get; set; }

    }

    public class Result
    {
        public string Success { get; set; }
        public string Message { get; set; }
        public string[] Result1 { get; set; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string val = "";
         try
        {
            //if (Session["user_id"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            if (!IsPostBack)
            {
                if (Request.QueryString["TaxPayerRIN"] != null)
                {
                    val = Request.QueryString["TaxPayerRIN"].ToString();


                    Session["TaxPRIN_Submit"] = val;
                    Response.Redirect("SubmitInputFile.aspx");
                    
                }
            }
            binddrop();
            drpfupcomapny.SelectedValue = Session["TaxPRIN_Submit"].ToString();
            Session["compRIN"] = Session["TaxPRIN_Submit"].ToString();


            string qry = "Select * from Companies_API where CompanyRIN='" + drpfupcomapny.SelectedValue + "'";
            DataTable dt_company = new DataTable();
            dt_company = PAYEClass.fetchdata(qry);

            if (dt_company.Rows.Count > 0)
                Session["TaxOfc"] = dt_company.Rows[0]["TaxOfficeName"].ToString();
            else
                Session["TaxOfc"] = "FOR REVIEW";

        }
         catch (Exception ex)
         {
             showmsg(2, "Something Went Wrong.");
         }
    }

    public void uploademployee()
    {
        try
        {
            string filepath = Server.MapPath("~") + "/docs/" + drpfupcomapny.SelectedValue.Trim() + ".xlsx";
            DataTable dt = new DataTable();
            dt = getdatatable(filepath);
            int st = 0;

            /*****************************************************************************/
            int status = 0;
            string URI1 = "";


            foreach (DataRow row1 in dt.Rows)
            {
            repeat:

                if (row1["employer_rin"].ToString() == "")
                    goto blankrepeat;

                //URI1 = "https://stage-api.eirsautomation.xyz/TaxPayer/SearchTaxPayerByRIN?TaxPayerRIN=" + row1["employee_rin"].ToString();
                URI1 = PAYEClass.URL_API + "TaxPayer/SearchTaxPayerByRIN?TaxPayerRIN=" + row1["employee_rin"].ToString();

                string InsCompRes = "";
                string headers = "";
                using (var wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();

                    InsCompRes = wc.DownloadString(URI1);

                    var des = (Receiver)JsonConvert.DeserializeObject(InsCompRes, typeof(Receiver));
                    //  var des1 = (Result)JsonConvert.DeserializeObject(InsCompRes, typeof(Result));
                    DataTable dt_list_ins = new DataTable();

                    /******************** Check With Mobile No. Start*****************************/

                    if (des != null && (des.Success).ToLower().ToString() == "true")
                    {
                        if (InsCompRes != "" && InsCompRes.Split('[')[1].ToString() != "]}")
                        {

                        }

                        else
                        {
                            if (row1["employee_phone"].ToString() != "")
                            {
                                URI1 = "https://stage-api.eirsautomation.xyz/TaxPayer/SearchTaxPayerByMobileNumber?MobileNumber=" + row1["employee_phone"].ToString();
                                URI1 = PAYEClass.URL_API + "TaxPayer/SearchTaxPayerByMobileNumber?MobileNumber=" + row1["employee_phone"].ToString();
                                using (var wc_mobile = new WebClient())
                                {
                                    wc_mobile.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                                    wc_mobile.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                                    InsCompRes = wc.DownloadString(URI1);
                                    des = (Receiver)JsonConvert.DeserializeObject(InsCompRes, typeof(Receiver));
                                    //  var des1 = (Result)JsonConvert.DeserializeObject(InsCompRes, typeof(Result));


                                }
                            }
                        }
                    }


                    if (des != null && (des.Success).ToLower().ToString() == "true")
                    {
                        if (InsCompRes != "" && InsCompRes.Split('[')[1].ToString() != "]}")
                        {

                        }

                        else
                        {
                            if (row1["employee_tin"].ToString() != "")
                            {
                                URI1 = "https://stage-api.eirsautomation.xyz/TaxPayer/SearchTaxPayerByTIN?TaxPayerTIN=" + row1["employee_tin"].ToString();
                                URI1 = PAYEClass.URL_API + "TaxPayer/SearchTaxPayerByTIN?TaxPayerTIN=" + row1["employee_tin"].ToString();
                                using (var wc_mobile = new WebClient())
                                {
                                    wc_mobile.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                                    wc_mobile.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                                    InsCompRes = wc.DownloadString(URI1);
                                    des = (Receiver)JsonConvert.DeserializeObject(InsCompRes, typeof(Receiver));
                                    //  var des1 = (Result)JsonConvert.DeserializeObject(InsCompRes, typeof(Result));
                                }
                            }
                        }
                    }
                    /******************** Check With Mobile No. END *****************************/



                    if (des != null && (des.Success).ToLower().ToString() == "true")
                    {
                        if (InsCompRes != "" && InsCompRes.Split('[')[1].ToString() != "]}")
                        {
                            DataTable dt_list_api = new DataTable();
                            dt_list_api = (DataTable)JsonConvert.DeserializeObject("[" + InsCompRes.Split('[')[1].Replace("}]", "") + "]", (typeof(DataTable)));


                            //Individual Business Linking

                            string[] res_AddInd_Business_API;
                            string URI_AddInd_Business_API = "https://stage-api.eirsautomation.xyz/TaxPayerAsset/AddBusinessToIndividual";
                            URI_AddInd_Business_API = PAYEClass.URL_API + "TaxPayerAsset/AddBusinessToIndividual";

                            string myParameters_AddInd_Business_API = "{\"TaxPayerID\": " + dt_list_api.Rows[0]["TaxPayerID"].ToString() + ", \"AssetID\": " + Session["BusinessID"].ToString() + ", \"TaxPayerRoleID\": " + dt_list_api.Rows[0]["TaxPayerTypeID"].ToString() + "}";

                            string InsCompRes_AddIndBusinessAPI = "";
                            using (WebClient wc_AddInd_Business_API = new WebClient())
                            {
                                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                                wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                                // string json = JsonConvert.SerializeObject(Assessment);
                                InsCompRes_AddIndBusinessAPI = wc.UploadString(URI_AddInd_Business_API, myParameters_AddInd_Business_API);

                                res_AddInd_Business_API = InsCompRes_AddIndBusinessAPI.Split('"');
                            }

                            //changes in 15 jan 19
                            {
                                if (String.IsNullOrEmpty(row1["annual_basic"].ToString()))
                                    row1["annual_basic"] = "0";

                                if (String.IsNullOrEmpty(row1["annual_rent"].ToString()))
                                    row1["annual_rent"] = "0";

                                if (String.IsNullOrEmpty(row1["annual_transport"].ToString()))
                                    row1["annual_transport"] = "0";


                                if (String.IsNullOrEmpty(row1["annual_utility"].ToString()))
                                    row1["annual_utility"] = "0";

                                if (String.IsNullOrEmpty(row1["annual_meal"].ToString()))
                                    row1["annual_meal"] = "0";



                                if (String.IsNullOrEmpty(row1["other_allowances_annual"].ToString()))
                                    row1["other_allowances_annual"] = "0";

                                if (String.IsNullOrEmpty(row1["leave_transport_grant_annual"].ToString()))
                                    row1["leave_transport_grant_annual"] = "0";

                                if (String.IsNullOrEmpty(row1["pension_contribution_declared"].ToString()))
                                    row1["pension_contribution_declared"] = "0";

                                if (String.IsNullOrEmpty(row1["nhf_contribution_declared"].ToString()))
                                    row1["nhf_contribution_declared"] = "0";


                                if (String.IsNullOrEmpty(row1["nhis_contribution_declared"].ToString()))
                                    row1["nhis_contribution_declared"] = "0";



                            }

                            SqlParameter[] pram = new SqlParameter[31];

                            pram[0] = new SqlParameter("@TaxPayerID", dt_list_api.Rows[0]["TaxPayerID"].ToString());
                            pram[1] = new SqlParameter("@TaxPayerTypeID", 1);

                            string taxpayerTypeName = "";
                            if (dt_list_api.Rows[0]["TaxPayerTypeID"].ToString() == "1")
                                taxpayerTypeName = "Individual";

                            pram[2] = new SqlParameter("@TaxPayerTypeName", taxpayerTypeName);
                            pram[3] = new SqlParameter("@TaxPayerName", dt_list_api.Rows[0]["TaxPayerName"].ToString());
                            pram[4] = new SqlParameter("@TaxPayerRIN", dt_list_api.Rows[0]["TaxPayerRIN"].ToString().Trim());
                            pram[5] = new SqlParameter("@MobileNumber", dt_list_api.Rows[0]["TaxPayerMobileNumber"].ToString().Trim());
                            pram[6] = new SqlParameter("@ContactAddress", dt_list_api.Rows[0]["TaxPayerAddress"].ToString().Trim());
                            pram[7] = new SqlParameter("@EmailAddress", "");
                            pram[8] = new SqlParameter("@TIN", row1["employee_tin"].ToString().Trim());

                            pram[9] = new SqlParameter("@employerName", drpfupcomapny.SelectedItem.Text);
                            pram[10] = new SqlParameter("@employerAddress", "");
                            pram[11] = new SqlParameter("@employerRIN", drpfupcomapny.SelectedValue.ToString());
                            pram[12] = new SqlParameter("@StartMonth", row1["start_month"].ToString());
                            pram[13] = new SqlParameter("@Nationality", row1["nationality"].ToString());
                            pram[14] = new SqlParameter("@Title", row1["title"].ToString());
                            pram[15] = new SqlParameter("@FirstName", row1["first_name"].ToString().Trim());
                            pram[16] = new SqlParameter("@Surname", row1["surname"].ToString().Trim());
                            pram[17] = new SqlParameter("@Assessment_Year", row1["assessment_year"].ToString().Trim());
                            pram[18] = new SqlParameter("@EndMonth", row1["end_month"].ToString().Trim());

                            pram[19] = new SqlParameter("@Basic", row1["annual_basic"].ToString());
                            pram[20] = new SqlParameter("@Rent", row1["annual_rent"].ToString());
                            pram[21] = new SqlParameter("@Trans", row1["annual_transport"].ToString());
                            pram[22] = new SqlParameter("@LTG", row1["leave_transport_grant_annual"].ToString().Trim());
                            pram[23] = new SqlParameter("@AnnualUtility", row1["annual_utility"].ToString().Trim());
                            pram[24] = new SqlParameter("@AnnualMeal", row1["annual_meal"].ToString().Trim());
                            pram[25] = new SqlParameter("@Others", row1["other_allowances_annual"].ToString().Trim());

                            pram[26] = new SqlParameter("@Pension", row1["pension_contribution_declared"].ToString().Trim());
                            pram[27] = new SqlParameter("@NHF", row1["nhf_contribution_declared"].ToString().Trim());
                            pram[28] = new SqlParameter("@NHIS", row1["nhis_contribution_declared"].ToString().Trim());
                            pram[29] = new SqlParameter("@BusinessRIN", drpbusiness.SelectedValue.ToString());

                            pram[30] = new SqlParameter("@SucessID", 1);
                            pram[30].Direction = System.Data.ParameterDirection.Output;
                            SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "Adm_INS_UploadXL_API", pram);
                            status += int.Parse(pram[30].Value.ToString());

                            row1["employee_rin"] = dt_list_api.Rows[0]["TaxPayerRIN"].ToString().Trim();
                            /************************ADD Input API***********************/

                            //DateTime.ParseExact(row1["start_month"].ToString(), "MMM", CultureInfo.InvariantCulture).Month
                            string[] res_Input_API;
                            string URI_Input_API = "https://stage-api.eirsautomation.xyz/DataWarehouse/PAYEInput/Insert";
                            URI_Input_API = PAYEClass.URL_API + "DataWarehouse/PAYEInput/Insert";

                            //string myParameters_Input_API = "{\n    \"TranscationDate\": \"" + DateTime.Now.Date.ToString() + "\",\n    \"Employer_RIN\": \"" + drpfupcomapny.SelectedValue.ToString() + "\",\n    \"Employee_RIN\": \"" + dt_list_api.Rows[0]["TaxPayerRIN"].ToString().Trim() + "\",\n    \"Assessment_Year\": " + row1["assessment_year"].ToString().Trim() + ",\n    \"Start_Month\": " + DateTime.ParseExact(row1["start_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month + ",\n    \"End_Month\": " + DateTime.ParseExact(row1["end_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month + ",\n    \"Annual_Basic\": " + row1["annual_basic"].ToString() + ",\n    \"Annual_Rent\": " + row1["annual_rent"].ToString() + ",\n    \"Annual_Transport\": " + row1["annual_transport"].ToString() + ",\n    \"Annual_Utility\": " + row1["annual_utility"].ToString() + ",\n    \"Annual_Meal\": " + row1["annual_meal"].ToString() + ",\n    \"Other_Allowances_Annual\": " + row1["other_allowances_annual"].ToString().Trim() + ",\n    \"Leave_Transport_Grant_Annual\": " + row1["leave_transport_grant_annual"].ToString().Trim() + ",\n    \"pension_contribution_declared\": " + row1["pension_contribution_declared"].ToString().Trim() + ",\n    \"nhf_contribution_declared\": " + row1["nhf_contribution_declared"].ToString().Trim() + ",\n    \"nhis_contribution_declared\": " + row1["nhis_contribution_declared"].ToString().Trim() + "\n}";
                            string tax_of="For Review";
                            tax_of = Session["TaxOfc"].ToString();

                            string myParameters_Input_API = "{\n    \"TranscationDate\": \"" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\",\n    \"Employer_RIN\": \"" + drpbusiness.SelectedValue.ToString() + "\",\n    \"Employee_RIN\": \"" + dt_list_api.Rows[0]["TaxPayerRIN"].ToString().Trim() + "\",\n    \"Assessment_Year\": " + row1["assessment_year"].ToString().Trim() + ",\n    \"Start_Month\": " + DateTime.ParseExact(row1["start_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month + ",\n    \"End_Month\": " + DateTime.ParseExact(row1["end_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month + ",\n    \"Annual_Basic\": " + row1["annual_basic"].ToString() + ",\n    \"Annual_Rent\": " + row1["annual_rent"].ToString() + ",\n    \"Annual_Transport\": " + row1["annual_transport"].ToString() + ",\n    \"Annual_Utility\": " + row1["annual_utility"].ToString() + ",\n    \"Annual_Meal\": " + row1["annual_meal"].ToString() + ",\n    \"Other_Allowances_Annual\": " + row1["other_allowances_annual"].ToString().Trim() + ",\n    \"Leave_Transport_Grant_Annual\": " + row1["leave_transport_grant_annual"].ToString().Trim() + ",\n    \"pension_contribution_declared\": " + row1["pension_contribution_declared"].ToString().Trim() + ",\n    \"nhf_contribution_declared\": " + row1["nhf_contribution_declared"].ToString().Trim() + ",\n    \"nhis_contribution_declared\": " + row1["nhis_contribution_declared"].ToString().Trim() + ",\n    \"Tax_Office\":\"" + tax_of + "\"\n}";

                            string InsCompRes_InputAPI = "";
                            using (WebClient wc_Input_API = new WebClient())
                            {
                                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                                wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                                // string json = JsonConvert.SerializeObject(Assessment);
                                InsCompRes_InputAPI = wc.UploadString(URI_Input_API, myParameters_Input_API);

                                res_Input_API = InsCompRes_InputAPI.Split('"');

                            }
                            /****************************END***************************/



                        }

                        else
                        {
                            // insert individual


                            string[] res_AddInd_API;
                            string URI_AddInd_API = "https://stage-api.eirsautomation.xyz/TaxPayer/Individual/Insert";
                            URI_AddInd_API = PAYEClass.URL_API + "TaxPayer/Individual/Insert";
                            string myParameters_AddInd_API = "{\n    \"TaxPayerTypeId\":1,\n    \"GenderID\": 1,\n    \"TitleID\": 2,\n    \"FirstName\": \"" + row1["first_name"].ToString().Trim() + "\",\n    \"LastName\": \"" + row1["surname"].ToString().Trim() + "\",\n    \"MiddleName\": \"" + row1["middle_name"].ToString().Trim() + "\",\n    \"DOB\": \"01/01/2004\",\n    \"TIN\": \"" + row1["employee_tin"].ToString().Trim() + "\",\n    \"MobileNumber1\": \"" + row1["employee_phone"].ToString().Trim() + "\",\n    \"EmailAddress1\": \"abc@gmail.com\",\n    \"BiometricDetails\": \"\",\n    \"TaxOfficeID\": 34,\n    \"MaritalStatusID\": 3,\n    \"NationalityID\": 1,\n    \"EconomicActivitiesID\": 13,\n    \"NotificationMethodID\": 3,\n    \"ContactAddress\": \"None Listed\"\n}";

                            string InsCompRes_AddIndAPI = "";
                            using (WebClient wc_AddInd_API = new WebClient())
                            {
                                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                                wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                                // string json = JsonConvert.SerializeObject(Assessment);
                                InsCompRes_AddIndAPI = wc.UploadString(URI_AddInd_API, myParameters_AddInd_API);

                                res_AddInd_API = InsCompRes_AddIndAPI.Split('"');

                                if (res_AddInd_API[2].ToString() == ":false,")
                                {
                                    showmsg(2, "Something Wrong in Sheet:" + res_AddInd_API[5].ToString());
                                    return;
                                }
                            }





                            goto repeat;
                        }
                    }

                }
            blankrepeat: { }
            }


            /*****************************************************************************/
        //    if (dt.Rows[i]["assessment_year"].ToString().Trim() == "")
                Session["Tax_Year"] = drpTaxYear.SelectedValue;

            DataTable dt_list_inputfile = new DataTable();
            SqlDataAdapter Adp_inputfile = new SqlDataAdapter("select (firstname+' '+surname) as Name, EmployeeRIN as taxpayerRIN,EmployeeTIN as tp_TIN, Assessment_Year as Tax_Year, AnnualGross, EmployerName as CompanyName, EmployerRIN as CompanyRIN, EmployerAddress as ContactAddress,AnnualTax,(CASE WHEN (endmonth is NULL) then 'Active' else 'Active' end) as Active from payeOuputfile  where EmployerRIN='" + Session["compRIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
            Adp_inputfile.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
            Adp_inputfile.Fill(dt_list_inputfile);

            Session["dt_l"] = dt_list_inputfile;






            foreach (DataRow row1 in dt.Rows)
            {
                if (row1["employee_rin"].ToString() != "")
                    st = 0;
                foreach (DataRow row2 in ((DataTable)Session["dt_l"]).Rows)
                {
                    if (row1["employee_rin"].ToString() == row2["taxpayerRIN"].ToString())
                    {
                        st = 1;
                    }

                }

                if (st == 0)
                {
                    // showmsg(2, "Any EmployeeRIN not exist in database. Please Add First.");

                    showmsg(2, "Employee RIN - " + row1["employee_rin"].ToString() + " Salary Details Not Uploaded.");
                    return;
                }

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["employee_rin"].ToString() != "")
                {
                    DataTable dt_list = new DataTable();
                    SqlDataAdapter Adp = new SqlDataAdapter("select *,(FirstName+' '+SurName) as Name from PayeInputFile where EmployeeRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
                    Adp.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
                    Adp.Fill(dt_list);

                    if (dt_list.Rows.Count == 0)
                    {
                        con.Open();

                        //        SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
                        //"'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, convert(numeric(18,0),Tp_TIN) as EmployeeTIN," +
                        //"Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
                        //"LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+Pension) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and Tax_Year='" + Session["Tax_Year"].ToString() + "'", con);


                        SqlCommand cmd = new SqlCommand("insert into PayeInputfile select CompanyName as EmployerName, ContactAddress as EmployerAddress, CompanyRIN as EmployerRIN, TaxMonth as StartMonth," +
           "'' as Nationality, '' as Title, FirstName, MiddleName, LastName as SurName, TaxPayerRIN as EmployeeRIN, case  when Tp_TIN=TaxPayerRIN then  '' else Tp_Tin end as EmployeeTIN," +
           "Basic as AnnualBasic, Rent as AnnualRent, Trans as AnnualTransport, '0' as AnnualUtility, '0' as AnnualMeal, others as OtherAllowances_Annual," +
           "LTG as LeaveTransport_Annual, (Basic+Trans+Rent+LTG+Others+AnnualUtility+AnnualMeal) as AnnualGross, Pension,NHF,NHIS,Tax_Year as Assessment_Year, null as endmonth from vw_inputfile where taxmonth='January' and TaxPayerRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and Tax_Year='" + Session["Tax_Year"].ToString() + "' and CompanyRIN='" + Session["compRIN"].ToString() + "'", con);



                        cmd.ExecuteNonQuery();
                        con.Close();

                    }

                    //  double annual_gross = Convert.ToDouble(dt.Rows[i]["Basic"].ToString()) + Convert.ToDouble(dt.Rows[i]["Rent"].ToString()) + Convert.ToDouble(dt.Rows[i]["Utility"].ToString()) + Convert.ToDouble(dt.Rows[i]["Meal"].ToString()) + Convert.ToDouble(dt.Rows[i]["otherAllowances"].ToString()) + Convert.ToDouble(dt.Rows[i]["AnnualTransport"].ToString());
                    double annual_gross = 0;
                    string basic = dt.Rows[i]["annual_basic"].ToString();
                    // annual_gross = double.Parse(basic, CultureInfo.InvariantCulture);
                    // annual_gross = double.Parse(string.Format("{0:0.00}",dt.Rows[i]["Basic"].ToString().Trim()));
                    //  SqlCommand update = new SqlCommand("Update PayeInputfile set AnnualBasic='" + dt.Rows[i]["Basic"].ToString() + "', AnnualRent='" + dt.Rows[i]["Rent"].ToString() + "', AnnualTransport='" + dt.Rows[i]["AnnualTransport"].ToString() + "', AnnualUtility='" + dt.Rows[i]["Utility"].ToString() + "', AnnualMeal='" + dt.Rows[i]["Meal"].ToString() + "', OtherAllowances_Annual='" + dt.Rows[i]["otherAllowances"].ToString() + "',Pension='" + dt.Rows[i]["PensionDeclared"].ToString() + "', NHF='" + dt.Rows[i]["NHFDeclared"].ToString() + "', NHIS='" + dt.Rows[i]["NHISDeclared"].ToString() + "', LeaveTransport_Annual='" + dt.Rows[i]["LTG"].ToString() + "', AnnualGross='" + (Convert.ToInt32(dt.Rows[i]["Basic"].ToString()) + Convert.ToInt32(dt.Rows[i]["Rent"].ToString() + Convert.ToInt32(dt.Rows[i]["Utility"].ToString()) + Convert.ToInt32(dt.Rows[i]["Meal"].ToString()) + Convert.ToInt32(dt.Rows[i]["otherAllowances"].ToString())) + Convert.ToInt32(dt.Rows[i]["AnnualTransport"].ToString())) + "' where employeeRIN='" + dt.Rows[i]["RIN"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);

                    SqlCommand update = new SqlCommand("Update PayeInputfile set AnnualBasic='" + dt.Rows[i]["annual_basic"].ToString() + "', AnnualRent='" + dt.Rows[i]["annual_rent"].ToString() + "', AnnualTransport='" + dt.Rows[i]["annual_transport"].ToString() + "', AnnualUtility='" + dt.Rows[i]["annual_utility"].ToString() + "', AnnualMeal='" + dt.Rows[i]["annual_meal"].ToString() + "', OtherAllowances_Annual='" + dt.Rows[i]["other_allowances_annual"].ToString() + "',Pension='" + dt.Rows[i]["pension_contribution_declared"].ToString() + "', NHF='" + dt.Rows[i]["nhf_contribution_declared"].ToString() + "', NHIS='" + dt.Rows[i]["nhis_contribution_declared"].ToString() + "', LeaveTransport_Annual='" + dt.Rows[i]["leave_transport_grant_annual"].ToString() + "',AnnualGross='" + (Convert.ToDecimal(dt.Rows[i]["annual_basic"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_rent"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_transport"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_utility"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_meal"].ToString()) + Convert.ToDecimal(dt.Rows[i]["other_allowances_annual"].ToString()) + Convert.ToDecimal(dt.Rows[i]["leave_transport_grant_annual"].ToString())) + "', StartMonth='" + dt.Rows[i]["start_month"].ToString() + "', EndMonth='" + dt.Rows[i]["end_month"].ToString() + "' where employeeRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
                    con.Open();
                    update.ExecuteNonQuery();
                    con.Close();

                    double[] sal_brkup = new double[8];
                    double basic1 = 0, nhf = 0, nhis = 0, rent = 0, annual_trans = 0, pension = 0;

                    if (dt.Rows[i]["annual_rent"].ToString() != "0" || dt.Rows[i]["annual_rent"].ToString() != "")
                    {
                        rent = Convert.ToDouble(dt.Rows[i]["annual_rent"].ToString());
                    }

                    if (dt.Rows[i]["annual_transport"].ToString() != "0" || dt.Rows[i]["annual_transport"].ToString() != "")
                    {
                        annual_trans = Convert.ToDouble(dt.Rows[i]["annual_transport"].ToString());
                    }

                    if (dt.Rows[i]["pension_contribution_declared"].ToString() != "0" || dt.Rows[i]["pension_contribution_declared"].ToString() != "")
                    {
                        pension = Convert.ToDouble(dt.Rows[i]["pension_contribution_declared"].ToString());
                    }

                    if (dt.Rows[i]["nhf_contribution_declared"].ToString() != "0" || dt.Rows[i]["nhf_contribution_declared"].ToString() != "")
                    {
                        nhf = Convert.ToDouble(dt.Rows[i]["nhf_contribution_declared"].ToString());
                    }

                    if (dt.Rows[i]["nhis_contribution_declared"].ToString() != "0" || dt.Rows[i]["nhis_contribution_declared"].ToString() != "")
                    {
                        nhis = Convert.ToDouble(dt.Rows[i]["nhis_contribution_declared"].ToString());
                    }

                    Session["Tax_Year"] = dt.Rows[i]["assessment_year"].ToString().Trim();

                   

                    annual_gross = (Convert.ToDouble(dt.Rows[i]["annual_basic"].ToString()) + Convert.ToDouble(dt.Rows[i]["annual_rent"].ToString()) + Convert.ToDouble(dt.Rows[i]["annual_transport"].ToString()) + Convert.ToDouble(dt.Rows[i]["annual_utility"].ToString()) + Convert.ToDouble(dt.Rows[i]["annual_meal"].ToString()) + Convert.ToDouble(dt.Rows[i]["other_allowances_annual"].ToString()) + Convert.ToDouble(dt.Rows[i]["leave_transport_grant_annual"].ToString()));
                    int no_of_months = Math.Abs((Convert.ToInt32(dt.Rows[i]["assessment_year"].ToString()) * 12 + (DateTime.ParseExact(dt.Rows[i]["end_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month)) - (Convert.ToInt32(dt.Rows[i]["assessment_year"].ToString()) * 12 + (DateTime.ParseExact(dt.Rows[i]["start_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month - 1)));
                    sal_brkup = PAYEClass.calculatetax(annual_gross, Convert.ToDouble(dt.Rows[i]["annual_basic"].ToString()), rent, annual_trans, 1, pension, 1, nhf, 1, nhis, no_of_months);

                    con.Open();


                    SqlCommand cmd_update_outputFile = new SqlCommand("update payeouputfile set AnnualGross='" + (Convert.ToDecimal(dt.Rows[i]["annual_basic"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_rent"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_transport"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_utility"].ToString()) + Convert.ToDecimal(dt.Rows[i]["annual_meal"].ToString()) + Convert.ToDecimal(dt.Rows[i]["other_allowances_annual"].ToString()) + Convert.ToDecimal(dt.Rows[i]["leave_transport_grant_annual"].ToString())) + "', CRA='" + sal_brkup[0] + "', ValidatedPension='" + sal_brkup[1] + "', ValidatedNHF='" + sal_brkup[2] + "', ValidatedNHIS='" + sal_brkup[3] + "', TaxFreePay='" + sal_brkup[4] + "', ChargeableIncome='" + sal_brkup[5] + "', AnnualTax='" + sal_brkup[6] + "', MonthlyTax='" + sal_brkup[7] + "' where EmployeeRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and Assessment_Year='" + Session["Tax_Year"].ToString() + "'", con);
                    //        SqlCommand cmd_update_outputFile = new SqlCommand("update payeouputfile set AnnualGross='" + txt_AnnualGross.Text + "', CRA='" + sal_brkup[0] + "', ValidatedPension='" + validatedPension + "', ValidatedNHF='" + validatedNHF + "', ValidatedNHIS='" + validatedNHIS + "', TaxFreePay='" + sal_brkup[4] + "', ChargeableIncome='" + sal_brkup[5] + "', AnnualTax='" + sal_brkup[6] + "', MonthlyTax='" + sal_brkup[7] + "' where EmployeeRIN='" + txt_employee_RIN.Text + "' and Assessment_Year='" + txt_tax_year.Text + "' and EmployerRIN='" + Session["compRIN_edit"].ToString() + "'", con);

                    cmd_update_outputFile.ExecuteNonQuery();
                    con.Close();

                    con.Open();

                    int start_mon = (DateTime.ParseExact(dt.Rows[i]["start_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month);
                    int end_mon = (DateTime.ParseExact(dt.Rows[i]["end_month"].ToString().Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month);

                    SqlCommand delete = new SqlCommand("delete from EmployeeContributionOutputFile where EmployeRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and AssessmentYear='" + Session["Tax_Year"].ToString() + "'", con);

                    delete.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    DataTable dt_Emp_Contribution = new DataTable();
                    SqlDataAdapter Adp_Emp_Contribution = new SqlDataAdapter("Select * from employeecontributionoutputfile where EmployeRIN='" + dt.Rows[i]["employee_rin"].ToString() + "' and AssessmentYear=" + Session["Tax_Year"].ToString(), con);
                    Adp_Emp_Contribution.SelectCommand.CommandTimeout = PAYEClass.defaultTimeout;
                    Adp_Emp_Contribution.Fill(dt_Emp_Contribution);

                    SqlCommand cmd1 = new SqlCommand();
                    if (DateTime.Now.Year == Convert.ToInt32(Session["Tax_Year"].ToString()))
                    {
                        if (dt_Emp_Contribution.Rows.Count == 0)
                        {
                            //  cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dt.Rows[i]["employee_rin"].ToString().Replace("'", "''") + "','" + Session["Tax_Year"].ToString() + "',CASE WHEN month(getdate())>1 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>2 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>3 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>4 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>5 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>6 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>7 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>8 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>9 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>10 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>11 THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN month(getdate())>11 THEN '" + sal_brkup[7] + "' ELSE '0' END);", con);
                            cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dt.Rows[i]["employee_rin"].ToString().Replace("'", "''") + "','" + Session["Tax_Year"].ToString() + "',CASE WHEN (1>=" + start_mon + " and 1<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (2>=" + start_mon + " and 2<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (3>=" + start_mon + " and 3<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (4>=" + start_mon + " and 4<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (5>=" + start_mon + " and 5<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (6>=" + start_mon + " and 6<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (7>=" + start_mon + " and 7<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (8>=" + start_mon + " and 8<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (9>=" + start_mon + " and 9<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (10>=" + start_mon + " and 10<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (11>=" + start_mon + " and 11<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (12>=" + start_mon + " and 12<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END);", con);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        if (dt_Emp_Contribution.Rows.Count == 0)
                        {
                            //  cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dt.Rows[i]["employee_rin"].ToString().Replace("'", "''") + "','" + Session["Tax_Year"].ToString() + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "','" + sal_brkup[7] + "');", con);
                            cmd1 = new SqlCommand("insert into EmployeeContributionOutputFile values('" + dt.Rows[i]["employee_rin"].ToString().Replace("'", "''") + "','" + Session["Tax_Year"].ToString() + "',CASE WHEN (1>=" + start_mon + " and 1<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (2>=" + start_mon + " and 2<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (3>=" + start_mon + " and 3<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (4>=" + start_mon + " and 4<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (5>=" + start_mon + " and 5<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (6>=" + start_mon + " and 6<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (7>=" + start_mon + " and 7<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (8>=" + start_mon + " and 8<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (9>=" + start_mon + " and 9<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (10>=" + start_mon + " and 10<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (11>=" + start_mon + " and 11<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END,CASE WHEN (12>=" + start_mon + " and 12<=" + end_mon + ") THEN '" + sal_brkup[7] + "' ELSE '0' END);", con);
                            cmd1.ExecuteNonQuery();
                        }
                    }

                    con.Close();


                    /************************ADD Ouput API***********************/
                    string tax_of = "For Review";
                    //DateTime.ParseExact(row1["start_month"].ToString(), "MMM", CultureInfo.InvariantCulture).Month
                    string[] res_Ouput_API;
                    string URI_Ouput_API = "https://stage-api.eirsautomation.xyz/DataWarehouse/PAYEOutput/Insert";
                    URI_Ouput_API = PAYEClass.URL_API + "DataWarehouse/PAYEOutput/Insert";

                   // string myParameters_Ouput_API = "{\n    \"Transaction_Date\": \"" + DateTime.Now.ToString() + "\",\n    \"Employee_Rin\": \"" + dt.Rows[i]["employee_rin"].ToString().Replace("'", "''") + "\",\n    \"Employer_Rin\": \"" + drpfupcomapny.SelectedValue.ToString() + "\",\n    \"AssessmentYear\": " + Convert.ToInt32(Session["Tax_Year"].ToString()) + ",\n    \"Assessment_Month\": 1,\n    \"Monthly_CRA\": " + sal_brkup[0] + ",\n    \"Monthly_Gross\": 0,\n    \"Monthly_ValidatedNHF\": " + sal_brkup[2] + ",\n    \"Monthly_ValidatedNHIS\": " + sal_brkup[3] + ",\n    \"Monthly_ValidatedPension\": " + sal_brkup[1] + ",\n    \"Monthly_TaxFreePay\": " + sal_brkup[4] + ",\n    \"Monthly_ChargeableIncome\": " + sal_brkup[5] + ",\n    \"Monthly_Tax\": " + sal_brkup[7] + "\n}";

                    string myParameters_Ouput_API = "{\n    \"Transaction_Date\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\n    \"Employee_Rin\": \"" + dt.Rows[i]["employee_rin"].ToString().Replace("'", "''") + "\",\n    \"Employer_Rin\": \"" + drpbusiness.SelectedValue.ToString() + "\",\n    \"AssessmentYear\": " + Convert.ToInt32(Session["Tax_Year"].ToString()) + ",\n    \"Assessment_Month\": 1,\n    \"Monthly_CRA\": " + sal_brkup[0] + ",\n    \"Monthly_Gross\": 0,\n    \"Monthly_ValidatedNHF\": " + sal_brkup[2] + ",\n    \"Monthly_ValidatedNHIS\": " + sal_brkup[3] + ",\n    \"Monthly_ValidatedPension\": " + sal_brkup[1] + ",\n    \"Monthly_TaxFreePay\": " + sal_brkup[4] + ",\n    \"Monthly_ChargeableIncome\": " + sal_brkup[5] + ",\n    \"Monthly_Tax\": " + sal_brkup[7] + ",\n    \"Tax_Office\":\"" + tax_of + "\"\n}";

                    string InsCompRes_OuputAPI = "";
                    using (WebClient wc_Ouput_API = new WebClient())
                    {
                        wc_Ouput_API.Headers[HttpRequestHeader.ContentType] = "application/json";
                        wc_Ouput_API.Headers[HttpRequestHeader.Authorization] = "Bearer " + Session["token"].ToString();
                        // string json = JsonConvert.SerializeObject(Assessment);
                        InsCompRes_OuputAPI = wc_Ouput_API.UploadString(URI_Ouput_API, myParameters_Ouput_API);

                        res_Ouput_API = InsCompRes_OuputAPI.Split('"');

                    }
                    /****************************END***************************/
                }

                showmsg(1, "File Uploaded Successfully.");
            }
        }
        catch (Exception ex)
        {
            showmsg(2, "Something Went Wrong.");
        }
    }


    public DataTable getdatatable(string filename)
    {
        DataTable dt = new DataTable();
        Workbook workbook = new Workbook();
        workbook.LoadFromFile(filename);
        Worksheet sheet = workbook.Worksheets[0];
        dt = sheet.ExportDataTable();
        return dt;
    }

    public void binddrop()
    {
        string qry = "Select distinct CompanyRIN,CompanyName from vw_InputFile";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        drpfupcomapny.DataSource = dt;
        drpfupcomapny.DataTextField = "CompanyName";
        drpfupcomapny.DataValueField = "CompanyRIN";
        drpfupcomapny.DataBind();

        dt = null;
        qry = "Select distinct BusinessRIN_1,BusinessName from vw_InputFile where CompanyRIN='" + Session["TaxPRIN_Submit"].ToString() + "'";
        dt = PAYEClass.fetchdata(qry);
        drpbusiness.DataSource = dt;
        drpbusiness.DataTextField = "BusinessName";
        drpbusiness.DataValueField = "BusinessRIN_1";
        drpbusiness.DataBind();
    }

    public void showmsg(int id, string msg)
    {
        if (id == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-check-circle' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-success");
        }
        else if (id == 2)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "alert alert-warning");
        }
        else
        {
            divmsg.Style.Add("display", "none");
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            login_bearer_token();
            Session["BusinessID"] = drpbusiness.SelectedValue;
            showmsg(3, "");
            if (fpemp.HasFile)
            {
                if (fpemp.PostedFile.FileName.Contains(".xlsx"))
                {
                    ///////////////////////////New Changes Start////////////////////////////////
                    HttpPostedFile fileToUpload = fpemp.PostedFile;
                    string uploadUrl = PAYEClass.uploadurl;
                    string uploadFileName = drpfupcomapny.SelectedValue.Trim() + ".xlsx"; //fpemp.PostedFile.FileName;
                    Stream streamObj = fileToUpload.InputStream;
                    Byte[] buffer = new Byte[fileToUpload.ContentLength];
                    streamObj.Read(buffer, 0, buffer.Length);
                    streamObj.Close();
                    streamObj = null;

                    string ftpUrl = string.Format("{0}/{1}", uploadUrl, uploadFileName);
                    FtpWebRequest requestObj = FtpWebRequest.Create(ftpUrl) as FtpWebRequest;
                    requestObj.Method = WebRequestMethods.Ftp.UploadFile;
                    requestObj.Credentials = new NetworkCredential(PAYEClass.ftpusername, PAYEClass.ftppassword);
                    Stream requestStream = requestObj.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                    requestObj = null;

                    // addindividual.Style.Add("display", "none");
                    uploademployee();

                }
                else
                {
                    showmsg(2, "Please upload .xlsx file");
                    //   pnltax.Visible = false;
                }
            }
            else
            {
                showmsg(2, "Please upload a file");
                // pnltax.Visible = false;
            }
        }
        catch (Exception ex)
        {
            showmsg(2, "Something Went Wrong.");
        }
    }

    public class Token
    {
        public string access_token { get; set; }
    }

    public void login_bearer_token()
    {
        string token = PAYEClass.getToken();
        Session["token"] = token;
    }
}