//$(document).ready(function () {
//   // alert("ok");
//    $.get('http://localhost:54595/User/CustomAction', function (data) {
//        $("#partialDiv").load(data);
//    });
//});
var _siteUrl = "http://localhost:54232/";
function goBack()
{
    window.history.back()
}
function Delete(_methodURL,_value,_click)
{
    //alert(_value);
    //var _data = {
    //    id:_value
    //}
    $.ajax({
        url: _siteUrl + _methodURL,
        type: 'POST',
        data: "{id:"+_value+"}",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $(_click).closest('tr').remove();
            alert(data);
          
        },
        error: function () {
            alert("error");
        }
    });
}