<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassInfo.aspx.cs" Inherits="ClassInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        #SerachDiv {
            text-align: center;
        }
        .auto-style2 {
            width: 100%
        }
        .auto-style3 {
            width: 131px;
        }
        .auto-style4 {
            width: 234px;
        }
        .auto-style5 {
            width: 284px;
        }
        .auto-style6 {
            width: 89px;
        }
        .auto-style7 {
            width: 131px;
            height: 23px;
        }
        .auto-style8 {
            width: 234px;
            height: 23px;
        }
    </style>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style=" background-color: #F6F6F6 ;text-align:left " >

            <asp:Image ID="Image1" runat="server" Height="101px" Width="336px" ImageUrl="~/home-top_04.jpg" style="text-align: left" />

            班级信息<asp:LinkButton ID="AddCourse" runat="server" Text="添加课程" Visible="false" style="font-size: small" OnClick="AddCourse_Click"></asp:LinkButton>
        <div style="text-align:center">
            <div style="width:50%; margin:auto">
            <table class="auto-style2" border="1" id="AddCoursetd" runat="server" visible="false">
                <tr>
                    <td style="background-color: #0000FF" class="auto-style7"></td>
                    <td style="text-align: center; color: #FFFFFF; background-color: #0000FF" class="auto-style8">课程名</td>
                    <td style="text-align:center;color:#ffffff;background-color:#0000FF" class="auto-style8">课程人数</td>
                    <td style="text-align:center;color:#ffffff;background-color:#0000FF" class="auto-style8">课时长度</td>
                    <td style="text-align:center;color:#ffffff;background-color:#0000FF" class="auto-style8">课程价格</td>
                </tr>
                <tr>
                    <td style="text-align: center" class="auto-style3">
                        <asp:Button ID="Button2" runat="server" Text="添加" BackColor="Blue" ForeColor="White" OnClick="Button2_Click" style="height: 21px" />
                    </td>
                    <td class="auto-style4"><asp:TextBox ID="AddCourseNameText" runat="server" BorderStyle="None" Width="99%" BackColor="#f6f6f6" style="text-align: center"></asp:TextBox></td>
                    <td class="auto-style4">
                        <asp:TextBox ID="AddCourseCountText" runat="server" BorderStyle="None" Width="99%" BackColor="#f6f6f6" style="text-align: center"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="AddCourseHourseText" runat="server" BorderStyle="None" Width="99%" BackColor="#f6f6f6" style="text-align: center"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="AddCourseCostText" runat="server" BorderStyle="None" Width="99%" BackColor="#f6f6f6" style="text-align: center"></asp:TextBox>
                    </td>
                </tr>
            </table>
                </div>
            </div>
        </div>
       
        <div id="Admin" runat="server" visible="false">
             <div>
            &nbsp;
        </div>
            <div style="text-align:center">
            <table class="auto-style1" border="1" style="width:90%;margin:auto">
                <tr>
                    <td style="background-color: #0000FF" class="auto-style6">&nbsp;</td>
                    <td style="background-color: #0000FF; color: #FFFFFF; text-align: center;" class="auto-style5">课程名称</td>
                    <td style="background-color: #0000FF; text-align: center; color: #FFFFFF;">班级名称</td>
                    <td style="background-color: #0000FF; text-align: center; color: #FFFFFF;">可报名人数</td>
                    <td style="background-color: #0000FF; text-align: center; color: #FFFFFF;">开班日期</td>
                    <td style="background-color:#0000FF; text-align:center; color:#FFFFFF;">结班日期</td>
                    <td style="background-color:#0000FF; text-align:center; color:#FFFFFF;">单课程长度</td>
                    <td style="background-color: #0000FF; text-align: center; color: #FFFFFF;">任课老师</td>
                </tr>
                <tr>
                    <td style="text-align: center" class="auto-style6">
                        <asp:Button ID="Button1" runat="server" style="text-align: center" Text="添加"  ForeColor="White" BackColor="Blue" OnClick="Button1_Click"/>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="CourseText" runat="server" Width="99%" DataSourceID="SqlDataSource1" DataTextField="CourseName" DataValueField="Courseid" AutoPostBack="True" OnSelectedIndexChanged="CourseText_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=mssql.sql95.cdncenter.net;Initial Catalog=sq_robotedu ;Persist Security Info=True;User ID=sq_robotedu;Password=robotedu123" SelectCommand="SELECT [Courseid], [CourseName] FROM [CourseInfo] ORDER BY [Courseid]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:TextBox ID="ClassNameText" runat="server" Width="99%" BorderStyle="None" style="text-align: center" OnTextChanged="ClassNameText_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="RegistartionNumberText" runat="server" Width="99%" BorderStyle="None" style="text-align: center" ></asp:TextBox>
                    </td>
                    <td>
                        <input id="OpeningDateText"  runat="server" style="border-style: none; border-color: inherit; border-width: medium; width:99%; text-align: center;" onclick="WdatePicker()" />
                    </td>
                    <td>
                        <input id="CloseDateText"  runat="server" style="border-style:none; border-color:inherit;border-width:medium;width:99%; text-align:center;" onclick="WdatePicker()" />
                    </td>
                    <td>
                        <asp:TextBox ID="ClassTime"  runat="server" BorderStyle="None" Width="99%" style="text-align: center" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="TeacherText" runat="server" Width="99%"  style="text-align: center" DataSourceID="SqlDataSource4" DataTextField="TeacherName" DataValueField="Teacherid"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="Data Source=mssql.sql95.cdncenter.net;Initial Catalog=sq_robotedu ;Persist Security Info=True;User ID=sq_robotedu;Password=robotedu123" SelectCommand="SELECT [Teacherid], [TeacherName] FROM [TeacherInfo]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            </div>
        </div>
        <div style="text-align: center">
        <asp:Button ID="Serach" runat="server" Text="查找" style="font-size: small"  BackColor="Blue" ForeColor="White" OnClick="Serach_Click"></asp:Button>        
        </div>
        <div id="SerachDiv" runat="server" visible="false">

            课程名:<asp:DropDownList ID="CourseInfo" runat="server" Height="25px" Width="131px" DataSourceID="SqlDataSource1" DataTextField="CourseName" DataValueField="Courseid">
                <asp:ListItem Selected="True"></asp:ListItem>
            </asp:DropDownList>&nbsp;开班日期:<input id="SerachDate" runat="server"  onclick="WdatePicker()" />&nbsp; 任课老师:<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="TeacherName" DataValueField="Teacherid" Height="26px" Width="137px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=mssql.sql95.cdncenter.net;Initial Catalog=sq_robotedu ;Persist Security Info=True;User ID=sq_robotedu;Password=robotedu123" SelectCommand="SELECT [Teacherid], [TeacherName] FROM [TeacherInfo]"></asp:SqlDataSource>
            &nbsp;<asp:Button ID="Ok" runat="server" Text="确定" BackColor="Blue" BorderColor="Blue" ForeColor="White" OnClick="Ok_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="font-size: small">返回</asp:LinkButton>
        </div>
    </div>
        <div>

        </div>
        <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor ="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" AllowPaging="True" OnRowDeleted="GridView1_RowDeleted" style="text-align: center" DataKeyNames="Classid" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="课程名" SortExpression="CourseName" />
                <asp:BoundField DataField="CourseCost" HeaderText="课程价格" SortExpression="CourseCost" />
                <asp:BoundField DataField="ClassName" HeaderText="班级名" SortExpression="ClassName" />
                <asp:BoundField DataField="RemainingNumber" HeaderText="可报名人数" SortExpression="RemainingNumber" />
                <asp:BoundField DataField="ClassHour" HeaderText="课时" SortExpression="ClassHour" />
                <asp:TemplateField HeaderText="上课时间" SortExpression="ClassTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ClassTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ClassTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结班时间" SortExpression="CloseAnAccount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CloseAnAccount") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CloseAnAccount", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开班时间" SortExpression="OpenAnAccount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OpenAnAccount") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("OpenAnAccount", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
          
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=mssql.sql95.cdncenter.net;Initial Catalog=sq_robotedu ;Persist Security Info=True;User ID=sq_robotedu;Password=robotedu123" SelectCommand="SELECT CourseInfo.CourseName, [Class Info].ClassName, [Class Info].RemainingNumber, CourseInfo.ClassHour, CourseInfo.CourseCost, [Class Info].ClassTime, [Class Info].CloseAnAccount, [Class Info].OpenAnAccount ,[Class Info].Classid FROM [Class Info] INNER JOIN CourseInfo ON [Class Info].Courseid = CourseInfo.Courseid ,TCrelationship Where [Class Info].Classid!=0" DeleteCommand="DELETE FROM [Class Info] Where Classid=@Classid">
            <DeleteParameters>
                <asp:Parameter Name="Classid" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
