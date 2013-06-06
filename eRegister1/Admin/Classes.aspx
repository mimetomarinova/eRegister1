<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="eRegister1.Admin.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <table class="style14">
        <tr>
            <td style="text-align: left">
                <asp:GridView ID="GridViewClasses" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="ClassID" 
                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                    style="text-align: right">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField CancelText="Отказ" EditText="Промени" ShowEditButton="True" 
                            UpdateText="Запис" />
                        <asp:BoundField DataField="Class" HeaderText="Клас" SortExpression="Class" />
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
                    SelectCommand="SELECT * FROM [Classes]" 
                    UpdateCommand="UPDATE [Classes] SET [Class] = @Class WHERE [ClassID] = @original_ClassID AND [Class] = @original_Class">
                    
                   
                    <UpdateParameters>
                        <asp:Parameter Name="Class" Type="Int32" />
                        <asp:Parameter Name="original_ClassID" Type="Int32" />
                        <asp:Parameter Name="original_Class" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
            <td align="left" style="vertical-align: top">
               Въведете номер на класа:<asp:TextBox ID="TextBoxClasses" runat="server" 
                    Width="30px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="TextBoxClasses"
                    Display="Dynamic" ErrorMessage="Въведете число!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Само числа!" ForeColor="Red" ValidationExpression="\d+" ControlToValidate="TextBoxClasses"></asp:RegularExpressionValidator>
                <asp:Button ID="buttonSave" runat="server" Text="Запис" 
                    onclick="buttonSave_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
            <td>
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
