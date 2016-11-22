/*Booking site scripts*/
//Loading Datepicker
$(function () {
    // This will make every element with the class "date-picker" into a DatePicker element
    $('.date-picker').datepicker();
});


//Function for Next button, can not be pressed if inputvalue is empty
var $input = $('#Date');
var $button = $('#NxtAltBooking1');

setInterval(function () {
    if ($input.val().length > 0) {
        $button.attr('disabled', false);
    } else {
        $button.attr('disabled', true);
    }
}, 100);


//Functions for Displaing hidden divs when next button is pressed
$(document).ready(function () {
    $("#NxtAltBooking1").click(function () {
        $("#ShowBookingTime").show("show"),
            $('#NxtAltBooking1').hide("hide");
    });
});

$(document).ready(function () {
    $("#NxtAltBooking2").click(function () {
        $("#ShowBookingForm").show("show"),
            $('#NxtAltBooking2').hide("hide");
    });
});


//Function for Sending date and time values to DateAndTime Hidden Input
$(document).ready(function () {
    $.each($('.bookingBtns'), function (index, value) {
        $('#btnBooking_' + index).click(function () {
            var dateForBooking = document.getElementById('Date').value;
            var timeForBooking = document.getElementById('btnBooking_' + index).value;
            var idForBooking = document.getElementById('btnBooking_' + index).name;
            $('.hdnInpBookingDate').val(dateForBooking + ' ' + timeForBooking);
            $('.hdnInpBookingId').val(idForBooking);
        });
    });
});



// Old version and test versions
//$(document).ready(function () {
//    $('#btnBooking_2').click(function () {
//        var dateForBooking = document.getElementById('btnBooking_2').value;
//        $('.hdnInpBookingTime').val(dateForBooking);
//        });
//});

//$(document).ready(function () {
//    $('#NxtAltBooking1').click(function () {
//        var dateForBooking = document.getElementById('Date').value;
//        $('.hdnInpBookingDate').val(dateForBooking);
//    });
//});

//$(document).ready(function () {
//    $('#ui-datepicker-div').click(function () {
//        var dateForBooking = document.getElementById('Date').value;
//        var timeForBooking = document.getElementById('btnBooking1').value;
//        var idForBooking = document.getElementById('btnBooking1').name;
//        $('.hdnInpBookingDate').val(dateForBooking + ' 17:00:00');
//        $('.hdnInpBookingId').val(idForBooking);
//    });
//});


