<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssessmentList.aspx.cs" Inherits="AssessmentList" %>

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
              var gridId = "<%= grd_rules.ClientID %>";
              var rowClickEvent = "#" + gridId + " tr"
              var current = "";

              $("#" + gridId).on("click", "span.close", function () {
                  //Remove the row when user click on X
                  $(this).parent().parent().empty();
              });

              $(rowClickEvent).click(function () {
                  //Add row containing aditional info when user click on a row inside the grid view
                  var row = this;

                  $("#ItemRef").text(row.children[0].innerHTML);
                  $("#ItemName").text(row.children[1].innerHTML);
                  $("#RevStream").text(row.children[2].innerHTML);
                  $("#RevSubStream").text(row.children[3].innerHTML);

                  $("#ItemCategory").text(row.children[4].innerHTML);


                  // current = name + surname;
                  //alert(comp_name.html);
              });
          });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
   Assessment List
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <div class="portlet-title">
        <div class="caption">
        Assessments
        
    </div>
        </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
        <div class="portlet light">  
      

            <div>

             <asp:GridView ID="grd_rules" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" 
                 CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false" PagerSettings-PageButtonCount="5">
          <Columns>

         
         
        <asp:BoundField DataField="AssessmentItemReferenceNo" HeaderText="Item RefNo." />
        <asp:BoundField DataField="AssessmentItemName" HeaderText="Item Name" />
        <asp:BoundField DataField="RevenueStreamName" HeaderText="Revenue Stream" />
             <asp:BoundField DataField="RevenueSubStreamName" HeaderText="Revenue Sub Stream" />
             <asp:BoundField DataField="AssessmentItemCategoryName" HeaderText="Item Category" />

         <asp:BoundField DataField="AgencyName" HeaderText="AgencyName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
              <asp:BoundField DataField="ComputationName" HeaderText="ComputationName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
             
             
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
                 <EmptyDataTemplate>
                    <table class="table table-bordered v-middle dataTable no-footer dtr-inline" id="tblBillList" role="grid" aria-describedby="tblBillList_info">
                                <thead class="red-th">
                                    <tr role="row">
                                        <th class="sorting" tabindex="0" aria-controls="tblBillList" rowspan="1" colspan="1"  aria-label="Date: activate to sort column ascending">Date</th>
                                        <th class="sorting" tabindex="0" aria-controls="tblBillList" rowspan="1" colspan="1"  aria-label="Bill Type: activate to sort column ascending">Bill Type</th>
                                        <th class="sorting" tabindex="0" aria-controls="tblBillList" rowspan="1" colspan="1"  aria-label="Bill ID: activate to sort column ascending">Bill ID</th>
                                        <th class="sorting" tabindex="0" aria-controls="tblBillList" rowspan="1" colspan="1"  aria-label="Bill Amount: activate to sort column ascending">Bill Amount</th>
                                        <th class="sorting" tabindex="0" aria-controls="tblBillList" rowspan="1" colspan="1"  aria-label="Bill Status: activate to sort column ascending">Bill Status</th>
                                        <th class="action-th sorting_disabled" rowspan="1" colspan="1" aria-label="Action">Action</th>

                                    </tr>
                                </thead>
                                
                            </table>
                 </EmptyDataTemplate>
      <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView>
                <div style="margin-top:0px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom" Text="0"></asp:Label> - <asp:Label runat="server" ID="lblpageto" Text="0"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal" Text="0"></asp:Label> entries</div>
          </div>
               </div>

        <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Assessment Item Detail</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                         <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Assessment Item RefNo.</label>
                                <div id="ItemRef"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Assessment Item Name</label>
                                <div id="ItemName"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Assessment Revenue Stream</label>
                                <div id="RevStream"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Revenue Sub Stream</label>
                                <div id="RevSubStream" ></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Item Category</label>
                                <div id="ItemCategory"></div>
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

