<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditConsluting.aspx.cs" Inherits="AddConsluting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link type="text/css" href="Desk/CSS/Froms.css" rel="stylesheet" />
    <script id="date" src="My97DatePicker/WdatePicker.js"></script>
    <script id="textbox" src="Desk/Js/TextBox.js"></script>
    <script>
        //onreadystatechange = function () {
        //    if (document.readyState == "complete") {
        //        var tr = document.getElementsByTagName('tr');
        //        for (i = 0; i < tr.length; i++) {
        //            tr[i].style.color = "Blue";
        //            if (i % 2 == 0) {
        //                tr[i].style.backgroundColor = "White";
        //            }
        //            else {
        //                tr[i].style.backgroundColor = "#38cdfe";
        //            }
        //        }
        //    }
        //}
    </script>
    <title>Editing</title>
    <style type="text/css">
        .auto-style1 {
            color: #CC0000;
        }
        .auto-style2 {
            color: #FF0000;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div style="text-align:right;background-color:rgba(0, 38, 255, 0.37)">
            <asp:Label ID="landinfo" runat="server" ForeColor="White" ></asp:Label>
        </div>
        <div style="text-align:right;">
            <asp:LinkButton ID="return" runat="server" ForeColor="White" OnClick="return_Click">返回</asp:LinkButton>
        </div>
        <div class="From">
            <div class="HeaderTitle"><asp:Label  ID="headertitel" runat="server"></asp:Label></div>
            <table style="width:100%">
                <tr>
                    <td style="text-align:right">
                        班级:
                    </td>
                    <td>
                        <asp:DropDownList ID="ClassInfo_Dorp" runat="server"></asp:DropDownList><span class="auto-style1">*</span>
                    </td>
                </tr>
             <tr>
                 <td style="text-align:right">
                     咨询孩子姓名：
                 </td>
                 <td>
                     <a><input type="text" id="Children_Call" class="TextBox_1" runat="server" placeholder="这里输入孩子姓名" /></a>
                 </td>
             </tr>
                <tr>
                    <td style="text-align:right">
                         咨询家长称呼：
                    </td>
                    <td>
                        <input type="text" id="Parent_Call" class="TextBox_1" runat="server" placeholder="这里输入家长称呼"/>
                    <span class="auto-style1">*</span></td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        孩子年龄：
                    </td>
                    <td>
                        <input type="text" id="Age" class="TextBox_1" runat="server"  placeholder="这里只允许输入数字" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        孩子年级：
                    </td>
                    <td>
                        <input type="text" id="ClassLV" runat="server" class="TextBox_1" placeholder="输入年级(可以是中文)" />
                    <span class="auto-style2">*</span></td>
                </tr>
                <tr>
                    <td style="text-align:right" class="auto-style3">
                        孩子性别：
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="Sex" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        在读学校：
                    </td>
                    <td>
                        <input type="text" id="School" runat="server" class="TextBox_1" placeholder="输入孩子在上的学校" />
                    <span class="auto-style2">*</span></td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        联系电话：
                    </td>
                    <td>
                        <input type="text" id="Contact" runat="server" class="TextBox_1"  placeholder="最好输入家长联系方式" />
                    <span class="auto-style2">*</span></td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        上门时间：
                    </td>
                    <td>
                        <input type="text" id="arrive" runat="server" onclick="WdatePicker()" placeholder="点击这里就可以选择时间" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        咨询渠道:
                    </td>
                    <td>
                        <asp:DropDownList ID="Cannel" runat="server" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        备注:
                    </td>
                    <td>
                        <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" CssClass="TextBox_1"></asp:TextBox>                        
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td style="text-align:right">
                        <asp:Button ID="Confirm" runat="server" Text="确定" OnClick="Confirm_Click" />&nbsp;
                        <asp:Button ID="Cancel" runat="server" Text="重置" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
