<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectTest.aspx.cs" Inherits="Test.ObjectTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .Text-Style1 {
            /*font-family: Meiryo;*/
            font-size: 120%;
            font-weight: bold;
            font-style: normal;
            font-variant: normal;
            text-transform: none;
            
        }
        .NavButtom_Clicked {
           width:98%;
            border:1px solid black;           
            background-color:rgba(55, 41, 41, 0.80);
            text-align:center;
            color:white;
        }
        .NavButtom {
            width:98%;
            border:1px solid black;
            /*chrome,Safari+*/
            /*IE10+*/
            /*FireFox*/
            text-align:center;
            color:white;
            margin-bottom: 0px;
        }
        .PagerButtom {
            /*font-size:30px;*/
            color:white;
            background-color:rgba(40, 40, 40, 0.88);
            border-radius:5px;
            border:1px solid black;
            width:100px;
        }
        .GvTitle {
            border-radius:15px 15px 0px 0px;
            border-left:1px solid black;
            border-right:1px solid black;
            border-top:1px solid black;
            color:white;
            background-color:rgba(0, 0, 0, 0.80);
            text-align:center;
        }
        /*.Buttom_B_S {
            border:1px solid black;
            background-color:rgba(0,0,0,0.80);
            color:white;
            border-radius:15px;
        }*/
        .GridView {
            /*border:1px solid black;*/
            text-align:center;
        }
         table{
            border-collapse:collapse;
            border-spacing:0;
            border-left:1px solid #888;
            border-top:1px solid #888;
            background:#efefef;}
        th,td
        {
            border-right:1px solid #888;
             border-bottom:1px solid #888;
             padding:5px 15px;
        }
        th
        {
            font-weight:bold;background:#ccc;
        }
    </style>
    <script src="TIA/UI/JS/jQuery.js"></script>
    <script src="ajaxrequest/arequest/ajax.js"></script>
    <script src="My97DatePicker/WdatePicker.js"></script>
    <script src="TIA/UI/JS/Widget.js"></script>
    <script src="TIA/UI/JS/jqplot.js"></script>
    <script src="TIA/function/testInfo.js"></script>
    <script src="TIA/function/TIA.js"></script>
    <link href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <script type="text/javascript">
        document.onreadystatechange=function()
        {
            if(document.readyState=="complete")
            {
                var uid = document.getElementById('LandInfo_Userid').value;
                if ('<%=Request["TestInfo"] %>' != '') {
                    doTestInfo();
                }
                else if ('<%=Request["HistoryTest"]%>' != '') {

                }
                else if ('<%=Request["WorngQuiz"]%>' != '') {
                   
                }


            }
        }

        

    </script>

</head>
<body>
    <%--<input id="1" type="checkbox" onchange=""/>--%>
    <form id="form1" runat="server" style="border: 1px solid #dbd9d9"> 
     <input type="hidden" id="LandInfo_Userid" value=""  runat="server"/>
        <input type="hidden" id="ServerTime"  value="" />
    <div id="Timer">
        <div style="text-align:center;position:absolute;left:40%;top:5px" id="errorInfo"></div>
    <table style="width:100%; border-bottom:1px solid #dbd9d9">
        <tr>
            <td style="text-align:right">
                <label id="Time" class="Text-Style1" style="font-size:300%">
                    12:30
                </label>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;color:#808080">
                <label id="Date">
                2015年7月12日
                    </label>
                <br />
                <label id="Week">
                星期日

                </label>
                <br />
               <%--<asp:Image ID="Image1" runat="server"/>--%>
                <asp:Label ID="Weather1" runat="server" Font-Italic="True">Claudia</asp:Label>
            </td>
        </tr>
    </table>
    </div>
        <table style="width:100%">
            <tr>
                <td style="width:18%;border-right:1px solid #dbd9d9; vertical-align:top;">
                    <div class="NavButtom" onclick="MyTestInfoClick(event)" id="MyTestInfoBtn" title="none">
                        <div>
                            &nbsp;
                        </div>       
                                        
                        <div style="float:left; width:33%">&nbsp;</div>
                        <div style="float:left;"><label>▶我的练习</label></div>
                        <div style="float:left; width:20%" class="select_d"> &nbsp;</div>
                        <div style="float:left; display:none" class="select_f"><label>◀</label></div>
                        <div>
                            &nbsp;
                        </div>
                        <div>
                            
                            &nbsp;
                        </div>
                      <%--  <div>
                            &nbsp
                        </div>--%>
                    </div>
                    <div style="height:30px">
                        &nbsp;
                    </div>

                     <div class="NavButtom" id="MyHistoryBtn" onclick="MyHistroyTest(event)">
                        <div>
                            &nbsp;
                        </div>
                         <div style="float:left; width:33%">&nbsp;</div>
                         <div style="float:left;"><label>▶历史练习</label></div>
                        <div style="float:left; width:20%" class="select_d"> &nbsp;</div>
                        <div style="float:left; display:none" class="select_f"><label>◀</label></div>
                        <div>
                            &nbsp;
                        </div>
                        <div>
                            &nbsp;
                        </div>
                         </div>
                     <div style="height:30px">
                        &nbsp;
                    </div>

                    <div class="NavButtom" id="WorngQuizCouny" onclick="WornQuizCountClick(event)" >
                        <div>
                            &nbsp;
                        </div>
                        <div style="float:left; width:33%">&nbsp;</div>
                         <div style="float:left;"><label>▶错题归纳</label></div>
                        <div style="float:left; width:20%" class="select_d"> &nbsp;</div>
                        <div style="float:left; display:none" class="select_f"><label>◀</label></div>
                        <div>
                            &nbsp;
                        </div>
                        <div>
                            &nbsp;
                        </div>
                         </div>
                     <div style="height:30px">
                        &nbsp;
                    </div>
                    
                   <%-- <div class="NavButtom" id="MyDataTable" onclick="MyDataTabelClick(event)" >
                        <div>
                            &nbsp;
                        </div>
                        <div style="float:left; width:33%">&nbsp;</div>
                         <div style="float:left;"><label>▶线性分析</label></div>
                        <div style="float:left; width:20%" class="select_d"> &nbsp;</div>
                        <div style="float:left; display:none" class="select_f"><label>◀</label></div>
                        <div>
                            &nbsp;
                        </div>
                        <div>
                            &nbsp;
                        </div>
                         </div>
                     <div style="height:30px">
                        &nbsp;
                    </div>--%>
                    <%-- <div class="NavButtom">
                        <div>
                            &nbsp;
                        </div>
                        <table style="width:100%">
                            <tr>
                                <td style="width:90%;text-align:center">
                                <a href="#" style="color:white">button3</a>
                                </td>
                                <td style="text-align:right">
                                    ▶
                                </td>
                            </tr>
                        </table>
                        
                        <div>
                            &nbsp
                        </div>
                    </div>--%>
                </td>
                <td> 
                   
                    <div style="text-align:center; display:none" id="ProcessBar">
                <label id="ProgressBar" class="Text-Style1">
                    Loading
                </label>
                     </div>
                    <div id="desk">
                       
                        <%--QuizeControls --%>
                       <%--HisttoryTabel --%>
                      
                        <%--HisttoryTable --%>
                    </div>
                </td>
            </tr>
        </table>
        <div style="width:100%; border-top:1px solid #dbd9d9;text-align:left;color:#808080">
                            Userid:<label id="userid_lable"></label>&nbsp;
                           UserName:<label id="userName_label"></label>&nbsp;
                           <a href="#" style="color:#808080" onclick="OnLogOut()" >注销</a>
                           
                       </div>
        <div style="display:none;border:1px solid black;text-align:center;position:fixed;right:0px;bottom:0px" id="dialog">
            <div>
                &nbsp;
            </div>
            <div id="dialogTest"></div>
            <div style="height:3px">
                &nbsp;
            </div>
            <div style="text-align:right">
                <input type="button" id="dialogbtn_Y" value="是" />&nbsp;
                <input type="button" id="dialogbtn_N" value="否" />&nbsp;
            </div>
        </div>
    </form>
</body>
</html>
