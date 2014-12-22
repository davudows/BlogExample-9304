function AddMenuResult(response) {

    ShowResult(response);


    if (response.IsSuccess == true) {
        $('#frmAddMenu').trigger('reset');
        if (response.Record.TopMenuId == 0) {
            var option = "<option value='" + response.Record.Id + "'>" + response.Record.Name + "</option>";
            $('#TopMenuId').append(option);
        }
    }
};
$('#LangId').change(function () {
    var id = $(this).val();
    $.getJSON("/Menu/SelectByLangId/" + id, function (data) {
        $('#TopMenuId').empty()
        var message = id == 1 ? 'Yeni bir menü oluşturmak istiyorum..!' : 'I Want to create new top menu';


        $('#TopMenuId').append('<option value="">' + message + "</option>");
        $.each(data, function (key, value) {
            $("#TopMenuId").append("<option value='" + value.Value + "'>" + value.Text + "</option>")
        })


    })

})