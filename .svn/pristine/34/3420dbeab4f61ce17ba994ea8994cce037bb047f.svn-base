var MobNo;
var emailID;


function validatePhone(MobileNumber) {
    var filter = /^[7-9]{1}[0-9]{9}$/;
    if (filter.test(MobileNumber)) {
        return true;
    }
    else {
        return false;
    }
}



function isValidEmailAddress(emailAddress) {
    var mailformat = (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/);

    if (mailformat.test(emailAddress)) {
        return true;
    }
    else {
        return false;
    }
}


function UserFeedback($this) {
    emailID = $.trim($('#txtEmailid').val());
    MobNo = $('#txtMobile').val();
    var param = "collegeName=" + $('input[name=txtCollegeName]').val() + "&subjectName=" + $('input[name=txtSubjectName]').val() + "&userName=" + $('input[name=txtUserName]').val() + "&mobileNumber=" + $('input[name=txtMobile]').val() + "&emailId=" + $('input[name=txtEmailid]').val() + "&message=" + $('textarea[name=txtMessage]').val();
    $.ajax({
        beforeSend: function () {
         //   $this.val('Processing...');
            $('.loader').show();
            $('input:submit').attr("disabled", true);
        },
        crossOrigin: true,
        url: $('#frmContactUs').attr('action'),
        //url: $('#webUrl').val() + '/studentservice.svc/studentservice/FeedbackMail?collegeName=' + collegeName + '&subjectName=' + subjectName + '&userName=' + userName + '&mobileNumber=' + mobileNumber + '&emailId=' + emailId + '&message=' + message, 
        type: 'GET',
        data: param,
        datatype: 'json',
        success: function (Rdata) {
            sweetAlert("Contact Us", 'Your feedback has been sent to support team, We will contact you soon...');
            clear();
        },
        complete: function () {
           // $this.val('Submit');

            $('input:submit').attr("disabled", false);
            $('.loader').hide();
 
        }


    });
}



$(document).ready(function () {



    $('#btnSubmit').click(function (e) {
      
        var $this = $(this);
        e.preventDefault();
        $("#frmContactUs").validate({

            onfocusout: false,
            keypress: false,
            //           errorElement: "span",
            //           errorContainer: $('#errorContainer'),
            //    errorLabelContainer: $('#errorContainer ul'),
            //    wrapper: 'li',

            rules: {
                txtMobile: {
                    required: true,
                    number: true,
                    maxlength: 10,
                    minlength: 10
                },
                txtSubjectName: {
                    required: true
                },
                txtUserName: {
                    required: true
                },
                txtCollegeName: {
                    required: true
                },
                txtEmailid: {
                    required: true,
                    email: true
                },
                txtMessage: {
                    required: true
                }
            },
            messages: {
                txtMobile: {
                    required: 'Please enter your mobile number',
                    number: 'Please enter a valid mobile number',
                    maxlength: 'Mobile number accepts 10 digits only',
                    minlength: 'Mobile number accepts 10 digits only'
                },
                txtSubjectName: {
                    required: 'Please enter Your subject name'
                },
                txtUserName: {
                    required: 'Please enter your name'
                },
                txtCollegeName: {
                    required: 'Please enter your college name'
                },
                txtEmailid: {
                    required: 'Please enter your Email-ID'
                },
                txtMessage: {
                    required: 'Please enter the message'
                }
            },


            showErrors: function (errorMap, errorList) {
              
                if (errorList != "") {
                    ShowAlert("Contact Us", errorList[0].message);
                }
            }

        });




        if ($("#frmContactUs").valid()) {

            collegeName = $('#txtCollegeName').val();
            subjectName = $('#txtSubjectName').val();
            userName = $('#txtUserName').val();
            mobileNumber = $('#txtMobile').val();
            EmailID = $('#txtEmailid').val();
            message = $('#txtMessage').val();
            UserFeedback($this);
        }





    });
});

function clear() {
    $('#txtCollegeName').val('');
    $('#txtSubjectName').val('');
    $('#txtUserName').val('');
    $('#txtMobile').val('');
    $('#txtEmailid').val('');
    $('#txtMessage').val('');
    $('#txtUniv').val('');

}