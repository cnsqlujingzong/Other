<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AImglibType.aspx.cs" Inherits="Master_ImgLib_AImglibType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片库管理</title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../resources/js/Admin.js"></script>
    <link href="../resources/css/global.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {         
            $(".tname").change(function () {
                var full_src = $(this).siblings(".editLibs").attr("ref") + $(this).val();
                $(this).siblings(".editLibs").attr("href", full_src);
              
                full_src = "";
            });

            $(".tdesc").change(function () {
                var full_src = $(this).siblings(".editLibsd").attr("ref") + $(this).val();
                $(this).siblings(".editLibsd").attr("href", full_src);               
                full_src = "";
            });
            $("#addLibs").change(function () {
                var full_src = $(this).siblings("#aaddLibs").attr("ref") + $(this).val();
                $(this).siblings("#aaddLibs").attr("href", full_src);
             
            });
        })        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 6px; margin-top: 6px;">
        <div style="background-color: #DADFEF; color: #593D00; font-size: 9pt; padding: 5px 3px;
            border: 1px solid gray;">
            【当前位置】:&nbsp;&nbsp;&nbsp;图片库管理
        </div>
        <div style="background-color: #DADFEF; padding: 5px 15px 30px 15px; border: 1px solid gray; margin-top: 10px;">
            <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
            <div style="padding: 10px 15px;">
              <div >名称:<input type="text" id="addLibs"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="aaddLibs" ref='controlashx.ashx?flag=addlib&id=NAN&lib='>添加</a></div>
              <div style="clear:both;"></div>
                <asp:Repeater ID="RP_imgtype" runat="server">
                    <ItemTemplate>
                        <div class="imglibdiv">
                            <div class="div_img"><a href='AImglib.aspx?tid=<%# Eval("ID") %>'><img alt="" src='<%# GetCoverImg(Eval("ID").ToString())%>'/></a></div>
                            <p>
                              <input  type="text" class="tname" value='<%#Eval("La_NAME")%>'/> &nbsp;&nbsp;&nbsp;<a class="editLibs" ref='controlashx.ashx?flag=lib&id=<%#Eval("id") %>&lib='>编辑</a>
                              <br />
                             <textarea rows="5" class="tdesc"  cols="18"><%#Eval("La_Dec")%></textarea>&nbsp;&nbsp;&nbsp;<a class="editLibsd" ref='controlashx.ashx?flag=libd&id=<%#Eval("id") %>&lib='>编辑</a>
                            
                            </p>
                        </div>
                    </ItemTemplate>                    
                </asp:Repeater>
          <div style="clear:both;"></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
