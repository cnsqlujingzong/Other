<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_News_Add.aspx.cs" Inherits="Master_News_Admin_News_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加文章</title>
     <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>
      <script language="javascript" type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
  
</head>
<body>
    <form id="form1" runat="server">
     <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;添加文章
        </div>
          <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
          <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
               <div style=" padding:10px 15px;">
                 <div style=" width:90%; height:30px; margin:0 auto; border:2px solid #99BBE8; height:100%">
    <table width="100%" cellpadding="0" cellspacing="0">
    <tr><td style=" border:0px;"></td><td style=" border:0px;"></td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            语言:</td><td style="text-align: left">
                <asp:Label ID="LB_lang" runat="server" Text=""></asp:Label>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            分类:</td><td style="text-align: left">
                <asp:DropDownList ID="DL_NewsType" runat="server" Width="187px">
                </asp:DropDownList>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            标题:</td><td style="text-align: left">
                <asp:TextBox ID="txtTitle" runat="server" Width="670px"></asp:TextBox>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            作者:</td><td style="text-align: left">
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            发表日期:</td><td style="text-align: left">
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            </td></tr>
    
     <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
         设置SEO:<br /><asp:Label ID="LB_KeyWord" runat="server" Text="关键字:" Visible="false"></asp:Label>
           </td><td style="text-align: left">
           <div style="display:inline; float:left">  
           <asp:RadioButtonList ID="ISSEO" runat="server" 
                 RepeatDirection="Horizontal" AutoPostBack="True" 
                   onselectedindexchanged="ISSEO_SelectedIndexChanged">
                 <asp:ListItem Value="true">是</asp:ListItem>
                 <asp:ListItem Selected="True" Value="false">否</asp:ListItem>
             </asp:RadioButtonList>
            </div >
            <div style="height:30px; padding-top:10px;">选择'是'将为本页面单独设置SEO参数，全局参数对本页面无效</div>
            <div style=" clear:both;"></div>
            <div>
                <asp:TextBox ID="txtKeyWord" runat="server" Width="506px" Visible="false"></asp:TextBox> </div>
         </td></tr>
      <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
          
          摘要:</td><td style="text-align: left">
              <asp:TextBox ID="txtSummary" runat="server" Rows="6" TextMode="MultiLine" 
                  Width="668px"></asp:TextBox>
          </td></tr>
       <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
           文章内容:</td>
           <td style="text-align: left">
               <CKEditor:CKEditorControl ID="txtContent" runat="server" Width="100%"   >
               </CKEditor:CKEditorControl>
           </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;"></td>
            <td style="text-align: left">&nbsp;</td></tr>
         <tfoot>
         <tr><td colspan="2" align="right">
         <a class="save" href="Admin_News.aspx" style=" color:#4372B0;">取消</a>
         <input  type="button" id="reset" class="save" value="重置"/>
         <asp:Button ID="butSava" runat="server" class="save" Text="确认"  onclick="butSava_Click" /></td></tr>
         </tfoot>
    </table>
  </div>
               </div>
          </div>
      </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#reset").click(function () {
            $("#txtTitle,#txtAuthor,#txtFrom,#txtKeyWord,#txtSummary,#txtContent").val("");
        });
    });
  
</script>