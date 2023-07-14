<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="generatePayeList.aspx.cs" Inherits="generatePayeList" %>

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
    Employees List - Tax Calculation
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-title">
    <div class="caption">
       Search Assessment Rules
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
                 <div class="caption">Employee List</div>
          
         </div>
            <div style="overflow:scroll;">
             <asp:GridView ID="grd_emp_list" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10"  PagerSettings-PageButtonCount="5"
        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false">
       

         <Columns>
                
       <asp:BoundField DataField="CompanyName" HeaderText="Company Name"  />          
                
        <asp:BoundField DataField="CompanyRIN" HeaderText="Company RIN" />
         <asp:BoundField DataField="BusinessName" HeaderText="Employer Name" />
         <asp:BoundField DataField="BusinessRIN" HeaderText="Employer RIN" />
                         
       <asp:BoundField DataField="ContactAddress" HeaderText="Employer Address"  /> 
             
        <asp:BoundField DataField="TaxMonth" HeaderText="Start Month" />
       <asp:BoundField DataField="AssessmentRuleName" HeaderText="Assessment Rule" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  />          
       
                    <asp:BoundField DataField="title" HeaderText="Title" />
       <asp:BoundField DataField="firstname" HeaderText="First Name" />
        <asp:BoundField DataField="middlename" HeaderText="Middle Name" />
        <asp:BoundField DataField="lastname" HeaderText="SurName" />
        <asp:BoundField DataField="nationality" HeaderText="Nationality" />
       
                    <asp:BoundField DataField="taxpayerRIN" HeaderText="Employee RIN" />
                    <asp:BoundField DataField="tp_tin" HeaderText="Employee TIN" />

       <asp:BoundField DataField="Basic" HeaderText="Annual Basic" />
       <asp:BoundField DataField="Rent" HeaderText="Annual Rent" />
       <asp:BoundField DataField="trans" HeaderText="Annual Transport" />
       <asp:BoundField DataField="AnnualUtility" HeaderText="Annual Utility" />
       <asp:BoundField DataField="AnnualMeal" HeaderText="Annual Meal" />
       <asp:BoundField DataField="Others" HeaderText="Other Allounces-Annual" />
      
              <asp:BoundField DataField="LTG" HeaderText="Leave Transport-Annual" />
       
       
       <asp:BoundField DataField="AnnualGross" HeaderText="Annual Gross" />
       <asp:BoundField DataField="Pension" HeaderText="Pension" />
       <asp:BoundField DataField="NHF" HeaderText="NHF" />
       <asp:BoundField DataField="NHIS" HeaderText="NHIS" />
      

              <asp:BoundField DataField="AssessmentAmount" HeaderText="Assessment Amount"  />          
       <asp:BoundField DataField="Status" HeaderText="Assessed" />
             
             <asp:TemplateField HeaderText = "Actions" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" >
             <ItemTemplate>
               
              <div class="btn-group">
                                                <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a id="A1" data-toggle="modal" data-target="#divTaxPayerModal" onclick="gf();" runat="server">Quick View</a>

                                                       <%-- <asp:LinkButton runat="server" ID="lnkCustDetails" Text="Quick View" OnClick="lnkCustDetails_Click" />--%>
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

            <div align="center">
                <br />
                <table>
           <tr align="center">
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_compute" Text="Compute" runat="server" CssClass="btn btn-theme" OnClick="btn_compute_Click" /></td>
                </tr>     
                 </table></div>
           
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

