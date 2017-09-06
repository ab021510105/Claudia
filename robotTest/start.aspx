<%@ Page Language="C#" AutoEventWireup="true" CodeFile="start.aspx.cs" Inherits="start"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="base.css" media="all" />
	<script type="text/javascript" charset="UTF-8" src="prefixfree.min.js"></script>
    <script  type="text/javascript" src="My97DatePicker/WdatePicker.js" id="datelist"></script>
	<style type="text/css" media="screen">
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
            color: #FF0000;
        }
/*搜索框*/
.search input[type="search"] {
	width: 298px;
	height: 40px;
	border: 10px solid #00aec7;
	text-indent: 5px;
}
.search .icon-search {
	    border-style: none;
            border-color: inherit;
            border-width: medium;
            position: absolute;
	        top: 15px;
	        right: 15px;
	        width: 32px;
	        height: 32px;
	        background-color: #00aec7;
            left: 899px;
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
.vodeo-player {
	padding: 10px;
	background-color: #323232;
}
.video-container {
	position: relative;
}
.video-container:hover .hide {
	display: block;
}
.video-container .hide {
	display: none;
	position: absolute;
	right: 10px;
}
.video-container .hide a {
	display: block;
	width: 40px;
	line-height: 40px;
	text-align: center;
	margin-top: 10px;
	background-color: rgba(0,0,0,.2);
}
.icon-like:before {
	content: "\e08c";
	color: #00aec7;
}
.icon-link:before {
	content: "\e035";
}
.vodeo-bar {
	margin-top: 10px;
}
.vodeo-bar li {
	float: left;
}
.vodeo-bar li a {
	display: block;
	text-align: center;
	width: 42px;
	height: 40px;
	background-color: #00aec7;
}
.play-button:after {
	display: inline-block;
	content: "";
	width: 0;
	height: 0;
	margin-top: 8px;
	margin-left: 12px;
	border-width: 10px 12px;
	border-style: solid;
	border-color: transparent;
	border-left-color: #fff;
}
.vodeo-progress {
	position: relative;
	width: 400px;
	height: 10px;
	margin: 12px 15px 0;
	background-color: #00aec7;
}
.vodeo-progress:after {
	position: absolute;
	left: 50%;
	content: "";
	width: 200px;
	height: 10px;
	background-color: #000;
}
.vodeo-progress span {
	position: absolute;
	top: -40px;
	left: 50%;
	color: #fff;
	padding: 5px 10px;
	margin-left: -25px;
	position: absolute;
	background-color: #000;
	z-index: 2;
}
.vodeo-progress span:before, .vodeo-progress span:after {
	position: absolute;
	content: "";
}
.vodeo-progress span:before {
	top: 36px;
	left: 18px;
	border: 8px solid #fff;
	box-shadow: 0 0 0 2px #2e2e2e;
	border-radius: 50%;
}
.vodeo-progress span:after {
	top: 100%;
	left: 50%;
	margin-left: -5px;
	border: 5px solid transparent;
	border-top-color: #000;
}
.new-tab-button {
	margin-right: 10px;
}
.icon-new-tab:before {
	content: "\e0a0";
	font-size: 24px;
}
.icon-loop:before {
	content: "\e08a";
	font-size: 24px;
}
/*选项卡*/
.tab-menu-container {
	position: relative;
	padding-top: 35px;
	height: 352px;
}
.tab-1, .tab-2 {
	position: absolute;
	width: 588px;
	height: 352px;
}
.tab-1 h2 {
	position: absolute;
	top: -35px;
	left: 0;
}
.tab-2 h2 {
	position: absolute;
	top: -35px;
	left: 140px;
	margin-left: 20px;
}
.tab-1:target, .tab-2:target {
	z-index: 1;
}
.tab-menu h2 {
	padding-left: 10px;
	height: 35px;
	line-height: 35px;
}
.tab-menu h2 a {
	display: inline-block;
	font-size: 18px;
	padding: 0 10px;
	width: 130px;
	background-color: #00aec7;
}
.tab-2 h2 a {
	background-color: #006675;
}
.tab-1:target + .tab-2 h2 a {
	background-color: #00aec7;
}
.tab-1:target h2 a, .tab-2:target h2 a, .tab-menu h2 a:hover {
	background-color: #006675;
}
.filters-bar {
	color: #fff;
	line-height: 40px;
	background-color: #006675;
}
.filters-bar strong:first-child, .text-columns span:first-child {
	width: 19%;
}
.filters-bar strong, .text-columns span {
	float: left;
	width: 27%;
	text-indent: 20px;
}
.filters-bar i:before {
	font-size: 14px;
}
.text-columns {
	padding-bottom: 20px;
	background-color: #fff;
}
.text-columns li {
	margin: 10px 0;
	height: 30px;
	line-height: 30px;
}
.text-columns li:hover, .text-columns .active {
	color: #fff;
	background-color: #00aec7;
}
/*按钮*/
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
/*价格盒子*/
[class^="price-box"] li {
	float: left;
	width: 33%;
	text-align: center;
}
[class^="item-"] {
 margin-left: 10px;
 background-color: #fff;
}
.price-box-items h2 {
	color: #fff;
	font-size: 30px;
	line-height: 60px;
	background-color: #00aec7;
}
.price-box-items h3 {
	font-size: 24px;
	line-height: 100px;
}
.price-box-items h3 span {
	font-size: 48px;
}
.price-box-items em {
	color: #00aec7;
}
.price-box-items p {
	color: #969696;
	padding: 0 20px 40px;
}
.price-box-items [class^="item-"]:hover h2, [class^="item-"].active h2 {
	background-color: #006675;
}
.price-box-2 [class^="item-"] {
	background-color: #323232;
}
.price-box-2 .price-box-items h3 {
	color: #fff;
}
/*时钟动画*/
@keyframes minutes-1 {
 0% {
 top: 0;
}
 100% {
 top: -660px;
}
}
@keyframes minutes-2 {
 0% {
 top: 0px;
}
 100% {
 top: -1100px;
}
}
@keyframes hours-1 {
 0% {
 top: 0;
}
 100% {
 top: -330px;
}
}
@keyframes hours-2 {
 0% {
 top: 0px;
}
 100% {
 top: -1100px;
}
}
/*进度条动画*/
@keyframes bar-1 {
 0% {
 width: 0;
}
 100% {
 width: 100%;
}
}
        .auto-style1 {
            height: 22px;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            color: #CC0000;
        }
        .backgroundcolor{
            background-color:rgba(0, 174, 199, 0.26);
        }
        .auto-style5 {
            height: 30px;
        }
        .auto-style6 {
            width: 30%;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div style="text-align:right;background-color:rgba(0, 102, 117, 0.68)">
       <asp:LinkButton ID="land" runat="server" Font-Size="Small" Text="登入" Visible="false" OnClick="land_Click"></asp:LinkButton>
       <asp:Label ID="username" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
       &nbsp;
       <asp:LinkButton ID="landout" runat="server" Font-Size="Small" OnClick="landout_Click" ForeColor="White">注销</asp:LinkButton>
   </div>
        <section class="demo">
    <div class="row">
        <div class="nav">
            <ul class="nav-item clearfix">
                <li><a><asp:LinkButton ID="Add" runat="server" ForeColor="White" OnClick="Add_Click">Add</asp:LinkButton></a></li>
                 <li><a><asp:LinkButton ID="Edit" runat="server" ForeColor="White" OnClick="Edit_Click">Edit</asp:LinkButton></a></li>
                <li><a><asp:LinkButton ID="Delete" runat="server" ForeColor="White" OnClick="Delete_Click">Delete</asp:LinkButton></a></li>
                <li><a><asp:LinkButton ID="home" runat="server" OnClick="home_Click"  ForeColor="White">Home</asp:LinkButton></a> </li>
                <li><a><asp:LinkButton ID="ClassInfo" runat="server" ForeColor="White" OnClick="ClassInfo_Click" >ClassInfo</asp:LinkButton></a></li>
                <li><a><asp:LinkButton ID="Ourstudent" runat="server" ForeColor="White">Notice</asp:LinkButton></a></li>
                <li><a><asp:LinkButton ID="About" runat="server" ForeColor="White" OnClick="About_Click">About</asp:LinkButton></a></li>
            </ul>
        </div>
   <div>
       <asp:Label ID="Tips" runat="server" Visible="false" ForeColor="Red"></asp:Label>&nbsp;
   </div>
        <div id="_GridView" runat="server">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" GridLines="Horizontal" Height="100%" Width="100%" AllowPaging="True" AllowSorting="True" DataKeyNames="Contactid" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound" OnLoad="GridView1_Load" >
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                        <asp:LinkButton ID="Select" CommandName="Select" CommandArgument='<%#Bind("Contactid") %>'  runat="server" Text="选择"  ForeColor="Blue" Visible="true"/>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学生姓名" SortExpression="ChildrenCall" >
                        <ItemTemplate>
                            <asp:Label ID="ChildrenCall_Label" runat="server" Text='<%# Bind("ChildrenCall") %>' ></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="ChildrenCall_TextBox" runat="server" Text='<%# Bind("ChildrenCall") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="联系电话" SortExpression="Contact">
                        <ItemTemplate>
                            <asp:Label ID="Contact_Label" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="Contact_TextBox" runat="server" Text='<%# Bind("Contact") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="家长称呼" SortExpression="ParentsCall">
                        <EditItemTemplate>
                            <asp:TextBox ID="ParentsCall_TextBox" runat="server" Text='<%# Bind("ParentsCall") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ParentsCall_Label" runat="server" Text='<%# Bind("ParentsCall") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            
                            <asp:LinkButton ID="More" CommandName="More" CommandArgument='<%# Eval("Contactid") %>' runat="server" Text="详细"  ForeColor="Blue"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>    
                <PagerTemplate>

                </PagerTemplate>            
            </asp:GridView>  
        <div style="text-align:right">
            <asp:Label ID="Pagecount" runat="server"></asp:Label> &nbsp;
             <asp:LinkButton ID="firstpage" runat="server" Text="首页" CommandName="firstpage" ForeColor="Blue" Font-Underline="true" OnClick="firstpage_Click"></asp:LinkButton>&nbsp
                    <asp:LinkButton ID="lestpage" runat="server" Text="尾页" CommandName="lestpage" ForeColor="Blue" Font-Underline="true" OnClick="lestpage_Click"></asp:LinkButton>&nbsp
                    <asp:LinkButton ID="frontpage" runat="server" Text="上一页" CommandName="front" CommandArgument="First" ForeColor="Blue" Font-Underline="true" OnClick="frontpage_Click"></asp:LinkButton> &nbsp
                    <asp:DropDownList ID="pagecontrol" runat="server" AutoPostBack="True" Height="21px" OnSelectedIndexChanged="pagecontrol_SelectedIndexChanged" Width="39px"></asp:DropDownList>
                    <asp:LinkButton ID="nextpage" runat="server" Text="下一页" CommandName="next" CommandArgument="Next" ForeColor="Blue" Font-Underline="true" OnClick="nextpage_Click"></asp:LinkButton>&nbsp

        </div>
            </div>
            <div id="addtable" runat="server"  style="background-color:white;border:solid;border-bottom-width:1px;border-color:rgba(0,0,0,.2)" class="controls-form-texts mt-60" visible="false">
            <table border="0" style="width:100%;background-color:rgba(0, 102, 117, 0.18)">
                <tr>
                    <td style="text-align:right;width:35%" class="auto-style1">
                        <span class="auto-style3">咨询者姓名:</span>
                    </td>
                    <td style="text-align:left;" class="auto-style1" >
                    &nbsp;<Asp:TextBox name="text edit"  placeholder="这里指孩子姓名"  ID="chrildname" runat="server" style="text-align:center"/>&nbsp <span class="auto-style4">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">
                       <span class="auto-style3">咨询者性别:</span>
                    </td>
                    <td style="text-align:left">
                    &nbsp;<Asp:TextBox name="text edit"  placeholder="孩子性别只允许填男或女"  ID="childsex" runat="server" style="text-align:center"/> &nbsp <span class="auto-style4"><asp:Label runat="server" ID="sex_errorlab" Visible="false"></asp:Label>*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        <span class="auto-style3">联系电话:</span>
                    </td>
                    <td style="text-align:left">
                       &nbsp; <asp:TextBox name="text edit" placeholder="只允许数字不允许出现符号"  ID="PhoneNumber" runat="server" style="text-align:center" />&nbsp;<span class="auto-style4"><asp:Label runat="server" ID="PN_error" Visible="false"></asp:Label>*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        <span class="auto-style3">咨询者年龄:</span>
                    </td>
                    <td style="text-align:left">
                       &nbsp; <asp:TextBox name="text edit" placeholder="只允许输入数字" ID="Age" runat="server" style="text-align:center"/>&nbsp <span class="auto-style4"><asp:Label runat="server" ID="Age_error" Visible="false"></asp:Label>*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        <span class="auto-style3">咨询者年级:</span>
                    </td>
                    <td style="text-align:left">
                        &nbsp;<asp:TextBox placeholder="孩子年级"  ID="ClassLv" runat="server" style="text-align:center"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:right">
                        <span class="auto-style3">监护人称呼:</span>
                    </td>
                    <td style="text-align:left">
                        &nbsp;<asp:TextBox placeholder="监护者称呼"  ID="ParentsCall" runat="server" style="text-align:center" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        <span class="auto-style3">就读学校:</span>
                    </td>
                    <td style="text-align:left">
                        &nbsp;
                        <input type="text" id="school_TextBox" placeholder="学校名称" runat="server"  style="text-align:center" />
                    </td>
                    </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr id="ReceptionTime_tr" runat="server">
                    <td style="text-align:right">
                        <span class="auto-style3">上门时间:</span>
                    </td>
                    <td style="text-align:left">
                        &nbsp;<input type="text" runat="server" id="Reception" onclick="WdatePicker()" placeholder="上门日期" style="text-align:center;border-color:blue" />
                    </td>
                </tr>
                <tr id="Collter" runat="server" visible="false">
                    <td style="text-align:right">
                        <span class="auto-style3">孩子星座:</span>
                    </td>
                    <td style="text-align:left">
                        &nbsp;<asp:TextBox ID="Collter_textbox" runat="server" placeholder="这里输入孩子星座"  style="text-align:center" CssClass=" text-eduit focus-5" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">
                        <span class="auto-style3">备注:</span>
                    </td>
                    <td style="text-align:left">
                        &nbsp;<asp:TextBox ID="Remark_TextBox" runat="server" TextMode="MultiLine" CssClass="text-eduit focus-5" Height="67px" Width="300px"></asp:TextBox> &nbsp; 
                    </td>
                </tr>
                <tr>
                    <td>


                    </td>
                    <td>

                   </td>
                </tr>
               
                <tr>
                    <td>

                    </td>
                    <td>
                        <div class="controls-buttons mt-40" style="background-color:white">
                    <div class="big-buttons">
                        <asp:Button ID="Add_button" runat="server" CssClass="active" Text="添加"  ForeColor="White" OnClick="Add_button_Click"/>&nbsp;
                        <asp:LinkButton ID="Retrun" runat="server" Text="取消" ForeColor="Blue" Font-Size="Small" Font-Underline="true" Font-Italic="false" OnClick="Retrun_Click"></asp:LinkButton>
                    </div>
                    </div>
                    </td>
                </tr>
            </table>
                
                </div>
        <div id="moretable" runat="server" visible="false">
                        <p style="text-align:right;">
                <asp:LinkButton ID="Back" runat="server" Text="返回" ForeColor="Blue" OnClick="Back_Click"></asp:LinkButton>
            </p>
            <table border="1" style="background-color:white; width:100%">
                <tr class="backgroundcolor">
                    <td style="text-align:center">
                        <span class="auto-style3">咨询师:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                        <span class ="auto-style3"><asp:Label ID="UserName_Label" runat="server" text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <span class="auto-style3">咨询时间:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                        <span class="auto-style3"><asp:Label ID="Time_Label" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr class="backgroundcolor">
                    <td style="text-align:center">
                        <span class="auto-style3">状态:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                        <span class="auto-style3"><asp:Label ID="SignUp_Label" runat="server" Text="未报名"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <span class="auto-style3">上门时间:</span>
                    </td>
                    <td style="text-align:left">
                        <span class="auto-style3"><asp:Label ID="Reception_label" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr class="backgroundcolor">
                    <td style="text-align:center; " class="auto-style6">
                        <span class="auto-style3">咨询者姓名:&nbsp;</span>
                    </td>
                    <td style="text-align:left" class="auto-style5">
                        <asp:Label ID="childerName_label" runat="server" Text="Null"   CssClass="auto-style3"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;width:30%">
                        <span class="auto-style3">性别:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                        <span class="auto-style3"><asp:Label ID="Sex_label" runat="server" Text="男"></asp:Label></span>
                    </td>
                </tr>
                <tr class="backgroundcolor">
                    <td style="text-align:center">
                        <span class="auto-style3">咨询者年龄:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                        <span class="auto-style3"><asp:Label ID="Age_Label" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;width:30%">
                        <span class="auto-style3">咨询者年级:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                      <span class="auto-style3"><asp:Label ID="ClassLv_label" runat="server" Text="Null"></asp:Label></span>

                    </td>
                </tr>
                <tr class="backgroundcolor">
                    <td style="text-align:center;">
                        <span class="auto-style3">在读学校:&nbsp;</span>
                    </td>
                    <td style="text-align:left;">
                        <span class="auto-style3"><asp:Label ID="School_Label" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center" class="auto-style5">
                        <span class="auto-style3">联系方式:&nbsp;</span>
                    </td>
                    <td style="text-align:left" class="auto-style5">
                        <span class="auto-style3"><asp:Label ID="Contact_label" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr class="backgroundcolor">
                    <td style="text-align:center">
                        <span class="auto-style3">监护人称呼:&nbsp;</span>
                    </td>
                    <td style="text-align:left;">
                        <span class="auto-style3"><asp:Label ID="Parents_Call" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr id="Collet_Tr_More" runat="server" visible="false">
                    <td style="text-align:center; width:30%">
                        <span class="auto-style3">星座:</span>
                    </td>
                    <td style="text-align:left">
                        <span class="auto-style3"><asp:Label ID="Colltell_label" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <span class="auto-style3">备注:&nbsp;</span>
                    </td>
                    <td style="text-align:left;">
                        <span class="auto-style3"><asp:TextBox ID="Remarks_label" runat="server" TextMode="MultiLine"  style=" background-color:white;border-color:white"  BorderStyle="None" Enabled="false"  BorderWidth="0px" ForeColor="Black"></asp:TextBox></span>
                    </td>
                </tr>
                <tr class="backgroundcolor">
                    <td style="text-align:center">
                      <span class="auto-style3"> 信息来源:&nbsp;</span>
                    </td>
                    <td style="text-align:left">
                         <span class="auto-style3"><asp:Label ID="Canal" runat="server" Text="Null"></asp:Label></span>
                    </td>
                </tr>
            </table>

        </div>
                   
            <div class="controls-drop-down " style="text-align:right">
            <div class="form-item search">
                  <input type="search" name="search" id="search" placeholder="Search" class="search input"/>
                  <Asp:ImageButton  CssClass="icon-search" ID="searchbutton" runat="server" ImageUrl="easyui/themes/icons/search.png" OnClick="searchbutton_Click"/>
                </div>
         </div> 
        </div>
            
           </section>
        <div style="position:fixed;left:0%;bottom:0%; background-color:rgba(0, 0, 0, 0.15);width:20%;">
            <%--<asp:LinkButton ID="hide" runat="server" Text="隐藏" Font-Size="X-Small" style="position:inherit;top:0%;right:0%" OnClick="hide_Click"></asp:LinkButton>--%>
            <ul style="text-align:left" runat="server" id="InfoTab">
                <li>
            <asp:Label ID="Info0" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                    </li>
           <li><asp:Label ID="Info1" runat="server" Text="" Font-Size="Smaller"></asp:Label></li>
           <li><asp:Label ID="Info2" runat="server" Text="" Font-Size="Smaller"></asp:Label></li>
            <li><asp:Label ID="Info3" runat="server" Text="" Font-Size="Smaller"></asp:Label></li>
            <li><asp:Label ID="Info4" runat="server" Text="" Font-Size="Smaller"></asp:Label></li>
             </ul>
        </div>
       
        </form>

</body>
</html>
