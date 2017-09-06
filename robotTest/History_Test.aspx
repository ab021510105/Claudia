<%@ Page Language="C#" AutoEventWireup="true" CodeFile="History_Test.aspx.cs" Inherits="History_Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="TIA/UI/JS/Widget.js" type="text/javascript"></script>
    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <link href="Desk/CSS/Froms.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div style="text-align:right;background-color:rgba(0, 38, 255, 0.37)" class="landInfo">
            <asp:Label ID="landinfo" runat="server" ForeColor="White" ></asp:Label>
        </div>
        <div id="Back" style="text-align:right"><asp:LinkButton ID="TrunBack" runat="server" Text="返回" OnClick="TrunBack_Click" ForeColor="White"></asp:LinkButton></div>
        <div style="text-align:center">
            <div style="text-align:left" class="From">
                <div>
                统计时间段筛选: <input id="MinTime" runat="server" type="text" onclick="WdatePicker()"/>到<input id="MaxTime" runat="server" type="text" onclick="WdatePicker()"/>&nbsp;
                <asp:Button ID="ScreachBtn" runat="server" Text="筛选" OnClick="ScreachBtn_Click" CssClass="Button_S"/>
                    </div>
                <div>&nbsp;</div>
                <div>
                快捷筛选:<asp:Button ID="TheLast1Day" runat="server" Text="今天" OnClick="TheLast1Day_Click" CssClass="Button_S"/>&nbsp;
                    <asp:Button ID="TheLast3Day" runat="server" Text="最近三天" OnClick="TheLast3Day_Click"  CssClass="Button_S"/>&nbsp;
                    <asp:Button ID="TheLast7Day" runat="server" Text="最近一个星期" OnClick="TheLast7Day_Click" CssClass="Button_S" />&nbsp;
                    <asp:Button ID="LastOneMonth" runat="server" Text="最近一个月" OnClick="LastOneMonth_Click" CssClass="Button_S" />&nbsp;
                    </div>
            </div>
            <div>
                &nbsp;
            </div>
        <div style="background-color:rgba(8, 15, 148, 0.70);color:white" id="titel"><asp:Label ID="TestInfo_Titel" runat="server" ForeColor="White"></asp:Label></div>
                <div id="TestCount_div" runat="server">
                <asp:GridView Width="100%" runat="server" ID="Count" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="true" OnDataBound="Count_DataBound" PageSize="1"  >
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                    <PagerSettings Visible="false" />

                </asp:GridView>
                <div style="text-align:center; background-color:#99CCCC">
                    <asp:Button ID="FrontPage" runat="server" Text="上一页" CssClass="Button_S"  OnClick="FrontPage_Click"/>&nbsp;
                    <asp:Button ID="NextPage" runat="server" Text="下一页" CssClass="Button_S" OnClick="NextPage_Click" />&nbsp;
                    <asp:Label ID="PageCount" runat="server" ForeColor="Blue"></asp:Label>
                </div>
            </div>
            <div style="height:2px">
                &nbsp;
            </div>
            <div>
                <asp:Button ID="ResetScore_Btn" runat="server" CssClass="Button_S" Text="重新判分" OnClick="ResetScore_Btn_Click" />
            </div>
            <div style="height:2px">
                &nbsp
            </div>
         <asp:GridView runat="server" ID="Myhistory_Gw" AutoGenerateColumns="False" AllowPaging="True" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="My_Test_RowCommand" OnPageIndexChanged="Myhistory_Gw_PageIndexChanged" OnPageIndexChanging="Myhistory_Gw_PageIndexChanging" OnRowDeleting="Myhistory_Gw_RowDeleting">
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"/>
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left"/>
                                <RowStyle BackColor="White" ForeColor="#003399"  />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                
                               <Columns>
                                   <asp:BoundField HeaderText="考试名称" DataField="TestName" />
                                   <asp:BoundField HeaderText="考题数量" DataField="TestCount" />
                                   <asp:BoundField HeaderText="正确题数" DataField="Score" />
                                   <asp:TemplateField HeaderStyle-Width="25%">
                                       <ItemTemplate>
                                           <asp:Button ID="More" runat="server" CommandName='<%#Eval("RelationshipID").ToString() %>' CommandArgument='<%#Eval("TestID") %>'  Text="查看试题" CssClass="Button_S" />
                                           &nbsp
                                           <asp:Button ID="Delete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("RelationshipID") %>' Text="删除这条记录" CssClass="Button_S" />
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                            </asp:GridView>
            <div>
                &nbsp;
            </div>
            <div id="Titel" style="background-color:blue;color:white;text-align:center">
                错题归纳
            </div>
            <div>
                <asp:GridView ID="Worng_Q_T" runat="server" Width="100%" Height="100%" AllowPaging="true" AutoGenerateColumns="false" PageSize="5" OnDataBound="Worng_Q_T_DataBound" OnRowCommand="Worng_Q_T_RowCommand">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"/>
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left"/>
                                <RowStyle BackColor="White" ForeColor="#003399"  />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                <PagerSettings Visible="false" />
                    <Columns>
                        <asp:BoundField HeaderText="知识点" DataField="KnowledgePointName" />
                        <asp:BoundField HeaderText="错题数" DataField="WorngCount" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CssClass="Button_S" runat="server" ID="ConvtoTIa" CommandName="ConvertToTIA" CommandArgument='<%#Eval("KnowledgePointID") %>'  Text="查看"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div style="text-align:center;background-color:#99CCCC;color:#003399" >
                    <asp:Button ID="Worng_Q_T_FirstPage" runat="server" Text="第一页" CssClass="Button_S"  OnClick="Worng_Q_T_FirstPage_Click"/>&nbsp;
                    <asp:Button ID="Wrong_Q_T_FonrPage" runat="server" Text="上一页" CssClass="Button_S" OnClick="Wrong_Q_T_FonrPage_Click" />&nbsp;
                    <asp:DropDownList ID="Wrong_Q_TDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Wrong_Q_TDropDownList_SelectedIndexChanged"></asp:DropDownList>&nbsp;
                    <asp:Button ID="Wrong_Q_T_NextPage" runat="server" Text="下一页" CssClass="Button_S" OnClick="Wrong_Q_T_NextPage_Click" />&nbsp;
                    <asp:Button ID="Wrong_Q_T_LastPage" runat="server" Text="尾页" CssClass="Button_S" OnClick="Wrong_Q_T_LastPage_Click" />&nbsp;
                    <asp:Label ID="Wrong_Q_T_PageCount" runat="server"></asp:Label>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
