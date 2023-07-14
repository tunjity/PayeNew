<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CalculateTax.aspx.cs" Inherits="CalculateTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="contentheading" runat="server">
   Monthly Calculated Tax
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="text-align:center;vertical-align:middle; width: 75%;" cellpadding="2" cellspacing="5" id="box" class="table borderless" align="center" >
          
         <tr class="tblrw"><td align="right"><span class="control-label ">Employer Name</span> </td><td>:</td><td align="left"><asp:DropDownList ID="drpcomp" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpcomp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td></tr>
         <tr class="tblrw"><td align="right"><span class="control-label ">Employer RIN</span></td><td>:</td><td align="left"><asp:Label ID="lblRin" runat="server" CssClass="form-control"  ></asp:Label></td></tr>
         <tr class="tblrw"><td align="right"><span class="control-label ">Employer Address</span></td><td>:</td><td align="left"><asp:Label ID="lblAddress" CssClass="form-control"  runat="server" ></asp:Label></td></tr>
         <tr class="tblrw" id="tr_dpd_business" runat="server" style="display:none"><td align="right"><span class="control-label ">Select Business</span></td><td>:</td><td align="left"><asp:DropDownList ID="dpd_business" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dpd_business_SelectedIndexChanged"></asp:DropDownList></td></tr>
         <tr><td><br /></td></tr>
</table>
    <div style="width:100%;overflow:auto;">
        <asp:GridView runat="server" Visible="false" ID="grdEmpConfirm" AutoGenerateColumns="False" EnableModelValidation="True" 
                  CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader"  
                  EmptyDataText="No PAYE Assessment done for the Selected Company" EmptyDataRowStyle-CssClass="alert alert-danger"  OnRowDataBound="grdEmpConfirm_RowDataBound">
                   <Columns>
                      <asp:TemplateField HeaderText="RIN"> 
                            <ItemTemplate>
                                <asp:Label ID="lblrin" runat="server" Text='<%#Bind("user_rin") %>' CssClass="control-label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Bind("first_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nationality">
                            <ItemTemplate>
                                <asp:Label ID="lblnationality" runat="server" Text='<%#Bind("nationality")%>'></asp:Label>
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

                        <asp:TemplateField HeaderText="Start Month">
                            <ItemTemplate>
                                <asp:Label ID="lblstart_date" runat="server" Text='<%#Eval("start_date","{0:dd-MM-yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Annual Tax" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblannualtax" runat="server" Text='<%#Bind("sal_calc_tax") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Monthly Contribution" HeaderStyle-Width="150px" Visible="true">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkmonthly" runat="server" Text="View"></asp:LinkButton>
                                <!--<asp:Label ID="lblmonthlytax" runat="server" Text='<%#Bind("sal_calc_tax_monthly") %>'></asp:Label> -->
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Individual id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblindid" runat="server" Text='<%#Bind("ind_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                     </Columns>
                   </asp:GridView>
    </div>
    <br />
   <center > 
       
       <div id="divasses"  runat="server" style="width:550px;border:2px solid darkseagreen; display:none; box-shadow: 0px 2px 2px #a09c9c;"> 
       <br />
        
        <strong><center><h4 class="msgheader"style="margin-top: -13px;">PAYE Assessment</h4></center></strong>
     <strong class="tblrw" style="font-size:12px;color: #2b2f2d;">  The Employer Assessment has been done based on the Data uploaded for PAYE tax.</strong>
        <br />
       <strong style="font-size: 12px;color: #2b2f2d;"> PAYE Tax Calculated:</strong> <span id="currency" runat="server"></span><asp:Label  runat="server" CssClass="control-label bold" Text="0" Width="150px" Height="18px"  ForeColor="#666666"  BackColor="#aaff99" ID="lbltaxcalc"></asp:Label>(Annually) <br /><br />
      <strong style="font-size: 12px;color: #2b2f2d;"> EMPLOYER MONTHLY CONTRIBUTION:</strong> <span id="currencymonth" runat="server"></span><asp:Label  runat="server" CssClass="control-label bold" Text="0" Width="150px" Height="18px"  ForeColor="#666666"  BackColor="#aaff99" ID="lblmonthlytax"></asp:Label>(Monthly) <br /><br />
      <strong style="font-size: 12px;color: #2b2f2d;">  Assessment Id : </strong> <asp:Label runat="server" CssClass="control-label bold" Text="0" ID="lblassesno"  Width="150px" Height="18px" ForeColor="#666666" BackColor="#aaff99"></asp:Label><br />
        <br />
           <asp:Button runat="server" ID="btnsubmit" CssClass="btn btn-redtheme" Text="Submit" OnClick="btnsubmit_Click" />
        <br />
    </div> 

   </center>
     <br />
    <center> 
        <div id="divmsg" class="alert alert-success" runat="server" style="display:none;">
        Assessment Submitted to RDM and this Assessment is Scheduled for the Assessment Approval Process
        Assessment Id ( <span id="lblassessref" runat="server"></span> ) and Monthly Tax is <span id="lblmonthtax" runat="server"></span>
    </div> 
        <div id="divassessmentdone" runat="server" style="display:none;" class="msg-error">
        </div>
    </center>
</asp:Content>

