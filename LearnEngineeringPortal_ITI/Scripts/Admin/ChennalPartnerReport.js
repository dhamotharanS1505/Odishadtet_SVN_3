
var year = '';
var startdate = '';
var endDate = '';
var strYear = '';
var univId = '';
var collegeId = '';
var TeamId = '';


function showDataForParticularChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId) {

    $('#tblChennalPartnerCollegeWise tbody').html('');
    $('#tblChennalPartnerCollegeWise').DataTable({
        //"filter": false,
        "bDestroy": true,
        "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
        "iDisplayLength": 5,
        "sScrollY": "235px",
        "scrollY": 200,
        "scrollCollapse": true,
        "bAutoWidth": false,
        "bProcessing": true,
        "paging": false
    }).fnClearTable();
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/chennalPartnerWiseCollegeDetails?univId=' + univId + '&college_id=' + collegeId + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&bcustID=' + bcustId + '&TeamId=' + TeamId + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,


        success: function (response) {
            //var xmlData = $(response).find("GetAllReadHistroyResult").text();
            var rData = JSON.parse(response.chennalPartnerWiseCollegeDetailsResult);
            //var rData = response.UniversityReadHistoryResult;
            var res;
            var j = 0;

            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td id="UserName">' + rData[i].CollegeName + '</td>' +
                        '<td>' + rData[i].TeamName + '</td>' +
                        '<td>' + rData[i].StudentCount + '</td>' +
                        '</tr>';

            }

            $('#tblChennalPartnerCollegeWise tbody').html(res);
            $('#tblChennalPartnerCollegeWise').DataTable({
                
                "bDestroy": true,
                "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                "iDisplayLength": 5,
                "sScrollY": "235px",
                "scrollY": 200,
                "scrollCollapse": true,
                "bAutoWidth": false,
                "bProcessing": true,
                "paging": false
                // "aoColumnDefs": [{ "sType": "num-html", "aTargets": [4, 5]}]

            });


        },

        error: function (result) {
            alert("Error");
        },
        complete: function () {
            $('.loader').hide();
        }
    });
}


function showData(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId) {
   
    $('#tblChennalPartner tbody').html('');
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/chennalPartnerReport?univId=' + univId + '&college_id=' + collegeId + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&bcustID=' + bcustId + '&TeamId=' + TeamId + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,


        success: function (response) {
            //var xmlData = $(response).find("GetAllReadHistroyResult").text();
            var rData = JSON.parse(response.chennalPartnerReportResult);
            //var rData = response.UniversityReadHistoryResult;
            var res;
            var j = 0;

            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td id="UnivName">' + rData[i].univName + '</td>' +

                        '<td id="CustomerName"><a id="CustId" data-toggle="modal" data-target="#CPR_TeamWise" rel="' + rData[i].bcustId + '" href="#">' + rData[i].CustomerName + '</a></td>' +
                        '<td>' + rData[i].bcustMobile + '</td>' +
                        '<td><a id="overallcollegeCount" data-toggle="modal" data-target="#channelPartnerOverallCollegeDetails" rel="' + rData[i].bcustId + '-' + rData[i].univID + '" href="#">' + rData[i].CollegeCountOverAll + '</td>' +
                        '<td><a id="collegeCount" data-toggle="modal" data-target="#channelPartnerr" rel="' + rData[i].bcustId + '-' + rData[i].univID + '" href="#">' + rData[i].CollegeCount + '</td>' +
                        '<td ><a id="studCnt" data-toggle="modal" data-target="#channelPartner" rel="' + rData[i].bcustId + '-' + rData[i].univID + '" href="#">' + parseInt(rData[i].StudentCount) + '</a></td>' +
                        '<td><a id="staffCnt" data-toggle="modal" data-target="#channelPartnerForStaff" rel="' + rData[i].bcustId + '-' + rData[i].univID + '" href="#">' + parseInt(rData[i].StaffCount) + '</a></td>' +
                        '</tr>';

            }

            $('#tblChennalPartner tbody').html(res);

        },

        error: function (result) {
            alert("Error");
        },
        complete: function () {
            $('.loader').hide();
        }
    });
}

function StudentCountForChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId) {
    $('#tblchannelPartnerReport tbody').html('');
    $('#tblchannelPartnerReport').DataTable({
        //"filter": false,
        "bDestroy": true,
        "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
        "iDisplayLength": 5,
        "sScrollY": "235px",
        "scrollY": 200,
        "scrollCollapse": true,
        "bAutoWidth": false,
        "bProcessing": true,
        "paging": false

    }).fnClearTable();
    $.ajax({

        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/chennalPartnerForRegisteredStudent?univId=' + univId + '&college_id=' + collegeId + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&bcustID=' + bcustId + '&TeamId=' + TeamId + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,


        success: function (response) {
            //var xmlData = $(response).find("GetAllReadHistroyResult").text();
            var rData = JSON.parse(response.chennalPartnerForRegisteredStudentResult);
            //var rData = response.UniversityReadHistoryResult;
            var res;
            var j = 0;
            //var ress = '<<tr><th >S.No</th><th >College Name</th><th >Student Name</th></tr></thead>';
            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td>' + rData[i].CollegeName + '</td>' +
                         '<td>' + rData[i].TeamName + '</td>' +
                        '<td>' + rData[i].StudentName + '</td>' +
                        '<td>' + rData[i].UserMobile + '</td>' +
                        '<td>' + rData[i].UserEmailId + '</td>' +
                        '</tr>';

            }

            setTimeout(function () {

                $('#tblchannelPartnerReport tbody').html(res);
                $('#tblchannelPartnerReport').DataTable({
                    "bDestroy": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "235px",
                    "scrollY": 200,
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false
                    // "aoColumnDefs": [{ "sType": "num-html", "aTargets": [4, 5]}]

                });

            }, 100);
        },

        error: function (result) {
            alert("Error");
        }

    });

}

function StaffCountForChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId) {
    $('#tblchannelPartnerStaff tbody').html('');
    $('#tblchannelPartnerStaff').DataTable({
        //"filter": false,
        "bDestroy": true,
        "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
        "iDisplayLength": 5,
        "sScrollY": "235px",
        "scrollY": 200,
        "scrollCollapse": true,
        "bAutoWidth": false,
        "bProcessing": true,
        "paging": false
    }).fnClearTable();
    $.ajax({

        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/chennalPartnerForRegisteredStaff?univId=' + univId + '&college_id=' + collegeId + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&bcustID=' + bcustId + '&TeamId=' + TeamId + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,


        success: function (response) {
            //var xmlData = $(response).find("GetAllReadHistroyResult").text();
            var rData = JSON.parse(response.chennalPartnerForRegisteredStaffResult);
            //var rData = response.UniversityReadHistoryResult;
            var res;
            var j = 0;
            //var ress = '<<tr><th >S.No</th><th >College Name</th><th >Student Name</th></tr></thead>';
            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td>' + rData[i].CollegeName + '</td>' +
                         '<td>' + rData[i].TeamName + '</td>' +
                        '<td>' + rData[i].StudentName + '</td>' +
                         '<td>' + rData[i].UserMobile + '</td>' +
                        '<td>' + rData[i].UserEmailId + '</td>' +
                '</tr>';

            }
            setTimeout(function () {
                $('#tblchannelPartnerStaff tbody').html(res);
                $('#tblchannelPartnerStaff').DataTable({

                    "bDestroy": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "235px",
                    "scrollY": 200,
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false
                    // "aoColumnDefs": [{ "sType": "num-html", "aTargets": [4, 5]}]

                });
            }, 100);

        },

        error: function (result) {
            alert("Error");
        }

    });

}


function channelPartnerAllCollegeDetails(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId) {
    $('#tblchannelPartnerCollegeDetails tbody').html('');



//    $('#tblchannelPartnerCollegeDetails').html(headdata);

    $('#tblchannelPartnerCollegeDetails').DataTable({
        //"filter": false,
        "bDestroy": true,
        "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
        "iDisplayLength": 5,
        "sScrollY": "235px",
        "scrollCollapse": true,
        "bAutoWidth": false,
        "bProcessing": true,
        "paging": false
    }).fnClearTable();
    $.ajax({

        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/chennalPartnerOverallCollegeDetails?univId=' + univId + '&college_id=' + collegeId + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&bcustID=' + bcustId + '&TeamId=' + TeamId + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,


        success: function (response) {

            var rData = JSON.parse(response.chennalPartnerOverallCollegeDetailsResult);
            //var rData = response.UniversityReadHistoryResult;
            var res;
            var j = 0;

            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td>' + rData[i].CollegeName + '</td>' +
                         '<td>' + rData[i].TeamName + '</td>' +
                        '</tr>';

            }

            setTimeout(function () {


                $('#tblchannelPartnerCollegeDetails tbody').html(res);
                $('#tblchannelPartnerCollegeDetails').DataTable({

                    "bDestroy": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "235px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false

                });

            }, 100);
        },

        error: function (result) {
            alert("Error");
        }

    });

}

function TeamWiseChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId) {

    $('#tbl_CPR_TeamWise tbody').html('');
    $('#tbl_CPR_TeamWise').DataTable({
        //"filter": false,
        "bDestroy": true,
        "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
        "iDisplayLength": 5,
        "sScrollY": "235px",
        "scrollY": 200,
        "scrollCollapse": true,
        "bAutoWidth": false,
        "bProcessing": true,
        "paging": false
    }).fnClearTable();
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/chennalPartnerReportTeamWise?univId=' + univId + '&college_id=' + collegeId + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&bcustID=' + bcustId + '&TeamId=' + TeamId + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,


        success: function (response) {
            //var xmlData = $(response).find("GetAllReadHistroyResult").text();
            var rData = JSON.parse(response.chennalPartnerReportTeamWiseResult);
            //var rData = response.UniversityReadHistoryResult;
            var res;
            var j = 0;
           
            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td id="TeamName">' + rData[i].TeamName + '</td>' +
                        '<td>' + rData[i].CollegeCount + '</td>' +
                        '<td>' + parseInt(rData[i].StudentCount) + '</a></td>' +
                        '<td>' + parseInt(rData[i].StaffCount) + '</a></td>' +
                        '</tr>';

            }
            setTimeout(function () {


                $('#tbl_CPR_TeamWise tbody').html(res);
                $('#tbl_CPR_TeamWise').DataTable({

                    "bDestroy": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "235px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false

                });

            }, 300);
           

        },

        error: function (result) {
            alert("Error");
        },
        complete: function () {
            $('.loader').hide();
        }
    });
}




var Univ_Id = '';
var bcustId = '';
function getUniversity() {
    if ($('#chkAnna').prop('checked') == true && $('#chkVTU').prop('checked') == true) {
        Univ_Id = '1,2';
    }
    else if ($('#chkAnna').prop('checked') == true && $('#chkVTU').prop('checked') != true) {
        Univ_Id = '1';
    }
    else if ($('#chkAnna').prop('checked') != true && $('#chkVTU').prop('checked') == true) {
        Univ_Id = '2';
    }
    else if ($('#chkAnna').prop('checked') != true && $('#chkVTU').prop('checked') != true) {
        Univ_Id = '';
    }
}



$(function () {

    $('.package').click(function () {

        alert(1);

    });


    //    $("select").multiselect({
    //        selectedList: 4 // 0-based index
    //    });

    $('#tblChennalPartnerCollegeWise thead').hide();
    //    $("select").multiselect({
    //        selectedText: function (numChecked, numTotal, checkedItems) {
    //            return numChecked + ' of ' + numTotal + ' checked';
    //        }
    //    });

    jQuery.fn.dataTableExt.oSort['num-html-asc'] = function (a, b) {
        var x = a.replace(/<.*?>/g, "");
        var y = b.replace(/<.*?>/g, "");
        x = parseFloat(x);
        y = parseFloat(y);
        return ((x < y || isNaN(y)) ? -1 : ((x > y || isNaN(x)) ? 1 : 0));
    };

    jQuery.fn.dataTableExt.oSort['num-html-desc'] = function (a, b) {
        var x = a.replace(/<.*?>/g, "");
        var y = b.replace(/<.*?>/g, "");
        x = parseFloat(x);
        y = parseFloat(y);
        return ((x < y || isNaN(x)) ? 1 : ((x > y || isNaN(y)) ? -1 : 0));
    };



    //showData(1);
  //  showData(strYear, startdate, endDate, univId, collegeId, TeamId)

    $('#chkAnna').click(function () {

        getUniversity();
        showData(Univ_Id);

    });
    $('#chkVTU').click(function () {
        getUniversity();
        showData(Univ_Id);

    });


    $(document).on('click', '[data-target="#channelPartnerr"]', function (e) {
        e.preventDefault();

        $('#chanlpartnershow').show();
        $('#tblChennalPartnerCollegeWise thead').show();
        $('#tblChennalPartnerCollegeWise table tbody').html('Loading.Please wait...');
//        getUniversity();
//        bcustId = $(this).attr('rel');

        var data = $(this).attr('rel');
        var arr = data.split('-');
        bcustId = arr[0];
        univId = arr[1];

        showDataForParticularChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
        //StudentCountForChannelPartner(bcustId, Univ_Id);

    });

    $(document).on('click', '[data-target="#CPR_TeamWise"]', function (e) {
        e.preventDefault();

        bcustId = $(this).attr('rel');
        ID = $(this).attr('id');
        getUniversity();
        TeamWiseChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
        var customerName = $(this).parent().parent().find("#CustomerName").text();
        $("#Cus_Name").text("Customer Name : " + customerName).css('font-weight', 'Bold');


    });


    $(document).on('click', '[data-target="#channelPartner"]', function (e) {
        e.preventDefault();

//        bcustId = $(this).attr('rel');
        ID = $(this).attr('id');
        //        getUniversity();

        var data = $(this).attr('rel');
        var arr = data.split('-');
        bcustId = arr[0];
        univId = arr[1];

        StudentCountForChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
        var customerName = $(this).parent().parent().find("#CustomerName").text();
        $("#UserrName").text("University :" + univName + "  " + "  Partner Name : " + customerName).css('font-weight', 'Bold');
    });


    $(document).on('click', '[data-target="#channelPartnerForStaff"]', function (e) {
        e.preventDefault();

//        bcustId = $(this).attr('rel');
        ID = $(this).attr('id');
//        getUniversity();
        
        var data = $(this).attr('rel');
        var arr = data.split('-');
        bcustId = arr[0];
        univId = arr[1];

        StaffCountForChannelPartner(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
        var customerName = $(this).parent().parent().find("#CustomerName").text();
        $("#cusName").text("University :" + univName + "  " + "  Partner Name : " + customerName).css('font-weight', 'Bold');


    });

    $(document).on('click', '[data-target="#channelPartnerOverallCollegeDetails"]', function (e) {
        e.preventDefault();


        ID = $(this).attr('id');
        var data = $(this).attr('rel');
        var arr = data.split('-');
        bcustId = arr[0];
        univId = arr[1];
//        getUniversity();

        channelPartnerAllCollegeDetails(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
        var customerName = $(this).parent().parent().find("#CustomerName").text();
        var univName = $(this).parent().parent().find("#UnivName").text();
        $("#customerNameCol").text("University :" + univName + "  " + "Partner Name : " + customerName).css('font-weight', 'Bold');


    });




    $('#btnChannelPartner').click(function () {
        getUniversity();
        window.location.href = "/Admin/ChannelPartnerReport?univId=" + Univ_Id;
    });

});



//.........Filter...........
$(document).ready(function () {



    $("#startdate").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#EndDate").datepicker({ dateFormat: 'dd-mm-yy' });


    $('#ddlTeam').multiselect({
        includeSelectAllOption: true
    });
    $('#ddlYear').multiselect({
        includeSelectAllOption: true
    });
    $('#ddlsemster').multiselect({
        includeSelectAllOption: true

    });
    $('#ddlCollege').multiselect({
        includeSelectAllOption: true,
        enableFiltering: true,
        filterBehavior: 'text',
        enableCaseInsensitiveFiltering: true
    });

    startdate = 0;
    endDate = 0;
    strYear = 0;
    univId = 0;
    collegeId = 0;
    TeamId = 0;
    bcustId = 0;
    showData(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
});


function LoadUniversity() {
    $.ajax({
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/adminservice.svc/adminservice/UserUnitDetailsUniversity?xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,
        success: function (data) {
            var rData = data.UserUnitDetailsUniversityResult;
            var markup = "<option value=''>--- Select University ---</option>";

            for (var x = 0; x < rData.length; x++) {

                markup = markup + "<option value=" + rData[x].Universityid + ">" + rData[x].UniversityName + "</option>";
            }

            $('#ddlUniversity').find('option').remove().end().append(markup);

        },
        error: function () {
            alert("Error");
        }
    });
}

function LoadChannelPartner() {
    $.ajax({
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/adminservice.svc/adminservice/getChannelPartnerDetails?xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,
        success: function (data) {
            var rData = data.getChannelPartnerDetailsResult;
            var markup = "<option value=''>--- Select ChannelPartner ---</option>";

            for (var x = 0; x < rData.length; x++) {

                markup = markup + "<option value=" + rData[x].bcustId + ">" + rData[x].CustomerName + "</option>";
            }

            $('#ddlChannelPtnr').find('option').remove().end().append(markup);

        },
        error: function () {
            alert("Error");
        }
    });
}


$(function () {
    LoadUniversity();
    LoadChannelPartner();
    $('#ddlChannelPtnr').change(function () {
        var BcustID = $("#ddlChannelPtnr").find("option:selected").val();
        $.ajax({
            type: 'GET',
            url: $('#WebServiceUrl').val() + '/AdminService.svc/AdminService/getChannelPartnerTeamDetails?bcustID=' + BcustID + '',
            dataType: 'json',
            crossOrigin: true,
            success: function (ddTeam) {
                var rDataTeam = "";
                rDataTeam = ddTeam.getChannelPartnerTeamDetailsResult;
                var Team = "";
                for (var x = 0; x < rDataTeam.length; x++) {
                    Team = Team + "<option value=" + rDataTeam[x].TeamId + ">" + rDataTeam[x].TeamName + "</option>";

                }
                $('#ddlTeam').find('option').remove().end().append(Team);

                $("#ddlTeam").multiselect('destroy');
                $('#ddlTeam').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    // enableFiltering: true,
                    //filterBehavior: 'text',
                    //enableCaseInsensitiveFiltering: true,
                    numberDisplayed: 1
                });

            },
            error: function (result) {
                alert("Error");
            }
        });

    });

    $('#ddlUniversity').change(function () {
        var selectedUniversity = $("#ddlUniversity").find("option:selected").val();
        $.ajax({
            type: 'GET',
            url: $('#WebServiceUrl').val() + '/AdminService.svc/AdminService/LoadColleges?univ_id=' + selectedUniversity + '',
            dataType: 'json',
            crossOrigin: true,
            success: function (ddcollege) {
                var rDatacollg = "";
                rDatacollg = ddcollege.LoadCollegesResult;
                var colleges = "";
                for (var x = 0; x < rDatacollg.length; x++) {
                    colleges = colleges + "<option value=" + rDatacollg[x].CollegeId + ">" + rDatacollg[x].CollegeName + "</option>";

                }
                $('#ddlCollege').find('option').remove().end().append(colleges);

                $("#ddlCollege").multiselect('destroy');
                $('#ddlCollege').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    // enableFiltering: true,
                    //filterBehavior: 'text',
                    //enableCaseInsensitiveFiltering: true,
                    numberDisplayed: 1
                });

            },
            error: function (result) {
                alert("Error");
            }
        });

    });


    $('#btnApplyFilter').click(function () {

        var searchResult = "<b>Filtered Results For:  </b>";
        year = $("#ddlYear option:selected");
        var team = $("#ddlTeam option:selected");
        univId = $('#ddlUniversity option:selected').val();
        bcustId = $('#ddlChannelPtnr option:selected').val();
        college_Id = $("#ddlCollege option:selected");
        var selctCollege = '';
        college_Id.each(function () {
            selctCollege = selctCollege + $(this).val() + "-";
        });
        collegeId = selctCollege.substring(0, selctCollege.length - 1);

        startdate = $("#startdate").val();
        endDate = $("#EndDate").val();


        var selctyear = '';
        year.each(function () {
            selctyear = selctyear + $(this).val() + "-";
        });
        strYear = selctyear.substring(0, selctyear.length - 1);

        var selctteam = '';
        team.each(function () {
            selctteam = selctteam + $(this).val() + "-";
        });
        TeamId = selctteam.substring(0, selctteam.length - 1);

        var universityName = $("#ddlUniversity option:selected").text();
        if (universityName != "--- Select University ---") {

            searchResult += "<b>" + universityName + "</b>";
        }
        if (strYear == '') {
            strYear = 0;
        }
        else {
            searchResult += "  Year:" + " " + " " + "<b>" + strYear + "</b> ";
        }

        if (startdate == '') {
            startdate = 0;
        }
        else {
            searchResult += "  Reg Start date: <b>" + startdate + "</b>";
        }

        if (endDate == '') {
            endDate = 0;
        }
        else {
            searchResult += "  Reg End date: <b>" + endDate + "</b>";
        }

        if (collegeId == '') {
            collegeId = 0;
        }

        if (TeamId == '') {
            TeamId = 0;
        }
        if (bcustId == '') {
            bcustId = 0;
        }
        if (univId == '')
            univId = 0;

        showData(strYear, startdate, endDate, univId, collegeId, TeamId, bcustId);
        $('#closepopup').trigger('click');


        $("#DynamicFilteredData").html(searchResult).css('font-weight', 'Medium');

        $('#tblMaster').DataTable({
            "bProcessing": true,
            "bDestroy": true
        }).fnClearTable();

    });

    $('#refreshFilter').click(function () {
        clearpopup();
        showData(0, 0, 0, 0, 0, 0, 0, 0);

        startdate = 0;
        endDate = 0;
        strYear = 0;
        univId = 0;
        collegeId = 0;
        semester = 0;
        usg_Startdate = 0;
        usd_End_date = 0;
        TeamId = 0;
        bcustId = 0;

        $("#DynamicFilteredData").html('');
        $('#tblMaster').DataTable({
            "bDestroy": true
        }).fnClearTable();
    });
    $('#btnClearFilter').click(function () {
        clearpopup();
    });

    function clearpopup() {
        $('#ddlYear').multiselect('deselectAll', false);
        $('#ddlYear').multiselect('updateButtonText');
        $('#ddlCollege').multiselect('deselectAll', false);
        $('#ddlCollege').multiselect('updateButtonText');
        $('#ddlTeam').multiselect('deselectAll', false);
        $('#ddlTeam').multiselect('updateButtonText');

        $("#startdate").val('');
        $("#EndDate").val('');
        $('#ddlUniversity').val('');
        $('#ddlChannelPtnr').val('');

        startdate = 0;
        endDate = 0;
        strYear = 0;
        bcustId = 0;
    }
});
