$(document).ready(function () {

    $('.pagination').jqPagination({
        link_string: '/?page={page_number}',
        max_page: 276,
        paged: function (page) {
            $('.log').prepend('<li>Requested page ' + page + '</li>');
        }
    });

});