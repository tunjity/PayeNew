<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PerformanceReport.aspx.cs" Inherits="PerformanceReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=tbl_grd.ClientID %>");
             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>DIV Contents</title>');
             printWindow.document.write('</head><body >');
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
   Performance Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
 
        <div> 
            <div id="divmsg" class="" runat="server" style="display:none"></div>
            <br />
        <table  style="text-align:center; width: 98%;"   id="tbl_search" runat="server" class="table borderless">
             <tr class="tblrw">
             

         </tr>


               <tr class="tblrw">
             <td><asp:Label ID="lbl_start_date" runat="server" Text="Start Date:" Font-Bold="True" CssClass="control-label" ></asp:Label></td>
               <td>
                 <asp:TextBox ID="txt_start_date" CssClass="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                 <cc1:CalendarExtender ID="cal_start_date" TargetControlID="txt_start_date" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender>
                 </td>
                <td> <asp:Label ID="lbl_end_date" runat="server"  Text="End Date:" Font-Bold="True" CssClass="control-label" ></asp:Label></td>
                 <td>
                <asp:TextBox ID="txt_end_date" CssClass="form-control" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                 <cc1:CalendarExtender ID="cal_end_date" TargetControlID="txt_end_date" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender>
                </td>
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
            <td style="text-align: center; width:100%;position:absolute;">          
                
                <br />
                
               
               
                     
                


                </td>
                </tr>

           <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:100%">
                <div>
                    <table>
                        <tr>
                            <td>
                                   <asp:GridView ID="grvEmployee" runat="server" AutoGenerateColumns="False" Width="100%"

                      AllowPaging="True" PageSize="8"  

                       CssClass="table table-striped table-bordered table-hover"  border="1" cellspacing="1"  rules="all" style="Width:100%; overflow: scroll;"                     

                      AlternatingRowStyle-CssClass="alt"

                      PagerStyle-CssClass="pgr"   >        

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>

         <Columns>

         <asp:BoundField DataField="assessment_date" HeaderText="Assessment Date" />

         <asp:BoundField DataField="ActualAssessmentAmt" HeaderText="Amount Assessed" />

         <asp:BoundField DataField="settlement_amount" HeaderText="Amount Collected" />
         
         

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
                            <td style="width: 56px"></td>
                            <td>
                                <asp:Chart ID="Chart1" runat="server" BackColor="DarkGreen" BackGradientStyle="LeftRight"  
        BorderlineWidth="0" Height="387px" Palette="None" PaletteCustomColors="Green"  
        Width="380px" BorderlineColor="64, 0, 64">  
        <Titles>  
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
                        
        </Legends>  
        <Series>  
            <asp:Series Name="Amount Accessed" BorderWidth="1" />  
            <asp:Series Name="Amount Collected" BorderWidth="1"  />  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />  
            
        </ChartAreas>  
    </asp:Chart>  
                              
                            </td>
                            <td>  <asp:Image ID="img_chart" runat="server" ImageUrl="~/c:/Paye_SS/xx.jpg" /></td>
                        </tr>
                        <tr>
                            <td colspan="4"><asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-redtheme" OnClientClick = "return PrintPanel();"/></td>
                        </tr>
                    </table>
                </div>
                
                </td></tr>
        </table>
            </div>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>