function toastMessage(type, message) {

    toasting.create({
        "title": "İşlem Sonucu",
        "text": message,
        "type": type,
        "progressBarType": type

    });

}

function formBegin() {
  $(".btnSubmit").prop("disabled", true);
}
function formError(response) {
   $(".btnSubmit").prop("disabled", false);

    try {
        var responseJSON = response.responseJSON;
        toastMessage(responseJSON.statusCode, responseJSON.responseMessage);
    } catch (e) {
        toastMessage("error", "Sonuç Değeri Okunamadı");
    }
}

function formSuccess(response) {
    try {
        toastMessage(response.statusCode, response.responseMessage);

        window.location = "/AdminHome/Index";
    } catch (e) {
        toastMessage("error", "Sonuç Değeri Okunamadı");
    }
}

function ajaxError(response) {
    try {
        if (jqXHR.status == 401) {
            msg = 'Unauthorized user';
            window.location = "/Login";
        }
        var responseJSON = JSON.parse(response.responseText);
        toastMessage(responseJSON.statusCode, responseJSON.responseMessage);
    } catch (e) {
        toastMessage("error", "Sonuç Değeri Okunamadı", "");
    }


}