<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssessmentQueue_N.aspx.cs" Inherits="AssessmentQueue_N" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Assessment Queue
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-title">
    <div class="caption">
       Assessment Queue
        </div>
        
    
        </div>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

           <div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
 <tr>
                    <td>Tax Year:</td> <td></td><td><asp:DropDownList ID="txt_tax_year" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="btn_search_Click"></asp:DropDownList></td>
     <td>Search:</td> <td></td><td><asp:TextBox ID="txt_employer_RIN" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="btn_search_Click" ></asp:TextBox></td>
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click" Visible="true"/></td>
                </tr>
              

               
               

            </table>
        </div>

        <div>
    <table>
        
        <tr>
            <td>
                <asp:GridView ID="grdAssessmentQueue" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="false"  PagerSettings-PageButtonCount="5" ShowHeaderWhenEmpty="true"
        CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" OnPageIndexChanging="grdAssessmentQueue_PageIndexChanging">
       
        <Columns>

        <asp:BoundField DataField="EmployerRIN" HeaderText="Employer RIN" />
        <asp:BoundField DataField="EmployerName" HeaderText="Employer Name" />
        <asp:BoundField DataField="Asset" HeaderText="Asset (Business)" />

        <asp:BoundField DataField="Rule" HeaderText="Rule"  />
        <asp:BoundField DataField="TaxMonthYear" HeaderText="Tax Month/Year"/>
        
        <asp:BoundField DataField="TaxBaseAmount" HeaderText="Assessed Amount(₦)"/>
        <asp:BoundField DataField="AssessmentNotes" HeaderText="Assessment Notes"/>
        
            <asp:BoundField DataField="Status" HeaderText="Status"/>
        <asp:BoundField DataField="AssessmentRef" HeaderText="Assessment Ref."/>
        
         </Columns>

        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView>
            </td>
        </tr>
  </table></div>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

