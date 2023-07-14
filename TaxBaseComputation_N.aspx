<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TaxBaseComputation_N.aspx.cs" Inherits="TaxBaseComputation_N" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Tax Base Computation
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
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
  <table>
        
        <tr>
            <td>
                <asp:GridView ID="grdempcollection" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" 
        AutoGenerateColumns="False"  PagerSettings-PageButtonCount="5"
        CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" OnPageIndexChanging="grdempcollection_PageIndexChanging">
       
        <Columns>

        <asp:BoundField DataField="EmployerRIN" HeaderText="Employer RIN" />
        <asp:BoundField DataField="EmployerName" HeaderText="Employer Name" />
        <asp:BoundField DataField="Asset" HeaderText="Asset (Business)" />

        <asp:BoundField DataField="Rule" HeaderText="Rule"  />
        <asp:BoundField DataField="Item" HeaderText="Item"/>
        <asp:BoundField DataField="TaxYear" HeaderText="Tax Year"/>
        <asp:BoundField DataField="Month" HeaderText="Month"/>    

        <asp:BoundField DataField="TaxBaseAmount" HeaderText="Tax Base Amount"/>
        <asp:BoundField DataField="TaxAmount" HeaderText="Tax Amount"/>
         </Columns>

        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
       
        </asp:GridView>
            </td>
        </tr>
  </table>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

