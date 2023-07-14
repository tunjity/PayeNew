<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssessmentApprovalProcess.aspx.cs" EnableEventValidation="false" Inherits="AssessmentApprovalProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="http://code.jquery.com/ui/1.11.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <script type="text/javascript">
        function HideLabel() {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=divmsg.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
</script>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="contentheading" runat="server">
   Assessment Approval Process
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
     <script type="text/javascript">

         $(document).ready(function () {
             $("#ctl00_ContentPlaceHolder1_btn_back").click(function () {
                 $("#ctl00_ContentPlaceHolder1_tbl_details").hide("fast");
                 $("#ctl00_ContentPlaceHolder1_tbl_grd").show("fast");
                 $("#ctl00_ContentPlaceHolder1_tbl_search").show("fast");
             });
         });
         </script>   
         
   
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   
        <div style="width:100%;overflow:auto;">
       <div id="divmsg" class="" runat="server" style="display:none">Hello</div>
      
        <table style="text-align:center;vertical-align:middle; width: 98%;"  id="tbl_search" runat="server" class="table borderless">
          <tr class="tblrw">
             <td style="text-align: center; vertical-align:middle"><asp:Label ID="lbl_enter_ass_ref_no" runat="server" CssClass="control-label " Text="Please Enter ARN:"></asp:Label></td>
            <td><asp:TextBox ID="txt_enter_ass_ref_no" CssClass="form-control" runat="server" AutoCompleteType="Disabled" ></asp:TextBox></td>
              <td style="text-align: center; vertical-align:middle"><asp:Label ID="lbl_status" runat="server"  Text="Select Status:"  CssClass="control-label "  ></asp:Label></td>
              <td><asp:DropDownList ID="dpd_status" runat="server" CssClass="form-control">
                     <asp:ListItem>--Select--</asp:ListItem>
                     <asp:ListItem>Pending</asp:ListItem>
                     <asp:ListItem>Confirm</asp:ListItem>
                     <asp:ListItem>Pending for Approval</asp:ListItem>
                     <asp:ListItem>Approved</asp:ListItem>
                     <asp:ListItem>Payment</asp:ListItem>
                     <asp:ListItem>Paid</asp:ListItem>
                     <asp:ListItem>Clearance</asp:ListItem>
                  </asp:DropDownList>
                  </td>
              <td><asp:Button ID="btn_search" runat="server" Text="Search" CssClass="btn btn-redtheme"  OnClick="btn_search_Click" /></td>
         </tr>
         <tr>
         <td colspan="5">
         <br />
         </td></tr>
        </table>



      
                
      <table align="center" style="width:100%;" id="tbl_grd" runat="server">
            <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:100%;">          
                
                <br />
                
            <asp:GridView ID="grvEmployee" runat="server" AutoGenerateColumns="False" Width="100%"
            AllowPaging="True" PageSize="8" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader"  style="Width:100%; overflow: scroll;"                     
             OnRowCreated="grvEmployee_RowCreated" OnRowDataBound="grvEmployee_RowDataBound" OnSelectedIndexChanged="grvEmployee_SelectedIndexChanged"   >        
           <Columns>

         <asp:BoundField DataField="tax_year" HeaderText="Assessment Year" />

         <asp:BoundField DataField="tax_payer_type" HeaderText="Type"/>

         <asp:BoundField DataField="assessment_ref" HeaderText="ARN" />
         
         <asp:BoundField DataField="company_tin" HeaderText="TIN" />

         <asp:BoundField DataField="tax_payer_rin" HeaderText="RIN" />

         <asp:BoundField DataField="company_name" HeaderText="Company"/>
                     
         <asp:BoundField DataField="assessment_amount" HeaderText="Amount" />

         <asp:BoundField DataField="" HeaderText="Tax Agent"  />
         
             <asp:BoundField DataField="AssessmentApprovalStatus" HeaderText="StatusValue" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>             
         <asp:BoundField DataField="Assessment_Status" HeaderText="Status"  />

         
         

  <%--            <asp:TemplateField>
<ItemTemplate>
<a href="#" class="" onclick='openPopup("<%# Eval("user_rin")%>","<%# Eval("first_name")%>"+" "+"<%# Eval("last_name")%>","<%# Eval("sal_ch_income")%>","<%# Eval("sal_gross")%>","<%# Eval("sal_pension_declared")%>","<%# Eval("sal_nhf_declared")%>","<%# Eval("sal_nhis_declared")%>")'>Details</a>
</ItemTemplate>
</asp:TemplateField>--%>
         </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
<EmptyDataTemplate>No Record Available</EmptyDataTemplate>
        </asp:GridView>
                


                </td>
                </tr>

           <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:100%">
                
                </td></tr>
        </table>

        <br /><br />

         <table style=" width: 100%; display:block;"  runat="server" align="center"   id="tbl_details" class="box_t">
             <tr class="tblrw">
                              <td style="height:50px; width:100px;"></td>
             <td style="height:50px">
                 <asp:Label ID="lbl_ass_year" runat="server" Text="Assessment Year:  " Font-Bold="True" CssClass="control-label " ></asp:Label>
                 <asp:Label ID="txt_ass_year" runat="server" Text="" Font-Bold="True" CssClass="control-label " ></asp:Label>
             </td>
                 <td style="height:50px;width:50px;"></td>
                 <td style="height:50px">
                 <asp:Label ID="lbl_company" runat="server" Text="Company:  " Font-Bold="True" CssClass="control-label " ></asp:Label>
                 <asp:Label ID="txt_company" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>
                 <td style="height:50px;width:50px;"></td>
                 <td style="height:50px">
                 <asp:Label ID="lbl_ARN" runat="server" Text="ARN:  " Font-Bold="True" CssClass="control-label "></asp:Label>
                 <asp:Label ID="txt_ARN" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>


                 </tr>

                 <tr class="tblrw">
                     <td style="height:50px;width:100px;"></td>
             <td style="height:50px">
                 <asp:Label ID="lbl_TIN" runat="server" Text="TIN:  " Font-Bold="True" CssClass="control-label "></asp:Label>
                 <asp:Label ID="txt_TIN" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>
                     <td style="height:50px;width:50px;"></td>
                 <td style="height:50px">
                 <asp:Label ID="lbl_RIN" runat="server" Text="RIN:  " Font-Bold="True" CssClass="control-label "></asp:Label>
                 <asp:Label ID="txt_RIN" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>
                     <td style="height:50px;width:50px;"></td>
                 <td style="height:50px">
                 <asp:Label ID="lbl_AMT" runat="server" Text="Amount:  " Font-Bold="True" CssClass="control-label "></asp:Label>
                 <asp:Label ID="txt_amt" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>

                 </tr>

                 <tr class="tblrw">
                     <td style="height:50px"></td>
             <td style="height:50px">
                 <asp:Label ID="lbl_tax_agent" runat="server" Text="Tax Agent:  " Font-Bold="True" CssClass="control-label "></asp:Label>
                 <asp:Label ID="txt_tax_agent" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>
                     <td style="height:50px"></td>
                 <td style="height:50px">
                 <asp:Label ID="lbl_type" runat="server" Text="Type:  " Font-Bold="True" CssClass="control-label "></asp:Label>
                 <asp:Label ID="txt_type" runat="server" Text="" Font-Bold="True" CssClass="control-label "></asp:Label>
             </td>
                     <td style="height:50px"></td>
                 <td style="height:50px">
                 <asp:Label ID="lbl_status1" runat="server" Text="Status:  " Font-Bold="True" CssClass="control-label "></asp:Label>
               <%--  <asp:Label ID="txt_status" runat="server" Text="" Font-Bold="True" ></asp:Label>--%>
                     <asp:DropDownList ID="txt_status" runat="server" CssClass="txtbox">
                     <asp:ListItem>--Select--</asp:ListItem>
                     <asp:ListItem>Pending</asp:ListItem>
                     <asp:ListItem>Confirm</asp:ListItem>
                     <asp:ListItem>Pending for Approval</asp:ListItem>
                     <asp:ListItem>Approved</asp:ListItem>
                     <asp:ListItem>Payment</asp:ListItem>
                     <asp:ListItem>Paid</asp:ListItem>
                     <asp:ListItem>Clearance</asp:ListItem>

                 </asp:DropDownList>
             </td>

                 </tr>

                <tr class="tblrw">
                     <td style="height:50px"></td>
             <td style="text-align: center; height:50px" colspan="5" align="Center">
              <asp:Button ID="btn_confirm" runat="server" Text="Confirm" CssClass="btn btn-redtheme" OnClick="btn_confirm_Click" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button id="btn_back" runat="server" Text="Back" class="btn btn-redtheme" OnClick="btn_back_Click" />

                 </td></tr>
             <tr>
             <td>
             <br /></td></tr>
             </table>

           
            <br />


    </div>

   
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

