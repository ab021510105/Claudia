<%@ Page Language="C#" AutoEventWireup="true" CodeFile="overview.aspx.cs" Inherits="robotTest_TIA_function_overview" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">




   <%-- <script  src="echarts.min.js"></script>--%>
    <%--<script src="echarts.common.min.js"></script>--%>
    <%--<script type="text/javascript">
       //// var testchart = echarts.init(document.getElementById('TesCtountChart'));
        var option = {
            title: {
                test: '统计',
                subtext:'近10日'
            },
            tooltip: {
                trigger:'axis'
            },
            toolbox:{
                show: true,
                feature: {
                    magicType: { show: true, type: ['stack', 'tiled'] },
                    saveAsImage:{show:true}
                }
            },
            dataZoom: [{
                startValue:''
            }, {
                type: 'inside'
            }],
            visualMap: {
                top: 10,
                right: 10,
            },
            legend: {
                data: ['正确率']
            },
            xAxis: {
                type: 'category',
                boundaryGap: false,
                data:[]
            },
            yAxis: {
                type: 'value'
               //data: ["正确率"]
            },
            series: [{
                name: '正确率',
                type: 'line',
                smooth: true,
                //clipOverflow:false,
                data: []
            }]

        };
        document.onreadystatechange = function()
        {
            if (document.readyState == "complete")
            {
                var testchart = echarts.init(document.getElementById("TestCountChart"));
                var names = document.getElementById("OverViewTestName").value.split("#");
                var values = document.getElementById("OverViewTestValue").value.split("#");
                option.dataZoom[0].startValue = names[0];
                for (i = 0; i < values.length - 1; i++)
                {
                    option.series[0].data[i] = values[i];
                }
                var name = '';
                var j = 0;
                for (i = 0; i < names.length - 1; i++)
                {
                    if (names[i] == name)
                    {
                        names[i] = names[i] + "" + (++j);
                    }
                    else
                    {
                        name = names[i];
                    }
                    option.xAxis.data[i] = names[i];
                }
                testchart.setOption(option);

            }
        }
      
    </script>--%>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
      <input id="OverViewTestValue" runat="server" type="hidden" value="" />
        <input id="OverViewTestName" runat="server" type="hidden" value="" />
    <input id="OverViewTestScore" runat="server" type="hidden" value=""/>
    <input id="OverViewTestRow" runat="server" type="hidden" value="" />
    <div id="Chart" style="margin:10px;text-align:center" runat="server">
        <div id="TestCountChart" style="width:100%;height:300px" ></div>

        <%--<asp:Chart ID="TestCountChart" runat="server" BorderSkin-BorderDashStyle="Solid" Palette="BrightPastel" ImageType="Png" BackSecondaryColor="White"  BackGradientStyle="TopBottom"  BorderlineWidth="2" BackColor="#cccccc" BorderlineColor="26,59,105" Width="1024">
            <Titles> 
                <asp:title Text="最近状态" Font="微软雅黑,16pt"></asp:title>
            </Titles>
            <BorderSkin SkinStyle="Emboss" BorderDashStyle="Solid" />
            <Series>
                <asp:Series Name="Count_s" ChartType="Spline" MarkerSize="8"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="Count_Sa" BorderColor="64,64,64,64" BackSecondaryColor="Transparent" BackColor="64,165,191,228" ShadowColor="Transparent"  BackGradientStyle="TopBottom"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>--%>
        </div>
        <div style="width:100%">
    <div  style="width:1024px;margin:auto">

            <asp:GridView ID="TestCount" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="false" >
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
                <Columns>
                    <asp:TemplateField HeaderText="知识点">
                        <ItemTemplate>
                            <%#Eval("KnowledgeName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="已练习总数">
                        <ItemTemplate>
                            <%#Eval("KnowledgeCount") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="正确数">
                        <ItemTemplate>
                            <%#Eval("KnowledgeHit") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="评价">
                        <ItemTemplate>
                            <%#Eval("KnowledgeLevel") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

   </div>
    </form>
</body>
</html>
