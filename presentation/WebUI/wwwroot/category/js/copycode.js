function copyCode(elementId) {
    var codeElement = document.getElementById(elementId);
    var codeSpans = codeElement.getElementsByTagName('span');
    var code = '';

    for (var i = 0; i < codeSpans.length; i++) {
        var span = codeSpans[i];
        var text = span.textContent;

        if (text === '<') {
            code += '&lt;';
        } else if (text === '>') {
            code += '&gt;';
        } else {
            code += text;
        }
    }

    var dummyElement = document.createElement('textarea');
    dummyElement.innerHTML = code;
    var decodedCode = dummyElement.value;

    navigator.clipboard.writeText(decodedCode).then(function() {
        var logo = codeElement.nextElementSibling;
        logo.classList.add('clicked');

        setTimeout(function() {
            logo.classList.remove('clicked');
        }, 500);
    }).catch(function(err) {
        console.error('Kopyalama işlemi başarısız oldu: ', err);
    });
}