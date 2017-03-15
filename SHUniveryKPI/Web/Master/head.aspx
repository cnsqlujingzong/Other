<%@ Page Language="C#" AutoEventWireup="true" CodeFile="head.aspx.cs" Inherits="Master_head" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
     html,body{  font-family: Arial, Helvetica, sans-serif; padding:0px; margin:0px;}
    </style>
    <script language="JavaScript" type="text/javascript">
        function showTime() {
            var now = new Date();
            document.all.currentTime.innerHTML = now.toLocaleString();
            setTimeout("showTime()", 1000);
        }
</script>

</head>
<body onload="showTime()" >
   <div style="height:100px;background:url('resources/img/top_bg.jpg'); position:relative;">
    <div style=" margin-left:12%; padding-top:30px;">
      <span style="color:White; font-size:15pt;">网站后台管理</span> 
    </div>
    <div style=" color:White; font-size:9pt;bottom:2px; position:absolute;">欢迎您:&nbsp;&nbsp;&nbsp;管理员&nbsp;&nbsp;&nbsp;&nbsp;当前时间为:&nbsp;&nbsp;<span id="currentTime"></span></div>
    </div>
</body>
</html>
