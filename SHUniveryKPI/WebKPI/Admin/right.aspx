<%@ Page Language="C#" AutoEventWireup="true" CodeFile="right.aspx.cs" Inherits="Master_right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      body{font-family: Arial, Helvetica, sans-serif; margin:0px; padding:0px;}
      li{ font-size:10pt; padding:9px 0px;}
    </style>
</head>
<body>
    <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;系统信息
        </div>
          <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
           <img  src="resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">系统参数</span>
           <div style=" padding:10px 15px;">
             <ul style=" list-style-type:none;">
               <li>一、登录IP:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_ip" runat="server" Text=""></asp:Label></li>
               <li>二、操作系统类型:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_os" runat="server" Text=""></asp:Label></li>
               <li>三、浏览器类型:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_ex" runat="server" Text=""></asp:Label></li>
               <li>四、浏览器版本:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_exver" runat="server" Text=""></asp:Label></li>
               <li>五、IIS版本:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_iis" runat="server" Text=""></asp:Label></li>
               <li>六、服务器电脑名:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_sname" runat="server" Text=""></asp:Label></li>
               <li>七、Net版本:&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_netver" runat="server" Text=""></asp:Label></li>
             </ul>
           
           </div>
        </div>
    </div>
   
</body>
</html>
