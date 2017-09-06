
function MyHistroyTestGridViewCommand(DataFiled) {
    var pirmaryid = DataFiled.split("#")[0];
    TiatID = pirmaryid;
    var end = document.getElementById('TestEndTime');
    var start = document.getElementById('TestStartTime');
    histroyTestSartTime = start.value;
    historyTestEndTime = end.value;
    var desk = document.getElementById('desk');
    desk.innerHTML = Test.ObjectTest.startTita().value;
    var title = document.getElementById('TiatTitle');
    title.innerHTML = Test.ObjectTest.GetTiatName(pirmaryid).value;
    var tiatdesk = document.getElementById('TiatDesk');
    tiatdesk.innerHTML = Test.ObjectTest.startTiatDesk(pirmaryid).value;
    TiatPageindex = 1;
    TiatPageCount = Test.ObjectTest.GetTiatCount().value;
    TaitaDataBound();
}
var TiatPageCount = 0;
var TiatPageindex = 0;
var TiatID = null;
function OnTiatFontClick() {
    TiatPageindex--;
    TiatDataBild();
    TaitaDataBound();
}
function OnTiatNextClick() {
    TiatPageindex++;
    TiatDataBild();
    TaitaDataBound();
}


function TiatDataBild() {
    var temp = Test.ObjectTest.TiatPageControl(TiatPageindex).value;
    if (temp == "NULL") {
        Test.ObjectTest.startTiatDesk(pirmaryid);
        temp = Test.ObjectTest.TiatPageControl(TiatPageindex).value;
    }
    document.getElementById('TiatDesk').innerHTML = temp;

}

function TaitaDataBound() {
    var fontbtn = document.getElementById('TiatButtonFront');
    var nextbtn = document.getElementById('TiatButtonNext');
    var label = document.getElementById('TiatpageCount');
    label.innerHTML = TiatPageindex + "/" + TiatPageCount;
    if (TiatPageindex == 1) {
        fontbtn.disabled = true;
    }
    else {
        fontbtn.disabled = false;
    }
    if (TiatPageindex == TiatPageCount) {
        nextbtn.disabled = true;
    }
    else {
        nextbtn.disabled = false;
    }
}

