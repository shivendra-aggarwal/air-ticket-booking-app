$(document).ready(function () {
    $("#create_request_button").on("click", function () {
        $("form").submit();
    });
})

function assignSeat(obj) {

    console.log($(obj).parent().html());

    $("#selected_seat").val(selectedSeatId);
    $("#create_request_button").prop("disabled", false);
}


