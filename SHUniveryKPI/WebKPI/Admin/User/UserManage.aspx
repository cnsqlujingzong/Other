<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="Master_UserManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户管理</title>
    <link href="../resources/css/global.css" type="text/css" rel="stylesheet" />
    <style>
        #mainTable td {
            text-align: center;
            padding: 3px 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 6px; margin-top: 6px;">
            <div style="background-color: #DADFEF; color: #593D00; font-size: 9pt; padding: 5px 3px; border: 1px solid gray;">
                【当前位置】:&nbsp;&nbsp;&nbsp;教师管理
            </div>
            <div style="background-color: #DADFEF; padding: 5px 15px; border: 1px solid gray; margin-top: 10px;">
                <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
                <div style="padding: 10px 15px;" class="tahead">
                    <table width="" cellpadding="0" cellspacing="0" style="border: 2px solid #99BBE8" id="mainTable">
                        <thead>
                            <tr>
                                <td colspan="12" style="vertical-align: bottom;">
                                    <ul style="margin-left: 15px; padding-top: 20px;">
                                        <li>
                                            <div>
                                                <a class="iconfl" href="AddUser.aspx" target="mainFrame">添加员工</a>
                                            </div>
                                        </li>
                                        <li>
                                            <div>
                                                <asp:LinkButton ID="LB_DelSelect" class="iconf3" runat="server" OnClick="LB_DelSelect_Click" Width="71px" OnClientClick="return confirm('您确认要删除吗？')">删除选中项</asp:LinkButton>
                                            </div>
                                        </li>
                                          <li>
                                              用户状态：<asp:DropDownList ID="ddl_stat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_stat_SelectedIndexChanged" style="width:150px">
                                                  <asp:ListItem Value="-1">全部</asp:ListItem>
                                                  <asp:ListItem Value="1">启用</asp:ListItem>
                                                  <asp:ListItem Value="0">禁用</asp:ListItem>
                                                   </asp:DropDownList>
                                                 &nbsp;&nbsp;
                                          </li>
                                        <li>
                                            <div>
                                                <span style="font-size:14px">查询条件:</span><asp:TextBox ID="txt_search" runat="server"></asp:TextBox><asp:Button ID="btnsearch" runat="server" Text="搜索" OnClick="btnsearch_Click" />
                                         &nbsp;&nbsp;
                                                <span style="font-size:12px ;color:red">(支持工号,姓名,职务,邮箱,手机关键字搜索。可扩展)</span>
                                                   </div>
                                        </li>
                                        <li></li>
                                        <li style="width: 232px"></li>

                                    </ul>
                                    <div style="clear: both"></div>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 50px">
                                    <input type="checkbox" id="checkAll" onclick="GetAllCheckBox(this)" /></th>
                                <th style="width: 50px">序号</th>
                                <th style="width: 100px">工号</th>
                                <th style="width: 100px">姓名</th>
                                <th style="width: 100px">职务</th>
                                <th style="width: 100px">邮箱</th>
                                <th style="width: 100px">手机</th>
                                <th style="width: 100px">办公电话</th>
                                <th style="width: 80px">账户类型</th>
                                <th style="width: 80px">是否启用</th>
                                  <th style="width: 80px">详细</th>
                                <th style="width: 80px">编辑</th>
                                <th style="width: 80px">删除</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RP_con" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td style="">
                                            <asp:CheckBox ID="CheckBox1_" class="check" runat="server" />
                                            <asp:HiddenField ID="HiddenField_" runat="server" Value='<%# Eval("ID")%>' />
                                        </td>
                                        <td>
                                            <%#Eval("ID")%>
                                        </td>
                                        <td>
                                            <%#Eval("WorkID")%>
                                        </td>
                                        <td>
                                            <%#Eval("Name")%>
                                        </td>
                                        <td>
                                            <%#Eval("Zhiwu")%>
                                        </td>
                                        <td>
                                            <%#Eval("Email")%>
                                        </td>
                                        <td>
                                            <%#Eval("Moblie")%>
                                        </td>
                                        <td>
                                            <%#Eval("Tel")%>
                                        </td>
                                        <td>
                                            <%#Convert.ToInt32(Eval("UserType"))==99?"管理员":(Convert.ToInt32(Eval("UserType"))==0?"普通用户":"审核员")%>
                                        </td>


                                        <td>
                                            <a href="UserEdit.aspx?id=<%#Eval("ID") %>&con=pub">
                                                <img src="<%#GetPubICO(Eval("Satat").ToString())%>" alt="发布" border="0" /></a>
                                        </td>
                                        <td>
                                                    <a href="UserDetail.aspx?id=<%#Eval("ID") %>">详细</a>
                                        </td>
                                        <td>

                                            <a href="UserEdit.aspx?id=<%#Eval("ID") %>&con=edit">
                                                <img src="../resources/img/edit.gif" alt="编辑" border="0" /></a>

                                        </td>
                                        <td>
                                            <a href="UserEdit.aspx?id=<%#Eval("ID") %>&con=del" onclick="return confirm('您确认要删除吗？')">
                                                <img src="../resources/img/cross.gif" alt="删除" border="0" /></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>


                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
<script>
    function GetAllCheckBox(CheckAll) {
        var items = document.getElementsByTagName("input");
        for (var i = 0; i < items.length; i++) {
            if (items[i].type == "checkbox") {
                items[i].checked = CheckAll.checked;
            }
        }
    }
</script>
