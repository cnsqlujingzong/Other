<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-1.11.2.js"></script>
    <style>
        .titleBar {
            /**D8F0F8**/
            padding: 15px 10px;
            font-size: 20px;
            background: #205081;
            cursor: pointer;
            margin-bottom: 0px;
            color: #fff;
        }

        .content {
            border: 2px solid #205081;
            padding-left: 15px;
        }

        .titleYear {
            font-size: 28px;
            font-weight: 600;
        }

        #mainTable td,#mainTable th {
            padding: 5px 10px;
        }

        .itemRow {
            background: #eeeeee;
        }

        .altRow {
            background: #dddddd;
        }
    </style>
</head>
<body style="background: #efefef">
    <form id="form1" runat="server">
        <div>
            <h3 id="tit_tableList" class="titleBar" href="#tableList" style="">考核表列表</h3>
            <div id="tableList" class="content">
                <p>当前考核期：<span id="list_year" class="titleYear"></span>&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_msg" runat="server" Text="Label" >&nbsp;&nbsp;&nbsp;</asp:Label>&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_CreatTable" runat="server" Text="开始建立考核表" OnClick="btn_CreatTable_Click" /></p>
                <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" id="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>考评单号</th>
                                <th>考评年</th>
                                <th>考评人工号</th>
                                <th>考评人姓名</th>
                                <th>创建时间</th>
                                <th>状态</th>
                                <th>查看</th>
                                 <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_table" runat="server" OnItemCommand="rp_table_ItemCommand">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                        <td><%#Eval("ID") %></td>
                                        <td><%#Eval("KPINumber") %></td>
                                        <td><%#Eval("KPIYear") %></td>
                                        <td><%#Eval("WorkID") %></td>
                                        <td><%#Eval("Creator") %></td>
                                        <td><%#string.Format("{0:yyyy-MM-dd HH:mm:ss}",Eval("CreatDate")) %></td>
                                        <td><%#GetStatus(Eval("Status").ToString()) %></td>
                                        <td><a href="KPIManage.aspx?id=<%#Eval("ID") %>">查看详细</a></td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" OnClientClick="javascript:return confirm('确认提交审核')" Text="提交审核" CommandName="apply" CommandArgument='<%#Eval("ID") %>'/></td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                        <td><%#Eval("KPINumber") %></td>
                                        <td><%#Eval("KPIYear") %></td>
                                        <td><%#Eval("WorkID") %></td>
                                        <td><%#Eval("Creator") %></td>
                                        <td><%#string.Format("{0:yyyy-MM-dd HH:mm:ss}",Eval("CreatDate"))  %></td>
                                        <td><%#GetStatus(Eval("Status").ToString()) %></td>
                                        <td><a href="KPIManage.aspx?id=<%#Eval("ID") %>">查看详细</a></td>
                                            <td>
                                            <asp:Button ID="Button1" runat="server" OnClientClick="javascript:return confirm('确认提交审核')"  Text="提交审核" CommandName="apply" CommandArgument='<%#Eval("ID") %>'/></td>
                                
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>

                </div>
            </div>
                 <h3 id="tit_TableDetail" class="titleBar" href="#TableDetail" style="">考核表详细</h3>
                 <div id="TableDetail" class="content" style="display:none">
                     <p>detail</p>
                      <p>detail</p>
                      <p>detail</p>
                      <p>detail</p>
                 </div>
        </div>
    </form>
</body>
</html>
<script>
    $(function () {
        $(".titleBar").click(function () {
            var id = $(this).attr("href");
            $(id).slideToggle();          
        });

        var d = new Date()
        $("#list_year").html(d.getFullYear() + "年度");
    })
</script>
