<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryToPreview.aspx.cs" Inherits="TryToPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="TIA/UI/CSS/StyleSheet.css" />
    <script src="TIA/UI/JS/listcontrol.js"></script>
    <link rel="stylesheet" href="Desk/CSS/Froms.css" />
    <script src="My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="text" value="" runat="server" style="display:none" id="SelectionBuf" />
        <input type="text" value="" runat="server" style="display:none" id="ReturnBuf" />
     <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img  style="height:100%; width:100%; border:0;" src="Desk/desk01.jpg"/>
        </div>
        <div class="From">
            <div>
                <table>
                    <tr>
                        <td>
                考试名称:<input id="TestName" runat="server" type="text" placeholder="这里填写考试名称(选填)" />&nbsp;
                考试时间:<input id="TestStartTime" runat="server" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" placeholder="点击就可输入" />到
                <input id="TestEndTime" runat="server" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" placeholder="点击就可输入" />&nbsp;
                每题分数:<input id="TopicScore" runat="server" type="text" placeholder="这里选填（大概吧)" />
                        </td>
                        <td style="text-align:right">
                            <asp:Button ID="ToMould" runat="server" Text="使用模板" OnClick="ToMould_Click" CssClass="Button_S" />

                        </td>
                    </tr>
                </table>
            </div> 
            <table style="width:100%;text-align:center;background-color:white" id="testinfo">
         
            </table>
        </div> 
          <div style="text-align:right">
                <asp:Button ID="BtnConfirm" runat="server" Text="完成" CssClass="Button_L" OnClick="BtnConfirm_Click" />
            </div>
    </form>
   
</body>
</html>
