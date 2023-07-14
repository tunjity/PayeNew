<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditEmpPaye.aspx.cs" Inherits="EditEmpPaye" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

     <script type="src= http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#<%=txt_AnnualBasic.ClientID %>').keyup(function () {
                if ($('#<%=txt_AnnualBasic.ClientID %>').length > 0 && $('#<%=txt_AnnualRent.ClientID %>').length > 0 && $('#<%=txt_Annual_Trans.ClientID %>').length > 0 && $('#<%=txt_Annual_Utility.ClientID %>').length > 0 && $('#<%=txt_Annual_Meal.ClientID %>').length > 0 && $('#<%=txt_Leave_Trans_Grant.ClientID %>').length > 0) {
                    $('#<%=txt_AnnualGross.ClientID %>').val(parseInt($('#<%=txt_AnnualBasic.ClientID %>').val()) + parseInt($('#<%=txt_AnnualRent.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Trans.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Utility.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Meal.ClientID %>').val()) + parseInt($('#<%=txt_Leave_Trans_Grant.ClientID %>').val()) + parseInt($('#<%=txt_otherIncome.ClientID %>').val()));
                }
            });
        });

        $(function () {
            $('#<%=txt_AnnualRent.ClientID %>').keyup(function () {
                if ($('#<%=txt_AnnualBasic.ClientID %>').length > 0 && $('#<%=txt_AnnualRent.ClientID %>').length > 0 && $('#<%=txt_Annual_Trans.ClientID %>').length > 0 && $('#<%=txt_Annual_Utility.ClientID %>').length > 0 && $('#<%=txt_Annual_Meal.ClientID %>').length > 0 && $('#<%=txt_Leave_Trans_Grant.ClientID %>').length > 0) {
                    $('#<%=txt_AnnualGross.ClientID %>').val(parseInt($('#<%=txt_AnnualBasic.ClientID %>').val()) + parseInt($('#<%=txt_AnnualRent.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Trans.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Utility.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Meal.ClientID %>').val()) + parseInt($('#<%=txt_Leave_Trans_Grant.ClientID %>').val()) + parseInt($('#<%=txt_otherIncome.ClientID %>').val()));
                }
            });
        });

        $(function () {
            $('#<%=txt_Annual_Trans.ClientID %>').keyup(function () {
                if ($('#<%=txt_AnnualBasic.ClientID %>').length > 0 && $('#<%=txt_AnnualRent.ClientID %>').length > 0 && $('#<%=txt_Annual_Trans.ClientID %>').length > 0 && $('#<%=txt_Annual_Utility.ClientID %>').length > 0 && $('#<%=txt_Annual_Meal.ClientID %>').length > 0 && $('#<%=txt_Leave_Trans_Grant.ClientID %>').length > 0)
                    $('#<%=txt_AnnualGross.ClientID %>').val(parseInt($('#<%=txt_AnnualBasic.ClientID %>').val()) + parseInt($('#<%=txt_AnnualRent.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Trans.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Utility.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Meal.ClientID %>').val()) + parseInt($('#<%=txt_Leave_Trans_Grant.ClientID %>').val()) + parseInt($('#<%=txt_otherIncome.ClientID %>').val()));
            });
        });

        $(function () {
            $('#<%=txt_Annual_Utility.ClientID %>').keyup(function () {
                if ($('#<%=txt_AnnualBasic.ClientID %>').length > 0 && $('#<%=txt_AnnualRent.ClientID %>').length > 0 && $('#<%=txt_Annual_Trans.ClientID %>').length > 0 && $('#<%=txt_Annual_Utility.ClientID %>').length > 0 && $('#<%=txt_Annual_Meal.ClientID %>').length > 0 && $('#<%=txt_Leave_Trans_Grant.ClientID %>').length > 0)               
                    $('#<%=txt_AnnualGross.ClientID %>').val(parseInt($('#<%=txt_AnnualBasic.ClientID %>').val()) + parseInt($('#<%=txt_AnnualRent.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Trans.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Utility.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Meal.ClientID %>').val()) + parseInt($('#<%=txt_Leave_Trans_Grant.ClientID %>').val()) + parseInt($('#<%=txt_otherIncome.ClientID %>').val()));
            });
        });

        $(function () {
            $('#<%=txt_Leave_Trans_Grant.ClientID %>').keyup(function () {
                if ($('#<%=txt_AnnualBasic.ClientID %>').length >0 && $('#<%=txt_AnnualRent.ClientID %>').length >0 && $('#<%=txt_Annual_Trans.ClientID %>').length >0 && $('#<%=txt_Annual_Utility.ClientID %>').length >0 && $('#<%=txt_Annual_Meal.ClientID %>').length >0 && $('#<%=txt_Leave_Trans_Grant.ClientID %>').length >0)
                    $('#<%=txt_AnnualGross.ClientID %>').val(parseInt($('#<%=txt_AnnualBasic.ClientID %>').val()) + parseInt($('#<%=txt_AnnualRent.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Trans.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Utility.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Meal.ClientID %>').val()) + parseInt($('#<%=txt_Leave_Trans_Grant.ClientID %>').val()) + parseInt($('#<%=txt_otherIncome.ClientID %>').val()));
            });
         });


        $(function () {
            $('#<%=txt_otherIncome.ClientID %>').keyup(function () {
                if ($('#<%=txt_AnnualBasic.ClientID %>').length > 0 && $('#<%=txt_AnnualRent.ClientID %>').length > 0 && $('#<%=txt_Annual_Trans.ClientID %>').length > 0 && $('#<%=txt_Annual_Utility.ClientID %>').length > 0 && $('#<%=txt_Annual_Meal.ClientID %>').length > 0 && $('#<%=txt_Leave_Trans_Grant.ClientID %>').length > 0 && $('#<%=txt_otherIncome.ClientID %>').length > 0)
                    $('#<%=txt_AnnualGross.ClientID %>').val(parseInt($('#<%=txt_AnnualBasic.ClientID %>').val()) + parseInt($('#<%=txt_AnnualRent.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Trans.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Utility.ClientID %>').val()) + parseInt($('#<%=txt_Annual_Meal.ClientID %>').val()) + parseInt($('#<%=txt_Leave_Trans_Grant.ClientID %>').val()) + parseInt($('#<%=txt_otherIncome.ClientID %>').val()));
            });
        });


       
</script>


    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Employee PAYE Details

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="portlet-title">
    <div class="caption">
       Employee Paye Details
        </div>
        <div class="actions">
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-redtheme" Text="Back To List" OnClick="btnBack_Click" />
                                </div>
                            </div>
    
        </div>

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

        <div id="divmsg" class="" runat="server" style="display:none"></div>

         <div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
                  <tr>
                      <td style="font-weight:bold;">Employee Name:</td> <td></td><td><asp:TextBox ID="txt_employee_name" runat="server" CssClass="form-control"></asp:TextBox></td>
                      <td style="font-weight:bold;">Employee TIN:</td> <td></td><td><asp:TextBox ID="txt_employee_TIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Tax Year:</td> <td></td><td><asp:TextBox ID="txt_tax_year" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td style="font-weight:bold;">Employee RIN:</td> <td></td><td><asp:TextBox ID="txt_employee_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Annual Basic:</td> <td></td><td><asp:TextBox ID="txt_AnnualBasic" runat="server" CssClass="form-control" Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Annual Rent:</td> <td></td><td><asp:TextBox ID="txt_AnnualRent" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Annual Transport:</td> <td></td><td><asp:TextBox ID="txt_Annual_Trans" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Annual Utility:</td> <td></td><td><asp:TextBox ID="txt_Annual_Utility" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Annual Meal:</td> <td></td><td><asp:TextBox ID="txt_Annual_Meal" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Leave Transport Grant:</td> <td></td><td><asp:TextBox ID="txt_Leave_Trans_Grant" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="font-weight:bold;">Pension:</td> <td></td><td><asp:TextBox ID="txt_Pension" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">NHF:</td> <td></td><td><asp:TextBox ID="txt_NHF" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">NHIS:</td> <td></td><td><asp:TextBox ID="txt_NHIS" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;">Annual Gross:</td> <td></td><td><asp:TextBox Enabled="false" ID="txt_AnnualGross" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="font-weight:bold;">Other Income:</td> <td></td><td><asp:TextBox ID="txt_otherIncome" runat="server" CssClass="form-control"  Text="0"></asp:TextBox></td>
                    <td style="font-weight:bold;"></td> <td></td><td></td>
                </tr>


                 <tr>
                    <td style="font-weight:bold;">Start Month:</td> <td></td><td>
                      
                       <%-- <asp:TextBox ID="txt_start_month" runat="server" CssClass="form-control"></asp:TextBox>

                         <br />
                 <cc1:CalendarExtender ID="cal_start_date" TargetControlID="txt_start_month" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender>--%>
                                                                            
                        <asp:DropDownList ID="txt_start_month" runat="server" CssClass="form-control">
                            
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
                            
                        </asp:DropDownList>
                         </td>
                     
                    <td style="font-weight:bold;">End Month:</td> <td></td><td>
                        
                        <%--<asp:TextBox ID="txt_end_month" runat="server" CssClass="form-control"></asp:TextBox>

                        <cc1:CalendarExtender ID="cal_end_date" TargetControlID="txt_end_month" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender>--%>

                         <asp:DropDownList ID="txt_end_month" runat="server" CssClass="form-control">
                            
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
                            
                        </asp:DropDownList>
                                                                           </td>
                </tr>


                 <tr>
                    <td style="font-weight:bold;" colspan="5">Pension:&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chk_pension" runat="server"></asp:CheckBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NHF:&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="chk_NHF" runat="server"></asp:CheckBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NHIS:&nbsp;&nbsp;&nbsp;&nbsp; <asp:CheckBox ID="chk_NHIS" runat="server"></asp:CheckBox>
                    </td> 

                    

                     <td><asp:Button ID="btn_save" Text="SAVE" runat="server" CssClass="btn btn-theme" OnClick="btn_save_Click"/> </td>

                </tr>


                </table>
             </div></ContentTemplate></asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

