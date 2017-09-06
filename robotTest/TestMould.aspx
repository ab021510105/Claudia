<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestMould.aspx.cs" Inherits="robotTest_TestMould" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="TIA/UI/JS/Modulelist.js" ></script>
    <link href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <script src="TIA/UI/JS/Widget.js"></script>
    <link href="Desk/CSS/Froms.css" rel="stylesheet" />
    <script src="My97DatePicker/WdatePicker.js"></script>
      
</head>
<body>
    <form id="form1" runat="server">
           <input type="text" value="" runat="server" style="display:none" id="Sigen" />
          <input  type="text" value="" runat="server" style="display:none" id="SurfaceBuf" />
          <input type="text" value="" runat="server" style="display:none" id="SelectionBuf" />
          <input type="text" value="" runat="server" style="display:none" id="ReturnBuf" />
           <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div style="text-align:right;background-color:rgba(0, 38, 255, 0.37)" class="landInfo">
                <asp:Label ID="landinfo" runat="server" ForeColor="White" ></asp:Label>
            </div>
        <div id="Main" style="position:absolute; left:5%;width:90%;">
                <div id="Gridviews" style="text-align:center;background-color:white">
                    <div id="NullData" runat="server" visible="false">
                        目前没有模板
                    </div>
                <asp:GridView ID="TestMouldGV" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AllowPaging="true" AutoGenerateColumns="false" PageSize="10" OnDataBound="TestMouldGV_DataBound" OnRowCommand="TestMouldGV_RowCommand" OnRowDeleting="TestMouldGV_RowDeleting" >
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                    <PagerSettings  Visible="false"/>
                    <Columns>                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Delete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("MouldID") %>' CssClass="Button_S"/>  
                                <asp:Button ID="More" runat="server" Text="查看模板"  CommandArgument='<%#Eval("MouldID") %>' CommandName="More" CssClass="Button_S"/>                                 
                            </ItemTemplate>
                        </asp:TemplateField>
  <asp:BoundField DataField="MouldName"  HeaderText="模板名"/>
                      
                       </Columns>
                </asp:GridView>
                    <div style="background-color:#003399; text-align:center;color:white">
                        <asp:Button ID="FirsetPage" runat="server" CssClass="Button_S" Text="首页" OnClick="FirsetPage_Click" />&nbsp;
                        <asp:Button ID="FrontPage" runat="server" CssClass="Button_S" Text="上一页" OnClick="FrontPage_Click"/>&nbsp;
                        <asp:DropDownList ID="PagerControl" runat="server" OnSelectedIndexChanged="PagerControl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;
                        <asp:Button ID="NextPage" runat="server" CssClass="Button_S" Text="下一页" OnClick="NextPage_Click" />&nbsp;
                        <asp:Button ID="lastPage" runat="server" CssClass="Button_S" Text="尾页" OnClick="lastPage_Click" />&nbsp;
                        <asp:Label ID="PageCounts" runat="server"></asp:Label>
                    </div>
            </div>
            <div>
                &nbsp;
            </div>
            <div>
                &nbsp
            </div>
            <div id="MouldView" runat="server" visible="false">
                <div style="color:white">
                     
                考试名称:<input id="TestName" runat="server" type="text" placeholder="这里填写考试名称(选填)" />&nbsp;
                考试时间:<input id="TestStartTime" runat="server" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" placeholder="点击就可输入" />到
                <input id="TestEndTime" runat="server" type="text" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm' })" placeholder="点击就可输入" />&nbsp;
                每题分数:<input id="TopicScore" runat="server" type="text" placeholder="这里选填" />&nbsp;
                    <asp:Button ID="ToTest" runat="server" CssClass="Button_S" Text="生成试卷" OnClick="ToTest_Click" />
                
                </div>
                <div style="background-color:white">
                    <table id="MouldTabel">

                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
