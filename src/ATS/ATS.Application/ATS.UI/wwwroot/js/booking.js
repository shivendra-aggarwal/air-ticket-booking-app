﻿$(document).ready(function () {
    $("#create_request_button").on("click", function () {
        $("form").submit();
    });
})

function assignSeat(selectedSeatId) {
    $("#selected_seat").val(selectedSeatId);
    $("#selected_vendor").val("GoAir");
    $("#create_request_button").prop("disabled", false);
}


