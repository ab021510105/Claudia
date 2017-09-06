var TestInfoPageIndex = 0;


function startTest(rid)
{
    pageindex = 0;
    Arequest('maindesk', "TIA/function/_TIA/TIA.aspx?stid=" + rid, true);
}

function reqLastPage()
{
    TestInfoPageIndex--;
    Arequest('maindesk', "TIA/function/testInfo.aspx?Pindex=" + TestInfoPageIndex, true);
}

function reqPage() {
    var select = document.getElementById('PageSelect');
    TestInfoPageIndex = select.options[select.selectedIndex].value;
    Arequest('maindesk', "TIA/function/testInfo.aspx?Pindex=" + TestInfoPageIndex, true);
}
function reqNextPage()
{
    TestInfoPageIndex++;
    Arequest('maindesk', "TIA/function/testInfo.aspx?Pindex=" + TestInfoPageIndex, true);
}

function doTestInfo()
{
    TestInfoPageIndex = 0;
    Arequest('maindesk', "TIA/function/testInfo.aspx?Pindex=" + TestInfoPageIndex, true);
}