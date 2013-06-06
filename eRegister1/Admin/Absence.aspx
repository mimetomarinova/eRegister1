<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="Absence.aspx.cs" Inherits="eRegister1.Admin.Absence" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style14">
        <tr>
            <td style="text-align: left">
                От:
                <asp:TextBox ID="txtDateFrom" runat="server" Height="22px" Width="62px"></asp:TextBox>
              
                <asp:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    Format="dd.MM.yyyy" TargetControlID="txtDateFrom">
                </asp:CalendarExtender>
              
            </td>
            <td style="text-align: left">
                До:<asp:TextBox ID="txtDateTo" runat="server" Height="20px" Width="58px"></asp:TextBox>
                
                <asp:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    Format="dd.MM.yyyy" TargetControlID="txtDateTo">
                </asp:CalendarExtender>
                
            </td>
            <td style="text-align: left">
                Минимален брой<asp:TextBox ID="txtMinAbsence" runat="server" Height="23px" 
                    Width="66px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="ButtonSearch" runat="server" Style="text-align: left" 
                    Text="Търси" onclick="ButtonSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridViewAbsence" runat="server" AutoGenerateColumns="False" 
                    Width="357px" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Брой отсъствия" DataField="AbsenceNumber" />
                        <asp:BoundField HeaderText="Ученик" DataField="StudentName" />
                        <asp:BoundField HeaderText="Клас" DataField="Class" />
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
            </td>
        </tr>
    </table>
</asp:Content>
