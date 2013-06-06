<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="SuccessStudent.aspx.cs" Inherits="eRegister1.Admin.SuccessStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
<table class="style14">
        <tr>
            <td style="text-decoration: underline; text-align: left; width: 105px;">
                <span style="color: #990000">Класове</span>:
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 105px" class="style12">
                <asp:GridView ID="GridViewAllClasses" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="False" AllowPaging="True"
                    OnPageIndexChanging="GridViewAllClasses_PageIndexChanging" PageSize="14">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonAllClasses" runat="server" Text='<%# Eval("Class")%>'
                                    OnCommand="Get_Classes" CommandName='<%#Eval("ClassDevisionDetailsID")%>' Font-Bold="False"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
            <td>
                &nbsp;
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-left: 0px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Клас:" />
                        <asp:BoundField HeaderText="№ в класа" />
                        <asp:BoundField HeaderText="Ученик" />
                        <asp:BoundField HeaderText="Първи срок" />
                        <asp:BoundField HeaderText="Втори срок" />
                        <asp:BoundField HeaderText="Годишна" />
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
        <tr>
            <td style="text-align: left; width: 105px">
                <asp:Label ID="lblError" runat="server" style="color: #990000"></asp:Label>
            </td>
            <td>
                &nbsp;
                </td>
        </tr>
        <tr>
            <td style="width: 105px" class="style12">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
