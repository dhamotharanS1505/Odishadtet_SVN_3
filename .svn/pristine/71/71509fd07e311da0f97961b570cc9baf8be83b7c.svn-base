var UnivId = '';
var UnivCode = '';
var userid = '';
var universtiyCode = '';
var urlweb = '';

function LoadUniversity() {

    $.ajax({
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/adminservice.svc/adminservice/UserUnitDetailsUniversitywithUnivCode?xmlOrJson=0',
        dataType: 'json',
        //crossOrigin: true,
        success: function (data) {
             
            var rData = data.UserUnitDetailsUniversitywithUnivCodeResult;
             
            var markup = "";
            markup = "<option value='0-00'>All</option>";


            for (var x = 0; x < rData.length; x++) {

                markup = markup + "<option value=" + rData[x].Universityid + ">" + rData[x].UniversityName + "</option>";

            }
         //   markup = markup + "<option value='1-VTU'>VTU</option>";
            $('#ddlUniversity').find('option').remove().end().append(markup);

        },
        error: function (result) {
            alert("Error");
        }
    });
}

function showData() {
    
    $('#tblRegIssues').DataTable({
        "bProcessing": true,
        "bDestroy": true
    }).fnClearTable();
    //if (UnivId == 0) {
    //    urlwebsAnna = $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    //    urlwebsVtu = $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    //}
    //else if (UnivId > 0 && UnivCode != 'VTU') {
    //    urlwebsAnna = $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    //}
    //else if (UnivId > 0 && UnivCode == 'VTU') {
    //    urlwebsVtu = $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    //}
    $.ajax({
        beforeSend: function() {
            $('.loader').show();
        },
        type: 'GET',
       // url:urlwebsAnna,
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?xmlOrJson=0',
        dataType: 'json',
       // crossOrigin: true,
        success: function(response) {
            var rData = JSON.parse(response.NotActivatedUsersResult);
            var Grid;
            var j = 0;
            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);
                var d = rData[i].userid;
                Grid += '<tr><td>' + j + '</td>' +
                        '<td id="UserName">' + rData[i].userName + '</td>' +
                        '<td>' + rData[i].userRole + '</td>' +
                        '<td>' + rData[i].mobileNumber + '</td>' +
                         '<td>' + rData[i].EmailId + '</td>' +
                        '<td>' + rData[i].collegename + '</td>' +
                        '<td>' + rData[i].registeredOn + '</td>' +
                        '<td>Verification Pending</td>' +
                        '<td><a class="btnDelete"  rel="' + d + '" data-toggle="modal" data-target="#UnitModel"  href="#">DeleteUser' + '</td></tr>';

            }


            $('#tblRegIssues tbody').html(Grid);
            $('#tblRegIssues').DataTable({
                "bProcessing": true,
                "deferRender": true,
                "bDestroy": true,
                "bStateSave": true

            });

        },

        complete: function() {
            $('.loader').hide();
        },
        error: function(result) {
            alert("Error");
        }
    });

}

function DeleteRegistrationIssue(userId, universtiyCode) {
    //if (universtiyCode == 'VTU') {
       
    //    urlweb = $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/GetNotActivatedUser?userId=' + userId + '&xmlOrJson=0';
    //}
    //else {
        urlweb = $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/GetNotActivatedUser?userId=' + userId + '&xmlOrJson=0';
   // }

    $.ajax({
        type: 'GET',
        url: urlweb,
        dataType: 'json',
      //  crossOrigin: true,
        success: function (response) {
            var rData = JSON.parse(response.GetNotActivatedUserResult);
            var res;
            for (var i = 0; i < rData.length; i++) {
                res +=
                                         '<tr><td> User Name : <br/></td><br/><td class="Text"><strong>' + rData[i].userName + '</strong></td></tr>' +
                                          '<tr><td> User Role  : <br/></td><td class="Text"><strong>' + rData[i].userRole + '</strong></td></tr>' +
                                         '<tr><td>Mobile Number : <br/></td><td class="Text"><strong>' + rData[i].mobileNumber + '</strong></td></tr>' +
                                         '<tr><td> Email-Id :  <br/></td><td class="Text"><strong>' + rData[i].EmailId + '</strong></td></tr>' +
                                         '<tr><td> University :  <br/></td><td class="Text"><strong>' + rData[i].univName + '</strong></td></tr>' +
                                         '<tr><td> College Name :  <br/></td><td class="Text"><strong>' + rData[i].collegename + '</strong></td></tr>' +
                                         '<tr><td> Registered On : </td><td class="Text"><strong>' + rData[i].registeredOn + '</strong></td></tr>' +
                                         '<tr><td colspan="12"  style="text-align: center;"><br><br><input  class="btndeletedia fil_in_btn"  type="Button" class="selected" rel="' + rData[i].userid + '"  value="Delete User" href="#" />' + '<br/><br/></td></tr>';
            }

            $('#tblUniit').html(res);

        }
    });

}



$(function () {
    $('#ddlUniversity').change(function () {
        UnivId = $("#ddlUniversity").find("option:selected").val().split('-')[0];
        UnivCode = $("#ddlUniversity").find("option:selected").val().split('-')[1];
        showDataInitial(UnivId, UnivCode)
    });
});

function showDataInitial(UnivId, UnivCode) {
    var GridAnna = '';
    var GridVtu = '';
    var result = '';
    var sno = 0;
    var urlwebsAnna = '';
    var urlwebsVtu = '';

    $('#tblRegIssues').DataTable({
        "bProcessing": true,
        "bDestroy": true
    }).fnClearTable();

    if (UnivId == 0) {
        urlwebsAnna = $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
        urlwebsVtu = $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    }
    else if (UnivId > 0 && UnivCode != 'VTU') {
        urlwebsAnna = $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    }
    else if (UnivId > 0 && UnivCode == 'VTU') {
        urlwebsVtu = $('#WebServiceUrlVtu').val() + '/AdminService.svc/Adminservice/NotActivatedUsers?univid=' + UnivId + '&xmlOrJson=0';
    }

    $.ajax({
        beforeSend: function() {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebsAnna,
        dataType: 'json',
      //  crossOrigin: true,
        success: function(response) {
            var rData = JSON.parse(response.NotActivatedUsersResult);
            for (var i = 0; i < rData.length; i++) {
                sno = parseInt(sno + 1);
                var d = rData[i].userid;
                GridAnna += '<tr><td>' + sno + '</td>' +
                        '<td id="UserName">' + rData[i].userName + '</td>' +
                        '<td>' + rData[i].userRole + '</td>' +
                        '<td>' + rData[i].mobileNumber + '</td>' +
                         '<td>' + rData[i].EmailId + '</td>' +
                        '<td>' + rData[i].collegename + '</td>' +
                        '<td>' + rData[i].registeredOn + '</td>' +
                        '<td>Verification Pending</td>' +
                        '<td><a class="btnDelete"  rel="' + d + '" data-toggle="modal" data-target="#UnitModel"  href="#">DeleteUser' + '</td></tr>';
            }
            $('#tblRegIssues tbody').html(GridAnna);
            $('#tblRegIssues').DataTable({
                "bProcessing": true,
                "deferRender": true,
                "bDestroy": true
            });
        },
        complete: function() {
            $('.loader').hide();
        }
    });
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: urlwebsVtu,
        dataType: 'json',
      //  crossOrigin: true,
        success: function (response) {
            var rData = JSON.parse(response.NotActivatedUsersResult);
            for (var i = 0; i < rData.length; i++) {
                sno = parseInt(sno + 1);
                var d = rData[i].userid;
                GridVtu += '<tr><td>' + sno + '</td>' +
                        '<td id="UserName">' + rData[i].userName + '</td>' +
                        '<td>' + rData[i].userRole + '</td>' +
                        '<td>' + rData[i].mobileNumber + '</td>' +
                         '<td>' + rData[i].EmailId + '</td>' +
                        '<td>' + rData[i].collegename + '</td>' +
                        '<td>' + rData[i].registeredOn + '</td>' +
                        '<td>Verification Pending</td>' +
                        //'<td><a id="btnDelete"  rel="' + rData[i].userid + '-' + rData[i].univCode + '" data-toggle="modal" data-target="#UnitModel"  href="#">DeleteUser' + '</td></tr>';
                        '<td><a class="btnDelete"  rel="' + d + '" data-toggle="modal" data-target="#UnitModel"  href="#">DeleteUser' + '</td></tr>';
            }
            $('#tblRegIssues tbody').html(GridVtu);
            $('#tblRegIssues').DataTable({
                "bProcessing": true,
                "deferRender": true,
                "bDestroy": true
            });
        },
        complete: function () {
            $('.loader').hide();
        }
    });



}

$(document).ready(function() {
    LoadUniversity();
   showDataInitial(0, '00');
    $(document).on('click', '[data-toggle="modal"]', function(e) {
        e.preventDefault();
        $('#SubjectUnit table tbody').html('Loading.Please wait...');
        var $this = $(this);
        var getuser = $(this).attr('rel');
        // userId = getuser.split('-')[0];
        universtiyCode = 0; // getuser.split('-')[1];
        $("#DynamicUnitName").html("<b> User Details </b> ");
        DeleteRegistrationIssue(getuser, universtiyCode);
    });

    $("#tblUniit").on('click', '.btndeletedia', function(e) {
        $('#tblRegIssues').DataTable({
            "bProcessing": true,
            "bDestroy": true
        });
        var deleteuser = $(this).attr('rel');
        userid = deleteuser; //.split('-')[0];
        //universtiyCode = deleteuser.split('-')[1];
        ShowAlert({
            title: "Delete Confirmation",
            text: "Are you sure? want to delete",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: true
        },
function(isConfirm) {
    if (isConfirm == true) {
       // if (universtiyCode == 'VTU') {
         //   urlweb = $('#WebServiceUrlVtu').val() + '/AdminService.svc/AdminService/DeleteUserRegistrationIssue?userId=' + userid;
       // }
       // else {
            urlweb = $('#WebServiceUrl').val() + '/AdminService.svc/AdminService/DeleteUserRegistrationIssue?userId=' + userid;
        //}
        $.ajax({
            type: 'GET',
            url: urlweb,
            dataType: 'json',
          //  crossOrigin: true,
            success: function(responce) {
                var rData = responce.DeleteUserRegistrationIssueResult;

                if (rData = 1) {
                    ShowAlert("Delete User", "User Deleted Successfully");
                    $('#ClosePopup').trigger('click');
                    showData();

                }
                else {
                    ShowAlert("Delete User", "There is No Data To Delete");
                }

            }

        });
    }
    else {

        return;
    }

});
    });

});
