function AjaxRequest(url, cmd, value,ene) {
    var xmls = new XMLHttpRequest();
    //var val = "";
    xmls.onreadystatechange = function () {
        if (xmls.readyState == 4 && xmls.status == 200) {
           ene.innerHTML = xmls.responseText;
        }
    };
    xmls.open("POST", url + "?" + cmd + "=" + value, true);
    xmls.send();
}

