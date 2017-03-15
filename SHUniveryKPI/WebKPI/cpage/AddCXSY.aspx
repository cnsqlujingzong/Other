<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCXSY.aspx.cs" Inherits="cpage_AddCXSY" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link  href="../css/Style.css" rel="stylesheet"/>
    <style>
        td {
        padding:5px 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 900px; margin: 0px auto">
            <h3 style="text-align:center">大学生创新实验项目</h3>
            <asp:HiddenField ID="hid_cid" runat="server" />
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">

                        <tr>
                        <td height="35" width="30%" align="right">项目周期：</td>
                        <td height="35" width="*" align="left">
                            <asp:DropDownList ID="ddl_pstartyear" runat="server">
                                  <asp:ListItem Value="2016">2016年</asp:ListItem>
                                  <asp:ListItem Value="2017">2017年</asp:ListItem>
                                 <asp:ListItem Value="2018">2018年</asp:ListItem>
                                  <asp:ListItem Value="2019">2019年</asp:ListItem>
                                  <asp:ListItem Value="2020">2020年</asp:ListItem>
                                  <asp:ListItem Value="2021">2021年</asp:ListItem>
                                  <asp:ListItem Value="2022">2022年</asp:ListItem>
                                  <asp:ListItem Value="2023">2023年</asp:ListItem>
                                  <asp:ListItem Value="2024">2024年</asp:ListItem>
                                  <asp:ListItem Value="2025">2025年</asp:ListItem>
                                  <asp:ListItem Value="2026">2026年</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="ddl_pstartmonth" runat="server">
                                   <asp:ListItem Value="1">01月</asp:ListItem>
                                  <asp:ListItem Value="2">02月</asp:ListItem>
                                 <asp:ListItem Value="3">03月</asp:ListItem>
                                  <asp:ListItem Value="4">04月</asp:ListItem>
                                  <asp:ListItem Value="5">05月</asp:ListItem>
                                  <asp:ListItem Value="6">06月</asp:ListItem>
                                  <asp:ListItem Value="7">07月</asp:ListItem>
                                  <asp:ListItem Value="8">08月</asp:ListItem>
                                  <asp:ListItem Value="9">09月</asp:ListItem>
                                  <asp:ListItem Value="10">10月</asp:ListItem>
                                  <asp:ListItem Value="11">11月</asp:ListItem>
                                  <asp:ListItem Value="12">12月</asp:ListItem>
                                               </asp:DropDownList>至
                            <asp:DropDownList ID="ddl_pendyear" runat="server">
                                    <asp:ListItem Value="2016">2016年</asp:ListItem>
                                  <asp:ListItem Value="2017">2017年</asp:ListItem>
                                 <asp:ListItem Value="2018">2018年</asp:ListItem>
                                  <asp:ListItem Value="2019">2019年</asp:ListItem>
                                  <asp:ListItem Value="2020">2020年</asp:ListItem>
                                  <asp:ListItem Value="2021">2021年</asp:ListItem>
                                  <asp:ListItem Value="2022">2022年</asp:ListItem>
                                  <asp:ListItem Value="2023">2023年</asp:ListItem>
                                  <asp:ListItem Value="2024">2024年</asp:ListItem>
                                  <asp:ListItem Value="2025">2025年</asp:ListItem>
                                  <asp:ListItem Value="2026">2026年</asp:ListItem>
                            </asp:DropDownList>  <asp:DropDownList ID="ddl_pendmonth" runat="server">
                                    <asp:ListItem Value="1">01月</asp:ListItem>
                                  <asp:ListItem Value="2">02月</asp:ListItem>
                                 <asp:ListItem Value="3">03月</asp:ListItem>
                                  <asp:ListItem Value="4">04月</asp:ListItem>
                                  <asp:ListItem Value="5">05月</asp:ListItem>
                                  <asp:ListItem Value="6">06月</asp:ListItem>
                                  <asp:ListItem Value="7">07月</asp:ListItem>
                                  <asp:ListItem Value="8">08月</asp:ListItem>
                                  <asp:ListItem Value="9">09月</asp:ListItem>
                                  <asp:ListItem Value="10">10月</asp:ListItem>
                                  <asp:ListItem Value="11">11月</asp:ListItem>
                                  <asp:ListItem Value="12">12月</asp:ListItem>
                                                 </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">项目编号：</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtProjectNO" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">项目名称：</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtProjectName" runat="server" Width="200px"></asp:TextBox> </td>
                    </tr>       
                        <tr>
                        <td  width="30%" align="right">项目级别：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px">
                                <asp:ListItem>院系项目</asp:ListItem>
                                <asp:ListItem>校级项目</asp:ListItem>
                                <asp:ListItem>市级项目</asp:ListItem>
                                <asp:ListItem>国家级项目</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                      <tr>
                        <td  width="30%" align="right">周期(天数)：</td>
                        <td  width="*" align="left">
                            <asp:TextBox ID="txtZQ" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">学生数：</td>
                        <td  width="*" align="left">
                            <asp:TextBox ID="txtStuNum" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                        <td  width="30%" align="right">项目质量：</td>
                        <td  width="*" align="left">
                            <asp:RadioButtonList ID="rb_status" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="合格" Selected="True">合格</asp:ListItem>
                                <asp:ListItem Value="优秀">优秀</asp:ListItem>
                                <asp:ListItem Value="不合格">不合格或未完成</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>                        
                    </tr>
                    <tr>
                        <td  width="30%" align="right">学生院系：</td>
                        <td  width="*" align="left">
                            <asp:TextBox ID="txtStuYuanXi" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td  width="30%" align="right">学生名单：</td>
                        <td  width="*" align="left">
                            <asp:TextBox ID="txtStuNames" runat="server" Width="250px" TextMode="MultiLine" Height="116px"></asp:TextBox>
                        </td>
                    </tr>
                  
                
                            <tr>
                        <td  width="30%" align="right"></td>
                        <td  width="*" align="left">
                            <asp:Button ID="btnSubmit" runat="server" Text="保存" Width="140px" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;
                              <asp:Button ID="btnCancel" runat="server" Text="返回" Width="140px" OnClick="btnCancel_Click"  />
                        </td>
                        
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
