<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PeriodicAssessmentReport.aspx.cs" Inherits="PeriodicAssessmentReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type = "text/javascript">
          function PrintPanel() {
              var panel = document.getElementById("<%=tbl_grd.ClientID %>");
              var printWindow = window.open('', '', 'height=400,width=800');
              printWindow.document.write('<html><head><title>Periodic Assessment Report</title>');
              printWindow.document.write('</head><body><table width="100%"><tr><td align="center"><U><h2 class="headertext">Periodic Assessment Report</h2></U></td></tr></table>');
              printWindow.document.write(panel.innerHTML);
              printWindow.document.write('</body></html>');
              printWindow.document.close();
              setTimeout(function () {
                  printWindow.print();
              }, 500);
              return false;
          }
    </script>
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
  Periodic Assessment Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
 
        <div> 
             <div id="divmsg" class="" runat="server" style="display:none"></div>
            <table style="text-align:center; width: 98%;"   id="tbl_search" runat="server" class="table borderless">
            <tr>
                <td>
                    <br />
                </td>
            </tr> 


               <tr class="tblrw">
             <td><asp:Label ID="lbl_start_date" runat="server" Text="Start Date:"  CssClass="control-label " ></asp:Label></td>
                
               <td>  <asp:TextBox ID="txt_start_date" CssClass="form-control" runat="server" AutoComplete="off"></asp:TextBox>
                 <br />
                 <cc1:CalendarExtender ID="cal_start_date" TargetControlID="txt_start_date" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender>
                 &nbsp;&nbsp;&nbsp;&nbsp;</td>
                   <td>
                 <asp:Label ID="lbl_end_date" runat="server"  Text="End Date:"  CssClass="control-label " ></asp:Label> </td>
                 <td>
                <asp:TextBox ID="txt_end_date" CssClass="form-control"  runat="server" AutoComplete="off"></asp:TextBox>
                 <cc1:CalendarExtender ID="cal_end_date" TargetControlID="txt_end_date" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <br /> </td>
                   <td>
                 <asp:Button ID="btn_generate" runat="server" Text="Generate Report" CssClass="btn btn-redtheme" OnClick="btn_generate_Click" />

               
                
                
             </td>
         </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
        </table>


            <table align="center" style="width:100%;" id="tbl_grd" runat="server">
            <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:80%; overflow:scroll">          
                
                <br />
                
              
               
                     <asp:GridView ID="grvEmployee" runat="server" AutoGenerateColumns="False" Width="100%"

                      AllowPaging="True" PageSize="8"  

                       CssClass="table table-striped table-bordered table-hover"  border="1" cellspacing="1"  rules="all" style="Width:100%; overflow: scroll;"                     

                      AlternatingRowStyle-CssClass="alt"

                      PagerStyle-CssClass="pgr"   >        

<AlternatingRowStyle ></AlternatingRowStyle>

         <Columns>

         <asp:BoundField DataField="tax_year" HeaderText="Assessment Year" />

         <asp:BoundField DataField="tax_payer_type" HeaderText="Type" />

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
                
                &nbsp;</td></tr>


                 
        </table>
            <table style="text-align:center; width: 98%; display:block;" id="tbl_xl" runat="server" align="center">
                <tr>
                            <td align="center"><asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-redtheme" OnClientClick = "return PrintPanel();"/>
                                <asp:Button ID="btn_excel" runat="server" Text="Export To Excel" CssClass="btn btn-redtheme" OnClick="btn_excel_Click" />
                            </td>
                        </tr>
            </table>
            </div>
    
      <%--  </ContentTemplate></asp:UpdatePanel>--%>
</asp:Content>