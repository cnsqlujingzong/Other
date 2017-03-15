<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Master_index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站后台管理</title>
    <link rel="stylesheet" type="text/css" href="resources/css/login.css" />
    <script language="javascript" type="text/javascript">
        function ChangeCode() {
            var date = new Date();
            var myImg = document.getElementById("ImageCheck");
            myImg.src = "../ValidateCode.ashx?&flag=" + date.getMilliseconds()
            return false;
        }
   
    </script>
    <style type="text/css">
      Table.statusSection
{background-color:#fff;border:2px solid #fee6ab;-moz-border-radius:3px;-webkit-border-radius:3px;border-radius:3px;
 color:#333;font:"Arial" 12px;padding-left:15px;padding-right:15px;padding-top:5px;margin-bottom:10px;text-align:left;}
 TD.statusTopHeadingTD{font-size:16px;font-weight:bold;color:#333;}
 TD.statusStandaloneTopHeadingTD{font-size:16px;font-weight:bold;color:#333;padding-bottom:5px;}
 Table.statusSection TD.statusSectionBody{color:#333;font-size:12px;}Table.statusSection TD.minorSectionHeader
 {color:#333;font-weight:bold;}Table.statusSection TD.contentSecColHeaders
 {font:12px Arial;color:#333;font-weight:bold;border-bottom-color:#bfbfbf;border-bottom-style:solid;border-bottom-width:2px;
  padding-left:6px;padding-right:6px;padding-top:6px;margin-bottom:3px;}TABLE.chargeSubTbl{padding-bottom:5px;}
    </style>
</head>
<body  style="text-align:center; ">
  
    <div class="leftshadow generalcontainer" style=" margin-top:100px;">
        <div class="maincontainer" >
            <div class="logocontainer">
                <div style="color: #fff; font-size: 24px; padding-top: 20px; padding-left: 10px;">
                    <asp:Label ID="lb_companyName" runat="server" Text=""></asp:Label></div>
            </div>
            <form id="form1" method="post" runat="server">
          
            <div class="bodycontainer">
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="comingsooncontainer">
                            <br>
                            <br>
                            <!---   <img src="Images/login_features_chrome.jpg" >--->
                            <iframe id="Iframe1" allowtransparency="true" frameborder="0" marginwidth="0" marginheight="0"
                                width="490px" height="299px" src="http://feeling3d.com/news.html" scrolling="no">
                            </iframe>
                        </td>
                      <td class="logincontainer" >
                <div id="logincontainer">
                    <div class="logincontainertitle">Sign In</div>                 
                    <div style="margin-top:5px;">
                        <div class="field_label">User ID:</div>
                        <div class="fielddiv">
                            <div style="display:inline;">
                          
                            <asp:TextBox ID="txt_USERNAME" runat="server" tabindex="1" class="textfield" maxlength="256"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ControlToValidate="txt_USERNAME" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div style="margin-top:5px; display: none; "></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="fieldcontainer">
                        <div class="field_label">Password:</div>
                        <div class="fielddiv">
                            <div style="display:inline;">
                              <asp:TextBox ID="txt_PASSWORD" runat="server"  
                                    autocomplete="off" tabindex="2" class="textfield" style="padding-left:7px;" TextMode="Password"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*" ControlToValidate="txt_PASSWORD" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div style="margin-top:5px; display: none; "></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                 
             <div class="fieldcontainer">
                        <div class="field_label">Check Code:</div>
                        <div class="fielddiv">
                            <div style="display:inline;">
                              <asp:TextBox ID="TB_Code" runat="server"  style="padding-left:7px;" tabindex="3"
                                    Height="20px" ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="*" ControlToValidate="TB_Code" ForeColor="Red"></asp:RequiredFieldValidator>
                                     <a id="A2" href="" onclick="ChangeCode();return false;">
                <img id="ImageCheck" src="../ValidateCode.ashx?GUID=GUID" style="border:0" alt="看不清，换一个" />
               </a>
                            </div>
                            <div style="margin-top:5px; display: none; "></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="fieldcontainer" style="margin-top:17px;">
                        <div class="field_label">&nbsp;</div>

                        <div class="fielddiv">

                        <asp:Button ID="Button1" runat="server" class='button' style='cursor: pointer;' tabindex="4"  buttonStyle='Main' Text="Sign In" onclick="Button1_Click"/>
                     	
                        </div>

						<div style="margin-left:10px;float:left;margin-top:13px;"></div>
                        <div class="clear"></div>
                    </div>
                   
                </div>
                </td>


                    </tr>
                </table>
            </div>
            <span id="DigestID"></span><span id="snID"></span>
            </form>
        </div>
    </div>
    <div class="footercontainer generalcontainer">
        <div class="copyright">
            &copy; 2012 <asp:Label ID="lb_companyName2" runat="server" Text=""></asp:Label>. All rights reserved.</div>
        <div class="footerlinkscontainer">
            <div class="footerlinks">
                <a class="footer_link" href="#" target="_blank">Register</a> &nbsp;&nbsp;|&nbsp;&nbsp;
                <a class="footer_link" href="#" target="_blank">Privacy</a> &nbsp;&nbsp;<span class="bottomSignupLink">|</span>&nbsp;&nbsp;
                <a class="footer_link bottomSignupLink" href="#" target="_blank">SiteMap</a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="divContentFooter" class="divContentFooter" style=''>
    </div>
    <div id="divFooter" class="divFooter" style=''>
    </div>
    <div id='chromewebstore' style='display: none; position: fixed; bottom: 0; right: 0;'>
        <a href='/' target='qboblog'>
            <img width='180px' src='/' />
        </a>
    </div>
</body>
</html>
