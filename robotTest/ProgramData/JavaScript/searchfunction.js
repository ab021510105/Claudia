function searchHistoryInf0() {
    var MyHistory_Count = document.getElementById('Myhistory_Count_Desk');
    Test.ObjectTest.ClearMyHistoryTestCount();
    var teststarttime = document.getElementById('TestStartTime').value;
    var testendtime = document.getElementById('TestEndTime').value;
    MyHistory_Count.innerHTML = Test.ObjectTest.MyHistoryBind(0, teststarttime, testendtime).value;
    MyHistoryTestPageCount = Test.ObjectTest.GetMyHistoryPageCount().value;
    MyHistoryTestCountBound();
    var teststartmin = document.getElementById('TestStartTime');
    var teststartmax = document.getElementById('TestEndTime');
    Test.ObjectTest.CleanMyHistoryTestInfo();
    Test.ObjectTest.BindHistoryTestInfo(teststartmin.value, teststartmax.value);
    var desk = document.getElementById('MyHistoryTestInfo_desk');
    desk.innerHTML = Test.ObjectTest.HistoryTestInfoPageControler(0).value;
    HistoryTestInfoPageCount = Test.ObjectTest.GetMyHistoryTestInfoPageCount().value;
    HistoryTestInfoBound();
}