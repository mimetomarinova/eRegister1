<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true"
    CodeBehind="Massages.aspx.cs" Inherits="eRegister1.Student.Massages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div style="text-align: left">
            <asp:Label ID="Label1" runat="server" Text="Изберете тип съобщение: "></asp:Label>
            <asp:DropDownList ID="DropDownListMessageType" runat="server" Height="16px" Width="145px"
                AutoPostBack="True" OnSelectedIndexChanged="DropDownListMessageType_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <br />
        <br />
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
</asp:Content>
