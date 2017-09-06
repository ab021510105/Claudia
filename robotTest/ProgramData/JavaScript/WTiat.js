var WTiatPageIndex = 0;
var WTiatPageCount = 0;
function Worng_Q_TCommand(DataFiled) {
    var primaryID = DataFiled.split("#")[0];
    var tiat = document.getElementById('TiatDesk');
    tiat.innerHTML = Test.ObjectTest.startWTiat().value;
    var title = document.getElementById('W_TiatTitle');
    title.innerHTML = Test.ObjectTest.GetKonowledgeName(primaryID).value;
    var desk = document.getElementById('W_iatTileDesk');
    var maxTime = document.getElementById('TestEndTime');
    var minTime = document.getElementById('TestStartTime');
    desk.innerHTML = Test.ObjectTest.WTiatPageControlBlind(primaryID, minTime.value, maxTime.value).value;
    WTiatPageIndex = 1;
    WTiatPageCount = Test.ObjectTest.GetWtiatPagecount().value;
    WtiatDataBound();

}
function onWtiatFontBtnClick() {
    WTiatPageIndex--;
    WtiatDataBilnd();
    WtiatDataBound();
}
function OnWtiatNextBtnClikc() {
    WTiatPageIndex++;
    WtiatDataBilnd();
    WtiatDataBound();
}
function WtiatDataBilnd() {
    var desk = document.getElementById('W_iatTileDesk');
    var temp = Test.ObjectTest.WtiatPagerControl(WTiatPageIndex).value;
    if (temp == "NULL") {
        var maxTime = document.getElementById('TestEndTime');
        var minTime = document.getElementById('TestStartTime');
        Test.ObjectTest.WTiatPageControlBlind(primaryID, minTime.value, maxTime.value);
        temp = Test.ObjectTest.WtiatPagerControl(WTiatPageIndex).value;
    }
    desk.innerHTML = temp;
}

function WtiatDataBound() {
    var fontbtn = document.getElementById('TiatButtonFront');
    var nextbtn = document.getElementById('TiatButtonNext');
    var label = document.getElementById('WtitleCount');
    label.innerHTML = WTiatPageIndex + "/" + WTiatPageCount;
    if (WTiatPageIndex == 1) {
        fontbtn.disabled = true;
    }
    else {
        fontbtn.disabled = false;
    }
    if (WTiatPageCount == WTiatPageIndex) {
        nextbtn.disabled = true;
    }
    else {
        nextbtn.disabled = false;
    }
}

function OnWTiatCloseClick() {
    var desk = document.getElementById('TiatDesk');
    TiatDesk.innerHTML = "";
}