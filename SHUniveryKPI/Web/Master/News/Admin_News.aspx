<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_News.aspx.cs" Inherits="Master_News_Admin_News" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文章管理</title>
    <link  href="../resources/css/global.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../resources/js/Admin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div style=" margin-left:6px; margin-top:6px;">
        <div style=" background-color:#DADFEF; color:#593D00; font-size:9pt; padding:5px 3px; border:1px solid gray;">
          【当前位置】:&nbsp;&nbsp;&nbsp;文章管理
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
                            <li ><a class="iconfl" href="Admin_NewsType.aspx" target="mainFrame">管理分类</a></li>
                            <li > 
                                <asp:HyperLink ID="HY_AddNews" runat="server" class="iconf2">添加文章</asp:HyperLink></li>
                            <li >
                                <asp:LinkButton ID="LB_Del" runat="server" class="iconf3" 
                                    onclick="LB_Del_Click">删除文章</asp:LinkButton></li>
                             <li style="width:100px">                          
                                 <asp:DropDownList ID="DD_Type" runat="server" border="1px" AutoPostBack="True" 
                                     onselectedindexchanged="DD_Type_SelectedIndexChanged">
                                 </asp:DropDownList>                            
                             </li>
                              <li style="width:150px; padding-left:20px;">
                                 <asp:DropDownList ID="DL_lang" runat="server" AutoPostBack="True" 
                                      border="1px" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                     <asp:ListItem Value="cn">简体中文</asp:ListItem>
                                     <asp:ListItem Value="en">英文</asp:ListItem>
                                 </asp:DropDownList>
                              </li>
                               <li style="width:220px;" > 
                                   <asp:TextBox ID="txtCondition" runat="server" border="1px" Width="168px" 
                                       Height="15px"></asp:TextBox>
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
                   <th>
                       <input id="checkAll" onclick="GetAllCheckBox(this)" type="checkbox" /></th>
                    <th width="35%">标题</th>
                     <th width="10%">作者</th>
                      <th width="15%">分类</th>
                       <th width="7%">顺序</th>
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
                      <%#Eval("Title")%>
                    </td>
                   <td>
                    <%#Eval("Author")%>
                   </td>
                    <td>
                  <%#GetNewsType(Eval("News_Type").ToString()) %>  
                   </td>
                     <td>
                         <asp:TextBox ID="txtOrderBy" runat="server" Text='<%#Eval("OrderBy")%>' Width="50px"></asp:TextBox>
                   </td>
                    <td>
                       <a href="Admin_News_Add.aspx?cid=<%#Eval("ID") %>&con=ispub" > <img src="<%#GetPubICO(Eval("ISPublish").ToString())%>" alt="发布" border="0" /></a>
                    </td>
                    <td>
                   
                       <a href="Admin_News_Add.aspx?cid=<%#Eval("ID") %>&con=edit" > <img  src="../resources/img/edit.gif" alt="编辑" border="0"/></a>
                        
                    </td>
                   <td>
                    <a href="Admin_News_Add.aspx?cid=<%#Eval("ID")%>&con=del" onclick="return confirm('您确定要删除？')"> <img  src="../resources/img/cross.gif" alt="删除" border="0"/></a>
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
