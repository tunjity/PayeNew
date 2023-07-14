<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAsset.aspx.cs" Inherits="AddAsset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="http://code.jquery.com/ui/1.11.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  
    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=divmsg.ClientID %>").style.display = "none";
            }, seconds * 2000);
        };
</script>



    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="WaterMark.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=ctl00_ContentPlaceHolder1_txt_house_no]").WaterMark();


        });
    </script>
    
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
    Add Asset (Business)
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>

        <script type="text/javascript" language="javascript">
            Sys.Application.add_load(HideLabel);
            </script>
    <div>
    <div id="divmsg" class="" runat="server" style="display:none"></div>

     <table style="text-align:center;width:auto;" class="table borderless" align="center"  runat="server"  id="box" border="0">
           <tr>
           
              <td>
                 <asp:Label ID="lbl_Associated_Business" runat="server" Text="Associated Assets:" CssClass="control-label" ></asp:Label>
                 </td>
             <td>
                 <asp:DropDownList ID="dpd_associated_business_list" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
             </td>
             
              </tr>

         <tr>
             <td colspan="2">
                 <asp:Button ID="btn_proceed" runat="server" CssClass="btn btn-redtheme" Text="Proceed" OnClick="btn_proceed_Click" />
             </td>
         </tr>
         
        </table>
        
        <table style="text-align:center;width: 98%; display:none;" class="table borderless" border="0"  cellpadding="2" cellspacing="5" runat="server"   id="box1">

          <tr id="tr_enter_TIN" runat="server">
              <td colspan="5" align="center">
              <table >
                  <tr>
                      <td><asp:Label ID="lbl_enter_RIN" runat="server" Text="Enter RIN:" BackColor="White" ForeColor="Black" BorderStyle="None"></asp:Label></td>
                      <td><asp:TextBox ID="txt_enter_RIN" runat="server"  CssClass="form-control"></asp:TextBox></td>
                      <td>&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_search" runat="server" CssClass="btn btn-redtheme" OnClick="btn_search_Click" Text="Search" /></td>
                  </tr>
                 
              </table>
                 </td>
             </tr>

            <tr class="tblrw">
                 <td style="text-align: right">
                     <asp:Label ID="lbl_Business_RIN" runat="server" Text="Business RIN:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txt_Business_RIN" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                 </td>
                 <td></td>
                 <td style="text-align: right">
                     <asp:Label ID="lbl_AssetType" runat="server" Text="Asset Type:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_AssetType" runat="server" CssClass="form-control"></asp:DropDownList>

                  
                 </td>
             </tr>

           <tr class="tblrw">
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessName" runat="server" Text="Business Name:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txt_BusinessName" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                 </td>
                 <td></td>
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessType" runat="server" Text="Business Type:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_BusinessType" runat="server" CssClass="form-control"></asp:DropDownList>

                  
                 </td>
             </tr>

           <tr class="tblrw">
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessCategory" runat="server" Text="Business Category:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_BusinessCategory" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                 </td>
                 <td></td>
                 <td style="text-align: right">
                     <asp:Label ID="lbl_LGAName" runat="server" Text="LGA Name:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_LGAName" runat="server" CssClass="form-control"></asp:DropDownList>

                  
                 </td>
             </tr>

            <tr class="tblrw">
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessSectorName" runat="server" Text="Business Sector:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_BusinessSectorName" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                 </td>
                 <td></td>
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessSubSectorName" runat="server" Text="Business Sub-Sector Name:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_BusinessSubSectorName" runat="server" CssClass="form-control"></asp:DropDownList>

                  
                 </td>
             </tr>


          <tr class="tblrw">
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessStructureName" runat="server" Text="Business Structure Name:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_BusinessStructureName" runat="server" CssClass="form-control" Enabled="False"></asp:DropDownList>
                 </td>
                 <td></td>
                 <td style="text-align: right">
                     <asp:Label ID="lbl_BusinessOperationName" runat="server" Text="Business Operation Name:" CssClass="control-label "></asp:Label>
                 </td>
                 <td>
                     <asp:DropDownList ID="txt_BusinessOperationName" runat="server" CssClass="form-control"></asp:DropDownList>

                  
                 </td>
             </tr>

          <tr>
             <td colspan="5"></td>
         </tr>
         <tr id="tr_yes" runat="server" style="display:none;">
             <td colspan="5">Do You Want To Associate This Business To the Company... <asp:Button ID="btn_yes" runat="server" CssClass="btn btn-redtheme" Text="Yes" OnClick="btn_yes_Click" /><asp:Button ID="btn_no" runat="server" CssClass="sbbtn" Text="No" OnClick="btn_no_Click" /></td>
         </tr>

            <tr id="tr_yess" runat="server" style="display:none;">
             <td colspan="5">Would You Like To Add a Business for This Company... <asp:Button ID="btn_yess" runat="server" CssClass="btn btn-redtheme" Text="Yes" OnClick="btn_yess_Click" /><asp:Button ID="btn_noo" runat="server" CssClass="sbbtn" Text="No" OnClick="btn_noo_Click" /></td>
         </tr>

           <tr id="tr_submit" runat="server" style="display:none;">
             <td colspan="5"><asp:Button ID="btn_submit" runat="server" CssClass="btn btn-redtheme" Text="Submit" OnClick="btn_submit_Click"/></td>
         </tr>
         </table>
        </div>
         </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>