<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KYXM.aspx.cs" Inherits="cpage_KYXM" %>

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
            <h3 style="text-align:center">科研项目</h3>
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
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px" >
                                <asp:ListItem Value="A">A类</asp:ListItem>
                                <asp:ListItem Value="B">B类</asp:ListItem>
                                <asp:ListItem Value="C">C类</asp:ListItem>
                                <asp:ListItem Value="D">D类</asp:ListItem>
                                 <asp:ListItem Value="E">E类</asp:ListItem>
                                 <asp:ListItem Value="F">F类</asp:ListItem>
                            </asp:DropDownList>
                                  <asp:Label ID="LBGJJF" runat="server" Text="实到经费"></asp:Label>
                            <asp:TextBox ID="txtGJJF" runat="server"></asp:TextBox>万
                            <br />
                            <span style="font-size:14px;color:red;">级别说明:</span>
                            <br />
                            <div style="font-size:13px; line-height:16px">
                          <span style="font-weight:600"> A类：</span>国家自然科学基金重大项目、863计划重大项目、973计划项目、国家重大基础研究计划项目</div>
                            <div style="font-size:13px;line-height:16px">
                             <span style="font-weight:600"> B类：</span>国家自然科学基金重点项目、国家自然科学基金重大项目子课题、863计划项目、973计划项目直接课题(申请时列入)、国家重大基础研究计划项目子课题、国家级重点人才基金、市科委重大项目等</div>
                             <div style="font-size:13px;line-height:16px">
                                 <span style="font-weight:600"> C类：</span>国家自然科学基金面上项目(含青年基金)、国家自然科学基金重点项目子课题和863计划项目直接课题(申请时列入)、市科委重点项目</div>
                             <div style="font-size:13px;line-height:16px">
                                <span style="font-weight:600">  D类：</span>科技部、国防科工委等国家部委办一般项目、教育部博士点基金、以及国家自然科学基金主任基金、天元数学基金、理论物理专科项目、市科委启明星计划、市教委曙光计划、浦江计划等项目</div>
                             <div style="font-size:13px;line-height:16px">
                                 <span style="font-weight:600"> E类：</span>市科委、市经信委、市教委、市发改委等上海市委办局的项目</div>
                             <div style="font-size:13px;line-height:16px">
                                <span style="font-weight:600">F类：</span>横向科研项目(项目和经费应经校科技处认定、按照项目合同书、以本考核期间实到校经费为准，因和外单位合作而划转出去的项目经费和仪器设备经费等不计算在内)</div><br />

                        </td>
                    </tr>
                         <tr>
                        <td  width="30%" align="right">分配方案：<br /><span style="font-size:12px">(可不计指导的学生排名，只计教师实际排名)</span></td>
                        <td  width="*" align="left">
                                本人贡献比例：<asp:TextBox ID="txt_self_lv" runat="server" Text=""></asp:TextBox><br />
                            教师1：<asp:TextBox ID="txtJS1" runat="server" Text=""></asp:TextBox>贡献比例:<asp:TextBox ID="txt_js1_lv" runat="server" Text=""></asp:TextBox><br />
                            教师2：<asp:TextBox ID="txtJS2" runat="server" Text=""></asp:TextBox>贡献比例:<asp:TextBox ID="txt_js2_lv" runat="server" Text=""></asp:TextBox><br />
                            教师3：<asp:TextBox ID="txtJS3" runat="server" Text=""></asp:TextBox>贡献比例:<asp:TextBox ID="txt_js3_lv" runat="server" Text=""></asp:TextBox><br />
                            教师4：<asp:TextBox ID="txtJS4" runat="server" Text=""></asp:TextBox>贡献比例:<asp:TextBox ID="txt_js4_lv" runat="server" Text=""></asp:TextBox><br />
                        
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
