﻿$(document).ready(function () {

    var nonAvailableDates = [];

    //Get array with nonAvailableDates from Bookings controller to use it in Date Picker
    $(function () {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Bookings/GetNonAvailableDates',
            success: function (data) {
                //Add dates to the array
                for (var i = 0; i < data.length; i++) {
                    nonAvailableDates.push(data[i]);
                }


                //Date Picker called
                $('.date-picker').datepicker({
                    dateFormat: 'yy-mm-dd',
                    altField: "#Date",

                    beforeShowDay: function (date) {
                        var string = jQuery.datepicker.formatDate('yymmdd', date);
                        return [$.inArray(string, nonAvailableDates) == -1];
                    }
                });

            }
        });

    });


    //Function for Next button, can not be pressed if inputvalue is empty
    //var $input = $('#Date');
    //var $button = $('#NxtAltBooking1');


    //setInterval(function () {
    //    if ($input.val().length > 0) {
    //        $button.attr('disabled', false);
    //    } else {
    //        $button.attr('disabled', true);
    //    }
    //}, 100);

    //$("#NxtAltBooking1").click(function () {
    //    var test = $("#Date").val();
    //    alert(test);
    //});


    //Functions for Displaing hidden divs when next button is pressed + pass date to hidden date input
    $("#NxtAltBooking1").click(function () {
        var dateForBooking = document.getElementById('Date').value;
        $("#ShowBookingTime").show("show"),
            $('#NxtAltBooking1').hide("hide");
        $('.hdnInpBookingDate').val(dateForBooking);
    });


    $("#batata").click(function () {
        $("#ShowBookingForm").show("show"),
            $('#NxtAltBooking2').hide("hide");
    });

    $("#NxtAltBooking2").click(function () {
        $("#ShowBookingForm").show("show"),
            $('#NxtAltBooking2').hide("hide");
    });


    //Function for Sending date and time values to DateAndTime Hidden Input
    $.each($('.bookingBtns'), function (index, value) {
        $('#btnBooking_' + index).click(function () {
            //var dateForBooking = document.getElementById('Date').value;
            var timeForBooking = document.getElementById('btnBooking_' + index).value;
            var idForBooking = document.getElementById('btnBooking_' + index).name;
            $('.hdnInpBookingTime').val(timeForBooking);
            $('.hdnInpBookingId').val(idForBooking);
            $('#lblBookingTime').text(timeForBooking);
        });
    });




    

    $('div').click(function () {
        $("a.ui-state-default").each(function (index) {
            $(this).attr('id', index + 1);
            
        });
    });


    $.each($('.bookingBtns'), function (index, value) {
        $('#btnBooking_' + index).click(function () {
            //var dateForBooking = document.getElementById('Date').value;
            var timeForBooking = document.getElementById('btnBooking_' + index).value;
            var idForBooking = document.getElementById('btnBooking_' + index).name;


            var $button = $('#li_' + index).clone();
            $('#bookingPplList').html($button);
            $('#bookingPplList > li > input').hide();
            $('#bookingPplList > li > label').removeClass('hidden');
        });
    });


    $('#btnBooking_0').click(function () {
        var $button = $('#li_0').clone();
        $('#test').html($button);
        $('#test > li > input').hide();
        $('#test > li > label').removeClass('hidden');
    });




    //Get date and add to hidden date input when create button is clicked
    $('#btnCreate').click(function () {
        var dateForBooking = document.getElementById('Date').value;
        $('.hdnInpBookingDate').val(dateForBooking);
    });


    //Getting value from all input fields and sending to styled alertbox
    $('#btnCreate').click(function () {
        var dateForBooking = $('.hdnInpBookingDate').val();
        var timeForBooking = $('.hdnInpBookingTime').val();
        var nameForBooking = $('.inpBookingName').val();
        var phoneForBooking = $('.inpBookingPhone').val();
        var emailforBooking = $('.inpBookingEmail').val();

        if (dateForBooking.length > 0 &&
            timeForBooking.length > 0 &&
            nameForBooking.length > 0 &&
            phoneForBooking.length > 0 &&
            emailforBooking.length > 0) {

            swal("Välkommen " + nameForBooking,
               "Datum: " + dateForBooking + "\n" +
               "Tid: " + timeForBooking + "\n" +
               "Email: " + emailforBooking + "\n" +
               "Telefon: " + phoneForBooking + "\n" +
               "Vi kommer att skicka ett mail med boknings informationen till dig", "success");

        }
    });


});
