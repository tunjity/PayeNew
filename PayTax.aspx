<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayTax.aspx.cs" Inherits="PayTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">
    <style type="text/css">
        .paymentoptions {
            width:25%;
            border:1px solid;
            background-color: #f2f2f2;
        }
            .paymentoptions:hover {
                background-color: #ddd;
            }
       .btn {
  background: #a1a5a8;
  background-image: -webkit-linear-gradient(top, #a1a5a8, #4f5152);
  background-image: -moz-linear-gradient(top, #a1a5a8, #4f5152);
  background-image: -ms-linear-gradient(top, #a1a5a8, #4f5152);
  background-image: -o-linear-gradient(top, #a1a5a8, #4f5152);
  background-image: linear-gradient(to bottom, #a1a5a8, #4f5152);
  -webkit-border-radius: 4;
  -moz-border-radius: 4;
  border-radius: 4px;
  font-family: Arial;
  color: #ffffff;
  font-size: 14px;
  padding: 8px 20px 8px 20px;
  text-decoration: none;
}

.btn:hover {
  background: #8a8e91;
  background-image: -webkit-linear-gradient(top, #8a8e91, #1e1f1f);
  background-image: -moz-linear-gradient(top, #8a8e91, #1e1f1f);
  background-image: -ms-linear-gradient(top, #8a8e91, #1e1f1f);
  background-image: -o-linear-gradient(top, #8a8e91, #1e1f1f);
  background-image: linear-gradient(to bottom, #8a8e91, #1e1f1f);
  text-decoration: none;
}

        .heading {
            font-size:14px;
            font-weight:400;
            font-family:sans-serif;
            
        }

        .txt {
            border-bottom:1px solid;
            border-top:none;
            border-left:none;
            border-right:none;
        }
        .td-stle {
            padding-bottom:15px;
            padding-top:5px;
        }
    </style>
    
     <script src="https://js.paystack.co/v1/inline.js"></script>
    <script>
        function payWithPaystack() {
            document.getElementById('donotrefresh').style.display = '';
            document.getElementById('paymentgate').style.display = 'none';
            var email = document.getElementById('<%=lblemailid.ClientID%>').value;
            var amount = document.getElementById('<%=lblamount.ClientID%>').value;
            var mobileno = document.getElementById('<%=lblmobilenumber.ClientID%>').value;
            var txnid = document.getElementById('<%=lbltxnid.ClientID%>').value;
            var handler = PaystackPop.setup({
                key: 'pk_test_eec85b91bc8299374baaac0454c5806aeee58db1',
                email: email,
                amount: amount,
                ref: '' + txnid, // generates a pseudo-unique reference. Please replace with a reference you generated. Or remove the line entirely so our API will generate one for you
                metadata: {
                    custom_fields: [
                       {
                           display_name: "Mobile Number",
                           variable_name: "mobile_number",
                           value: mobileno
                       }
                    ]
                },
                callback: function (response) {
                    window.location.href = "PaymentResponse.aspx?res=1-" + response.reference;

                },
                onClose: function () {
                    window.location.href = "PaymentResponse.aspx?res=0-accaw6846813843843";
                }
            });
            handler.openIframe();
        }

        function changediv(flag) {
            var divpaycc = document.getElementById('paywithcc');
            var divpayscr = document.getElementById('paywithscratch');
            var paywithccoption = document.getElementById('paywithccoption');
            var paywithscratchoption = document.getElementById('paywithscratchoption');
            if (flag == 1) {
                divpaycc.style.display = '';
                divpayscr.style.display = 'none';

            }
            else {
                divpaycc.style.display = 'none';
                divpayscr.style.display = '';

            }
        }

        function pay() {
            var txnid = document.getElementById('<%=lbltxnid.ClientID%>').value;
            document.getElementById('donotrefresh').style.display = '';
            document.getElementById('paymentgate').style.display = 'none';
            window.location.href = "PaymentResponse.aspx?res=1-" + txnid;
        }

        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

</script>
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
   EIRS PAYE PAYMENT GATEWAY 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div id="paymentgate">
        <table align="center" class="table borderless">
            <tr><td>Company Name</td><td><asp:TextBox Enabled="false" runat="server" ID="lblcompname" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Email Id</td><td><asp:TextBox Enabled="false" runat="server" ID="lblemailid" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Mobile Number</td><td><asp:TextBox Enabled="false" runat="server" ID="lblmobilenumber" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Company RIN</td><td><asp:TextBox Enabled="false" runat="server" ID="lblcomprin" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Year of Assessment</td><td><asp:TextBox Enabled="false" runat="server" ID="lblyear" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Assessment Ref</td><td><asp:TextBox Enabled="false" runat="server" ID="lblassessmentref" CssClass="form-control"></asp:TextBox><asp:TextBox Enabled="false" runat="server" ID="lbltxnid" Width="1px" Height="1px"></asp:TextBox></td></tr>
            <tr><td>Month(s) of Assessment</td><td><asp:TextBox Enabled="false" runat="server" ID="txtMonth" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Assessment Amount</td><td><asp:TextBox Enabled="false" runat="server" ID="lblamount" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Total Settled Amount</td><td><asp:TextBox Enabled="false" runat="server" ID="txttsa" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Balance Amount</td><td><asp:TextBox Enabled="false" runat="server" ID="txtba" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td>Amount to pay</td><td><asp:TextBox Enabled="true" runat="server" ID="txtatp" Text="0" onkeypress="return isNumberKey(event,this)" CssClass="form-control"></asp:TextBox></td></tr>
            <tr><td colspan="2"><asp:CompareValidator ControlToValidate="txtatp" ControlToCompare="txtba" Operator="LessThanEqual" runat="server" ID="cmp" Type="Double" ErrorMessage="Amount to pay cannot be greater than Balance" ValidationGroup="payment"></asp:CompareValidator>
            </td></tr>
            <tr><td><asp:Label runat="server" ID="lblmsg" Visible="false" ForeColor="Red"></asp:Label></td></tr>
        </table>
       <div align="center">
             <asp:GridView runat="server" AutoGenerateColumns="False" ID="grdsettlements" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader">
                 <Columns>
                     <asp:TemplateField HeaderText="Settlement Refrence Number">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblsetref" Text='<%#Bind("settlement_ref") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField HeaderText="Assessment Refrence Number">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblsetref" Text='<%#Bind("assessment_ref") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField HeaderText="Settlement Amount">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblsetref" Text='<%#Bind("settlement_amount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField HeaderText="Settlement Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblsetref" Text='<%#Eval("settlement_date","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField HeaderText="Settlement Method">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblsetref" Text='<%#Bind("settlement_method") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                 </Columns>
               </asp:GridView>
         </div>
         <table style="width:90%;border:10px solid;color:#467fdb;border-radius:5px 5px 5px 5px;" align="center">
            <tr><td class="paymentoptions" ><a href="#" onclick="changediv(1)" id="paywithccoption" style="text-decoration:none; color:black;"><div style="padding:20px;"><i class="fa fa-credit-card" style="font-size:20px;"></i> Pay via Credit Card/ Debit Card</div></a></td>
                <td rowspan="2" style="border:1px solid;width:49%;padding-left:10px;">
                    <div id="paywithcc" style="color:black;width:100%;">
                        <table style="width:100%;">
                            <tr><td><span class="heading">Card Number</span></td></tr>
                            <tr><td class="td-stle"><asp:TextBox runat="server" ID="txtcardnumber" placeholder="CARD NUMBER" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="txtcardnumber" ErrorMessage="Enter card number" ID="reqcard" ValidationGroup="pay"></asp:RequiredFieldValidator></td></tr>
                            <tr><td><span class="heading">Expiry Date</span></td></tr>
                            <tr><td><table border="0">
                                        <tr>
                                            <td><asp:TextBox runat="server" ID="txtccMonth" placeholder="MM" CssClass="form-control" Width="50px"></asp:TextBox></td><td>&nbsp;&nbsp;</td>
                                            <td><asp:TextBox runat="server" Width="50px" ID="txtccyear" placeholder="YY" CssClass="form-control"></asp:TextBox> </td>
                                            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="txtccMonth" ErrorMessage="Enter month" ID="RequiredFieldValidator1" ValidationGroup="pay"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtccYear" ErrorMessage="Enter Year" ID="RequiredFieldValidator2" ValidationGroup="pay"></asp:RequiredFieldValidator></td>
                                        </tr>
                                    </table></td></tr>
                            <tr><td><br /></td></tr>
                            <tr><td><span class="heading">CVV</span></td></tr>
                            <tr><td class="td-stle"><asp:TextBox runat="server" ID="txtcvv" placeholder="CVV" CssClass="form-control" Width="50px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="txtcvv" ErrorMessage="Enter CVV" ID="RequiredFieldValidator3" ValidationGroup="pay"></asp:RequiredFieldValidator></td></tr>
                            <tr><td><span class="heading">PIN</span></td></tr>
                            <tr><td class="td-stle"><asp:TextBox runat="server" ID="txtccpin" placeholder="PIN" CssClass="form-control" Width="50px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="txtccpin" ErrorMessage="Enter pin" ID="RequiredFieldValidator4" ValidationGroup="pay"></asp:RequiredFieldValidator></td></tr>
                        </table>
                        <span style="padding-left:200px;"><asp:Button runat="server" CssClass="btn btn-redtheme" Text="Pay" ID="btnpaywithdc" OnClick="btnpaywithdc_Click" ValidationGroup="pay"/></span>
                    </div>
                    <div id="paywithscratch" style="color:black;display:none;">
                        <i class="fa fa-info-circle" style="font-size:20px;"></i>Enter PIN for Scratch Card <asp:TextBox runat="server" ID="txtscratchpin"></asp:TextBox><asp:RequiredFieldValidator runat="server" ID="reqsc" ErrorMessage="Enter Scratch Card Pin" ControlToValidate="txtscratchpin" ValidationGroup="payscratch"></asp:RequiredFieldValidator><br />
                        <span style="padding-left:90px;"><asp:Button runat="server" ID="btnScratch" CssClass="btn btn-redtheme" Text="Pay" OnClick="btnScratch_Click" ValidationGroup="payscratch" /></span>
                    </div>

                </td>
            </tr>
            <tr><td class="paymentoptions"><a href="#" onclick="changediv(2)" id="paywithscratchoption" style="text-decoration:none;color:black;"><div style="padding:20px;"><i class="fa fa-money" style="font-size:20px;"></i>  Pay via Scratch Card</div></a></td></tr>
            
        </table>
      <asp:Label runat="server" ID="message"></asp:Label>
    </div>
    <div id="donotrefresh" style="margin:auto;display:none;width:40%;">Please do not press back or refresh the page...<br /><img src="images/loader.gif" style="margin-left:130px;position:relative;" /></div>
    
</asp:Content>

