<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewOutputFile_N.aspx.cs" Inherits="ViewOutputFile_N" %>

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

   <%-- <script type = "text/javascript">
        function AnnualGross() {
            var basic = document.getElementById("<%=txt_AnnualBasic.ClientID%>");
            var rent = document.getElementById("<%=txt_AnnualRent.ClientID%>");
            var trans = document.getElementById("<%=txt_Annual_Trans.ClientID%>");
            var gross = document.getElementById("<%=txt_AnnualGross.ClientID%>").toString()
            gross.toString() = basic + rent + trans;
        }


    </script>--%>

   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Employee PAYE Details

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="portlet-title">
    <div class="caption">
       Employee Paye Details - Output File
        </div>
        <div class="actions">
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-redtheme" Text="Back To List" OnClick="btnBack_Click" />
                                </div>
                            </div>
    
        </div>

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

       

         <div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
                  <tr>
                      <td style="font-weight:bold;">Employee Name:</td> <td></td><td><asp:TextBox ID="txt_employee_name" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox></td>
                      <td style="font-weight:bold;">Employee TIN:</td> <td></td><td><asp:TextBox ID="txt_employee_TIN" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Tax Year:</td> <td></td><td><asp:TextBox ID="txt_tax_year" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox></td>
                    <td style="font-weight:bold;">Employee RIN:</td> <td></td><td><asp:TextBox ID="txt_employee_RIN" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Annual Gross:</td> <td></td><td><asp:TextBox ID="txt_AnnualGross" Enabled="false" runat="server" CssClass="form-control" Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Annual CRA:</td> <td></td><td><asp:TextBox ID="txt_AnnualCRA" Enabled="false" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Validated Pension:</td> <td></td><td><asp:TextBox ID="txt_ValidatedPension" Enabled="false" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Validated NHF:</td> <td></td><td><asp:TextBox ID="txt_NHF" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Validated NHIS:</td> <td></td><td><asp:TextBox ID="txt_NHIS" runat="server" Enabled="false" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Tax Free Pay:</td> <td></td><td><asp:TextBox ID="txt_tax_free_pay" runat="server" Enabled="false" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Chargable Income:</td> <td></td><td><asp:TextBox ID="txt_ChargableIncome" Enabled="false" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Annual Tax:</td> <td></td><td><asp:TextBox ID="txt_AnnualTax" Enabled="false" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Monthly Tax:</td> <td></td><td><asp:TextBox ID="txt_MonthlyTax" Enabled="false" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;"></td> <td></td><td></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Start Month:</td> <td></td><td><asp:DropDownList ID="txt_start_month" runat="server" CssClass="form-control" Enabled="false">
                            
                            <asp:ListItem>January</asp:ListItem>
                            <asp:ListItem>February</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>August</asp:ListItem>
                            <asp:ListItem>September</asp:ListItem>
                            <asp:ListItem>October</asp:ListItem>
                            <asp:ListItem>November</asp:ListItem>
                            <asp:ListItem>December</asp:ListItem>
                            
                        </asp:DropDownList></td>
                    <td style="font-weight:bold;">End Month:</td> <td></td><td><asp:DropDownList ID="txt_end_month" runat="server" CssClass="form-control" Enabled="false">
                            
                            <asp:ListItem>January</asp:ListItem>
                            <asp:ListItem>February</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>August</asp:ListItem>
                            <asp:ListItem>September</asp:ListItem>
                            <asp:ListItem>October</asp:ListItem>
                            <asp:ListItem>November</asp:ListItem>
                            <asp:ListItem Selected="True">December</asp:ListItem>
                            
                        </asp:DropDownList></td>
                </tr>


              


                </table>
             </div></ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

