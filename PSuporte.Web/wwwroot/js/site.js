Lemos = {}
Lemos.Framework = {}
Lemos.Framework.Form = {}

Lemos.Framework.Login = function () {
    var nomeUsuario = $("#usuario-login").val();
    var senhaUsuario = $("#senha-login").val();

    $.post(Lemos.Framework.loginActionUrl, { nomeUsuario: nomeUsuario, senha: senhaUsuario }, function (resposta) {
        if (resposta.Sucesso) {
            location.reload();
        } else {
            console.log(resposta.Sucesso);
        }
    });
};

Lemos.Framework.Form.Serialize = function (idForm) {
    return $(idForm).serialize();
};

Lemos.Framework.Form.SerializeJson = function (idForm) {
    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
        if ($(idForm).is('fieldset')) {
            return Lemos.Framework.Form.SerializeJsonInputs($(idForm).find(':input').not('disabled').not('button'));
        }
    }

    var val = {};
    $(idForm).serializeArray().map(function (x) {
        if (val[x.name] != undefined && val[x.name] === 'true') {
            return;
        }
        if (x.name.indexOf("[]") !== -1) {
            var name = x.name.replace("\[\]", "");
            if (val[name] == undefined) {
                val[name] = [];
            }
            val[name].push(x.value);
        } else {
            val[x.name] = x.value;
        }
    });

    return val;
};

Lemos.Framework.SerializeJsonInputs = function (inputs) {
    var val = {};
    $.each(inputs, function (idx, x) {
        if (val[$(x).attr('name')] != undefined && $(x).is(':checked') === false) {
            return;
        }
        if ($(x).attr('name') !== undefined && $(x).attr('name').indexOf("[]") !== -1) {
            var name = $(x).attr('name').replace("\[\]", "");
            if (val[name] == undefined) {
                val[name] = [];
            }
            val[name].push($(x).val());
        } else {
            val[$(x).attr('name')] = $(x).val();
        }
    });
    return val;
};

$.fn.addHiddenInputData = function (data) {
    var keys = {};
    var addData = function (data, prefix) {
        for (var key in data) {
            var value = data[key];
            if (!prefix) {
                var nprefix = key;
            } else {
                var nprefix = prefix + '[' + key + ']';
            }
            if (typeof (value) == 'object') {
                addData(value, nprefix);
                continue;
            }
            keys[nprefix] = value;
        }
    }
    addData(data);
    var $form = $(this);
    for (var k in keys) {
        $form.addHiddenInput(k, keys[k]);
    }
}
$.fn.addHiddenInput = function (key, value) {
    var $input = $('<input type="hidden" name="' + key + '" />');
    $input.val(value);
    $(this).append($input);
}