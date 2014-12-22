function ShowResult(cevap) {
    $('#result').empty();
    $('#result').removeClass('alert alert-danger');
    $('#result').removeClass('alert alert-info');
    $('#result').addClass(cevap.CssClass);
    $('#result').append(cevap.Message);
}