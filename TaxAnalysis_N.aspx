<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TaxAnalysis_N.aspx.cs" EnableEventValidation="false" Inherits="TaxAnalysis_N" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    Tax Analysis
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="portlet-title">
        <div class="caption" align="center" style="width: 100%;">

            <%--EDO STATE INTERNAL REVENUE SERVICE <br />
80, NEW LAGOS ROAD, BENIN CITY--%>

            <table align="center" style="width: 100%">
                <tr>
                    <td>
                        <img alt="" src="https://pinscher.eirs.gov.ng/spike/logo/coat_of_arm.png" height="70" width="70" /></td>
                    <td align="center"><b>EDO STATE INTERNAL REVENUE SERVICE
                        <br />
                        80, NEW LAGOS ROAD, BENIN CITY</b></td>

                    <td>
                        <img alt="" src="https://pinscher.eirs.gov.ng/spike/logo/eirs_logo.png" height="70" width="70" /></td>
                </tr>
            </table>
        </div>
    </div>

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>

    <div id="main" runat="server">

        <div class="caption" style="width: 100%; display: none;">
            <table style="width: 100%">
                <tr>
                    <td>
                        <img alt="" src="https://pinscher.eirs.gov.ng/spike/logo/coat_of_arm.png" height="70" width="70" /></td>
                    <td></td>
                    <td></td>
                    <td id="HeadingDiv" runat="server" colspan="3" align="center"><b>EDO STATE INTERNAL REVENUE SERVICE
                        <br />
                        80, NEW LAGOS ROAD, BENIN CITY</b></td>
                    <td></td>
                    <td></td>

                    <td align="right" style="width: 100px;">
                        <img alt="" src="https://pinscher.eirs.gov.ng/spike/logo/eirs_logo.png" height="70" width="70" /></td>
                </tr>
            </table>


            <br />

            <br />

        </div>

        <div style="display: none;">

            <table id="Table1" runat="server" border="1" class="table" style="width: 95% !important; border: solid; border-width: 2px; border-color: lightsteelblue;">
                <tr style="border: solid; border-width: 2px; border-color: lightsteelblue;">
                    <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue; width: 30%;"></td>

                </tr>

            </table>


        </div>


        <br />

        <div class="portlet light" align="center">
            <table>
                <tr>
                    <td valign="top">
                        <table id="t1" runat="server" border="1" class="table" style="width: 95% !important; border: solid; border-width: 2px; border-color: lightsteelblue;">
                            <tr style="border: solid; border-width: 2px; border-color: lightsteelblue;">
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue; width: 40%;"><b>TAXPAYER NAME:</b></td>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;">
                                    <asp:Label ID="lbl_tax_payer_name" runat="server"></asp:Label></td>
                            </tr>

                            <tr>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;"><b>BUSINESS NAME:</b></td>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;">
                                    <asp:Label ID="lbl_business_name" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;"><b>ADDRESS:</b></td>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;">
                                    <asp:Label ID="lbl_address" runat="server"></asp:Label></td>
                            </tr>

                        </table>
                    </td>

                    <td style="width: 1%;"></td>

                    <td valign="top">
                        <table class="table" border="1" style="width: 100% !important; border: solid; border-width: 2px; border-color: lightsteelblue;">
                            <tr>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;"><b>TAX PAYER RIN:</b></td>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;">
                                    <asp:Label ID="lbl_tax_payer_RIN" runat="server"></asp:Label></td>
                            </tr>

                            <tr>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;"><b>BUSINESS RIN:</b></td>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;">
                                    <asp:Label ID="lbl_business_RIN" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;"><b>PHONE:</b></td>
                                <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue;">
                                    <asp:Label ID="lbl_phone" runat="server"></asp:Label></td>
                            </tr>

                        </table>
                    </td>
                </tr>
            </table>
        </div>


        <div style="display: none;">

            <table id="Table2" runat="server" border="1" class="table" style="width: 95% !important; border: solid; border-width: 2px; border-color: lightsteelblue;">
                <tr style="border: solid; border-width: 2px; border-color: lightsteelblue;">
                    <td style="text-align: left; border: solid; border-width: 2px; border-color: lightsteelblue; width: 30%;"></td>

                </tr>

            </table>


        </div>



        <div class="portlet light">
            <div class="portlet-title">

                <div class="caption" style="width: 100%; text-align: center;">
                    <b>
                        <asp:Label ID="lbl_year" runat="server"></asp:Label>
                        &nbsp;&nbsp;  PAYE TAX ANALYSIS
                        <br />
                        <br />
                    </b>
                </div>
            </div>

            <div style="overflow-x: scroll;">
                <asp:GridView allowresize="" AllowPaging="true" ID="grd_tax_analysis" OnPageIndexChanging="GridView1_PageIndexChanging" runat="server" AllowSorting="True" PagerSettings-PageButtonCount="5"
                    AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="true">


                    <Columns>

                        <asp:BoundField ItemStyle-Width="4" DataField="serial" HeaderText="S/NO." />
                        <asp:BoundField ItemStyle-Width="9" DataField="taxpayerRIN" HeaderText="RIN" />
                        <asp:BoundField ItemStyle-Width="15" DataField="Name" HeaderText="Name" />
                        <asp:BoundField ItemStyle-Width="7" DataField="StartMonth" HeaderText="Start Month" />
                        <asp:BoundField ItemStyle-Width="7" DataField="EndMonth" HeaderText="End Month" />
                        <asp:BoundField ItemStyle-Width="7" DataField="AnnualGross" HeaderText="Gross" />
                        <asp:BoundField ItemStyle-Width="7" DataField="CRA" HeaderText="CRA" />
                        <asp:BoundField ItemStyle-Width="7" DataField="ValidatedPension" HeaderText="Pension" />
                        <asp:BoundField ItemStyle-Width="7" DataField="ValidatedNHF" HeaderText="NHF" />
                        <asp:BoundField ItemStyle-Width="7" DataField="ValidatedNHIS" HeaderText="NHIS" />
                        <asp:BoundField ItemStyle-Width="7" DataField="TaxFreePay" HeaderText="Tax Free Pay" />
                        <asp:BoundField ItemStyle-Width="7" DataField="ChargeableIncome" HeaderText="Ch. Income" />
                        <asp:BoundField ItemStyle-Width="7" DataField="MonthlyTax" HeaderText="M. Tax" />
                        <asp:BoundField ItemStyle-Width="7" DataField="AnnualTax" HeaderText="Exp.A. Tax" />

                    </Columns>



                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />

                </asp:GridView>

                <input type="hidden" runat="server" value="" id="hidden1" />
                <div style="margin-top: -60px; margin-left: 10px; display: none;" visible="false" id="div_paging" runat="server">Showing
                    <asp:Label runat="server" ID="lblpagefrom"></asp:Label>
                    -
                    <asp:Label runat="server" ID="lblpageto"></asp:Label>
                    entries of
                    <asp:Label runat="server" ID="lbltoal"></asp:Label>
                    entries</div>
            </div>



        </div>
    </div>

    <div align="Center">
        <asp:Button ID="btnPDF" Text="Save AS PDF" CssClass="btn btn-theme" runat="server" OnClick="btnPDF_Click" />
    </div>
    <%--</ContentTemplate></asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" runat="Server">
</asp:Content>

