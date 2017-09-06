<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllocationStudent.aspx.cs" Inherits="AllocationStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Desk/CSS/Froms.css" rel="stylesheet" />
    <link href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <script src="TIA/UI/JS/Widget.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div id="UserInfo" style="text-align:right;background-color:rgba(0, 38, 255, 0.37);color:white">
            <asp:Label ID="UserInfoTitel" runat="server" Text="Info"></asp:Label>
        </div>
        <div style="text-align:right">
           <asp:LinkButton ID="BackUp" runat="server" Text="返回"  OnClick="BackUp_Click"></asp:LinkButton>
        </div>
        <div class="From" style="text-align:center">
            <div class="HeaderTitle">
                请为<asp:label ID="ClassName_Label" runat="server" ></asp:label>添加学生
            </div>
           <asp:GridView ID="GW1" runat="server" Width="100%" Height="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="true" AutoGenerateColumns="false" OnPageIndexChanging="GW1_PageIndexChanging" OnRowDataBound="GW1_RowDataBound" OnRowCreated="GW1_RowCreated" OnRowCommand="GW1_RowCommand">
               <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
               <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
               <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
               <RowStyle BackColor="White" ForeColor="#003399" />
               <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SortedAscendingCellStyle BackColor="#EDF6F6" />
               <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
               <SortedDescendingCellStyle BackColor="#D6DFDF" />
               <SortedDescendingHeaderStyle BackColor="#002876" />
               <Columns>
                   <asp:TemplateField>
                       <ItemTemplate>
                           <asp:CheckBox ID="CheckBox" runat="server"   AutoPostBack="true" OnCheckedChanged="CheckBox_CheckedChanged"/>
                           <asp:Label ID="label1" runat="server" Text='<%#Eval("Contactid") %>' Visible="false"></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="ChildrenCall" HeaderText="学生姓名" />
                   <asp:BoundField DataField="Contactid" HeaderText="账号" />
               </Columns>
           </asp:GridView>
            <div style=" text-align:right">
                <asp:Button ID="Confrim" runat="server" Text="完成" OnClick="Confrim_Click" CssClass="Button_L"/>

            </div>
        </div>
    </form>
</body>
</html>
