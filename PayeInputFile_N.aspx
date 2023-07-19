<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayeInputFile_N.aspx.cs" EnableEventValidation="false" Inherits="PayeInputFile_N" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <style type="text/css">
        .hiddencol {
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
      
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to submit selected Files for Coding?")) {
                confirm_value.value = "";
                confirm_value.value = "Yes";
                document.getElementById('<%= hidden1.ClientID %>').value = "Yes";
            } else {
                confirm_value.value = "";
                confirm_value.value = "No";
                document.getElementById('<%= hidden1.ClientID %>').value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }


        function Confirm_drop_emps() {

            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are You Sure You Want to Drop Employees Record?")) {
                confirm_value.value = "";
                confirm_value.value = "Yes";
                document.getElementById('<%= hidden1.ClientID %>').value = "Yes";
                showImage();
            } else {
                confirm_value.value = "";
                confirm_value.value = "No";
                document.getElementById('<%= hidden1.ClientID %>').value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>




    <%--  <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%=txt_employer_RIN.ClientID %>").keyup(function () {
                 if ($(this).val().length == 4) {
                     
                 }
             });
             
         });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    Paye Input File
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-title" style="display: none;">
        <div class="caption">
            Search Company
        </div>
    </div>
    <div id="div_loading" runat="server" style="display: none; margin-top: 15%; margin-left: 20%; position: fixed; z-index: 1; text-align: center;">
        <img id="img_load" runat="server" src="~/images/Pulsating circle.gif" />
        <p id="sync_data" runat="server">We are processing you request</p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">Paye Input File (Corporate List)</div>
                    <div align="right">
                        <asp:Button ID="btn_file_selected" Text="File Selected" runat="server" CssClass="btn btn-theme" OnClick="btn_file_selected_Click" OnClientClick="Confirm()" />
                    
                    </div>
                </div>
                <div>
                    <table class="table borderless" style="width: 100% !important; border: none !important;">
                        <tr>
                            <td>Tax Year:</td>
                           
                            <td>
                                <asp:DropDownList ID="txt_tax_year" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="btn_search_Click"></asp:DropDownList></td>
                            <td>Company RIN:</td>
                            
                            <td>
                                <asp:TextBox ID="txt_cmp_RIN" runat="server" CssClass="form-control" placeholder="Company RIN"></asp:TextBox>

                            </td>
                            <td>Business RIN:</td>
                           
                            <td>
                                <asp:TextBox ID="txt_employer_RIN" runat="server" CssClass="form-control" placeholder="Business RIN"></asp:TextBox>

                            </td>
                           
                            <td colspan="3" style="text-align: right;">
                                <asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click" Visible="true" />

                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>Employer Name:</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txt_employer_name" runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr style="display: none;">
                            <td>Employer TIN:</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txt_employer_TIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr style="display: none;">
                            <td>Business RIN:</td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txt_business_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>




                    </table>
                </div>

                <div>
                    <asp:GridView ID="grd_Company" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" PagerSettings-PageButtonCount="5"
                        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false" OnRowDataBound="grd_Company_RowDataBound">


                        <Columns>
                            <asp:BoundField DataField="CompanyRIN" HeaderText="Employer RIN" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Employer Name" />
                            <%-- <asp:BoundField DataField="CompanyTIN" HeaderText="Employer TIN" />   --%>
                            <asp:BoundField DataField="Tax_Year" HeaderText="Tax Year" />
                            <asp:BoundField DataField="BusinessRIN" HeaderText="Business RIN" />
                            <asp:BoundField DataField="BusinessName" HeaderText="Business Name" Visible="false" />


                            <asp:BoundField DataField="EmployeeCount" HeaderText="Employee Count" />

                            <asp:BoundField DataField="Status"  HeaderText="Status (Filed/UnFiled)" />

                            
                            <asp:TemplateField HeaderText="CheckBox">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkchkbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            Action <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu">
                                            
                                            <li class='<%= Session["roleId"].ToString() != "1" ? "show" : "hide" %>'>
                                                <asp:LinkButton PostBackUrl='<%#"~/ShowLegacyDataEmpInput.aspx?compRIN="+Eval("CompanyRIN")+"&year="+Eval("Tax_Year")+"&redirect=I&Employer="+Eval("CompanyName")+"&BusinessRIN="+Eval("BusinessRIN")+"&FiledStatus="+Eval("Status")+""%>' runat="server" ID="lnkDetails"> Manage Employees </asp:LinkButton>
                                            </li>
                                            
                                            <li class='<%= Session["roleId"].ToString() != "1" ? "show" : "hide" %>'>
                                                <asp:LinkButton runat="server" ID="lnksendtoinputfile" OnClick="btn_file_selected_Click" OnClientClick="Confirm()"> Submit Filing </asp:LinkButton>
                                            </li>

                                           
                                            <li class='<%= Session["roleId"].ToString() != "1" ? "show" : "hide" %>'>
                                                <asp:LinkButton runat="server" ID="lnk_drop_employees" OnClick="btn_drop_employees_Click" OnClientClick="Confirm_drop_emps()"> Drop Employees </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <%-- <Columns>
             <asp:BoundField DataField="CompanyRIN" HeaderText="Employer RIN" /> 
             <asp:BoundField DataField="CompanyName" HeaderText="Employer Name" />           
             <asp:BoundField DataField="CompanyTIN" HeaderText="Employer TIN" />           
        <asp:BoundField DataField="Tax_Year" HeaderText="Tax Year"  />  
                <asp:BoundField DataField="BusinessRIN" HeaderText="Business RIN" />      
         <asp:BoundField DataField="BusinessName" HeaderText="Business Name" Visible="false" />
       
             
       <asp:BoundField DataField="totalcount" HeaderText="Employee Count"  />          
         
                 <asp:BoundField DataField="FiledStatus" HeaderText="Status (Filed/UnFiled)"  />          
         
         <asp:TemplateField HeaderText="CheckBox">
             <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkchkbox"/>
             </ItemTemplate>
         </asp:TemplateField>
       <asp:TemplateField HeaderText = "Actions" >
             <ItemTemplate>
       <div class="btn-group">
                                                <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                      <li>
                                                        <asp:LinkButton PostBackUrl= '<%#"~/ShowLegacyDataEmpInput.aspx?compRIN="+Eval("CompanyRIN")+"&year="+Eval("Tax_Year")+"&redirect=I&Employer="+Eval("CompanyName")+"&BusinessRIN="+Eval("BusinessRIN")+"&FiledStatus="+Eval("FiledStatus")+""%>' runat="server" ID="lnkDetails"> Manage Employees </asp:LinkButton>
                                                    </li>
                                                   <li>
                                                       <asp:LinkButton runat="server" ID="lnksendtoinputfile" OnClick="btn_file_selected_Click" OnClientClick="Confirm()"> Submit Filing </asp:LinkButton>
                                                   </li>

                                                      <li>
                                                         <asp:LinkButton runat="server" ID="lnk_drop_employees" OnClick="btn_drop_employees_Click" OnClientClick="Confirm_drop_emps()"> Drop Employees </asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
        </ItemTemplate>
        </asp:TemplateField>

         </Columns>--%>



                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />

                    </asp:GridView>
                    <input type="hidden" runat="server" value="" id="hidden1" />
                    <div style="margin-top: -60px; margin-left: 10px;" id="div_paging" runat="server">
                        Showing
                        <asp:Label runat="server" ID="lblpagefrom"></asp:Label>
                        -
                        <asp:Label runat="server" ID="lblpageto"></asp:Label>
                        entries of
                        <asp:Label runat="server" ID="lbltoal"></asp:Label>
                        entries
                    </div>
                </div>

            </div>

            <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">�</span></button>
                            <h4 class="modal-title" id="divTaxPayerModalLabel">Assessment - Rules Check Details</h4>
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
                                        <div id="tax_payer_name"></div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label control-label-static bold">Assessment Rule</label>
                                        <div id="tax_rule"></div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label control-label-static bold">Assessed</label>
                                        <div id="tax_assessed"></div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" runat="Server">
</asp:Content>

