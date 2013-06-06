<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="Massages.aspx.cs" Inherits="eRegister1.Admin.Massages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div>
            <asp:GridView ID="GridViewMessages" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" Width="519px" onselectedindexchanged="GridViewMessages_SelectedIndexChanged" 
              CommandName="Select" AllowPaging="True" AutoGenerateColumns="False" 
                onpageindexchanging="GridViewMessages_PageIndexChanging" >
                <AlternatingRowStyle BackColor="White" />
                
                <Columns>
                    <asp:BoundField DataField="№ на съобщение" HeaderText="№ на съобщение" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide"  />
                    <asp:BoundField DataField="Дата" HeaderText="Дата" />
                    <asp:BoundField DataField="От" HeaderText="От" />
                    <asp:BoundField DataField="Текст" HeaderText="Текст" />
                    <asp:BoundField DataField="Тип съобщение" HeaderText="Тип съобщение" />
                    <asp:CommandField SelectText="отговор" ShowSelectButton="True" />
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
        </div>
    </asp:Panel>
    <asp:Label ID="lblMessage" runat="server" style="color: #990000"></asp:Label>
</asp:Content>
