var univID = '';
var DefaultStartDate = "0";
var DefaultEndDate = "0";
function showDatachk( CollegeGrpId,deptID, collegeID, DateFrom, DateTo,type) {
    
    var resultData = "";
    var result = '';

    var urlws = '/APIService/APICollegeGroupAdminDashBoardReports/RegistrationReportCollegesummary?CollegeGrpId='+CollegeGrpId+'&deptID=' + deptID+'&collegeID='+ collegeID+'&DateFrom='+ DateFrom+'&DateTo='+ DateTo+'&type='+type;
  

    $('#tblMaster').DataTable({
        "bDestroy": true
    }).fnClearTable();
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlws,
        dataType: 'json',
        crossOrigin: true,
        success: function (response) {
            var rData = response;
            var j = 0;         
            for (var i = 0; i < rData.length; i++) {
                j = parseInt(j + 1);

                resultData += '<tr><td>' + j + '</td>' +
                    '<td id="colName" style="text-align:left;padding-left:25px;">' + rData[i].ITIName + '</td>' +
                    '<td>' + rData[i].activeationMinDate + '</td>';

                if (rData[i].TotalDesktop > 0) {
                    resultData += '<td><a class="Colleges" data-toggle="modal" data-target="#subjectModel" rel="' + rData[i].CollegeId + "~2" + '" href="#">' + rData[i].TotalDesktop + ' </a></td>';
                        
                } else {
                    resultData += '<td>' + rData[i].TotalDesktop + '</td>';
                       
                }

                if (rData[i].TotalTrades > 0) {
                    resultData += '<td><a class="Colleges" data-toggle="modal" data-target="#subjectModel" rel="' + rData[i].CollegeId + "~3" + '" href="#">' + rData[i].TotalTrades + ' </a></td></tr>';
                } else {
                    resultData += '<td>' + rData[i].TotalTrades + '</td></tr>';
                }

            }
            setTimeout(function () {
                $('#tblMaster tbody').html(resultData);
                $('#tblMaster').DataTable({
                    "bProcessing": true,
                    "deferRender": true,
                    "bDestroy": true
                });
            }, 100);
        },

        complete: function () {
            $('.loader').hide();
        },
        error: function (result) {
            ShowAlert("Registration Report", "Please Contact Administrator");
        }
    });
}

function showData() {
    var resultData = "";
    var result = '';
    var urlws = '/APIService/APIAdminReport/RegistrationReportCollegesummary';

    $('#tblMaster').DataTable({
        "bDestroy": true
    }).fnClearTable();
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlws,
        dataType: 'json',
        crossOrigin: true,
        success: function (response) {
            var rData = response.RegistrationReport;
            var j = 0;
            alert("rData" + rData.length);
            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                resultData += '<tr><td>' + j + '</td>' +
                              '<td id="colName" style="text-align:left;padding-left:25px;">' + rData[i].ITIName + '</td>' +
                              '<td><a class="Colleges" data-toggle="modal" data-target="#subjectModel" rel="' + rData[i].CollegeId + "~1"  + '" href="#">' + rData[i].TotalDesktop + ' </a></td>' +
                              '<td><a class="Colleges" data-toggle="modal" data-target="#subjectModel" rel="' + rData[i].CollegeId + "~2" + '" href="#">' + rData[i].TotalTrades + ' </a></td>' +
                              '<td><a class="Colleges" data-toggle="modal" data-target="#subjectModel" rel="' + rData[i].CollegeId + "~3" + '" href="#">' + rData[i].TotalInstructors + ' </a></td></tr>';


            }
            setTimeout(function () {
                $('#tblMaster tbody').html(resultData);
                $('#tblMaster').DataTable({
                    "bProcessing": true,
                    "deferRender": true,
                    "bDestroy": true
                });
            }, 100);
        },

        complete: function () {
            $('.loader').hide();
        },
        error: function (result) {
            ShowAlert("Registration Report", "Please Contact Administrator");
        }
    });

}

function showRegistrationHistory(collegeid, sessionuserID) {

    
 
    var colId = collegeid.split('~')[0];
    var roleId = collegeid.split('~')[1];
    var table = '';
    var table1 = '';
    var Display = '';
    var regTypeID = 1;

    //if ($("#RegType").val() != "") {
    //    alert("regtype" + $("#RegType").val());
    //    regTypeID = $("#RegType").val();
    //}
    var deptID = $("#TradeName").val();

    if ($("#StartDate").val() != "") {
        DefaultStartDate = $("#StartDate").val();
    }

    if ($("#EndDate").val() != "") {
        DefaultEndDate = $("#EndDate").val();
    }

   $('#tblChild').DataTable({
        "bProcessing": true,
        "bDestroy": true
    }).fnClearTable();

   WebChildURL = '/APIService/APICollegeGroupAdminDashBoardReports/RegistrationReportCollegeDetails?CollegeGrpId=' + sessionuserID+'&category=' + roleId + '&collegeid=' + colId + '&regtype=' + regTypeID + '&deptID=' + deptID + '&DateFrom=' + DefaultStartDate + '&DateTo=' + DefaultEndDate;
   // alert("WebChildURL" + WebChildURL);

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: WebChildURL,
        dataType: 'json',
        crossOrigin: true,
        success: function (res) {
            var rData1 = res;
            var j = 0;
            var studroleId = "-1";
            var staffRoleId = "-2";

            for (var i = 0; i < rData1.length; i++) {

                j = parseInt(j + 1);

                table +=
                           '<tr>' +
                           '<td>' + j + '</td>' +
                           '<td style="text-align:left;padding-left:25px;">' + rData1[i].InstructorName + '</td>' +
                            '<td>' + rData1[i].RegisteredOn + '</td></tr>';
            }
            setTimeout(function () {
                Display = table.toString() + table1.toString();
                $('#tblChild tbody').html(table);
                $('#tblChild').DataTable({
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "235px",
                    "scrollY": 200,
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false
                });
            }, 200);
        },
        error: function (result) {
            alert("Error");
        },
        complete: function () {
            $('.loader').hide();
        }

    });
    $("#tblChild").css("width", "100%")
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};

$(document).ready(function () {
    univID = getUrlParameter('UnivID');

});

$(function () {

    $('#btnStaff').click(function () {
        window.location.href = "/Admin/registrationStaff";
    });
    $('#btnStudent').click(function () {
        window.location.href = "/Admin/registrationStudent";
    });
    $(document).on('click', '.Colleges', function (e) {

        e.preventDefault();
        $('#SubjectUnitDetails table tbody').html('Loading.Please wait...');

        collegeId = $(this).attr('rel');
        var sessuserID = sessionCollegeGrpId; // $("#GGrpId").val();
        var collegeName = $(this).parent().parent().find("#colName").text();

        $("#DynamicCollegeName").text("Institute :" + collegeName).css('font-weight', 'bold');
        showRegistrationHistory(collegeId, sessuserID);
    });

});

