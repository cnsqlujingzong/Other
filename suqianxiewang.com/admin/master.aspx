<%@ Page Language="C#" AutoEventWireup="true" CodeFile="master.aspx.cs" Inherits="admin_master" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="30px" Width="104px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>全部</asp:ListItem>
            <asp:ListItem Value="1">已发货</asp:ListItem>
            <asp:ListItem Value="0">未发货</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="序号" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="OrderID" HeaderText="订单号" SortExpression="OrderID" />
                <asp:BoundField DataField="CardNum" HeaderText="券号" SortExpression="CardNum" />
                <asp:BoundField DataField="DName" HeaderText="收货人" SortExpression="DName" />
                <asp:BoundField DataField="Mobile" HeaderText="手机号" SortExpression="Mobile" />
                <asp:BoundField DataField="Sheng" HeaderText="省份" SortExpression="Sheng" />
                <asp:BoundField DataField="Shi" HeaderText="城市" SortExpression="Shi" />
                <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                <asp:TemplateField HeaderText="订单状态" SortExpression="OrderSate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OrderSate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("OrderSate").ToString()=="0"?"未发货":"已发货" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SendCory" HeaderText="物流公司" SortExpression="SendCory" />
                <asp:BoundField DataField="SendNum" HeaderText="快递单号" SortExpression="SendNum" />
                <asp:BoundField DataField="CreatTime" HeaderText="下单时间" SortExpression="CreatTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:qds164505679_dbConnectionString %>" DeleteCommand="DELETE FROM [Order] WHERE [ID] = @original_ID AND (([OrderID] = @original_OrderID) OR ([OrderID] IS NULL AND @original_OrderID IS NULL)) AND (([CardNum] = @original_CardNum) OR ([CardNum] IS NULL AND @original_CardNum IS NULL)) AND (([OrderSate] = @original_OrderSate) OR ([OrderSate] IS NULL AND @original_OrderSate IS NULL)) AND (([Mobile] = @original_Mobile) OR ([Mobile] IS NULL AND @original_Mobile IS NULL)) AND (([DName] = @original_DName) OR ([DName] IS NULL AND @original_DName IS NULL)) AND (([Sheng] = @original_Sheng) OR ([Sheng] IS NULL AND @original_Sheng IS NULL)) AND (([Shi] = @original_Shi) OR ([Shi] IS NULL AND @original_Shi IS NULL)) AND (([Address] = @original_Address) OR ([Address] IS NULL AND @original_Address IS NULL)) AND (([SendCory] = @original_SendCory) OR ([SendCory] IS NULL AND @original_SendCory IS NULL)) AND (([SendNum] = @original_SendNum) OR ([SendNum] IS NULL AND @original_SendNum IS NULL))" InsertCommand="INSERT INTO [Order] ([OrderID], [CardNum], [OrderSate], [Mobile], [DName], [Sheng], [Shi], [Address], [SendCory], [SendNum]) VALUES (@OrderID, @CardNum, @OrderSate, @Mobile, @DName, @Sheng, @Shi, @Address, @SendCory, @SendNum)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Order]" UpdateCommand="UPDATE [Order] SET [OrderID] = @OrderID, [CardNum] = @CardNum, [OrderSate] = @OrderSate, [Mobile] = @Mobile, [DName] = @DName, [Sheng] = @Sheng, [Shi] = @Shi, [Address] = @Address, [SendCory] = @SendCory, [SendNum] = @SendNum WHERE [ID] = @original_ID AND (([OrderID] = @original_OrderID) OR ([OrderID] IS NULL AND @original_OrderID IS NULL)) AND (([CardNum] = @original_CardNum) OR ([CardNum] IS NULL AND @original_CardNum IS NULL)) AND (([OrderSate] = @original_OrderSate) OR ([OrderSate] IS NULL AND @original_OrderSate IS NULL)) AND (([Mobile] = @original_Mobile) OR ([Mobile] IS NULL AND @original_Mobile IS NULL)) AND (([DName] = @original_DName) OR ([DName] IS NULL AND @original_DName IS NULL)) AND (([Sheng] = @original_Sheng) OR ([Sheng] IS NULL AND @original_Sheng IS NULL)) AND (([Shi] = @original_Shi) OR ([Shi] IS NULL AND @original_Shi IS NULL)) AND (([Address] = @original_Address) OR ([Address] IS NULL AND @original_Address IS NULL)) AND (([SendCory] = @original_SendCory) OR ([SendCory] IS NULL AND @original_SendCory IS NULL)) AND (([SendNum] = @original_SendNum) OR ([SendNum] IS NULL AND @original_SendNum IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_OrderID" Type="String" />
                <asp:Parameter Name="original_CardNum" Type="String" />
                <asp:Parameter Name="original_OrderSate" Type="Int32" />
                <asp:Parameter Name="original_Mobile" Type="String" />
                <asp:Parameter Name="original_DName" Type="String" />
                <asp:Parameter Name="original_Sheng" Type="String" />
                <asp:Parameter Name="original_Shi" Type="String" />
                <asp:Parameter Name="original_Address" Type="String" />
                <asp:Parameter Name="original_SendCory" Type="String" />
                <asp:Parameter Name="original_SendNum" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="OrderID" Type="String" />
                <asp:Parameter Name="CardNum" Type="String" />
                <asp:Parameter Name="OrderSate" Type="Int32" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="DName" Type="String" />
                <asp:Parameter Name="Sheng" Type="String" />
                <asp:Parameter Name="Shi" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="SendCory" Type="String" />
                <asp:Parameter Name="SendNum" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="OrderID" Type="String" />
                <asp:Parameter Name="CardNum" Type="String" />
                <asp:Parameter Name="OrderSate" Type="Int32" />
                <asp:Parameter Name="Mobile" Type="String" />
                <asp:Parameter Name="DName" Type="String" />
                <asp:Parameter Name="Sheng" Type="String" />
                <asp:Parameter Name="Shi" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="SendCory" Type="String" />
                <asp:Parameter Name="SendNum" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_OrderID" Type="String" />
                <asp:Parameter Name="original_CardNum" Type="String" />
                <asp:Parameter Name="original_OrderSate" Type="Int32" />
                <asp:Parameter Name="original_Mobile" Type="String" />
                <asp:Parameter Name="original_DName" Type="String" />
                <asp:Parameter Name="original_Sheng" Type="String" />
                <asp:Parameter Name="original_Shi" Type="String" />
                <asp:Parameter Name="original_Address" Type="String" />
                <asp:Parameter Name="original_SendCory" Type="String" />
                <asp:Parameter Name="original_SendNum" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
