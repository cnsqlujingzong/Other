<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="Admin_User_UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="342px" DataSourceID="ObjectDataSource1" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <EditRowStyle BackColor="#999999" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="ID" HeaderText="序号" SortExpression="ID" />
                                <asp:BoundField DataField="WorkID" HeaderText="工号" SortExpression="WorkID" />
                                <asp:BoundField DataField="Password" HeaderText="密码" SortExpression="Password" />
                                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                                <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
                                <asp:BoundField DataField="BrithDay" DataFormatString="{0:yyyy-MM-dd}" HeaderText="生日" SortExpression="BrithDay" />
                                <asp:BoundField DataField="Xueli" HeaderText="学历" SortExpression="Xueli" />
                                <asp:BoundField DataField="Xuexiao" HeaderText="学校" SortExpression="Xuexiao" />
                                <asp:BoundField DataField="Zhiwu" HeaderText="职务" SortExpression="Zhiwu" />
                                <asp:BoundField DataField="Email" HeaderText="电子邮件" SortExpression="Email" />
                                <asp:BoundField DataField="Moblie" HeaderText="手机" SortExpression="Moblie" />
                                <asp:BoundField DataField="Tel" HeaderText="办公电话" SortExpression="Tel" />
                                <asp:BoundField DataField="InDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="进校日期" SortExpression="InDate" />
                                <asp:BoundField DataField="Ramerk" HeaderText="备注" SortExpression="Ramerk" />
                                <asp:BoundField DataField="UserType" HeaderText="用户类型" SortExpression="UserType" />
                                <asp:BoundField DataField="Satat" HeaderText="账户状态" SortExpression="Satat" />
                                <asp:BoundField DataField="CreatDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="创建日期" SortExpression="CreatDate" />
                            </Fields>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        </asp:DetailsView>
                      
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetModel" TypeName="SHUniversity.KPI.BLL.Users">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="id" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                      
                    </div>
                </div>
            </div>
        </div>



    </form>
</body>
</html>
