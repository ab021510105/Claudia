document.onreadystatechange = function () {
    if (document.readyState == "complete") {
        CreateRow();
        Finddivs();
    }
}
var sec="";
var p = 1;
var row = "";
var Selectbuf = "";
function Finddivs() {
    var divs = document.getElementsByClassName("clickdiv");
    for (i = 0; i < divs.length; i++) {
        divs[i].onmouseover = function () {
            this.style.border = "2px solid #95f6f3";
        }
        divs[i].onmouseleave = function () {
            this.style.border = "2px solid #FFFFFF";
        }
    }
}

function CreateRow() {
    var buf = document.getElementById("SelectionBuf");
    var str = buf.value;
    sec = str;
    var rows = "<tr><td><div style=\"border:2px solid white\" class=\"clickdiv\" onclick=\"showdv(\'d"+p+"\') \"><label id=\"label" + p + "\">题目" + p + ".请选择知识点和章节</label></div><div id=\"d"+p+"\" style=\"display:none\">章节:<select id=\"s"+p+"\" name=\"section\" onchange=\"selectcheck(this,\'k"+p+"\')\">";
    var SECRTIONS = sec.split("#")[0];
    var sections = SECRTIONS.split("$");
    var selectedvalue = sections[0].split("*")[1];
    rows += "<option value=\"0\"> </option>";
    for (i = 0; i < sections.length - 1; i++) {
        var sectionName = sections[i].split("*")[0];
        var sectionValue = sections[i].split("*")[1];
        rows += "<option value=\"" + sectionValue + "\">" + sectionName + "</option>";
    }
    rows += "</select> &nbsp;知识点:<select name=\"KnowledgePoint\" onchange=\"selectcheck(this,0)\" id=\"k"+p+"\">";
    var OPTIONS = sec.split("#")[1];
    var options = OPTIONS.split("%");
    //for (i = 0; i < options.length; i++) {
    //    if (selectedvalue == options[i].split("$")[0]) {
    //        var opt = options[i].split("$")[1].split("+");
    //        for (j = 0; j < opt.length - 1; j++) {
    //            rows += "<option value=\""+opt[j].split("*")[1]+"\">"+opt[j].split("*")[0]+"</option>";
    //        }
    //        rows += "</select>";
    //        break;
    //    }
    //}
    rows += "</select>";
    rows += "&nbsp;<input type=\"button\" value=\"确定\" class=\"Button_S\" onclick=\"confirmclick(this,\'d"+p+"\')\"></div></td></tr>";
    var table = document.getElementById("testinfo");
    //row += rows;
    table.innerHTML += rows;
    p++;
}
function selectcheck(obj, id) {
    sec = document.getElementById("SelectionBuf").value;
    if (id != 0) {
        var Sselect = obj;
        var Kselect = document.getElementById(id);
        var Sv = Sselect.options[Sselect.selectedIndex].value;
        Kselect.innerHTML = "";
        var kval = sec.split("#")[1].split("%");
        for (i = 0; i < kval.length - 1; i++) {
            var ksv = kval[i].split("$")[0];
            if (ksv == Sv) {
                var kno = kval[i].split("$")[1].split("+");
                for (j = 0; j < kno.length - 1; j++) {
                    Kselect.options.add(new Option(kno[j].split("*")[0], kno[j].split("*")[1]));
                }
                break;
            }
            
        }
    }
    else {

    }
}

function confirmclick(obj,divid) {
    var div = document.getElementById(divid);    
    poin = divid.split('d')[1];
    if (poin == p - 1) {
        var lab = document.getElementById("label" + poin);
        var Sselect = document.getElementById("s" + poin);
        var Kselect = document.getElementById("k" + poin);
        lab.innerHTML = "题目" + poin + ":" + Sselect.options[Sselect.selectedIndex].text + ">>" + Kselect.options[Kselect.selectedIndex].text;
        var rBuf = document.getElementById("ReturnBuf");
        rBuf.value += Kselect.options[Kselect.selectedIndex].value + "#";
        div.style.display = "none";
        var table = document.getElementById("testinfo");
        //table.innerHTML = "";
        Selectbuf += poin + "$" + Kselect.options[Kselect.selectedIndex].value + "#"+"%";
        CreateRow();
        Finddivs();
    }
    else {
        var lab = document.getElementById("label" + poin);
        var Sselect = document.getElementById("s" + poin);
        var Kselect = document.getElementById("k" + poin);
        lab.innerHTML = "题目" + poin + ":" + Sselect.options[Sselect.selectedIndex].text + ">>" + Kselect.options[Kselect.selectedIndex].text;
        var rBuf = document.getElementById("ReturnBuf");
        var rbufBorker;
        var selectedBufBorker
        var historys = Selectbuf.split("%");
        for (i = 0; i < historys.length; i++) {
            if (poin == historys[i].split("$")[0]) {
                rbufBorker = historys[i].split("$")[1];
                selectedBufBorker = historys[i];
                break;
            }
        }
        var temp = rBuf.value.split(rbufBorker);
        rBuf.value = "";
        for (i = 0; i < temp.length; i++) {
            rBuf.value += temp[i];
        }
        rBuf.value += Kselect.options[Kselect.selectedIndex].value + "#";
        temp = Selectbuf.split(selectedBufBorker);
        Selectbuf = "";
        for (i = 0; i < temp.length; i++) {
            Selectbuf += temp[i];
        }
        Selectbuf += poin + "$" + Kselect.options[Kselect.selectedIndex].value + "#" + "%";
        div.style.display = "none";
        
    }
}
function showdv(s) {
    div = document.getElementById(s);
    var point = s.split("d")[1];
    div.style.display = "block";
    
}