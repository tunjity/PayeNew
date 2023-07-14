<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssessmentRules.aspx.cs" Inherits="AssessmentRules" %>

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

                $("#AssessmentRuleCode").text(row.children[0].innerHTML);
                $("#AssessmentRuleName").text(row.children[1].innerHTML);
                $("#RuleRunName").text(row.children[2].innerHTML);
                $("#PaymentFrequencyName").text(row.children[3].innerHTML);
                


                // current = name + surname;
                //alert(comp_name.html);
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Search Assessment Rules
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-title">
    <div class="caption">
       Search Assessment Rules
        
    </div>
        </div>

       <div>
            <table class="table borderless" style="width:45% !important; border:none !important;">
                <tr>
                    <td>Rule Code:</td> <td></td><td><asp:TextBox ID="txt_rule_code" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Rule Name:</td> <td></td><td><asp:TextBox ID="txt_rule_name" runat="server" CssClass="form-control"></asp:TextBox></td>
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
                 <div class="caption">Assessment Rules List</div>
           <div class="actions">
                                <a href="#" class="btn btn-redtheme"> Add New Rule </a>
                            </div>
         </div>

            <div>

             <asp:GridView ID="grd_rules" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" 
                 CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false" PagerSettings-PageButtonCount="5">
       

         <Columns>

         
         
        <asp:BoundField DataField="AssessmentRuleCode" HeaderText="Assessment Rule Code" />
        <asp:BoundField DataField="AssessmentRuleName" HeaderText="Assessment Rule Name" />
        <asp:BoundField DataField="RuleRunName" HeaderText="Rule Run Name" />
             <asp:BoundField DataField="PaymentFrequencyName" HeaderText="Payment Frequency Name" />

         <asp:BoundField DataField="TaxYear" HeaderText="TaxYear" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
              <asp:BoundField DataField="PaymentOptionName" HeaderText="PaymentOptionName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
             
             
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
                <div style="margin-top:0px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom"></asp:Label> - <asp:Label runat="server" ID="lblpageto"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal"></asp:Label> entries</div>
          </div>
               </div>

        <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Assessment Rule</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Assessment Rule Code</label>
                                <div id="AssessmentRuleCode"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Assessment Rule Name</label>
                                <div id="AssessmentRuleName"></div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Rule Run Name</label>
                                <div id="RuleRunName" ></div>
                            </div>
                        </div>
                      
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Payment Frequency Name</label>
                                <div id="PaymentFrequencyName"></div>
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

