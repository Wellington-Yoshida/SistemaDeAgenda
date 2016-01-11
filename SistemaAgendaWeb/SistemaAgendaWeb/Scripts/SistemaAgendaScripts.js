
/// Hover para os Cards
$(document).ready(function () {
    $('.special.cards .image').dimmer({
        on: 'hover'
    });
});

///------------------------------------------------>

///Mascara para Celular e TeleFoneFixo
(function ($) {
    $(function () {
        $("#Celular").mask("(99)9999-9999");
        $("#TelefoneFixo").mask("(99)9999-9999");
    });
})(jQuery);

///------------------------------------------------>

/// Valida TelefoneFixo
$(document).ready(function () {
    $("#Celular").on("blur", function () {

        var valida = {
            url: "/Contatoes/ValidaCelular/",
            method: "GET",
            data: { celular: $(this).val() },
            dataType: "Json",
            contentType: "application/Json; charset=utf-8"
        };

        var request = $.ajax(valida);

        request.done(function (data) {
            if (data.ContatoId > 0) {
                $('.form-group').find("input[type=submit]").prop("disabled", false);
            }
            else {
                $('.ui.basic.modal') /// Chamando Modal
                    .modal('show')
                ;
                $('.form-group').find("input[type=submit]").prop("disabled", true);
            }
        });

    });
});

///----------------------------------------------------->

///Modal Ajuda

$(document).ready(function () {
    $("#btnModalAjuda").on("click", function () {
        $('.large.modal')
        .modal('show')
        ;
    });
});

///------------------------------------------------------>

/// Popup img Sobre Sistema

$('#imgSobreSistema')
  .popup({
      inline: true
  })
;
    
///----------------------------------------------------->

/// Accordion Do Relatório

$('.ui.accordion')
  .accordion()
;

///------------------------------------------------------>
