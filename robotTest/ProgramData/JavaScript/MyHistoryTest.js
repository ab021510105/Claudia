function OnLastSeventDaysClick() {
    var TestStartTime = document.getElementById('TestStartTime');
    var TestEndTime = document.getElementById('TestEndTime');
    TestStartTime.value = Test.ObjectTest.GetDateTime_Days(-7).value;
    TestEndTime.value = Test.ObjectTest.GetDateTime_Days(0).value;
}

function OnLastMonthClick() {
    var TestStartTime = document.getElementById('TestStartTime');
    var TestEndTime = document.getElementById('TestEndTime');
    TestStartTime.value = Test.ObjectTest.GetDateTime_Month(-1).value;
    TestEndTime.value = Test.ObjectTest.GetDateTime_Month(0).value;
}

function OnTodayClick() {
    var TestStartTime = document.getElementById('TestStartTime');
    var TestEndTime = document.getElementById('TestEndTime');
    var DateTime = new Date();
    var Year = DateTime.getFullYear();
    var Month = DateTime.getMonth() + 1;
    var Day = DateTime.getDate();
    Month = Month < 10 ? "0" + Month : Month;
    Day = Day < 10 ? "0" + Day : Day;
    TestStartTime.value = Year + "-" + Month + "-" + Day + " " + "00:00:00";
    TestEndTime.value = Year + "-" + Month + "-" + Day + " " + "23:59:59";
}
function RefreshMyhistoryCount() {
    Test.ObjectTest.ClearMyHistoryTestCount();
    MyHistoryTestPageIndex = 0;
    var HistoryCount = document.getElementById('Myhistory_Count_Desk');
    var teststarttime = document.getElementById('TestStartTime').value;
    var testendtime = document.getElementById('TestEndTime').value;
    HistoryCount.innerHTML = Test.ObjectTest.MyHistoryBind(0,teststarttime,testendtime).value;
    MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryPageCount().value;
    MyHistoryTestCountBound();
}
function OnHistoryTestCountFontBtnClick() {
    MyHistoryTestPageIndex--;
    var HistoryCount = document.getElementById('Myhistory_Count_Desk');
    HistoryCount.innerHTML = Test.ObjectTest.MyHistoryTestPageControl(MyHistoryTestPageIndex).value;
    MyHistoryTestCountBound();
}
function OnHistoryTestCountNextBtnClick() {
    MyHistoryTestPageIndex++;
    var HistoryCount = document.getElementById('Myhistory_Count_Desk');
    HistoryCount.innerHTML = Test.ObjectTest.MyHistoryTestPageControl(MyHistoryTestPageIndex).value;
    MyHistoryTestCountBound();
}

var MyHistoryTestPageIndex = 0;
var MyHistoryTestPageCount = 0;
function MyHistoryTestCountBound() {
    var FontBtn = document.getElementById('MyhistoryFontPagebtn');
    var NextBtn = document.getElementById('MyhistoryNextPagebtn');
    var LabelCount = document.getElementById('MyHistoryCountpager_Count_label');
    if (MyHistoryTestPageCount == 0) {
        MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryPageCount().value;
    }
    if (MyHistoryTestPageIndex == MyHistoryTestPageCount - 1) {
        NextBtn.disabled = true;
    }
    else {
        NextBtn.disabled = false;
    }
    if (MyHistoryTestPageIndex == 0) {
        FontBtn.disabled = true;
    }
    else {
        FontBtn.disabled = false;
    }
    LabelCount.innerHTML =( MyHistoryTestPageIndex+1) + "/" + MyHistoryTestPageCount;
}
function GoHistoryCount() {
    var MyHistory_Count = document.getElementById('Myhistory_Count_Desk');
    Test.ObjectTest.ClearMyHistoryTestCount();
    var teststarttime = document.getElementById('TestStartTime').value;
    var testendtime = document.getElementById('TestEndTime').value;
    MyHistory_Count.innerHTML = Test.ObjectTest.MyHistoryBind(0,teststarttime,testendtime).value;
    MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryPageCount().value;
    MyHistoryTestCountBound();
}

var HistoryTestInfoPageIndex = 0;
var HistoryTestInfoPageCount = 0;




function OnHestoryTestInfoFontClick() {
    HistoryTestInfoPageIndex--;
    disablebtn(this);
    StartProcessBar();
    HistoryTestInfoBlind();
    HistoryTestInfoBound();
    EndProcessBar(this);
}

function OnHestoryTestInfoNextClick() {
    HistoryTestInfoPageIndex++;
    disablebtn(this);
    StartProcessBar();
    HistoryTestInfoBlind();
    HistoryTestInfoBound();
    EndProcessBar(this);
}

function OnHestoryTestInfoSelectChanged() {
    var select = document.getElementById('HistoryControl');
    HistoryTestInfoPageIndex = parseInt(select.options[select.selectedIndex].value, 10);
    disablebtn(this);
    StartProcessBar();
    HistoryTestInfoBlind();
    HistoryTestInfoBound();
    EndProcessBar(this);
}

function HistoryTestInfoBound() {
    var pageSelect = document.getElementById('HistoryControl');
    if (pageSelect.innerHTML != "") {
        pageSelect.innerHTML = "";
    }
    for (i = 0; i < HistoryTestInfoPageCount; i++) {
        //var selectoptions;
        new Option(1, 2, false, true);
        if (i == HistoryTestInfoPageIndex) {
            //selectoptions = "<option value=\"" + i + "\" selected=\"selected\">" + (i + 1) + "</option>";
            pageSelect.options.add(new Option((i + 1) + "", i + "", false, true));
        }
        else {
            //selectoptions = "<option value=\"" + i + "\" >" + (i + 1) + "</option>";
            pageSelect.options.add(new Option((i + 1) + "", i + "", false, false));
        }
    }
    var label = document.getElementById('HistoryInfoPageCount');
    label.innerHTML = "" + HistoryTestInfoPageCount;
    //label.innerText = "" + HistoryInfoPageCount;
    var FontBtn = document.getElementById('MyHistoryTestInfo_FontButtom');
    var NextBtn = document.getElementById('MyHistoryTestInfo_NextButtom');
    if (HistoryTestInfoPageCount - 1 == HistoryTestInfoPageIndex) {
        NextBtn.disabled = true;
    }
    else {
        NextBtn.disabled = false;
    }
    if (HistoryTestInfoPageIndex == 0) {
        FontBtn.disabled = true;
    }
    else {
        FontBtn.disabled = false;
    }
}

function HistoryTestInfoBlind() {
    var HistoryTest = document.getElementById('MyHistoryTestInfo_desk');
    var TestStartTimeMin = document.getElementById('TestStartTime');
    var TestStartTimeMax = document.getElementById('TestEndTime');
    var buf= Test.ObjectTest.HistoryTestInfoPageControler(HistoryTestInfoPageIndex).value;
    if ( buf!= "NULL") {
        HistoryTest.innerHTML = buf;
        if (MyHistoryTestPageCount == 0) {
            MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryTestInfoPageCount().value;
        }
    }
    else {
        Test.ObjectTestBindHistoryTestInfo(TestStartTimeMin.value, TestStartTimeMax.value);
        HistoryTest.innerHTML = Test.ObjectTest.HistoryTestInfoPageIndex(HistoryTestInfoPageIndex).value;
        MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryTestInfoPageCount().value;
    }

    //HistoryTest.innerHTML=
}

function GoHistoryTestInfo() {
    var teststartmin = document.getElementById('TestStartTime');
    var teststartmax = document.getElementById('TestEndTime');
    teststartmin.value = Test.ObjectTest.GetDateTime_Days(-7).value;
    teststartmax.value = Test.ObjectTest.GetDateTime_Days(0).value;
    if (histroyTestSartTime!=null)
    {
        teststartmin.value = histroyTestSartTime;
        teststartmax.value = historyTestEndTime;
    }
    Test.ObjectTest.CleanMyHistoryTestInfo();
    Test.ObjectTest.BindHistoryTestInfo(teststartmin.value, teststartmax.value);
    var desk = document.getElementById('MyHistoryTestInfo_desk');
    desk.innerHTML = Test.ObjectTest.HistoryTestInfoPageControler(0).value;
    HistoryTestInfoPageCount = Test.ObjectTest.GetMyHistoryTestInfoPageCount().value;
    HistoryTestInfoBound();
}

 
//function searchHistoryInf0()
//{
//    var MyHistory_Count = document.getElementById('Myhistory_Count_Desk');
//    Test.ObjectTest.ClearMyHistoryTestCount();
//    var teststarttime = document.getElementById('TestStartTime').value;
//    var testendtime = document.getElementById('TestEndTime').value;
//    MyHistory_Count.innerHTML = Test.ObjectTest.MyHistoryBind(0, teststarttime, testendtime).value;
//    MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryPageCount().value;
//    MyHistoryTestCountBound();
//    var teststartmin = document.getElementById('TestStartTime');
//    var teststartmax = document.getElementById('TestEndTime');
//    Test.ObjectTest.CleanMyHistoryTestInfo();
//    Test.ObjectTest.BindHistoryTestInfo(teststartmin.value, teststartmax.value);
//    var desk = document.getElementById('MyHistoryTestInfo_desk');
//    desk.innerHTML = Test.ObjectTest.HistoryTestInfoPageControl(0).value;
//    HistoryTestInfoPageCount = Test.ObjectTest.GetMyHistoryTestInfoPageCount().value;
//}