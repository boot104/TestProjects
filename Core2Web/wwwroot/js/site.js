// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
 * checks and sends a the given devExtreme form to the given url.
 *
 * returns a promise 
 */
function SubmitDxForm(dxFormId, keyField , url) {
    var form = $('#' + dxFormId).dxForm('instance');
    if (form.validate().isValid) {
        var data = form.option("formData");
        var send;
        if (!data[keyField] || data[keyField] == 0) {
            send = JSON.stringify(data);
        } else {
            send = JSON.stringify({ key: data[keyField], values: data });
        }
        return fetch(url,
            {
                method: 'POST',
                body: send,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                    'dataType': 'json',
                    'charset':'utf-8'
                }
            }).then(checkRes);
    }
    return Promise.reject("form not valid");
}

function SubmitForm(formId, url) {
    var form = $("#"+formId)[0];
    return fetch(url,
        {
            method: 'POST',
            body: new FormData(form)
        });
}

function checkRes(res) {
    return res.status != '200' ? Promise.reject(res) : Promise.resolve(res);
}

// Comes From ExToasdtrAjax
function postToast(res) {
    var msgs = JSON.parse(res.headers.get('X-NToastNotify-Messages'));

    msgs.forEach(function (i) {
        toastr.options = i.options;
        toastr[i.options.type](i.message,'',i.options);
    });
    return Promise.resolve(res);
}

function postToastAfterNav() {
    var msgs = JSON.parse(res.headers.get('X-NToastNotify-Messages'));

    msgs.forEach(function (i) {
        toastr.options = i.options;
        toastr[i.options.type](i.message, '', i.options);
    });
    return Promise.resolve(res);
}

function NavToUrl(url) {
    return function(res) {
        window.location.href = url;
        return Promise.resolve(res);
    }
}

function reloadPage(res) {
    window.location.reload();
    return Promise.resolve(res);
}