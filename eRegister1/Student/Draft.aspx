<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true"
    CodeBehind="Draft.aspx.cs" Inherits="eRegister1.Student.Draft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Чернови">
        <asp:GridView ID="GridViewDraft" runat="server" AllowPaging="True" CellPadding="4"
            ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridViewDraft_PageIndexChanging"
            PageSize="5" AutoGenerateColumns="False" 
            onselectedindexchanged="GridViewDraft_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="№ на съобщение" HeaderText="№ на съобщение"  
                    HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"  >
                <HeaderStyle CssClass="Hide" />
                <ItemStyle CssClass="Hide" />
                </asp:BoundField>
                <asp:BoundField DataField="Дата" HeaderText="Дата" />
                <asp:BoundField DataField="До" HeaderText="До" />
                <asp:BoundField DataField="Текст" HeaderText="Текст" />
                <asp:CommandField SelectText="избери" ShowSelectButton="True" />
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
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
