<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addingquestions.aspx.cs" Inherits="Addingquestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link type="text/css" href="Desk/CSS/Nav.css"  rel="stylesheet" />
    <link type="text/css" href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <script id="button" src="Desk/Js/Button_L.js"></script>
    <script id="GvControl" src="Desk/Js/GvControl.js"></script>
    <script src="My97DatePicker/WdatePicker.js"></script>
    <script src="TIA/UI/JS/Widget.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div id="Main">
              <div class="nav">
                  <ul class="nav-item">
                      <li>
                          <a><asp:LinkButton ID="SectionButton" runat="server" CssClass="nav-Linkbuttom">章节</asp:LinkButton></a>
                          <ul class="nav-sub-item">
                              <li>
                                  <a><asp:LinkButton ID="AddSectionButon" runat="server" CssClass="nav-Linkbuttom">添加</asp:LinkButton></a>
                              </li>
                          </ul>
                      </li>
                      <li>
                          <a><asp:LinkButton ID="KonwledgePointButton" runat="server" CssClass="nav-Linkbuttom">知识点</asp:LinkButton></a>
                          <ul class="nav-sub-item">
                              <li>
                                  <a><asp:LinkButton ID="AddKonwledgePointButton" runat="server" CssClass="nav-Linkbuttom">添加</asp:LinkButton></a>
                              </li>
                          </ul>
                      </li>
                      <li>
                          <a><asp:LinkButton ID="Topic" runat="server" CssClass="nav-Linkbuttom">题目</asp:LinkButton></a>
                          <ul class="nav-sub-item">
                              <li>
                                  <a><asp:LinkButton ID="AddTopic" runat="server" CssClass="nav-Linkbuttom">添加</asp:LinkButton></a>
                              </li>
                          </ul>
                      </li>
                      <li>&nbsp; </li>
                  </ul>
              </div>
            <div id="TopicInfo" runat="server" visible="true">
                <div style="background-color:white;text-align:center">
                    <asp:GridView ID="Topic_Gw" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="false" AllowPaging="true" Width="100%" OnPageIndexChanging="Topic_Gw_PageIndexChanging" OnRowCommand="Topic_Gw_RowCommand" OnRowDataBound="Topic_Gw_RowDataBound">
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
                                    <asp:Button ID="Btn1" runat="server" Text="编辑" CssClass="Button_S"  CommandName="Edit" CommandArgument='<%#Eval("TopicID") %>'/>
                                    &nbsp;
                                    <asp:Button ID="Btn2" runat="server" Text="删除" CssClass="Button_S" CommandName="Delete" CommandArgument='<%#Eval("TopicID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="试题">
                                <ItemTemplate>
                                    <%#Eval("TopicID") %>
                                    <%#Eval("MoreContent") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
