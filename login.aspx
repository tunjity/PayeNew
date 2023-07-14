<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ERAS</title>
    
    <style>


.input {
    width: 35%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
}

.button {
    background-color: #2c8968;
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    cursor: pointer;
    width: 15%;
}

.button:hover {
    opacity: 0.8;
}

.cancelbtn {
    width: auto;
    padding: 10px 18px;
    background-color: #f44336;
}

.imgcontainer {
    text-align: center;
    margin: 24px 0 12px 0;
}

img.avatar {
    width: 40%;
    border-radius: 50%;
}

.container {
    padding: 16px;
}

span.psw {
    float: right;
    padding-top: 16px;
}
</style>
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
   
    
        <div class="top-bar">
            <div class="container">
                <div class="navbar-header">
                    <a href="index.html" class="navbar-brand">
                        <%--<img src="images/EIRS-logo.png" alt="" />--%>
                        <img src="images/Logo_New.png" alt="" style="height:174px;margin-top: -63px;" />
                        <h1 class="heading wow fadeInDown" style="margin-left: 335px;margin-top: 4px;color:#c00001;">Edo Revenue Administration System</h1> 
                    </a>
                </div>
                
               
            </div>
        </div>
        <div class="navbar navbar-default">
            <div class="container">
               
            </div>
        </div>
   
    


<section class="banner">
    <div class="container">
        <h1 class="heading wow fadeInDown" style="color:#5a5345;">LOGIN DETAILS</h1>
        <hr />
        
         <div class="row">
   <form runat="server" id="frmlogin">
                       
                        <div class="container">
                            <label><b>User Name</b></label>
                            <div style="border-radius:2px;">
                                <table width="100%">
                                    <tr>
                                       
                                        <td align="center"><asp:TextBox runat="server" ID="txtusername" placeholder="User name" CssClass="input"  required></asp:TextBox></td>
                                     </tr>
                                </table>
                              </div>
                       <%-- </div>
                        <div class="container">--%>
                            <label><b>Password</b></label>
                            <div style="border-radius:2px;">
                                <table width="100%">
                                    <tr>
                                       
                                        <td align="center"><asp:TextBox runat="server" ID="txtpassword" placeholder="Password" CssClass="input" TextMode="Password" required></asp:TextBox></td>
                                     </tr>
                                </table>
                              </div>
                            
                        
                    
                        <asp:Button ID="btnlogin" style="color: white;" CssClass="button" runat="server" Text="Login" OnClick="btnlogin_Click" />
                         <br /><br /></div>
                        <div id="divmsg" runat="server" class="msg-error" style="display:none;width:100% !important"><i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;Invalid Credentials. Please login again ! !</div>
                    </form>
        </div>   
        
    </div>
</section>



    <footer>
   
        <div class="container">
            <div class="row">
                <div class="col-sm-1">
                    <div class="navbar-brand">
                        <%--<img src="images/Logo.png" />--%>
                        <img src="images/Logo_New.png" style="height: 33px;width: 89px;"/>
                    </div>
                </div>
                <div class="col-sm-7" id="copyright">
                   
                    &copy; Copyright ERAS - Edo State Internal Revenue Service   <script>document.getElementById('copyright').appendChild(document.createTextNode(new Date().getFullYear()))</script>. All rights reserved
                </div>
                <div class="col-sm-4">
                   
                       
                            <a href="#">Data Protection</a>
                       &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="#">Terms of Use</a>
                       &nbsp;&nbsp;&nbsp;&nbsp; 
                            <a href="#">Contact Us</a>
                       
                   
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


    
</body>
</html>
