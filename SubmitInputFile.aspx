<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNew.master" AutoEventWireup="true" CodeFile="SubmitInputFile.aspx.cs" Inherits="SubmitInputFile" %>

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
    Submit PAYE Input File

     <div class="actions" style="margin-top:-35px;" align="right">
                                <a href="frmCompanyFileRet.aspx" class="btn btn-redtheme"> Back </a>
                            </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="portlet light">  
      <div class="portlet-title">
                 <div class="caption">Submit Paye Input File</div>
         </div>

              <div>

                    <script src="js/Extension.min.js" type="text/javascript"></script>
    <div id="divmsg" class="" runat="server" style="display:none"></div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
                  <tr>
                    <td align="right">Select Company:</td><td width="30"></td><td><asp:DropDownList ID="drpfupcomapny" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false"></asp:DropDownList></td>
                </tr>
              
                 <tr>
                    <td align="right">Select Business:</td><td width="30"></td><td align="left"><asp:DropDownList ID="drpbusiness" runat="server" CssClass="form-control" ></asp:DropDownList><asp:Label Text="NA" runat="server" ID="lblnabusiness" Visible="false"></asp:Label></td>
                </tr>
                
                <tr>
                    <td align="right">Tax Year:</td><td width="30"></td><td align="left"><asp:DropDownList ID="drpTaxYear" runat="server" CssClass="form-control">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>

                <tr>
                    <td align="right">Select File to upload:</td><td width="30"></td><td><asp:FileUpload runat="server" ID="fpemp" style="float:left;" /> &nbsp;</td>
                </tr>
                
                <tr><td colspan="4"><a href="EmployeeTemplate.xls" style="font-size:small; text-decoration:underline;color:blue;">Download Employee Template here</a></td></tr>
                
                <tr class="tblrw"><td colspan="4" align="center"><asp:Button ID="btnupload" CssClass="btn btn-redtheme" Text="Upload" runat="server" OnClick="btnupload_Click" /></td></tr>
                <tr><td colspan="4" align="center"><br /></td></tr>
                </table></div></div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

