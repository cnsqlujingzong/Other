<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_NewsType_Edit.aspx.cs" Inherits="Master_News_Admin_NewsType_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章类型修改</title>
     <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>   
</head>
<body>
    <form id="form1" runat="server">
        <div style=" margin-left:6px; margin-top:6px;">
            <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
              【当前位置】:&nbsp;&nbsp;&nbsp;修改文章分类
            </div>
             <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
              <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
               <div style=" padding:10px 15px;">
                     <div style=" width:90%; height:30px; margin:0 auto; border:2px solid #99BBE8; height:100%">
    <table width="100%" cellpadding="0" cellspacing="0">
    <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
        名称:</td><td style="text-align: left">
            <asp:TextBox ID="txtTypeName" runat="server" style="border:1px solid #DEDEDE; width:350px; line-height:18px;"></asp:TextBox>
            <asp:HiddenField ID="Hid" runat="server" />
        </td></tr>
     <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
         上级分类:</td><td style="text-align: left">
             <asp:DropDownList ID="DD_Type" runat="server" Width="100px">
             </asp:DropDownList>
         </td></tr>
      <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
          
          语言:</td><td style="text-align: left">
              <asp:Label ID="LB_language" runat="server" Text="Label"></asp:Label>
          </td></tr>
       <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;"></td>
           <td style="text-align: left"> 
               <asp:CheckBox ID="isfabu" runat="server" />  发布</td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;"></td>
            <td style="text-align: left">
                <asp:CheckBox ID="islimit" runat="server" />仅会员访问</td></tr>
         <tfoot>
         <tr><td colspan="2" align="right">
         <a  class="save" href="Admin_NewsType.aspx">取消</a>&nbsp;
         <asp:Button ID="butSava" runat="server" class="save" Text="确认" onclick="butSava_Click" /></td></tr>
         </tfoot>
    </table>
  </div>
               </div>
             </div>
        </div>
    </form>
</body>
</html>
