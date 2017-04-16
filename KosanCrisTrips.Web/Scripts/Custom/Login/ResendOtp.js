/// <reference path="../../jquery.min.js" />

$(document).ready(function () {
    $('#btnResendOtp').click(function () {
        var userId = $('#btnResendOtp').data('user-id');
        $.post('/Login/ResendOTP', { UserId: userId });
    });

});