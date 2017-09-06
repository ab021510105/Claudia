<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .style2 {
            text-align: center; color: #FFFFFF; background-color: #0000FF
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style=" background-color: #F6F6F6 ;text-align:left " >

            <asp:Image ID="Image1" runat="server" Height="101px" Width="336px" ImageUrl="~/home-top_04.jpg" style="text-align: left" />

            学生管理<asp:LinkButton ID="LinkButton2" Text="返回主页" runat="server" style="font-size: small"  OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SMDBConnectionString %>" SelectCommand="SELECT [Courseid], [CourseName] FROM [CourseInfo]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SMDBConnectionString2 %>" SelectCommand="SELECT [Classid], [ClassName] FROM [Class Info]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SMDBConnectionString %>" SelectCommand="SELECT [Classid], [ClassName] FROM [Class Info]"></asp:SqlDataSource>
        </div>
        <div>

            <asp:Label ID="ErrorLab" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>

            &nbsp;</div>
        <div>

            <table class="auto-style1" border="1">
                <tr>
                    <td class="style2">&nbsp;</td>
                    <td class="style2">联系方式</td>
                    <td class="style2">学生姓名</td>
                    <td class="style2">家长称呼</td>
                    <td class="style2">学生年龄</td>
                    <td class="style2">学生性别</td>
                    <td class="style2">在读学校</td>
                    <td class="style2">报名课程</td>
                    <td class="style2">报名班级</td>
                    <td class="style2">付费情况</td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Button ID="Button1" runat="server" Text="添加" BackColor="Blue" ForeColor="White" OnClick="Button1_Click" Height="21px" />
                    </td>
                    <td style="width:10%">
                        <asp:TextBox ID="Contactadd" runat="server" AutoPostBack="true"  Width="99%" BorderStyle="None" OnTextChanged="Contactadd_TextChanged" style="text-align: center"></asp:TextBox>
                    </td>
                    <td style="width:10%">
                        <asp:TextBox ID="ChildrenCall" runat="server" AutoPostBack="true" Width="99%" BorderStyle="None" OnTextChanged="ChildrenCall_TextChanged" style="text-align: center"></asp:TextBox>
                    </td>
                    <td style="width:10%">
                       <asp:TextBox ID="ParentsCall" runat="server" AutoPostBack="true" Width="99%" BorderStyle="None" OnTextChanged="ParentsCall_TextChanged" style="text-align: center"></asp:TextBox>
                    </td>
                    <td style="text-align:center;width:10%">
                       <asp:TextBox ID="ChildrenAge" runat="server" Width="99%" BorderStyle="None" style="text-align: center" ></asp:TextBox>
                    </td>
                    <td style="text-align:center; width:5%">
                         <asp:DropDownList ID="ChildrenSex" runat="server" >
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:20%">
                        <asp:TextBox ID="School" runat="server" Width="99%" BorderStyle="None" style="text-align: center"></asp:TextBox>
                    </td>
                    <td style="width:10%">
                        <asp:DropDownList ID="Course" runat="server" Width="99%" DataSourceID="SqlDataSource1" DataTextField="CourseName" DataValueField="Courseid" OnSelectedIndexChanged="Course_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        
                    </td>
                    <td style="width:10%">
                        <asp:DropDownList ID="Class" runat="server" Width="99%" DataSourceID="SqlDataSource2" DataTextField="ClassName" DataValueField="Classid"></asp:DropDownList>
                        
                    </td>
                    <td style="width:10%">
                        <asp:TextBox ID="Payment" runat="server" Width="99%" BorderStyle="None" style="text-align: center"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div>
                &nbsp;
            </div>
            <div>

                <table class="auto-style1">
                    <tr>
                        <td>
                            课程:<asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CourseName" DataValueField="Courseid" Height="27px" Width="136px" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                <asp:ListItem Selected="True"></asp:ListItem>
                            </asp:DropDownList>
&nbsp;班级:<asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="ClassName" DataValueField="Classid" Height="27px" Width="136px" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="font-size: small">刷新</asp:LinkButton>
                        </td>
                    </tr>
                </table>

            </div>
            <div>
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  AllowPaging="True" style="text-align: center" DataKeyNames="Contactid" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnRowCancelingEdit="GridView1_RowCancelingEdit" >
                    <Columns>
                        <asp:CommandField ShowEditButton="true" />
                        <asp:BoundField DataField="ChildrenCall" HeaderText="孩子姓名" SortExpression="ChildrenCall" />
                        <asp:BoundField DataField="ParentsCall" HeaderText="家长称呼" SortExpression="ParentsCall" />
                        <asp:TemplateField HeaderText="联系方式" SortExpression="Contact">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Contact") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年龄" SortExpression="ChildrenAge">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ChildrenAge") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("ChildrenAge") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="性别" SortExpression="ChildrenSex">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("ChildrenSex") %>'>
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ChildrenSex") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="School" HeaderText="就读学校" SortExpression="School" />
                        <asp:TemplateField HeaderText="备注" SortExpression="Remarks">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Height="49px" Text='<%# Bind("Remarks") %>' TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Height="46px" Text='<%# Bind("Remarks") %>' TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="报名时间" SortExpression="Registrarion">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Registrarion", "{0:d}") %>' ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <input id="input1" runat="server" onclick="WdatePicker()" value='<%# Bind("Registrarion") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="课程类别" SortExpression="CourseName">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CourseName" DataValueField="Courseid" Height="16px" Width="119px" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged1" >
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="班级名称" SortExpression="[Class Info].ClassName">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource0" DataTextField="ClassName" DataValueField="Classid" Height="16px"  Width="121px"  OnSelectedIndexChanged="CsInfoIndexChanged">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource0" runat="server" ConnectionString="<%$ ConnectionStrings:WebString %>" SelectCommand="SELECT [Classid], [ClassName] FROM [Class Info]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("ClassName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Payment" HeaderText="付费情况" SortExpression="Payment" />
                        <asp:TemplateField HeaderText="报名" SortExpression="SignUp">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("SignUp", "{0}") %>'>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# (int)Eval("SignUp")==1?true:false %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    
                </asp:GridView>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
