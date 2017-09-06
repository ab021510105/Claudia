<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Historycount.aspx.cs" Inherits="robotTest_TIA_function_Historycount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function err() {
            document.getElementById("desk").innerHTML = "<img src=\"Desk/Error.PNG\" />";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="desk" style="width:100%;height:100%">
    <div id="TestCount" style="width:100%;background-color:black;color:white;border-radius:15px 15px 0px 0px;text-align:center">
        <asp:Label ID="Title" runat="server"></asp:Label>
        <asp:GridView ID="TestCountGV" runat="server" Width="100%" Height="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="True" AllowPaging="True" PageSize="10">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"/>
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            <PagerSettings Visible="false" />
            
        </asp:GridView>
    </div>
        <div>
            &nbsp;
        </div>
        <div style="width:100%;background-color:black;color:white;border-radius:15px 15px 0px 0px;text-align:center">
                        <asp:Label ID="TopicInfo_w_title" runat="server">错误归纳</asp:Label> 
            <div style="width:100%-1px;background-color:white;color:black; border:1px solid black" id="TopicInfo_w" runat="server">
                <div id="p0" style="text-align:left;">
                    <div class="Topic" style="font-size:125%">
                        1.Topic
                    </div>
                    <div class="Options" style="border:1px solid white">
                       &nbsp;A,Optent1
                    </div>
                    <div class="Options" style="border:1px solid white;">
                        &nbsp;B,Optent2
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
