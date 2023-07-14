<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IndividualBusinessAdd.aspx.cs" Inherits="IndividualBusinessAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Individual Tax Payer: Add Business
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="portlet-title">
                            <div class="caption">
                                Add Business
                            </div>
                            <div class="actions">
                                <a href="IndividualDetail.html" class="btn btn-redtheme"> Cancel </a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label">Asset Type </label>
                                        <asp:TextBox runat="server" ID="txtassettype" placeholder="Business" Enabled="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Tax Payer Role  </label>
                                        <asp:DropDownList runat="server" ID="drptaxpayerrole" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Tax Payer Role" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList> 
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business Name </label>
                                        <asp:TextBox runat="server" placeholder="Enter Business Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business Address</label>
                                        <asp:TextBox CssClass="form-control" placeholder="Enter Business Address" runat="server" ID="txtbusinessaddress" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business Type</label>
                                        <asp:DropDownList runat="server" ID="drpbusinesstype" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Type" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business LGA</label>
                                        <asp:DropDownList runat="server" ID="drpbusinesslga" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business LGA" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                  </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Buisness Category</label>
                                        <asp:DropDownList runat="server" ID="drpbusinesscategory" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Category" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                       </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business Sector</label>
                                        <asp:DropDownList runat="server" ID="drpbusinesssector" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Sector" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                       </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business Sub Sector</label>
                                        <asp:DropDownList runat="server" ID="drpbusinesssubsector" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Sub Sector" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label">Business Structure</label>
                                        <asp:DropDownList runat="server" ID="drpbusinessstructure" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Structure" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label">Business Operation</label>
                                        <asp:DropDownList runat="server" ID="drpbusinessoperation" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Operation" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label required-star">Business Size</label>
                                        <asp:DropDownList runat="server" ID="drpbusinesssize" CssClass="form-control bs-select">
                                            <asp:ListItem Text="Select Business Size" Selected="True" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                      </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="text-right col-sm-12">
                                    <div class="form-group">
                                        <br />
                                        <asp:Button runat="server" ID="btnsavebusiness" CssClass="btn-theme btn" Text="Save" />
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

