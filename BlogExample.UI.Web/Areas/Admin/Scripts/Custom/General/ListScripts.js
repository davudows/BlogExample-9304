$('.deleteButton').click(function () {
    var adress = $(this).attr('data-action');

    var id = $(this).attr('data-recordid');

    var options = {
        type: 'DELETE',
        url: adress + id,
        success: function (response) {
            $('#forDelete_' + recordId).fadeOut();
        }
    };
    $.ajax(options)
});