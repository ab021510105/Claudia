function TestInfoCommand(Rowsid) {
    var rowid = Rowsid.split("#")[0];
    var btnid = Rowsid.split("#")[1];
    QuizRelationshipID = Rowsid.split("#")[2];
    Quizid = rowid;
    hidealluntil();
    var Quiztable = document.getElementById('QuizControl');
    var Quizdes = document.getElementById('QuizDesk');
    Quizdes.innerHTML = Test.ObjectTest.QuizBlind(QuizPageindex, rowid, 2).value;
    var QuizTitle = document.getElementById('QuizTitle');
    var titlebuf = Test.ObjectTest.GetQuizTitle(rowid).value;
    var TestName = titlebuf.split("#")[0];
    var TestCount = titlebuf.split("#")[1];
    var TestTimer = titlebuf.split("#")[2];
    QuizTitle.innerHTML = "练习名称:" + TestName + ";   " + "练习题数:" + TestCount + "题;   " + "练习时长:" + TestTimer + "分钟;";
    Quizid = rowid;
    QuziDataBound();
    Quiztable.style.display = "block";
    item_Options();
    if (getCookie(rowid) != null) {
        Cookiebuf = getCookie(rowid);
        setCookie(rowid, null, -1);
        document.getElementById('dialogbtn_Y').onclick = function () {
            setCookie(rowid, Cookiebuf, 1);
            Cookiebuf = "";
            QuizPageindex = 0;
            var Quizdes = document.getElementById('QuizDesk');
            //var Quiztable = document.getElementById('QuizControl');
            Quizdes.style.display = "none";
            Pagerbtn = this;
            StartProcessBar();
            Quizdes.innerHTML = Test.ObjectTest.QuizBlind(QuizPageindex, Quizid, 2).value;
            QuziDataBound();
            item_Options();
            ResetQuiz();
            Quizdes.style.display = "block";
            EndProcessBar(this);
            var d = document.getElementById('dialog');
            d.style.display = "none";

        };
        document.getElementById('dialogbtn_N').onclick = function () {
            Cookiebuf = "";
            var d = document.getElementById('dialog');
            d.style.display = "none";
        };
        StartMyDialog("发现本次测验存在备份，是否恢复选项？");
    }
}

function OnQuizFrontPageClick() {
    QuizPageindex--;
    var Quizdes = document.getElementById('QuizDesk');
    //var Quiztable = document.getElementById('QuizControl');
    Quizdes.style.display = "none";
    Pagerbtn = this;
    disablebtn(this);
    StartProcessBar();
    Quizdes.innerHTML = Test.ObjectTest.QuizBlind(QuizPageindex, Quizid, 2).value;
    QuziDataBound();
    item_Options();
    ResetQuiz();
    Quizdes.style.display = "block";
    EndProcessBar(this);
}

function OnQuizNextPageClick() {
    if (!QuizUpload) {
        QuizPageindex++;
        var Quizdes = document.getElementById('QuizDesk');
        //var Quiztable = document.getElementById('QuizControl');
        Quizdes.style.display = "none";
        Pagerbtn = this;
        disablebtn(this);
        StartProcessBar();
        Quizdes.innerHTML = Test.ObjectTest.QuizBlind(QuizPageindex, Quizid, 2).value;
        QuziDataBound();
        item_Options();
        ResetQuiz();
        Quizdes.style.display = "block";
        EndProcessBar(this);
    }
    else {
        var t = Test.ObjectTest.CreateUploadeTabel(QuizPageindex, Quizid, 2).value;
        var answerbuf = getCookie(Quizid);
        if (answerbuf == null)
        {
            answerbuf = Cookiebuf;
        }
        var answer = answerbuf.split("#");
        for (i = 0; i < answer.length; i++) {
            if (answer[i] != "") {
                t = Test.ObjectTest.AddOptionsid(answer[i]).value;
            }
        }
        t = Test.ObjectTest.ReadyUpLoad(QuizRelationshipID).value;
        if (t == 1) {
            Junmp_f = true;
            setCookie(Quizid, null, -1);
            window.location.href = 'Busy.aspx';
        }
        else {
            alert('你有题目没有完成');
        }
    }
}

function Getid(id, tid) {
    var a = document.getElementById(id);
    a.checked = a.checked ? false : true;
    if (a.checked) {
        // var test = Test.ObjectTest.AddOptionsid(id, tid).value;
        var answers = getCookie(Quizid);
        if (answers != null) {
            answers += id + "#";
            setCookie(Quizid, answers, 1);
        }
        else {
              setCookie(Quizid, id + "#", 1);
              if(getCookie(Quizid)==null)
              {
                  Cookiebuf += id + "#";
              }
        }

    }
    else {
        var answer = getCookie(Quizid);
        var _buf;
        if (answer != null) {
            _buf = answer.split(id + "#");
        }
        else
        {
            _buf = Cookiebuf.split(id + "#");
        }
        var Write = "";
        for (i = 0; i < _buf.length; i++) {
            Write += _buf[i];
        }
        setCookie(Quizid, Write, 1);
        if(getCookie(Quizid)==null)
        {
            Cookiebuf = Write;
        }
    }
}


function test_ServerChange(sender) {
    if (sender.checked) {

    }
    else {

    }
}




var TestID = "0";
var TSRelationshipID = "0";
var QuizUpload = false;
var ProgressBarSwitch = false;
var Quizid = null;
var LastQuizPageIndex = 0;
var QuizRelationshipID = null;

var QuizPageindex = 0;
var QuizPageCount = 0;
var RogessBarPoint = 0;

var Pagerbtn = null;



function hidealluntil() {
    document.getElementById('MyTestGridView').style.display = "none";
    document.getElementById('QuizControl').style.display = "none";
    document.getElementById('ProcessBar').style.display = "none";
}

function ClearGv(Gv1) {
    var nodes = Gv1.getElementsByTagName("div");
    for (i = 0; i < nodes.length; i++) {
        if (nodes[i].className != "GvTitle") {
            Gv1.removeChild(nodes[i]);
        }
    }
}
function QuziDataBound() {
    var countlabel = document.getElementById('QuizpageCount');
    countlabel.innerHTML = (QuizPageindex + 1) + "/" + Test.ObjectTest.GetQuizPageCount().value;
    var QuizNextButtom = document.getElementById('QuizButtonNext');
    var QuizFrontButtom = document.getElementById('QuizButtonFront');
    if (Test.ObjectTest.GetQuizPageCount().value - 1 == QuizPageindex) {
        QuizNextButtom.value = "上传";
        QuizUpload = true;
    }
    else {
        QuizUpload = false;
        QuizNextButtom.value = "▶";
    }
    if (QuizPageindex == 0) {
        QuizFrontButtom.disabled = true;
    }
    else {
        QuizFrontButtom.disabled = false;
    }
}

function item_Options() {
    var tr = document.getElementsByClassName('item_Options');
    for (i = 0; i < tr.length; i++) {
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

function ResetQuiz() {
    var options = getCookie(Quizid);
    var optid="";
    if (options != null) {
        optid = options.split("#");
    }
    else
    {
        optid = Cookiebuf.split("#");
    }
    var input = document.getElementsByTagName("input");
    for (i = 0; i < input.length; i++) {
        if (input[i].type == "checkbox") {
            input[i].checked = false;
        }
    }
    for (i = 0; i < optid.length; i++) {
        var check = document.getElementById(optid[i]);
        if (check != null) {
            check.checked = true;
        }
    }
}
function ReFreshMyTest() {
    var Gv1 = document.getElementById('MyTestGridView');
    ClearGv(Gv1);
    var Gv1 = document.getElementById('MyTestGridView');
    ClearGv(Gv1);
    Test.ObjectTest.CleanMyTestInfo();
    Gv1.innerHTML += Test.ObjectTest.BindMyTestInfo(0).value;
}