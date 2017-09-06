<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistributionOfTheClass.aspx.cs" Inherits="DistributionOfTheClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script src="TIA/UI/JS/Widget.js" type="text/javascript"></script>
    <link href="TIA/UI/CSS/StyleSheet.css" type="text/css" rel="stylesheet"/>
    <script>
        document.onreadystatechange = function () {
            if (document.readyState == "complete") {
                var tab = document.getElementById('body1');
                tab.style.width = screen.width.toString() + "px";
                tab.style.height = screen.height.toString() + "px";

            }
        }
    </script>
</head>
<body id="body1">
    <form id="form1" runat="server">
        <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
            </div>
        <div id="longinfo" class="loginfo">
    <asp:LinkButton ID="UerName" runat="server" ForeColor="White"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="SignOut" runat="server" ForeColor="White">注销</asp:LinkButton>
    </div>
    <div style="border:1px solid black;width:50%;position:absolute;left:25%;background-color:rgba(245, 245, 245, 0.60);text-align:center">
    <div>
        &nbsp;
    </div>
        <div style="text-align:left">
            年级:&nbsp;<asp:DropDownList ID="CouresInfo" runat="server"  OnSelectedIndexChanged="CouresInfo_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div>
            &nbsp;
        </div>
        <div style="text-align:left">
            班级:&nbsp;<asp:CheckBoxList ID="Classes" runat="server"  OnSelectedIndexChanged="Classes_SelectedIndexChanged"  ></asp:CheckBoxList>
        </div>
        <div>
            &nbsp;
        </div>
        <div style="text-align:right">
            <asp:Button ID="Upload" runat="server"  Text="完成" OnClick="Upload_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
