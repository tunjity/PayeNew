<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNew.master" AutoEventWireup="true" CodeFile="frmCompanyFileRet.aspx.cs" Inherits="frmCompanyFileRet" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
  
     <div class="portlet-title">
    <div class="caption">
      <h1 style="
    margin-left: -123px;">  List of Companies(<asp:Label ID="lbl_name" runat="server"></asp:Label>)</h1>
        
       
    </div>
          <div class="actions" style="margin-top:-50px;" align="right">
                                <a href="FileReturns.aspx" class="btn btn-redtheme"> Back </a>
                            </div>
        </div>

   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="divmsg" class="" runat="server" style="display:none"></div>
    
    <div style="margin-left: -140px;"><table>
     <tr>
            <td colspan="3">
                <asp:GridView ID="grd_company" runat="server" AllowPaging="True" AllowSorting="True"  PageSize="10" PagerSettings-PageButtonCount="5" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" CellPadding="4" GridLines="None" Width="800px" OnRowCreated="grd_company_RowCreated" OnSelectedIndexChanged="grd_company_SelectedIndexChanged" OnPageIndexChanging="grd_company_PageIndexChanging" >
                    <Columns>
                        <asp:BoundField DataField="TaxPayerRIN" HeaderText="Company RIN" HeaderStyle-Width="115px" />
        <asp:BoundField DataField="TaxPayerName" HeaderText="Company Name" />
        <asp:BoundField DataField="TIN" HeaderText="Company TIN" HeaderStyle-Width="115px" />
        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile"/>
        <asp:BoundField DataField="EmailAddress" HeaderText="Email" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
       <%-- <asp:BoundField DataField="EconomicActivitiesName" HeaderText="Economic Activity" />--%>
        <%--<asp:BoundField DataField="ActiveText" HeaderText="Tax Payer Status" />--%>

              <asp:BoundField DataField="MobileNumber" HeaderText="Mobile" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  />
        <asp:BoundField DataField="EmailAddress" HeaderText="Email" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
            
             <asp:BoundField DataField="TaxOffice" HeaderText="TO" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />

             <asp:BoundField DataField="ContactAddress" HeaderText="Address" />

                        </Columns>
                   <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" /> 
                </asp:GridView>
                <div style="margin-top:-60px;margin-left:10px;" id="div_paging" runat="server">Showing <asp:Label runat="server" ID="lblpagefrom"></asp:Label> - <asp:Label runat="server" ID="lblpageto"></asp:Label> entries of <asp:Label runat="server" ID="lbltoal"></asp:Label> entries</div>

            </td>

            <td></td>
        </tr>
    </table></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

