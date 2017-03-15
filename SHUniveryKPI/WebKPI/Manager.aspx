<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
        font-family:'Microsoft YaHei'
        }
        ul li {
        float:left;
        padding:5px 10px;
        }
        td {
        text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:0 auto; width:1000px;">
        <h1 style="color:#1d38d7;text-align:center">教师考核管理</h1>
    <ul style="list-style-type:none">
        <li>年度：
            <asp:DropDownList ID="ddl_year" runat="server">
                <asp:ListItem Value="2016">2016</asp:ListItem>
                 <asp:ListItem Value="2017">2017</asp:ListItem>
                 <asp:ListItem Value="2018">2018</asp:ListItem>
                 <asp:ListItem Value="2019">2019</asp:ListItem>
                 <asp:ListItem Value="2020">2020</asp:ListItem>
                 <asp:ListItem Value="2021">2021</asp:ListItem>
                 <asp:ListItem Value="2022">2022</asp:ListItem>
                 <asp:ListItem Value="2023">2023</asp:ListItem>
                 <asp:ListItem Value="2024">2024</asp:ListItem>
                 <asp:ListItem Value="2025">2025</asp:ListItem>
                 <asp:ListItem Value="2026">2026</asp:ListItem>
            </asp:DropDownList>
        </li>
        <li>
            姓名/工号：<asp:TextBox ID="tx_kw" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
        </li>

    </ul>
        <div style="clear:both; background-color:#ff6a00; color:#fff;padding-left:10px;font-size:20px;margin-bottom:10px" >考核表</div>
        <div>
            <table cellspacing="0" cellpadding="0" style="width:100%">
                <thead>
                    <tr>
                        <th>序号</th>
                        <th>考核年度</th>
                        <th>教师编号</th>
                        <th>教师姓名</th>
                        <th>是否免考核</th>
                        <th>考核分数</th>
                        <th>考核表状态</th>
                        <th>查看</th>
                         <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                     <asp:Repeater ID="rp_main" runat="server" OnItemCommand="rp_main_ItemCommand">
                <ItemTemplate>
                        <tr>
                        <td><%#Eval("id") %></td>
                        <td><%#string.IsNullOrEmpty(Eval("KPIYear").ToString())?ddl_year.SelectedValue:Eval("KPIYear").ToString() %></td>
                        <td><%#Eval("WorkID") %></td>
                        <td><%#Eval("Name") %></td>
                        <td><%# GetTop(Eval("kid").ToString()) %></td>
                        <td><%# GetScore(Eval("kid").ToString()) %></td>
                        <td><%#GetStatus(Eval("Status").ToString()) %></td>
                        <td><a href='/manage/KPIManageM.aspx?id=<%#Eval("kid")%>' target="_blank">查看</a></td>
                         <td>
                             <asp:Button ID="Button2" runat="server" OnClientClick="javascript:return confirm('确定要审核通过吗')" Text="通过" CommandName="pass" CommandArgument='<%#Eval("kid") %>' />&nbsp;&nbsp;
                             <asp:Button ID="Button3" runat="server" OnClientClick="javascript:return confirm('确定要审核驳回吗')" Text="驳回" CommandName="back" CommandArgument='<%#Eval("kid") %>' />
                       
                         </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
                </tbody>
            </table>
           
        </div>
    </div>
    </form>
</body>
</html>
