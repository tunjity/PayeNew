<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="controls.aspx.cs" Inherits="controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="col-sm-9">
                <div class="title">
                    <h1>
                        HEADING - BLANK
                    </h1>
                    <hr>
                </div>
        <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                TITLE
                            </div>
                          
                           
                        </div>
                        <div class="portlet-body">
                            <div class="row view-form">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label class="control-label bold" ID="Label1" runat="server" Text="TEST LABEL"></asp:Label> 
                                        <div class="form-control-static">
                                         <asp:TextBox class="form-control" placeholder="TEST TEXTBOX"  ID="TextBox1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="control-label bold" ID="Label2" runat="server" Text="TEST LABEL"></asp:Label> 
                                        <div class="form-control-static">
                                            Tax Payer TIN
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="control-label bold" ID="Label3" runat="server" Text="TEST LABEL"></asp:Label> 
                                        <div class="form-control-static">
                                            Mobile Number
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <asp:Label class="control-label bold" ID="Label4" runat="server" Text="TEST LABEL"></asp:Label> 
                                        <div class="form-control-static">
                                               <asp:TextBox class="form-control" placeholder="TEST TEXTBOX"  ID="TextBox2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="control-label bold" ID="Label5" runat="server" Text="TEST LABEL"></asp:Label> 
                                        <div class="form-control-static">
                                            Tax Payer RIN
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label class="control-label bold" ID="Label6" runat="server" Text="TEST LABEL"></asp:Label> 
                                        <div class="form-control-static">
                                            Contact  Address
                                        </div>
                                    </div>
                                     <asp:Button ID="Button1" class="btn btn-redtheme" runat="server" Text="TEST Button" />
                                </div>
                            </div>
                        </div>
                    </div>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

