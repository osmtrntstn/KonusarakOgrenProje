function goToCreateExam(id) {
    window.location = "/AdminHome/CreateExam/" + id;
}

function DeleteExam(id) {
    $.ajax({
        url: "/AdminHome/DeleteExam",
        type: "post",
        dataType: "json",
        data: { id },
        success: function (response) {
            if (response.response.statusCode == "success") {
                $("#tr_" + response.target).remove();
            }
            toastMessage(response.response.statusCode, response.response.responseMessage);

        }, error: function (jqXHR, exception) {
            ajaxError(jqXHR);
        }
    });
}