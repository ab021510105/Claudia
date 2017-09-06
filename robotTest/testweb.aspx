<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testweb.aspx.cs" Inherits="testweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList ID="list" runat="server" Height="35px" Width="166px" OnSelectedIndexChanged="list_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
    </div>
        <div>
            SqlCommand
        </div>
        <div>
            <asp:TextBox ID="command" runat="server" TextMode="MultiLine" Height="138px" Width="541px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="button1" runat="server" Text="执行" OnClick="button1_Click" />&nbsp
            <asp:Button ID="Button2" runat="server" Text="查询列" OnClick="Button2_Click" />
        </div>
        <div>
            <asp:Label ID="l1" runat="server" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="gridview1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="171px" Width="556px" AllowPaging="True" OnPageIndexChanging="gridview1_PageIndexChanging">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
      
    </form>
</body>
</html>
