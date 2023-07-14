<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PaymentInterface.aspx.cs" Inherits="PaymentInterface" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
   Payment Interface
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div>
        <div id="divmsg" class="" runat="server" style="display:none"></div>
          <table  id="tbl_grd" runat="server" class="table borderless" >
            <table align="center">   
               <tr id="tr_dpd" runat="server" >
                 <td   align="right"> Company Name:</td>
                   
            <td >
                <asp:DropDownList ID="dpd_company" CssClass="form-control" runat="server" OnSelectedIndexChanged="dpd_company_SelectedIndexChanged" Width="200px" AutoPostBack="true">
                </asp:DropDownList>                                
            </td>
                   </tr>
              <tr id="tr2" runat="server" style="text-align:center;">
                 <td align="right"> Business Name:</td>
            <td align="left">
                <asp:DropDownList ID="drpBusiness" Width="200px" runat="server" CssClass="form-control">
                </asp:DropDownList>
                     <asp:Label Text="NA" Visible="false"  runat="server" Width="200px" ID="lblnabusiness" CssClass="form-control"></asp:Label>
             </td>
                 </tr>
              <tr id="tr3" runat="server">
                  <td align="center" colspan="2"><asp:Button ID="btn_Search" runat="server" Text="Search" CssClass="btn btn-redtheme" OnClick="btn_Search_Click"/></td>
              </tr>
                </table>
            <tr style="text-align:center;">
            <td style="text-align: center;" colspan="2">          
               <asp:GridView ID="grvEmployee" runat="server" AutoGenerateColumns="False" Width="100%"
                      AllowPaging="True" PageSize="8" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader"
                       style="Width:100%; overflow: scroll;"                     
                         OnRowCreated="grvEmployee_RowCreated" OnRowDataBound="grvEmployee_RowDataBound" OnSelectedIndexChanged="grvEmployee_SelectedIndexChanged"  
                   EmptyDataRowStyle-CssClass="alert alert-warning"> 
                          
                 <Columns>
                      <asp:BoundField DataField="company_rin" HeaderText="Company RIN No." />
                      <asp:BoundField DataField="company_name" HeaderText="Company Name" />
                      <asp:BoundField DataField="assessment_ref" HeaderText="Assessment Ref. No." />
                      <asp:BoundField DataField="assessment_child_ref" HeaderText="Assessment Child Ref. No." />
                     <asp:BoundField DataField="MonthTax" HeaderText="Month" />
                      <asp:BoundField DataField="YearTax" HeaderText="Year" />
                      <asp:BoundField DataField="Amount" HeaderText="Amount" />
                      <asp:BoundField DataField="Status" HeaderText="Status" />
                   </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
<EmptyDataTemplate>No Record Available</EmptyDataTemplate>
        </asp:GridView>
                


                </td>
                </tr>

              <tr>
                  
             <td style="text-align: center; height:50px; display:none;" colspan="2" align="Center">
                <span class="control-label bold"> Amount To Paid:</span>  <asp:Label ID="lbl_bal" runat="server" Text="" Visible="false" CssClass="control-label bold"></asp:Label>

             </td>

                 
                  </tr>

             <tr>
                  
             <td style="text-align: center; height:50px" colspan="2" align="Center">
              <asp:Button ID="btn_Pay" runat="server" Text="Pay" CssClass="btn btn-redtheme" OnClick="btn_Pay_Click" Visible="false"  />
                

                 </td></tr>
                         
        </table>
          </div>
</asp:Content>
