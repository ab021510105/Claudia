<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consultion.aspx.cs" Inherits="DataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link type="text/css" href="Desk/CSS/Nav.css"  rel="stylesheet" />
    <link type="text/css" href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <script id="button" src="Desk/Js/Button_L.js"></script>
    <script id="GvControl" src="Desk/Js/GvControl.js"></script>
    <script src="My97DatePicker/WdatePicker.js"></script>
    <script src="TIA/UI/JS/Widget.js"></script>
    <title>DataSoureSystem</title>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" value="" id="templet"  runat="server" />
        <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div style="text-align:right;background-color:rgba(0, 38, 255, 0.37)" class="landInfo">
            <asp:Label ID="landinfo" runat="server" ForeColor="White" ></asp:Label>
            <asp:LinkButton ID="Cancel" runat="server" Text="注销" ForeColor="White" OnClick="Cancel_Click"> </asp:LinkButton>
        </div>
        <div class="nav">
            <ul class="nav-item">
                <li>
                    <a><asp:LinkButton ID="Consultion_button" runat="server"  CssClass="nav-Linkbuttom" OnClick="Consultion_button_Click">学生信息</asp:LinkButton></a>
                    <ul class="nav-sub-item">
                        <li >
                            <a><asp:LinkButton ID="Consul_Add_button" runat="server" OnClick="Consul_Add_button_Click" CssClass="nav-Linkbuttom" >添加</asp:LinkButton></a>
                        </li>
                        <li >
                            <a><asp:LinkButton ID="Consul_Edit_button" runat="server" OnClick="Consul_Edit_button_Click" CssClass="nav-Linkbuttom">修改</asp:LinkButton></a>
                        </li>
                        <li >
                            <a><asp:LinkButton ID="Consule_Delete_button" runat="server"  CssClass="nav-Linkbuttom" OnClick="Consule_Delete_button_Click">删除</asp:LinkButton></a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a><asp:LinkButton ID="SutdentInfo_button" runat="server" CssClass="nav-Linkbuttom" OnClick="SutdentInfo_button_Click">测验信息</asp:LinkButton></a>
                    <ul class="nav-sub-item">
                        <li>
                            <a><asp:LinkButton ID="AddTestInfo_button" runat="server" CssClass="nav-Linkbuttom" OnClick="AddTestInfo_button_Click">新建试卷</asp:LinkButton></a>
                        </li>
                        <li>
                            <a><asp:LinkButton ID="StudentInfo_Edit_button" runat="server" CssClass="nav-Linkbuttom" OnClick="StudentInfo_Edit_button_Click">分配班级</asp:LinkButton></a>
                        </li>
                       <%-- <li>
                            <a><asp:LinkButton ID="StudentInfo_Move_button" runat="server" CssClass="nav-Linkbuttom" OnClick="StudentInfo_Move_button_Click">移除</asp:LinkButton></a>
                        </li>--%>
                    </ul>
                </li>
                <li>
                    <a><asp:LinkButton ID="ClassInfo_button" runat="server" CssClass="nav-Linkbuttom" OnClick="ClassInfo_button_Click">班级信息</asp:LinkButton></a>
                    <ul class="nav-sub-item">
                        <li><a><asp:LinkButton ID="ClassInfo_add_button" runat="server" CssClass="nav-Linkbuttom" OnClick="ClassInfo_add_button_Click">添加</asp:LinkButton></a></li>
                        <li><a><asp:LinkButton ID="ClassInfo_add_student_button" runat="server" CssClass="nav-Linkbuttom" OnClick="ClassInfo_add_student_button_Click">添加学生</asp:LinkButton></a></li>
                        <li><a><asp:LinkButton ID="ClassInfo_edit_button" runat="server" CssClass="nav-Linkbuttom" OnClick="ClassInfo_edit_button_Click">修改</asp:LinkButton></a></li>
                        <li><a><asp:LinkButton ID="ClassInfo_delete_button" runat="server" CssClass="nav-Linkbuttom" OnClick="ClassInfo_delete_button_Click">删除</asp:LinkButton></a></li>
                    </ul>
                </li>
               
            </ul> 
            
            <table style="position:fixed; right:5%;  border:1px solid white">
                <tr>
                    <td>
                        <asp:DropDownList ID="ClassInfo" runat="server" style="width:200px" AutoPostBack="True" OnSelectedIndexChanged="ClassInfo_SelectedIndexChanged" ></asp:DropDownList>
                        &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="Screach" runat="server"></asp:TextBox> </td>
                    <td>
                       
                        <asp:Button ID="Search_Button" runat="server" BorderStyle="None" Text="Search"  ForeColor="White" BackColor="#2c749c" OnClick="Search_Button_Click" Height="17px"/>
                    </td>
                </tr>
            </table>
        </div>
        

        <div>&nbsp</div>
        <div>&nbsp</div>
        <div>&nbsp</div>
        <div class="Gw_Div" runat="server" id="Consultion_Gw" visible="false"  style="text-align:center">
            <div>&nbsp</div>
            <div class="Plan">&nbsp</div>            
            <div style="background-color:white">
            <asp:GridView ID="Consultion" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowDataBound="Consultion_RowDataBound" OnRowCommand="Consultion_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None"  Width="100%" OnDataBound="Consultion_DataBound" OnRowDeleting="Consultion_RowDeleting">
                <Columns>
                  <asp:TemplateField Visible="false">
                      <ItemTemplate>
                          <asp:LinkButton ID="linkbutton" runat="server" Text="选择" OnClick="linkbutton_Click"  CommandArgument='<%#Eval("Contactid") %>' CommandName="select" ></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField> 
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Button ID="ReMoveThisClass" runat="server" Text="踢出班级" CommandArgument='<%#Eval("Contactid") %>' CssClass="Button_S" CommandName="RemoveClass"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="ChildrenCall" HeaderText="学生姓名" />  
                <asp:BoundField DataField="Contactid" HeaderText="账号" />
               <asp:BoundField DataField="Contact" HeaderText="电话" />
               <%-- <asp:BoundField DataField="ParentsCall" HeaderText="家长称呼" />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="HistoryTest" runat="server" CommandName="HistoryTest" CommandArgument='<%#Eval("Contactid") %>' CssClass="Button_S" Text="查看历史测验"/>
                        </ItemTemplate>
                    </asp:TemplateField>
     
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                <PagerSettings Visible="false" />
            </asp:GridView>
                </div>
            <div class="Pager">
                <asp:LinkButton ID="First_Page_C" runat="server" Text="|<<" CssClass="PagerButton" OnClick="First_Page_C_Click" ></asp:LinkButton>&nbsp;
                <asp:LinkButton ID="Front_page_C" runat="server" Text="|<" CssClass="PagerButton" OnClick="Front_page_C_Click"></asp:LinkButton>&nbsp;
                <asp:DropDownList ID="PageControl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageControl_SelectedIndexChanged"></asp:DropDownList>&nbsp;
                <asp:LinkButton ID="Next_Page_C" runat="server" Text=">|" CssClass="PagerButton" OnClick="Next_Page_C_Click"></asp:LinkButton>&nbsp;
                <asp:LinkButton ID="Last_Page_C" runat="server" Text=">>|" CssClass="PagerButton" OnClick="Last_Page_C_Click"></asp:LinkButton>&nbsp;
                <asp:Label ID="PageCount" runat="server" CssClass="PagerButton" Text=" "></asp:Label>
            </div>
            <div style="text-align:right" id="Comfirn" runat="server" visible="false">
               <asp:Button ID="Con_Com" runat="server" CssClass="Button_L" Text="确定"  OnClick="Con_Com_Click"/>
            </div>
        </div>


        <div id="TestInfo" runat="server" visible="false" style="text-align:center">
            <div style="color:white">
                筛选:<input type="text" runat="server" onclick="WdatePicker()" id="TestSartTime" />~<input type="text" runat="server" onclick="WdatePicker()" id="TestEndTime" />
                &nbsp;
                <asp:Button ID="Search" runat="server" Text="检索" OnClick="Search_Click" CssClass="Button_S"/>
            </div>
            <asp:GridView runat="server" ID="TestGw" AutoGenerateColumns="false" Width="100%" AllowPaging="true" AllowSorting="true" OnRowCommand="TestGw_RowCommand" OnPageIndexChanging="TestGw_PageIndexChanging" OnRowDeleting="TestGw_RowDeleting" >
            <Columns>

             <asp:TemplateField HeaderText="ID" HeaderStyle-Width="10%" Visible="false">
                 <ItemTemplate>
                 <%--  <asp:CheckBox ID="check" runat="server" Text='<%#Eval("TestID") %>' OnCheckedChanged="ChecekChanged" AutoPostBack="true"/>--%>
                     <asp:Button CssClass="Button_S" runat="server" ID="Button_select_t" CommandName="Selected" CommandArgument='<%#Eval("TestID") %>' Text="选择"/>
                 </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="考试名称" DataField="TestName"/>

                
                   
           <asp:TemplateField HeaderText="考试时段">
               <ItemTemplate>
                   <asp:Label ID="Label_Time" runat="server" Text='<%#Eval("TestStartTime")+"~"+Eval("TestEndTime") %>'></asp:Label>
                    <asp:Button ID="TestID" runat="server" Text="更改" CommandName="Update" CommandArgument='<%#Eval("TestID") %>' CssClass="Button_S" Visible="true"></asp:Button>
               </ItemTemplate>  
           </asp:TemplateField>
            <asp:BoundField HeaderText="考题数量" DataField="TestCount"/>
            <asp:BoundField HeaderText="每题分值" DataField="TopicScore"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="More" runat="server" Text="详细" CssClass="Button_S"  CommandName="More" CommandArgument='<%#Eval("TestID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <div id="ClassInfo_Div" runat="server" visible="false" style="text-align:center">
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" Width="100%" AllowPaging="true" AllowSorting="true" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="SelectLinkButton" runat="server" Text="选择" CommandArgument='<%#Eval("Classid") %>' CommandName="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="删除" CommandArgument='<%#Eval("Classid") %>' CommandName="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="班级名称" DataField="ClassName" />
                    <asp:BoundField HeaderText="年级" DataField="CourseName" />
                    <asp:BoundField HeaderText="班级人数" DataField="RemainingNumber" />
                    
                </Columns>
                </asp:GridView>
        </div>
    </form>
</body>
</html>
