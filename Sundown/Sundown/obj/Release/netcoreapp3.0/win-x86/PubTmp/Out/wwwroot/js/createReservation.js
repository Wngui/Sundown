$(document).ready(function () {

    $("#guestpicker").change(function () {
        var value = $('#guestpicker').val();
        if (value !== "" && value !== null) {
            pickDate();
        } else {
            hideDate();
        }
    });

    function hideDate() {
        $("#calendar-container").fadeOut();
        $("#timeslot-container").fadeOut();
    }

    function pickDate() {
        $("#calendar-container").fadeIn();
        $("#calendar").datepicker({ minDate: 0 });
    }

    $("#calendar").on("change", function () {
        hideDate();
        var date = $("#calendar").val();
        pickTimeSlot(date);
    });

    function pickTimeSlot(date_pick) {
        $('#timeslot').empty();
        var url = $("#timeslot").data('request-url');
        $.get(url, { guests: 2, date: date_pick }, function (response) {
            generateTimeSlots(response);
            $("#timeslot-container").fadeIn();
        });
    }

    function generateTimeSlots(response) {
        console.log(response);
        $.each(response, function () {
            var button = $('<button type="button" data-date="'+this.fullDate+'" class="slot btn btn-outline-dark">' + this.timeString + '</button>');
            /*button.data("date", this.fullTimeString);
            console.log(this.isAvailable);*/
            if(!this.isAvailable) button.prop("disabled", "disabled");
            button.click(function () {
                console.log($(this).text());
                $("#ReservationDate").val($(this).data("date"));
                nextFlow();
            });
            $('#timeslot').append(button);
        });
    }

    function nextFlow() {
        $("#flow_when").fadeOut("slow", function () {
            $("#flow_how").fadeIn();
            $("#btn_back").fadeIn();
        });
    }

    $("#drinkpicker").change(function () {
        var value = $('#drinkpicker').val();
        if (value !== "" && value !== null) {
            $("#menu-container").fadeOut("slow", function () {
                $("#user-container").fadeIn();
                $("#btn_confirm").fadeIn();
            });
        }
    });

    $("#mail_input").on('input', function () {
        $("#btn_confirm").prop("disabled", !isEmail(this.value));
    }); 

    function isEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }

    $("#btn_back").click(function () {
        window.location.href = $("#btn_back").data("request-url");
    }); 

});


