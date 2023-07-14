<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagenew.master" AutoEventWireup="true" CodeFile="FileReturns.aspx.cs" Inherits="FileReturns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function closecompany() {
            var companypopup = document.getElementById('<%=DivCompanyPopup.ClientID%>');
            companypopup.style.display = 'none';
        }
        function showcompany() {
            var companypopup = document.getElementById('<%=DivCompanyPopup.ClientID%>');
            companypopup.style.display = '';
        }    </script>
    
</asp:Content>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="contentheading">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
                        
    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
          <div id="divmsg" class="" runat="server" style="display:none"></div>
    <div>
        <table style="margin-left: -91px;">
            <tr>
                <td >
                    &nbsp;&nbsp;
                    <asp:Label ID="lbl_govt" runat="server" Text="Government" Style="background-color:#aba59b;color:white;" CssClass="btn"  ></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td >
                    <asp:Button ID="lbl_private_business_A_G" runat="server" Text="Private Businesses A - G" CssClass="btn btn-theme"  OnClick="lbl_private_business_A_G_Click"></asp:Button>


                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>

                <td >
                    <asp:Button ID="lbl_private_business_H_Z" runat="server" Text="Private Businesses H - Z" CssClass="btn btn-theme" OnClick="lbl_private_business_H_Z_Click"></asp:Button>
                </td>

            </tr>

           
        </table>
    </div>
   

       <div id ="DivCompanyPopup" runat="server" style="display:none;">
           
        <div class="box" id="box"  style="left: 21%; float: none; top: 18%;  position: fixed;  width: 900px; height: 450px; overflow:scroll; background-color:Window;">
      <%-- <div  id="DivCompanyPopup"  runat="server" style="left: 24%; float: none; top: 10%;  position: fixed;  width: 500px; height: 500px;background-color:Window; overflow:scroll; border: 2px solid #a1a1a1; padding: 10px 40px;  border-radius: 15px 50px 30px 5px; -webkit-box-shadow: 10px 7px 0px -1px rgba(0,0,0,0.57); -moz-box-shadow: 10px 7px 0px -1px rgba(0,0,0,0.57); box-shadow: 10px 7px 0px -1px rgba(0,0,0,0.57); " >
      --%>               
         <table style=" width:850px; height:100px;" align="center"  >
        <tr>
            <td align="right" colspan="3" style="height:25px"> <input type="button" onclick="closecompany()" value="X" />
 </td>

        </tr>
     <tr> 
         <td align="center" colspan="3">
             
             <h3><span class="information-box">Fill Employer Name</span></h3></td></tr>
     <tr>
         <td></td>
         <td    align="center" > 
          <div id="DivCompanyError"  class="Errorbox"  height="5px" width="20%" style="display:block;"   runat="server">
          
            <p style="color:#ca0c0c;" id="p1" runat="server" class="t11"><strong> Please type atleast 3 characters of company name for fast search  </strong></p>  
           
        </div>
         </td>
          <td></td>
     </tr>
        <tr>
     <td  align="left" style="width: 200px;">
          <asp:Label ID="Label1" runat="server" Text="Name:" Font-Bold="true" Font-Size="Large"></asp:Label>  
     
     </td>
     <td align="left">
       <asp:TextBox ID="txtCompanyName" runat="server" Width="450px" CssClass="txtbox" Height="26px"  onKeyUP="this.value = this.value.toUpperCase();" TabIndex="1" onkeydown="return EnterEvent(event);" ></asp:TextBox>
     </td> 
     <td align="left">
          <div class="Adminshortcuts" style="height:60px; width: 200px;">
       
                <asp:ImageButton ID="btn_search" runat="server" Text="Search" ImageUrl="~/images/SearchIcon.png" OnClick="btn_search_Click"  CssClass="Adminshortcut" Height="60px" Width="60px" />
                         
             </div>
         <asp:Label ID="lblCompRow" runat="server"  Visible="false" Text=""></asp:Label>
     </td>
     </tr>
        <tr><td style="height:30px" colspan="3" align="center">
            <asp:Image ImageUrl="~/Images/companyloading.gif" runat="server" style="display:none" ID="imgcompanyloader" />
            </td></tr>
        


        <tr>
            <td colspan="3">
                <asp:GridView ID="grd_company" runat="server" AutoGenerateColumns="False" CssClass="GridBaseStyle" CellPadding="4" ForeColor="#333333" GridLines="None" Width="800px" OnRowCreated="grd_company_RowCreated" OnSelectedIndexChanged="grd_company_SelectedIndexChanged" >
                    <Columns>
                        <asp:BoundField DataField="TaxPayerRIN" HeaderText="Company RIN"  />
        <asp:BoundField DataField="TaxPayerName" HeaderText="Company Name" />
        <asp:BoundField DataField="TIN" HeaderText="Company TIN"  />
        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile"/>
        <asp:BoundField DataField="EmailAddress" HeaderText="Email" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
       <%-- <asp:BoundField DataField="EconomicActivitiesName" HeaderText="Economic Activity" />--%>
        <%--<asp:BoundField DataField="ActiveText" HeaderText="Tax Payer Status" />--%>

              <asp:BoundField DataField="MobileNumber" HeaderText="Mobile" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  />
        <asp:BoundField DataField="EmailAddress" HeaderText="Email" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
            
             <asp:BoundField DataField="TaxOffice" HeaderText="TO" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />

             <asp:BoundField DataField="ContactAddress" HeaderText="Address" />

                        </Columns>
                    <HeaderStyle CssClass="Grid_Header" BackColor="#2f672b" Font-Bold="True" ForeColor="White" />

<PagerStyle CssClass="pgr" BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

                        <RowStyle CssClass="Grid_Item" BackColor="#F7F6F3" ForeColor="#333333" />
                        <AlternatingRowStyle CssClass="Grid_Item_Alternaterow" BackColor="White" ForeColor="#284775" />
                        <SelectedRowStyle CssClass="Grid_Selected" BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle CssClass="Grid_Footer" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>

            <td></td>
        </tr>

       
</table>
        <%--</div>--%>
</div>
                   
        </div>
             </ContentTemplate></asp:UpdatePanel>
</asp:Content>
