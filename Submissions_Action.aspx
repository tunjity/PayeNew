<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Submissions_Action.aspx.cs" Inherits="Submissions_Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
   <%--<script src="js/jquery/1.8/jquery-1.8.0.js"></script>  
   --%>
    <link href="js/jquery/jquery-ui.css" rel="stylesheet" type="text/css" />  
    <script src="js/jquery/jquery-ui.min.js" type="text/javascript"></script>  
    <script src="js/jquery/jquery.min.js" type="text/javascript"></script>  

    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
           
        });
        function SearchText() {

            
            $('#<%= txtEmpName.ClientID %>').autocomplete(


                {

                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Submissions_Action.aspx/GetEmployeeName",
                        data: "{'empName':'" + document.getElementById('<%= txtEmpName.ClientID %>').value + "'}",
                        dataType: "json",                       
                        success: function (data) {
                           
                            response(data.d);

                        },
                        error: function (result) {
                            alert("No Match");
                        }
                    });

                    
                },
                select: function (event, ui) {
                   
                    $.ajax({
                        type: "POST",
                        url: "Submissions_Action.aspx/GetBusinesses",
                        data: "{'empName':'" + ui.item.value + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            var ddlCustomers = $("[id*=ContentPlaceHolder1_drpempbusiness]");
                            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
                            $.each(r.d, function () {
                                ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                            });
                        }
                    });
                }

            });
        }

      

        function SearchText1() {
            $('<%= txtEmpName.ClientID %>').change({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Submissions_Action.aspx/GetEmployeeName1",
                        data: "{'empName':'" + document.getElementById('<%= txtEmpName.ClientID %>').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);

                        },
                        error: function (result) {
                            alert("No Match");
                        }
                    });
                }
            });
        }

    </script>  


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" Runat="Server">
    Submissions
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
  
          <div align="center" style="padding:5px;"><asp:Label runat="server" ID="lblmsg" CssClass="alert alert-success"  Visible="false" Text="Submission Added Successfully" style="padding:10px;"></asp:Label></div>
            <table class="table borderless" border="0">
                   
          <tr class="tblrw">
            <td align="right">Employer</td><td>:</td><td align="left">

 <asp:TextBox ID="txtEmpName" CssClass="form-control" runat="server" AutoPostBack="false" OnTextChanged="txtEmpName_TextChanged" ></asp:TextBox>


                                                     </td><td width="30"></td>
          </tr>
        <tr class="tblrw">
            <td align="right">Employer Business</td><td>:</td><td><asp:DropDownList ID="drpempbusiness" CssClass="form-control" runat="server" AutoPostBack="false"></asp:DropDownList>

                                                              </td>
        </tr>
        <tr class="tblrw">
            <td align="right">Tax Year</td><td>:</td><td><asp:DropDownList ID="drpTaxyear" CssClass="form-control" runat="server" ></asp:DropDownList></td>    
        </tr>
        <tr class="tblrw">
            <td align="right">Assessment Rule</td><td>:</td><td><asp:DropDownList ID="drpassessmentrule" CssClass="form-control" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr class="tblrw">
            <td align="right">Assessment Items</td><td>:</td><td><asp:DropDownList ID="drpassessmentitems" CssClass="form-control" runat="server" ></asp:DropDownList></td><td width="30"></td> 
        </tr>
        <tr class="tblrw">
            <td align="right">Submission Amount</td><td>:</td><td><asp:TextBox ID="txtsubmissionamt" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox></td> 
                
        </tr>
        <tr class="tblrw">
            <td align="right">Upload File </td><td>:</td><td><asp:TextBox ID="txtupliadfile" runat="server" CssClass="form-control"></asp:TextBox></td> 
        </tr>
            
        <tr class="tblrw">
            <td align="right">Submission Notes </td><td>:</td><td><asp:TextBox ID="txtsubmissionnotes" runat="server" CssClass="form-control"></asp:TextBox></td><td width="30"></td> 
        </tr>
         <tr class="tblrw"><td colspan="8" align="center">
             <asp:Button Text="Save" ID="btnsave" CssClass="btn btn-redtheme" runat="server" OnClick="btnsave_Click"/>
             <asp:Button Text="Back To List" ID="btnback" CssClass="btn btn-redtheme" runat="server" OnClick="btnback_Click" />
                           </td></tr>
                </table>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" Runat="Server">
</asp:Content>

