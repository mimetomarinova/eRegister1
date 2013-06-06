<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="eRegister1.Admin.Profil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
<asp:Panel ID="Panel1" runat="server" GroupingText="Профил(с изучаване на чужд език - Англиийски)">
    <div style="text-align: left" >
        <asp:Label ID="Label1" runat="server" Text="Въведете профил:"></asp:Label>
        <asp:TextBox ID="TextBoxProfil" runat="server"  Width="250px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Въведете профил!" ControlToValidate="TextBoxProfil" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:Button ID="ButtonSave" runat="server" Text="Запис" Font-Bold="True" 
            Width="90px" onclick="ButtonSave_Click" />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label><br /><br /><br />
        <asp:GridView ID="GridViewProfil" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="499px" DataKeyNames="IDProfil">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField CancelText="Отказ" EditText="Промени" ShowEditButton="True" 
                    UpdateText="Запис" />
                <asp:BoundField DataField="Profil" HeaderText="Профил" 
                    SortExpression="Profil" />
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
            SelectCommand="SELECT * FROM [Profil]" 
            UpdateCommand="UPDATE [Profil] SET [Profil] = @Profil WHERE [IDProfil] = @original_IDProfil AND [Profil] = @original_Profil">
            
          
            <UpdateParameters>
                <asp:Parameter Name="Profil" Type="String" />
                <asp:Parameter Name="original_IDProfil" Type="Int32" />
                <asp:Parameter Name="original_Profil" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    
    </asp:Panel>
</asp:Content>
