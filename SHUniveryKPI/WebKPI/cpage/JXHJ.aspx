<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JXHJ.aspx.cs" Inherits="cpage_JXHJ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 36px;
        }
        .auto-style3 {
            height: 27px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
      <style>
        td {
       line-height:30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div style="width: 900px; margin: 0px auto">
            <h3 style="text-align:center">教学获奖</h3>
            <asp:HiddenField ID="hid_cid" runat="server" />
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">

                        <tr>
                        <td height="35" width="30%" align="right">获奖日期：</td>
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
                        <td  width="30%" align="right" class="auto-style4">获奖名称：</td>
                        <td  width="*" align="left" class="auto-style4"> <asp:TextBox ID="txtProjectName" runat="server" Width="200px"></asp:TextBox> </td>
                    </tr>       
                            
                        <tr>
                        <td  width="30%" align="right" class="auto-style2">获奖分类：</td>
                        <td  width="*" align="left" class="auto-style2">
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_ptype_SelectedIndexChanged" >
                                <asp:ListItem >全国优秀教学成果奖</asp:ListItem>
                                <asp:ListItem >全国优秀教材奖</asp:ListItem>
                                <asp:ListItem >省部委级优秀教学成果奖</asp:ListItem>
                                <asp:ListItem >省部委级优秀教材奖</asp:ListItem>
                                 <asp:ListItem Value="校级获奖">局级优秀教学成果奖和优秀教材奖(校级获奖)</asp:ListItem>                        
                            </asp:DropDownList>
                                  <asp:DropDownList ID="ddl_xj_level" runat="server" Width="200px"  Visible="false">
                                <asp:ListItem >特等奖</asp:ListItem>
                                <asp:ListItem >一等奖</asp:ListItem>
                                <asp:ListItem >二等奖</asp:ListItem>
                                <asp:ListItem >三等奖</asp:ListItem>                                          
                            </asp:DropDownList>
                                  &nbsp;<br />
                           
                        </td>
                    </tr>
                         <tr>
                        <td  width="30%" align="right" class="auto-style3">指导老师数量:</td>
                        <td  width="*" align="left" class="auto-style3">
                           <asp:DropDownList ID="ddl_qty" runat="server" Width="200px"  Visible="false">
                                <asp:ListItem >1</asp:ListItem>
                                <asp:ListItem >2</asp:ListItem>
                                <asp:ListItem >3</asp:ListItem>
                                <asp:ListItem >4</asp:ListItem>          
                                  <asp:ListItem >5</asp:ListItem>             
                                  <asp:ListItem >6</asp:ListItem>             
                                  <asp:ListItem >7</asp:ListItem>           
                                   <asp:ListItem >8</asp:ListItem>             
                                  <asp:ListItem >9</asp:ListItem>             
                                  <asp:ListItem >10</asp:ListItem>                                       
                            </asp:DropDownList>
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
