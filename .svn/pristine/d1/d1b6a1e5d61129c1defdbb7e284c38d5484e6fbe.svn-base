var UnAssignCollegeId = '';
var AssignCollegeId = '';
var AssignLength = '';
var UnAssignLength = '';


function Get() {
    $.ajax({
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/adminservice.svc/adminservice/LoadChannelPartnerName?xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,
        success: function (data) {
            var rData = data.LoadChannelPartnerNameResult;
            var markup = "<option  value=''>----- Select Channel Partner -----</option>";

            for (var x = 0; x < rData.length; x++) {

                markup = markup + "<option value=" + rData[x].bcustId + ">" + rData[x].bcustname + "</option>";
            }

            $('#UnivID').find('option').remove().end().append(markup);

        },
        error: function (result) {
            alert("Error");
        }
    });
}

$(function () {
    $('#UnivID').change(function () {
        var bcusid = $("#UnivID").find("option:selected").val();
        $.ajax({
            type: 'GET',
            url: $('#WebServiceUrl').val() + '/adminservice.svc/adminservice/LoadChannelPartnerTeam?bcustId=' + bcusid + '&xmlOrJson=0',
            dataType: 'json',
            crossOrigin: true,

            success: function (dd) {

                var rData1 = dd.LoadChannelPartnerTeamResult;

                var DepartementDetails = "<option  value=''>-- Select Channel Partner Team --</option>";

                for (var x = 0; x < rData1.length; x++) {
                    DepartementDetails = DepartementDetails + "<option value=" + rData1[x].TeamId + ">" + rData1[x].TeamName + "</option>";
                }

                $('#depId').find('option').remove().end().append(DepartementDetails);

            },
            error: function (result) {
                alert("Error");

            }
        });

    });
});

$(function () {
    $('#depId').change(function () {
        var bcusid = $("#UnivID").find("option:selected").val();
        var Teamid = $("#depId").find("option:selected").val();

        $.ajax({
            type: 'GET',
            url: $('#WebServiceUrl').val() + '/adminservice.svc/adminservice/LoadChannelPartnerUniversity?xmlOrJson=0',
            dataType: 'json',
            crossOrigin: true,

            success: function (dd) {

                var rData1 = dd.LoadChannelPartnerUniversityResult;

                var DepartementDetails = "<option  value=''>-------- Select University --------</option>";

                for (var x = 0; x < rData1.length; x++) {
                    DepartementDetails = DepartementDetails + "<option value=" + rData1[x].universityid + ">" + rData1[x].universityname + "</option>";
                }

                $('#subname').find('option').remove().end().append(DepartementDetails);

            },
            error: function (result) {
                alert("Error");

            }
        });

    });
});

function AssignGridLoad() {
    $('#tblfirst').DataTable({
        "bDestroy": true
    }).fnClearTable();

    var bcusid = $("#UnivID").find("option:selected").val();
    var Teamid = $("#depId").find("option:selected").val();
    var University = $("#subname").find("option:selected").val();

//    if ((bcusid == "") || (Teamid == "")) {
//        alert("Select Channel Partner and Team");
//        return false;
//    }


    $.ajax({

        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/ChannelPartnerAssignedCollege?bcustId=' + bcusid + '&univId=' + University + '&TeamId=' + Teamid + '&xmlOrJson=0',

        dataType: 'json',
        crossOrigin: true,
        success: function (response) {
            var rData = response.ChannelPartnerAssignedCollegeResult;
            var res = '';
            var j = 0;
            AssignLength = rData.length;
           // alert(AssignLength);
            for (var i = 0; i < rData.length; i++) {
                j = parseInt(j + 1);
                res += '<tr><td><input id="chkAssign"  class="All"  type="checkbox" class="chk" name="checkAll"  value = "' + rData[i].collegeid + '"   />' + '</td>' +
                        '<td>' + j + '</td>' +
                        '<td>' + rData[i].collegename + '</td></tr>';
            }

            $('#tblfirst tbody').html(res);
            $('#tblfirst').DataTable({
                "bProcessing": true,
                "bDestroy": true
            });

        },
        error: function (result) {
            alert("Error");
        }

    });
}

function UnAssignGridLoad() {
    $('#tblSecond').DataTable({
        "bDestroy": true
    }).fnClearTable();

    var bcusid = $("#UnivID").find("option:selected").val();
    var Teamid = $("#depId").find("option:selected").val();
    var University = $("#subname").find("option:selected").val();
//    if ((bcusid == "") || (Teamid == "") || (University == "")) {
//        alert("Select Channel Partner and Team and University");
//        return false;
//    }


    $.ajax({

        type: 'GET',

        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/ChannelPartnerUnassignedCollege?univId=' + University + '&xmlOrJson=0',
        dataType: 'json',
        crossOrigin: true,
        success: function (response) {
            var rData = JSON.parse(response.ChannelPartnerUnassignedCollegeResult);
            //   var rData = response.ChannelPartnerUnassignedCollegeResult;
            var res = '';
            var j = 0;
            UnAssignLength = rData.length;
            for (var i = 0; i < rData.length; i++) {

                j = parseInt(j + 1);
                res += '<tr><td><input id="chkUnAssign"  class="notall"  type="checkbox" class="chk" name="checkAll"   value = "' + rData[i].college_id + '"  />' + '</td>' +
                        '<td>' + j + '</td>' +
                        '<td>' + rData[i].college_name + '</td></tr>';
                      
            }
           
            $('#tblSecond tbody').html(res);
            $('#tblSecond').DataTable({
                "bProcessing": true,
                "bDestroy": true
            });

        },
        error: function (result) {
            alert("Error");
        }

    });
}

$('#btnUserunAssignGrid').click(function () {
    var bcusid = $("#UnivID").find("option:selected").val();
    var Teamid = $("#depId").find("option:selected").val();
    var University = $("#subname").find("option:selected").val();
    if ((bcusid == "") || (Teamid == "") || (University == "")) {
        alert("Select Channel Partner and Team and University");

    }
    else {
        AssignGridLoad();
        UnAssignGridLoad();
    }
});

$('#btnUserunAssgin').click(function (bcustId, collegeId, TeamId) {

    var bcusid = $("#UnivID").find("option:selected").val();
    var Teamid = $("#depId").find("option:selected").val();
    var Teamid = $("#depId").find("option:selected").val();
    var CookiesUserId = $('#cookieUserId').val();
    alert(CookiesUserId);
    $.ajax({
        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/makeChannelPartnerAssignedCollege?bcustId=' + bcusid + '&collegeId=' + UnAssignCollegeId + '&TeamId=' + Teamid + '&CookiesUserId=' + CookiesUserId,
        crossOrigin: true,
        success: function (response) {
            var rData = response.makeChannelPartnerAssignedCollegeResult;
            if (rData != 0) {
                alert(rData);
                AssignGridLoad();
                UnAssignGridLoad();
            }
            else {
                return false;
            }
        }
    });
});

$('#btnUserAssign').click(function (bcustId, collegeId) {
    var bcusid = $("#UnivID").find("option:selected").val();
    var Teamid = $("#depId").find("option:selected").val();
    var University = $("#subname").find("option:selected").val();
    
    $.ajax({

        type: 'GET',
        url: $('#WebServiceUrl').val() + '/AdminService.svc/Adminservice/makeChannelPartnerUnassignedCollege?bcustId=' + bcusid + '&collegeId=' + AssignCollegeId,
        crossOrigin: true,
        success: function (response) {
            var rData = response.makeChannelPartnerUnassignedCollegeResult;
          
                alert(rData);
                AssignGridLoad();
                UnAssignGridLoad();
            
        }
    });
});

function CookieUserid() {
    $.ajax({
        url: $('#webUrl').val() + '/Adminservice.svc/Adminservice/GetUserProfileImage?UserID=' + $('#cookieUserId').val(),
        type: 'get',
        async: false,

        success: function (response) {
            var rData = JSON.parse(response.GetUserProfileImageResult);
            var CookiesUserId = $('#cookieUserId').val();
            //            alert(CookiesUserId);
//            d = new Date();
//            $("#MainProfilePic").attr("src", $("#UserImageHidden").val() + rData.ProfileImage + "?" + d.getTime());
//            $("#UserProfileCroppedImg").attr("src", $("#UserImageHidden").val() + rData.ProfileImage + "?" + d.getTime());
            // alert(CookiesUserId);
        }
    });
}



$(document).ready(function () {
    Get();
    $('#btnUserAssign').hide();
    $('#btnUserunAssgin').hide();
   
    $('#btnChannelPartnerCollege').click(function () {

        var bcusid = $("#UnivID").find("option:selected").val();
        var Teamid = $("#depId").find("option:selected").val();
        var University = $("#subname").find("option:selected").val();
        if ((bcusid == "") || (Teamid == "") || (University == "")) {
            alert("Select Channel Partner and Team and University");
        }
        else {
            window.location.href = '/Admin/ChannelPartnerCollege?bcusid=' + bcusid + '&Teamid=' + Teamid + '&University=' + University + '&xmlOrJson=1';
        }

    });

    $('#btnChannelPartnerUnCollege').click(function () {
        var bcusid = $("#UnivID").find("option:selected").val();
        var Teamid = $("#depId").find("option:selected").val();
        var University = $("#subname").find("option:selected").val();

        if ((bcusid == "") || (Teamid == "") || (University == "")) {
            alert("Select  University");
        }
        else {
            alert(1);
            window.location.href = "/Admin/ChannelPartnerReportForUnAssignedCollege?University=" + University;
        }


    });

    $("#selectall").change(function () {
        if (AssignLength > 0) {

            $('#btnUserAssign').show();
            $(".All").prop('checked', $(this).prop("checked"));
            AssignCollegeId = $(".All:checked").map(function () {
                return this.value;
            }).get();
        }
        else {
            return false;
        }
        //  alert(AssignCollegeId);
    });

    $(document).on('click', '.All', function () {
        $('#btnUserAssign').show();
        //$(".All").prop('checked', $(this).prop("checked"));
        AssignCollegeId = $(".All:checked").map(function () {
            return this.value;
        }).get();

        //  alert(AssignCollegeId);

    });


    $("#UnAssignselecctall").change(function () {
        if (UnAssignLength > 0) {
            $('#btnUserunAssgin').show();
            $(".notall").prop('checked', $(this).prop("checked"));
            UnAssignCollegeId = $(".notall:checked").map(function () {
                return this.value;
            }).get();
        }
        else {
            return false;
        }

        // alert(UnAssignCollegeId);
    });


    $(document).on('click', '.notall', function () {

        $('#btnUserunAssgin').show();
        // $(".notall").prop('checked', $(this).prop("checked"));
        UnAssignCollegeId = $(".notall:checked").map(function () {
            return this.value;
        }).get();

        //alert(UnAssignCollegeId);

    });



    //      cookieUserIdUserMaster = Convert.ToInt32(Request.Cookies[@Resources.RoutingService.UserCookieName]["id"]);
    //      alert(cookieUserIdUserMaster);
});


