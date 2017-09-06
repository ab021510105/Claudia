<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestInfo.aspx.cs" Inherits="Teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="TIA/UI/CSS/StyleSheet.css" type="text/css" rel="stylesheet"/>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="TIA/UI/JS/Widget.js" type="text/javascript"></script>
    <script>
        document.onreadystatechange = function () {
            if (document.readyState == "complete") {
                var tab = document.getElementById('body1');
                tab.style.width = screen.width.toString()+"px";
                tab.style.height = screen.height.toString() + "px";
               
            }
        }
    </script>
    <title></title>
</head>
<body id="body1">
    <form id="form1" runat="server">
        <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img  style="height:100%; width:100%; border:0;" src="Desk/desk01.jpg"/>
        </div>
    <div id="longinfo" class="loginfo">
    <asp:LinkButton ID="UerName" runat="server" ForeColor="White"></asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="SignOut" runat="server" ForeColor="White">注销</asp:LinkButton>
    </div>
        <div style="text-align:center">
            <asp:Label runat="server" ID="DialogLabel"  ForeColor="Red">选填项目是带有*符号的</asp:Label>&nbsp;

        </div>
       <div style="border:1px solid black;width:50%;position:absolute;left:25%;background-color:rgba(245, 245, 245, 0.60)">
           <div>
               &nbsp;
           </div>
           <div>
               选择章节:&nbsp;<asp:CheckBoxList ID="SectionInfo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SectionInfo_SelectedIndexChanged"></asp:CheckBoxList>
           </div>
           <div>
               &nbsp;
           </div>
           <div>
               选择知识点:&nbsp<asp:CheckBoxList ID="KnowledgePointInfo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="KnowledgePointInfo_SelectedIndexChanged"></asp:CheckBoxList>
           </div>
           <div>
           &nbsp
               </div>
           <div>
               考试名称:&nbsp<asp:TextBox ID="TestName" runat="server" ></asp:TextBox> &nbsp <span style="color:red">*</span>
           </div>
           <div>
               &nbsp;
           </div>
           <div>
               题目数量:&nbsp<asp:TextBox runat="server" ID="TestCount"></asp:TextBox>
           </div>
           <div>
               &nbsp;
           </div>
           <div>
               每题分值:&nbsp<asp:TextBox runat="server" ID="TextScore"></asp:TextBox>
           </div>
           <div>
               &nbsp;
           </div>
           <div>
               开考时间:&nbsp<input id="TestStartDate" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" />到
               <input id="TestEndDate" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})" />
           </div>
           <div>
               &nbsp;
           </div>
           <div style="text-align:right">
               <asp:Button ID="Confirm" runat="server" Text="上传" CssClass="Button_S" OnClick="Confirm_Click"/>&nbsp
           </div>
       </div>
      <%--  <div id="PlaseWait" runat="server" visible="false" style="position:absolute;top:20%;left:25%">
            <asp:Image ID="img1" runat="server" ImageUrl="~/Desk/wait.png" />
        </div>--%>
    </form>
</body>
</html>
