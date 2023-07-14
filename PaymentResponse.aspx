<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentResponse.aspx.cs" Inherits="PaymentResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="divshow" runat="server" style="margin:auto;width:20%;"></div>
    <div style="border:1px solid;border-radius:7px;display:none;padding:10px;background-color:#2bab5c;color:white;width:70%;margin:auto;" id="divsuccess" runat="server">
    
    </div>
     <div style="border:1px solid;border-radius:7px;display:none;padding:10px;background-color:#de6a62;color:white;width:70%;margin:auto;" id="divfail" runat="server">

     </div>

</asp:Content>

