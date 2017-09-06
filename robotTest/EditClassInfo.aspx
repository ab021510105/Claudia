<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditClassInfo.aspx.cs" Inherits="EditClassInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link type="text/css" href="Desk/CSS/Froms.css" rel="stylesheet" />
    <script id="date" src="My97DatePicker/WdatePicker.js"></script>
    <link type="text/css" href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <table class="From" style="text-align:center ;width:100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr >
          <td style="text-align:right">  年级:&nbsp</td>
          <td style="text-align:left"><asp:DropDownList ID="CourseInfo_Drop" runat="server"></asp:DropDownList></td>
              <td style="text-align:right"> 班级名称:&nbsp</td>
               <td style="text-align:left"><input id="ClassName" runat="server" type="text" placeholder="班级名称" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">开班日期:&nbsp</td>
                <td style="text-align:left"><input id="OpenAnAccount" runat="server" type="text" onclick="WdatePicker()" /></td>
             <td style="text-align:right"> 星期:&nbsp</td>
                <td style="text-align:left"><input id="WEEK" runat="server" type="text" placeholder="这里填星期几上课" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">课时数:&nbsp;</td>
               <td style="text-align:left"> <input id="ClassTime" runat="server" type="text" placeholder="这里填课时数" /></td>
                 <td style="text-align:right"> 时间段:&nbsp</td>
                <td style="text-align:left"> <asp:DropDownList ID="MF_Dorp" runat="server">
                    <asp:ListItem Text="上午" Value="0"></asp:ListItem>
                    <asp:ListItem Text="下午" Value="1"></asp:ListItem>
                         </asp:DropDownList></td>
              
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align:right">  班级人数:&nbsp</td>
               <td style="text-align:left"><input id="RemainingNumber" runat="server" type="text" placeholder="这里只能填写数字" /></td>
                <td>

                </td>
                <td>

                </td>
            </tr>
            <tr>
                
                </tr>
            <tr>
                
               
            </tr>
            <tr>
               
            </tr>
            <tr style="text-align:right">
                <td></td>
                <td><asp:Button  ID="UpLoad" runat="server" Text="完成" OnClick="UpLoad_Click" CssClass="Button_S"/> </td>
            </tr>
       </table>
    </form>
</body>
</html>
