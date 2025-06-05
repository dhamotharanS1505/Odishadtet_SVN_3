
var year = '';
var startdate = '';
var endDate = '';
var strYear = '';
var semester = '';
var univeristy_Id = '';
var university_Code = '';

function showUnivData() {   
    
    var snCount = 1;   
    var urlwebs = '/APIService/APIAdminReport/RegistrationReportsummaryTest';
    var resultDetails = '';  
   
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        async: false,
        success: function (data) {
          
            resultDetails += '<tr>'+
                        '<td>  </td>' +
                         '<td>' + snCount + '</td>' +
                        '<td>' + data.TotalITI + '</td>' +
                         '<td>' + data.TotalDesktop + ' </td>' +
                            //'<td>' + '<b>' + data.TotalInstructors + '</b>' + '</td>'+
                            '<tr>';
        },
        complete: function () {
            $('.loader').hide();
        }
    });
  
    $('#tblMasterMain tbody').html(resultDetails);

}


function showRegistrationUniversityHistory(universityId) {

    var unvId = universityId.split('-')[0];
    var roleId = universityId.split('-')[1];

    var weburls = '';

    if (year == 0 && semester == 0 && startdate == 0 && endDate == 0) {

        weburls = '/APIService/APIAdminReport/RegisteredUniversityCollegeDetailsTest?year=' + strYear + '&semester=' + semester + '&start_date=' + startdate + '&end_date=' + endDate + '&universityId=' + unvId + '&roleid=' + roleId;
    }
    else {

        weburls = '/APIService/APIAdminReport/RegisteredUniversityCollegeDetailsTest?year=' + strYear + '&semester=' + semester + '&start_date=' + startdate + '&end_date=' + endDate + '&universityId=' + unvId + '&roleid=' + roleId;

    }
    $('#tblChildUniv').DataTable({
        "bProcessing": true,
        "bDestroy": true
    }).fnClearTable();

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: weburls,
        dataType: 'json',
        success: function (response) {
            var rData = response;
            var table;
            var j = 0;
            for (var i = 0; i < rData.length; i++) {
                j = parseInt(j + 1);

                table +=
                           '<tr>' +
                           '<td>' + j + '</td>' +
                           '<td>' + rData[i].userName + '</td>' +
                           '<td>' + rData[i].CollegeName + '</td>' +
                            // '<td>' + rData[i].Emailid + '</td>' +
                            // '<td>' + rData[i].Mobile + '</td>' +
                           '<td>' + rData[i].RegisteredOn + '</td></tr>';
            }

            setTimeout(function () {
                $('#tblChildUniv tbody').html(table);
                $('#tblChildUniv').DataTable({
                    "bProcessing": true,
                    "bDestroy": true,
                    "deferRender": true,
                    "aLengthMenu": [[5, 15, 25, 50, 100, 200], [5, 15, 25, 50, 100, 200]],
                    "iDisplayLength": 5,
                    "sScrollY": "235px",
                    "scrollY": 200,
                    "scrollCollapse": true,
                    "bAutoWidth": false,
                    "paging": false
                });
            }, 50);
        },
        complete: function () {
            $('.loader').hide();
        }
    });
}

/*Function To Get Value From Another View.cshtml*/
/*start*/
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
/*End*/

$(document).ready(function () {    
   
    showUnivData();
    showDatachk();

});











