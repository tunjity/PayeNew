<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IndividualAdd.aspx.cs" Inherits="IndividualAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Individual Tax Payer
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-title">
                            <div class="caption">
                                Add New Individual
                            </div>
                            <div class="actions">
                                <a href="IndividualList.aspx" class="btn btn-redtheme"> Cancel </a>
                            </div>
                        </div>

    <div id="divIndividualForm">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Tax Payer Type </label>
                                            <asp:TextBox runat="server" ID="txttaxpayertype" CssClass="form-control" Enabled="false" Text="Individual"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Gender </label>
                                            <asp:DropDownList runat="server" ID="drpgender" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Value="0" Text="Select Gender"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Title </label>
                                            <asp:DropDownList runat="server" CssClass="form-control bs-select" ID="drptitle">
                                                <asp:ListItem Value="0" Selected="True" Text="Select Title"></asp:ListItem>
                                            </asp:DropDownList>
                                      </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">First Name</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtfirstname" placeholder="Enter First Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Last Name</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtlastname" placeholder="Enter Last Name"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Middle Name</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtmiddlename" placeholder="Enter Middle Name"></asp:TextBox>
                                           </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Date of Birth</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdob" placeholder="Enter Date of Birth"></asp:TextBox>
                                         </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">TIN</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txttin" placeholder="Enter TIN"></asp:TextBox>
                                          </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Phone 1</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtphone1" placeholder="Enter Phone 1"></asp:TextBox>
                                          </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Phone 2</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtphone2" placeholder="Enter Phone 2"></asp:TextBox>
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Email Address 1</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtemail1" placeholder="Enter Email Address 1"></asp:TextBox>
                                            </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Email Address 2</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtemail2" placeholder="Enter Email Address 2"></asp:TextBox>
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Biometric Details</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtbiometricdetail" placeholder="Enter Biometric Details"></asp:TextBox>
                                            </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Tax Office</label>
                                            <asp:DropDownList runat="server" ID="drptaxoffice" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Text="Select Tax Office" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Marital Status</label>
                                            <asp:DropDownList runat="server" ID="drpmaritialstatus" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Text="Select Maritial Status" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Nationality</label>
                                            <asp:DropDownList runat="server" ID="drpnationality" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Text="Select  Nationlality" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                           </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Economic Activity </label>
                                            <asp:DropDownList runat="server" ID="drpeconomicactivity" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Text="Select Economic Activity" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label">Preferred Notification</label>
                                            <asp:DropDownList runat="server" ID="drpprefnotification" CssClass="form-control bs-select">
                                                <asp:ListItem Selected="True" Text="Select Preferred Notification" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label class="control-label required-star">Contact Address </label>
                                            <asp:TextBox CssClass="form-control" placeholder="Enter Contact Address" runat="server" ID="txtaddress" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                           </div>
                                    </div>
                                    <div class="text-right col-sm-6">
                                        <div class="form-group">
                                            <br />
                                            <asp:Button runat="server" ID="btnsaveindividual" CssClass="btn-theme btn" Text="Save" />
                                       </div>
                                    </div>
                                </div>
                            </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

