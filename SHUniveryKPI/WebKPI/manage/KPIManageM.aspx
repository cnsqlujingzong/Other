<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KPIManageM.aspx.cs" Inherits="KPIManageM" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>考核表详细</title>
    <script src="/js/jquery-1.11.2.js"></script>
    <style>
        .titleBar {
            /**D8F0F8**/
            padding: 15px 10px;
            font-size: 20px;
            background: #205081;
            cursor: pointer;
            margin-bottom: 0px;
            color: #fff;
        }

        .content {
            border: 2px solid #205081;
            padding-left: 15px;
            padding-top:20px;
        }

        .titleYear {
            font-size: 28px;
            font-weight: 600;
        }

        .mainTable td,.mainTable th {
            padding: 5px 10px;
        }

        .itemRow {
            background: #eeeeee;
        }

        .altRow {
            background: #dddddd;
        }
      .button-giant {
    font-size: 15px;
    height: 40px;
    line-height: 40px;
    padding: 0px 10px;
}.button-rounded {
    border-radius: 4px;
}
 .button-royal, .button-royal-flat {
    background-color: #FF4351;
    border-color: #FF4351;
    color: #FFF;
}
 .button {
    font-weight: 300;
    font-size: 16px;
    font-family: "Helvetica Neue Light", "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
    text-decoration: none;
    text-align: center;
    line-height: 40px;
    height: 40px;
    margin: 0;
    display: inline-block;
    appearance: none;
    cursor: pointer;
    border: none;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
    -webkit-transition-property: all;
    transition-property: all;
    -webkit-transition-duration: .3s;
    transition-duration: .3s;
    margin-bottom:5px;
}
    </style>
</head>
<body style="background: #efefef">
    <h2>
        <asp:Label ID="lb_title" runat="server" Text=""></asp:Label></h2>
    <form id="form1" runat="server">
<%--        <a href="Home.aspx" style="display:inline-block; color:#fff; background:#205081; text-decoration:none;padding:5px"><-返回首页</a>--%>
        <div style="padding-top:20px">
            <h3 id="" class="titleBar" href="#tb_dxscx" style="">大学生创新实验项目</h3>
            <div id="tb_dxscx" class="content" style="display:none">
                     
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>项目类别</th>
                                  <th>项目质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>
                                <th>学生列表</th>
                                <th>教分</th>
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_cxsy" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                   <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                            <td><%#Eval("Str2")%></td>
                               <td><%#Eval("Str3")%></td>
                                 <td><%#Eval("Int5")%></td>
                                 <td><%#Eval("Str1")%></td>
                                 <td><%#Eval("text1")%></td>
                                <td></td>
                                          <td><a href="cpage/AddCXSY.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/AddCXSY.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                         <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                   <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                               <td><%#Eval("Str2")%></td>
                               <td><%#Eval("Str3")%></td>
                                 <td><%#Eval("Int5")%></td>
                                 <td><%#Eval("Str1")%></td>
                                 <td><%#Eval("text1")%></td>
                                <td></td>
                                <td><a href="cpage/AddCXSY.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/AddCXSY.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
                 <h3  class="titleBar" href="#TableXKJS" style="">学科竞赛</h3>
                 <div id="TableXKJS" class="content" style="display:none">
             
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>获奖类型</th>
                                   <th>获奖等级</th>
                                    <th>是否挑战杯</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>
                                <th>学生列表</th>
                                <th>教分</th>
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_xkjs" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                   <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                        <td><%#Eval("Str2") %></td>
                                              <td><%#Eval("Str4") %></td>
                               <td><%#Eval("Str3")%></td>
                                 <td><%#Eval("Int5")%></td>
                                 <td><%#Eval("Str1")%></td>
                                 <td><%#Eval("text1")%></td>
                                <td></td>
                                          <td><a href="cpage/XKJS.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/XKJS.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                         <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                   <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                             <td><%#Eval("Str2") %></td>
                                            <td><%#Eval("Str4") %></td>
                               <td><%#Eval("Str3")%></td>
                                 <td><%#Eval("Int5")%></td>
                                 <td><%#Eval("Str1")%></td>
                                 <td><%#Eval("text1")%></td>
                                <td></td>
                                <td><a href="cpage/XKJS.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/XKJS.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>


                 </div>
          <h3  class="titleBar" href="#TableDSZ" style="">本科班导师、励志导师和学术导师</h3>
                 <div id="TableDSZ" class="content" style="display:none">
                         
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_dsz" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/DSZ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/DSZ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/DSZ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/DSZ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>
         <h3  class="titleBar" href="#TableJXGG" style="">教学改革项目，课程建设和获奖项目</h3>
                 <div id="TableJXGG" class="content" style="display:none">
                         
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_jxgg" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/JXGG.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/JXGG.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/JXGG.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/JXGG.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>

                       
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_jxhj" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/JXHJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/JXHJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/JXHJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/JXHJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>

                 
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_jxlw" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/JXLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/JXLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/JXLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/JXLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>
              <h3  class="titleBar" href="#TableKYXM" style="">科研项目</h3>
                 <div id="TableKYXM" class="content" style="display:none">
                 
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月~何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_KYXM" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KYXM.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KYXM.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KYXM.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KYXM.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>
          <h3  class="titleBar" href="#TableKYLW" style="">科研论文</h3>
                 <div id="TableKYLW" class="content" style="display:none">
                   
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_KYLW" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KYLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KYLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KYLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KYLW.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>
      
                  <h3  class="titleBar" href="#TableKYCB" style="">著作出版</h3>
                 <div id="TableKYCB" class="content" style="display:none">
                            
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_KYCB" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KYCB.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KYCB.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KYCB.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KYCB.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>
                  <h3  class="titleBar" href="#TableKJJL" style="">科技奖励</h3>
                 <div id="TableKJJL" class="content" style="display:none">
                      
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_KJJL" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/KJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/KJ.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>

               <h3  class="titleBar" href="#TableZL" style="">获得专利</h3>
                 <div id="TableZL" class="content" style="display:none">
                       
                  <div class="grid" style="padding-bottom:30px">
                    <table border="1" cellpadding="0" cellspacing="0" class="mainTable">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>何年月</th>
                                <th>项目编号</th>
                                <th>项目名称</th>
                                <th>导师类型</th>
                                <th>学年指导数</th>
                                <th>指导质量</th>
                                <th>学生主要院系</th>
                                <th>学生数</th>
                                <th>周期</th>                         
                            
                                  <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_KL" runat="server">
                                <ItemTemplate>
                                    <tr class="itemRow">
                                <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32(Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/ZL.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/ZL.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="altRow">
                                        <td><%#Eval("ID") %></td>
                                <td><%#Eval("Int1")+"年"+ Eval("Int2")+"月~"+Eval("Int3")+"年"+ Eval("Int4")+"月"%></td>
                                <td><%#Eval("ProjectNO")%></td>
                                 <td><%#Eval("ProjectName")%></td>
                                 <td><%#Eval("ProjectType")%></td>
                                 <td><%#Eval("Int5") %></td>
                                  <td><%#Eval("Str4") %></td>
                                 <td><%#Eval("Str3")%></td>
                                 <td><%#Convert.ToInt32( Eval("float2"))%></td>
                                 <td><%#Eval("Str1")%></td>    
                                 <td><a href="cpage/ZL.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=edit">编辑</a> <a href="cpage/ZL.aspx?id=<%#Tid%>&&cxsyid=<%#Eval("ID") %>&&op=del" onclick="return confirm('确定要删除')">删除</a></td>
                                    
                                          </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
                 </div>
      
              </div>
    </form>
</body>
</html>
<script>
    $(function () {
        $(".titleBar").click(function () {
            var id = $(this).attr("href");
            $(id).slideToggle();
        });

        var d = new Date()
        $("#list_year").html(d.getFullYear() + "年度");
    })
</script>
