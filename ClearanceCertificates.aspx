<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClearanceCertificates.aspx.cs" Inherits="ClearanceCertificates" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
   Clearance Certificate Request
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div id="divmsg" class="" runat="server" style="display:none"></div>
    <br />
    <table id="box" class="table borderless"  style="width:98%;" border="0">
        <tr>
            <td>
                <table align="center" border="0">
                    <tr class="tblrw">
                    <td align="right">Enter Company Rin</td>
                    <td>:&nbsp;&nbsp;</td>
                    <td align="left"><asp:TextBox ID="txtcomptin" runat="server" CssClass="form-control" >
                   </asp:TextBox></td>
                        <td>&nbsp;</td>
                        <td align="right"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="white" ForeColor="Red" BorderStyle="None" ControlToValidate="txtcomptin" ErrorMessage="*This field is required" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
                </tr>
        <tr><td colspan="4" height="5">&nbsp;</td></tr>
        <tr class="tblrw">
                    <td align="right">Select Year</td>
                    <td>:</td>
                    <td align="left"><asp:DropDownList ID="drpYear" 
 CssClass="form-control"  runat="server" ></asp:DropDownList></td>
            </tr>
        <tr><td colspan="4" height="5">&nbsp;</td></tr>
        <tr class="tblrw">
                    <td align="right">Select Month</td>
                    <td>:</td>
                    <td align="left"><asp:DropDownList ID="drpMonth"  CssClass="form-control" runat="server"></asp:DropDownList></td>
                </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr><td colspan="3" align="center" ><asp:Button Text="Search" ID="btnsubmit" CssClass="btn btn-redtheme" runat="server" OnClick="btnsubmit_Click" ValidationGroup="submit" /></td></tr>
                </table>
            </td>
        </tr>
        
        
                
        <tr><td>&nbsp;</td></tr>
                <tr>
                    <td colspan="6">
                    <asp:GridView ID="grdclrcert" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="8" 
                    CssClass="table table-striped table-bordered table-hover" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="grdclrcert_SelectedIndexChanged" OnRowDataBound="OnRowDataBound"  >        
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="assessment_child_ref" HeaderText="Assessment Ref No." />
                            <asp:BoundField DataField="company_rin" HeaderText="Company RIN" />
                            <asp:BoundField DataField="tax_payer_name" HeaderText="Company Name" />
                            <asp:BoundField DataField="YearTax" HeaderText="Year" />
                            <asp:BoundField DataField="MonthTax" HeaderText="Month" />
                         </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                      </asp:GridView>    
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div id="divconfirm" runat="server" style="border:dashed 1px;width:98%;display:none;">
                            <i class="fa fa-exclamation-circle" style="font-size:20px;"></i><asp:Label runat="server" Text="" ID="lblconfirm"></asp:Label><br />
                            <asp:Button Text="Ok" runat="server" ID="btnok" CssClass="btn btn-redtheme" OnClick="btnok_Click"/>&nbsp;&nbsp; <asp:Button Text="Cancel" runat="server" ID="btncancel" CssClass="sbbtn" OnClick="btncancel_Click" />
                        </div>
                    </td>

                </tr>
                
            </table>
</asp:Content>