function GetTest(id)
{
    pageindex = 0;
    var tid = 'maindesk';
    var st = document.getElementById("startTime").value;
    var et = document.getElementById("endTime").value;
    Arequest(tid, "TIA/function/TestHisInfo/HTIAT.aspx?tsid="+id+"&et="+et+"&st="+st, true);
}
function GetInfo()
{
    pageindex = 0;
    var tid = 'maindesk';
    var st = document.getElementById("startTime").value;
    var et = document.getElementById("endTime").value;
    var uid = document.getElementById("userid").value;
    Arequest(tid, "TIA/function/TestHisInfo/main.aspx?uid=" + uid + "&et=" + et + "&st=" + st, true);
}


function HtiaBack()
{
    pageindex = 0;
    var tid = 'maindesk';
    var uid = document.getElementById("userid").value;
    var stime = document.getElementById("stime").value;
    var etime = document.getElementById("etime").value;
    Arequest(tid, "TIA/function/TestHisInfo/main.aspx?uid=" + uid+"&et="+etime+"&st="+stime, true);
}

function SeeMore(id)
{
    var contentid = id + "more";
    var content = document.getElementById(contentid);
    var classname = content.className;
    if (classname=="void") {
        Arequest(contentid, "TIA/function/TestHisInfo/MoreInfo.aspx?tsid=" + id, true);
        content.className = "m_actived";
    }
    else if (classname == "m_actived") {
        content.className = "onHide";
        content.style.display = "none";
    }
    else if (classname == "onHide")
    {
        content.className = "m_actived";
        content.style.display = "block";
    }
}

var pageindex = 0;

function pageChanging(pCount)
{
    var _page = document.getElementById("page" + pageindex);
    var selt = document.getElementById("PageSelect");
    //selt.options[self.selectedIndex].selected = false;
    selt.options[pageindex].selected = true;
    for(i=0;i<pCount;i++)
    {
        var p = document.getElementById("page" + i);
        p.style.display = "none";
      

    }
    _page.style.display = "block";
    if (  parseInt(pageindex) + 1 == pCount) {
        document.getElementById("PageNextBtn").disabled = true;
    }
    else {
        document.getElementById("PageNextBtn").disabled = false;
    }
    if (pageindex == 0) {
        document.getElementById("PageFrontBtn").disabled = true;
    }
    else {
        document.getElementById("PageFrontBtn").disabled = false;
    }
    
}

function ThNextPageClick()
{
    
    //page.style.display = "none";
    var pageCount = document.getElementById("PageCount").innerHTML;
    pageindex++;
    
    pageChanging(pageCount);

}

function ThFontClick()
{
    var pageCount = document.getElementById("PageCount").innerHTML;
    pageindex--;
    
    pageChanging(pageCount);

}

function PageSelectedChange()
{
    var sel=document.getElementById("PageSelect");
    pageindex =sel.options[sel.selectedIndex].value;
    var pCount = document.getElementById("PageCount").innerHTML;
    pageChanging(pCount);

}