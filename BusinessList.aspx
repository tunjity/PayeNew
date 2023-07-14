<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusinessList.aspx.cs" Inherits="BusinessList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Business
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="title">
                 <h1 style="font-size:16px !important;">List Of Business</h1>
         </div>
               
       
     
    <asp:GridView ID="grd_ind" runat="server" AllowPaging="True" AllowSorting="True" PageSize="15" 
        AutoGenerateColumns="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader">
       

         
       
         <HeaderStyle CssClass="GridHeader" />
       
        </asp:GridView>

    </ContentTemplate></asp:UpdatePanel>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

