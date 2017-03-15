<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LW.aspx.cs" Inherits="cpage_kylw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>
        td {
       line-height:30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div style="width: 900px; margin: 0px auto">
            <h3 style="text-align:center">科研论文</h3>
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
                                               </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">&nbsp;论文题目：</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtProjectName" runat="server" Width="200px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">杂志出版社:</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtChubanshe" runat="server" Width="200px"></asp:TextBox></td>
                    </tr>       
                         <tr>
                        <td  width="30%" align="right">卷期:</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtJuanqi" runat="server" Width="200px"></asp:TextBox></td>
                    </tr>   
                         <tr>
                        <td  width="30%" align="right">时间:</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtShijian" runat="server" Width="200px"></asp:TextBox></td>
                    </tr>   
                     <tr>
                        <td  width="30%" align="right">学科:</td>
                         <td>
                               <asp:DropDownList ID="ddl_xk" runat="server" Width="200px" >
                                <asp:ListItem Value="2.0">物理</asp:ListItem>
                                <asp:ListItem Value="1.5">数学</asp:ListItem>
                                <asp:ListItem Value="1.8">化学</asp:ListItem>
                                <asp:ListItem Value="2.0">生物</asp:ListItem>
                                 <asp:ListItem Value="1.5">待定</asp:ListItem>
                          
                            </asp:DropDownList>

                         </td>
                        </tr>
                        <tr>
                        <td  width="30%" align="right">期刊类别：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px" >
                                <asp:ListItem Value="A">A类</asp:ListItem>
                                <asp:ListItem Value="B">B类</asp:ListItem>
                                <asp:ListItem Value="C">C类</asp:ListItem>
                                <asp:ListItem Value="D">D类</asp:ListItem>
                                 <asp:ListItem Value="E">E类</asp:ListItem>                          
                            </asp:DropDownList>
                                  &nbsp;<br /><br />
                            <span style="font-size:14px;color:red;">类别说明:</span>
                            <br />
                            <div style="font-size:13px; line-height:16px">
                          <span style="font-weight:600"> A类：</span>SCI一区论文</div>
                            <div style="font-size:13px;line-height:16px">
                             <span style="font-weight:600"> B类：</span>SCI收录</div>
                             <div style="font-size:13px;line-height:16px">
                                 <span style="font-weight:600"> C类：</span>EI和ISTP收录</div>
                             <div style="font-size:13px;line-height:16px">
                                <span style="font-weight:600">  D类：</span>其他国际学术刊物及ISTP未收录的国际会议、核心期刊（1200种左右，不含高校学报）</div>
                             <div style="font-size:13px;line-height:16px">
                                 <span style="font-weight:600"> E类：</span>高校学报、全国学术会议（出版论文集）</div>
                             <div style="font-size:13px;line-height:16px">
                             
                        </td>
                    </tr>
                         <tr>
                        <td  width="30%" align="right">分配方案：<br /></td>
                        <td  width="*" align="left">
                            <table>
                                <thead>
                                        <tr>
                                         <th>自己</th>
                                        <th>作者类别</th>
                                            <th>姓名</th>
                                               <th>是否是学生</th>
                                              <th>是否是通讯作者</th>
                                </tr>                                    
                                </thead>
                            <tbody>
                                <tr>
                                    <td >
                                     <asp:RadioButton ID="rb_1" runat="server" name="rbzj" />
                                      </td>                                    
                                    <td> 独立作者</td>
                                    <td><asp:TextBox ID="txtJS1" runat="server" Text=""></asp:TextBox></td>
                                    <td><asp:CheckBox ID="cb_iss_1" runat="server" /></td>
                                     <td><asp:CheckBox ID="cb_istx_1" runat="server" /></td>                                    
                                </tr>
                                   <tr>
                                    <td >
                                     <asp:RadioButton ID="rb_2" runat="server" name="rbzj"/>
                                      </td>                                    
                                    <td> 第一作者</td>
                                    <td><asp:TextBox ID="txtJS2" runat="server" Text=""></asp:TextBox></td>
                                        <td><asp:CheckBox ID="cb_iss_2" runat="server" /></td>
                                     <td><asp:CheckBox ID="cb_istx_2" runat="server" /></td>
                                </tr>
                                   <tr>
                                    <td >
                                     <asp:RadioButton ID="rb_3" runat="server" name="rbzj"/>
                                      </td>                                    
                                    <td> 第二作者</td>
                                    <td><asp:TextBox ID="txtJS3" runat="server" Text=""></asp:TextBox></td>
                                         <td><asp:CheckBox ID="cb_iss_3" runat="server" /></td>
                                     <td><asp:CheckBox ID="cb_istx_3" runat="server" /></td>
                                </tr>
                                   <tr>
                                    <td >
                                     <asp:RadioButton ID="rb_4" runat="server" name="rbzj"/>
                                      </td>                                    
                                    <td> 第三作者</td>
                                    <td><asp:TextBox ID="txtJS4" runat="server" Text=""></asp:TextBox></td>
                                         <td><asp:CheckBox ID="cb_iss_4" runat="server" /></td>
                                     <td><asp:CheckBox ID="cb_istx_4" runat="server" /></td>
                                </tr>
                                   <tr>
                                    <td >
                                     <asp:RadioButton ID="rb_5" runat="server" name="rbzj"/>
                                      </td>                                    
                                    <td> 其他作者</td>
                                    <td><asp:TextBox ID="txtJS5" runat="server" Text=""></asp:TextBox></td>
                                         <td><asp:CheckBox ID="cb_iss_5" runat="server" /></td>
                                     <td><asp:CheckBox ID="cb_istx_5" runat="server" /></td>
                                </tr>
                            </tbody>
                            </table>
                       


                            &nbsp;</td>                        
                    </tr>
                   <tr>
                       <td width="30%" align="right">是否国际合作发表</td>
                       <td>                 
                                        <asp:DropDownList ID="ddl_gjhz" runat="server" Width="100px">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem Selected="True">否</asp:ListItem>
                             </asp:DropDownList>
                       </td>
                   </tr>
                        <tr>
                        <td  width="30%" align="right">
                            <asp:Label ID="Label1" runat="server" Text="免考核项*" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                        <td  width="*" align="left">                  
                            <br />         
                            <asp:DropDownList ID="ddl_mkh" runat="server" Width="100px">
                                <asp:ListItem>是</asp:ListItem>
                                <asp:ListItem Selected="True">否</asp:ListItem>
                             </asp:DropDownList><br />
                            <span style="color:red">  Science。Nature、PRL、JACS等国际最顶级学术奇卡发表原创性科学论文</span>
                            </td>
                    </tr>  
                       <tr>
                        <td  width="30%" align="right">&nbsp;</td>
                        <td  width="*" align="left">
                              <br />
                        </td>
                    </tr>  
                       <tr>
                        <td  width="30%" align="right">&nbsp;</td>
                        <td  width="*" align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">&nbsp;</td>
                        <td  width="*" align="left">
                            &nbsp;</td>
                    </tr>                   
                    <tr>
                        <td  width="30%" align="right">&nbsp;</td>
                        <td  width="*" align="left">
                            &nbsp;</td>
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
