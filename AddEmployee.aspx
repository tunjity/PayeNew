<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="AddEmployee" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style text="text/css">
        .tbl {
            width:1100px;
            border-collapse: collapse;
        }
        .ajax__calendar_day_disabled {
            text-decoration: line-through;
        }
    
    </style>
    <script type="text/javascript" language="javascript">
        function CheckAllEmp(Checkbox) {
            var grdCheckBox = document.getElementById("<%=grdemp.ClientID %>");
            for (i = 1; i < grdCheckBox.rows.length; i++) {
                grdCheckBox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }

        function CheckAllEmpNV(Checkbox) {
            var grdCheckBox = document.getElementById("<%=grdnotvalidated.ClientID %>");
            for (i = 1; i < grdCheckBox.rows.length; i++) {
                grdCheckBox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
        
        </script>
    <script type="text/javascript">
        function calcgross() {
            var basic = document.getElementById('<%=txtbasic.ClientID %>').value;
            var rent = document.getElementById('<%=txtRent.ClientID %>').value;
            var trans = document.getElementById('<%=txttrans.ClientID %>').value;
            var utility = document.getElementById('<%=txtutilityadd.ClientID %>').value;
            var meal = document.getElementById('<%=txtmealadd.ClientID %>').value;
            var othall = document.getElementById('<%=txtothalladd.ClientID %>').value;
            var ltg = document.getElementById('<%=txtltgadd.ClientID %>').value;
            var gross = parseFloat(basic) + parseFloat(rent) + parseFloat(trans) + parseFloat(utility) + parseFloat(meal) + parseFloat(othall) + parseFloat(ltg);
            document.getElementById('<%=txtgross.ClientID %>').value = gross;
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

        function checkDate(sender, args) {
            if (sender._selectedDate >= new Date()) {
                alert("Future dates are not allowed!");
                sender._textbox.set_Value("");
            }
        }


       
    </script>
    
    
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="contentheading" runat="server">
    Add Employee with Payroll Data
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script src="js/Extension.min.js" type="text/javascript"></script>
    <div id="divmsg" class="" runat="server" style="display:none"></div>
    <div runat="server" id="divmain">
    <table id="box" style="width:98%;">
        <tr><td><br /></td></tr>
               <tr>
         <td colspan="8" align="center">
            
            <table>
                <tr>
                    <td align="right">Select Company</td><td width="30"></td><td>:&nbsp;&nbsp;</td><td align="left"><asp:DropDownList ID="drpfupcomapny" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpfupcomapny_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                 <tr>
                    <td align="right">Select Business</td><td width="30"></td><td>:</td><td align="left"><asp:DropDownList ID="drpbusiness" runat="server" CssClass="form-control"></asp:DropDownList><asp:Label Text="NA" runat="server" ID="lblnabusiness" Visible="false"></asp:Label></td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td align="right">Select File to upload</td><td width="30"></td><td>:</td><td><asp:FileUpload runat="server" ID="fpemp" style="float:left;" /> &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr><td colspan="4"><a href="EmployeeTemplate.xls" style="font-size:small; text-decoration:underline;color:blue;">Download Employee Template here</a></td></tr>
                 <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr class="tblrw"><td colspan="4" align="center"><asp:Button ID="btnupload" CssClass="btn btn-redtheme" Text="Upload" runat="server" OnClick="btnupload_Click" /></td></tr>
                <tr><td colspan="4" align="center"><br /></td></tr>
            </table>
          </td>     
        </tr>
        <tr>
            <td colspan="8" align="center">
                <div id="addindividual" runat="server">
                <table class="table borderless" border="0">
                    <tr>
                    <td colspan="8" align="center">If You Want To View Existing Employees in this Company... <asp:LinkButton id="link_click" Text="Click here..." CssClass="sbbtn" OnClick="LinkButton_Click" runat="server"/></td></tr>
                    <tr class="tblrw">
                    <td align="right">Nationality</td><td>:</td><td align="left"><asp:DropDownList ID="txtnationality" CssClass="form-control" runat="server"></asp:DropDownList></td><td width="30"></td> 
                        <td align="right"></td> <td></td><td> <asp:DropDownList ID="drpcompany" runat="server" CssClass="form-control" Visible="false"></asp:DropDownList></td><td width="30"></td> 
        </tr>
          <tr class="tblrw">
            <td align="right">Title</td><td>:</td><td align="left"><asp:DropDownList ID="drptitle" CssClass="form-control" runat="server" ></asp:DropDownList></td><td width="30"></td>
            <td align="right">Gross</td> <td>:</td><td><asp:TextBox ID="txtgross" runat="server" CssClass="form-control" Text="0" onkeypress="return false"></asp:TextBox></td>
             <td width="30"><asp:RequiredFieldValidator ID="reqgross" runat="server" ControlToValidate="txtgross" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw">
            <td align="right">First Name</td><td>:</td><td><asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td width="30"><asp:RequiredFieldValidator ID="reqfname" runat="server" ControlToValidate="txtfirstname" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
            <td align="right">Basic</td><td>:</td><td><asp:TextBox ID="txtbasic" runat="server" CssClass="form-control" Text="0" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
                <td width="30"><asp:RequiredFieldValidator ID="reqbasic" runat="server" ControlToValidate="txtbasic" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw">
            <td align="right">Last Name</td><td>:</td><td><asp:TextBox ID="txtlastname" runat="server" CssClass="form-control"></asp:TextBox></td>    
             <td width="30"><asp:RequiredFieldValidator ID="reqlname" runat="server" ControlToValidate="txtlastname" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
            <td align="right">Rent</td> <td>:</td><td><asp:TextBox ID="txtRent" runat="server" CssClass="form-control" Text="0" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
                <td width="30"><asp:RequiredFieldValidator ID="reqrent" runat="server" ControlToValidate="txtRent" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw">
            <td align="right">Date of birth</td><td>:</td><td><asp:TextBox ID="txtdob" runat="server" CssClass="disable_future_dates form-control" Autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="caldob" TargetControlID="txtdob" Format="yyyy-MM-dd" runat="server" DefaultView="Years"  ></cc1:CalendarExtender></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqdob" runat="server" ControlToValidate="txtdob" ValidationGroup="submit" ErrorMessage="*"></asp:RequiredFieldValidator> </td>
            <td align="right">Annual Transport</td><td>:</td><td><asp:TextBox ID="txttrans" runat="server" CssClass="form-control" Text="0" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqtrans" runat="server" ControlToValidate="txttrans" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw">
            <td align="right">Gender</td><td>:</td><td><asp:RadioButtonList ID="radgender" runat="server" RepeatColumns="2"><asp:ListItem Selected="True" Value="Male" Text="Male"></asp:ListItem><asp:ListItem Text="Female" Value="Female"></asp:ListItem></asp:RadioButtonList></td><td width="30"></td> 
            <td align="right">Pension Declared</td><td>:</td><td><asp:TextBox ID="txtpensiondeclared" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqpensiondeclared" runat="server" ControlToValidate="txtpensiondeclared" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw">
            <td align="right">TIN</td><td>:</td><td><asp:TextBox ID="txtemptin" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqemptin" runat="server" ControlToValidate="txtemptin" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
            <td align="right">NHF Declared</td><td>:</td><td><asp:TextBox ID="txtnhfdeclared" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqnhfdeclared" runat="server" ControlToValidate="txtnhfdeclared" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw">
            <td align="right">Mobile </td><td>:</td><td><asp:TextBox ID="txtmobile" runat="server" CssClass="form-control"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqmobile" runat="server" ControlToValidate="txtmobile" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
            <td align="right">NHIS Declared</td> <td>:</td><td><asp:TextBox ID="txtnhisdeclared" runat="server" CssClass="form-control" Text="0" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
                <td width="30"><asp:RequiredFieldValidator ID="reqnhisdeclared" runat="server" ControlToValidate="txtnhisdeclared" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
        </tr>
            
        <tr class="tblrw">
            <td align="right">Email Address </td><td>:</td><td><asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox></td><td width="30"></td> 
            <td align="right">Salary Start Date</td><td>:</td><td><asp:TextBox ID="txtsalarystartdate" runat="server" CssClass="disable_future_dates form-control"></asp:TextBox><cc1:CalendarExtender ID="calstartdate" TargetControlID="txtsalarystartdate" Format="yyyy-MM-dd" runat="server" ></cc1:CalendarExtender></td> 
                <td width="30"><asp:RequiredFieldValidator ID="reqsalstartdate" runat="server" ValidationGroup="submit" ControlToValidate="txtsalarystartdate" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>

        <tr class="tblrw">
            <td align="right">RIN </td><td>:</td><td><asp:TextBox ID="txtRINadd" runat="server" CssClass="form-control"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRINadd" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
            <td align="right">Filters</td><td></td><td><asp:CheckBox runat="server" Text="Pension" ID="chkpensionadd" /><asp:CheckBox runat="server" Text="NHF" ID="chknhfadd" /><asp:CheckBox runat="server" Text="NHIS" ID="chknhisadd" /></td><td width="30"></td> 
        </tr>
        <tr class="tblrw">
            <td align="right">Utility </td><td>:</td><td><asp:TextBox ID="txtutilityadd" Text="0" runat="server" CssClass="form-control" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtutilityadd" ErrorMessage="*" ValidationGroup="submit"></asp:RequiredFieldValidator></td>
            <td align="right">Meal</td><td>:</td><td><asp:TextBox ID="txtmealadd" Text="0" runat="server" CssClass="form-control" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="submit" ControlToValidate="txtmealadd" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
         <tr class="tblrw">
            <td align="right">Other Allowances </td><td>:</td><td><asp:TextBox ID="txtothalladd" Text="0" runat="server" CssClass="form-control" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="submit" ControlToValidate="txtothalladd" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td align="right">Leave Transport Grant</td><td>:</td><td><asp:TextBox ID="txtltgadd" Text="0" runat="server" CssClass="form-control" onkeyup="calcgross();" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td> 
                <td width="30"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="submit" ControlToValidate="txtltgadd" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr class="tblrw"><td colspan="8" align="center"><asp:Button Text="Add" ID="btnsubmit" CssClass="btn btn-redtheme" runat="server" OnClick="btnsubmit_Click" ValidationGroup="submit" /></td></tr>
                </table>
                    </div>
            </td>
        </tr>
        </table>
        <table>
        <tr class="tblrw"><td> </td></tr>
        <tr><td><br /></td></tr>
        <tr class="tblrw">
            <td colspan="8" align="left">
            <asp:Panel runat="server" ID="pnltax" Visible="false">
                <div class="title"><h1>Tax Calculation</h1><hr /></div>
                <asp:CheckBox ID="chkPension" runat="server" Text="Pension" />
                <asp:CheckBox ID="chkNHF" runat="server" Text="NHF" />
                <asp:CheckBox ID="chkNHIS" runat="server" Text="NHIS" />
                <asp:Panel runat="server" ID="pnlEmp" style="width:70%;overflow-x:scroll;">
                <asp:GridView runat="server" ID="grdemp" AutoGenerateColumns="False" CellPadding="4" 
                    EnableModelValidation="True" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader">
                   <Columns>
                        
                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="70px" ShowHeader="true">
                             <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chksalall" onclick="CheckAllEmp(this);"/>Select 
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkemp" />
                            </ItemTemplate>
                        </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rin" > 
                            <ItemTemplate>
                                <asp:Label ID="lblrin" runat="server" Text='<%#Bind("Rin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tin" Visible="false"> 
                            <ItemTemplate>
                                <asp:Label ID="lbltin" runat="server" Text='<%#Bind("tin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("first_name") +" "+ Eval("last_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <asp:Label ID="lblnationality" runat="server" Text='<%#Bind("nationality") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gross">
                            <ItemTemplate>
                                <asp:Label ID="lblgross" runat="server" Text='<%#Bind("sal_gross") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Basic">
                            <ItemTemplate>
                                <asp:Label ID="lblbasic" runat="server" Text='<%#Bind("sal_basic") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rent">
                            <ItemTemplate>
                                <asp:Label ID="lblrent" runat="server" Text='<%#Bind("sal_rent") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Transport">
                            <ItemTemplate>
                                <asp:Label ID="lbltrans" runat="server" Text='<%#Bind("sal_trans") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pension">
                            <ItemTemplate>
                                <asp:Label ID="lblpension" runat="server" Text='<%#Bind("sal_pension") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="NHF">
                            <ItemTemplate>
                                <asp:Label ID="lblnhf" runat="server" Text='<%#Bind("sal_nhf") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS">
                            <ItemTemplate>
                                <asp:Label ID="lblnhis" runat="server" Text='<%#Bind("sal_nhis") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Utility">
                            <ItemTemplate>
                                <asp:Label ID="lblutility" runat="server" Text='<%#Bind("sal_utility") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Meal">
                            <ItemTemplate>
                                <asp:Label ID="lblmeal" runat="server" Text='<%#Bind("sal_meal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Other Allowances">
                            <ItemTemplate>
                                <asp:Label ID="lblothall" runat="server" Text='<%#Bind("sal_otherallowances") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Leave Transport Grant">
                            <ItemTemplate>
                                <asp:Label ID="lblltg" runat="server" Text='<%#Bind("sal_ltg") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Emp Date">
                            <ItemTemplate>
                                <asp:Label ID="lblstart_date" runat="server" Text='<%#Eval("start_date","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblgender"  runat="server" Text='<%#Bind("gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbltitle"  runat="server" Text='<%#Bind("title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblfirst_name"  runat="server" Text='<%#Bind("first_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbllast_name"  runat="server" Text='<%#Bind("last_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblcompany_rin"  runat="server" Text='<%#Bind("company_rin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblmobilenumber"  runat="server" Text='<%#Bind("mobile_number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblemailaddress"  runat="server" Text='<%#Bind("email_address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbluserrin"  runat="server" Text='<%#Bind("rin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Emp Date" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbldob" runat="server" Text='<%#Eval("date_of_birth","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    
                </asp:GridView>

                </asp:Panel>
                <asp:Button Text="Compute" runat="server" CssClass="btn btn-redtheme" ID="btncompute" OnClick="btncompute_Click" />
                <asp:Button Text="Reset" runat="server" CssClass="btn btn-redtheme" ID="btnreset" OnClick="btnreset_Click" />
                <asp:Button Text="Register" runat="server" CssClass="btn btn-redtheme" ID="btnregister" OnClick="btnregister_Click" />
            </asp:Panel>
            <br />
         </td>

        </tr>
    </table>
    
    <div style="width:100%;overflow:auto;">
    <table align="center" style="width:100%; height: 412px;display:none" runat="server" id="tblupdemp">
        <tr><td><h6>Click on employee to update employee details else click on <b>Proceed</b> button to proceed to assessment</h6></td></tr>
            <tr style="text-align:center; width:100%">
            <td style="text-align: center; width:100%">
            <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" Width="100%"  AllowPaging="True" PageSize="8" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader"
                 OnSelectedIndexChanged="gvEmployee_SelectedIndexChanged" OnRowDataBound="OnRowDataBound"  >        
                <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                <Columns>
                    <asp:BoundField DataField="ind_id" HeaderText="Employee ID" />
                    <asp:BoundField DataField="user_rin" HeaderText="Employee RIN" />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" />
                    <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                    <asp:BoundField DataField="date_of_birth" HeaderText="DOB" DataFormatString="{0:d}" />        
                    <asp:BoundField DataField="tin" HeaderText="TIN" />
                    <asp:BoundField DataField="mobile_number_1" HeaderText="Mobile" />
                    <asp:BoundField DataField="email_address_1" HeaderText="E-mail"/>
                    <asp:BoundField DataField="nationality" HeaderText="Nationality" />
                 </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
<EmptyDataTemplate>No Record Available</EmptyDataTemplate>
        </asp:GridView>
             </td>
             </tr>
        <tr><td align="center"><asp:Button ID="btnproceed" runat="server" Text="Proceed" CssClass="btn btn-redtheme" OnClick="btnproceed_Click" /></td></tr>
      </table>
    </div>

   <div id="div_update" runat="server" visible="false">
       <table  style="text-align:center;width: 98%;" cellpadding="2" cellspacing="5"   id="Table1">
                 <tr class="tblrw">
             <td colspan="5">
                 <div class="tile"><h1>Update Employee Salary Structure <asp:Label ID="lbl_emp_id" runat="server" Visible="false"></asp:Label></h1><hr /></div> </td>
         </tr>
            
                
                <tr class="tblrw">
            <td style="text-align:right" align="left" ><asp:Label ID="lbl_gross" runat="server" Text="Gross:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txt_gross"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
    <td></td>
     <td style="text-align: right" ><asp:Label ID="lbl_annual_basic" runat="server" Text="Annual Basic:" CssClass="control-label bold"></asp:Label></td>
            <td ><asp:TextBox ID="txt_annual_basic"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
        </tr>

             <tr class="tblrw">
            <td style="text-align: right" ><asp:Label ID="lbl_rent" runat="server" Text="Rent:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txt_rent"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
    <td></td>
     <td style="text-align: right" ><asp:Label ID="lbl_annual_transport" runat="server" Text="Annual Transport:" CssClass="control-label bold"></asp:Label></td>
            <td><asp:TextBox ID="txt_annual_transport"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
        </tr>
<tr class="tblrw">
            <td style="text-align: right" ><asp:Label ID="lbl_pension_dec_by_tax_payer" runat="server" Text="Pension Declared By Tax Payer:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txt_pension_declared"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
    <td></td>
     <td style="text-align: right"><asp:Label ID="lbl_NHF_dec_by_tax_payer" runat="server" Text="NHF Declared By Tax Payer:" CssClass="control-label bold"></asp:Label></td>
            <td><asp:TextBox ID="txt_NHF_declared"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
        </tr>

<tr class="tblrw">
            <td style="text-align: right" ><asp:Label ID="Label1" runat="server" Text="Utility:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtutilityupd"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
    <td></td>
     <td style="text-align: right"><asp:Label ID="Label2" runat="server" Text="Meal:" CssClass="control-label bold"></asp:Label></td>
            <td><asp:TextBox ID="txtmealupd"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
        </tr>

<tr class="tblrw">
            <td style="text-align: right" ><asp:Label ID="Label3" runat="server" Text="Other Allowances:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txtothallupd"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
    <td></td>
     <td style="text-align: right"><asp:Label ID="Label4" runat="server" Text="Leave Transport Grant:" CssClass="control-label bold"></asp:Label></td>
            <td><asp:TextBox ID="txtltgupd"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
        </tr>

<tr class="tblrw">
             <td style="text-align: right" ><asp:Label ID="lbl_start_date" runat="server" Text="New Salary Start Date:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txt_start_date"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="req1" runat="server" ValidationGroup="update" ErrorMessage="This field is required" ControlToValidate="txt_start_date"></asp:RequiredFieldValidator><cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txt_start_date" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender></td>
    <td></td>
     <td style="text-align: right" ><asp:Label ID="lbl_NHIS_declared" runat="server" Text="NHIS Declared by the tax payer:" CssClass="control-label bold"></asp:Label></td>
            <td><asp:TextBox ID="txt_NHIS_declared"  CssClass="form-control" runat="server" onkeypress="return isNumberKey(event,this)"></asp:TextBox></td>
        </tr>

<tr class="tblrw">
             <td style="text-align: right" ><asp:Label ID="lbl_end_date" runat="server" Text="Last Salary End Date:" CssClass="control-label bold"></asp:Label></td>
            <td align="left"><asp:TextBox ID="txt_end_date"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="update" ErrorMessage="This field is required" ControlToValidate="txt_end_date"></asp:RequiredFieldValidator><cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txt_end_date" Format="yyyy-MM-dd" runat="server"></cc1:CalendarExtender></td>
    <td></td>
     <td style="text-align: right"></td>
            <td><asp:CheckBox runat="server" Text="Pension" ID="chkpensionupd" /><asp:CheckBox runat="server" Text="NHF" ID="chknhfupd" /><asp:CheckBox runat="server" Text="NHIS" ID="chknhisupd" /></td>
        </tr>

                <tr>
                    <td colspan="5">
                        <br />
                        <asp:Button ID="btn_update" runat="server" Text="Update" CssClass="btn btn-redtheme" OnClick="btn_update_Click" ValidationGroup="update" />
                    </td>
                </tr>
                <tr><td><br /></td></tr>
            </table>
        </div>
    <br />
    </div>

    <div id="divconfirm" runat="server" style="display:none;">
        <div class="title"><h1>Verify Tax Details </h1><hr /></div>
        <h4>If correct click on <span style="color:green;font-weight:600;">Confirm</span> to complete process. If no click on <span style="color:green;font-weight:600;">Back</span> to return and correct inputed values.</h4><br />
        <div style="width:100%;overflow:scroll;">
        <asp:GridView runat="server" ID="grdEmpConfirm" AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
           Font-Size="Small" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader">
                    
                    <Columns>

                       <asp:TemplateField HeaderText="Tin" Visible="false"> 
                            <ItemTemplate>
                                <asp:Label ID="lbltin" runat="server" Text='<%#Bind("tin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RIN">
                            <ItemTemplate>
                                <asp:Label ID="lbluser_rin" runat="server" Text='<%#Bind("rin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("first_name") +" "+ Eval("last_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country">
                            <ItemTemplate>
                                <asp:Label ID="lblnationality" runat="server" Text='<%#Bind("nationality") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gross">
                            <ItemTemplate>
                                <asp:Label ID="lblgross" runat="server" Text='<%#Bind("sal_gross") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Basic">
                            <ItemTemplate>
                                <asp:Label ID="lblbasic" runat="server" Text='<%#Bind("sal_basic") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rent">
                            <ItemTemplate>
                                <asp:Label ID="lblrent" runat="server" Text='<%#Bind("sal_rent") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Transport">
                            <ItemTemplate>
                                <asp:Label ID="lbltrans" runat="server" Text='<%#Bind("sal_trans") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="CRA">
                            <ItemTemplate>
                                <asp:Label ID="lblcra" runat="server" Text='<%#Bind("sal_cra") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pension">
                            <ItemTemplate>
                                <asp:Label ID="lblpension" runat="server" Text='<%#Bind("sal_pension") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="NHF">
                            <ItemTemplate>
                                <asp:Label ID="lblnhf" runat="server" Text='<%#Bind("sal_nhf") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS">
                            <ItemTemplate>
                                <asp:Label ID="lblnhis" runat="server" Text='<%#Bind("sal_nhis") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Emp Date">
                            <ItemTemplate>
                                <asp:Label ID="lblstart_date" runat="server" Text='<%#Eval("start_date","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Months Taxed">
                            <ItemTemplate>
                                <asp:Label ID="lblmonthstaxed" runat="server" Text='12'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Annual Tax">
                            <ItemTemplate>
                                <asp:Label ID="lblannualtax" runat="server" Text='<%#Bind("sal_calc_tax") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Monthly Tax">
                            <ItemTemplate>
                                <asp:Label ID="lblmonthlytax" runat="server" Text='<%#Bind("sal_calc_tax_monthly") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Chargable Income">
                            <ItemTemplate>
                                <asp:Label ID="lblchargableincome" runat="server" Text='<%#Bind("sal_ch_income") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tax free pay">
                            <ItemTemplate>
                                <asp:Label ID="lbltaxfreepay" runat="server" Text='<%#Bind("sal_tax_free_pay") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblgender"  runat="server" Text='<%#Bind("gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbltitle"  runat="server" Text='<%#Bind("title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblfirst_name"  runat="server" Text='<%#Bind("first_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbllast_name"  runat="server" Text='<%#Bind("last_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblcompany_tin"  runat="server" Text='<%#Bind("company_rin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblmobilenumber"  runat="server" Text='<%#Bind("mobile_number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NHIS" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblemailaddress"  runat="server" Text='<%#Bind("email_address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Emp Date" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbldob" runat="server" Text='<%#Eval("date_of_birth","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    </asp:GridView>
            </div>
        <br />
        Expected Annual Tax : <asp:Label runat="server" ID="lblanntax" CssClass="control-label bold"></asp:Label> <br />
        Expected Monthly Tax : <asp:Label runat="server" ID="lblmonttax" CssClass="control-label bold"></asp:Label > <br />
        <asp:Button Text="Confirm" CssClass="btn btn-redtheme" runat="server" ID="btncnfrmregis" OnClick="btncnfrmregis_Click" />
        <asp:Button Text="Back" CssClass="btn btn-redtheme" runat="server" ID="btnBack" OnClick="btnBack_Click" />
    </div>
    
    <div id="divnotvalidated" runat="server" style="display:none;" align="center">
        <br />
        <h6>There are some employees that are not validated from RDM. Please validate them.</h6><br />
        <asp:GridView runat="server" ID="grdnotvalidated" AutoGenerateColumns="False"
         CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" Width="800px">
           
            <Columns>
                <asp:TemplateField HeaderText="Select" >
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="chkall" onclick="CheckAllEmpNV(this);" /> Select
                    </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkempnv" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>

               <asp:TemplateField HeaderText="Gender" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblgender"  runat="server" Text='<%#Bind("gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Title" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lbltitle"  runat="server" Text='<%#Bind("title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="First Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblfirst_name"  runat="server" Text='<%#Bind("first_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name" >
                            <ItemTemplate>
                                <asp:Label ID="lbllast_name"  runat="server" Text='<%#Bind("last_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee RIN" >
                            <ItemTemplate>
                                <asp:Label ID="lbluser_rin"  runat="server" Text='<%#Bind("user_rin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mobile Number">
                            <ItemTemplate>
                                <asp:Label ID="lblmobilenumber"  runat="server" Text='<%#Bind("mobile_number_1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email Address">
                            <ItemTemplate>
                                <asp:Label ID="lblemailaddress"  runat="server" Text='<%#Bind("email_address_1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date of Birth" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbldob" runat="server" Text='<%#Eval("date_of_birth","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

            </Columns> 
        </asp:GridView><br />
       <span align="center"><asp:Button ID="btnaddemployeeapi" runat="server" Text="Validate" CssClass="btn btn-redtheme" OnClick="btnaddemployeeapi_Click" /></span>
    </div> 

</asp:Content>

