$(document).ready(function () {
    var elems = document.querySelectorAll('td[data-exam="tdExam"]');
    $.each(elems, function (key, value) {
        var id = value.dataset.id;
        $.ajax({
            url: "/UserHome/GetExamStatus",
            type: "post",
            dataType: "json",
            data: { id },
            async: false,
            success: function (response) {
                $("#" + value.id).html(response.result);
            }, error: function () {
            }
        });
    });
});

function setQuestionAnswer(answer, target) {
    $("#Answer_" + target).val(answer);
}
function examSuccess(response) {
    $.each(response, function (key, value) {
        $(".answer-" + value.questionId + "-" + value.userAnswerId).css("background-color", "red")
        $(".answer-" + value.questionId + "-" + value.answerId).css("background-color", "green")
    });
    $("#btnEndExam").remove();
    $("#btnGoBack").css("display", "");
}