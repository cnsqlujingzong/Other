<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProsManage.aspx.cs" Inherits="Master_Pro_ProsManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
     <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
  	<script type="text/javascript" src="../../ckfinder/ckfinder.js"></script>
  	<script type="text/javascript">
  	    function BrowseServer(startupPath, functionData) {
  	        // You can use the "CKFinder" class to render CKFinder in a page:
  	        var finder = new CKFinder();
  	        finder.basePath = '../';
  	        finder.startupPath = startupPath;
  	        finder.selectActionFunction = SetFileField;
  	        finder.selectActionData = functionData;
  	        finder.popup();
  	    }

  	    function SetFileField(fileUrl, data) {
  	        document.getElementById(data["selectActionData"]).value = fileUrl;
  	    }
        
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;产品管理
        </div>
          <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
          <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
           <div style=" padding:10px 15px;">
           <table width="100%" cellpadding="0" cellspacing="0">   
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            语言:</td><td style="text-align: left">
                <asp:Label ID="LB_lang" runat="server" Text="Label"></asp:Label>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            分类:</td><td style="text-align: left">
                <asp:DropDownList ID="DL_prosType" runat="server" Width="187px">
                </asp:DropDownList>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            名称:</td><td style="text-align: left">
                <asp:TextBox ID="txtProName" runat="server" Width="670px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtProName" ErrorMessage="不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
            </td></tr>
        <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
            发表日期:</td><td style="text-align: left">
                <asp:TextBox ID="txtDate" runat="server" Enabled="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 产品属性: <asp:CheckBox ID="CB_Recommend" runat="server" Text="推荐产品" />    <asp:CheckBox ID="CB_ISNEW" Visible="false" runat="server" Text="最新产品" /> 
            </td></tr>
    
     <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
         设置SEO:<br /><br /><asp:Label ID="LB_KeyWord" runat="server" Text="关键字:" Visible="false"></asp:Label>
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
                <asp:TextBox ID="txtKeyWord" runat="server" Width="506px" Visible="false"></asp:TextBox> 
                <br /> <br />
             </div>
         </td></tr>
      <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
          
          简介:</td><td style="text-align: left">
               <CKEditor:CKEditorControl ID="txtIntro" runat="server" Width="100%"   >
               </CKEditor:CKEditorControl>
          </td></tr>
       <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
           产品内容:</td>
           <td style="text-align: left">
               <CKEditor:CKEditorControl ID="txtContent" runat="server" Width="100%"   >
               </CKEditor:CKEditorControl>
           </td></tr>

      <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">详细参数</td><td>
               <CKEditor:CKEditorControl ID="txtAgument" runat="server" Width="100%"   >
               </CKEditor:CKEditorControl>
           </td></tr>
      <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">应用方案</td><td>
               <CKEditor:CKEditorControl ID="txtCase" runat="server" Width="100%"   >
               </CKEditor:CKEditorControl>
           </td></tr>

        <tr><td style="text-align: right; vertical-align:top; color: #4372B0; padding-right: 10px; font-size: 14px;">全图:</td>
            <td style="text-align: left" class="style1">支持的文件类型:Gif&nbsp; | JPG&nbsp; |&nbsp;PNG | bmp<br />
            <div style=" display:inline; float:left;"><asp:Image ID="Image1" runat="server" 
                    Height="200px" Width="200px" /><br /><asp:FileUpload ID="upimg1" runat="server" />
                    <br /><asp:TextBox ID="txtimg1" runat="server"></asp:TextBox><input type="button" value="服务器选择" onclick="BrowseServer( 'Images:/', 'txtimg1' );" /></div>
                      <div style=" display:inline; float:left;"><asp:Image ID="Image2" runat="server" 
                    Height="200px" Width="200px" /><br /><asp:FileUpload ID="upimg2" runat="server" />
                     <br /><asp:TextBox ID="txtimg2" runat="server"></asp:TextBox><input type="button" value="服务器选择" onclick="BrowseServer( 'Images:/', 'txtimg2' );" /></div>
                      <div style=" display:inline; float:left;"><asp:Image ID="Image3" runat="server" 
                    Height="200px" Width="200px" /><br /><asp:FileUpload ID="upimg3" runat="server" />
                     <br /><asp:TextBox ID="txtimg3" runat="server"></asp:TextBox><input type="button" value="服务器选择" onclick="BrowseServer( 'Images:/', 'txtimg3' );" /></div>
                      <div style=" display:inline; float:left;"><asp:Image ID="Image4" runat="server" 
                    Height="200px" Width="200px" /><br /><asp:FileUpload ID="upimg4" runat="server" />
                     <br /><asp:TextBox ID="txtimg4" runat="server"></asp:TextBox><input type="button" value="服务器选择" onclick="BrowseServer( 'Images:/', 'txtimg4' );" /></div>
            </td>
        </tr>
         <tr><td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">
             操作手册</td>
            <td style="text-align: left">
              
                <asp:FileUpload ID="upomfile" runat="server" />
              
             </td>
        </tr>
         <tfoot>
         <tr><td colspan="2" align="right">
         <a class="save" href="ProAdmin.aspx" style=" color:#4372B0;">取消</a>
         <input  type="button" id="reset" class="save" value="重置"/>
         <asp:Button ID="butSava" runat="server" class="save" Text="确认"  onclick="butSava_Click" /></td></tr>
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
            $("#txtProName,#txtKeyWord,#txtSummary,#txtContent").val("");
        });
    });
  
</script>