<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CorporateAdd.aspx.cs" Inherits="CorporateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
     Corporate Tax Payer
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="portlet-title">
    <div class="caption">
       Add New Corporate
        
    </div>
          <div class="actions">
                                <a href="Corporates.aspx" class="btn btn-redtheme"> Cancel </a>
                            </div>
        </div>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      

        <div>
            <table class="table borderless" style="width:100% !important; border:none !important;">
                <tr>
                    <td>
                        Tax Payer Type 
                        <br />
                        <asp:TextBox ID="txt_payer_type" placeholder="Company" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td>
                        Company Name 
                        <br />
                        <asp:TextBox ID="txt_company_name" runat="server" CssClass="form-control" placeholder="Enter Company Name"></asp:TextBox>
                    </td>

                    <td>
                        TIN 
                        <br />
                        <asp:TextBox ID="txt_TIN" runat="server" CssClass="form-control" placeholder="Enter TIN"></asp:TextBox>
                    </td>

                </tr>

                 <tr>
                    <td>
                        Phone 1 
                        <br />
                        <asp:TextBox ID="txt_phone_1" runat="server" CssClass="form-control" placeholder="Enter Phone 1"></asp:TextBox>
                    </td>

                    <td>
                        Phone 2 
                        <br />
                        <asp:TextBox ID="txt_phone_2" runat="server" CssClass="form-control" placeholder="Enter Phone 2"></asp:TextBox>
                    </td>

                </tr>

                 <tr>
                    <td>
                        Email Address 1 
                        <br />
                        <asp:TextBox ID="txt_email_1" runat="server" CssClass="form-control" placeholder="Enter Email Address 1"></asp:TextBox>
                    </td>

                    <td>
                        Email Address 2 
                        <br />
                        <asp:TextBox ID="txt_email_2" runat="server" CssClass="form-control" placeholder="Enter Email Address 2"></asp:TextBox>
                    </td>

                </tr>

                 <tr>
                    <td>
                        Tax Office 
                        <br />
                        <asp:DropDownList ID="txt_tax_office" runat="server" CssClass="form-control bs-select"></asp:DropDownList>
                    </td>

                    <td>
                        Economic Activity 
                        <br />
                        <asp:DropDownList ID="txt_economic_activity" runat="server" CssClass="form-control bs-select"></asp:DropDownList>
                    </td>

                </tr>

                 <tr>
                    <td>
                        Preferred Notification
                        <br />
                        <asp:DropDownList ID="txt_pre_notification" runat="server" CssClass="form-control bs-select"></asp:DropDownList>
                    </td>

                    <td>
                        Contact Address 
                        <br />
                        <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </td>

                </tr>

                <tr><td></td><td style="text-align:right;"><asp:Button ID="btn_save" Text="Save" runat="server" CssClass="btn btn-theme" OnClick="btn_save_Click"/></td></tr>

            </table>
        </div>

        </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

