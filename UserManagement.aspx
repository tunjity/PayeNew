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
   <%-- <script type="text/javascript">
        function gf() {
            $(function () {
                var gridId = "<%= grd_user_management_check.ClientID %>";
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
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    Assessment - Input File
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">Input File</div>

        </div>
        <div style="overflow: scroll;">
            <asp:GridView ID="grd_user_management_check" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" PagerSettings-PageButtonCount="5"
                AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="GridHeader" ShowFooter="false">


                <Columns>

                    <asp:BoundField DataField="BusinessName" HeaderText="Full Name" />
                    <asp:BoundField DataField="ContactAddress" HeaderText="Email Address" />
                    <asp:BoundField DataField="BusinessRIN" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TaxMonth" HeaderText="Role" />
                </Columns>



                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />

            </asp:GridView>

            <div style="margin-top: -60px; margin-left: 10px;" id="div_paging" runat="server">
                Showing
                        <asp:Label runat="server" ID="lblpagefrom"></asp:Label>
                -
                        <asp:Label runat="server" ID="lblpageto"></asp:Label>
                entries of
                        <asp:Label runat="server" ID="lbltoal"></asp:Label>
                entries
            </div>
        </div>

    </div>
</asp:Content>
