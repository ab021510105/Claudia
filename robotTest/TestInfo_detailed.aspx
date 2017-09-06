<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestInfo_detailed.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Desk/CSS/Froms.css" rel="stylesheet" type="text/css" />
    <script src="TIA/UI/JS/Widget.js"></script>
    <link href="TIA/UI/CSS/StyleSheet.css"  rel="stylesheet" type="text/css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
         <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div style="text-align:right;background-color:rgba(0, 38, 255, 0.37)" class="landInfo">
            <asp:Label ID="landinfo" runat="server" ForeColor="White" ></asp:Label>
            </div>
        <div id="Back" style="text-align:right"><asp:LinkButton ID="TrunBack" runat="server" Text="返回" OnClick="TrunBack_Click" ForeColor="White"></asp:LinkButton></div>
        <div id="TestInfo_Div" runat="server" >
            <div style="background-color:rgba(8, 15, 148, 0.70);color:white" id="titel"><asp:Label ID="TestInfo_Titel" runat="server" ForeColor="White"></asp:Label></div>
            <div class="From" style="background-color:white">
            <%=Quiz_Table_B %>
               
                <div style="text-align:center" id="TitaPager" runat="server" visible="false">
                    <asp:Button ID="FrontButton" runat="server" Text="上一页" CssClass="Button_S" OnClick="FrontButton_Click" />&nbsp;
                    <asp:Button ID="NextButton" runat="server" Text="下一页" CssClass="Button_S" OnClick="NextButton_Click"/>&nbsp;
                    <asp:Label ID="pageCount" runat="server" Text=""></asp:Label>
                </div>
                <div style="text-align:center" id="TitaPager_w" runat="server" visible="false">
                    <asp:Button ID="Tita_FrontButton" runat="server" Text="上一页" CssClass="Button_S" OnClick="Tita_FrontButton_Click" />&nbsp;
                    <asp:Button ID="Tita_NextButton" runat="server" Text="下一页" CssClass="Button_S" OnClick="Tita_NextButton_Click"/>&nbsp;
                    <asp:Label ID="Tiata_Pagecount" runat="server" Text=""></asp:Label>
                </div>
                </div>
        </div>
    </form>
</body>
</html>
