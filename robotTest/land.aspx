<%@ Page Language="C#" AutoEventWireup="true" CodeFile="land.aspx.cs" Inherits="land" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="base.css" media="all" />
	<script type="text/javascript" charset="UTF-8" src="prefixfree.min.js"></script>
    <title></title>
    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="easyui/themes/icon.css"/>
	<link rel="stylesheet" type="text/css" href="easyui/demo.css"/>
	<script type="text/javascript" src="easyui/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>
     <style type="text/css">
         .auto-style2 {
            width: 100%;
            background-color: #F6F6F6;
            margin:auto;
             height: 16px;
         }
         .auto-style4 {
             text-align:center;
             width: 100%;
         }
body {
	background-color: #dbdbdb;
}
[class^="icon-"]:before {
	font-family: 'icomoon';
	speak: none;
	font-weight: normal;
	-webkit-font-smoothing: antialiased;
	font-size: 18px;
	color: #fff;
}
@font-face {
	font-family: 'icomoon';
	src: url('fonts/icomoon.eot');
	src: url('fonts/icomoon.eot?#iefix') format('embedded-opentype'),  url('fonts/icomoon.svg#icomoon') format('svg'),  url('fonts/icomoon.woff') format('woff'),  url('fonts/icomoon.ttf') format('truetype');
	font-weight: normal;
	font-style: normal;
}
.mt-20 {
	margin-top: 20px;
}
.mt-40 {
	margin-top: 40px;
}
.mt-60 {
	margin-top: 60px;
}
.mr-10 {
	margin-right: 10px;
}
.fl {
	float: left;
}
.fr {
	float: right;
}
.inline {
	display: inline-block;
}
.fsize20 {
	font-size: 20px;
}
.fsize10 {
	font-size: 10px;
}
.demo {
	width: 950px;
	margin: 40px auto;
}
.demo a, .demo a:hover {
	color: #fff;
	text-decoration: none;
}
.span-1 {
	width: 320px;
}
.span-2 {
	width: 350px;
	margin: 0 40px;
}
.span-3 {
	width: 200px;
}
.span-4 {
	width: 588px;
	margin-left: 40px;
}
::-webkit-input-placeholder, :-moz-placeholder {
 font-size: 14px;
 font-style: italic;
}
/*导航*/
.nav-item {
	line-height: 60px;
	background-color: #00aec7;
}
.nav-item > li {
	position: relative;
	float: left;
}
.nav-item > li a {
	display: block;
}
.nav-item > li > a {
	font-size: 19px;
	font-weight: bold;
	padding: 0 31px;
	border-left: 1px solid #3bc1d4;
}
.nav-item > li:first-child > a {
	border-left: none;
}
.nav-item li a:hover, .nav-item > li:hover > a {
	background-color: #006675;
}
.nav-item > li .nav-sub-item {
	display: none;
	position: absolute;
	left: 1px;
	font-size: 14px;
	width: 100%;
	line-height: 40px;
	background-color: #00aec7;
}
.nav-sub-item li a {
	padding-left: 31px;
}
.nav-item > li:hover .nav-sub-item {
	display: block;
}
/*==下拉控件==*/
.controls-drop-down {
	height: 362px;
}
.controls-drop-down .form-item {
	position: relative;
	font-size: 14px;
}
/*搜索框*/
.search input[type="search"] {
	width: 298px;
	height: 40px;
	border: 10px solid #00aec7;
	text-indent: 5px;
}
.search .icon-search {
	position: absolute;
	top: 15px;
	right: 15px;
	width: 32px;
	height: 32px;
	border: none;
	background-color: #00aec7;
}
.icon-search:before {
	content: "\7d";
}
/*选择框*/
.select {
	position: relative;
}
.select:after {
	position: absolute;
	top: 25px;
	right: 15px;
	content: "";
	border: 8px solid transparent;
	border-top-color: #00aec7;
}
.select select {
	appearance: none;
	width: 320px;
	height: 60px;
	border: 10px solid #00aec7;
	text-indent: 5px;
}
.select .select-item {
	margin-top: 20px;
	width: 300px;
	height: 40px;
	border: 10px solid #00aec7;
}
.select .select-value {
	line-height: 40px;
	box-shadow: 0 0 5px 1px rgba(0,0,0,.2);
	background-color: #fff;
}
.select-value li {
	margin-bottom: 10px;
}
.select-value a, .select-value a:hover {
	display: block;
	color: #444;
	padding-left: 10px;
}
.select-value li:not(:first-child) a:hover {
	color: #fff;
	background-color: #00aec7;
}
.select-value li:not(:first-child) {
	display: none;
}
.select-value:hover li {
	display: block;
}
/*时钟*/
.clock-item li {
	float: left;
	width: 110px;
	line-height: 30px;
	text-align: center;
	margin-right: 10px;
	overflow: hidden;
}
.clock-item .hours, .clock-item .minutes {
	position: relative;
	line-height: 110px;
	height: 110px;
	font-size: 60px;
	background-color: #00aec7;
}
.clock-item span {
	position: absolute;
	display: inline-block;
	width: 45px;
}
.clock-item .hours-1, .clock-item .minutes-1 {
	left: 0;
	margin-left: 10px;
}
.clock-item .hours-2, .clock-item .minutes-2 {
	right: 0;
	margin-right: 10px;
}
.clock-item a {
	color: #000;
	text-decoration: none;
}
.hours:before, .hours:after, .minutes:before, .minutes:after {
	position: absolute;
	top: 50%;
	left: 0;
	content: '';
}
.hours:before, .minutes:before {
	margin-top: -4px;
	height: 10px;
	width: 2px;
	box-shadow: 8px 0 0 0 #fff, 100px 0 0 0 #fff;
}
.hours:after, .minutes:after {
	width: 100%;
	border-top: 1px solid #fff;
}
.minutes .minutes-2 {
	animation: minutes-2 600s steps(10, end) infinite;
}
.minutes .minutes-1 {
	animation: minutes-1 3600s steps(6, end) infinite;
}
.hours .hours-2 {
	animation: hours-2 36000s steps(10, end) infinite;
}
.hours .hours-1 {
	animation: hours-1 2160000s steps(3, end) infinite;
}
/*进度条*/
.progress-bar-item {
	position: relative;
	width: 100%;
	height: 10px;
	background-color: #323232;
}
.progress {
	position: relative;
	height: 10px;
	background-color: #00aec7;
}
.bar-1 .progress {
	width: 0;
	animation: bar-1 10s linear 2s infinite;
}
.bar-2 .progress {
	width: 80%;
}
.bar-3 .progress {
	width: 20%;
}
.bar-4 .progress {
	width: 60%;
}
.bar-3 .progress:after, .bar-4 .progress:after {
	position: absolute;
	top: -50%;
	right: -8px;
	content: "";
	width: 15px;
	height: 15px;
	border: 2px solid #323232;
	border-radius: 50%;
	background-color: #fff;
}
[class^="bar-"] span {
	position: absolute;
	top: 100%;
	right: -25px;
	color: #fff;
	margin-top: 10px;
	width: 50px;
	line-height: 26px;
	text-align: center;
	background-color: #322332;
}
.bar-3 span {
	top: 15px;
}
[class^="bar-"] span:after {
	position: absolute;
	top: -10px;
	left: 20px;
	content: "";
	border: 5px solid transparent;
	border-bottom-color: #323223;
}
.controls-form-texts {
	line-height: 60px;
}
.controls-form-texts input[type="text"] {
	width: 310px;
	height: 40px;
	padding-left: 3px;
	text-indent: 5px;
	border: none;
	border-radius: 1px;
	box-shadow: 0 2px 5px rgba(0,0,0,.3);
	transition: all 300ms;
}
.controls-form-texts ::-webkit-input-placeholder {
 font-size: 14px;
 font-style: normal;
 color: #333;
}
.select-text {
	position: relative;
}
.select-text:before, .select-text:after {
	position: absolute;
	right: 20px;
	content: "";
	width: 1px;
	height: 1px;
	border: 8px solid transparent;
	border-width: 8px;
}
.select-text:before {
	top: 12px;
	border-bottom-color: #00aec7;
}
.select-text:after {
	top: 32px;
	border-top-color: #00aec7;
}
input[type="text"].focus-5, .form-item-login input:focus, .controls-form-texts input[type="text"]:focus {
	outline: 0 none;
	box-shadow: 0 0 0 5px #00aec7;
}
/*登录框*/
.controls-login {
	color: #fff;
	background-color: #323232;
}
.form-login {
	padding: 20px;
	line-height: 60px;
}
.form-login h3 {
	font-size: 24px;
	font-weight: normal;
	text-align: center;
}
.form-login input[type="text"], .form-login input[type="password"] {
	width: 100%;
	height: 40px;
	border: none;
	text-indent: 5px;
	border-radius: 1px;
	transition: all 300ms;
}
.info-list {
	line-height: 20px;
	color: #808080;
}
.info-list input[type='checkbox'] {
	vertical-align: middle;
	margin-right: 3px;
}
.form-login input:focus {
	outline: 0 none;
	box-shadow: 0 0 0 5px #00aec7;
}
.form-login button[type="button"] {
	font-size: 24px;
	color: #fff;
	width: 100%;
	height: 70px;
	margin: 38px 0 30px;
	border: none;
	background-color: #00aec7;
}
/*日历*/
[class^="controls-calendar"] {
 background-color: #00aec7;
}
.calendar-header {
	color: #fff;
	background-color: #323232;
}
.icon-calendar:before {
	display: inline-block;
	width: 30px;
	height: 30px;
	content: "\46";
}
.calendar-header h2 {
	font-size: 18px;
	font-weight: normal;
	text-align: center;
	line-height: 35px;
	padding: 10px 10px 0;
}
.calendar-header .arrow a {
	position: relative;
	display: inline-block;
	width: 15px;
	height: 30px;
}
.calendar-header .arrow a:after {
	position: absolute;
	top: 7px;
	left: 0;
	content: "";
	width: 1px;
	height: 1px;
	border: 7px solid transparent;
}
.calendar-header a.prev-month:after {
	border-right-color: #fff;
}
.calendar-header a.next-month:after {
	border-left-color: #fff;
}
.controls-calendar-dayview li {
	float: left;
	width: 50px;
	text-align: center;
	line-height: 50px;
}
.week-days li {
	color: #a7a7a7;
	line-height: 22px;
}
.calendar-body {
	overflow: hidden;
}
.days a {
	display: block;
	font-size: 18px;
	font-weight: bold;
	border-right: 1px solid #fff;
	border-bottom: 1px solid #fff;
}
.days li:nth-child(7n) a {
	border-right: none;
}
.days li:nth-last-child(-n+7) a {
	border-bottom: none;
}
.dull {
	color: #c5c5c5;
}
.highlighted-day {
	background-color: #f00;
}
.current-day, .current-months, .calendar-body a:hover {
	background-color: #006675;
}
.months li {
	float: left;
	width: 25%;
	text-align: center;
	line-height: 90px;
}
.months a {
	display: block;
	font-size: 18px;
	font-weight: bold;
	height: 90px;
	line-height: 85px;
	border-right: 1px solid #fff;
	border-bottom: 1px solid #fff;
}
.months li:nth-child(4n) a {
	border-right: none;
}
.months li:nth-last-child(-n+4) a {
	border-bottom: none;
}
.highlighted-months {
	position: relative;
}
.highlighted-months:after {
	position: absolute;
	bottom: 10px;
	left: 7%;
	content: "";
	width: 86%;
	height: 2px;
	background-color: #f00;
}
/*视图按钮*/
.views-item a {
	float: left;
	width: 40px;
	line-height: 40px;
	text-align: center;
	border-right: 1px solid #5acbdb;
	background-color: #00aec7;
}
.views-item a:hover {
	background-color: #006675;
}
.icon-paragraph-justify:before {
	content: "\e048";
}
.icon-paragraph-left:before {
	content: "\e031";
}
.icon-paragraph-center:before {
	content: "\e03a";
}
.icon-paragraph-right:before {
	content: "\e03f";
}
/*分享按钮*/
.share-btn {
	position: relative;
	display: block;
	width: 100px;
	line-height: 30px;
	padding-right: 30px;
	text-align: center;
	background-color: #00aec7;
}
.share-btn a:before {
	position: absolute;
	top: 0;
	right: 0;
	width: 30px;
	height: 30px;
	border-left: 1px solid #87d9e5;
}
.icon-thumbs-up:before {
	content: "\e071";
}
.icon-twitter:before {
	content: "\e0a2";
}
.share-btn span {
	display: none;
	position: absolute;
	top: 0;
	right: -70px;
	width: 60px;
	line-height: 30px;
	text-align: center;
	background-color: #323223;
}
.share-btn span:after {
	position: absolute;
	top: 10px;
	left: -10px;
	content: "";
	border: 5px solid transparent;
	border-right-color: #323223;
}
.share-btn:hover {
	background-color: #006675;
}
.share-btn:hover span {
	display: block;
}
/*复选框*/
.controls-checkboxs .checkbox-item {
	display: inline-block;
}
.controls-checkboxs input[type="checkbox"] {
	display: none;
}
label.radius {
	border-radius: 1em;
}
label.radius:before {
	border-radius: 50%;
}
.controls-checkboxs label {
	position: relative;
	display: inline-block;
	color: #fff;
	width: 4.5em;
	height: 2em;
	background-color: #323232;
}
.controls-checkboxs label:before, .controls-checkboxs label:after {
	position: absolute;
	content: "";
}
.controls-checkboxs label:before {
	margin: .25em;
	width: 1.5em;
	height: 1.5em;
	background-color: #fff;
	transition: margin-left .3s;
}
.controls-checkboxs label:after {
	margin-top: .25em;
	margin-left: 2.25em;
	content: attr(data-off);
	transition: margin-left .5s;
}
.controls-checkboxs input:checked + label {
	background-color: #00aec7;
}
.controls-checkboxs input:checked + label:before {
	margin-left: 2.7em;
}
.controls-checkboxs input:checked + label:after {
	content: attr(data-on);
	margin-left: .5em;
}
/*色板*/
.color-wheel img {
	margin: 10px 0 0 -20px;
}
/*功能按钮*/
.icon-items li a {
	float: left;
	width: 20px;
	height: 20px;
	text-align: center;
	line-height: 20px;
	margin-right: 5px;
	background-color: #00aec7;
}
.icon-items .checked {
	background-color: #323232;
}
.icon-items i:before {
}
.icon-checked:before {
	content: "\e054";
	font-size: 16px;
}
.icon-close:before {
	content: "\e055";
	font-size: 12px;
}
.icon-menu:before {
	content: "\e09b";
}
.icon-plus:before {
	content: "\e093";
	font-size: 12px;
}
.icon-minus:before {
	content: "\e092";
	font-size: 12px;
}
.icon-radio-checked:before {
	content: "\e01e";
	font-size: 14px;
}
.icon-radio-unchecked:before {
	content: "\e023";
	font-size: 14px;
}
.social-items li {
	float: left;
	width: 53px;
	text-align: center;
	line-height: 53px;
	margin-bottom: 20px;
	margin-right: 15px;
}
.social-items li:nth-child(3n) {
	margin-right: 0;
}
.social-items li a {
	display: block;
	background-color: #00aec7;
}
.social-items li a:hover {
	background-color: #006675;
}
.icon-tumblr:before {
	content: "\e0b7";
}
.icon-facebook:before {
	content: "\e049";
}
.icon-pinterest:before {
	content: "\e0bc";
}
.icon-yahoo:before {
	content: "\e0bd";
}
.icon-blogger:before {
	content: "\e0b1";
}
.icon-vimeo:before {
	content: "\e06a";
}
.icon-linkedin-2:before {
	content: "\e0aa";
}
.icon-dribbble-3:before {
	content: "\e04b";
}
.icon-github-2:before {
	content: "\e063";
}
/*手风琴*/
[class^="accordion"] {
 padding: 10px;
 background-color: #fff;
}
[class^="accordion"] li {
	margin-bottom: 10px
}
[class^="accordion"] li img {
	max-width: 320px;
	vertical-align: middle;
}
[class^="accordion"] input[type="radio"] {
	display: none;
}
[class^="accordion"] label {
	display: block;
	color: #fff;
	line-height: 40px;
	font-weight: bold;
	font-size: 18px;
	padding: 0 5px;
	background-color: #00aec7;
}
[class^="accordion"] input[type="radio"]:checked + label, .accordion label:hover {
	background-color: #006675;
}
[class^="accordion"] input[type="radio"]:checked ~ .accordion-content {
	display: block;
}
.accordion-content {
	display: none;
	padding: 10px 0 20px;
}
.accordion-content h3 {
	font-size: 14px;
	line-height: 30px;
}
.accordion-2 {
	background-color: #323232;
}
.accordion-2 .accordion-content {
	color: #fff;
	background-color: #323232;
}
/*视频播放器*/

.big-buttons, .normal-buttons {
	float: left;
}
.big-buttons {
	width: 340px;
	margin-left: 20px;
	font-size: 18px;
	font-weight: bold;
}
.normal-buttons {
	width: 220px;
	font-size: 14px;
	font-weight: bold;
}
.controls-buttons button {
	color: #fff;
	text-align: center;
	margin-bottom: 10px;
	border: none;
	background-color: #00aec7;
}
.normal-buttons button {
	width: 90px;
	line-height: 30px;
}
.big-buttons button {
	width: 150px;
	line-height: 50px;
	margin-bottom: 15px;
}
.controls-buttons button:nth-child(odd) {
	margin-right: 20px;
}
.controls-buttons .black {
	background-color: #000;
}
.controls-buttons .active, .controls-buttons button:hover {
	background-color: #006675;
}

         </style>
    </head>
<body>
    <div id="form1" runat="server" style="text-align:center">
        <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="disk top/abstractsdark4.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div class="span-2 fl" style="text-align:center;">

        <div class="controls-login" style="position:absolute;top:20%;right:40%; width:300px">
              <div class="form-login">
            <h3>LOGIN</h3>
            <form  method="get" accept-charset="utf-8" class="mt-20" runat="server">
                  <div class="form-item">
                <input type="text" name="username" id="username" placeholder="Username" runat="server"/>
                      
              </div>
                  <div class="form-item">
                <Asp:TextBox  name="pwd" id="pwd" placeholder="Password" runat="server" TextMode="Password"/>
              </div>
                  <div class="form-item info-list">
                <Asp:CheckBox  name="showpwd" value="" id="showpwd" checked="false" runat="server" AutoPostBack="True" OnCheckedChanged="showpwd_CheckedChanged"/>
                <label for="showpwd">Show password</label>
                <Asp:LinkButton ID="changword" runat="server" href="#" class="fr" OnClick="changword_Click">Change password?</Asp:LinkButton> 
                      </div>
                  <div class="form-item">
                <asp:Button ID="buuton1" runat="server"  onclick="Button1_Click"  Text="Sign In" BackColor="#323232" ForeColor="#F6F6F6" BorderColor="#F6F6F6" BorderStyle="Solid"/>
              </div>
                </form>
          </div>
            </div>
            </div>
        </div>
</body>
</html>
