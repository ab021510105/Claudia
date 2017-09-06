<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
        .auto-style2 {
            width: 70%;
            background-color: #F6F6F6;
            margin:auto;
        }
         .auto-style4 {
             width: 100%;
         }
         .auto-style5 {
             color: #3333FF;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
         <div style=" width:70%; background-color: #F6F6F6 ;margin:auto;text-align:left " >

            <asp:Image ID="Image1" runat="server" Height="101px" Width="336px" ImageUrl="~/home-top_04.jpg" style="text-align: left" />

            <span class="auto-style2"><strong>管理员模式<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="font-size: small">返回主页</asp:LinkButton>
             </strong></span></div>
            </div>
        <div style="text-align:center">
            <div style="width:70%;margin:auto;background-color:#F6F6F6">

            </div>
            <div class="auto-style2">

                <table class="auto-style4">
                    <tr>
                        <td>&nbsp;</td>
                        <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text="Label"  Visible="false" style="color: #CC0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:45%; text-align: right;" class="auto-style5">用户名:</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                     <td>

                         &nbsp;&nbsp;</td>
                        <td>

                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style5">ID:</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox2" runat="server" style="text-align: left" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            &nbsp;&nbsp;</td>
                        <td>

                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style5">密码:</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox3" runat="server" style="text-align: left" TextMode="Password" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            &nbsp;&nbsp;</td>
                        <td>

                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="text-align: right">

                            确认密码:</td>
                        <td style="text-align: left">

                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>

                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="Button1" runat="server" style="text-align: right" Text="添加" BackColor="Blue" ForeColor="White" OnClick="Button1_Click"/>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
