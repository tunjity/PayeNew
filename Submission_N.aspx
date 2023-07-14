<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Submission_N.aspx.cs" Inherits="Submission_N" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var gridId = "<%= grd_submissions.ClientID %>";
            var rowClickEvent = "#" + gridId + " tr"
            var current = "";

            $("#" + gridId).on("click", "span.close", function () {
                //Remove the row when user click on X
                $(this).parent().parent().empty();
            });

            $(rowClickEvent).click(function () {
                //Add row containing aditional info when user click on a row inside the grid view
                var row = this;

                
                $("#EmployerRIN").text(row.children[0].innerHTML);
                $("#EmployerName").text(row.children[1].innerHTML);
                $("#Asset").text(row.children[2].innerHTML);
                $("#Rule").text(row.children[3].innerHTML);
                $("#Item").text(row.children[4].innerHTML);
                $("#SAmt").text(row.children[5].innerHTML);


                // current = name + surname;
                //alert(comp_name.html);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Submissions
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-title">
    <div class="caption">
       Submissions
        </div>
        <div class="actions">
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-redtheme" Text="Add New Submission" OnClick="btnAdd_Click"/>
                                </div>
                            </div>
    
        </div>

     <div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
 <tr>
                    <td>Tax Year:</td> <td></td><td><asp:DropDownList ID="txt_tax_year" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="btn_search_Click"></asp:DropDownList></td>
     <td>Search:</td> <td></td><td><asp:TextBox ID="txt_employer_RIN" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="btn_search_Click" ></asp:TextBox></td>
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click" Visible="false"/></td>
                </tr>
              

               
               

            </table>
        </div>

    <div>
    <asp:GridView ID="grd_submissions" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="False"  PagerSettings-PageButtonCount="5"
        CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" OnPageIndexChanging="grd_submissions_PageIndexChanging">
       

         <Columns>

        <asp:BoundField DataField="TaxPayer" HeaderText="Employer RIN" />
        <asp:BoundField DataField="CompanyName" HeaderText="Employer Name" />
        <asp:BoundField DataField="Asset" HeaderText="Asset (Business)" />

        <asp:BoundField DataField="AssessmentRule" HeaderText="Rule"  />
        <asp:BoundField DataField="AssessmentItems" HeaderText="Item"/>

        <asp:BoundField DataField="TaxBaseAmount" HeaderText="Submitted Amount"/>
<asp:BoundField DataField="TaxYear" HeaderText="Tax Year" Visible="false"/>
<asp:BoundField DataField="SubmissionNotes" HeaderText="Submission Notes" Visible="false"/>

        <asp:TemplateField HeaderText = "Actions">
        <ItemTemplate>
         <div class="btn-group">
            <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
             Action <span class="caret"></span>
            </button>
               <ul class="dropdown-menu">
                 <li>
                     
                  <asp:LinkButton PostBackUrl= '<%#"~/Submissions_Action.aspx?TaxPayer="+Eval("TaxPayer")+"&CompanyName="+Eval("CompanyName")+"&Action=E&Asset="+Eval("Asset")+"&AssessmentRule="+Eval("AssessmentRule")+"&AssessmentItems="+Eval("AssessmentItems")+"&TaxBaseAmount="+Eval("TaxBaseAmount")+"&TaxYear="+Eval("TaxYear")+"&SubmissionNotes="+Eval("SubmissionNotes")+""%>'  runat="server" ID="lnkDetailsEdit"> Edit Submisisons </asp:LinkButton>
                 </li>
                   <li>
                  <asp:LinkButton data-toggle="modal" data-target="#divTaxPayerModal" runat="server" ID="lnkSubmissionDetails"> View Submissions </asp:LinkButton>

                       
                 </li>
               </ul>
         </div>
        </ItemTemplate>
        </asp:TemplateField>

        
       
         </Columns>

        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView></div>

    <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Submissions In Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Type</label>
                                <div>Corporats</div>
                            </div>
                        </div>
                      <%--  <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer RIN </label>
                                <div id="tax_payer_rin"></div>
                            </div>
                        </div>--%>
                     
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Employer RIN</label>
                                <div id="EmployerRIN" ></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Employer Name</label>
                                <div id="EmployerName"></div>
                            </div>
                        </div>
                       
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Asset</label>
                                <div id="Asset"></div>
                            </div>
                        </div>
                      
                          <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Rule</label>
                                <div id="Rule"></div>
                            </div>
                        </div>
                      
                          <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Item</label>
                                <div id="Item"></div>
                            </div>
                        </div>

                          <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Summited Amount</label>
                                <div id="SAmt"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

