<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="generatePAYE.aspx.cs" Inherits="generatePAYE" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Corporate List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="portlet-title">
    <div class="caption">
       Search Company
    </div>
</div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

         <div>
            <table class="table borderless" style="width:45% !important; border:none !important;">
                <tr>
                    <td>Tax Payer RIN:</td> <td></td><td><asp:TextBox ID="txt_tax_payer_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Tax Payer Name:</td> <td></td><td><asp:TextBox ID="txt_tax_payer_name" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
               

                <tr>
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click"/></td>
                </tr>

            </table>
        </div>


        <div class="portlet light">  
      <div class="portlet-title">
                 <div class="caption">corporate List</div>
          
         </div>
            <div>
             <asp:GridView ID="grd_Company" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10"  PagerSettings-PageButtonCount="5"
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false">
       

         <Columns>
                
       <asp:BoundField DataField="CompanyName" HeaderText="Employer Name"  />          
       <asp:BoundField DataField="ContactAddress" HeaderText="Employer Address"  />          
        <asp:BoundField DataField="CompanyRIN" HeaderText="Employer RIN" />   
      

               
   
             
             <asp:TemplateField HeaderText = "Actions" >
             <ItemTemplate>
               
              <div class="btn-group">
                                                <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                      <li>
                                                        <asp:LinkButton PostBackUrl= '<%#"~/generatePayeList.aspx?compRIN="+Eval("CompanyRIN")%>' runat="server" ID="lnkDetails"> View Details </asp:LinkButton>
                                                    </li>
                                                   
                                                </ul>
                                            </div>
        </ItemTemplate>
        </asp:TemplateField>

         </Columns>
       
       
       
         <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView>

                <div style="margin-top:-60px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom"></asp:Label> - <asp:Label runat="server" ID="lblpageto"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal"></asp:Label> entries</div>
                </div>
          
               </div>

        <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
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
                                <div id="tax_payer_name" ></div>
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
       </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

