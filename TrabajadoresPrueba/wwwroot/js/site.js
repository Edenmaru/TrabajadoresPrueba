
$(function () {

    var placeElement = $('#placeElement');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            placeElement.html(data);
            placeElement.find('.modal').modal('show');

        })
    })

    placeElement.on('click', '[data-save="modal"]', function (event) {

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        
        $.post(actionUrl, sendData).done(function (data) {
            placeElement.find('.modal').modal('hide');
            location.reload(true);
        })

    })

})