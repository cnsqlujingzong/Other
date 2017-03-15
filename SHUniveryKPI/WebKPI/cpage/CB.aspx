<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CB.aspx.cs" Inherits="cpage_cb" %>

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
            <h3 style="text-align:center">著作出版</h3>
            <asp:HiddenField ID="hid_cid" runat="server" />
            <div>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">

                        <tr>
                        <td height="35" width="30%" align="right">出版日期：</td>
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
                        <td  width="30%" align="right">&nbsp;著作名：</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtProjectName" runat="server" Width="200px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td  width="30%" align="right">出版社:</td>
                        <td  width="*" align="left"> <asp:TextBox ID="txtChubanshe" runat="server" Width="200px"></asp:TextBox></td>
                    </tr>      
                                                  
                        <tr>
                        <td  width="30%" align="right">著作类别：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_ptype" runat="server" Width="200px" >
                                <asp:ListItem Value="专著">专著</asp:ListItem>
                                <asp:ListItem Value="编著">编著</asp:ListItem>
                                <asp:ListItem Value="教材">教材</asp:ListItem>
                                <asp:ListItem Value="译著">译著</asp:ListItem>                       
                            </asp:DropDownList>
                                                        
                        </td>
                    </tr>
                     <tr>
                        <td  width="30%" align="right">出版社类别：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_cbtype" runat="server" Width="200px" >
                                <asp:ListItem Value="省部级和高校出版社">省部级和高校出版社</asp:ListItem>
                                <asp:ListItem Value="国家出版社">国家出版社</asp:ListItem>
                                <asp:ListItem Value="科学出版社">科学出版社</asp:ListItem>                            
                            </asp:DropDownList>                                                        
                        </td>
                    </tr>
                         <tr>
                        <td  width="30%" align="right">著作字数：</td>
                        <td  width="*" align="left">
                            <asp:DropDownList ID="ddl_zishu" runat="server" Width="200px" >
                                <asp:ListItem Value="L15">15万字以内</asp:ListItem>
                                <asp:ListItem Value="15T25">15万--25万</asp:ListItem>
                                <asp:ListItem Value="25P">25万及以上</asp:ListItem>                  
                            </asp:DropDownList>
                                                        
                        </td>
                    </tr>
                         <tr>
                        <td  width="30%" align="right">贡献比例：<br /></td>
                        <td  width="*" align="left">
                            是否独立作者   <asp:DropDownList ID="ddl_isdl" runat="server" Width="100px" AutoPostBack="True" >
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                    </asp:DropDownList><br />                         
                            <asp:Panel ID="Panel1" runat="server">
                                贡献工作量:  <asp:TextBox ID="txt_lv" runat="server" Width="80px"></asp:TextBox><span style="color:red">0~1之间</span>
                            </asp:Panel>

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
