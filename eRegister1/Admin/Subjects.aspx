<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="Subjects.aspx.cs" Inherits="eRegister1.Admin.Subjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Предмети">
    <div style="text-align: left" >
    <asp:Label ID="Label1" runat="server" Text="Въведете предмет:"></asp:Label>
        <asp:TextBox ID="TextBoxSubject" runat="server"  Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Въведете предмет!" ControlToValidate="TextBoxSubject" 
            ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:Button ID="ButtonSave" runat="server" Text="Запис" Font-Bold="True" 
            Width="90px" onclick="ButtonSave_Click" />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label><br /><br /><br />
        <asp:GridView ID="GridViewSubject" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="393px" DataKeyNames="SubjectID" 
            DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField CancelText="Отказ" EditText="Промени" ShowEditButton="True" 
                    UpdateText="Запис" />
                <asp:BoundField DataField="Name" HeaderText="Предмет" SortExpression="Name" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"          
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [Subjects] order by Name" 
            UpdateCommand="UPDATE [Subjects] SET [Name] = @Name WHERE [SubjectID] = @original_SubjectID AND [Name] = @original_Name">
            
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="original_SubjectID" Type="Int16" />
                <asp:Parameter Name="original_Name" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    
    </asp:Panel>
</asp:Content>
