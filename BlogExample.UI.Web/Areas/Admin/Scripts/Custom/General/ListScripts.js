$('.deleteButton').click(function () {    
    debugger;

    var adress = $(this).attr('data-action');
    var id = $(this).attr('data-recordid');

    var options = {
        type: 'POST',
        url: adress + id,
        success: function (response) {
            $('#forDelete_' + recordId).fadeOut();
        }
    };
    $.ajax(options)
});