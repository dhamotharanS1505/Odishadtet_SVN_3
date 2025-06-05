
var year = '';
var startdate = '';
var endDate = '';
var strYear = '';
var semester = '';
var univeristy_Id = '';
var university_Code = '';

function showUnivData(CollegeGrpId, deptID, collegeID, DateFrom, DateTo, type) {   
    
    var snCount = 1;   
    var urlwebs = '/APIService/APICollegeGroupAdminDashBoardReports/RegistrationReportsummary?CollegeGrpId=' + CollegeGrpId +'&deptID=' + deptID + '&collegeID=' + collegeID + '&DateFrom=' + DateFrom + '&DateTo=' + DateTo + '&type=' + type;
    var resultDetails = '';  
   
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
            //$('.cnt-snd-ft-one-click').prop('disabled', true);
            //$('.cnt-snd-ft-two-click').prop('disabled', true);
        },
        type: 'GET',
        url: urlwebs,
        dataType: 'json',
        async: false,
        success: function (data) {
          
            resultDetails += '<tr>'+                        
                         '<td>' + snCount + '</td>' +
                        '<td style="text-align:left;padding-left:25px;">' + data.TotalITI + '</td>' +
                        '<td>' + data.TotalDesktop + ' </td>';
                    if (optionval == 2) {
                        resultDetails += '<td class="SelChoiceVal">' + '<b>' + data.TotalInstructors + '</b>' + '</td>';
                    }
                    resultDetails += '</tr>';
        },
        complete: function () {
            $('.loader').hide();
            //$('.cnt-snd-ft-one-click').prop('disabled', false);
            //$('.cnt-snd-ft-two-click').prop('disabled', false);
        }
    });
  
    $('#tblMasterMain tbody').html(resultDetails);

}


function showRegistrationUniversityHistory(universityId) {

    var unvId = universityId.split('-')[0];
    var roleId = universityId.split('-')[1];

    var weburls = '';

    if (year === 0 && semester === 0 && startdate === 0 && endDate === 0) {

        weburls = '/APIService/APICollegeGroupAdminDashBoardReports/RegisteredUniversityCollegeDetails?CollegeGrpId=' + CollegeGrpId +'&year=' + strYear + '&semester=' + semester + '&start_date=' + startdate + '&end_date=' + endDate + '&universityId=' + unvId + '&roleid=' + roleId;
    }
    else {

        weburls = '/APIService/APICollegeGroupAdminDashBoardReports/RegisteredUniversityCollegeDetails?CollegeGrpId=' + CollegeGrpId +'&year=' + strYear + '&semester=' + semester + '&start_date=' + startdate + '&end_date=' + endDate + '&universityId=' + unvId + '&roleid=' + roleId;

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
                           '<td style="text-align:left;padding-left:25px;">' + rData[i].userName + '</td>' +
                           '<td style="text-align:left;padding-left:25px;">' + rData[i].CollegeName + '</td>' +
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


    
   
  //  showUnivData(0, 0, '0', '0', 0);
  //  showDatachk(0, 0,'0','0',0);

});











