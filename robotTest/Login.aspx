<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login.land" %>
<%--<%@ Register Assembly="Vincent.AutoAuthCode, Version=1.5.0.0, Culture=neutral, PublicKeyToken=b633909bc009d6d9" Namespace="Vincent.AutoAuthCode" TagPrefix="cc1" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <link rel="stylesheet" type="text/css" href="base.css" media="all" />
    <script type="text/javascript" charset="utf-8" src="TIA/UI/JS/Ajax.js"></script>
	<script type="text/javascript" charset="UTF-8" src="prefixfree.min.js"></script>
   <script type="text/javascript" charset="utf-8" src="TIA/UI/JS/Captcha.js"></script>
    <script>
       
        document.onreadystatechange = function () {
            if (document.readyState == "complete") {
                CheckVerificationTimeOut();
            }
        }
    </script>
    <title></title>
<%--    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="easyui/themes/icon.css"/>
	<link rel="stylesheet" type="text/css" href="easyui/demo.css"/>
	<script type="text/javascript" src="easyui/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>--%>
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

         </style>
    </head>
<body>
    <div id="form4"  style="text-align:center">
       
       <%-- <input type="hidden" runat="server" id="he" />
        <input type="hidden" id="time_buf" value=""/>
        <input type="hidden" id="now_buf" value="" />--%>
        <input type="password" id="Code_buf" value="" style="display:none"/>
       <%-- <input type="password" style="display:none" />--%>
       <div style=" background-position:center;position:fixed; top:0; left:0; bottom:0; right:0; z-index:-1; background-repeat:no-repeat">
            <img src="Desk/desk01.jpg" style="height:100%; width:100%; border:0; "/>
        </div>
        <div class="span-2 fl" style="text-align:center;">

        <div class="controls-login" style="position:absolute;top:20%;right:40%; width:300px">
              <div class="form-login">
            <h3>LOGIN</h3>
            <form id="Form2"  method="get" accept-charset="utf-8" class="mt-20" runat="server">
                  <div class="form-item">
                <input type="text" name="username" id="UserId_text" placeholder="Username" runat="server"/>
                      
              </div>
                  <div class="form-item">
                <input type="password"  name="pwd" id="PassWorld" placeholder="Password" runat="server"/>
              </div>
                <div class="form-item">
                    <input type="text" name="Cr" id="VerificationCode" placeholder="x=?" runat="server" />
                </div>
                <div class="form-item">
                   <%--<cc1:AuthCode  ID="AuthCode1"  runat="server" TextBoxClass="authText" EnableClientValidate="true"  SubmitControlID="buuton1" ImageStyle-Width="70" TextControlWidth="90" />--%>
                  <canvas id="captcha" height="45" width="150"></canvas><a href="#" onclick=" GreatCaptcha()" style="color:#06c" id="Relpacea">Relpace</a>
                   
                </div>
              <div class="form-item info-list">
              <%--  <Asp:CheckBox  name="showpwd" value="" id="showpwd" checked="false" runat="server" AutoPostBack="True" OnCheckedChanged="showpwd_CheckedChanged"/>
                <label for="showpwd">Show password</label>--%>
                  <div style="text-align:right">
                <Asp:LinkButton ID="changword" runat="server"   OnClick="changword_Click">Reset password?</Asp:LinkButton>
                      </div>
                  <div>Developed by OnlyRobot Edu</div> 
                  
                      </div>
                  <div class="form-item">
                <asp:Button ID="buuton1" runat="server" OnClick="buuton1_Click"  Text="Sign In" BackColor="#323232" ForeColor="#F6F6F6" BorderColor="#F6F6F6" BorderStyle="Solid"/>
              </div>
                </form>
          </div>
            </div>
            </div>
        </div>
</body>
</html>
