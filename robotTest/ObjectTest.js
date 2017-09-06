
var errortimes = 0;
var ticked = 0;
var sign = 0;
var colorindex = 15;
function Time_Clock(){
    var time = Test.ObjectTest.GetServerTime().value;
    var wait = 1000;
    if (time == null) {
        var divInfo = "<div class=\"Text-Style1\">error:Disconnet from the server</div>";
        document.getElementById("errorInfo").innerHTML = divInfo;
        wait = 5000;
        errortimes++;
        if (errortimes == 3) {
            errortimes = 0;
            location.reload(true);
        }
    }
    else {
        errortimes = 0;
        var timer = document.getElementById('Time');
        var date = document.getElementById('Date');
        var week = document.getElementById('Week');
        var times = time.split("#");
        timer.innerHTML = times[0].split(":")[0]+"<label id=\"P1\">:</label>"+times[0].split(":")[1];
        date.innerHTML = times[1];
        week.innerHTML = WeekItoA(parseInt(times[2]));
    }


    setTimeout(Time_Clock,wait);
}

function TickTock() {
    var p = document.getElementById('P1');
    var wait = 25;
    if (p != null)
    {
        if (sign == 1) {
            sign = 0;
            setTimeout(TickTock,4000);
            return;
        }
        else {
            if (colorindex >= 0) {
                p.style.color = colorlist[colorindex--];
                setTimeout(TickTock, wait);
                return;
            }
            else {
                colorindex = 0;
                if (colorindex <= 15) {
                    p.style.color = colorlist[colorindex++];

                }
                else {
                    colorindex = 15;
                }
                sign = 1;
                setTimeout(TickTock, wait);
                return;
            }
        }
    }
    
}

var p = 20.0;
var div;
var flag = true;
function movsflag()
{
    if(p!=0&&div!=null&&flag)
    {
        p-=1;
        div.style.width = p + "%";        
        setTimeout(movsflag,5);
    }
    else
    {
        p = 20;
        flag = false;
    }
}

function BoundNav() {
    var buttoms = document.getElementsByClassName('NavButtom');
    for (i = 0; i < buttoms.length; i++)
    {
        buttoms[i].onmouseover = function ()
        {
           this.style.borderColor = "#00c8ff";
            var d=this.getElementsByClassName('select_d');
            var f = this.getElementsByClassName('select_f');
            f[0].style.display = "block";
            div = d[0];
            movsflag();
        }
        buttoms[i].onmouseleave = function ()
        {
            this.style.borderColor = "black";
            var d = this.getElementsByClassName('select_d');
            var f = this.getElementsByClassName('select_f');
            if (this.id.toString() != NavClickBtnID) {
                d[0].style.width = "20%"
                f[0].style.display = "none";
            }
                flag = true;
        }
        buttoms[i].onmousedown=function()
        {

        }
    }
}


function WeekItoA(week) {
    switch (week) {
        case 0: return "星期日";
            break;
        case 1: return "星期一";
            break;
        case 2: return "星期二";
            break;
        case 3: return "星期三";
            break;
        case 4: return "星期四";
            break;
        case 5: return "星期五";
            break;
        case 6: return "星期六";
            break;
       
    }
}

function TestInfoRef() {
    var TestGv = Test.ObjectTest.BindMyTestInfo(0).value;
    var div = document.getElementById('G1');
    div.innerHTML = TestGv;
}


