<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true"
    CodeBehind="SchoolReport.aspx.cs" Inherits="eRegister1.Student.SchoolReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <div >
        <table style="width: 100%; vertical-align: top;">
            <tr>
                <td colspan="2">
                    <h3 style="font-family: Arial, Helvetica, sans-serif; color: #990000">
                        <span style="font-weight: normal">Текущи оценки за:
                </span>
                    </h3>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; width: 228px;">
                    <span style="font-family: Arial, Helvetica, sans-serif; color: #990000">срок</span>&nbsp;
                    <asp:DropDownList ID="DropDownListTerm" runat="server" OnSelectedIndexChanged="DropDownListTerm_SelectedIndexChanged"
                        AutoPostBack="True" Width="100px">
                    </asp:DropDownList>
                </td>
                <td>
                    <span style="font-family: Arial, Helvetica, sans-serif; color: #990000">по предмет:</span>
                    <asp:DropDownList ID="DropDownListSubject" runat="server" Height="16px" Width="200px"
                        OnSelectedIndexChanged="DropDownListSubject_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <span style="color: #990000; font-family: Arial, Helvetica, sans-serif">Среден успех:</span>
                    <asp:TextBox ID="txtAvgSubjectScore" runat="server" ReadOnly="True" 
                        Width="30px" ForeColor="#CC0000" 
                       ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridViewScore" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None">
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
            </tr>
            <tr>
                <td colspan="2">
                    <h3 style="font-family: Arial, Helvetica, sans-serif; color: #990000">
                        <span style="font-weight: normal">Срочни и годишни оценки
                </span>
                    </h3>
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="center">
                    <asp:GridView ID="GridViewYearScore" runat="server" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        style="text-align: center">
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
            </tr>
            <tr>
                <td style="width: 228px">
                    <span style="font-family: Arial, Helvetica, sans-serif; color: #990000">Среден успех за:</span>
                    <asp:DropDownList ID="DropDownListYearScore" runat="server" Width="100px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DropDownListYearScore_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="text-align: left">
                    <span style="font-family: Arial, Helvetica, sans-serif; color: #990000">e:<strong>
                    </strong></span>
                    <asp:TextBox ID="txtYearScore" runat="server" ReadOnly="True" Width="30px" 
                        ForeColor="#CC0000"></asp:TextBox>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
