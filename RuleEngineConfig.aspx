<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RuleEngineConfig.aspx.cs" Inherits="RuleEngineConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
  Rule Engine Configurations
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divmsg" class="" runat="server" style="display:none"></div><br />
    <table id="box" border="1" style="width:98%;border-collapse:collapse;border:1px solid;border-color:black;">
        <tr>
            <td>Salary Type</td><td>Old Formula</td><td>New Formula</td><td>Copy old formula</td>
        </tr>
        <tr>
            <td>Pension</td><td><asp:Label runat="server" ID="lblpensionformulaold" CssClass="control-label bold"></asp:Label></td><td><asp:TextBox runat="server" ID="txtpensionformulanew" CssClass="form-control"></asp:TextBox></td><td><asp:CheckBox runat="server" ID="chkpensionformulacopy" Text="Copy" AutoPostBack="true" OnCheckedChanged="chkpensionformulacopy_CheckedChanged" /></td>
        </tr>
         <tr>
            <td>NHF</td><td><asp:Label runat="server" ID="lblnhfformulaold" CssClass="control-label bold"></asp:Label></td><td><asp:TextBox runat="server" ID="txtnhfformulanew" CssClass="form-control"></asp:TextBox></td><td><asp:CheckBox runat="server" ID="chknhfformulacopy" Text="Copy" AutoPostBack="true" OnCheckedChanged="chknhfformulacopy_CheckedChanged" /></td>
        </tr>
         <tr>
            <td>NHIS</td><td><asp:Label runat="server" ID="lblnhisformulaold" CssClass="control-label bold"></asp:Label></td><td><asp:TextBox runat="server" ID="txtnhisformulanew" CssClass="form-control"></asp:TextBox></td><td><asp:CheckBox runat="server" ID="chknhisformulacopy" Text="Copy"  OnCheckedChanged="chknhisformulacopy_CheckedChanged"/></td>
        </tr>
         <tr style="display:none;">
            <td>CRA1</td><td><asp:Label runat="server" ID="lblcra1formulaold" CssClass="control-label bold"></asp:Label></td><td><asp:TextBox runat="server" ID="txtcra1formulanew" CssClass="form-control"></asp:TextBox></td><td><asp:CheckBox runat="server" ID="chkcra1formulacopy" Text="Copy" AutoPostBack="true" OnCheckedChanged="chkcra1formulacopy_CheckedChanged" /></td>
        </tr>
        <tr style="display:none;">
            <td>CRA2</td><td><asp:Label runat="server" ID="lblcra2formulaold" CssClass="control-label bold"></asp:Label></td><td><asp:TextBox runat="server" ID="txtcra2formulanew" CssClass="form-control"></asp:TextBox></td><td><asp:CheckBox runat="server" ID="chkcra2formulacopy" Text="Copy" AutoPostBack="true" OnCheckedChanged="chkcra2formulacopy_CheckedChanged"/></td>
        </tr>
        <tr><td>Notations</td><td colspan="4">B: Basic Salary&nbsp;&nbsp;R: Rent&nbsp;&nbsp;T: Transport &nbsp;&nbsp;</td></tr>
        </table>
    <div style="margin:auto;width:30%;" align="center"><asp:Button runat="server" ID="btnNewRule" Text="Add New Rule" CssClass="btn btn-redtheme" OnClick="btnNewRule_Click" /></div>
</asp:Content>

