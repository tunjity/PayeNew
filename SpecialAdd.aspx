<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SpecialAdd.aspx.cs" Inherits="SpecialAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Special Tax Payer
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-title">
                            <div class="caption">
                                Add New Special
                            </div>
                            <div class="actions">
                                <a href="SpecialList.aspx" class="btn btn-redtheme"> Cancel </a>
                            </div>
                        </div>

    <div id="divSpecialForm">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Tax Payer Type </label>
                                            <asp:TextBox runat="server" ID="txttype" CssClass="form-control" placeholder="Special"></asp:TextBox>
                                            </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Special Name</label>
                                            <asp:TextBox runat="server" ID="txtspecialname" CssClass="form-control" placeholder="Enter Special Name"></asp:TextBox>
                                             </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">TIN</label>
                                            <asp:TextBox runat="server" ID="txtspecialtin" CssClass="form-control" placeholder="Enter TIN"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Phone 1</label>
                                            <asp:TextBox runat="server" ID="txtspecialphone1" CssClass="form-control" placeholder="Enter Phone 1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Phone 2</label>
                                            <asp:TextBox runat="server" ID="txtspecialphone2" CssClass="form-control" placeholder="Enter Phone 2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Email Address 1</label>
                                            <asp:TextBox runat="server" ID="txtspecialemail1" CssClass="form-control" placeholder="Enter Email Address 1"></asp:TextBox>
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Tax Office</label>
                                            <asp:DropDownList runat="server" ID="drpspecialtaxoffice" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Value="0" Text="Select Tax Office"></asp:ListItem>
                                            </asp:DropDownList>
                                           </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Preferred Notification</label>
                                            <asp:DropDownList runat="server" ID="drpspecialprefnotification" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Value="0" Text="Select Preferred Notification"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="text-right col-sm-12">
                                        <div class="form-group">
                                            <br />
                                            <asp:Button runat="server" ID="btnspecialsave" CssClass="btn-theme btn" Text="Save"/> 
                                          </div>
                                    </div>
                                </div>
                            </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

