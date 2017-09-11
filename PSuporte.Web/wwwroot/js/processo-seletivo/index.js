Lemos.Framework.ProcessoSeletivo = {};

Lemos.Framework.ProcessoSeletivo.EnviarInscricao = function () {
    var _nome = $("#Nome").val();
    var _email = $("#Email").val();
    var _curso = $("#Curso :selected").val();
    var _indisponibilidades = $("#Indisponibilidades").val();
    var _processoSeletivoId = $("#ProcessoSeletivoId").val();
    var _horarioIndividual = $("#HorarioIndividual").get(0).files[0];

    var formData = new FormData();
    formData.append("Nome", _nome);
    formData.append("Email", _email);
    formData.append("Curso", _curso);
    formData.append("Indisponibilidades", _indisponibilidades);
    formData.append("ProcessoSeletivoId", _processoSeletivoId);
    formData.append("HorarioIndividual", _horarioIndividual);


    $.ajax({
        url: Lemos.Framework.ProcessoSeletivo.urlEnviarInscricao,
        method: 'POST',
        dataType: 'json',
        data: formData,
        contentType: false,
        processData: false,
    }).done(function (resposta) {
        console.log(resposta);
        if (resposta.sucesso) {
            $("#titulo-modal").text("Sucesso");
            $("#corpo-modal").append("<p>Inscrição realizada com sucesso</p>");

            $("#modal-inscricao").modal("show");
        } else {
            $("#titulo-modal").text("Falha");
            $("#corpo-modal").empty();

            for (var i in resposta.mensagens) {
                $("#corpo-modal").append("<p>" + resposta.mensagens[i] + "</p>");
            }

            $("#modal-inscricao").modal("show");
        }
    });
};