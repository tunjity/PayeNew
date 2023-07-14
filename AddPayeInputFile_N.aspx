<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPayeInputFile_N.aspx.cs" Inherits="AddPayeInputFile_N" %>

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
    Add Paye Input File
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

         <div style="width:100%;">
            <table class="table borderless" style="width:45% !important; border:none !important;">
                <tr>
                    <td>Employer Name:</td> <td></td><td><asp:DropDownList ID="dpd_employer_RIN" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dpd_employer_RIN_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td>Business Name:</td> <td></td><td><asp:DropDownList ID="dpd_Business_RIN" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dpd_Business_RIN_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
               
                 <tr>
                    <td>Tax Year:</td> <td></td><td><asp:DropDownList ID="dpd_Tax_Year" runat="server" CssClass="form-control" ></asp:DropDownList></td>
                </tr>
               
                <tr>
                    <td colspan="3" style="text-align: right;"><asp:Button ID="btn_Search" Text="Add" runat="server" CssClass="btn btn-theme" OnClick="btn_Add_Click"/>
                    <asp:Button ID="btn_back" Text="Back To List" runat="server" CssClass="btn btn-theme" OnClick="btn_back_Click"/></td>
                </tr>

            </table>
        </div>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

