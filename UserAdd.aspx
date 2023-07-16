<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="UserAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    User Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-title">
        <div class="caption">
            Add User
        </div>
        <div class="actions">
            <a href="UserManagement.aspx" class="btn btn-redtheme">Cancel </a>
        </div>
    </div>
        <div id="divIndividualForm">

            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label required-star">First Name</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtfirstname" placeholder="Enter First Name"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label required-star">Last Name</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtlastname" placeholder="Enter Last Name"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">

                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label">Middle Name</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtmiddlename" placeholder="Enter Middle Name"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label">Email Address</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtemail1" placeholder="Enter Email Address 1"></asp:TextBox>
                    </div>
                </div>
            </div><div class="row">

                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label">UserName</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtuserName" placeholder="Enter User Name"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label">Designation</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtdesign" placeholder="Enter Designation"></asp:TextBox>
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
                        <label class="control-label required-star">Role </label>
                        <asp:DropDownList runat="server" CssClass="form-control bs-select" ID="drptitle">
                            <asp:ListItem  Text="Select Role"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">

                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label">Password</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtpassword" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="control-label">Confirm Password</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtpassword2" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="text-right col-sm-6">
                    <div class="form-group">
                        <asp:Button ID="btnsaveindividual" Style="color: white;" CssClass="button" runat="server" Text="Save" OnClick="btn_add_user_Click" />
                        <%--             <asp:Button runat="server" ID="btnsaveindividual"OnClick="btn_add_user_Click" CssClass="btn-theme btn" Text="Save" />--%>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" runat="Server">
</asp:Content>

