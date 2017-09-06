<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TIA.aspx.cs" Inherits="robotTest_TIA_function__TIA_TIA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:98%;margin:auto;text-align:left">
            <input id="testid" type="hidden" value="" runat="server" />
            <input id="_stid" type="hidden" value="" runat="server" />
        <%--<div onclick="" onmouseover="" onmouseout="" title="unselected" style="color:#ff6a00" ></div>--%>
            <%=echo %>
            <div style="width:100%;text-align:right; height:25px;line-height:25px">
                <input type="button" value="上一页" style="margin-right:6px" onclick="ThFontClick()" id="PageFrontBtn" disabled="disabled" />
                <select id="PageSelect" runat="server" onchange="PageSelectedChange()">
                   
                </select>
                /<asp:Label ID="PageCount" runat="server" Text="10"></asp:Label>
                <input type="button" value="下一页"  style="margin-left:6px;margin-right:30px" onclick="ThNextPageClick()" id="PageNextBtn"/>
                <input type="button" value="完成" onclick="OnUpLoad()"/>
            </div>
        </div>
    </form>
</body>
</html>
