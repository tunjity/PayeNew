<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PullData_N.aspx.cs" Inherits="PullData_N" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .progress {
            background-color: #EEEEEE;
            height: 6px;
            border-radius: 6px;
            margin: 10px 0;
            position: relative;
            z-index: 1;
            overflow: hidden;
            transition: width 25s;
        }

        .progress-meter, .preload {
            background-color: #0096DC;
            border-radius: 3px;
            height: 6px;
            width: 0;
            /*transition: width 300ms;*/
        }

        .preload {
            background-color: #c0ccd9;
            box-shadow: -8px 0px 10px 2px rgba(192,204,217,1);
            width: 80;
            position: relative;
            animation: preloader 1.8s linear both infinite;
        }
    </style>
    <script type="text/javascript">
        function showImage() {
            document.getElementById('<%=div_loading.ClientID%>').style.display = "block";

        }

    </script>
    <script
        src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script type="text/javascript">

        //start items sync data
        function startItemsSync() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateData_start_syncing();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }

        function startItemsSyncB() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateData_start_syncingB();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }

        function startItemsSyncC() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateData_start_syncingC();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }

        function startCorporateSyncing() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateCorporateData_start_syncing();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }
        function startCorporateSyncingC() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateCorporateData_start_syncingC();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }
        function startCorporateSyncingB() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateCorporateData_start_syncingB();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }



        function startAssetSyncing() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateAssetsData_start_syncing();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }
        function startAssetSyncingB() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateAssetsData_start_syncingB();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }
        function startAssetSyncingC() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateAssetsData_start_syncingC();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }


        function startIndividualsSync() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateIndividualsData_start_syncing();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }



        function startProfileSync() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateProfileData_start_syncing();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }

        function startProfileSyncB() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateProfileData_start_syncingB();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }

        function startProfileSyncC() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateProfileData_start_syncingC();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })
        }


        //start reules syncing data
        function startRuleSync() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateRulesData_start_syncing();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }

        //start reules syncing data
        function startRuleSyncB() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateRulesData_start_syncingB();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }

        function startRuleSyncC() {
            Swal.fire({
                title: '<strong>Do not Close this window</strong>',
                type: 'info',
                html:
                    'Closing this window may cause loss in the data',
                showCloseButton: true,
                showCancelButton: true,
                focusConfirm: false,
                confirmButtonText:
                    'Start',
                confirmButtonAriaLabel: 'Start!',
                cancelButtonText:
                    'Cancel',
                cancelButtonAriaLabel: 'Thumbs down',
            }).then((result) => {
                if (result.value) {
                    //truncateData_start_syncing();
                    truncateRulesData_start_syncingC();
                    Swal.fire({

                        showCancelButton: false,
                        showConfirmButton: false,
                        title: 'Syncing',
                        html: '<img width=40 src="https://gifimage.net/wp-content/uploads/2018/04/loader-gif-transparent-background-11.gif"/><div class="progress">' +

                            '<div class="progress-meter" style="width:0%"></div>' +
                            '</div >' +
                            '<span class="progress-val">0%</span> complete ',
                        allowOutsideClick: false


                    });
                }
            })

        }

        function truncateIndividualsData_start_syncing() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_Individual_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Individual_recursive_hits(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }


            });

        }


        function truncateProfileData_start_syncing() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_profile_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_profile_recursive_hits(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }


            });
        }

        function truncateProfileData_start_syncingB() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_profile_dataB",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_profile_recursive_hitsB(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }


            });
        }    
    function truncateProfileData_start_syncingC() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_profile_dataC",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_profile_recursive_hitsC(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }


            });
        }

        function truncateCorporateData_start_syncing() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_corporate_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Corporate_recursive_hits(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
        }
        function truncateCorporateData_start_syncingC() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_corporate_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Corporate_recursive_hitsC(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
        }
        function truncateCorporateData_start_syncingB() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_corporate_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Corporate_recursive_hitsB(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
        }


        function truncateAssetsData_start_syncing() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_assets_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Assets_recursive_hits(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
        }
        function truncateAssetsData_start_syncingB() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_assets_dataB",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Assets_recursive_hitsB(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
        }
        function truncateAssetsData_start_syncingC() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_assets_dataC",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Assets_recursive_hitsC(1, 1000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
        }

        //truncate rules data
        //truncate items data
        function truncateRulesData_start_syncing() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_Rules_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Rules_recursive_hits(1, 12);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }


        function truncateRulesData_start_syncingB() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_Rules_dataB",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Rules_recursive_hitsB(1, 12);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

        function truncateRulesData_start_syncingC() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_Rules_dataC",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_Rules_recursive_hitsC(1, 12);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }


        //truncate items data
        function truncateData_start_syncing() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_data",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_recursive_hits(1, 10000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

        //truncate items data B
        function truncateData_start_syncingB() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_dataB",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_recursive_hitsB(1, 10000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

        //truncate items data C
        function truncateData_start_syncingC() {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/truncate_dataC",
                contentType: "application/json; charset=utf-8",
                data: '{ }',
                success: function (msg) {

                    start_recursive_hitsC(1, 10000);

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

        function start_Individual_recursive_hits(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/IndividualcheckProgress",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Individual_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }

        function start_profile_recursive_hits(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/ProfilecheckProgress",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_profile_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }

        function start_profile_recursive_hitsB(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/ProfilecheckProgressB",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_profile_recursive_hitsB(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }  
    function start_profile_recursive_hitsC(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/ProfilecheckProgressC",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_profile_recursive_hitsC(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }


        function start_Corporate_recursive_hits(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/CorporatecheckProgress",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Corporate_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }


        function start_Corporate_recursive_hitsB(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/CorporatecheckProgressB",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Corporate_recursive_hitsB(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }
        function start_Corporate_recursive_hitsC(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/CorporatecheckProgressC",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Corporate_recursive_hitsC(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });
        }




        function start_Assets_recursive_hits(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/AssetcheckProgress",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Assets_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });

        }
         function start_Assets_recursive_hitsB(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/AssetcheckProgressB",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Assets_recursive_hitsB(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });

        }
         function start_Assets_recursive_hitsC(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/AssetcheckProgressC",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);





                    if (nextPage == "Yes") {
                        start_Assets_recursive_hitsC(pageNumber + 1, pageSize);
                    } else {
                        var percentage = 100;
                        $('.progress-meter').stop();
                        var $el = $('.progress-val');
                        $('.progress-meter').animate({

                            width: percentage + '%'
                        }, {
                            duration: 5000,
                            step: function (now, fx) {
                                if (fx.prop == 'width') { //If you animate more than 1 property
                                    var data = Math.round(now);
                                    $el.text(data + ' % ');
                                }

                            },
                            done: function () {
                                Swal.fire(
                                    'Syncing Successful',
                                    'Data Successfully Synced Count :' + totRecord,
                                    'success'
                                )
                            }
                        });
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val')
            $('.progress-meter').stop(true).animate({

                width: percentage + '%'
            }, {
                duration: 15000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });

        }


        //hitting syncing API recursivly for rules
        function start_Rules_recursive_hits(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/rulesCheckProgress",
                timeout: 1800000,
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {
                    console.log("completed syncing")
                    var percentage = 100;
                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    $('.progress-meter').stop();
                    var $el = $('.progress-val');
                    $('.progress-meter').animate({

                        width: percentage + '%'
                    }, {
                        duration: 5000,
                        step: function (now, fx) {
                            if (fx.prop == 'width') { //If you animate more than 1 property
                                var data = Math.round(now);
                                $el.text(data + ' % ');
                            }

                        },
                        done: function () {
                            Swal.fire(
                                'Syncing Successful',
                                'Data Successfully Synced Count :' + totRecord,
                                'success'
                            )
                        }
                    });
                    // if (nextPage == "Yes") {
                    //    start_Rules_recursive_hits(pageNumber + 1, pageSize);
                    // } else {

                    //}



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val');
            $('.progress-meter').animate({

                width: percentage + '%'
            }, {
                duration: 250000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });

            /*$({ percentage: parseInt($('.progress-val').text(), 10) }).stop(true).animate({ percentage: value }, {
                duration: 150000,
                easing: "easeOutExpo",
                step: function () {
                    // percentage with 1 decimal;
                    var percentageVal = Math.round(this.percentage * 10) / 10;

                    $el.text(percentageVal + '%');

                }
            }).promise().done(function () {
                // hard set the value after animation is done to be

                // $el.text(value + "%");


            });*/

        }

        function start_Rules_recursive_hitsB(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/rulesCheckProgressB",
                timeout: 1800000,
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {
                    console.log("completed syncing")
                    var percentage = 100;
                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    $('.progress-meter').stop();
                    var $el = $('.progress-val');
                    $('.progress-meter').animate({

                        width: percentage + '%'
                    }, {
                        duration: 5000,
                        step: function (now, fx) {
                            if (fx.prop == 'width') { //If you animate more than 1 property
                                var data = Math.round(now);
                                $el.text(data + ' % ');
                            }

                        },
                        done: function () {
                            Swal.fire(
                                'Syncing Successful',
                                'Data Successfully Synced Count :' + totRecord,
                                'success'
                            )
                        }
                    });
                    // if (nextPage == "Yes") {
                    //    start_Rules_recursive_hits(pageNumber + 1, pageSize);
                    // } else {

                    //}



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val');
            $('.progress-meter').animate({

                width: percentage + '%'
            }, {
                duration: 250000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });

            /*$({ percentage: parseInt($('.progress-val').text(), 10) }).stop(true).animate({ percentage: value }, {
                duration: 150000,
                easing: "easeOutExpo",
                step: function () {
                    // percentage with 1 decimal;
                    var percentageVal = Math.round(this.percentage * 10) / 10;

                    $el.text(percentageVal + '%');

                }
            }).promise().done(function () {
                // hard set the value after animation is done to be

                // $el.text(value + "%");


            });*/

        }

        function start_Rules_recursive_hitsC(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/rulesCheckProgressC",
                timeout: 1800000,
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {
                    console.log("completed syncing")
                    var percentage = 100;
                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    $('.progress-meter').stop();
                    var $el = $('.progress-val');
                    $('.progress-meter').animate({

                        width: percentage + '%'
                    }, {
                        duration: 5000,
                        step: function (now, fx) {
                            if (fx.prop == 'width') { //If you animate more than 1 property
                                var data = Math.round(now);
                                $el.text(data + ' % ');
                            }

                        },
                        done: function () {
                            Swal.fire(
                                'Syncing Successful',
                                'Data Successfully Synced Count :' + totRecord,
                                'success'
                            )
                        }
                    });
                    // if (nextPage == "Yes") {
                    //    start_Rules_recursive_hits(pageNumber + 1, pageSize);
                    // } else {

                    //}



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });
            var percentage = 60;
            var $el = $('.progress-val');
            $('.progress-meter').animate({

                width: percentage + '%'
            }, {
                duration: 250000,
                step: function (now, fx) {
                    if (fx.prop == 'width') { //If you animate more than 1 property
                        var data = Math.round(now);
                        $el.text(data + ' % ');
                    }
                }
            });

            /*$({ percentage: parseInt($('.progress-val').text(), 10) }).stop(true).animate({ percentage: value }, {
                duration: 150000,
                easing: "easeOutExpo",
                step: function () {
                    // percentage with 1 decimal;
                    var percentageVal = Math.round(this.percentage * 10) / 10;

                    $el.text(percentageVal + '%');

                }
            }).promise().done(function () {
                // hard set the value after animation is done to be

                // $el.text(value + "%");


            });*/

        }


        //hitting syncing API recursivly for items
        function start_recursive_hits(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/checkProgress",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);



                    var $el = $('.progress-val'),
                        value = percentage;
                    $('.progress-meter').stop(true).animate({

                        width: percentage + '%'
                    }, {
                        duration: 15000,
                        progress: function (promise, progress, ms) {
                            var val = Math.round(progress * 100) + '%';


                        }
                    });

                    $({ percentage: parseInt($('.progress-val').text(), 10) }).stop(true).animate({ percentage: value }, {
                        duration: 25000,
                        easing: "easeOutExpo",
                        step: function () {
                            // percentage with 1 decimal;
                            var percentageVal = Math.round(this.percentage * 10) / 10;

                            $el.text(percentageVal + '%');

                        }
                    }).promise().done(function () {
                        // hard set the value after animation is done to be

                        // $el.text(value + "%");

                    });






                    if (nextPage == "Yes") {
                        start_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        Swal.fire(
                            'Syncing Successful',
                            'Data Successfully Synced Count :' + totRecord,
                            'success'
                        )
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

        function start_recursive_hitsB(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/checkProgressB",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);



                    var $el = $('.progress-val'),
                        value = percentage;
                    $('.progress-meter').stop(true).animate({

                        width: percentage + '%'
                    }, {
                        duration: 15000,
                        progress: function (promise, progress, ms) {
                            var val = Math.round(progress * 100) + '%';


                        }
                    });

                    $({ percentage: parseInt($('.progress-val').text(), 10) }).stop(true).animate({ percentage: value }, {
                        duration: 25000,
                        easing: "easeOutExpo",
                        step: function () {
                            // percentage with 1 decimal;
                            var percentageVal = Math.round(this.percentage * 10) / 10;

                            $el.text(percentageVal + '%');

                        }
                    }).promise().done(function () {
                        // hard set the value after animation is done to be

                        // $el.text(value + "%");

                    });






                    if (nextPage == "Yes") {
                        start_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        Swal.fire(
                            'Syncing Successful',
                            'Data Successfully Synced Count :' + totRecord,
                            'success'
                        )
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

        function start_recursive_hitsC(pageNumber, pageSize) {
            $.ajax({
                type: "POST",
                url: "PullData_N.aspx/checkProgressC",
                contentType: "application/json; charset=utf-8",
                data: '{pageNumber:' + pageNumber + ',pageSize: ' + pageSize + ' }',
                success: function (msg) {

                    var json = $.parseJSON(msg.d);
                    var currentPage = json.currentPage;
                    var totalPages = json.totalPages;
                    var nextPage = json.nextPage;
                    var totRecord = json.totalCount;
                    var percentage = ((currentPage * 100) / totalPages);



                    var $el = $('.progress-val'),
                        value = percentage;
                    $('.progress-meter').stop(true).animate({

                        width: percentage + '%'
                    }, {
                        duration: 15000,
                        progress: function (promise, progress, ms) {
                            var val = Math.round(progress * 100) + '%';


                        }
                    });

                    $({ percentage: parseInt($('.progress-val').text(), 10) }).stop(true).animate({ percentage: value }, {
                        duration: 25000,
                        easing: "easeOutExpo",
                        step: function () {
                            // percentage with 1 decimal;
                            var percentageVal = Math.round(this.percentage * 10) / 10;

                            $el.text(percentageVal + '%');

                        }
                    }).promise().done(function () {
                        // hard set the value after animation is done to be

                        // $el.text(value + "%");

                    });






                    if (nextPage == "Yes") {
                        start_recursive_hits(pageNumber + 1, pageSize);
                    } else {
                        Swal.fire(
                            'Syncing Successful',
                            'Data Successfully Synced Count :' + totRecord,
                            'success'
                        )
                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    var json = $.parseJSON(XMLHttpRequest.responseText);
                    console.log(json);
                    Swal.fire(
                        '(' + XMLHttpRequest.status + ' )' + errorThrown,
                        json.Message,
                        'error'
                    )
                }

            });

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentheading" runat="Server">
    Pull Data from RDM
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-title">
        <div class="caption">
            Pull Data from RDM
        
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divmsg" class="" runat="server" style="display: none"></div>


            <div id="div_loading" runat="server" style="display: none; margin-top: 10%; margin-left: 35%; position: absolute;">
                <img id="img_load" runat="server" src="~/images/Pulsating circle.gif" />
                <p id="sync_data" runat="server">Data Syncing in Progress</p>
            </div>

            <div>
                <table class="dt-responsive table table-bordered v-middle" width="100%" id="tblReportList">
                    <thead class="red-th">
                        <tr>
                            <th>ID</th>
                            <th>Table Name</th>
                            <th class="action-th all">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>SS001</td>
                            <td>Pull Data from RDM (Corporates-TaxPayer) A-F</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>


                                            <asp:LinkButton runat="server" ID="lnk_Pull_Corporates" OnClientClick="startCorporateSyncing();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>SS001B</td>
                            <td>Pull Data from RDM (Corporates-TaxPayer) G</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>


                                            <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="startCorporateSyncingB();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>SS001C</td>
                            <td>Pull Data from RDM (Corporates-TaxPayer) H-Z</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>


                                            <asp:LinkButton runat="server" ID="LinkButton2" OnClientClick="startCorporateSyncingC();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>SS002</td>
                            <td>Pull Data from RDM (Assets) A - F</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>

                                            <asp:LinkButton runat="server" ID="lnk_Pull_Assets" OnClientClick="startAssetSyncing();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>SS002B</td>
                            <td>Pull Data from RDM (Assets) G</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>

                                            <asp:LinkButton runat="server" ID="lnk_Pull_AssetsB" OnClientClick="startAssetSyncingB();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>SS002C</td>
                            <td>Pull Data from RDM (Assets) H - Z</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>

                                            <asp:LinkButton runat="server" ID="lnk_Pull_AssetsC" OnClientClick="startAssetSyncingC();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>


                        <%--<tr>
                            <td>SS003</td>
                            <td>Pull Data From RDM (Items) A - F</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnk_Pull_Items" OnClientClick="startItemsSync();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                         <tr>
                            <td>SS003B</td>
                            <td>Pull Data From RDM (Items) G </td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="LinkButton3" OnClientClick="startItemsSyncB();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>SS003C</td>
                            <td>Pull Data From RDM (Items) H - Z </td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="LinkButton4" OnClientClick="startItemsSyncC();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>--%>

 <%--                       <tr>
                            <td>SS004</td>
                            <td>Pull Data From RDM (RULES)  A - F</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnk_Pull_Rules" OnClientClick="startRuleSync();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>SS004B</td>
                            <td>Pull Data From RDM (RULES) G </td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="LinkButton5" OnClientClick="startRuleSyncB();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>SS004C</td>
                            <td>Pull Data From RDM (RULES) H - Z </td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="LinkButton6" OnClientClick="startRuleSyncC();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>SS005</td>
                            <td>Pull Data From RDM (Profile)</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnk_Pull_Profile" OnClientClick="startProfileSync();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>SS005B</td>
                            <td>Pull Data From RDM (Profile) G </td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="LinkButton7" OnClientClick="startProfileSyncB();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                         <tr>
                            <td>SS005C</td>
                            <td>Pull Data From RDM (Profile) H - Z </td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="LinkButton8" OnClientClick="startProfileSyncC();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>SS006</td>
                            <td>Pull Data From RDM (Individuals)</td>
                            <td>
                                <div class="btn-group">
                                    <button type="button" class="btn btn-theme btn-xs md-skip dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        Action <span class="caret"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton runat="server" ID="lnk_Pull_Individuals" OnClientClick="startIndividualsSync();"> Start Pulling Data </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </td>
                        </tr>--%>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="modelpops" runat="Server">
</asp:Content>

