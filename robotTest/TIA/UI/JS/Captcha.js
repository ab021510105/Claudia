function GetVal(value) {
    var val = "";
    if (value != "") {
        var t = value.split("<rvalue>");
        val = t[1];
    }
    return val;
}
function CheckVerificationTimeOut() {
    //if (document.getElementById("time_buf") == null) {
    //    var f = document.createElement("input");
    //    f.type = "hidden";
    //    f.id = "time_buf";
    //    f.value=""
    //    document.appendChild(f);
    //}
    //var xmls = new XMLHttpRequest();
    if (time == 0) {
        GreatCaptcha();
        var datetime = new Date();
        time = datetime.getMinutes() * 100 + datetime.getSeconds();
        //time = Login.land.GetCodeTime().value;        
        //xmls.onreadystatechange = function () {
          //  if (xmls.readyState == 4 && xmls.status == 200) {
           //    time=document.getElementById("time_buf").value = xmls.responseText;
           // }
       // };
        //xmls.open("POST", "ajaxrequest/s_time.aspx?getCodeTime=1", true);
        //xmls.send();
        //time = GetVal(document.getElementById("time_buf").value);
    }
    else {
        //var now = Login.land.GetSeverTime().value;
        //if (document.getElementById("now_buf") == null) {
        //    var now_f = document.createElement("input");
        //    now_f.type = "hidden";
        //    now_f.id = "now_buf";
        //    document.appendChild(now_f);
        //}
        //xmls.onreadystatechange = function () {
        //    if (xmls.readyState == 4 && xmls.status == 200) {
        //        document.getElementById("now_buf").value = xmls.responseText;
        //    }
        //};
        //xmls.open("POST", "ajaxrequest/s_time.aspx?getCodeTime=1", true);
        //xmls.send();
        //AjaxRequest("/ajaxrequest/s_time.aspx", "getServerTime", "mmss");
        //while(Ajrul=="");
        //var now = Ajrul;
        //a_c_flage = true;
        var datetime=new Date();
        now = datetime.getMinutes() * 100 + datetime.getSeconds();
        
        if (now == null)
        {
            alert('Disconnected from the server');
            sing = 0;
            return;
        }
        if (now - time >= 30) {
            time = 0;
        }
    }

    setTimeout(CheckVerificationTimeOut, 1000);
}
var time=0;
var sing = 1;


function GreatCaptcha() {
    if (sing == 0)
    {
        return;
    }
    var canvas = document.getElementById('captcha');
    //var div3 = document.getElementById('captcha_div');
    if (canvas == null) {
        alert('This page is not support your browser');
        return;
    }
    var BackColorPointColor = ColorSelect();
    var TestColor = ColorSelect();
    while (TestColor == BackColorPointColor) {
        TestColor = ColorSelect();
    }
    var context = canvas.getContext("2d");
    //context.clearRect(0, 0, canvas.widht, canvas.height);
    context.fillStyle = "#d1cdcd";
    context.fillRect(0, 0, canvas.width, canvas.height);
    context.lineWidth = "3px";
    context.fillStyle = BackColorPointColor;
    var h = canvas.height;
    var w = canvas.width;
    var Count = 10;
    var x = Array(Count);
    var y = Array(Count);
    for (i = 0; i <= Count; i++) {
        x[i] = parseInt(w * Math.random()) - 3;
        while (x[i] <= 0) {
            x[i] = parseInt(w * Math.random()) - 3;
        }
        for (j = 0; j < i; j++) {
            if (x[i] == x[j]) {
                x[i] = parseInt(w * Math.random()) - 3;
                while (x[i] <= 0) {
                    x[i] = parseInt(w * Math.random()) - 3;
                }
                j = -1;
            }
        }
    }
    for (i = 0; i <= Count; i++) {
        y[i] = parseInt(h * Math.random()) - 3;
        while (y[i] <= 0) {
            y[i] = parseInt(h * Math.random()) - 3;
        }
        for (j = 0; j < i; j++) {
            if (y[i] == y[j]) {
                y[i] = parseInt(h * Math.random()) - 3;
                while (y[i] <= 0) {
                    y[i] = parseInt(h * Math.random()) - 3;
                }
                j = -1;
            }
        }
    }
    context.beginPath();
    for (i = 0; i < Count; i++) {

        context.arc(x[i], y[i], 3, 0, Math.PI * 2, true);

    }
    context.closePath();
    context.fill();
    var Code="";
    var xmls = new XMLHttpRequest();
    //var val = "";
    if (document.getElementById("Code_buf") == null) {
        var code_f = document.createElement("input");
        code_f.type = "password";
        code_f.sytle = "display:none;";
        code_f.value = "";
    }

    xmls.onreadystatechange = function () {
        if (xmls.readyState == 4 && xmls.status == 200) {
            document.getElementById("Code_buf").value= xmls.responseText;
        }
    };
    //var Code = Login.land.GetCode().value;
    //AjaxRequest("/ajaxrequest/s_time.aspx", "getCode", "1");
    xmls.open("POST", "ajaxrequest/s_time.aspx?getCode=1", false);
    xmls.send();
    //while (Ajrul == "");
    // = Ajrul;
    //a_c_flage = true;
    //time = Login.land.GetCodeTime().value;
    //if (document.getElementById("time_buf") == null) {
    //    var f = document.createElement("input");
    //    f.type = "hidden";
    //    f.id = "time_buf";
    //    f.value = "";
    //    document.appendChild(f);
    //}
    //var xmls2 = new XMLHttpRequest();
    //xmls2.onreadystatechange = function () {
    //    if (xmls2.readyState == 4 && xmls2.status == 200) {
    //        document.getElementById("time_buf").value=xmls2.responseText; 
    //    }
    //};
    ////while (document.getElementById("time_buf").value == "");
    var datetime=new Date();
    time = datetime.getMinutes() * 100 + datetime.getSeconds();
    //document.getElementById("time_buf").value = "";
    // AjaxRequest("/ajaxrequest/s_time.aspx", "getCodeTime", "1");
    //xmls2.open("POST", "ajaxrequest/s_time.aspx?getCodeTime=1", true);
    //xmls2.send();
    //while(Ajrul=="");
    //= Ajrul;
    //a_c_flage = true;
    var C_tem = document.getElementById("Code_buf");
    //while (C_tem.value == "");
    Code = GetVal(C_tem.value);
    if (Code == "") {
        Code = GetVal(C_tem.value);
    }
    C_tem.value = "";
    //while (Code == "");
    var fun = Code.split("#");
    var Fy = fun[fun.length - 1] + "=";
    context.font = SelectFontStyle() + " 20px sans-serif";
    context.textBaseline = 'top';
    context.fillStyle = TestColor;
    context.fillText(Fy, 0, parseInt(10 * Math.random()));
    var FrontTextLenght = context.measureText(Fy);
    var Fronwidth = FrontTextLenght.width;
    for (i = 0; i < fun.length - 1; i++) {
        if (i == 1) {
            if (fun[i] == "*") {
                continue;
            }
        }
        var text = fun[i];
        context.font = SelectFontStyle() + " 20px sans-serif";
        //context.fillStyle = ColorSelect();
        Fronwidth += parseInt(5 * Math.random());
        context.fillText(text, Fronwidth, parseInt(15 * Math.random()));

        Fronwidth += context.measureText(text).width;
    }

}

function SelectFontStyle()
{
    var rand = Math.random();
    var select = parseInt(3 * rand);
    switch(select)
    {
        case 0: return "italic";
            break;
        case 1: return "oblique";
            break;
        case 2: return "normal";
            break;
        default: return "italic";
            break;
    }
}

function ColorSelect()
{
    var rand = Math.random();
    var SelectColor = parseInt(3 * rand);
   
    switch (SelectColor) {
        case 0: return "Yellow";
            break;
        case 1: return "Red";
            break;
        case 2: return "Green";
            break;
        default:return "Blue";
            break;
    }
}

