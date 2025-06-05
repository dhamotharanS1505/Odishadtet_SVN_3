jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "time-uni-pre": function (a) {

        var uniTime;
       // var uniTimeFinal;
       
        uniTime = a.replace(":", "");
        while (uniTime.indexOf(":") > -1) {
            uniTime = uniTime.replace(":", "");
        }

        //uniTimeFinal = uniTime.replace(":", "");
        //while (uniTimeFinal.indexOf(":") > -1) {
        //    uniTimeFinal = uniTimeFinal.replace(":", "");
        //}
        //alert("uniTime" + uniTime);
        return Number(uniTime);
    },

    "time-uni-asc": function (a, b) {
       // alert("a"+a);
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },

    "time-uni-desc": function (a, b) {
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    }
});