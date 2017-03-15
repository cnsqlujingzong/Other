<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_NewsType.aspx.cs" Inherits="Master_News_Admin_NewsType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻类型管理</title>
  
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../resources/js/Admin.js"></script>
    <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
     <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;新闻分类管理
        </div>
          <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
          <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
           <div style=" padding:10px 15px;" class="tahead">
             <table width="90%" cellpadding="0" cellspacing="0" style="border: 2px solid #99BBE8"
            align="center">
            <thead>
                <tr >
                    <td colspan="5" style=" vertical-align:bottom;" >
                        <ul style="margin-left: 15px; padding-top:20px;">
                            <li >
                                <asp:HyperLink class="iconfl" ID="HL_NewType" runat="server" target="mainFrame">新分类</asp:HyperLink>
                           </li>
                            <li >
                                <asp:LinkButton ID="LinkButton1" class="iconf3" runat="server" 
                                    onclick="LinkButton1_Click" Width="71px">删除选中项</asp:LinkButton></li>
                             <li>
                                 <!---<a class="iconf4" href="NewsAdmin.aspx">返回</a>-->
                             </li>
                              <li>
                                 <asp:DropDownList ID="DD_language" runat="server" AutoPostBack="True" 
                                      border="1px" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                     <asp:ListItem Value="cn">简体中文</asp:ListItem>
                                     <asp:ListItem Value="en">英文</asp:ListItem>
                                 </asp:DropDownList>
                              </li>
                               <li style="width:232px" > 
                               </li>
                            
                        </ul>
                    </td>
                </tr>
                <tr>
                   <th width="20px"><input  type="checkbox" id="checkAll" onclick="GetAllCheckBox(this)"/></th>
                    <th width="60%">名称</th>
                        <th width="7%">发布</th>
                         <th width="7%">编辑</th>
                          <th width="7%">删除</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RP_con" runat="server">
                <ItemTemplate>
                   <tr>
                    <td style=" width:20px;">
                        <asp:CheckBox ID="CheckBox1_" class="check" runat="server" />
                        <asp:HiddenField ID="HiddenField_" runat="server"  Value='<%# Eval("ID")%>'/>
                    </td>
                    <td>
                      <%#Eval("TypeName")%>
                    </td>                   
                    <td>
                       <a href="Admin_NewsType_Edit.aspx?id=<%#Eval("ID") %>&ispub=true" > <img src="<%#GetPubICO(Eval("ISFabu").ToString())%>" alt="发布" border="0" /></a>
                    </td>
                    <td>
                   
                       <a href="Admin_NewsType_Edit.aspx?id=<%#Eval("ID") %>&ispub=false" > <img  src="../resources/img/edit.gif" alt="编辑" border="0"/></a>
                        
                    </td>
                   <td>
                    <a href="Del.aspx?type=0&id=<%#Eval("ID") %>" onclick="return confirm('您确认要删除吗？')"  > <img  src="../resources/img/cross.gif" alt="删除" border="0"/></a>
                   </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>               
            </tbody>
        </table>           
           </div>
        </div>
    </div>
    </form>
</body>
</html>
