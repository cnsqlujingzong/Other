<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="Admin_User_UserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>账号编辑</title>
    <link href="../resources/css/global.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.11.2.js"></script>
    <script type="text/javascript" src="../../js/Base.js"></script>
      <script type="text/javascript" src="../../js/my97/WdatePicker.js"></script>
</head>
<body>
     <form id="form1" runat="server">
        <div style="margin-left: 6px; margin-top: 6px;">
            <div style="background-color: #DADFEF; color: #593D00; font-size: 9pt; padding: 5px 3px; border: 1px solid gray;">
                【当前位置】:&nbsp;&nbsp;&nbsp;编辑账号
            </div>
            <div style="background-color: #DADFEF; padding: 5px 15px; border: 1px solid gray; margin-top: 10px;">
                <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
                <div style="padding: 10px 15px;">
                    <div style="width: 90%; margin: 0 auto;">
                        <table width="600px" cellpadding="0" cellspacing="0" id="mainTable">
                              <tr>
                                <td class="ltd">用户类型:</td>
                                <td style="text-align: left">
                                    <asp:HiddenField ID="hidid" runat="server" />
                                  <asp:RadioButtonList ID="rb_usertype" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Selected="True">普通用户</asp:ListItem>
                                        <asp:ListItem Value="1">审核员</asp:ListItem>
                                        <asp:ListItem Value="99">管理员</asp:ListItem>
                                    </asp:RadioButtonList>  
                                </td>
                            </tr>
                            <tr>
                                <td class="ltd">工号:</td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txt_workID" runat="server" class="txt"></asp:TextBox>
                                  </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">初始密码:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_pwd" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">员工姓名:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_name" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">性别:</td>
                                <td style="text-align: left">
                                    <asp:RadioButtonList ID="rb_sex" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                        <asp:ListItem Value="0">女</asp:ListItem>
                                    </asp:RadioButtonList>
                                  </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">出生日期:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_birthday" runat="server" class="txt"   onfocus="WdatePicker()"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">学历:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_xueli" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">学校:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_xuexiao" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">职务:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_zhiwu" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">Email:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_email" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">手机:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_moblie" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">办公电话:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_tell" runat="server" class="txt"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">进校时间:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_indate" runat="server" class="txt" onfocus="WdatePicker()" ></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; color: #4372B0; padding-right: 10px; font-size: 14px;">备注:</td>
                                <td style="text-align: left">
                                     <asp:TextBox ID="txt_common" runat="server" class="txt" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                           
                            <tfoot>
                                <tr>
                                    <td colspan="2" align="right">
                                        <a class="save" href="UserManage.aspx" style="color: #4372B0;">取消</a>                                     
                                        <asp:Button ID="butSava" runat="server" class="save" Text="确认"
                                           OnClientClick="return checkData()" OnClick="butSava_Click" /></td>
                                </tr>
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
            $("#newstypename").val("");
        });
    });
    function checkData() {
        //  alert(document.getElementById("newstypename").value.trim().length);
        if (isNull(Trim($("#txt_workID").val())))
        {
            alert("工号不能为空！");
            return false;
        }
        if (isNull(Trim($("#txt_pwd").val()))) {
            alert("初始密码不能为空！");
            return false;
        }
        if (isNull(Trim($("#txt_name").val()))) {
            alert("员工姓名不能为空！");
            return false;
        }
        if (isNull(Trim($("#txt_birthday").val())))
        {
            alert("出生日期不能为空！");
            return false;
        }
        if (isNull(Trim($("#txt_zhiwu").val()))) {
            alert("职务不能为空！");
            return false;
        }
        //Trim
        else {
            return true;
        }

    }
</script>