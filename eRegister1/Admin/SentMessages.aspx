<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="SentMessages.aspx.cs" Inherits="eRegister1.Admin.SentMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Изпратени съобщения">
        <asp:GridView ID="GridViewSentMessage" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AllowPaging="True" OnPageIndexChanging="GridViewSentMessage_PageIndexChanging"
            PageSize="5">
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
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
