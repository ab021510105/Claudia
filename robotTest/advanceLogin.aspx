<%@ Page Language="C#" AutoEventWireup="true" CodeFile="advanceLogin.aspx.cs" Inherits="robotTest_advanceLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名：<asp:TextBox ID="UserID" runat="server"></asp:TextBox>
        <asp:Button ID="Cnfirm" runat="server" Text="确定" OnClick="Cnfirm_Click" />
    </div>
    </form>
</body>
</html>
