<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCompany.aspx.cs" Inherits="AddCompany" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="headertext">Add Employer</h1>
    <table cellpadding="2" cellspacing="5"  style="width: 98%;"  id="box">
    <br />
        <tr><td><br /></td></tr>
        <tr class="tblrw"><td align="right">Company Name</td><td width="30"></td> <td>:</td><td><asp:TextBox ID="txtcompname" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqcompname" runat="server" ControlToValidate="txtcompname" ErrorMessage="*This field is required"></asp:RequiredFieldValidator></td></tr>
        <tr class="tblrw"><td align="right">Company Tin</td><td width="30"></td> <td>:</td><td><asp:TextBox ID="txtcompanytin" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqcomptin" runat="server" ControlToValidate="txtcompanytin" ErrorMessage="*This field is required"></asp:RequiredFieldValidator></td></tr>
        <tr class="tblrw"><td align="right">Mobile 1</td><td width="30"></td> <td>:</td><td><asp:TextBox ID="txtmobile1" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqmobile1" runat="server" ControlToValidate="txtmobile1" ErrorMessage="*This field is required"></asp:RequiredFieldValidator><cc1:FilteredTextBoxExtender ID="filteredmobile1" TargetControlID="txtmobile1" runat="server" FilterType="Numbers" ></cc1:FilteredTextBoxExtender></td></tr>
        <tr class="tblrw"><td align="right">Mobile 2</td><td width="30""><td>:</td></td><td class="auto-style1"><asp:TextBox ID="txtmobile2" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTXTMOBILE2" TargetControlID="txtmobile2" runat="server" FilterType="Numbers" ></cc1:FilteredTextBoxExtender></td></tr>
        <tr><td></td></tr>
        <tr class="tblrw"><td align="right">Email Address 1</td><td width="30"></td> <td>:</td><td><asp:TextBox ID="txtemail1" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqemail1" runat="server" ControlToValidate="txtemail1" ErrorMessage="*This field is required"></asp:RequiredFieldValidator></td></tr>
        <tr class="tblrw"><td align="right">Email Address 2</td><td width="30"></td> <td>:</td><td><asp:TextBox ID="txtemail2" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox></td></tr>
        <tr class="tblrw"><td align="right">Tax Office</td><td width="30"></td> <td>:</td><td><asp:DropDownList ID="txttaxoffice" runat="server" CssClass="form-control" ></asp:DropDownList></td></tr>
        <tr class="tblrw"><td align="right">Tax Payer Type</td><td width="30"></td> <td>:</td><td><asp:DropDownList ID="txttaxpayertype" runat="server" CssClass="form-control"  ></asp:DropDownList></td></tr>
        <tr class="tblrw"><td align="right">Economic Activity</td><td width="30"></td> <td>:</td><td><asp:DropDownList ID="txteconomicactivity" runat="server" CssClass="form-control" ></asp:DropDownList></td></tr>
        <tr class="tblrw"><td align="right">Preferred Notification</td><td width="30"></td> <td>:</td><td><asp:DropDownList ID="txtpreferrednotification" runat="server" CssClass="form-control"  ></asp:DropDownList></td></tr>
        <tr class="tblrw"><td align="right">Tax Payer Status</td><td width="30"></td> <td>:</td><td><asp:DropDownList ID="txttaxpayerstatus" runat="server" CssClass="form-control" ></asp:DropDownList></td></tr>
         <tr class="tblrw"><td> </td></tr>
         <br />
        <tr class="tblrw"><td colspan="5" align="center"><asp:Button Text="Submit" ID="btnsubmit" CssClass="btn btn-redtheme" runat="server" OnClick="btnsubmit_Click"/></td></tr>
       
           <tr><td><br /></td></tr>
    </table>
    <br />
    <div id="divmsg" class="msg" align="center" runat="server" style="margin-left:160px;display:none"></div>
</asp:Content>

