var univId = "";
var univCode = "";



function showData(univId, strYear, semester, startdate, endDate) {
   
    var ServiceName = univId.split('~')[0];
    var ServiceResult = "";
    var AnnaService = $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&xmlOrJson=0';
    var Vtuservice = $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&univ_code='+ univCode +'&xmlOrJson=0';
    var NuService = $('#WebServiceUrl_NU').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&xmlOrJson=0';
    var KtuService = $('#WebServiceUrlKtu').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&xmlOrJson=0';

    if ( univId > 0 && univCode == 'NU') {
        ServiceResult = NuService;
      //  alert("nu"+ServiceResult);
    }
     else if ( univId > 0 && univCode == 'VTU') {
         ServiceResult = Vtuservice;
         //alert("vtu"+ServiceResult);
     }
     else if (univId > 0 && univCode == 'KTM') {
         ServiceResult = KtuService;
         //alert("vtu"+ServiceResult);
     }
    else {
        ServiceResult = AnnaService;
     //   alert(ServiceResult);
    }

//    $.ajax({
//        type: 'GET',
//      
//        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&xmlOrJson=0',
//        url: $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&xmlOrJson=0',
//        url: $('#WebServiceUrl_NU').val() + '/AdminService.svc/Adminservice/RegisteredUserCollegeDetails?year=' + strYear + '&semester=' + semester + '&start_Date=' + startdate + '&end_Date=' + endDate + '&universityId=' + univId + '&xmlOrJson=0',
//        dataType: 'json',
//        crossOrigin: true,

    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: ServiceResult,
        dataType: 'json',
        crossOrigin: true,
        success: function (response) {
            //var xmlData = $(response).find("GetAllReadHistroyResult").text();
           // var rData = JSON.parse(response.RegisteredUserCollegeDetailsResult);
           var rData = response.RegisteredUserCollegeDetailsResult;
            var res;
            var j = 0;

            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);

                res += '<tr><td>' + j + '</td>' +
                        '<td>' + rData[i].CollegeName + '</td>' +
                        '<td>' + rData[i].StudentCount + '</td></tr>';

            }

            $('#tblMaster tbody').html(res);
            $('#tblMaster').DataTable({
                "bProcessing": true,
                "bDestroy": true
            });


        },
        error: function (result) {
            alert("Error");
        }
   });
}


//passing parameter from one page to another page without using controller 
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
  
     univCode = getUrlParameter('UnivCode');
   // alert(univCode);
    univId = getUrlParameter('UnivID');
  //  alert(univId);

    showData(univId, 0, 0, 0, 0)


}); 