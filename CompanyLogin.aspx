<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="CompanyLogin.aspx.cs" Inherits="CompanyLogin" %>

<html>


<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrapnew.min.css" />
    <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="css/simple-line-icons.css" />
    <link rel="stylesheet" type="text/css" href="css/typeahead.css" /><!-- not present -->
    <link rel="stylesheet" type="text/css" href="css/components.min.css" />
    <link rel="stylesheet" type="text/css" href="css/layout.min.css" />
    <link rel="stylesheet" type="text/css" href="css/plugins.min.css" />
    <link rel="stylesheet" type="text/css" href="css/theme.min.css" />
    <link rel="stylesheet" type="text/css" href="css/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="css/custom.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap-select.min.css" />
     <link rel="shortcut icon" href="images/favicon.jpg" />

</head>
<body>
 <form id="frm1" runat="server">
    <header>
        <div class="top-bar">
            <div class="container">
                <div class="navbar-header">
                    <a href="index.html" class="navbar-brand">
                        <img src="images/EIRS-logo.png">
                        <img src="images/Logo.png">
                    </a>
                </div>
                <ul>
                    <li><a href="#">Sign Up</a></li>
                    <li><a href="Login.aspx">Login</a></li>
                </ul>
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navMainMenu" aria-expanded="false">
                    <i class="fa fa-bars"></i>
                </button>
            </div>
        </div>
        <div class="navbar navbar-default">
            <div class="container">
                <div class="navbar-collapse collapse" id="navMainMenu" aria-expanded="false">
                    <ul class="nav navbar-nav">
                        <li class=" switch-li no-hover">
                            <a href="index.html">
                                <label class="switch">
                                    <input type="checkbox" id="chkMenuSwitch">
                                    <span class="slider round"></span>
                                </label>
                            </a>
                        </li>
                        <li class=""><a href="#">About</a></li>
                        <li class=""><a href="#">Awareness</a></li>
                        <li class=""><a href="#">Tax Payers</a></li>
                        <li class=""><a href="#">Tax Assets</a></li>
                        <li class=""><a href="#">Services</a></li>
                        <li class=""><a href="#">Partnership</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </header>


    <section class="alternate">
        <div class="container">

            <div class="title">
                <h1>
                    Login as a Tax Payer - Company
                </h1>
                <hr>
                <p>
                    Only registered tax payers can gain access to this system
                </p>
            </div>

            <div class="row">
                <div class="col-sm-4">
                    <div class="portlet light compressed-menu">
                        <div class="portlet-title">
                            <div class="caption">
                                Login
                            </div>
                        </div>
                        <div class="portlet-body ">
                            <p class="padded">
                                Select one option from below
                            </p>
                            <ul class="nav">
                                <li >
                                    <a href="Login.aspx"><i class="fa fa-angle-right"></i> Tax Payer - Individual</a>
                                </li>
                                <li class="active">
                                    <a href="CompanyLogin.aspx"><i class="fa fa-angle-right"></i>  Tax Payer - Company</a>
                                </li>
                                <li>
                                    <a href="GovernmentLogin.aspx"><i class="fa fa-angle-right"></i>  Tax Payer - Government</a>
                                </li>
                                <li>
                                    <a href="StaffAccessLogin.aspx"><i class="fa fa-angle-right"></i>  Staff Access</a>
                                </li>
                                <li>
                                    <a href="PartnerAccessLogin.aspx"><i class="fa fa-angle-right"></i>  Partner Access</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

                <div class="col-sm-8">
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                Log into ERAS as Tax Payer - Company
                            </div>
                        </div>
                        <div class="portlet-body ">
                            <div class="row">
                                <div class="col-sm-7">
                                    <div class="form-group">
                                        <label class="control-label">Enter RIN or Mobile No – 234X</label>
                                        <span class="pull-right"><a href="#"> GOT NONE, GET ONE</a></span>
                                        <asp:TextBox runat="server" ID="txtusername" placeholder="User name" CssClass="form-control"  required></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label">Password</label>
                                        <span class="pull-right"><a href="#"> Forgot Password</a></span>
                                        <asp:TextBox runat="server" ID="txtpassword" placeholder="Password" CssClass="form-control" TextMode="Password" required></asp:TextBox>
                                    </div>

                                    <div class="form-group text-right">
                                        
                                       <asp:Button ID="btnlogin" style="color: white;" CssClass="btn btn-theme" runat="server" Text="Login" /><br />
                                        <div id="divmsg" runat="server" class="alert alert-danger" style="display:none;margin:auto;width:auto !important;text-align:center;"><i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;Invalid Credentials. Please login again ! !</div>       
                                    </div>
                                </div>
                                <div class="col-sm-5">
                                    
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>

    <footer>
        <div class="container">
            <div class="row">
                <div class="col-sm-1">
                    <div class="navbar-brand">
                        <img src="images/Logo.png">
                    </div>
                </div>
                <div class="col-sm-7">
                    © Copyright ERAS - Edo State Internal Revenue Service <%= year %>. All rights reserved
                </div>
                <div class="col-sm-4">
                    <ul>
                        <li>
                            <a href="#">Data Protection</a>
                        </li>
                        <li>
                            <a href="#">Terms of Use</a>
                        </li>
                        <li>
                            <a href="#">Contact Us</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </footer>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="js/jquery.unobtrusive-ajax.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.unobtrusive.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-select.min.js"></script>
    <script type="text/javascript" src="js/select2.min.js"></script>
    <script type="text/javascript" src="js/jsCommon.js"></script>
    <script type="text/javascript" src="js/jsCustomValidator.js"></script>

     </form>
</body>


</html>
