<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusinessDetails.aspx.cs" Inherits="BusinessDetails" %>

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
         function gf() {
             $(function () {
                 var gridId = "<%= grd_ind.ClientID %>";
                var rowClickEvent = "#" + gridId + " tr"
                var current = "";

                $("#" + gridId).on("click", "span.close", function () {
                    //Remove the row when user click on X
                    $(this).parent().parent().empty();
                });

                $(rowClickEvent).click(function () {
                    //Add row containing aditional info when user click on a row inside the grid view
                    var row = this;
                                 
                    $("#txt_asset_type").text(row.children[4].innerText);
                    $("#txt_asset_LGA").text(row.children[5].innerText);
                    $("#tax_payer_type").text(row.children[0].innerText);

                    $("#tax_payer_name").text(row.children[2].innerText);


                    $("#tax_payer_RIN").text(row.children[1].innerText);

                    $("#tax_payer_role").text(row.children[3].innerText);


                   

                });
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
      <asp:Label ID="lbl_main_head" runat="server">Business Asset Details</asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="portlet light">
        <div class="portlet-title">
    <div class="caption">
       
        <asp:Label ID="lbl_head1" runat="server">Business Asset Information</asp:Label>
    </div>
        </div>
           
    <div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
                <tr>
                    <td ><b>Business RIN:</b>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="txt_Business_RIN" runat="server"></asp:Label></td><td ><b>Business Name:&nbsp;&nbsp;&nbsp;&nbsp; </b><asp:Label ID="txt_business_name" runat="server" ></asp:Label></td>
                        <td></td>
                </tr>
               
                <tr>
                    <td ><b>Address:&nbsp;&nbsp;&nbsp; </b><asp:Label ID="txt_Address" runat="server"></asp:Label></td> <td><b>Sector Name:&nbsp;&nbsp;&nbsp;&nbsp; </b><asp:Label ID="txt_Sector" runat="server"></asp:Label></td>
                        <td></td>
                </tr>
             
            </table>
        </div> </div>




          <div class="portlet light">
         <div class="portlet-title">
    <div class="caption">
       Associated Tax Payers
        
    </div>
        </div>
            
         <div>
             <div>
    
        <asp:GridView ID="grd_ind" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" 
        CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" PagerSettings-PageButtonCount="5">
       

         <Columns>
                <asp:BoundField DataField="TaxPayerTypeName" HeaderText="Tax Payer Type" />
     
        <asp:BoundField DataField="TaxPayerRINNumber" HeaderText="Tax Payer RIN" />
     
         <asp:BoundField DataField="TaxPayerName" HeaderText="Tax Payer Name"/>
     
               <asp:BoundField DataField="TaxPayerRoleName" HeaderText="TaxPayer Role"/>

 <asp:BoundField DataField="AssetTypeName" HeaderText="AssetTypeName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
 <asp:BoundField DataField="AssetLGA" HeaderText="AssetLGA" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>

             <asp:TemplateField HeaderText = "Actions">
             <ItemTemplate>
               
              <div class="btn-group">
                                                <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a id="A1" data-toggle="modal" data-target="#divTaxPayerModal" onclick="gf();" runat="server">Quick View</a>

                                                        
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton PostBackUrl= '<%#"~/TaxPayerDetails.aspx?name="+Eval("TaxPayerName")+"|"+Eval("TaxPayerTypeName")+"|"+""+"|"+""+"|"+Eval("TaxPayerRINNumber")%>' runat="server" ID="lnkDetails"> Tax Payer Details </asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
        </ItemTemplate>
        </asp:TemplateField>
         </Columns>
       
         <HeaderStyle CssClass="GridHeader" />
         <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
        </asp:GridView>
       
            <div style="margin-top:-60px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom"></asp:Label> - <asp:Label runat="server" ID="lblpageto"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal"></asp:Label> entries</div>
       </div>
        </div>  

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
                                <label class="control-label control-label-static bold">Asset Type Name</label>
                                <div id="txt_asset_type"></div>
                            </div>
                        </div>
                         <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Asset LGA</label>
                                <div id="txt_asset_LGA"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Type</label>
                                <div id="tax_payer_type"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Name </label>
                                <div id="tax_payer_name"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer RIN </label>
                                <div id="tax_payer_RIN"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Role</label>
                                <div id="tax_payer_role" ></div>
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

