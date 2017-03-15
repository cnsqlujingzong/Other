<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Master_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理</title>
</head>
<frameset rows="100,*" cols="*" frameborder="0" border="0" framespacing="0">
  <frame src="head.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset rows="*" cols="160,*" frameborder="0" border="1" framespacing="0" scrolling="No">
    <frame src="Left.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
    <frame src="right.aspx" name="mainFrame" id="mainFrame" title="mainFrame"/>
  </frameset>
</frameset>
<noframes><body>您的浏览器不支持Frame框架，请换其他浏览器再试！
</body></noframes>
</html>