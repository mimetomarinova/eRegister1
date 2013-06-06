<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="eRegister1.Admin.News" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="font-family: Arial, Helvetica, sans-serif">
        <h4 style="color: #990000">
            Въвеждане на новини</h4>
    </div>
    <asp:DetailsView ID="DetailsViewNews" runat="server" Height="170px" Width="475px" 
        AutoGenerateRows="False" CellPadding="4" DataKeyNames="NewsID" 
        DataSourceID="SqlDataSource1" DefaultMode="Insert" ForeColor="#333333" 
        GridLines="None" style="text-align: left">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="NewsID" HeaderText="NewsID" InsertVisible="False" 
                ReadOnly="True" SortExpression="NewsID" />
            <asp:TemplateField HeaderText="Заглавие" SortExpression="Title">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBoxTitle" runat="server" MaxLength="200" 
                        Text='<%# Bind("Title") %>' Width="500px"></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Описание" SortExpression="Description">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescriptionEdit" runat="server" Height="146px" 
                        Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" Height="146px" 
                        Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:CommandField CancelText="Отказ" InsertText="Въвеждане" NewText="Въвеждане" 
                ShowInsertButton="True" />
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>" 
        
        InsertCommand="INSERT INTO [News] ([Title], [Description], [DatePublication]) VALUES (@Title, @Description, GetDate())" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT [NewsID], [Title], [Description], [DatePublication] FROM [News]" 
        UpdateCommand="UPDATE [News] SET [Title] = @Title, [Description] = @Description, [DatePublication] = @DatePublication WHERE [NewsID] = @original_NewsID AND [Title] = @original_Title AND [Description] = @original_Description AND [DatePublication] = @original_DatePublication">
      
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="DatePublication" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="DatePublication" Type="DateTime" />
            <asp:Parameter Name="original_NewsID" Type="Int32" />
            <asp:Parameter Name="original_Title" Type="String" />
            <asp:Parameter Name="original_Description" Type="String" />
            <asp:Parameter Name="original_DatePublication" Type="DateTime" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
