<%@ Page Language="C#" AutoEventWireup="true" CodeFile="historyTestInfo.aspx.cs" Inherits="robotTest_TIA_function_historyTestInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../ajaxrequest/arequest/ajax.js"></script>
    <script>
        var Gv1Pindex = 0;
        var Gv2Pindex = 0;
        var Gv2disIndex = 0;
        function hgetUID() {
            return document.getElementById('userid_lable').innerHTML;
        }
        function noGv1nextBtnClick() {
            Gv1Pindex++;
            OnGV1PageChanging();
        }
        function noGv1LastBtnClick() {
            Gv1Pindex--;
            OnGV1PageChanging();
        }
        function OnGV1PageChanging() {
            var Pcount = document.getElementById("Gv1pageCount").value;
            var NextBtn = document.getElementById("Gv1NextBtn");
            var FontBtn = document.getElementById("Gv1LastBtn");
            var Gv1counter = document.getElementById("Gv1count");
            if(Gv1Pindex+1==Pcount){
                NextBtn.disabled = true;
            }
            else
            {
                NextBtn.disabled = false;
            }
            if (Gv1Pindex == 0) {
                FontBtn.disabled = true;
            }
            else {
                FontBtn.disabled = false;
            }
            Gv1counter.innerHTML = Pindex + "/" + Pcount;
            var tablesId = "Gv1P" + Pindex;
            var table = document.getElementById(tablesId);
            table.style.display = "";
            var ntable = document.getElementById("Gv1P" + (Gv1Pindex - 1));
            if (ntable != null) {
                ntable.style.display = "none";
            }
            ntable = document.getElementById("Gv1P" + (Gv1Pindex + 1));
            if (ntable != null) {
                ntable.style.display = "none";
            }
        }
        function OnTodayClick() {            
            Arequest("desk", "TIA/function/historyTestInfo.aspx?UID" + hgetUID() + "&Today=1", true);
        }
        function OnSearchClick() {
            var tSt = document.getElementById('TestStartTimeTextFront').value;
            var tEt = document.getElementById('TestStartTimeTextRoot').value;
            Arequest("desk", "TIA/function/historyTestInfo.aspx?UID" + hgetUID() + "&TStart=" + tSt + "&TEnd="+tEt, true);
        }
        function OnWeekClick() {
            Arequest("desk", "TIA/function/historyTestInfo.aspx?UID" + hgetUID() + "&Week=1", true);
        }
        function OnMonthClick() {
            Arequest("desk", "TIA/function/historyTestInfo.aspx?UID" + hgetUID() + "&Month=1", true);
        }
        function GetHistoryTest(RelationshipID) {
            Arequest("desk", "TIA/function/HTIA.aspx?RID=" + RelationshipID, true);
        }
        function GetHistoryInfo(RelationshipID) {

        }
        function OnGv2NextClick() {
            Gv2disIndex=Gv2Pindex++;
            OnGv2Changing();
        }
        function OnGv2LastClick() {
            Gv2disIndex=Gv2Pindex--;
            OnGv2Changing();
        }
        function OnGv2SelectChanged() {
            var s = document.getElementById('Gv2Select');
            Gv2Pindex = parseInt(s.options[s.selectedIndex].value);
            OnGv2Changing();
        }
        function OnGv2Changing() {
            var Pcount = document.getElementById('Gv2pageCount').value;
            var s = document.getElementById('Gv2Select');
            var counter = document.getElementById('Gv2Counter');
            var lastBtn = document.getElementById('Gv2LastBtn');
            var nextBtn = document.getElementById('Gv2NextBtn');
            counter.innerHTML = Pcount + "";
            s.selectedIndex = Gv2Pindex;
            if (Gv2Pindex + 1 == Pcount) {
                nextBtn.disabled = true;
            }
            else {
                nextBtn.disabled = false;

            }
            if (Gv2Pindex == 0) {
                lastBtn.disabled = true;
            }
            else {
                lastBtn.disabled = false;
            }
            document.getElementById(('Gv2P' + Gv2disIndex)).style.display = "none";
            document.getElementById(('Gv2P' + Gv2Pindex)).style.display = "";
        }
    </script>
    <%--<style>
         table{
            border-collapse:collapse;
            border-spacing:0;
            border-left:1px solid #888;
            border-top:1px solid #888;
            background:#efefef;}
        th,td
        {
            border-right:1px solid #888;
             border-bottom:1px solid #888;
             padding:5px 15px;
        }
        th
        {
            font-weight:bold;background:#ccc;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        
        <div style="width:98%;color:#808080;text-align:center">
    <div id="Searchdiv" style="text-align:left;border-bottom:1px solid #dbd9d9;">
    时间段:<input type="text"  value="" onclick="WdatePicker()" id="TestStartTimeTextFront" runat="server"/>&nbsp~&nbsp;
        <input type="text" value="" onclick="WdatePicker()" id="TestStartTimeTextRoot" runat="server" />&nbsp;
        <input type="button" value="检索" style=" background: -ms-linear-gradient(top,#ffffff,#e6e2e2);  border-radius: 5px;border:1px solid #808080; "  id="Search_bnt" onclick="OnSearchClick()"/>
        <div style="height:2px">&nbsp;</div>
         <input type="button" value="今天" style=" background: -ms-linear-gradient(top,#ffffff,#e6e2e2);  border-radius: 5px;border:1px solid #808080; "  id="Search_today_bnt" onclick="OnTodayClick()"/>
         <input type="button" value="这个星期" style=" background: -ms-linear-gradient(top,#ffffff,#e6e2e2);  border-radius: 5px;border:1px solid #808080; "  id="Search_Weeek_bnt" onclick="OnWeekClick()" />
         <input type="button" value="这个月" style=" background: -ms-linear-gradient(top,#ffffff,#e6e2e2);  border-radius: 5px;border:1px solid #808080; "  id="Search_Month_bnt" onclick="OnMonthClick()"/>
        <div style="height:1px">
            &nbsp;
        </div>
    </div>
            <div style="width:100%;background-color:black;color:white;border-radius:15px 15px 0px 0px;">
             <%--   练习汇总
                <table style="width:100%;background-color:white; border:1px solid gray;border-spacing:0px" border="1"  >
                    <tr>
                        <th>
                            test
                        </th>
                        <th>
                            test2
                        </th>
                        <th>
                            test3
                        </th>
                    </tr>

                </table>--%>
            <%=Gv1  %>
                <div style="text-align:right">
                    <input type="button" value="上一页" disabled="disabled" id="Gv1LastBtn" onclick="noGv1LastBtnClick()"/>&nbsp;
                    <a id="Gv1count" runat="server">1/2</a>&nbsp;
                    <input type="button" value="下一页" id="Gv1NextBtn" onclick="noGv1nextBtnClick()" />
                </div>
            </div>
            <div>
                &nbsp;
            </div>

            <div style="width:100%;background-color:black;color:white;border-radius:15px 15px 0px 0px;">
                历史练习
              <%=Gv2 %>
                <div style="text-align:right">
                    <input type="button" value="上一页" disabled="disabled" id="Gv2LastBtn" onclick="OnGv2LastClick()"/>&nbsp;
                    <select id="Gv2Select" runat="server" onchange="OnGv2SelectChanged()">
                        <option value="0" selected="selected">1</option>
                        <option value="1">2</option>
                    </select>/<a id="Gv2Counter" runat="server">10</a>&nbsp;
                    <input type="button" value="下一页"  id="Gv2NextBtn" onclick="OnGv2NextClick()"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
