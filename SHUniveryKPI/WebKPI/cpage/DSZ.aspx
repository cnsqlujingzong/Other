<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSZ.aspx.cs" Inherits="cpage_DSZ" %>

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
            <h3 style="text-align:center">本科班导师，励志导师，学术导师</h3>
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
                        <td  width="30%" align="right">导师类型：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px">
                                <asp:ListItem>本科班导师</asp:ListItem>
                                <asp:ListItem>励志导师</asp:ListItem>
                                <asp:ListItem>学术导师</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                    </tr>
                         <tr>
                        <td  width="30%" align="right">学年指导数：</td>
                        <td  width="*" align="left">
                            <asp:RadioButtonList ID="rb_num" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected>一个</asp:ListItem>
                                <asp:ListItem Value="2">两个</asp:ListItem>                            
                            </asp:RadioButtonList>
                        </td>                        
                    </tr>
                   
                        <tr>
                        <td  width="30%" align="right">指导质量：</td>
                        <td  width="*" align="left">
                             <asp:RadioButtonList ID="rb_zl" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                  <asp:ListItem Value="合格" Selected >合格</asp:ListItem>   
                                     <asp:ListItem Value="院优" >院优</asp:ListItem>                        
                                <asp:ListItem Value="校优" >校优</asp:ListItem>
                                    <asp:ListItem Value="不合格" >不合格</asp:ListItem>                                    
                            </asp:RadioButtonList>
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
                        <td  width="30%" align="right">学生院系：</td>
                        <td  width="*" align="left">
                            <asp:TextBox ID="txtStuYuanXi" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                
                    <tr>
                        <td  width="30%" align="right">&nbsp;</td>
                        <td  width="*" align="left">
                            &nbsp;</td>
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
