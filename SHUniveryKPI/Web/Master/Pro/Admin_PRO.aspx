<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_PRO.aspx.cs" Inherits="Master_Pro_Admin_PRO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品管理</title>
    <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../resources/js/Admin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;产品管理
        </div>
          <div style=" background-color:#DADFEF; padding:5px 15px; border:1px solid gray; margin-top:10px;">
          <!--- <img  src="../resources/img/position.gif"/><span style=" color:#C38500;font-size:10pt; margin-left:15px;">新闻分类管理</span>---->
           <div style=" padding:10px 15px;" class="tahead">
             <table width="90%" cellpadding="0" cellspacing="0" style="border: 1px solid #99BBE8"
            align="center">
            <thead>
                <tr >
                    <td colspan="8" style=" vertical-align:bottom;" >
                        <ul style="margin-left: 15px; padding-top:20px;">
                            <li ><a class="iconfl" href="ProsTypeAdmin.aspx" target="mainFrame">管理分类</a></li>
                            <li > 
                                <asp:HyperLink ID="HY_AddPros" runat="server" class="iconf2" Width="58px">添加产品</asp:HyperLink></li>
                            <li >
                                <asp:LinkButton ID="LB_Del" runat="server" class="iconf3" 
                                    onclick="LB_Del_Click" OnClientClick="return confirm('您确认要删除吗？')">删除所选</asp:LinkButton></li>
                             <li style=" width:auto;">
                          
                                 <asp:DropDownList ID="DD_Type" runat="server" border="1px" AutoPostBack="True" 
                                     onselectedindexchanged="DD_Type_SelectedIndexChanged">
                                 </asp:DropDownList>
                            
                             </li>
                              <li>
                                 <asp:DropDownList ID="DL_lang" runat="server" AutoPostBack="True" 
                                      border="1px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                      style="height: 21px">
                                     <asp:ListItem Value="cn">简体中文</asp:ListItem>
                                     <asp:ListItem Value="en">英文</asp:ListItem>
                                 </asp:DropDownList>
                              </li>
                               <li style="width:220px" > 
                                   <asp:TextBox ID="txtCondition" runat="server" border="1px" Width="168px"></asp:TextBox>
                                   <asp:ImageButton ID="ImageButton1" runat="server" 
                                       ImageUrl="../resources/img/view.png" onclick="ImageButton1_Click"  />
                               </li>
                               <li>
                                   <asp:Button ID="txtOrderBy" runat="server" Text="保存顺序" onclick="OrderBy_Click" />
                               </li>
                            
                        </ul>
                    </td>
                </tr>
                <tr>
                   <th class="style1">
                       <input id="checkAll" onclick="GetAllCheckBox(this)" type="checkbox" /></th>
                    <th width="35%">名称</th>
                      <th width="15%">分类</th>
                       <th width="7%">顺序</th>
                        <th width="7%">状态</th>
                         <th class="style2">发表日期</th>
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
                      <%#Eval("PName")%>
                    </td>
                    <td>
                  <%#GetProTypeName(Eval("PType").ToString())%>  
                   </td>
                     <td>
                         <asp:TextBox ID="txtOrderBy" runat="server" Text='<%#Eval("OrderBy")%>' Width="50px"></asp:TextBox>
                   </td>
                    <td>
                       <a href="ProsManage.aspx?cid=<%#Eval("ID") %>&con=ispub&lang=<%#Eval("Language") %>" > <img src="<%#GetPubICO(Eval("ISPub").ToString())%>" alt="发布" border="0" /></a>
                    </td>
                    <td style=" width:10%;">
                    <%# string.Format("{0:yyyy-MM-dd HH-mm-ss}", Eval("PubDate"))%>
                    </td>
                    <td>
                       <a href="ProsManage.aspx?cid=<%#Eval("ID") %>&con=edit&lang=<%#Eval("Language") %>" > <img  src="../resources/img/edit.gif" alt="编辑" border="0"/></a>
                    </td>
                   <td>
                    <a href="ProsManage.aspx?cid=<%#Eval("ID")%>&con=del" onclick="return confirm('您确认要删除吗？')" > <img  src="../resources/img/cross.gif" alt="删除" border="0"/></a>
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
