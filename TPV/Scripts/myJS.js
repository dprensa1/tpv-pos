﻿

function atras() {
    window.history.back();
};

$("[data-toggle=tooltip]").tooltip();

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

$(function () {
    $("[data-toggle='tooltip']").tooltip();
});;

//$(document).ready(function () {
//    $('.date').mask('11/11/1111');
//    $('.time').mask('00:00:00');
//    $('.date_time').mask('00/00/0000 00:00:00');
//    $('.cep').mask('00000-000');
//    $('.phone').mask('0000-0000');
//    $('.phone_with_ddd').mask('(00) 0000-0000');
//    $('.phone_us').mask('(000) 000-0000');
//    $('.mixed').mask('AAA 000-S0S');
//    $('.cpf').mask('000.000.000-00', { reverse: true });
//    $('.money').mask('000.000.000.000.000,00', { reverse: true });
//});

$(document).ready(function () {
    $('.cedula').mask('000-0000000-0');
    $('.telefono').mask('000-000-0000');
    $('.money').mask('000.000.000.000.000,00', { reverse: true });    
});