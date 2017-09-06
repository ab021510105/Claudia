<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wTest.aspx.cs" Inherits="wTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Image ID="inamd" runat="server" />
    </div>
        <asp:Button ID="Btn1" runat="server" Text="Btn" OnClick="Btn1_Click" />
    </form>
</body>
</html>
