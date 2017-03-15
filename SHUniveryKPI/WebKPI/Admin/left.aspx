<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="Master_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
      body{ background-color:#002A43;font-family: Arial, Helvetica, sans-serif; margin:0px; padding:0px;}
      ul li a:link{color:#002A43}
      ul li a:visited{color:#002A43}
      ul li a:hover{color:#396}    
      ul li a{ font-size:10pt; text-decoration: none; }
      ul li{padding:3px 0px;}
      .title{color:#593D00; font-size:10pt; font-weight:bold; cursor:pointer; display:block; background:url("resources/img/left_menu_bg.gif"); padding-top:3px; padding-bottom:3px;}
      .childlist{ list-style-type:none; text-align:left;}
    </style>
    <script src="/js/jquery-1.11.2.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $(".title").click(function () {
                var name = $(this).attr('href');
                $(name).slideToggle();
            });

        })

    </script>
</head>
<body>    
    <div  style=" width:150px;">
       <div style="background-color:White; font-size:11pt;color:#002A43;font-weight: bold; padding-top:8px;padding-bottom:8px; text-align:center;">管理菜单</div>
       <div style="background-color:White; margin-top:2px; text-align:center;">
          <span class="title" href="#news">用户管理</span>
          <div style="color:#002A43; margin-top:-10px; " id="news">
            <ul class="childlist">
             <li><a href="User/AddUser.aspx" target="mainFrame">新添加员工</a></li>        
             <li><a href="User/UserManage.aspx" target="mainFrame">员工管理</a></li>              
            </ul>
          </div>


           <span class="title" href="#products">考核管理</span>
          <div style="color:#002A43; margin-top:-10px; display:none" id="products">
            <ul class="childlist">
                 <li><a href="javascript:void(0)" target="mainFrame">新建考核表</a></li>   
                  <li><a href="javascript:void(0)" target="mainFrame">待审核</a></li>            
                 <li><a href="javascript:void(0)" target="mainFrame">考核管理</a></li> 
            </ul>
          </div>


           <span class="title" href="#files">文件管理</span>
          <div style="color:#002A43; margin-top:-10px; display:none" id="files">
            <ul class="childlist">
             <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>             
              <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>      
               <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>      
               <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>      
            </ul>
          </div>


           <span class="title" href="#systems">系统管理</span>
          <div style="color:#002A43; margin-top:-10px; display:none" id="systems">
            <ul class="childlist">
             <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>      
             <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>      
              <li><a href="javascript:void(0)" target="mainFrame">暂无</a></li>      
          
            </ul>
          </div>
       
       </div>
    </div>   
</body>
</html>
