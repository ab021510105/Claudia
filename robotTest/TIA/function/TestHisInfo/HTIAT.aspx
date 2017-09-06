<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HTIAT.aspx.cs" Inherits="robotTest_TIA_function_TestHisInfo_HTIAT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1024px;margin-top:10px; text-align:left;margin-left:auto;margin-right:auto">    
        <input id="stime" runat="server" type="hidden" />
        <input id="etime" runat="server" type="hidden" />
        <a href="javascript:void(0);" style="color:gray" onclick="HtiaBack()">返回</a>
        <div style="width:98%;margin:auto">
            
            <%=echo %>
            <div style="width:100%;text-align:right; height:25px;line-height:25px">
                <input type="button" value="上一页" style="margin-right:6px" onclick="ThFontClick()" id="PageFrontBtn" disabled="disabled" />
                <select id="PageSelect" runat="server" onchange="PageSelectedChange()">
                   
                </select>
                /<asp:Label ID="PageCount" runat="server" Text="10"></asp:Label>
                <input type="button" value="下一页"  style="margin-left:6px" onclick="ThNextPageClick()" id="PageNextBtn" runat="server"/>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
