<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProsTypeManage.aspx.cs" Inherits="Master_Pro_ProsTypeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品分类管理</title>
     <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;产品分类管理
        </div>
          <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
          <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
           <div style=" padding:10px 15px;">
               <table width="100%" cellpadding="0" cellspacing="0">
    <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
        名称:</td><td style="text-align: left">
            <asp:TextBox ID="txtProTypeName" runat="server" style="border:1px solid #DEDEDE; width:350px; line-height:18px;" ></asp:TextBox></td></tr>
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
           <td style="text-align: left"> <asp:CheckBox ID="CB_ispub" runat="server"  Text="发布"  Checked="True"/> </tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;"></td>
            <td style="text-align: left"><asp:CheckBox ID="CB_isLimit" runat="server"  Text="仅会员访问"/></td></tr>
         <tfoot>
         <tr><td colspan="2" align="right">
         <a class="save" href="ProsTypeAdmin.aspx" style=" color:#4372B0;">取消</a>
         <input  type="button" id="reset" class="save" value="重置"/>
         <asp:Button ID="butSava" runat="server" class="save" Text="确认" 
                 onclick="butSava_Click" OnClientClick="return checkData()" /></td></tr>
         </tfoot>
    </table>
           </div>
           </div>
           </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#reset").click(function () {
            $("#txtProTypeName").val("");
        });
    });
    function checkData() {
        //  alert(document.getElementById("newstypename").value.trim().length);
        if ($("#txtProTypeName").val() == "" || $("#txtProTypeName").val() == null) {
            alert("名称不能为空！");
            return false;
        } else {
            return true;
        }

    }
</script>
