<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SHUniversity.KPI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{ margin:0 auto; background:#002A43; width:98%; font-size:11px; font-family:Verdana, Arial, Helvetica, sans-serif;}
h1,h2,h3,h4,h5,span,ul,ol,li{ margin:0; padding:0;}
.clear{ font-size:0; line-height:0; height:0; clear:both;}
a{ color:#1E4673; text-decoration:none;}
a:hover{ text-decoration:underline}
/*login page style*/
.loginpadding{ padding-top:155px; margin:0 auto}
.loginbg1{ width:526px; height:150px; background:url(../images/loginbg1.jpg) no-repeat; margin:0 auto;}
.loginbg2{ width:526px; height:176px; background:url(../images/loginbg2.jpg) no-repeat; margin:0 auto;}


    </style>
</head>
<body>
    <form id="Form1" name="form1" runat="server">
<div>  &nbsp;&nbsp;</div>
<div>
</div>
<div class="loginpadding"  id="mm">

	<div class="loginbg1"></div>
	<div class="loginbg2">
		<div style="padding:10px 0 0 25px; font-size:12px; color:#fff;">
	  <table width="50%" border="0" cellspacing="0" cellpadding="3" align="center">
        <tr>
          <td width="18%"><div align="right">工号:</div></td>
          <td width="82%">
              <asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox></td>
        </tr>
        <tr>
          <td style="height: 20px"><div align="right">密码:</div></td>
          <td style="height: 20px">
              <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
          <td><div align="right">
              &nbsp;</div></td>
          <td>
              &nbsp;<asp:Label ID="lb_msg" runat="server" ForeColor="Red"></asp:Label> </td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td><input src="images/login_submit.gif" name="Image1" type="image" id="Image1" runat="server" onserverclick="Image1_ServerClick" />
          </td>
        </tr>
        <tr>
        <td colspan="2"></td>            
        </tr>
      </table>
	  </div>
	  <div style="text-align:right; padding-right:7px;  color:#fff; padding-top:17px;">Copyright &copy; 2016 ShangHai University . All rights reserved.,</div>
	</div>
	
</div>
</form>
</body>
</html>
