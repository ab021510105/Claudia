<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <link href="Desk/CSS/Froms.css" rel="stylesheet" />
    <script src="TIA/UI/JS/Widget.js"></script>
    <style>
        .text_box {
            width: 100%;
	height: 40px;
	border: none;
	text-indent: 5px;
	border-radius: 1px;
	transition: all 300ms;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div class="From" style="text-align:center ;width:100%">
            <table style="width:100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;width:50%">
                      Your UserID:
                    </td>
                    <td style="text-align:left">
                        <div style="width:250px">
                        <input type="text" id="Userid" runat="server" class="text_box"/>
                         </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr style="text-align:right">
                    <td>
                        Youer Old Password:
                    </td>
                    <td style="text-align:left">                       
                         <asp:Label ID="errorOldPasss" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                        <div style="width:250px">
                        <input type="password" id="OldPassword" runat="server" class="text_box" />
                         </div> 

                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        Your New Passworld:
                    </td>
                    <td>
                        <div style="width:250px">
                            <input type="password" id="NewPasssword" runat="server" class="text_box" />
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        Confirm Your New Pssword:
                    </td>
                    <td style="text-align:left">
                        <asp:Label ID="ConPassordError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                        <div style="width:250px">
                            <input type="password" id="CNewPssword" runat="server" class="text_box" />

                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div style="text-align:center">
                <asp:Button ID="Done" runat="server" Text="Done" CssClass="Button_L" OnClick="Done_Click" />
            </div>
        </div>

    </form>
</body>
</html>
