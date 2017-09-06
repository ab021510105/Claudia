<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="robotTest_TIA_function_TestHisInfo_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../../../My97DatePicker/My97DatePicker/WdatePicker.js"></script>
   <%-- <script src="ThControl.js"></script>--%>
    <script src="../../../ajaxrequest/jquery-3.1.1.js"></script>
    
    <title></title>
    <%--<script>
        function selection()
        {
            var p = document.getElementById("PageSelect");
            p.options[0].selected = false;
            p.selectedIndex;
            p.disabled = true;
            p.options[p.selectedIndex].value;
            
        }
    </script>--%>
   
  
</head>
<body>
    <form id="form1" runat="server"> 
    <div style="margin:auto;width:1024px">
     <div id="TimeClube" style="color:gray;height:20px;margin:10px">
         时间：<input id="startTime" runat="server" type="text" onclick="WdatePicker({dataFmt:'yyyy-MM-dd HH:mm'})" style="margin:5px" />到
         <input id="endTime" runat="server" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" style="margin:5px" /><input type="button" value="确定" runat="server"  onclick="GetInfo()"/>
     </div>
        <div style="color:gray;border:1px solid gray"  >
            <div id="TestInfoList" runat="server" style="width:100%;">
            <%=echo %>
                 
            <div style="width:100%;text-align:right; height:25px;line-height:25px">
                <input type="button" value="上一页" style="margin-right:6px" onclick="ThFontClick()" id="PageFrontBtn" disabled="disabled" runat="server" />
                <select id="PageSelect" runat="server" onchange="PageSelectedChange()">
                   
                </select>
                /<asp:Label ID="PageCount" runat="server" Text="10"></asp:Label>
                <input type="button" value="下一页"  style="margin-left:6px" onclick="ThNextPageClick()" id="PageNextBtn" runat="server"/>
            </div>
        </div>
            </div>
        </div>
    </form>
</body>
</html>
