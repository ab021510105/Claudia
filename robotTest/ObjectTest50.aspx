<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectTest50.aspx.cs" Inherits="robotTest_ObjectTest50" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>train</title>
    <link href="TIA/UI/CSS/StyleSheet.css" rel="stylesheet" />
    <style>
        #content {
            text-align:center;
            width:90%;
            position:absolute;
            top:20px;
            left:5%;
            /*border-left:1px solid #686868;
            border-right:1px solid #686868;*/
        }
        #userInfo a{
            color:#808080;
            margin-left:5px;
        }
        #userInfo {
            color:#808080;
            position:absolute;
            top:10px;
            left:5px;
        }
        #maindisk{
            text-align:center;
            width:100%
        }
        #Nav{
            width:100%;
            background-color:#2d2d30;
            border-bottom:2px solid #007acc;
            height:60px;
        }
        #Nav ul li{
            position:relative;
            margin-left:4px;
            float:right;
            list-style:none;
            width:80px;
        }
        #Nav ul li a{
            color:#fff;
            text-decoration:none;
            display:block;
            line-height:60px;
        }
        #Nav ul li:hover{
            margin-left:4px;
            float:right;
            list-style:none;
            background-color:#3f3f46;
        }
        #Nav ul li:hover .NavItem{
            display:block;
            position:absolute; 
            left:0px;           
        }

        #Nav ul li .NavItem{
            background-color:#2d2d30;
            display:none;
        }

        #Nav ul li .NavItem ul li{
            float:none;
            list-style:none;
            width:80px;
            height:20px;
            line-height:20px;
        }
        #Nav ul li .NavItem ul li a{
            color:#fff;
            text-decoration:none;
            display:block;
        }
        .option {
            border: 1px solid #fff;
        }
            
        .option:hover {
            border:1px solid #007acc;
            }
    </style>
    <script src="ajaxrequest/jquery-3.1.1.js"></script>
    <script src="ajaxrequest/arequest/ajax.js"></script>
    <script src="TIA/function/_TIA/echarts.min.js"></script>
    <script src="TIA/function/overview.js"></script>
    <%--<script src="TIA/UI/JS/Widget.js"></script>--%>
    <script src="TIA/UI/JS/jqplot.js"></script>
    <script src="TIA/function/testInfo.js"></script>
   <%-- <script src="TIA/function/TIA.js"></script>--%>
    <script src="My97DatePicker/WdatePicker.js"></script>
    <script src="TIA/function/TestHisInfo/ThControl.js"></script>
    <script src="TIA/function/_TIA/TIA_Ctr.js"></script>
    <script type="text/javascript">
        var selectedId = null;
        document.onreadystatechange = function () {
            if (document.readyState == "complete") {
                HomeBtnClick('HomeBtn');
            }
        }
        function btnClickedStyle(id)
        {
            if(selectedId!=null)
            {
                //document.getElementById(selectedId).style.backgroundColor = "";
                $("#"+selectedId).css("background-color", "");
            }
            selectedId = id;
            //document.getElementById(id).style.backgroundColor = "#007acc";
            $("#"+id).css("background-color", "#007acc");
        }

        function HomeBtnClick(id)
        {
            btnClickedStyle(id);
            var uid = $("#userid").val();
            var xmla= $.ajax({
                type: "POST",
                url: 'TIA/function/overview.aspx?uid=' + uid,
                async: true,
                beforeSend: function ()
                {
                    busy('maindesk');
                },
                success: function ()
                {
                    $("#maindesk").html(xmla.responseText);
                    overview_ActiveChart();
                },
            });
          
            //Arequest('maindesk','TIA/function/overview.aspx?uid='+uid,true);
        }

        function MyTestBtnClick(id)
        {
            btnClickedStyle(id);
            //Arequest('desk', 'TIA/function/testInfo.aspx?Pindex=0', true);
            var uid = $("#userid").val();
            var tid='maindesk';
            Arequest(tid,"TIA/function/testInfo.aspx?uid="+uid, true);
        }

        function MyCountClick(id)
        {
            btnClickedStyle(id);
            var tid = 'maindesk';
            var uid = $("#userid").val();
            Arequest(tid, "TIA/function/TestHisInfo/main.aspx?uid="+uid+"&d=1", true);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="userid" type="hidden" runat="server" value="" />
    <div id="content">
<div id="Nav">
    <ul>
        <li id="HomeBtn" runat="server">
            <a href="javascript:void(0);" onclick="HomeBtnClick('HomeBtn')">主页</a>
        </li>
        <li id="MyTest_btn">
            <a href="javascript:void(0);" onclick="MyTestBtnClick('MyTest_btn')">练习</a>
        </li>
        <li id="MyCount_btn">
            <a href="javascript:void(0);" onclick="MyCountClick('MyCount_btn')">统计</a>
        </li>
    </ul>

</div>    
<div id="list">

 </div>
    <div id="maindesk">
      
    </div>
        </div>
        <div id="userInfo">
            <asp:Label ID="userid_lab" runat="server" Text="15050003"></asp:Label>
           <a id="LogOut" href="#" onclick="window.location.href='Login.aspx?LO=1' ">注销</a>
        </div>
    </form>
</body>
</html>
