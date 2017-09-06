﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head id="Head1" runat="server">
	<meta  http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title></title>
	<link rel="stylesheet" type="text/css" href="base.css" media="all" />
	<script type="text/javascript" charset="UTF-8" src="prefixfree.min.js"></script>
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
</style>
	</head>
	<body>
	<link href="/templets/skins/style/yulan.css" rel="stylesheet">
<div id="header">
  <div id="top">
    <div id="warp">
      <div class="topleft fl"> 
          <a href="/">网站首页</a> <a href='/list-58.html' title='JS代码'>JS代码</a> <a href='/list-5.html' title='Jquery插件'>Jquery插件</a> <a href='/list-56.html' title='前端设计'>前端设计</a> <a href='/list-100.html' title='素材下载'>素材下载</a> <a href='/list-20.html' title='网页模板'>网页模板</a> <a href='/list-4.html' title='网页特效'>网页特效</ <a href='/list-59.html' title='CMS教程'>CMS教程</a> <a href='/list-81.html' title='CMS插件'>CMS插件</a> <a href='/list-57.html' title='网络编程'>网络编程</a> <a href='/list-60.html' title='电脑教程'>电脑教程</a> <a href='/list-55.html' title='站长技术'>站长技术</a> <a href='/list-54.html' title='IT互联网'>IT互联网</a>
      </div>
      <div class="topright fr"><a href="/">返回首页</a></div>
    </div>
  </div>
</div>
<div class="page">
      <header id="header1">
    <hgrounp class="white blank">
        <!--Logo-->
    <h1>Metrostyle Web UI</h1>
    <h2>
    <h2>
    </hgrounp>
  </header>
      <section class="demo">
    <div class="row"> 
          <!--导航-->
          <div class="nav">
        <ul class="nav-item clearfix">
              <li><a href="#">Home</a></li>
              <li><a href="#">Services</a></li>
              <li><a href="#">Products</a></li>
              <li><a href="#">About</a></li>
              <li><a href="#">Contact</a></li>
              <li><a href="#">Blog</a></li>
              <li> <a href="#">Shop On-line</a>
            <ul class="nav-sub-item">
                  <li><a href="#">Videogames</a></li>
                  <li><a href="#">Software</a></li>
                  <li><a href="#">Electronics</a></li>
                  <li><a href="#">Music</a></li>
                  <li><a href="#">Books</a></li>
                </ul>
          </li>
            </ul>
      </div>
        </div>
    <div class="row clearfix mt-40">
          <div class="span-1 fl">
        <div class="controls-drop-down">
              <form action="" method="get" accept-charset="utf-8">
            <!--搜索框-->
            <div class="form-item search">
                  <input type="search" name="search" id="search" placeholder="Search">
                  <button type="button" class="icon-search"></button>
                </div>
            <!--选择框-->
            <div class="select mt-20">
                  <select name="select" class="icon-select">
                <option value="">United States</option>
                <option value="">Europe</option>
                <option value="">Asia Pacific</option>
                <option value="">Africa, Middle East, India</option>
              </select>
                </div>
            <div class="select">
                  <div class="select-item">
                <ul class="select-value">
                      <li><a href="" title="">United States</a></li>
                      <li><a href="" title="">Europe</a></li>
                      <li><a href="" title="">Asia Pacific</a></li>
                      <li><a href="" title="">Africa, Middle East, India</a></li>
                    </ul>
              </div>
                </div>
          </form>
            </div>
        <!--时钟-->
        <div class="controls-clock clearfix mt-20">
              <ul class="clock-item">
            <li class="hours"> <span class="hours-1">0 1 2 </span> <span class="hours-2">0 1 2 3 4 5 6 7 8 9 </span> </li>
            <li class="minutes"> <span class="minutes-1">0 1 2 3 4 5 </span> <span class="minutes-2">0 1 2 3 4 5 6 7 8 9 </span> </li>
            <li>Hours</li>
            <li>Minutes</li>
          </ul>
            </div>
        <!--进度条-->
        <div class="controls-progress-bar">
              <div class="progress-bar-item mt-20">
            <div class="bar-1">
                  <div class="progress"></div>
                </div>
            <p>Loading...</p>
          </div>
              <div class="progress-bar-item mt-40">
            <div class="bar-2">
                  <div class="progress"> <span>80%</span> </div>
                </div>
          </div>
              <div class="progress-bar-item mt-60">
            <div class="bar-3">
                  <div class="progress"> <span>20%</span> </div>
                </div>
          </div>
              <div class="progress-bar-item mt-60">
            <div class="bar-4">
                  <div class="progress"> <span>60%</span> </div>
                </div>
          </div>
            </div>
        <!--文本框-->
        <div class="controls-form-texts mt-60">
              <form action="" method="get" accept-charset="utf-8">
            <div class="form-item">
                  <input type="text" name="text edit" id="" placeholder="Text edit" class="text-edit focus-5"/>
                </div>
            <div class="form-item">
                  <input type="text" name="text edit" id="Text1" placeholder="Text edit"/>
                </div>
            <div class="form-item select-text">
                  <input type="text" name="text edit" id="Text2" placeholder="3 560 €" class="focus-5">
                </div>
            <div class="form-item select-text">
                  <input type="text" name="text edit" id="Text3" placeholder="2 317 €">
                </div>
          </form>
            </div>
      </div>
          <div class="span-2 fl"> 
        <!--登录框-->
        <div class="controls-login">
              <div class="form-login">
            <h3>LOGIN</h3>
            <form action="" method="get" accept-charset="utf-8" class="mt-20">
                  <div class="form-item">
                <input type="text" name="username" id="username" placeholder="Username">
              </div>
                  <div class="form-item">
                <input type="password" name="pwd" id="pwd" placeholder="Password">
              </div>
                  <div class="form-item info-list">
                <input type="checkbox" name="showpwd" value="" id="showpwd" checked="checked">
                <label for="showpwd">Show password</label>
                <a href="#" class="fr">Forgot password?</a> </div>
                  <div class="form-item">
                <button type="button">Sign In</button>
              </div>
                </form>
          </div>
            </div>
        <!--日历-日视图-->
        <div class="controls-calendar-dayview mt-40">
              <div class="calendar-header">
            <h2 class="clearfix">
                  <div class="arrow fr"> <a href="#" class="prev-month"></a> <a href="#" class="next-month"></a> </div>
                  <a href="#" class="icon-calendar years-mode-button fl"></a> DECEMBER, 2012 </h2>
            <ul class="week-days clearfix">
                  <li>MON</li>
                  <li>TUE</li>
                  <li>WED</li>
                  <li>THU</li>
                  <li>FRI</li>
                  <li>SAT</li>
                  <li>SUN</li>
                </ul>
          </div>
              <div class="calendar-body">
            <ul class="days clearfix">
                  <li><a href="#" title="29" class="dull">29</a></li>
                  <li><a href="#" title="30" class="dull">30</a></li>
                  <li><a href="#" title="31" class="dull">31</a></li>
                  <li><a href="#" title="1">1</a></li>
                  <li><a href="#" title="2">2</a></li>
                  <li><a href="#" title="3">3</a></li>
                  <li><a href="#" title="4">4</a></li>
                  <li><a href="#" title="5">5</a></li>
                  <li><a href="#" title="6">6</a></li>
                  <li><a href="#" title="7">7</a></li>
                  <li><a href="#" title="8">8</a></li>
                  <li><a href="#" title="9" class="highlighted-day">9</a></li>
                  <li><a href="#" title="10">10</a></li>
                  <li><a href="#" title="11">11</a></li>
                  <li><a href="#" title="12">12</a></li>
                  <li><a href="#" title="13">13</a></li>
                  <li><a href="#" title="14">14</a></li>
                  <li><a href="#" title="15">15</a></li>
                  <li><a href="#" title="16">16</a></li>
                  <li><a href="#" title="17">17</a></li>
                  <li><a href="#" title="18">18</a></li>
                  <li><a href="#" title="19">19</a></li>
                  <li><a href="#" title="20" class="current-day">20</a></li>
                  <li><a href="#" title="21">21</a></li>
                  <li><a href="#" title="22">22</a></li>
                  <li><a href="#" title="23">23</a></li>
                  <li><a href="#" title="24">24</a></li>
                  <li><a href="#" title="25">25</a></li>
                  <li><a href="#" title="26">26</a></li>
                  <li><a href="#" title="27">27</a></li>
                  <li><a href="#" title="28">28</a></li>
                  <li><a href="#" title="29">29</a></li>
                  <li><a href="#" title="30">30</a></li>
                  <li><a href="#" title="1" class="dull">1</a></li>
                  <li><a href="#" title="2" class="dull">2</a></li>
                </ul>
          </div>
            </div>
        <!--日历-月视图-->
        <div class="controls-calendar-monthview mt-40">
              <div class="calendar-header">
            <h2 class="clearfix">
                  <div class="arrow fr"> <a href="#" class="prev-month"></a> <a href="#" class="next-month"></a> </div>
                  <a href="#" class="icon-calendar years-mode-button fl"></a> 2012 </h2>
          </div>
              <div class="calendar-body">
            <ul class="months clearfix">
                  <li><a href="#" title="JAN" class="highlighted-months">JAN</a></li>
                  <li><a href="#" title="FEB">FEB</a></li>
                  <li><a href="#" title="MAR">MAR</a></li>
                  <li><a href="#" title="APR">APR</a></li>
                  <li><a href="#" title="MAY">MAY</a></li>
                  <li><a href="#" title="JUN" class="highlighted-months">JUN</a></li>
                  <li><a href="#" title="JUL" class="current-months">JUL</a></li>
                  <li><a href="#" title="AUG">AUG</a></li>
                  <li><a href="#" title="SEP" class="highlighted-months">SEP</a></li>
                  <li><a href="#" title="OCT" class="highlighted-months">OCT</a></li>
                  <li><a href="#" title="NOV">NOV</a></li>
                  <li><a href="#" title="DEC" class="highlighted-months">DEC</a></li>
                </ul>
          </div>
            </div>
      </div>
          <div class="span-3 fl">
        <div class="controls-icons"> 
              <!--视图按钮 and 分享按钮-->
              <div class="views-item clearfix"> <a href="#" title="" class="icon-paragraph-justify"></a> <a href="#" title="" class="icon-paragraph-left"></a> <a href="#" title="" class="icon-paragraph-center"></a> <a href="#" title="" class="icon-paragraph-right"></a> </div>
              <div class="like-it-item mt-40 share-btn"> <a href="" class="icon-thumbs-up like-it"> Like It <span class="labe"> 5720 </span> </a> </div>
              <div class="twitter-item mt-20 share-btn" > <a href="" class="icon-twitter twitter"> Tweet <span class="labe"> 2035 </span> </a> </div>
              <!--复选框-->
              <div class="controls-checkboxs mt-40">
            <form action="" method="get" accept-charset="utf-8">
                  <div class="form-item fsize20">
                <div class="checkbox-item mr-10">
                      <input type="checkbox" name="" id="checkbox-1">
                      <label for="checkbox-1" data-off="Off" data-on="On" class="radius"></label>
                    </div>
                <div class="checkbox-item">
                      <input type="checkbox" name="" id="checkbox-2" checked="checked">
                      <label for="checkbox-2" data-off="Off" data-on="On" class="radius"></label>
                    </div>
              </div>
                  <div class="form-item fsize10 mt-20">
                <div class="checkbox-item mr-10">
                      <input type="checkbox" name="" id="checkbox-3">
                      <label for="checkbox-3" data-off="Off" data-on="On" class="radius"></label>
                    </div>
                <div class="checkbox-item">
                      <input type="checkbox" name="" id="checkbox-4" checked="checked">
                      <label for="checkbox-4" data-off="Off" data-on="On" class="radius"></label>
                    </div>
              </div>
                  <div class="form-item fsize20 mt-40">
                <div class="checkbox-item mr-10">
                      <input type="checkbox" name="" id="checkbox-5">
                      <label for="checkbox-5" data-off="Off" data-on="On"></label>
                    </div>
                <div class="checkbox-item">
                      <input type="checkbox" name="" id="checkbox-6" checked="checked">
                      <label for="checkbox-6" data-off="Off" data-on="On"></label>
                    </div>
              </div>
                  <div class="form-item fsize10 mt-20">
                <div class="checkbox-item mr-10">
                      <input type="checkbox" name="" id="checkbox-7">
                      <label for="checkbox-7" data-off="Off" data-on="On"></label>
                    </div>
                <div class="checkbox-item">
                      <input type="checkbox" name="" id="checkbox-8" checked="checked">
                      <label for="checkbox-8" data-off="Off" data-on="On"></label>
                    </div>
              </div>
                </form>
          </div>
              <!--色板-->
              <div class="color-wheel"> <img src="img/color-wheel.png" alt=""/> </div>
              <!--功能按钮-->
              <div class="function-buttons mt-40">
            <ul class="icon-items clearfix">
                  <li><a href="#" title="" class="checked"><i class="icon-checked"></i></a></li>
                  <li><a href="#" title=""><i class="icon-checked"></i></a></li>
                  <li><a href="#" title=""><i class="icon-close"></i></a></li>
                  <li><a href="#" title=""><i class="icon-menu"></i></a></li>
                  <li><a href="#" title=""><i class="icon-plus"></i></a></li>
                  <li><a href="#" title=""><i class="icon-minus"></i></a></li>
                  <li><a href="#" title=""><i class="icon-radio-checked"></i></a></li>
                  <li><a href="#" title=""><i class="icon-radio-unchecked"></i></a></li>
                </ul>
          </div>
              <div class="social-buttons mt-40">
            <ul class="social-items">
                  <li><a href="" title=""><i class="icon-tumblr"></i></a></li>
                  <li><a href="" title=""><i class="icon-facebook"></i></a></li>
                  <li><a href="" title=""><i class="icon-pinterest"></i></a></li>
                  <li><a href="" title=""><i class="icon-yahoo"></i></a></li>
                  <li><a href="" title=""><i class="icon-blogger"></i></a></li>
                  <li><a href="" title=""><i class="icon-vimeo"></i></a></li>
                  <li><a href="" title=""><i class="icon-linkedin-2"></i></a></li>
                  <li><a href="" title=""><i class="icon-dribbble-3"></i></a></li>
                  <li><a href="" title=""><i class="icon-github-2"></i></a></li>
                </ul>
          </div>
            </div>
      </div>
        </div>
    <div class="row clearfix">
          <div class="span-1 fl"> 
        <!--手风琴-->
        <div class="accordion">
              <ul class="nostyle">
            <li>
                  <input type="radio" id="ac-1" name="accordion-1" checked="checked">
                  <label for="ac-1">Option 1</label>
                  <div class="accordion-content"> <img src="img/ac-1.jpg" alt="">
                <h3>Here you title</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
              </div>
                </li>
            <li>
                  <input type="radio" id="ac-2" name="accordion-1">
                  <label for="ac-2">Option 2</label>
                  <div class="accordion-content"> <img src="img/ac-1.jpg" alt="">
                <h3>Here you title</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
              </div>
                </li>
            <li>
                  <input type="radio" id="ac-3" name="accordion-1">
                  <label for="ac-3">Option 3</label>
                  <div class="accordion-content"> <img src="img/ac-1.jpg" alt="">
                <h3>Here you title</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
              </div>
                </li>
          </ul>
            </div>
        <div class="accordion-2 mt-40">
              <ul class="nostyle">
            <li>
                  <input type="radio" id="ac-4" name="accordion-2" checked="checked">
                  <label for="ac-4">Option 1</label>
                  <div class="accordion-content"> <img src="img/ac-1.jpg" alt="">
                <h3>Here you title</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
              </div>
                </li>
            <li>
                  <input type="radio" id="ac-5" name="accordion-2">
                  <label for="ac-5">Option 2</label>
                  <div class="accordion-content"> <img src="img/ac-1.jpg" alt="">
                <h3>Here you title</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
              </div>
                </li>
            <li>
                  <input type="radio" id="ac-6" name="accordion-2">
                  <label for="ac-6">Option 3</label>
                  <div class="accordion-content"> <img src="img/ac-1.jpg" alt="">
                <h3>Here you title</h3>
                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
              </div>
                </li>
          </ul>
            </div>
      </div>
          <div class="span-4 fl">
        <div class="vodeo-player mt-40">
              <div class="video-container">
            <div class="hide"> <a href="" title="" class="like-button"><i class="icon-like"></i></a> <a href="" title="" class="link-button"><i class="icon-link"></i></a> </div>
            <img src="img/video-container.jpg" alt=""> </div>
              <div class="vodeo-bar clearfix">
            <ul class="nostyle">
                  <li><a href="" title="" class="play-button"><i class="icon-play"></i></a></li>
                  <li>
                <div class="vodeo-progress"> <span>06:52</span> </div>
              </li>
                  <li><a href="" title="" class="new-tab-button"><i class="icon-new-tab"></i></a></li>
                  <li><a href="" title="" class="loop-button"><i class="icon-loop"></i></a></li>
                </ul>
          </div>
            </div>
        <div class="tab-menu mt-40">
              <div class="tab-menu-container">
            <div class="tab-1" id="tab-1">
                  <h2><a href="#tab-1" title="Option 1" class="active">Option 1</a></h2>
                  <div class="filters-bar clearfix"> <strong># <i class="icon-menu"></i></strong> <strong>Title <i class="icon-menu"></i></strong> <strong>Status</strong> <strong>Price <i class="icon-menu"></i></strong> </div>
                  <div class="text-columns clearfix">
                <ul class="nostyle">
                      <li> <span>1</span> <span>Loremt ipsum</span> <span>Deactive</span> <span>$0.99</span> </li>
                      <li class="active"> <span>2</span> <span>Consectetuer</span> <span>Deactive</span> <span>$1.99</span> </li>
                      <li> <span>3</span> <span>Nonummy</span> <span>Deactive</span> <span>$0.78</span> </li>
                      <li> <span>4</span> <span>Euismod</span> <span>Deactive</span> <span>$1.99</span> </li>
                      <li> <span>5</span> <span>Consequat</span> <span>Deactive</span> <span>$22.50</span> </li>
                      <li> <span>6</span> <span>Lobortis</span> <span>Deactive</span> <span>$0.99</span> </li>
                      <li> <span>7</span> <span>Vulputate velit</span> <span>Deactive</span> <span>$0.99</span> </li>
                    </ul>
              </div>
                </div>
            <div class="tab-2" id="tab-2">
                  <h2><a href="#tab-2" title="Option 2">Option 2</a></h2>
                  <div class="filters-bar clearfix"> <strong># <i class="icon-menu"></i></strong> <strong>Title <i class="icon-menu"></i></strong> <strong>Status</strong> <strong>Price <i class="icon-menu"></i></strong> </div>
                  <div class="text-columns clearfix">
                <ul class="nostyle">
                      <li> <span>1</span> <span>Consectetuer</span> <span>Deactive</span> <span>$1.99</span> </li>
                      <li> <span>2</span> <span>Nonummy</span> <span>Deactive</span> <span>$0.78</span> </li>
                      <li> <span>3</span> <span>Loremt ipsum</span> <span>Deactive</span> <span>$0.99</span> </li>
                      <li class="active"> <span>4</span> <span>Consequat</span> <span>Deactive</span> <span>$22.50</span> </li>
                      <li> <span>5</span> <span>Euismod</span> <span>Deactive</span> <span>$1.99</span> </li>
                      <li> <span>6</span> <span>Vulputate velit</span> <span>Deactive</span> <span>$0.99</span> </li>
                      <li> <span>7</span> <span>Lobortis</span> <span>Deactive</span> <span>$0.99</span> </li>
                    </ul>
              </div>
                </div>
          </div>
            </div>
        <div class="controls-buttons mt-40">
              <div class="normal-buttons">
            <button type="button">Button</button>
            <button type="button" class="black">Button</button>
            <button type="button" class="active">Button</button>
            <button type="button">Button</button>
          </div>
              <div class="big-buttons">
            <button type="button">Button</button>
            <button type="button" class="black">Button</button>
            <button type="button" class="active">Button</button>
            <button type="button">Button</button>
          </div>
            </div>
      </div>
        </div>
    <div class="row  mt-40">
          <div class="price-box clearfix">
        <ul class="price-box-items">
              <li>
            <div class="item-1">
                  <h2><span>BasicBasic</span></h2>
                  <h3>$ <span>5</span>.99 <em>/</em> Month</h3>
                  <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet olore <em>magna</em> aliquam erat volutpat.</p>
                </div>
          </li>
              <li>
            <div class="item-2 active">
                  <h2><span>Advanced</span></h2>
                  <h3>$ <span>10</span>.99 <em>/</em> Month</h3>
                  <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet olore <em>magna</em> aliquam erat volutpat.</p>
                </div>
          </li>
              <li>
            <div class="item-3">
                  <h2><span>Premium</span></h2>
                  <h3>$ <span>99</span>.00 <em>/</em> Month</h3>
                  <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet olore <em>magna</em> aliquam erat volutpat.</p>
                </div>
          </li>
            </ul>
      </div>
          <div class="price-box-2 clearfix mt-40">
        <ul class="price-box-items">
              <li>
            <div class="item-1">
                  <h2><span>BasicBasic</span></h2>
                  <h3>$ <span>5</span>.99 <em>/</em> Month</h3>
                  <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet olore <em>magna</em> aliquam erat volutpat.</p>
                </div>
          </li>
              <li>
            <div class="item-2 active">
                  <h2><span>Advanced</span></h2>
                  <h3>$ <span>10</span>.99 <em>/</em> Month</h3>
                  <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet olore <em>magna</em> aliquam erat volutpat.</p>
                </div>
          </li>
              <li>
            <div class="item-3">
                  <h2><span>Premium</span></h2>
                  <h3>$ <span>99</span>.00 <em>/</em> Month</h3>
                  <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet olore <em>magna</em> aliquam erat volutpat.</p>
                </div>
          </li>
            </ul>
      </div>
        </div>
  </section>
    </div>
</body>
</html>