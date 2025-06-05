
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
        error: function (result) {
            alert("Error");
        }
    });
}

$(function () {

    var customDateDDMMMYYYYToOrd = function (date) {
        "use strict"; //let's avoid tom-foolery in this function
        // Convert to a number YYYYMMDD which we can use to order
        var dateParts = date.split(/-/);
        return (dateParts[2] * 10000) + ($.inArray(dateParts[1].toUpperCase(), ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"]) * 100) + (dateParts[0] * 1);
    };

    // This will help DataTables magic detect the "dd-MMM-yyyy" format; Unshift
    // so that it's the first data type (so it takes priority over existing)
    jQuery.fn.dataTableExt.aTypes.unshift(function (sData) {
        "use strict"; //let's avoid tom-foolery in this function
        if (/^([0-2]?\d|3[0-1])-(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)-\d{4}/i.test(sData)) {
            return 'date-dd-mmm-yyyy';
        }
        return null;
    });

    // define the sorts
    jQuery.fn.dataTableExt.oSort['date-dd-mmm-yyyy-asc'] = function (a, b) {
        "use strict"; //let's avoid tom-foolery in this function
        var ordA = customDateDDMMMYYYYToOrd(a),
        ordB = customDateDDMMMYYYYToOrd(b);
        return (ordA < ordB) ? -1 : ((ordA > ordB) ? 1 : 0);
    };

    jQuery.fn.dataTableExt.oSort['date-dd-mmm-yyyy-desc'] = function (a, b) {
        "use strict"; //let's avoid tom-foolery in this function
        var ordA = customDateDDMMMYYYYToOrd(a),
        ordB = customDateDDMMMYYYYToOrd(b);
        return (ordA < ordB) ? 1 : ((ordA > ordB) ? -1 : 0);
    };


    $(function () {
        $("#tabs").tabs();
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
});

var year = '';
var startdate = '';
var endDate = '';
var usg_Startdate = '';
var usd_End_date = '';
var strYear = '';
var semester = '';
var univId = '';
var collegeId = '';

function showUnivData(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester) {
    var snCount = 0;
    var res = "";
    var resMOU = '';
    var result = '';
    var urlwebs = '';
    var resultMOU = '';
    var resultDetails = '';

    if (strYear == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0) {

        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/RegisteredUsageDownloadDetails?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    else {
        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/RegisteredUsageDownloadDetails?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    $('#tblMasterMain').DataTable().destroy();
    //.DataTable({
    //    "bProcessing": true,
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        crossOrigin: true,
        async: false,
        success: function (res) {
            var rData = res.RegisteredUsageDownloadDetailsResult;
            var studroleId = "-1";
            var staffRoleId = "-2";
            var annaService = "-1";

            for (var i = 0; i < rData.length; i++) {

                snCount = parseInt(snCount + 1);

                if (snCount == 1) {
                    resultDetails += '<tr>' +
                   '<td id="UnivName"> <b> ' + rData[i].processName + '</b></td>' +
                        '<td><a id="regClg"  data-toggle="c" rel="' + rData[i].universityid + '" href="#">' + rData[i].CollegeCount + ' </a></td>' +
                         '<td>' + rData[i].StudentCount + ' </a></td>' +
                          '<td>' + rData[i].StaffCount + ' </a></td>' + '<td>' + '<b>' + rData[i].TotalRegistration + '</b>' + '</td></tr>';
                }
                else {

                    resultDetails += '<tr>' +
                   '<td id="UnivName"> <b> ' + rData[i].processName + '</b></td>' +
                        '<td>' + rData[i].CollegeCount + ' </a></td>' +
                         '<td>' + rData[i].StudentCount + ' </a></td>' +
                          '<td>' + rData[i].StaffCount + ' </a></td>' + '<td>' + '<b>' + rData[i].TotalRegistration + '</b>' + '</td></tr>';
                }


            }
            $('#tblMasterMain tbody').html(resultDetails);
            $('#tblMasterMain').DataTable({
                "bProcessing": true,
                "bDestroy": true,
                "deferRender": true,
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [0]}],
                "aaSorting": [],
                "bPaginate": false,
                "bFilter": false,
                "bInfo": false

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

function RegisteredCollgeDetails(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester) {

    var snCount = 0;
    var res = "";
    var resMOU = '';
    var result = '';
    var urlwebs = '';
    var resultMOU = '';
    var resultDetails = '';

    if (strYear == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0) {

        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/CollegeWiseRegisteredUsageDownloadDetails?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    else {
        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/CollegeWiseRegisteredUsageDownloadDetails?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    $('#tblMaster').DataTable().destroy();
    //.DataTable({
    //    "bProcessing": true,
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        crossOrigin: true,
        async: false,
        success: function (res) {
            var rData = res.CollegeWiseRegisteredUsageDownloadDetailsResult;
            var studroleId = "-1";
            var staffRoleId = "-2";
            var annaService = "-1";

            for (var i = 0; i < rData.length; i++) {

                snCount = parseInt(snCount + 1);

                resultDetails += '<tr>' +
                //  '<td> <input id="chKAnna" type="checkbox" class="chk" name="chkUniv" value=' + rData[i].universityid + annaService + ' /></td>' +
                //    '<td>' + snCount + '</td>' +
                          '<td>' + parseInt(snCount) + '</td>' +
                          '<td id="ColgName"> <b> ' + rData[i].collegeName + '</b></td>' +
                        '<td><a id="regStud" data-toggle="modal" data-target="#RegStudent" style="color:#0073e6;"  rel="' + rData[i].collegeid + '-1" href="#">' + rData[i].studentRegUser + ' </a></td>' +
                         '<td>' + rData[i].studentDownloadUser + ' </a></td>' +
                          '<td>' + rData[i].studentUsageUser + ' </a></td>' +
                          '<td><a id="regStaf" data-toggle="modal" data-target="#RegStudent" style="color:#0073e6;" rel="' + rData[i].collegeid + '-2" href="#">' + rData[i].staffRegUser + ' </a></td>' +
                          '<td>' + rData[i].staffDownloadUser + '</td>' +
                          '<td>' + rData[i].staffUsageUser + '</td></tr>';


            }
            $('#tblMaster tbody').html(resultDetails);
            $('#tblMaster').DataTable({
                "bProcessing": true,
                "bDestroy": true,
                // "aoColumnDefs": [{ "bSortable": false, "aTargets": [0]}],
                "aaSorting": []

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

function RegisteredUsageDateWise(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester) {

    var snCount = 0;
    var res = "";
    var resMOU = '';
    var result = '';
    var urlwebs = '';
    var resultMOU = '';
    var resultDetails = '';

    if (strYear == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0) {

        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/DateWiseRegisteredUsageDownloadDetails?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    else {
        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/DateWiseRegisteredUsageDownloadDetails?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    $('#tblMasterDateWise').DataTable().destroy();
    //.DataTable({
    //    "bProcessing": true,
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        crossOrigin: true,
        async: false,
        success: function (res) {
            var rData = res.DateWiseRegisteredUsageDownloadDetailsResult;
            var studroleId = "-1";
            var staffRoleId = "-2";
            var annaService = "-1";

            for (var i = 0; i < rData.length; i++) {

                snCount = parseInt(snCount + 1);

                resultDetails += '<tr>' +
                          '<td>' + snCount + '</td>' +
                          '<td> ' + rData[i].Datewise + '</td>' +
                        '<td><a id="regStudDateWise30" data-toggle="modal" data-target="#RegStudent" style="color:#0073e6;"  rel="' + rData[i].Datewise + '~1" href="#">' + rData[i].studentRegUser + '</td>' +
                         '<td>' + rData[i].studentDownloadUser + '</td>' +
                          '<td>' + rData[i].studentUsageUser + '</td>' +
                          '<td><a id="regStafDateWise30" data-toggle="modal" data-target="#RegStudent" style="color:#0073e6;"  rel="' + rData[i].Datewise + '~2" href="#">' + rData[i].staffRegUser + ' </td>' +
                          '<td>' + rData[i].staffDownloadUser + '</td>' +
                          '<td>' + rData[i].staffUsageUser + '</td></tr>';


            }
            $('#tblMasterDateWise tbody').html(resultDetails);
            $('#tblMasterDateWise').DataTable({
                "bProcessing": true,
                "deferRender": true,
                "bDestroy": true,
                // "aoColumnDefs": [{ "bSortable": false, "aTargets": [0]}],
                "aaSorting": []

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


function RegisteredUsageDateWiseForlast3Months(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester) {

    var snCount = 0;
    var res = "";
    var resMOU = '';
    var result = '';
    var urlwebs = '';
    var resultMOU = '';
    var resultDetails = '';

    if (strYear == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0) {

        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/DateWiseRegisteredUsageDownloadDetailsForLast3Months?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    else {
        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/DateWiseRegisteredUsageDownloadDetailsForLast3Months?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    $('#tblMasterDateWise_3Months').DataTable().destroy();
    //.DataTable({
    //    "bProcessing": true,
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        crossOrigin: true,
        async: false,
        success: function (res) {
            var rData = res.DateWiseRegisteredUsageDownloadDetailsForLast3MonthsResult;
            var studroleId = "-1";
            var staffRoleId = "-2";
            var annaService = "-1";

            for (var i = 0; i < rData.length; i++) {

                snCount = parseInt(snCount + 1);

                resultDetails += '<tr>' +
                          '<td>' + snCount + '</td>' +
                          '<td>' + rData[i].Datewise + '</td>' +
                        '<td><a id="regStudDateWise" data-toggle="modal" data-target="#RegStudent" style="color:#0073e6;"  rel="' + rData[i].Datewise + '~1" href="#">' + rData[i].studentRegUser + '</a></td>' +
                         '<td>' + rData[i].studentDownloadUser + '</td>' +
                          '<td>' + rData[i].studentUsageUser + '</td>' +
                          '<td><a id="regStafDateWise" data-toggle="modal" data-target="#RegStudent" style="color:#0073e6;"  rel="' + rData[i].Datewise + '~2" href="#">' + rData[i].staffRegUser + '</a></td>' +
                          '<td>' + rData[i].staffDownloadUser + '</td>' +
                          '<td>' + rData[i].staffUsageUser + '</td></tr>';


            }
            $('#tblMasterDateWise_3Months tbody').html(resultDetails);







            $('#tblMasterDateWise_3Months').DataTable({
                "bProcessing": true,
                "bDestroy": true,
                "deferRender": true,
                // "aoColumnDefs": [{ "bSortable": false, "aTargets": [0]}],
                "aaSorting": []

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

function RegisteredStudentDetailsForDate(roleId, strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester, Date_) {
 var snCount = 0;
    var res = "";
    var resMOU = '';
    var result = '';
    var urlwebs = '';
    var resultMOU = '';
    var resultDetails = '';

    if (year == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0) {

        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/DateRegisteredUsageDownloadDetails?roleId=' + roleId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&Date_on=' + Date_ + '&xmlOrJson=0';
    }
    else {
        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/DateRegisteredUsageDownloadDetails?roleId=' + roleId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&Date_on=' + Date_ + '&xmlOrJson=0';
    }
    $('#tblChild').DataTable().destroy();
    //.DataTable({
    //    "bProcessing": true,
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        crossOrigin: true,
        async: false,
        success: function (res) {
            var rData = res.DateRegisteredUsageDownloadDetailsResult;

            for (var i = 0; i < rData.length; i++) {

                snCount = parseInt(snCount + 1);

                resultDetails += '<tr>' +

                          '<td>  ' + snCount + '</td>' +
                          '<td> ' + rData[i].studentName + '</td>' +
                          '<td>' + rData[i].RegisteredOn + '</td>' +
                          '<td>' + rData[i].totalhrsUsage + ' </a></td>' +
                          '<td>' + rData[i].ReadSubject + ' </a></td>' +
                //'<td>' + rData[i].lastReadOn + '</td>' +
                          '<td>' + rData[i].totalUnits + '</td>' +
                          '<td>' + rData[i].unitsDownload + '</td>' +
                          '</tr>';


            }
            setTimeout(function () {
                $('#tblChild tbody').html(resultDetails);
                $('#tblChild').DataTable({
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "185px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false

                });
            }, 400);
        },
        error: function (result) {
            alert("Error");
        },
        complete: function () {
            $('.loader').hide();
        }
    });

}




function RegisteredStudentDetails(roleId, strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester) {

    var snCount = 0;
    var res = "";
    var resMOU = '';
    var result = '';
    var urlwebs = '';
    var resultMOU = '';
    var resultDetails = '';

    if (year == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0) {

        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/CollegeRegisteredUsageDownloadDetails?roleId=' + roleId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    else {
        urlwebs = $('#WebServiceUrl').val() + '/AdminService.svc/adminservice/CollegeRegisteredUsageDownloadDetails?roleId=' + roleId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }
    $('#tblChild').DataTable().destroy();
    //.DataTable({
    //    "bProcessing": true,
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        crossOrigin: true,
        async: false,
        success: function (res) {
            var rData = res.CollegeRegisteredUsageDownloadDetailsResult;

            for (var i = 0; i < rData.length; i++) {

                snCount = parseInt(snCount + 1);

                resultDetails += '<tr>' +

                          '<td>  ' + snCount + '</td>' +
                          '<td> ' + rData[i].studentName + '</td>' +
                          '<td>' + rData[i].RegisteredOn + '</td>' +
                          '<td>' + rData[i].totalhrsUsage + ' </a></td>' +
                          '<td>' + rData[i].ReadSubject + ' </a></td>' +
                //'<td>' + rData[i].lastReadOn + '</td>' +
                          '<td>' + rData[i].totalUnits + '</td>' +
                          '<td>' + rData[i].unitsDownload + '</td>' +
                          '</tr>';


            }
            setTimeout(function () {
                $('#tblChild tbody').html(resultDetails);
                $('#tblChild').DataTable({
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "185px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false

                });
            }, 400);
        },
        error: function (result) {
            alert("Error");
        },
        complete: function () {
            $('.loader').hide();
        }
    });

}


$(document).ready(function () {
    LoadUniversity();

    $("#startdate").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#EndDate").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#usageStart").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#usageEnd").datepicker({ dateFormat: 'dd-mm-yy' });

    $('#ddlunivId').multiselect({
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
    semester = 0;
    usg_Startdate = 0;
    usd_End_date = 0;

    showUnivData(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);
});
function clearpopup() {
    $('#ddlunivId').multiselect('deselectAll', false);
    $('#ddlunivId').multiselect('updateButtonText');
    $('#ddlsemster').multiselect('deselectAll', false);
    $('#ddlsemster').multiselect('updateButtonText');
    $('#ddlCollege').multiselect('deselectAll', false);
    $('#ddlCollege').multiselect('updateButtonText');

    $("#startdate").val('');
    $("#EndDate").val('');
    $("#usageStart").val('');
    $("#usageEnd").val('');
    $('#ddlUniversity').val('');

    startdate = 0;
    endDate = 0;
    strYear = 0;
}

$(function () {


    $('#btnApplyFilter').click(function () {

        var searchResult = "<b>Filtered Results For:  </b>";

        $('#tblMaster').DataTable().destroy();
        //.DataTable({
        //    "bDestroy": true
        //}).fnClearTable();
        $('#tblMasterDateWise').DataTable().destroy();
        //.DataTable({
        //    "bDestroy": true
        //}).fnClearTable();
        $('#tblMasterDateWise_3Months').DataTable().destroy();
        //.DataTable({
        //    "bDestroy": true
        //}).fnClearTable();


        year = $("#ddlunivId option:selected");
        var sem = $("#ddlsemster option:selected");
        var selectsem = '';
        sem.each(function () {
            selectsem = selectsem + $(this).val() + "-";
        });
        semester = selectsem.substring(0, selectsem.length - 1);
        univId = $('#ddlUniversity option:selected').val();
        college_Id = $("#ddlCollege option:selected");
        var selctCollege = '';
        college_Id.each(function () {
            selctCollege = selctCollege + $(this).val() + "-";
        });
        collegeId = selctCollege.substring(0, selctCollege.length - 1);

        startdate = $("#startdate").val();
        endDate = $("#EndDate").val();

        usg_Startdate = $("#usageStart").val();
        usd_End_date = $("#usageEnd").val();

        var selctyear = '';
        year.each(function () {
            selctyear = selctyear + $(this).val() + "-";
        });
        strYear = selctyear.substring(0, selctyear.length - 1);

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
        if (semester == '') {
            semester = 0;
        }
        else {
            searchResult += "  Semester:" + " " + "" + "<b>" + semester + "</b>";
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

        if (usg_Startdate == '') {
            usg_Startdate = 0;
        }
        else {
            searchResult += " </br></br> Usage Start date: <b>" + usg_Startdate + "</b>";
        }

        if (usd_End_date == '') {
            usd_End_date = 0;
        }
        else {
            searchResult += "  Usage End date: <b>" + usd_End_date + "</b>";
        }

        if (univId == '')
            univId = 0;

        showUnivData(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);
        $('#closepopup').trigger('click');


        //  if (strYear != 0 && startdate != 0 && endDate != 0 && univId != 0 && collegeId != 0 && usg_Startdate != 0 && usd_End_date != 0 && semester != 0) {
        //  showUnivData(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);
        //  $('#closepopup').trigger('click');
        //  }
        //   else {
        //   showUnivData(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);
        //   $('#closepopup').trigger('click');
        //   }

        $("#DynamicFilteredData").html(searchResult).css('font-weight', 'Medium');

        $('#tblMaster').DataTable().destroy();
        //.DataTable({
        //    "bProcessing": true,
        //    "bDestroy": true
        //}).fnClearTable();
    });

    $('#refreshFilter').click(function () {
        clearpopup();
        showUnivData(0, 0, 0, 0, 0, 0, 0, 0);

        startdate = 0;
        endDate = 0;
        strYear = 0;
        univId = 0;
        collegeId = 0;
        semester = 0;
        usg_Startdate = 0;
        usd_End_date = 0;

        $("#DynamicFilteredData").html('');
        $('#tblMaster').DataTable().destroy();
        //.DataTable({
        //    "bDestroy": true
        //}).fnClearTable();
    });
    $('#btnClearFilter').click(function () {
        clearpopup();
    });
    $(document).on('click', '#regClg', function () {

        RegisteredCollgeDetails(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);
        RegisteredUsageDateWise(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);
        RegisteredUsageDateWiseForlast3Months(strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester);

    });
    $(document).on('click', '#regStud', function (e) {
        e.preventDefault();
        $('#tblChild table tbody').html('Loading.Please wait...');
        var CollgeroleId = $(this).attr('rel');
        var roleId = CollgeroleId.split('-')[1];
        var ColgId = CollgeroleId.split('-')[0];
        var college_Name = $(this).parent().parent().find("#ColgName").text();
        $("#CollegeName").text("College Name : " + college_Name).css('font-weight', 'Bold');
        RegisteredStudentDetails(roleId, strYear, startdate, endDate, univId, ColgId, usg_Startdate, usd_End_date, semester);

    });

    $(document).on('click', '#regStaf', function (e) {
        e.preventDefault();
        $('#tblChild table tbody').html('Loading.Please wait...');
        var CollgeroleId = $(this).attr('rel');
        var roleId = CollgeroleId.split('-')[1];
        var ColgId = CollgeroleId.split('-')[0];
        var college_Name = $(this).parent().parent().find("#ColgName").text();
        $("#CollegeName").text("College Name : " + college_Name).css('font-weight', 'Bold');
        RegisteredStudentDetails(roleId, strYear, startdate, endDate, univId, ColgId, usg_Startdate, usd_End_date, semester);
    });

    $(document).on('click', '#regStudDateWise', function (e) {
        e.preventDefault();
        $('#tblChild table tbody').html('Loading.Please wait...');
        var DateroleId = $(this).attr('rel');
        var roleId = DateroleId.split('~')[1];
        var Date_ = DateroleId.split('~')[0];
       // var DateName = $(this).parent().parent().find("#ColgName").text();
        $("#CollegeName").text("DateOn : " + Date_).css('font-weight', 'Bold');
        RegisteredStudentDetailsForDate(roleId, strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester, Date_);
    });

    $(document).on('click', '#regStafDateWise', function (e) {
        e.preventDefault();
        $('#tblChild table tbody').html('Loading.Please wait...');
        var DateroleId = $(this).attr('rel');
        var roleId = DateroleId.split('~')[1];
        var Date_ = DateroleId.split('~')[0];
       // var DateName = $(this).parent().parent().find("#ColgName").text();
        $("#CollegeName").text("DateOn : " + Date_).css('font-weight', 'Bold');
        RegisteredStudentDetailsForDate(roleId, strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester, Date_);
    });
    $(document).on('click', '#regStudDateWise30', function (e) {
        e.preventDefault();
        $('#tblChild table tbody').html('Loading.Please wait...');
        var DateroleId = $(this).attr('rel');
        var roleId = DateroleId.split('~')[1];
        var Date_ = DateroleId.split('~')[0];
        // var DateName = $(this).parent().parent().find("#ColgName").text();
        $("#CollegeName").text("DateOn : " + Date_).css('font-weight', 'Bold');
        RegisteredStudentDetailsForDate(roleId, strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester, Date_);
    });

    $(document).on('click', '#regStafDateWise30', function (e) {
        e.preventDefault();
        $('#tblChild table tbody').html('Loading.Please wait...');
        var DateroleId = $(this).attr('rel');
        var roleId = DateroleId.split('~')[1];
        var Date_ = DateroleId.split('~')[0];
        // var DateName = $(this).parent().parent().find("#ColgName").text();
        $("#CollegeName").text("DateOn : " + Date_).css('font-weight', 'Bold');
        RegisteredStudentDetailsForDate(roleId, strYear, startdate, endDate, univId, collegeId, usg_Startdate, usd_End_date, semester, Date_);
    });
});










