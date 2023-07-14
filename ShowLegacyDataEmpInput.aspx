<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowLegacyDataEmpInput.aspx.cs" Inherits="ShowLegacyDataEmpInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">
.modalBackground
{
background-color: Gray;
filter: alpha(opacity=80);
opacity: 0.8;
z-index: 10000;
}
</style>
    <style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>

    
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script type="text/javascript">

        function showImage() {
            document.getElementById('<%=div_loading.ClientID%>').style.display = "block";

        }
        function hideImage() {
            document.getElementById('<%=div_loading.ClientID%>').style.display = "none";

        }

        function gf() {
            $(function () {
                var gridId = "<%= grd_emp_list.ClientID %>";
                var rowClickEvent = "#" + gridId + " tr"
                var current = "";

                $("#" + gridId).on("click", "span.close", function () {
                    //Remove the row when user click on X
                    $(this).parent().parent().empty();
                });

                $(rowClickEvent).click(function () {
                    //Add row containing aditional info when user click on a row inside the grid view
                    var row = this;

                    $("#tax_payer_rin").text(row.children[0].innerText);
                    $("#tax_payer_name").text(row.children[1].innerText);
                    $("#annual_gross").text(row.children[4].innerText);

                    $("#txt_rent").text(row.children[19].innerText);
                    $("#txt_trans").text(row.children[20].innerText);
                    $("#txt_pension").text(row.children[25].innerText);

                    $("#txt_NHF").text(row.children[26].innerText);
                    $("#txt_NHIS").text(row.children[27].innerText);


                });
            });
        }




       
        function Confirm_drop_emp() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are You Sure You Want to Drop this employee?")) {
                confirm_value.value = "";
                confirm_value.value = "Yes";
                document.getElementById('<%= hidden1.ClientID %>').value = "Yes";
                showImage()
            } else {
                confirm_value.value = "";
                confirm_value.value = "No";
                document.getElementById('<%= hidden1.ClientID %>').value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Manage Employees (<asp:Label ID="lbl_employername" runat="server" Text=""></asp:Label>) - PAYE Input File
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

         


        <div class="portlet light">  
      <div class="portlet-title">
                 <div class="caption">Employee List</div>
           <div align="right">
                <asp:Button runat="server" ID="btnExport" class="btn btn-redtheme" Text="Download Employees Record " OnClick="btn_download_file" />
                        <asp:Button ID="btn_Add_Employees" Text="Add Employees" runat="server" CssClass="btn btn-theme" OnClick="btn_Add_Employees_Click"/>

                
          <div class="btn-group">
                                    <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Upload Input File <span class="caret"></span>
                                    </button>
              
                                    <ul class="dropdown-menu">
                                      
                                        <li>
                                           <asp:LinkButton runat="server" ID="lnk_btn_upload_inputfile_Click" OnClick="btn_upload_inputfile_Click" > New input File </asp:LinkButton>
                                        </li>
                                        
                                        <li>
                                          <asp:LinkButton runat="server" ID="LinkButton2" OnClick="btn_load_emp_Click" > Upload Previous Year’s Employees </asp:LinkButton>
                                        </li>
                                        
                                    </ul>
              </div>
                                               
              </div>
         </div>
            <div style="overflow:scroll;">
             <asp:GridView ID="grd_emp_list" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10"  PagerSettings-PageButtonCount="5"
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false" OnRowDataBound="grd_emp_list_RowDataBound">
       

         <Columns>

        <asp:BoundField DataField="taxpayerRIN" HeaderText="Employee RIN" />
        <asp:BoundField DataField="Name" HeaderText="Employee Name" />
        <asp:BoundField DataField="tp_tin" HeaderText="Employee TIN" />
        <asp:BoundField DataField="Tax_year" HeaderText="Tax Year" />  
        <asp:BoundField DataField="AnnualGross" HeaderText="Annual Gross" />
        <asp:BoundField DataField="Active" HeaderText="Employee Status" />             

                     
       <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />          
       <asp:BoundField DataField="CompanyRIN" HeaderText="Company RIN" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
    <%--   <asp:BoundField DataField="BusinessName" HeaderText="Employer Name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="BusinessRIN" HeaderText="Employer RIN" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="ContactAddress" HeaderText="Employer Address"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" /> 
       <asp:BoundField DataField="TaxMonth" HeaderText="Start Month" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="AssessmentRuleName" HeaderText="Assessment Rule" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  />          
       <asp:BoundField DataField="title" HeaderText="Title" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="firstname" HeaderText="First Name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="middlename" HeaderText="Middle Name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="lastname" HeaderText="SurName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="nationality" HeaderText="Nationality" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="Basic" HeaderText="Annual Basic" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="Rent" HeaderText="Annual Rent" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="trans" HeaderText="Annual Transport" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="AnnualUtility" HeaderText="Annual Utility" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="AnnualMeal" HeaderText="Annual Meal" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="Others" HeaderText="Other Allounces-Annual" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="LTG" HeaderText="Leave Transport-Annual" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="Pension" HeaderText="Pension" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="NHF" HeaderText="NHF" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="NHIS" HeaderText="NHIS" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
       <asp:BoundField DataField="AssessmentAmount" HeaderText="Assessment Amount"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />          
       <asp:BoundField DataField="Status" HeaderText="Assessed" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />--%>
       <asp:TemplateField HeaderText = "Actions">
        <ItemTemplate>
               
              <div class="btn-group">
                                                <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                       <%-- <a id="A1" data-toggle="modal" data-target="#divTaxPayerModal" onclick="gf();" runat="server">View Paye detail</a>--%>
                                                        <asp:LinkButton PostBackUrl= '<%#"~/ViewPayeInputFile_N.aspx?compRIN="+Eval("CompanyRIN")+"&empRIN="+Eval("taxpayerRIN")+"&empTIN="+Eval("tp_tin")+"&TaxYear="+Eval("tax_year")%>' runat="server" ID="LinkButton1"> View Paye Details </asp:LinkButton>
                                                       <%-- <asp:LinkButton runat="server" ID="lnkCustDetails" Text="Quick View" OnClick="lnkCustDetails_Click" />--%>
                                                    </li>
                                                   
                                                    <li>
                                                        <asp:LinkButton runat="server" PostBackUrl= '<%#"~/EditEmpPaye.aspx?compRIN="+Eval("CompanyRIN")+"&empRIN="+Eval("taxpayerRIN")+"&empTIN="+Eval("tp_tin")+"&TaxYear="+Eval("tax_year")%>' ID="lnkDetails"> Edit Paye Details </asp:LinkButton>
                                                    </li>

                                                    <li>
                                                         <asp:LinkButton runat="server" ID="lnk_drop_employee" OnClick="btn_drop_employee_Click" OnClientClick="Confirm_drop_emp()"> Drop Employee </asp:LinkButton>
                                                    </li>


                                                </ul>
                                            </div>
        </ItemTemplate>
        </asp:TemplateField>

         </Columns>
     
         <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView>
                   <div id="div_loading" runat="server" style="display:none;margin-top: -10%;margin-left: 10%;position: fixed; z-index:1;text-align:center;">
            <img id="img_load" runat="server" src="~/images/Pulsating circle.gif" />
            <p id="sync_data" runat="server">We are processing you request</p>
        </div>
                <input type="hidden" runat="server" value="" id="hidden1" />
                <div style="margin-top:-5px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom"></asp:Label> - <asp:Label runat="server" ID="lblpageto"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal"></asp:Label> entries</div>
                </div>

            <div align="center">
                <br />
                <table>
           <tr align="center">
                    <td colspan="3" style="text-align: right;display:none;"><asp:Button ID="btn_compute" Text="Compute" runat="server" CssClass="btn btn-theme" OnClick="btn_compute_Click" Visible="false" /></td>
               <td colspan="3" style="text-align: right;"><asp:Button ID="btnBack" Text="Back" runat="server" CssClass="btn btn-theme" OnClick="btnBack_Click" /></td>
                </tr>     
                 </table></div>
           
               </div>


        


        <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Tax Payer Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                       
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer RIN </label>
                                <div id="tax_payer_rin"></div>
                            </div>
                        </div>
                     
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Name</label>
                                <div id="tax_payer_name" ></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Anual Gross</label>
                                <div id="annual_gross"></div>
                            </div>
                        </div>
                       
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Rent</label>
                                <div id="txt_rent"></div>
                            </div>
                        </div>
                      
                          <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Transport</label>
                                <div id="txt_trans"></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Pension</label>
                                <div id="txt_pension"></div>
                            </div>
                        </div>
                      
                          <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">NHF</label>
                                <div id="txt_NHF"></div>
                            </div>
                        </div>
                      
                          <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">NHIS</label>
                                <div id="txt_NHIS"></div>
                            </div>
                        </div>
                      

                    </div>
                </div>
            </div>
        </div>
    </div>
       </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

