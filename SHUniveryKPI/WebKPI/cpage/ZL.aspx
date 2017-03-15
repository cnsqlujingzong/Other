<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZL.aspx.cs" Inherits="cpage_zl" %>

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
            <h3 style="text-align:center">专利(不记学生)</h3>
            <asp:HiddenField ID="hid_cid" runat="server" />
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">

                        <tr>
                        <td height="35" width="30%" align="right">授权日期：</td>
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
                        <td  width="30%" align="right">&nbsp;专利名：</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtProjectName" runat="server" Width="200px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">授权编号:</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtChubanshe" runat="server" Width="200px"></asp:TextBox></td>
                    </tr>      
                                     <tr>
                        <td  width="30%" align="right">奖励类型：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_cbtype" runat="server" Width="200px" >
                                <asp:ListItem Value="20" Selected="True">国家发明专利</asp:ListItem>
                                <asp:ListItem Value="10">国家实用新型专利</asp:ListItem>
                                <asp:ListItem Value="5">国家外观设计专利</asp:ListItem>                                             
                            </asp:DropDownList>
                                                        
                        </td>
                    </tr>                  
                        <tr>
                        <td  width="30%" align="right">专利国别：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px" >
                                <asp:ListItem Value="1"  Selected="True">国内</asp:ListItem>
                                <asp:ListItem Value="1">国外专利</asp:ListItem>
                                           
                            </asp:DropDownList>
                                                        
                        </td>
                    </tr>
                
                    
                         <tr>
                        <td  width="30%" align="right">贡献比例：<br /></td>
                        <td  width="*" align="left">
                            排位顺序: <asp:DropDownList ID="ddl_isdl" runat="server" Width="100px" AutoPostBack="True" >
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                      <asp:ListItem Value="3">3</asp:ListItem>
                                                      <asp:ListItem Value="4">4</asp:ListItem>
                                                      <asp:ListItem Value="5">5</asp:ListItem>
                                                    </asp:DropDownList><br />                         
                            
                                权重分配:  <asp:TextBox ID="txt_lv" runat="server" Width="80px"></asp:TextBox><span style="color:red">0~1之间</span>
                        

                            &nbsp;</td>                        
                    </tr>
                   <tr>
                       <td width="30%" align="right">&nbsp;</td>
                       <td>                 
                                        &nbsp;</td>
                   </tr>
                        <tr>
                        <td  width="30%" align="right">
                            &nbsp;</td>
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
