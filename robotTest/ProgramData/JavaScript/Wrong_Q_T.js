function onWorng_Q_TSearchClick() {
    var mintime = document.getElementById('TestStartTime');
    var maxtime = document.getElementById('TestEndTime');
    var desk = document.getElementById('Worg_Q_T_desk');
    desk.innerHTML = Test.ObjectTest.Worng_Q_TBind(mintime.value, maxtime.value).value;
    Wront_Q_TPageCount = Test.ObjectTest.GetQuizPageCountCount().value;
    Wrong_Q_TDataBound();
}





var Wront_Q_TPageindex = 0;
var Wront_Q_TPageCount = 0;
function GoWront_Q_T() {
    var mintime = document.getElementById('TestStartTime');
    var maxtime = document.getElementById('TestEndTime');
    mintime.value = Test.ObjectTest.GetDateTime_Days(-7).value;
    maxtime.value = Test.ObjectTest.GetDateTime_Days(0).value;
    var desk = document.getElementById('Worg_Q_T_desk');
    desk.innerHTML = Test.ObjectTest.Worng_Q_TBind(mintime.value, maxtime.value).value;
    Wront_Q_TPageCount = Test.ObjectTest.GetQuizPageCountCount().value;
    Wrong_Q_TDataBound();

}

function Wront_Q_TDataBind() {
    var GvDesk = document.getElementById('Worg_Q_T_desk');
    var mintime = document.getElementById('TestStartTime');
    var maxtime = document.getElementById('TestEndTime');
    var temp = Test.ObjectTest.Wrong_Q_TPageControl(Wront_Q_TPageindex).value;
    if (temp == "NULL") {
        Test.ObjectTest.Worng_Q_TBind(mintime.value, maxtime.value);
        temp = Test.ObjectTest.Wrong_Q_TPageControl(Wront_Q_TPageindex).value;
    }
    GvDesk.innerHTML = temp;

}

function OnWrong_Q_T_FontClick() {
    Wront_Q_TPageindex--;
    Wront_Q_TDataBind();
    Wrong_Q_TDataBound();
}

function OnWrong_Q_T_NextClick() {
    Wront_Q_TPageindex++;
    Wront_Q_TDataBind();
    Wrong_Q_TDataBound();
}

function OnWorg_Q_T_Controlchanged() {
    var select = document.getElementById('Worg_Q_T_Control');
    Wront_Q_TPageindex = parseInt(select.options[select.selectedIndex].value, 10);
    Wront_Q_TDataBind();
    Wrong_Q_TDataBound();
}

function Wrong_Q_TDataBound() {
    var select = document.getElementById('Worg_Q_T_Control');
    if (select.innerHTML != "") {
        select.innerHTML = "";
    }
    for (i = 0; i < Wront_Q_TPageCount; i++) {
        if (i == Wront_Q_TPageindex) {
            select.options.add(new Option((i + 1) + "", i + "", false, true));
        }
        else {
            select.options.add(new Option((i + 1) + "", i + "", false, false));
        }
    }
    var nextbtn = document.getElementById('Worg_Q_T_NextButtom');
    var fontbtn = document.getElementById('Worg_Q_T_FontButtom');
    if (Wront_Q_TPageindex == 0) {
        fontbtn.disabled = true
    }
    else {
        fontbtn.disabled = false;
    }
    if (Wront_Q_TPageindex == Wront_Q_TPageCount - 1) {
        nextbtn.disabled = true;
    }
    else {
        nextbtn.disabled = false;
    }
    var count = document.getElementById('Worg_Q_T_PageCount');
    count.innerHTML = "" + Wront_Q_TPageCount;
}