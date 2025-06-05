var LastUpdatedDay = "5"
var Datesufix = "th"
var monthofday = "Aug 2016"
var version = "3.0.0";

var UpdateContent = LastUpdatedDay + '<sup>' + Datesufix + '</sup>' + monthofday;


//-----------------------start activate code --------------------//
$(document).ready(function () {

    $("#LatestUpdatedDate").html('');
    $("#LatestUpdatedDate").html(UpdateContent);

    $("#LatestVersion").html('');
    $("#LatestVersion").html(version);

    //$('video').bind('contextmenu', function (e) {
    //    return false;
    //});


});

//-----------------------End activate code --------------------//

$(window).load(function () {
    $('[title]').tipTip();
});

//-----------------------End activate code --------------------//

 $(function(){
    $(".dropdown").hover(            
            function() {
                $('.dropdown-menu', this).stop( true, true ).fadeIn("fast");
                $(this).toggleClass('open');
                $('b', this).toggleClass("caret caret-up");                
            },
            function() {
                $('.dropdown-menu', this).stop( true, true ).fadeOut("fast");
                $(this).toggleClass('open');
                $('b', this).toggleClass("caret caret-up");                
            });
 });



 jQuery.fn.ForceNumericOnly =
 function () {
     return this.each(function () {
         $(this).keydown(function (e) {
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


 function isValidEmailAddress(emailAddress) {
     var mailformat = (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/);

     if (mailformat.test(emailAddress)) {
         return true;
     }
     else {
         return false;
     }
 }

 function validatePhone(MobileNumber) {
     var filter = /^[7-9]{1}[0-9]{9}$/;
     if (filter.test(MobileNumber)) {
         return true;
     }
     else {
         return false;
     }
 }