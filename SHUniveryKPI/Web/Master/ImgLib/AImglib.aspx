<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AImglib.aspx.cs" Inherits="Master_ImgLib_AImglib" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图片库管理</title>

     <link href="../../css/uploadify.css" type="text/css" rel="stylesheet" />    
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.prettyPhoto.js"></script>
    <script type="text/javascript" src="../../js/jquery.uploadify.min.js"></script>
    <script type="text/javascript" src="../../js/uploadswfobject.js"></script>
     <script type="text/javascript" src="../../js/tinybox.js"></script>
    <link href="../resources/css/global.css" type="text/css" rel="stylesheet" />
    <link href="../../css/prettyPhoto.css" type="text/css" rel="stylesheet" />
   
     <script type="text/javascript">
         $(document).ready(function () {
 
             $("a[rel^='prettyPhoto']").prettyPhoto();
             $("#uploadify").uploadify({
                 'uploader': '/js/uploadify.swf',
                 'script': '/Master/UpLoadPage.ashx',
                 'cancelImg': '/img/cancel.png',
                 'folder': '/upload/Img_Lib',
                 'queueID': 'fileQueue',
                 'auto': false,
                 'multi': true,
                 'fileExt': '*.jpg;*.gif;*.png',
                 'fileDesc': 'Web Image Files (.JPG, .GIF, .PNG)',
                 'buttonText': '浏览图片',
                 'onSelect': function (event, queueID, fileObj) {
                     $("#uploadify").uploadifySettings("script", "/Master/UpLoadPage.ashx?tid=" + $("#HF_typeid").val()); //动态更新配(执行此处时可获得值)

                 },
                 'onError': function (event, queueId, fileObj, errorObj) {
                     alert(errorObj.info + "---------" + errorObj.type);
                 },
                 'onAllComplete': function () {
                     window.location.reload();
                 }
             });


         });

    </script>
</head>
<body>
    <form id="form1" runat="server">       

        <div style="clear:both;"></div>
    <div style="margin-left: 6px; margin-top: 6px;">
        <div style="background-color: #DADFEF; color: #593D00; font-size: 9pt; padding: 5px 3px;
            border: 1px solid gray;">
            【相册分类】:&nbsp;&nbsp;&nbsp;<asp:Label ID="LB_imgType" runat="server" Text=""></asp:Label> 
            <asp:HiddenField ID="HF_typeid" runat="server" />
        </div>
        <div style="background-color: #DADFEF; padding: 5px 15px 30px 15px; border: 1px solid gray;
            margin-top: 10px;">
           
            <div style="padding: 10px 15px;">
            <div>
            <input type="file" name="uploadify" id="uploadify" />&nbsp;  <a href="javascript:$('#uploadify').uploadifyUpload()">上传</a>| <a href="javascript:$('#uploadify').uploadifyClearQueue()"> 取消上传</a><a style=" color:#000; font-size:18px; margin-left:30px;" href="AImglibType.aspx" >返回相册</a>
            </div>
          <div id="fileQueue"></div>
              <div style="clear:both;"></div>
                <asp:Repeater ID="RP_img" runat="server">
                    <ItemTemplate>
                        <div class="imglibdiv">
                            <div class="zoom"><a href='<%# "../../upload/Img_Lib/"+Eval("SRC") %>' rel="prettyPhoto[gallery]"><img src='<%# "../../upload/Img_Lib/"+Eval("SRC") %>' alt="" class="pimg" /></a></div>
                            <p style=" text-align:center;"><a href="controlashx.ashx?flag=img&id=<%#Eval("id") %>&lib=<%#Eval("P_ImgLibrary")%>" onclick="return confirm('确认要删除？')">删除</a></p>                        
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