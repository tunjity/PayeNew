<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayeSubmissions.aspx.cs" Inherits="PayeSubmissions" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Search tax payer - Legacy Submissions
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-title">
    <div class="caption">
       Search tax payer - Legacy Submissions
        
    </div>
        </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div>
            <table class="table borderless" style="width:45% !important; border:none !important;">
                
                <tr>
                    <td>Tax Payer TIN:</td> <td></td><td><asp:TextBox ID="txt_tin" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tax Payer RIN:</td> <td></td><td><asp:TextBox ID="txt_payer_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Business RIN:</td> <td></td><td><asp:TextBox ID="txt_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click"/></td>
                </tr>

            </table>
        </div>
       <div class="portlet light">  
      <div class="portlet-title">
                 <div class="caption">List of Legacy Submissions Details</div>
         
         </div>
            </div>
       
        <div style="overflow:scroll;"> 
     
    <asp:GridView ID="grd_legacy_submissions" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"  PagerSettings-PageButtonCount="5"
        CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" OnRowDataBound="grd_legacy_submissions_RowDataBound">
       

         <Columns>

        <asp:BoundField DataField="LSID" HeaderText="LSID" />
        <asp:BoundField DataField="Tp_TIN" HeaderText="TIN" />
        <asp:BoundField DataField="TaxPayerRIN" HeaderText="TaxPayer RIN" />

        <asp:BoundField DataField="Tax_year" HeaderText="Tax Year"  />
        <asp:BoundField DataField="Basic" HeaderText="Basic"/>

        <asp:BoundField DataField="Rent" HeaderText="Rent"/>
        <asp:BoundField DataField="Trans" HeaderText="Transport" />

        <asp:BoundField DataField="LTG" HeaderText="LTG" />
        <asp:BoundField DataField="Pension" HeaderText="Pension"/>
             
        <asp:BoundField DataField="NHF" HeaderText="NHF"/>
        <asp:BoundField DataField="NHIS" HeaderText="NHIS"/>
        
        <asp:BoundField DataField="BusinessRIN" HeaderText="Business RIN"/>
        
       
         </Columns>

        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView>

            <div style="margin-top:-60px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom"></asp:Label> - <asp:Label runat="server" ID="lblpageto"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal"></asp:Label> entries</div>
         
            </div>

        <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Corporate Tax Payer Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Type</label>
                                <div>Corporate</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Company Name </label>
                                <div id="comp_name"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">TIN </label>
                                <div id="tin"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Phone No.</label>
                                <div id="Phone1" ></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Email Address</label>
                                <div id="email1"></div>
                            </div>
                        </div>
                       
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Office</label>
                                <div id="taxoffice"></div>
                            </div>
                        </div>
                      
                       
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Contact Address </label>
                                <div id="address11"></div>
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

