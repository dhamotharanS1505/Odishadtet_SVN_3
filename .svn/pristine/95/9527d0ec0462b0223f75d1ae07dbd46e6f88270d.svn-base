var SubscribedCountry = "";
var SubscribedRegion = "";
var SubscribedCity = "";
var SubscribedIP = "";





$(document).ready(function () {


    //livedatavalue

   
    //end by hari
    $.get("http://ipinfo.io", function (location) {
      
        SubscribedCity = location.city;
        SubscribedRegion = location.region;
        SubscribedCountry = location.country;
        SubscribedIP=location.ip;
     
    }, "jsonp");



    $("#SubMobNumber").keydown(function(e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A, Command+A
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
    
   

    


});

jQuery.fn.ForceNumericOnly =
function() {
    return this.each(function() {
        $(this).keydown(function(e) {
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
            return (
                key == 8 ||
                key == 9 ||
                key == 13 ||
                key == 46 ||
                key == 110 ||
                key == 190 ||
                (key >= 35 && key <= 40) ||
                (key >= 48 && key <= 57) ||
                (key >= 96 && key <= 105));
        });
    });
};

function validateEmail(sEmail) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (filter.test(sEmail)) {
        return true;
    }
    else {
        return false;
    }
}

$(function() {
    $(document).on('click', '#btnSubscribnew', function(e) {
        //    $('#btnSubscribnew').click(function (e) {
        e.preventDefault();

        var nam = $('#Sname').val();
        var coll = $('#Scollege').val();
        var sEmail = $('#SubEmailID').val();

        if ($.trim(sEmail).length == 0) {
            ShowAlert("Subscribe Validation", "Please enter valid email address", "error");
        }
        else {
            if (validateEmail(sEmail)) {
                // second validate Mobile number
                var myLength = $("#SubMobNumber").val().length;
                //alert($("#SubMobNumber").intlTelInput('isValidNumber'));


                //  if (parseInt(myLength) <= parseInt(15)) {
                //    ShowAlert("Subscribe Validation", "Please Enter Valid Mobile Number", "error");
                //  }
                if ($("#SubMobNumber").intlTelInput('isValidNumber') == false) {
                    ShowAlert("Subscribe Validation", "Please Enter Valid Mobile Number", "error");
                }
                else {

                    $("#element").LoadingOverlay("show");

                    $.ajax({
                        type: 'GET',
                        url: "http://learnengg.com/webservice/StudentService.svc/StudentService/SaveSubscriberUser?MailID=" + sEmail + '&mobilenum=' + $("#SubMobNumber").val() + '&Name=' + nam + '&college=' + coll + '&IPadd=' + SubscribedIP + '&country=' + SubscribedCountry + '&region=' + SubscribedRegion + '&city=' + SubscribedCity,
                        dataType: 'json',
                        crossOrigin: true,
                        success: function(data) {

                            var rData = data.SaveSubscriberUserResult;
                            $("#element").LoadingOverlay("hide", true);
                            ClearSub();
                            ShowAlert("Subscribe Validation", rData, "success");


                        },
                        error: function(result) {
                            $("#element").LoadingOverlay("hide", true);
                            alert("Error");
                        }
                    });

                }

            }
            else {
                ShowAlert("Subscribe Validation", "Invalid Email Address", "error");
            }
        }

    });
});



function ClearSub() {
    $("#SubMobNumber").val('');
    $("#Sname").val('');
    $("#Scollege").val('');
    $("#SubEmailID").val('');
    }




