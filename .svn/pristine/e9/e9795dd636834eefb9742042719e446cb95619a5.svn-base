var rData;

function LoadMailSummayView() {
    $.ajax({
        type: 'GET',
        url: $('#MailSummaryUrl').val(),
        dataType: 'json',
        success: function (data) {
            var response = $.parseJSON(data);
            var rData = response;
            var dynamicMails = "";
            for (var i = 0; i < rData.length; i++) {
                unReadClass = "";
                if (rData[i].isRead == false) {
                    unReadClass = 'mark_unread';
                }
                dynamicMails += '<ul>' +
          '<li><input id="hdnSubjectLine" value="' + rData[i].subjectName + '" type="hidden"/> ' +
          '<input id="hdnCreateDate" value="' + rData[i].createdDate + '" type="hidden"/>' +
          '<input id="hdnName" value="' + rData[i].name + '" type="hidden"/>' +
          '<input id="hdnMessage" value="' + rData[i].message + '" type="hidden"/>' +
          '<input id="hdnIsRead" value="' + rData[i].isRead + '" type="hidden"/>' +
           '<input id="hdnCollegeName" value="' + rData[i].collegeName + '" type="hidden"/>' +
           '<input id="hdnEmail" value="' + rData[i].email + '" type="hidden"/>' +
           '<input id="hdnMobileNumber" value="' + rData[i].mobileNumber + '" type="hidden"/>' +
           '<input id="hdnFId" value="' + rData[i].fb_id + '" type="hidden"/> ' +
            '<h5 class="' + unReadClass + '">' + rData[i].subjectName + '</h5>' +
                '</li>' +
          '<li><span>' + rData[i].name + ' <strong>' + rData[i].createdDate + '</strong> </span></li>' +
        '</ul>';
            }
            $('#SummaryView').html(dynamicMails);
            if ($('#SummaryView ul').length > 0) {
                $('.viewmail').fadeIn();
                LoadMailDetailedView($('#SummaryView > ul:first-child'), 0);
            }

        }
    });
}

function LoadMailDetailedView($this, addClass) {
    $('#SubjectLine').text($this.find('#hdnSubjectLine').val());
    $('#CreatedDate').text($this.find('#hdnCreateDate').val());
    $('#CollegeName').text($this.find('#hdnCollegeName').val());
    $('#Name').text($this.find('#hdnName').val());
    $('#MobileNumber').text($this.find('#hdnMobileNumber').val());
    $('#FromEmail').text($this.find('#hdnEmail').val());
    $('#Message').html('CollegeName:' + $this.find('#hdnCollegeName').val() + '<br/>Mobile:' + $this.find('#hdnMobileNumber').val() + '<br/>Message:' + $this.find('#hdnMessage').val());
    return false;
}

function LoadArchiveMails() {
   
    $.ajax({
        beforeSend: function () {
            $('.loader').show();
        },
        type: 'GET',
        url: '/APIService/APIAdminActivity/GetArchiveFeedbacks',
        dataType: 'json',
        success: function (response) {
            rData = response;
            $('#counts').text('(' + rData.feedbacks.length + ')');

            var createByDateArchive = "";
            for (var i = 0; i < rData.createdDate.length; i++) {
                createByDateArchive += '<li name="' + rData.createdDate[i].createdDate + '">' +
                 rData.createdDate[i].createdDate +
                 '<span style="float:right">(' + rData.createdDate[i].count + ')</span>' +
                '</li>';
            }
            $('#createdDate').html(createByDateArchive);

            var collegeNameArchive = "";
            for (var i = 0; i < rData.colleges.length; i++) {
                collegeNameArchive += '<li name="' + rData.colleges[i].collgeName + '">' + rData.colleges[i].collgeName +
                '<span style="float:right">(' + rData.colleges[i].count + ')</span>' +
                '</li>'
            }
            $('#college').html(collegeNameArchive);

            var dynamicMails = "";

            for (var i = 0; i < rData.feedbacks.length; i++) {
                unReadClass = "";
                if (rData.feedbacks[i].isRead == false) {
                    unReadClass = 'mark_unread';
                }
                dynamicMails += '<ul>' +
          '<li><input id="hdnSubjectLine" value="' + rData.feedbacks[i].subjectName + '" type="hidden"/> ' +
          '<input class="hdnCreateDate" id="hdnCreateDate" value="' + rData.feedbacks[i].createdDate + '" type="hidden"/>' +
          '<input id="hdnName" value="' + rData.feedbacks[i].name + '" type="hidden"/>' +
          '<input id="hdnMessage" value="' + rData.feedbacks[i].message + '" type="hidden"/>' +
          '<input id="hdnIsRead" value="' + rData.feedbacks[i].isRead + '" type="hidden"/>' +
           '<input class="hdnCollegeName" id="hdnCollegeName" value="' + rData.feedbacks[i].collegeName + '" type="hidden"/>' +
           '<input id="hdnEmail" value="' + rData.feedbacks[i].email + '" type="hidden"/>' +
           '<input id="hdnMobileNumber" value="' + rData.feedbacks[i].mobileNumber + '" type="hidden"/>' +
           '<input id="hdnFId" value="' + rData.feedbacks[i].fb_id + '" type="hidden"/> ' +
            '<h5 class="' + unReadClass + '">' + rData.feedbacks[i].subjectName + '</h5>' +
                '</li>' +
          '<li><span>' + rData.feedbacks[i].name + ' <strong>' + rData.feedbacks[i].createdDate + '</strong> </span></li>' +
        '</ul>';
            }
            $('#SummaryView').html(dynamicMails);


            if ($('#SummaryView ul').length > 0) {
                $('.viewmail').fadeIn();
                LoadMailDetailedView($('#SummaryView > ul:first-child'), 0);
            }
        },
        complete: function () {
            $('.loader').hide();
        }
    });
}


$(document).on('click', '#SummaryView ul', function (e) {
    e.preventDefault();
    $('.aside_active').removeClass('aside_active');
    $(this).addClass('aside_active');
    LoadMailDetailedView($(this), 1);
    $(this).find('.mark_unread').removeClass('mark_unread');
    $.post($('#UpdateReadStatusUrl').val() + '?fId=' + $(this).find('#hdnFId').val(), function () {
        return false;
    });


});

$(document).ready(function () {
  LoadArchiveMails();
});


$(document).on('click', '#createdDate li', function (e) {
    e.preventDefault();

    var searchText = $(this).attr('name');
    $('#SummaryView ul').hide().removeClass('visible');
    $('#SummaryView ul:contains("' + searchText + '")').fadeIn().addClass('visible');

    $('#SummaryView ul.aside_active').removeClass('aside_active');
    $('#SummaryView > ul.visible:eq(0)').addClass('aside_active');

    $('.child_menu_active').removeClass('child_menu_active');
    $(this).addClass('child_menu_active');

    $('#detailedsection, #SummarySection').fadeIn();
    $('#chartSection').fadeOut();
    LoadMailDetailedView($('#SummaryView > ul.visible').find(':first-child'), 0);
});


$(document).on('click', '#college li', function (e) {
    e.preventDefault();

    var searchText = $(this).attr('name');

    $('.child_menu_active').removeClass('child_menu_active');
    $(this).addClass('child_menu_active');

    $('#SummaryView ul').removeClass('visible').hide();
    $('#SummaryView ul .hdnCollegeName').filter(function () {
        return $(this).val().toLowerCase() === searchText.toLowerCase()
    }).parents('ul').addClass('visible').fadeIn();

    $('#SummaryView ul.aside_active').removeClass('aside_active');
    $('#SummaryView > ul.visible:eq(0)').addClass('aside_active');
    $('#detailedsection, #SummarySection').fadeIn();
    $('#chartSection').fadeOut();
    LoadMailDetailedView($('#SummaryView > ul.visible').find(':first-child'), 0);
});


$(document).on('click', '.mail_main_hed > ul > li > h5', function () {
    if (!$(this).hasClass('aside_active') && !$(this).hasClass('all')) {
        $('.mail_main_hed > ul > li > h5').removeClass('aside_active');
        $('.mail_main_hed li ul').slideUp();
        $(this).next().slideToggle();
        $(this).addClass('aside_active');
        title = $(this).text();
        var categories = [];
        var chart_data = [];
        if ($.trim($(this).text().toString()) === "Date") {

            for (var i = 0; i < rData.createdDate.length; i++) {
                //var item = { "name": rData.createdDate[i].createdDate, "y": rData.createdDate[i].count };
                categories.push(rData.createdDate[i].createdDate);
                chart_data.push(rData.createdDate[i].count);
            }
        }
        else {
            for (var i = 0; i < rData.colleges.length; i++) {
                //var item = { "name": rData.createdDate[i].createdDate, "y": rData.createdDate[i].count };
                categories.push(rData.colleges[i].collgeName);
                chart_data.push(rData.colleges[i].count);
            }
        }
        $('#SummarySection, #detailedsection').fadeOut();
        $('#chartSection').fadeIn();
        var title = $(this).text();
        PlotChart(title, categories, chart_data);


    }
    else if ($(this).hasClass('aside_active') && !$(this).hasClass('all')) {
        $('.mail_main_hed > ul > li > h5').removeClass('aside_active');
        $('.mail_main_hed li ul').slideUp();
        $('#SummarySection, #detailedsection').fadeOut();
        $('#chartSection').fadeIn();
    }
    if ($(this).hasClass('all')) {
        $('#detailedsection, #SummarySection').fadeIn();
        $('#chartSection').fadeOut();
        $('.visible').removeClass('visible');
        $('#SummaryView ul').fadeIn().addClass('visible');
        $('#SummaryView ul.aside_active').removeClass('aside_active');
        $('#SummaryView > ul.visible:eq(0)').addClass('aside_active');
        LoadMailDetailedView($('#SummaryView > ul.visible').find(':first-child'), 0);

    }
});


function PlotChart(title, categories, chart_data) {
    $('#container').highcharts({
        chart: {
            type: 'column'
        },
        title: {
            text: title + " Wise Report"
        },
        subtitle: {
            //text: 'Source: WorldClimate.com'
        },
        xAxis: {
            categories: categories,
            crosshair: true,
            title: {
                text: title
            }
        },
        yAxis: {
            min: 0,
            allowDecimals: false,
            title: {
                text: 'Count'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y: 1f}</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: [{
            name: 'Count',
            data: chart_data

        }]
    });
}
