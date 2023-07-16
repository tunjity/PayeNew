<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="/../code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />

    <style>
        #ContentPlaceHolder1_RegularExpressionValidator1 {
            color: red;
        }
    </style>

</asp:Content><asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    User Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-5">
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Edit User</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->

            <div class="box-body">
                <div class="form-group">

                    <asp:Label ID="lbl_fname" runat="server" Text="First Name"></asp:Label>
                    <asp:TextBox runat="server" ID="txt_fname" placeholder="Enter First Name" CssClass="form-control" required ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lbl_lname" runat="server" Text="Last Name"></asp:Label>
                    <asp:TextBox runat="server" ID="txt_lname" placeholder="Enter Last Name" CssClass="form-control" required ReadOnly="true"></asp:TextBox>
                     <asp:Label ID="lbl_phn" runat="server" Text="Phone Number"></asp:Label>
                    <asp:TextBox runat="server" ID="txt_phn" placeholder="Enter Phone Number" CssClass="form-control" required ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox runat="server" ID="txt_email" placeholder="Enter Email" CssClass="form-control" required ReadOnly="true"></asp:TextBox>
                     <asp:Label ID="lbl_password" runat="server" Text="Present Password"></asp:Label>
                    <asp:TextBox runat="server" ID="txt_password" placeholder="Enter Present Password" CssClass="form-control" required ReadOnly="true"></asp:TextBox>

                    <asp:Label ID="lbl_new_password" runat="server" Text="New Password"></asp:Label>
                    <asp:TextBox runat="server" ID="txt_new_password" placeholder="Enter New Password" CssClass="form-control" required></asp:TextBox>

                    <asp:Label ID="lbl_con_password" runat="server" Text="Confirm Password""></asp:Label>
                    <asp:TextBox runat="server" ID="txt_con_password" placeholder="Enter Confirm Password" CssClass="form-control" required></asp:TextBox>

                </div>
            </div>
            <!-- /.box-body -->

        </div>
    </div>
   
    <div class="col-md-10" align="center">
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
    </div>
    script>
</asp:Content>

