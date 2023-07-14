<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssessmentConfirmation.aspx.cs" Inherits="AssessmentConfirmation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="css/Gridstyle.css" rel="stylesheet" />


<link href="http://code.jquery.com/ui/1.11.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
<script type="text/javascript">


    function openPopup(user_rin, firstname, sal_ch_income, sal_gross, sal_pension_declared, sal_nhf_declared, sal_nhis_declared) {
        $('#lblRIN').text(user_rin);
        $('#lblName').text(firstname);
        $('#lbl_gross').text(sal_gross);
        $('#lbl_pension_dec').text(sal_pension_declared);
        $('#lbl_ch_Income').text(sal_ch_income);

        $("#popupdiv").dialog({
            title: "Record Details",
            width: 300,
            height: 250,
            modal: true,
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            }
        });
    }
</script>


</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="contentheading" runat="server">
   Assessment Confirmation
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
         <div id="popupdiv" title="Basic modal dialog" style="display: none">
User Rin: <label id="lblRIN"></label><br />
Name: <label id="lblName"></label><br />
Gross Salary: <label id="lbl_gross"></label><br />
Pension Declared: <label id="lbl_pension_dec"></label><br />
Chargable Income: <label id="lbl_ch_Income"></label>

</div>
        
        <br />
      <table style="text-align:center; width: 98%;" id="box"  cellpadding="2" cellspacing="5" >
           <tr class="tblrw">
             <td style="text-align:center;vertical-align:middle;"><asp:Label ID="lbl_enter_ass_ref_no" runat="server" CssClass="control-label bold" Text="Enter Assessment Reference Number:" Font-Bold="True" ></asp:Label></td>
              <td><asp:TextBox ID="txt_enter_ass_ref_no" CssClass="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox></td>
               <td><asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-redtheme"  OnClick="btn_search_Click" />
             </td>
         </tr>
          <tr>
              <td>
                  <br />
              </td>
          </tr>
         </table>

           <table style="text-align:center; width: 98%; display:none;" align="center" runat="server" id="box1" class="table borderless"  >
            <tr style="text-align:center; width:100%" align="center">
            <td style="text-align: center; width:100%" align="center">
             <asp:GridView ID="gvCompany" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
            CssClass="table table-striped table-bordered table-hover"   border="1" cellspacing="1" HeaderStyle-CssClass="GridHeader"                   
            OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="gvCompany_SelectedIndexChanged"  >        
        <Columns>
            <asp:BoundField DataField="company_rin" HeaderText="RIN" />
            <asp:BoundField DataField="company_name" HeaderText="Company" />
            <asp:BoundField DataField="company_tin" HeaderText="TIN" />
            </Columns>
                 <PagerStyle CssClass="pgr"></PagerStyle>
<EmptyDataTemplate>No Record Available</EmptyDataTemplate>
        </asp:GridView>
                </td>
                </tr>
        </table>


        <table style="text-align:center; width: 98%; display:none;"  runat="server"   id="Table1">
            <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:100%">
            <asp:GridView ID="grvEmployee" runat="server" AutoGenerateColumns="False" 
             AllowPaging="True" PageSize="8" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader"
             style="Width:120%; overflow: scroll;margin-left: 5%;">                     
         <Columns>

         <asp:BoundField DataField="user_rin" HeaderText="User RIN" />

         <asp:BoundField DataField="first_name" HeaderText="First Name" />

         <asp:BoundField DataField="last_name" HeaderText="Last Name" />
         
         <asp:BoundField DataField="date_of_birth" HeaderText="DOB" DataFormatString="{0:d}" />        

         <asp:BoundField DataField="tin" HeaderText="TIN" />

         
         <asp:BoundField DataField="mobile_number_1" HeaderText="Mobile" />

         <asp:BoundField DataField="email_address_1" HeaderText="E-mail"/>
                     
         <asp:BoundField DataField="sal_ch_income" HeaderText="Taxable Income" />

         <asp:BoundField DataField="sal_gross" HeaderText="sal_gross"  />

         </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
<EmptyDataTemplate>No Record Available</EmptyDataTemplate>
        </asp:GridView>
   </td>
                </tr>

           <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:100%">
                <asp:Button ID="btn_confirm" runat="server" Text="Confirm Assessment" CssClass="btn btn-redtheme" OnClick="btn_confirm_Click" />
                </td></tr>
        </table>
    </div>
</asp:Content>

