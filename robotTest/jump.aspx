<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jump.aspx.cs" Inherits="jump" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        var i = 3;
        function CheckOut()
        {
            var url = document.getElementById('labelinfo').innerText;
            document.getElementById('label1').innerText = i;
            i--;
            if (i <= 0)
            {
                window.location.href = url;
            }
            setTimeout(CheckOut, 1000);
        }
        document.onreadystatechange=function()
        {
            if(document.readyState=="complete")
            {
                CheckOut();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <label style="display:none" id="labelinfo" runat="server"></label>
    <div>
    正在完成操作剩余时间<label id="label1" style="color:red"></label>秒
    </div>
    </form>
</body>
</html>
