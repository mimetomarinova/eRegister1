<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="Divisions.aspx.cs" Inherits="eRegister1.Admin.Divisions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
<table class="style14">
        <tr>
            <td style="text-align: left">
                <asp:GridView ID="GridViewDivision" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="DivisionID" 
                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                    style="text-align: right">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField CancelText="Отказ" DeleteText="Изтрий" EditText="Промени" 
                            ShowEditButton="True" UpdateText="Запис" />
                        <asp:BoundField DataField="Division" HeaderText="Паралелка" 
                            SortExpression="Division" />
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
                    SelectCommand="SELECT * FROM [Divisions]" 
                    UpdateCommand="UPDATE [Divisions] SET [Division] = @Division WHERE [DivisionID] = @original_DivisionID AND [Division] = @original_Division">
                   
                   
                    <UpdateParameters>
                        <asp:Parameter Name="Division" Type="String" />
                        <asp:Parameter Name="original_DivisionID" Type="Byte" />
                        <asp:Parameter Name="original_Division" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
            <td align="left" style="vertical-align: top">
               Въведете паралелка(А,Б...):<asp:TextBox ID="TextBoxDivision" runat="server" 
                    Width="30px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="TextBoxDivision"
                    Display="Dynamic" ErrorMessage="Въведете буква!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Само една буква!" ForeColor="Red" 
                    ValidationExpression="^[a-z A-Z]{1}" ControlToValidate="TextBoxDivision"></asp:RegularExpressionValidator>
                <asp:Button ID="buttonSave" runat="server" Text="Запис" 
                    onclick="buttonSave_Click" />
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
