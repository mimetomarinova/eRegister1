<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true" CodeBehind="Absences.aspx.cs" Inherits="eRegister1.Student.Absences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <h3 style="font-family: Arial, Helvetica, sans-serif; color: #990000">
                        Брой отсъствия</h3>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <span style="font-family: Arial, Helvetica, sans-serif; color: #990000"><em>
                    Неизвинени</em></span>:
                    <asp:TextBox ID="TextBoxUnexcused" runat="server" Height="21px" 
                        ReadOnly="True" Width="30px"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <span style="color: #990000; font-family: Arial, Helvetica, sans-serif"><em>
                    Извинени</em></span>:
                    <asp:TextBox ID="TextBoxExcused" runat="server" Height="21px" ReadOnly="True" 
                        Width="30px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 279px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; width: 279px">
                    <asp:GridView ID="GridViewAbsences" runat="server" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
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
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
