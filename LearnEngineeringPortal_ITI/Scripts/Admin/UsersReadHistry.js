

var year = '';
var startdate = '';
var endDate = '';
var usg_Startdate = '';
var usd_End_date = '';
var strYear = '';
var semester = '';
var univId = '';
var collegeId = '';
var univCode = '';
var urlwebs = '';
var urlwebsNu = '';
var urlwebsVtu = '';

function getWeeklyWiseReport(univId, collegeId, semester, strYear, startdate, endDate, usg_Startdate, usd_End_date) {

    if (strYear == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0 && semester == 0) {

        urlwebs = '/APIService/APIAdminReport/weeklywiseReport?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }

    else {
        urlwebs = '/APIService/APIAdminReport/weeklywiseReport?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date + '&xmlOrJson=0';
    }


    $.ajax({
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        success: function (data) {
            var res;
            var sno = 0;
            var rData = data;

            for (var i = 0; i < rData.length; i++) {

                sno = parseInt(sno + 1);

                if (parseInt(sno) != parseInt(rData.length)) {
                    res += '<tr><td>' + sno + '</td>' +
                        //'<td>' + rData[i].univName + '</td>' +
                        '<td>' + rData[i].month + '</td>' +
                        '<td>' + rData[i].week1 + '</td>' +
                        '<td>' + rData[i].week2 + '</td>' +
                        '<td>' + rData[i].week3 + '</td>' +
                        '<td>' + rData[i].week4 + '</td>' +
                        '<td><b>' + rData[i].totalhrs + '</b></td></tr>';
                }
                else {
                    res += '<tr><td colspan=5></td>' +
                        '<td><b>Total Hrs</b></td>' +
                        //  '<td><b>' + rData[i].month + '</b></td>' +
                        //  '<td><b>' + rData[i].week1 + '</b></td>' +
                        //  '<td><b>' + rData[i].week2 + '</b></td>' +
                        //  '<td><b>' + rData[i].week3 + '</b></td>' +
                        //  '<td><b>' + rData[i].week4 + '</b></td>' +
                        '<td><b>' + rData[i].totalhrs + '</b></td></tr>';
                }

            }
            $('#tblWeeklyWise tbody').html(res);

        }
    });
}
function showData(univId, collegeId, semester, strYear, startdate, endDate, usg_Startdate, usd_End_date) {

    $('#tblReadHistry').DataTable().destroy();
    //.DataTable({
    //    "bDestroy": true
    //}).fnClearTable();

    if (strYear == 0 && startdate == 0 && endDate == 0 && univId == 0 && collegeId == 0 && usg_Startdate == 0 && usd_End_date == 0 && semester == 0) {
        urlwebs = '/APIService/APIAdminReport/UniversityReadHistory?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date;
    }
    else {
        urlwebs = '/APIService/APIAdminReport/UniversityReadHistory?univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date;
    }


    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        success: function (rData) {
            var res;
            var sno = 0;
            var data = rData;

            for (var i = 0; i < data.length; i++) {

                sno = parseInt(sno + 1);

                res += '<tr><td>' + sno + '</td>' +
                        '<td id="UserName" style="text-align:left;padding-left:15px;">' + data[i].userName + '</td>' +
                        '<td style="text-align:left;padding-left:15px;">' + data[i].collegeName + '</td>' +
                        '<td>' + data[i].totalhrs + '</td>' +
                        '<td><a id="subjCnt" data-toggle="modal" data-target="#usrReadHsty" rel="' + data[i].userId + '" href="#">' + data[i].TradeCount + '</a></td>' +
                        '<td>' + data[i].lastReadOn + '</td>' +
                         '<td>' + data[i].Mobile + '</td>' +
                          '<td>' + data[i].RegisteredOn + '</td>' +

                       '</tr>';

            }
            $('#tblReadHistry tbody').html(res);
            setTimeout(function () {


                /*hari-start*/
                jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                    "num-html-pre": function (a) {
                        var x = String(a).replace(/<[\s\S]*?>/g, "");
                        return parseFloat(x);
                    },

                    "num-html-asc": function (a, b) {
                        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                    },

                    "num-html-desc": function (a, b) {
                        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                    }
                });


                jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                    "date-uk-pre": function (a) {
                        if (a == null || a == "") {
                            return 0;
                        }
                        var ukDatea = a.split('/');
                        return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
                    },

                    "date-uk-asc": function (a, b) {
                        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                    },

                    "date-uk-desc": function (a, b) {
                        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                    }
                });


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
                /*End*/
                $('#tblReadHistry').DataTable({
                    "bProcessing": true,
                    "bDestroy": true,
                    "aLengthMenu": [[10, 25, 50, 100, 500, 1000, 5000, 10000], [10, 25, 50, 100, 500, 1000, 5000, 10000]],
                    "deferRender": true,
                    "aoColumnDefs": [{ "sType": "num-html", "aTargets": [5, 6] }, { "sType": "date-dd-mmm-yyyy", "aTargets": [7] }],
                    "order": [[0, 'asc']]

                });
            }, 100);

        },
        complete: function () {
            $('.loader').hide();
        }
    });

}
function getUserSubjectDetails(userId, deptID) {

    var k = 0;

    if (strYear == '') {
        strYear = 0;
    }

    if (semester == '') {
        semester = 0;
    }


    if (startdate == '') {
        startdate = 0;
    }


    if (endDate == '') {
        endDate = 0;
    }


    if (collegeId == '') {
        collegeId = 0;
    }

    if (usg_Startdate == '') {
        usg_Startdate = 0;
    }


    if (usd_End_date == '') {
        usd_End_date = 0;
    }


    if (univId == '') {
        univId = 0;
    }

    $('#tblUsrSubject').DataTable().destroy();
    //.DataTable({
    //    "bDestroy": true
    //}).fnClearTable();

    var urlreadhitory = '';
    if (deptID == "0") {
        urlreadhitory = '/APIService/APIAdminReport/GetUserReadHistory?userID=' + userId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date;
    }
    else {
        urlreadhitory = '/APIService/APIAdminReport/GetUserUsageReadHistory?userID=' + userId + '&univId=' + univId + '&college_id=' + collegeId + '&deptid=' + deptID + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date;
    }

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlreadhitory,
        dataType: 'json',
        crossOrigin: true,


        success: function (data) {
            var res;
            var sno = 0;
            var rData = data;
            for (var i = 0; i < rData.length; i++) {

                sno = parseInt(sno + 1);

                res += '<tr><td>' + sno + '</td>' +
                        '<td style="text-align:left;padding-left:15px;">' + rData[i].departmentName + '</td>' +
                        '<td style="text-align:left;padding-left:15px;">' + rData[i].subjectName + '</td>' +
                        //'<td>' + rData[i].Semester + '</td>' +
                         '<td>' + rData[i].totalhrs + '</td>' +
                        '<td>' + rData[i].lastReadOn + '</td>' +
                       '</tr>';

            }
            setTimeout(function () {
                $('#tblUsrSubject tbody').html(res);
                $('#tblUsrSubject').DataTable({
                    "bProcessing": true,
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[10, 15, 25, 50, 100, 200], [10, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 10,
                    "scrollY": 200,
                    "sScrollY": "235px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "paging": false,
                    "order": [[0, 'asc']],


                });
            }, 200);


        },
        complete: function () {
            $('.loader').hide();
        }
    });
}


function getSubjectwiseHistory(userId) {
    var M = 0;
    if (strYear == '') {
        strYear = 0;
    }

    if (semester == '') {
        semester = 0;
    }

    if (startdate == '') {
        startdate = 0;
    }

    if (endDate == '') {
        endDate = 0;
    }

    if (collegeId == '') {
        collegeId = 0;
    }

    if (usg_Startdate == '') {
        usg_Startdate = 0;
    }

    if (usd_End_date == '') {
        usd_End_date = 0;
    }
    if (univId == '') {
        univId = 0;
    }

    $('#tblUsrSubject').DataTable().destroy();
    //.DataTable({
    //    "bDestroy": true
    //}).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: '/APIService/APIAdminReport/subjectwiseReadHistory?userID=' + userId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date,
        dataType: 'json',
        crossOrigin: true,

        success: function (data) {

            var res;
            var sno = 0;
            var rData = data;
            for (var i = 0; i < rData.length; i++) {

                sno = parseInt(sno + 1);

                res += '<tr><td>' + sno + '</td>' +
                        '<td style="text-align:left;padding-left:15px;">' + rData[i].subjectName + '</td>' +
                        '<td>' + rData[i].lastReadOn + '</td>' +
                        '<td>' + rData[i].totalhrs + '</td></tr>';
            }
            setTimeout(function () {
                $('#tblUsrSubject tbody').html(res);
                $('#tblUsrSubject').DataTable({
                    "bProcessing": true,
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[10, 15, 25, 50, 100, 200], [10, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 10,
                    "scrollY": 200,
                    "sScrollY": "235px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "bProcessing": true,
                    "paging": false,
                    "order": [[0, 'asc']],
                });
            }, 200);
        },
        complete: function () {
            $('.loader').hide();
        }
    });
}

function getTotalSubjectReadHours(userId, deptID) {

    var k = 0;

    if (strYear == '') {
        strYear = 0;
    }

    if (semester == '') {
        semester = 0;
    }


    if (startdate == '') {
        startdate = 0;
    }


    if (endDate == '') {
        endDate = 0;
    }


    if (collegeId == '') {
        collegeId = 0;
    }

    if (usg_Startdate == '') {
        usg_Startdate = 0;
    }


    if (usd_End_date == '') {
        usd_End_date = 0;
    }


    if (univId == '') {
        univId = 0;
    }

    $('#tblTotalhrsHistry').DataTable().destroy();
    //.DataTable({
    //    "bDestroy": true
    //}).fnClearTable();

    var urlreadhitory = '';
    if (deptID == "0") {
        urlreadhitory = '/APIService/APIAdminReport/GetUserTotalHrsReadHistory?userID=' + userId + '&univId=' + univId + '&college_id=' + collegeId + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date;
    }
    else {
        urlreadhitory = '/APIService/APIAdminReport/GetTotalHoursUsageReadHistory?userID=' + userId + '&univId=' + univId + '&college_id=' + collegeId + '&deptid=' + deptID + '&semester=' + semester + '&year=' + strYear + '&reg_startdate=' + startdate + '&reg_end_date=' + endDate + '&usg_start_date=' + usg_Startdate + '&usg_end_date=' + usd_End_date;
    }

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlreadhitory,
        dataType: 'json',
        crossOrigin: true,


        success: function (data) {
            var res;
            var sno = 0;
            var rData = data;
            for (var i = 0; i < rData.length; i++) {

                sno = parseInt(sno + 1);

                res += '<tr><td>' + sno + '</td>' +
                        '<td style="text-align:left;padding-left:15px;">' + rData[i].departmentName + '</td>' +
                        '<td style="text-align:left;padding-left:15px;">' + rData[i].subjectName + '</td>' +
                        '<td>' + rData[i].Semester + '</td>' +
                         '<td>' + rData[i].totalhrs + '</td>' +
                        '<td>' + rData[i].lastReadOn + '</td>' +
                       '</tr>';

            }
            setTimeout(function () {
                $('#tblTotalhrsHistry tbody').html(res);
                $('#tblTotalhrsHistry').DataTable({
                    "bProcessing": true,
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[10, 15, 25, 50, 100, 200], [10, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "scrollY": 200,
                    "sScrollY": "235px",
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "paging": false

                });
            }, 200);


        },
        complete: function () {
            $('.loader').hide();
        }
    });
}




$(document).ready(function () {
    if (getUrlParameter('UnivID') != null) {
        univId = getUrlParameter('UnivID');
        univCode = getUrlParameter('UnivCode');
    }

});

$(function () {
    $(document).on('click', '[data-toggle="modal"]', function (e) {
        e.preventDefault();
        userId = $(this).attr('rel');
        var deptId = $("#TradeName").val();
        var userName = $(this).parent().parent().find("#UserName").text();
        $("#UserrName").text("User Name : " + userName).css('font-weight', 'Bold');
        $("#usedHrsName").text("Name : " + userName).css('font-weight', 'Bold');

        if ($.trim($(this).attr('id')) == "subjCnt") {
            getUserSubjectDetails(userId, deptId);
        }
        else if ($.trim($(this).attr('id')) == "subjwise") {
            getSubjectwiseHistory(userId);
        }
        else if ($.trim($(this).attr('id')) == "totalhrs") {
            getTotalSubjectReadHours(userId, deptId);
        }
    });
});
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

