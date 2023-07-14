<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NotificationTypeMaster.aspx.cs" Inherits="NotificationTypeMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
   Notification Type Master
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>Select Operation</td>
            <td width="30"></td>
            <td>
                <asp:RadioButtonList ID="radopt" runat="server" RepeatColumns="2" OnSelectedIndexChanged="radopt_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Selected="True" Text="Insert" Value="1"></asp:ListItem>
        <asp:ListItem Text="Update" Value="2"></asp:ListItem>
    </asp:RadioButtonList>
          </td>
        </tr>
    </table>
     
    <div id="divsubmit" runat="server">
        
    <table id="box">
        <tr class="tblrw"><td>Notification Type</td><td>:</td><td width="30"></td><td><asp:TextBox ID="txtnottype" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqcompname" ValidationGroup="submit" runat="server" ControlToValidate="txtnottype" ErrorMessage="*This field is required"></asp:RequiredFieldValidator></td></tr>
        <tr class="tblrw"><td>Notification Description</td><td>:</td><td width="30"></td><td><asp:TextBox ID="txtnotdesc" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqcomptin" ValidationGroup="submit" runat="server" ControlToValidate="txtnotdesc" ErrorMessage="*This field is required"></asp:RequiredFieldValidator></td></tr>
        <tr class="tblrw"><td>First Escalation</td><td>:</td><td width="30"></td><td><asp:TextBox ID="txtfirstesc" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="reqmobile1" ValidationGroup="submit" runat="server" ControlToValidate="txtfirstesc" ErrorMessage="*This field is required"></asp:RequiredFieldValidator><cc1:FilteredTextBoxExtender ID="filteredmobile1" TargetControlID="txtfirstesc" runat="server" FilterType="Numbers" ></cc1:FilteredTextBoxExtender></td></tr>
        <tr class="tblrw"><td>Second Escalation</td><td>:</td><td width="30" ></td><td><asp:TextBox ID="txtsecondesc" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTXTMOBILE2" TargetControlID="txtsecondesc" runat="server" FilterType="Numbers" ></cc1:FilteredTextBoxExtender></td></tr>
        <tr class="tblrw"><td colspan="5" align="center"><asp:Button Text="Submit" ID="btnsubmit" CssClass="btn btn-redtheme" runat="server" OnClick="btnsubmit_Click" ValidationGroup="submit"/></td></tr>
    </table>
    </div>
    
    <div id="divupdate" style="display:none;" runat="server">
     <table id="box">
        <tr class="tblrw"><td>Notification Type</td><td>:</td><td width="30"></td><td><asp:DropDownList ID="drpnotificationtype" runat="server" CssClass="form-control" AutoCompleteType="Disabled" OnSelectedIndexChanged="drpnotificationtype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td></tr>
        <tr class="tblrw"><td>Notification Description</td><td>:</td><td width="30"></td><td><asp:TextBox ID="txtupdnotdesc" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="update" runat="server" ControlToValidate="txtupdnotdesc" ErrorMessage="*This field is required"></asp:RequiredFieldValidator></td></tr>
        <tr class="tblrw"><td>First Escalation</td><td>:</td><td width="30"></td><td><asp:TextBox ID="txtupdfirstesc" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="update" ControlToValidate="txtupdfirstesc" ErrorMessage="*This field is required"></asp:RequiredFieldValidator><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtupdfirstesc" runat="server" FilterType="Numbers" ></cc1:FilteredTextBoxExtender></td></tr>
        <tr class="tblrw"><td>Second Escalation</td><td>:</td><td width="30" ></td><td><asp:TextBox ID="txtupdsecesc" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtupdsecesc" runat="server" FilterType="Numbers" ></cc1:FilteredTextBoxExtender></td></tr>
        <tr class="tblrw"><td colspan="5" align="center"><asp:Button Text="Update" ID="btnupdate" CssClass="btn btn-redtheme" runat="server" ValidationGroup="update" OnClick="btnupdate_Click"/></td></tr>
    </table>
    </div>
    <div id="divmsg" class="msg" align="center" runat="server" style="margin-left:160px;display:none"></div>
</asp:Content>

