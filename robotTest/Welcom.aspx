<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcom.aspx.cs" Inherits="Welcom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            color: #3333FF;
        }
        #div2 {
            text-align: center;
        }
        .auto-style3 {
            color: #FFFFFF;
        }
        #d11 {
            width: 82px;
        }
        </style>
    <script  type="text/javascript" src="My97DatePicker/WdatePicker.js" id="datelist"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: left; background-color: #F6F6F6">

            <asp:Image ID="Image1" runat="server" Height="101px" Width="336px" ImageUrl="~/home-top_04.jpg" style="text-align: left" />

            <strong>欢迎<asp:Label ID="Label1" runat="server" style="color: #CC0000" Text="Label"></asp:Label>
            ！<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click1" style="font-size: small" Visible="false">添加账号</asp:LinkButton>
            </strong></div>
        <div>

            <asp:Label ID="Label2" runat="server" style="color: #FF0000; font-weight: 700" Text="Label" Visible="false"></asp:Label>

        </div>
        <div id="tab1" runat="server">
            
            <table class="auto-style1" border="1">
                <tr>
                    <td style="background-color: #0000CC">&nbsp;</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">咨询班级</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">家长称呼</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">联系方式</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">孩子称呼</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">孩子性别</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">孩子年龄</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">就读学校</td>
                    <td style="color: #FFFFFF; background-color: #0000CC; text-align: center;">备注</td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="添加" BackColor="Black" ForeColor="White" OnClick="Button1_Click" />
                    </td>
                    <td style="font-size: small; text-align: center;width:16%" >
                        <asp:DropDownList ID="DropDownList4" runat="server" Width="99%" DataSourceID="SqlDataSource2" DataTextField="CourseName" DataValueField="Courseid">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SMDBConnectionString %>" SelectCommand="SELECT [CourseName], [Courseid] FROM [CourseInfo]"></asp:SqlDataSource>
                    </td>
                    <td style="text-align: center;width:15%">
                        <asp:TextBox ID="TextBox1" runat="server" Width="99%" style="text-align: center" BorderStyle="None"></asp:TextBox>
                    </td>
                    <td style="text-align: center;width:15%">
                        <asp:TextBox ID="TextBox2" runat="server" Width="99%" BorderStyle="None" style="text-align: center" ></asp:TextBox>
                    </td>
                    <td style="text-align: center;width:15%">
                        <asp:TextBox ID="TextBox3" runat="server" Width="99%" BorderStyle="None" style="text-align: center"></asp:TextBox>
                    </td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center;width:15%">
                        <asp:TextBox ID="TextBox6" runat="server" Width="99%" BorderStyle="None" style="text-align: center"></asp:TextBox>
                    </td>
                    <td style="text-align: center; width:15%">
                        <asp:TextBox ID="TextBox4" runat="server" Width="99%" BorderStyle="None" style="text-align: center" ></asp:TextBox>
                    </td>
                    <td style="text-align: center;width:15%">
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">编辑</asp:LinkButton>
                        </td>
                </tr>
            </table>
            
        </div>
        <div id="Remarks" runat="server" visible="false" style="text-align:center">
            <div style="width:16%; margin:auto">

                <table class="auto-style1" border="1">
                    <tr>
                        <td style="background-color:#0000CC" class="auto-style3">备注</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine" Width="99%" BorderStyle="None" Height="98px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="RemarkButton" runat="server" Text="完成" BackColor="Blue" ForeColor="White" OnClick="RemarkButton_Click" />
            </div>
        </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td style="text-align: left">
            <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="10%" AutoPostBack="True" OnSelectedIndexChanged="LinkButton3_Click" DataSourceID="SqlDataSource2" DataTextField="CourseName" DataValueField="Courseid" >
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            
            
            <asp:Label ID="Label3" runat="server" Text="电话：" style="font-weight: 700; color:red"></asp:Label>
           <asp:TextBox ID="TextBox7" runat="server" ></asp:TextBox>&nbsp;
            <asp:Button ID="Button2" runat="server" Text="查询" BackColor="Black" ForeColor="White" OnClick="Button2_Click" Width="40px" />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" style="font-size: small">高级搜索</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="new" runat="server" Text="刷新" Style="font-size: small;" OnClick="new_Click">刷新</asp:LinkButton></td>
                    <td style="text-align: right">

                        <asp:Button ID="Button4" runat="server" BackColor="Blue" ForeColor="White" Text="查看班级信息" OnClick="Button4_Click"></asp:Button>
&nbsp;
                        <asp:Button ID="Button5" runat="server" BackColor="Blue" ForeColor="White" Text="在读学生管理" OnClick="Button5_Click"></asp:Button>

                    </td>
                    </tr>
             </table>
        </div>
        <div id="div1" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div id="div2" runat="server" visible="false">
            
            <asp:Label ID="ul1" runat="server" style="color: #0000FF" Text="学校"></asp:Label>
            :<asp:TextBox ID="ShoolTextbox" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="ul2" runat="server" style="color: #0000FF" Text="年龄段:"></asp:Label>
            <asp:DropDownList ID="AgeDorpDownList1" runat="server">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem Selected="True"> </asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="ul3" runat="server" style="color: #0000FF" Text="~"></asp:Label>
            <asp:DropDownList ID="AgeDorpDownList2" runat="server">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem Selected="True"> </asp:ListItem>
            </asp:DropDownList>
&nbsp;<asp:Label ID="ul4" runat="server" style="color: #0000FF" Text="家长称呼:"></asp:Label>
            <asp:TextBox ID="ParentsCallTextBox" runat="server" Width="77px"></asp:TextBox>
&nbsp;<asp:Label ID="ul5" runat="server" style="color: #0000FF" Text="孩子称呼:"></asp:Label>
            <asp:TextBox ID="ChildrenCallTextBox" runat="server" Width="77px"></asp:TextBox>
&nbsp;<asp:Label ID="ul6" runat="server" style="color: #0000FF" Text="性别:"></asp:Label>
            <asp:DropDownList ID="SexDorpDownList" runat="server">
                <asp:ListItem> </asp:ListItem>
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>

            
            
       &nbsp;<asp:Label ID="ul7" runat="server" Text="备注:" style="color: #0000FF"></asp:Label>
            <asp:TextBox ID="RemarksTextBox" runat="server"></asp:TextBox>            
       &nbsp;<span class="auto-style2">日期:</span><input id="d12" onclick="WdatePicker()" runat="server" style="width:87px" />到<input id="d11"  onclick="WdatePicker()" runat="server" style="width:87px" />
&nbsp; <span class="auto-style2">是否报名:</span><asp:DropDownList ID="SignUpDorpDownList" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="1">true</asp:ListItem>
                <asp:ListItem Value="0">false</asp:ListItem>
            </asp:DropDownList>
            &nbsp; <asp:Button ID="uButton" runat="server" Text="高级查询" BackColor="Black"  ForeColor="White" OnClick="uButton_Click"/>
            &nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" style="font-size: small">返回</asp:LinkButton>
            
            
            
       </div>
        <table class="auto-style1">
            <tr>
                <td style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"  GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                           
                            <asp:CommandField ShowEditButton="True" />
                            <asp:TemplateField HeaderText="咨询人" SortExpression="Username">
                                <EditItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="咨询时间" SortExpression="ConsultingTime">
                                <EditItemTemplate>
                                    <input id="TextBox12" runat="server" onclick="WdatePicker()" value='<%#Bind("ConsultingTime", "{0:d}") %>'/>
                                </EditItemTemplate> 
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ConsultingTime", "{0:g}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField  HeaderText="家长称呼" SortExpression="ParentsCall">
                                <ItemTemplate>
                                    <asp:Label ID="ParentsCall_Label" runat="server" Text='<%# Bind("ParentsCall") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <Asp:TextBox ID="ParentsCall_TextBox" runat="server" Text='<%# Bind("ParentsCall") %>'></Asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="联系方式" SortExpression="Contact" >
                                <ItemTemplate>
                                    <asp:Label ID="Contact_Label" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="Contact_TextBox" runat="server" Text='<%# Bind("Contact") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="欲读课程" SortExpression="CourseName">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource2" DataTextField="CourseName" DataValueField="Courseid" Height="20px" SelectedValue='<%# Bind("Courseid", "{0}") %>' Width="124px">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ChildrenSex" HeaderText="孩子性别" SortExpression="ChildrenSex" />
                            <asp:BoundField DataField="ChildrenCall" HeaderText="孩子称呼" SortExpression="ChildrenCall" />
                            <asp:BoundField DataField="ChildrenAge" HeaderText="孩子年龄" SortExpression="ChildrenAge" />
                            <asp:BoundField DataField="School" HeaderText="学校" SortExpression="School" />
                            <asp:TemplateField HeaderText="备注信息" SortExpression="Remarks">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Height="53px" Text='<%# Bind("Remarks") %>' TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox11" runat="server" Height="33px" Text='<%# Eval("Remarks") %>' TextMode="MultiLine"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="报名" SortExpression="SignUp">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Chceked='<%#Convert.ToInt32(Eval("SignUp"))==1?true:false %>' Enabled="false"/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Convert.ToInt32(Eval("SignUp"))==1?true:false %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
