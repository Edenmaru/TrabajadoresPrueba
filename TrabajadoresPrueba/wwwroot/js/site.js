
$(function () {

    var placeElement = $('#placeElement');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeElement.html(data);
            placeElement.find('.modal').modal('show');

        })
    })

    placeElement.on('click', '[data-save="modal"]', function (event) {

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            console.log(sendData);
            placeElement.find('.modal').modal('hide');
        })

    })

})