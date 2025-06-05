$.ajax({ cache: false });

//var Appendurl = "/pharmawebservice";
var Appendurl = "";

clearInputValues = function (formName) {
    $('#' + formName + ' input[type=text]').val('');
    $('#' + formName + ' input[type=password]').val('');
    $('#' + formName + ' select').val(0);
    $('.modelErrorTxt').text('');
    $('.modelErrorTxt').hide();
    $('label.error').hide();
}

SendCode = function (userId, $this) {
    $.ajax({
        beforeSend: function () {
            if ($this.attr('id') == "btnReSend") {
                $this.text('Sending code...');
            }
        },
        url: $('#webUrl').val() + $('#SendVerificationCode').val() + '?userId=' + userId,
        type: 'get',
        success: function (Rdata) {

        },
        complete: function () {
            if ($this.attr('id') == "btnReSend") {
                $this.text('Resend Activation Code');
            }
        }
    });
}

function ReSendCode($this) {
    $.ajax({
        beforeSend: function () {

        },
        url: $('#webUrl').val() + '/studentservice.svc/studentservice/GetVerificationCode?MobNo=' + MobNo + '&userId=' + $('#regUserId').val() + '&emailID=' + emailID + '&xmlOrJson=0',
        type: 'get',
        success: function (Rdata) {
            var xmlData = $(Rdata).find("GetVerificationCodeResult").text();
            var rData = JSON.parse(xmlData);
            if (rData.length > 0) {
                successAlert('Success', 'OTP Password Resent successfully');
            }
        },
        complete: function () {

        }
    });
}

function RandomCodeVerification(UserID, VerifyCode, $this) {
    $('.modelErrorTxt').text('');
    $('.modelErrorTxt').hide();
    $.ajax({
        beforeSend: function () {
            $this.text('Processing...');
        },
        url: $('#webUrl').val() + '/studentservice.svc/studentservice/RandomCodeVerification1?userId=' + UserID + '&verifyCode=' + VerifyCode,
        type: 'get',
        success: function (Rdata) {
            var xmlData = $(Rdata).find("RandomCodeVerificationResult").text();
            var rData = JSON.parse(xmlData);

            if (rData == '1') {
                $this.text('Submit');
                $('#modelLogin').show();
                $('#modelAccountActivation').hide();
            }
            else {
                $('.modelErrorTxt').text(rData);
                $('.modelErrorTxt').show();
                $this.text('Submit');
                $('.txtOTPcode').val('');
            }
        }
    });
}






$(function () {
    $(document).on('click', '[data-toggle="modal"]', function (e) {
        e.preventDefault();
        clearInputValues('inline_content');
        $('#modelLogin').show();
        $('#modelForgetPassword, #modelPasswordReset, #modelAccountActivation, #modelactivateuser').hide();
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


    $(document).ready(function () {

        var forget = getUrlParameter('ForgetPass');
        if (forget == "1") {

            $("#ClickLoginProcess").get(0).click();

        }

        //check already login or not

        $.ajax({
            url: Appendurl +"/Student/CheckAlreadyLogined",
            type: 'post',
            async: false,
            success: function (Rdata) {
                //alert(Rdata.Valid);
                if (Rdata.Valid == true) {
                    var data = Rdata.ReturnUrl.split('~');
                    $('.modelErrorTxt').hide();
                    $("#sessionUserId").val(data[1]);
                    $("#loginUserName").text("Hi " + data[0]);
                    $(".stdSessionokLoginedUser").show();
                    $(".stdsignbutton").hide();
                    $(".registerbutton").hide();
                    $('#modal-login').modal('hide');
                }
                else {

                    return false;
                }

            },
            error: function () {
                ShowAlert("Error");
            }
        });



        //-------------------------Forget Password Start----------------------//

        $('#forStudentPassword').click(function (e) {
            e.preventDefault();
            clearInputValues('modelLogin');

            $('#modelForgetPassword').show();
            $('#modelLogin, #modelAccountActivation, #modelPasswordReset').hide();
        });


        $('.stdbacktologin, #forget_stdbacktoLogin, #ResetstdBacktoLogin, #OTPstdBacktoLogin').click(function (e) {
            e.preventDefault();
            $('#modelLogin').show();
            clearInputValues('modelLogin');
            clearInputValues('modelForgetPassword');
            clearInputValues('modelAccountActivation');
            clearInputValues('modelactivateuser');
            $('#modelAccountActivation, #modelForgetPassword, #modelPasswordReset,#modelactivateuser').hide();
        });

        $('.stdbacktologin_New').click(function (e) {
            e.preventDefault();
            $('#modelLoginNew').show();
            clearInputValues('modelLoginNew');
            clearInputValues('modelactivateuser_new');
            $('#modelactivateuser_new').hide();
        });


        $(document).on('click', '#btnstdForgetPassword', function (e) {
            $('.modelErrorTxt').text('');
            $('.modelErrorTxt').hide();
            e.preventDefault();
            $("#frmForgetPassword").validate({
                rules: {
                    mobileNo: {
                        required: true,
                        number: true,
                        maxlength: 10,
                        minlength: 10
                    }
                },
                messages: {
                    mobileNo: {
                        required: $('#PhoneNumberRequired').val(),
                        number: $('#PhoneNumberValidation').val(),
                        maxlength: $('#PhoneNumberLengthFailed').val(),
                        minlength: $('#PhoneNumberLengthFailed').val()
                    }
                }
            });

            if ($("#frmForgetPassword").valid()) {
                var $this = $(this);
                var prevText = $this.text();
                const mobileNo = $('#mobileNo').val();

                $.ajax({
                    beforeSend: function () {
                        $this.text('Processing...');
                    },
                    crossOrigin: true,
                    //url: $('#webUrl').val() + $('#ForgetPasswordUrl').val(),
                    //url: Appendurl + "/Student/ForgetPassword?MobileNumber=" + $('#mobileNo').val(),
                    url: Appendurl + "/Student/ForgetPassword",
                    data: JSON.stringify({ MobileNumber: mobileNo }),
                    contentType: 'application/json',
                    type: 'Post',
                    success: function (Rdata) {
                        //var userId = Rdata.userID;
                        
                        //if (userId > 0) {
                        ////var showModal = '@ViewBag.ShowModal'.toLowerCase() === 'true';
                        ////var showModal = '@ViewBag.ShowModal'.toLowerCase();
                        ////alert(showModal);
                        ////if (showModal) {
                        //    $('.modelErrorTxt').text(Rdata.message);
                        //    $('.modelErrorTxt').show();
                        //    $('#modelAccountActivation, #modelLogin, #modelForgetPassword, #modelactivateuser').hide();
                        //    $this.text(prevText);
                        //    $('#modelPasswordReset').show();
                        //}
                        //else {
                        //    $('.modelErrorTxt').text(Rdata.message);
                        //    $('.modelErrorTxt').show();
                        //    $this.text(prevText);
                        //}
                        ////alert(Rdata.message);
                        //ShowAlert("Forget password", "An OTP has been sent to the registered phone number if the user is present in our system.", "warning");
                        
                        $('.modelErrorTxt').text(Rdata.message).show();
                        $this.text(prevText);

                        //if (Rdata.Success) {
                      if (Rdata.Success === true && Rdata.code === 0) {

                            $('#modelAccountActivation, #modelLogin, #modelForgetPassword, #modelactivateuser').hide();
                            $('#modelPasswordReset').show();
                        }

                        ShowAlert("Forget password", Rdata.message, "warning");
                    },
                    error: function (Err) {
                        $('.modelErrorTxt').text("Internal Server Error");
                        $('.modelErrorTxt').show();
                        $this.text(prevText);
                    }
                });
            }

        });
        //-------------------------Forget Passwrod End -----------------------//

        //-------------------------Begin Reset Password------------------------//

        $('#btnstdResetPassword').click(function (e) {
            e.preventDefault();
            $('.modelErrorTxt').text('');
            $('.modelErrorTxt').hide();
            $("#frmResetPassword").validate({
                rules: {
                    otpCode: {
                        required: true,
                        number: true,
                        maxlength: 5,
                        minlength: 5
                    },
                    newPassword: {
                        required: true,
                        maxlength: 20
                    },
                    confirmPassword: {
                        required: true,
                        maxlength: 20,
                        equalTo: '#newPassword'
                    }
                },
                messages: {
                    otpCode: {
                        required: $('#OTPcodeRequired').val(),
                        number: $('#OTPCodeNumberValidation').val(),
                        maxlength: $('#OTPcodeLengthValidation').val(),
                        minlength: $('#OTPcodeLengthValidation').val()
                    },
                    newPassword: {
                        required: $('#NewPasswordRequired').val(),
                        maxlength: $('#PasswordLengthValidation').val()
                    },
                    confirmPassword: {
                        required: $('#ConfirmPasswordRequired').val(),
                        maxlength: $('#PasswordLengthValidation').val(),
                        equalTo: $('#PasswordMisMatch').val()
                    }

                }
            });

            if ($("#frmResetPassword").valid()) {
                var $this = $(this);
                $('#frmResetPassword input[name="mobileNo"]').val($('#frmForgetPassword input[name="mobileNo"]').val());
                var prevText = $this.text();
                var frmData = $('#frmResetPassword').serialize();

                var formData = {
                    mobileNo: $('#frmResetPassword input[name="mobileNo"]').val(),
                    otpCode: $('#otpCode').val(),
                    newPassword: $('#newPassword').val()
                };


                $.ajax({
                    beforeSend: function () {
                        $this.text('Processing...');
                    },
                    crossOrigin: true,
                    //url: Appendurl +"/Student/GetResetPasswords?mobileNo=" + $('#frmResetPassword input[name="mobileNo"]').val() + "&otpCode=" + $("#otpCode").val() + "&newPassword=" + $("#newPassword").val(),
                    url: Appendurl + "/Student/GetResetPasswords",
                    data: JSON.stringify(formData),
                    contentType: "application/json",
                    type: 'Post',
                    success: function (Rdata) {
                        var userId = Rdata.userID;
                        //if (userId > 0) {
                        //if (Rdata.Success) {
                        if (Rdata.Success === true && Rdata.code === 0) {
                            $('.modelErrorTxt').text(Rdata.message);
                            $('.modelErrorTxt').show();
                            $('#modelAccountActivation, #modelPasswordReset, #modelForgetPassword, #modelactivateuser').hide();
                            clearInputValues('myModal');
                            $('#modelLogin').show();
                            $this.text(prevText);
                            ShowAlert("ResetPassword", "Password changed successfully.", "success");
                            $('#otpCode').val('');
                            $('#newPassword').val('');
                            $('#confirmPassword').val('');
                        }

                        else {
                            $('.modelErrorTxt').text(Rdata.message);
                            $('.modelErrorTxt').show();
                            ShowAlert("ResetPassword", Rdata.message, "warning");
                            $this.text(prevText);
                        }
                    },
                    error: function (Err) {
                        $('.modelErrorTxt').text("Internal server error");
                        $('.modelErrorTxt').show();
                        $this.text(prevText);
                    }
                });
            }

        });


        //-------------------------End Reset Password -------------------------//

        //--------------------------New User Registration ---------------------//
        $('#newuser').click(function () {
            window.location.href = "/Student/StudentRegistration";
        });

        $('#newuserreg').click(function () {
            $('#modal-registeration').modal('show');
            $('#modal-login_new').modal('hide');
        });

        $('#userlogin').click(function () {
            $('#modal-registeration').modal('hide');
            $('#modal-login_new').modal('show');
        });

        //----------------------------Start Login ----------------------------//
        var phoneNumber = false;

        $("#frmLogin #loginID").blur(function () {

            var value = $("#frmLogin #loginID").val();
            var intRegex = /[0-9 -()+]+$/;
            if (intRegex.test(value)) {
                phoneNumber = true;
            }
            else {
                phoneNumber = false;
            }
        });

        $("#frmLogin #loginID").keyup(function () {
            var value = $("#frmLogin #loginID").val();
            var intRegex = /[0-9 -()+]+$/;
            if (intRegex.test(value)) {
                phoneNumber = true;
            }
            else {
                phoneNumber = false;
            }
        });
        $(document).on('click', '#btnStudentLogin', function (e) {
            e.preventDefault();
            //alert("hi");
            $('.modelErrorTxt').text('');
            $('.modelErrorTxt').hide();
            $("#frmLogin").validate({
                rules: {
                    loginID: {
                        required: true,
                        //  email: function () { if (phoneNumber == false) { return true; } },
                        number: function () { if (phoneNumber == true) { return true; } },
                        maxlength: function () { if (phoneNumber == true) { return 10; } else { return 50; } },
                        minlength: function () { if (phoneNumber == true) { return 10; } }
                    },
                    Password: {
                        required: true
                    }
                },


                messages: {
                    loginID: { required: "Enter your Email or Mobile number" },
                    Password: { required: "Enter the password" }
                }
            });
            if ($('#frmLogin').valid()) {
                var $this = $(this);   

                const encrypted = CryptoJS.AES.encrypt($('#Password').val(), "YourSecretKey123!").toString();
                alert(encrypted);
                var Mydata = {
                    FirstName: $('#loginID').val(),
                    Password: encrypted
                };

                //ajax start


                $.ajax({
                    beforeSend: function () {
                        $this.text('Processing...');
                    },                   
                    url: Appendurl +"/Student/CheckStudentLogininProcess",
                    //data: Mydata,
                    data: JSON.stringify(Mydata),
                    contentType: "application/json",
                    type: 'Post',
                    success: function (Rdata) {
                        if (( Rdata.role_type_code > 2) && Rdata.message == "")
                        {

                            $('.modelErrorTxt').hide();
                            $this.text('Redirecting..');
                            $("#sessionUserId").val(Rdata.userId);
                            $("#loginUserName").text("Hi " + Rdata.FirstName);
                            $(".stdSessionokLoginedUser").show();
                           
                            $(".stdsignbutton").hide();
                            $(".registerbutton").hide();
                            $('#modal-login').modal('hide');
                            $this.text('Login');
                            window.location.href = "/Student/Index";

                        }
                                             
                        else if (Rdata.message == "") {
                            $('.modelErrorTxt').hide();
                            $this.text('Redirecting..');
                            $("#sessionUserId").val(Rdata.userId);
                            $("#loginUserName").text("Hi " + Rdata.FirstName);
                            $(".stdSessionokLoginedUser").show(); //dashboard
                          
                            $(".stdsignbutton").hide();
                            $(".registerbutton").hide();
                            $('#modal-login').modal('hide');
                            $this.text('Login');
                          //  window.location.reload();
                            window.location.href = "/Student/Dashboard";
                        }
                        else {

                            if (Rdata.message == "Your Account is Not Activated. Please Activate Your Account") {

                                e.preventDefault();
                                $('#modelLogin').hide();
                                clearInputValues('modelLogin');
                                clearInputValues('modelForgetPassword');
                                clearInputValues('modelAccountActivation');
                                clearInputValues('modelactivateuser');
                                $('#modelAccountActivation, #modelForgetPassword, #modelPasswordReset').hide();
                                $this.text('Login');
                                $('.modelErrorTxt').text(Rdata.message);
                                $('.modelErrorTxt').show();
                                $('#modelactivateuser').show();

                                $('#sessionUserId').val(Rdata.userId);
                                $("#sessionMobileNumber").val(Rdata.mobileNumber);
                                $("#sessionEmailID").val(Rdata.emailId);

                                return false;

                            }
                            else {

                                $this.text('Login');
                                $('.modelErrorTxt').text(Rdata.message);
                                $('.modelErrorTxt').show();
                                return false;
                            }
                        }

                    },
                    error: function () {
                        ShowAlert("Error");
                    }
                });

                //ajax end

            }
        });

        //----------------------------End Login ----------------------------//

        //------------------- Resend OTP code if user not activated-------//
        $('#stdbtnresendotp').click(function () {
            var $this = $(this);
            $.ajax({
                //url: Appendurl +'/APIService/APIUserDashBoard/GetVerificationCodeByMobile?MobNo=' + $("#sessionMobileNumber").val() + '&emailID=' + $("#sessionEmailID").val(),
                url: Appendurl + '/Student/GetVerificationCodeByMobile?MobNo=' + $("#sessionMobileNumber").val() + '&emailID=' + $("#sessionEmailID").val(),
                type: 'GET',
                success: function (data) {
                    if (data == 1) {
                        ShowAlert("ONE TIME PASSWORD", "OTP has been sent to your Mobile Number", "success");
                    }
                },
                complete: function () {
                    $this.prop('disabled', true);
                }
            });
        });





        //-------------------Activate Code--------------------------------//

        $('#btnActivate').click(function (e) {
            e.preventDefault();
            var $this = $(this);
            var userId = $('#regUserId').val();
            RandomCodeVerification(userId, $('#txtPass').val(), $this);
        });

        $('#btnReSend').click(function (e) {
            e.preventDefault();
            var $this = $(this);
            SendCode($('#regUserId').val(), $this);
        });


        $('#Password').keypress(function (e) {
            var key = e.which;
            if (key == 13)  // the enter key code
            {
                $("#btnStudentLogin").trigger('click');
            }
        });
        //common activation for users
        $('#btnStdactivateaccount').click(function (e) {
            e.preventDefault();
            var $this = $(this);
            var userId = $('#sessionUserId').val();
            if ($("#mobileNootpverify").val().trim() == "") {
                ShowAlert("OTP Validation", "Please Enter OTP to Activate", "error");
            }
            else {
                $.ajax({
                    beforeSend: function () {
                        $this.text('Processing...');
                    },
                    crossOrigin: true,
                    url: Appendurl +"/Student/checkOTPisValid?userid=" + userId + "&OTP=" + $("#mobileNootpverify").val(),
                    type: 'Post',
                    success: function (Rdata) {
                        //  var userId = Rdata;
                        if (Rdata == 1) {
                            $('.modelErrorTxt').text(Rdata.message);
                            $('.modelErrorTxt').show();
                            $('#modelAccountActivation, #modelPasswordReset, #modelForgetPassword, #modelactivateuser').hide();
                            clearInputValues('modelactivateuser');
                            $('#modelactivateuser').hide();
                            $('#modelLogin').show();
                            $('#sessionUserId').val('');
                            $this.text('Activate');
                           // ShowAlert("OTP Validation", "Your Account is activated, Login Again to purchase the subjects", "success");
                            ShowAlert("OTP Validation", "Your Account is activated, Please Login Again", "success");
                        }

                        else {
                            $('.modelErrorTxt').text('please enter valid OTP');
                            $('.modelErrorTxt').show();
                            $this.text('Activate');
                        }
                    },
                    error: function (Err) {
                        $('.modelErrorTxt').text("Internal server error");
                        $('.modelErrorTxt').show();
                        $this.text('Activate');
                    }
                });
            }
        });

      
        // btnactivateaccount
        $('#btnstdLogout').click(function (e) {
            e.preventDefault();
            $.ajax({

                url: Appendurl +"/Student/Logout",
                type: 'Post',
                success: function (Rdata) {

                    if (Rdata == "") {
                        //window.location.href = Rdata.ReturnUrl;

                        $('.modelErrorTxt').hide();

                        $("#sessionUserId").val(0);
                        $("#loginUserName").text("Hi User");
                        $(".stdSessionokLoginedUser").hide();
                        $(".stdsignbutton").show();
                        $(".registerbutton").show();
                        window.location.href = "/Student/Index";
                        //get wishlist count
                        //get any cart added count
                    }


                },
                error: function () {
                    // ShowAlert("Error");
                }
            });

        });

        // btnactivateaccount
        $('#btnLogout1').click(function (e) {
            e.preventDefault();
            $.ajax({

                url: Appendurl +"/Student/Logout",
                type: 'Post',
                success: function (Rdata) {

                    if (Rdata == "") {
                        //window.location.href = Rdata.ReturnUrl;

                        $('.modelErrorTxt').hide();

                        $("#sessionUserId").val(0);
                        $("#loginUserName").text("Hi User");
                        $(".stdSessionokLoginedUser").hide();
                        $(".stdsignbutton").show();
                        $(".registerbutton").show();
                        window.location.href = "/Student/Index";
                        //get wishlist count
                        //get any cart added count
                    }


                },
                error: function () {
                    // ShowAlert("Error");
                }
            });

        });


        $('#Viewstudentprofile').click(function (e) {
            e.preventDefault();
            window.location.href = "/Student/ViewProfile";

        });

        

        //----------------------------Start Special offer Login New ----------------------------//
        var phoneNumber = false;
        

        //$('#btnstdForgetPassword').click(function (e) {
        //    e.preventDefault();
        //    if ($('#txtfogetpasswrd').val() != '' && $('#txtfogetpasswrd').val() != null) {
        //        $.ajax({
        //            type: "post",
        //            url: Appendurl +"/Student/ForgetPassword?MobileNumber=" + $('#txtfogetpasswrd').val(),
        //            datatype: "json",
        //            beforeSend: function () {
        //                $('#btnstdForgetPassword').parent().find('img:eq(0)').show();
        //            },
        //            success: function (rdata) {
        //                //alert(rdata.userID);
        //                if (rdata.userID > 0) {
        //                    ShowAlert("Forget password", rdata.message, "success");
        //                    $('.forget_password').hide();
        //                    $('.reset_pwd_new').show();
        //                    $('#txtfogetpasswrd').val('');
        //                    $('#mobileNo').val('');
        //                }
        //                else {
        //                    ShowAlert("Forget password", rdata.message, "error");
        //                }
        //            },
        //            complete: function () {
        //                $('#btnstdForgetPassword').parent().find('img:eq(0)').hide();
        //                frgtpwdmobile = $('#txtfogetpasswrd').val();


        //            }

        //        });
        //    }
        //    else {
        //        ShowAlert("Forget password", "An OTP has been sent to the registered phone number if the user is present in our system.", "warning");
        //    }
        //});
      
    });

    //----------------------------End Login ----------------------------//

});
//-----------------------End activate code --------------------//