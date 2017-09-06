
document.onreadystatechange = function () {
    if (document.readyState == "complete") {
        var body = document.getElementsByTagName('body');
        body[0].style.height = screen.height.toString()+"px";
        Button_L();
        Button_S();
        Timer();
        item_Options();
        Nav();
        CheckTimeOut();
        LoadingProgress();
    }
}
var Pint = 5;
function LoadingProgress() {
    var label = document.getElementById('ProgressLabel');
    if (Pint !=0) {
        label.innerHTML += ".";
        Pint--;
    }
    else {
        Pint = 5;
        label.innerHTML = "Loading";
    }
    setTimeout(LoadingProgress,1000);
}


function Button_L()
{
    var btn = document.getElementsByClassName('Button_L');
    for (i = 0; i < btn.length; i++) {
        btn[i].onmouseover = function () {
            this.style.backgroundColor = "#425e8f";
        }
        btn[i].onmouseleave = function () {
            this.style.backgroundColor = "Blue";
        }
    }
}

function Button_S() {
    var btns = document.getElementsByClassName('Button_S');
    for (i = 0; i < btns.length; i++) {
        btns[i].onmouseover = function () {
            this.style.backgroundColor = "#425e8f";
        }
        btns[i].onmouseleave = function () {
            this.style.backgroundColor = "Blue";
        }
    }
    var btn = document.getElementsByClassName('Button_S_B');
    for (i = 0; i < btn.length; i++) {
        btn[i].onmouseover = function () {
            this.style.backgroundColor = "#425e8f";
        }
        btn[i].onmouseleave = function () {
            this.style.backgroundColor = "black";
        }
    }
}

    function Timer()
    {
        var timer = document.getElementsByClassName('Timer');
        var t = new Date();
        var m;
        if (t.getMinutes() < 10) 
        {
            m = "0" + t.getMinutes();
        }
        else {
            m = t.getMinutes();
        }
        var s;
        if (t.getSeconds() < 10) {
            s = "0" + t.getSeconds();
        }
        else {
            s = t.getSeconds();
        }
        for (i = 0; i < timer.length; i++) {
            timer[i].innerHTML = t.getHours() + ":" + m;
        }
        setTimeout(Timer, 1000);
    }

    //function Getid(id, tid) 
    //{
    //    var a = document.getElementById(id);
    //    var htmlbuf = document.getElementById('GotOpionsID');
    //    a.checked = a.checked ? false : true;
    //    if (a.checked) 
    //    {
    //        if (htmlbuf.value == null)
    //        {
    //            htmlbuf.value = id + "$" + tid + "#";
    //        }
    //        else 
    //        {
    //            htmlbuf.value += id + "$" + tid + "#";
    //        }

    //    }
    //    else 
    //    {
    //        if (htmlbuf.value == null) 
    //        {
    //            htmlbuf.value = "error";
    //        }
    //        else
    //        {
    //            var str = htmlbuf.value;
    //            var t = id + "$" + tid + "#";
    //            var strs = str.split(t.toString());
    //            var buf = "";
    //            for (i = 0; i < strs.length; i++) 
    //            {
    //                buf += strs[i];
    //            }
    //            htmlbuf.value = buf;
    //        }
    //    }
    //}

    function item_Options() 
    {
        var tr = document.getElementsByClassName('item_Options');
        for (i = 0; i < tr.length; i++)
        {
            tr[i].onmouseover = function () {
                this.style.border = "2px solid #95f6f3";
            }
            tr[i].onmouseleave = function () {
                if (this.title != "Selected") {
                    this.style.border = "2px solid #FFFFFF";
                }
            }
        }
    }

    function Nav()
    {
        var nav = document.getElementsByClassName('Nav');
        for (i = 0; i < nav.length; i++) 
        {
            nav[i].onclick = function () {
                var _nav = document.getElementsByClassName('Nav');
                for (j = 0; j < _nav.length; j++) {
                    if (_nav[j].style.backgroundColor == "#0026ff") {
                        _nav[j].style.backgroundColor = "#0094ff";
                    }
                }
                this.style.backgroundColor = "#0026ff";
            }
            nav[i].onmouseover = function () {
                this.style.backgroundColor = "#4800ff";
            }
            nav[i].onmouseleave = function () {
                this.style.backgroundColor = "#0094ff";
            }
        }
    }

    //function ShowGridViewItem(sid, ev) {
    //    ev = ev || window.event;
    //    var target = ev.target || ev.srcElement;
    //    var div = document.getElementById("Div" + sid);
    //    div.style.display = div.style.display == "none" ? "block" : "none";
    //    //target.innerhtml = 
    //    target.innerHTML = div.style.display == "none" ? "+" : "-";
    //}

    var i = 0;
    function CheckTimeOut() 
    {
        var Timer = document.getElementById('TestTime');
        if (Timer != null) 
        {
            if (Timer.innerHTML != "" && Timer.innerHTML != null) 
            {
                i++;
                if (i >= Timer.innerText * 60) 
                {
                    window.location.href = "jump.aspx?Condition=TimeOut";
                }
                else
                {
                    setTimeout(CheckTimeOut, 1000);
                }
            }
            else 
            {
                i = 0;
            }
        }

    }

    function naClick(id) {
        var a = document.getElementById(id);
        a.innerText = a.innerText == "+" ? "-" : "+";
        var div = document.getElementById(id + "d");
        div.style.display = div.style.display == "none" ? "block" : "none";
    }

    function ShowGv(gvids)
    {
        var Gv = document.getElementById(gvids);
        var btn = document.getElementById(gvids+"btn");
        btn.innerText = btn.innerText == "+" ? "-" : "+";
        Gv.style.display = Gv.style.display == "none" ? "block" : "none";
    }