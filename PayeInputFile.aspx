<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayeInputFile.aspx.cs" Inherits="PayeInputFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script type="text/javascript">
        function gf() {
            $(function () {
                var gridId = "<%= grd_rules_check.ClientID %>";
                var rowClickEvent = "#" + gridId + " tr"
                var current = "";

                $("#" + gridId).on("click", "span.close", function () {
                    //Remove the row when user click on X
                    $(this).parent().parent().empty();
                });

                $(rowClickEvent).click(function () {
                    //Add row containing aditional info when user click on a row inside the grid view
                    var row = this;

                    $("#tax_payer_rin").text(row.children[0].innerText);
                    $("#tax_payer_name").text(row.children[1].innerText);
                    $("#tax_rule").text(row.children[3].innerText);

                    var assessed = "";
                    if (row.children[6].innerText == "No")
                        assessed = "Assessment Not Generated Yet";
                    else
                        assessed = "Assessment has been generated";
                    $("#tax_assessed").text(assessed);


                });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    Assessment - Input File
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-title">
        <div class="caption">
            Search Assessment Rules
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table class="table borderless" style="width: 45% !important; border: none !important;">
                    <tr>
                        <td>Tax Payer RIN:</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txt_tax_payer_RIN" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td>Tax Payer Name:</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txt_tax_payer_name" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr style="display: none;">
                        <td>Rule Code:</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txt_rule_code" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Rule Name:</td>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txt_rule_name" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <asp:Button ID="btn_search" Text="Search" runat="server" CssClass="btn btn-theme" OnClick="btn_search_Click" /></td>
                    </tr>

                </table>
            </div>


            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">Input File</div>

                </div>
                <div style="overflow: scroll;">
                    <asp:GridView ID="grd_rules_check" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" PagerSettings-PageButtonCount="5"
                        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false">


                        <Columns>

                            <asp:BoundField DataField="BusinessName" HeaderText="Employer Name" />
                            <asp:BoundField DataField="ContactAddress" HeaderText="Employer Address" />
                            <asp:BoundField DataField="BusinessRIN" HeaderText="Employer RIN" />
                            <%--<asp:BoundField DataField="BusinessName" HeaderText="Asset" />--%>
                            <asp:BoundField DataField="TaxMonth" HeaderText="Start Month" />
                            <asp:BoundField DataField="AssessmentRuleName" HeaderText="Assessment Rule" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />

                            <asp:BoundField DataField="title" HeaderText="Title" />
                            <asp:BoundField DataField="firstname" HeaderText="First Name" />
                            <asp:BoundField DataField="middlename" HeaderText="Middle Name" />
                            <asp:BoundField DataField="lastname" HeaderText="SurName" />
                            <asp:BoundField DataField="nationality" HeaderText="Nationality" />

                            <asp:BoundField DataField="taxpayerRIN" HeaderText="Employee RIN" />
                            <asp:BoundField DataField="tp_tin" HeaderText="Employee TIN" />

                            <asp:BoundField DataField="Basic" HeaderText="Annual Basic" />
                            <asp:BoundField DataField="Rent" HeaderText="Annual Rent" />
                            <asp:BoundField DataField="trans" HeaderText="Annual Transport" />
                            <asp:BoundField DataField="AnnualUtility" HeaderText="Annual Utility" />
                            <asp:BoundField DataField="AnnualMeal" HeaderText="Annual Meal" />
                            <asp:BoundField DataField="Others" HeaderText="Other Allounces-Annual" />

                            <asp:BoundField DataField="LTG" HeaderText="Leave Transport-Annual" />


                            <asp:BoundField DataField="AnnualGross" HeaderText="Annual Gross" />
                            <asp:BoundField DataField="Pension" HeaderText="Pension" />
                            <asp:BoundField DataField="NHF" HeaderText="NHF" />
                            <asp:BoundField DataField="NHIS" HeaderText="NHIS" />


                            <asp:BoundField DataField="AssessmentAmount" HeaderText="Assessment Amount" />
                            <asp:BoundField DataField="Status" HeaderText="Assessed" />

                            <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                <ItemTemplate>

                                    <div class="btn-group">
                                        <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            Action <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu">
                                            <li>
                                                <a id="A1" data-toggle="modal" data-target="#divTaxPayerModal" onclick="gf();" runat="server">Quick View</a>

                                                <%-- <asp:LinkButton runat="server" ID="lnkCustDetails" Text="Quick View" OnClick="lnkCustDetails_Click" />--%>
                                            </li>

                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>



                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />

                    </asp:GridView>

                    <div style="margin-top: -60px; margin-left: 10px;" id="div_paging" runat="server">Showing
                        <asp:Label runat="server" ID="lblpagefrom"></asp:Label>
                        -
                        <asp:Label runat="server" ID="lblpageto"></asp:Label>
                        entries of
                        <asp:Label runat="server" ID="lbltoal"></asp:Label>
                        entries</div>
                </div>

            </div>

            <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel" style="display: none;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                            <h4 class="modal-title" id="divTaxPayerModalLabel">Assessment - Rules Check Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label control-label-static bold">Tax Payer RIN </label>
                                        <div id="tax_payer_rin"></div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label control-label-static bold">Tax Payer Name</label>
                                        <div id="tax_payer_name"></div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label control-label-static bold">Assessment Rule</label>
                                        <div id="tax_rule"></div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label class="control-label control-label-static bold">Assessed</label>
                                        <div id="tax_assessed"></div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" runat="Server">
</asp:Content>

