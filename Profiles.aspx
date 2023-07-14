<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profiles.aspx.cs" Inherits="Profiles" %>

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
        $(function () {
            var gridId = "<%= grd_profile.ClientID %>";
            var rowClickEvent = "#" + gridId + " tr"
            var current = "";

            $("#" + gridId).on("click", "span.close", function () {
                //Remove the row when user click on X
                $(this).parent().parent().empty();
            });

            $(rowClickEvent).click(function () {
                //Add row containing aditional info when user click on a row inside the grid view
                var row = this;

               // $("#tax_payer_rin").text(row.children[1].innerHTML);
               // $("#asset_RIN").text(row.children[1].innerHTML);
                $("#ProfileReferenceNo").text(row.children[0].innerHTML);
                $("#ProfileDescription").text(row.children[1].innerHTML);
                //$("#TaxPayerRoleName").text(row.children[2].innerHTML);
              


                // current = name + surname;
                //alert(comp_name.html);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Search Profile - Individual
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-title">
    <div class="caption">
       Search Profile - Individual        
    </div>
        </div>

      <div>
            <table class="table borderless" style="width:45% !important; border:none !important;">
                <tr>
                    <td>Profile Ref. No.:</td> <td></td><td><asp:TextBox ID="txt_ref_no" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Asset RIN:</td> <td></td><td><asp:TextBox ID="txt_asset_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
               

                <tr>
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click"/></td>
                </tr>

            </table>
        </div>
        <br />

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
        <div class="portlet light">  
      <div class="portlet-title">
                 <div class="caption">Profiles</div>
           <div class="actions">
                                <a href="#" class="btn btn-redtheme"> Add New Profile </a>
                            </div>
         </div>
            <div>
             <asp:GridView ID="grd_profile" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10"  PagerSettings-PageButtonCount="5"
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false">
       

         <Columns>

         
         
       <asp:BoundField DataField="ProfileReferenceNo" HeaderText="ProfileReferenceNo"  />
       <%-- <asp:BoundField DataField="TaxPayerRIN" HeaderText="Tax-Payer RIN" />--%>
       <%-- <asp:BoundField DataField="AssetRIN" HeaderText="Asset RIN" />--%>
                 <%--  <asp:BoundField DataField="AssetTypeName" HeaderText="Asset Type Name"  />--%>
        
           <%--   <asp:BoundField DataField="TaxPayerRoleName" HeaderText="TaxPayerRoleName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />--%>
              
              <asp:BoundField DataField="ProfileDescription" HeaderText="ProfileDescription" />
        
             
             <asp:TemplateField HeaderText = "Actions">
             <ItemTemplate>
               
              <div class="btn-group">
                                                <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <%--<a data-toggle="modal" data-target="#divTaxPayerModal" runat="server">Quick View</a>--%>

                                                        <asp:LinkButton data-toggle="modal" data-target="#divTaxPayerModal" runat="server" ID="lnkCustDetails" Text="Quick View" OnClick="lnkCustDetails_Click" />
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
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Profile In Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Type</label>
                                <div>Individual</div>
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
                                <label class="control-label control-label-static bold">Profile Reference No.</label>
                                <div id="ProfileReferenceNo" ></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Profile Description</label>
                                <div id="ProfileDescription"></div>
                            </div>
                        </div>
                       
                     <%--   <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">TaxPayer Role Name</label>
                                <div id="TaxPayerRoleName"></div>
                            </div>
                        </div>--%>
                      
                      
                    </div>
                </div>
            </div>
        </div>
    </div>
       </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

