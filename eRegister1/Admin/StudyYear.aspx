<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="StudyYear.aspx.cs" Inherits="eRegister1.Admin.StudyYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <div align="center">
   
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" 
        AutoGenerateRows="False" CellPadding="4" 
        DataKeyNames="StudyYearID" DataSourceID="SqlDataSource1" ForeColor="#333333" 
        GridLines="None" AllowPaging="True" HeaderText="Учебна година">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="StudyYear" HeaderText="Учебна година (2000/2001)" 
                SortExpression="StudyYear" />
            <asp:CommandField ShowInsertButton="True" CancelText="Отказ" InsertText="Запис" 
                NewText="Нов запис" />
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"  
        InsertCommand="BEGIN TRY IF @StudyYear IS NULL BEGIN RAISERROR('Не може да се добави училище без да е оказано неговото име.',18,1)  END INSERT INTO [StudyYear] ([StudyYear]) VALUES (@StudyYear) END TRY BEGIN CATCH IF @@Trancount > 0 ROLLBACK END CATCH " 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [StudyYear]" ProviderName="<%$ ConnectionStrings:eRegisterConnectionString.ProviderName %>" 
        >
        <InsertParameters>
            <asp:Parameter Name="StudyYear" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
     </div>
</asp:Content>
