<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mobiletaxpayeasset.aspx.cs" Inherits="mobiletaxpayeasset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-9">
                    <div class="title">
                        <h1>
                            Tax Payer Details View
                        </h1>
                        <hr>
                    </div>

                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                Tax Payer Information
                            </div>
                            <div class="actions">
                                <a data-toggle="modal" data-target="#divTaxPayerModal" class="btn btn-redtheme"> Full Details </a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row view-form">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label bold">Tax Payer Type: </label>
                                        <div class="form-control-static">
                                            Tax Payer Type
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label bold">Tax Payer TIN: </label>
                                        <div class="form-control-static">
                                            Tax Payer TIN
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label bold">Mobile Number: </label>
                                        <div class="form-control-static">
                                            Mobile Number
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <div class="form-group">
                                        <label class="control-label bold">Tax Payer Name: </label>
                                        <div class="form-control-static">
                                            Tax Payer Name
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label bold">Tax Payer RIN: </label>
                                        <div class="form-control-static">
                                            Tax Payer RIN
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label bold">Contact  Address: </label>
                                        <div class="form-control-static">
                                            Contact  Address
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">Associated Assets</div>
                            <div class="actions">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-redtheme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Add New <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <a href="">Business</a>
                                        </li>
                                        <li>
                                            <a href="">Building</a>
                                        </li>
                                        <li>
                                            <a href="">Land</a>
                                        </li>
                                        <li>
                                            <a href="">Vehicles</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class="table table-bordered v-middle">
                                <thead class="red-th">
                                    <tr>
                                        <th>Asset Type</th>
                                        <th>Asset Name</th>
                                        <th>Tax Payer Role</th>
                                        <th class="action-th">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Type</td>
                                        <td>Name</td>
                                        <td>Role</td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssetModal">Quick View</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Type</td>
                                        <td>Name</td>
                                        <td>Role</td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssetModal">Quick View</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody style="display: none;">
                                    <tr>
                                        <td colspan="5">
                                            No Record Found
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div class="">
                                Showing 2 of 2 Records
                            </div>

                        </div>
                    </div>

                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">Associated Rules</div>
                            <div class="actions">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-redtheme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Tax Year <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <a href="">2017</a>
                                        </li>
                                        <li>
                                            <a href="">2018</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class="table table-bordered v-middle">
                                <thead class="red-th">
                                    <tr>
                                        <th>Rule ID</th>
                                        <th>Rule Year</th>
                                        <th>Rule Name</th>
                                        <th>Amount</th>
                                        <th class="action-th">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>ID</td>
                                        <td>2017</td>
                                        <td>Name</td>
                                        <td>Amount</td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssessmentRulesModal">Quick View</a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssessmentItemsModal">View Items </a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divProfileListingModal">View Profiles </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>ID</td>
                                        <td>2017</td>
                                        <td>Name</td>
                                        <td>Amount</td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssessmentRulesModal">Quick View</a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssessmentItemsModal">View Items </a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divProfileListingModal">View Profiles </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td colspan="5">
                                            No Record Found
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div class="">
                                Showing 2 of 2 Records
                            </div>

                        </div>
                    </div>

                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">Associated Bills</div>
                            <div class="actions">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-redtheme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Add New <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <a href="">Assessment Bill</a>
                                        </li>
                                        <li>
                                            <a href="">MDA Service Bill</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class="table table-bordered v-middle">
                                <thead class="red-th">
                                    <tr>
                                        <th>Date</th>
                                        <th>Bill Type</th>
                                        <th>Bill ID</th>
                                        <th>Bill Amount</th>
                                        <th>Bill Status</th>
                                        <th class="action-th">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Date</td>
                                        <td>Type</td>
                                        <td>ID</td>
                                        <td>Amount</td>
                                        <td>Status</td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssessmentViewModal">Quick View</a>
                                                    </li>
                                                    <li>
                                                        <a href="CBS-Inner-Bill.html">Make Payment</a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divPaymentHistoryModal">View Payments </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Date</td>
                                        <td>Type</td>
                                        <td>ID</td>
                                        <td>Amount</td>
                                        <td>Status</td>
                                        <td>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-theme dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Action <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divAssessmentViewModal">Quick View</a>
                                                    </li>
                                                    <li>
                                                        <a href="CBS-Inner-Bill.html">Make Payment</a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="modal" data-target="#divPaymentHistoryModal">View Payments </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td colspan="6">
                                            No Record Found
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div class="">
                                Showing 2 of 2 Records
                            </div>

                        </div>
                    </div>

                </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="modelpops">
    <div class="modal fade" id="divTaxPayerModal" tabindex="-1" role="dialog" aria-labelledby="divTaxPayerModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divTaxPayerModalLabel">Tax Payer Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Name</label>
                                <div>2 DEGREE EDUCATION CENTRE</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Address</label>
                                <div>90, BENIN TECHNICAL COLLEGE ROAD, BENIN CITY, EGOR, EDO, NIGERIA.</div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Type</label>
                                <div>Informal Business</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Category</label>
                                <div>Fixed Location</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer TIN</label>
                                <div>8888</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer RIN</label>
                                <div>8888</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divAssetModal" tabindex="-1" role="dialog" aria-labelledby="divAssetModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divAssetModalLabel">Asset Details</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Asset Type</label>
                                <div>Building</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Asset Name</label>
                                <div>Name</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Tax Payer Role</label>
                                <div>Role</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divAssessmentRulesModal" tabindex="-1" role="dialog" aria-labelledby="divAssessmentRulesModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divAssessmentRulesModalLabel">Assessment Rules</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Rule Name</label>
                                <div>Name</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="control-label control-label-static bold">Year</label>
                                <div>2017</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divAssessmentItemsModal" tabindex="-1" role="dialog" aria-labelledby="divAssessmentItemsModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divAssessmentItemsModalLabel">Assessment Items</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered">
                        <tr>
                            <th>Name</th>
                            <th></th>
                        </tr>
                        <tr>
                            <td>Item Name</td>
                            <td>Other details</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divProfileListingModal" tabindex="-1" role="dialog" aria-labelledby="divProfileListingModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divProfileListingModalLabel">Profile Listing</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered">
                        <tr>
                            <th>Name</th>
                            <th></th>
                        </tr>
                        <tr>
                            <td>Profile Name</td>
                            <td>Other details</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divAssessmentViewModal" tabindex="-1" role="dialog" aria-labelledby="divAssessmentViewModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="divAssessmentViewModalLabel">Assessment View</h4>
                </div>
                <div class="modal-body">
                    <p>Assessment Details goes here</p>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divPaymentHistoryModal" tabindex="-1" role="dialog" aria-labelledby="divPaymentHistoryModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="divPaymentHistoryModalLabel">Payment History</h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered">
                        <tr>
                            <th>Date</th>
                            <th>Amount</th>
                        </tr>
                        <tr>
                            <td>Date</td>
                            <td>1000</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


