function failed(en)
{
    en.innerHTML = "服务器已经停止响应，稍后重试";
}

function busy(tid) {
    var t = document.getElementById(tid);
    t.innerHTML = "<div style=\"width:100%;height:100%; text-align:center\"> <embed src=\"Desk/busy.swf\" width=\"500\" height=\"500\"/></div> ";
}

function Arequest(tid, url, syn)
{
    var xml = new XMLHttpRequest();
    document.getElementById(tid).innerHTML = "";
    busy(tid);
    xml.onreadystatechange = function () {
        if (xml.readyState == 4 && xml.status == 200) {
            document.getElementById(tid).innerHTML = xml.responseText;
        }
        else if (xml.status >= 400) {
            failed(document.getElementById(tid));
        }
    };
    xml.open("POST",url, syn);
    xml.send();

    
}

function Arequest_e(tid,url,mode,syn)
{
    var xml = new XMLHttpRequest();
    busy(tid);
    xml.onreadystatechange = function () {
        if (xml.readyState == 4 && xml.status == 200) {
            document.getElementById(tid).innerHTML = xml.responseText;
        }
        else if (xml.status >= 400) {
            failed(document.getElementById(tid));
        }
    };
    xml.open(mode, url, syn);
    xml.send();
}


