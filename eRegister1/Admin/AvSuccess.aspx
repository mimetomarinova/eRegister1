<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="AvSuccess.aspx.cs" Inherits="eRegister1.Admin.AvSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <table class="style14">
        <tr>
            <td colspan="2" style="color: #990000">
                <h3>
                    <span style="font-weight: normal; font-family: Arial, Helvetica, sans-serif">
                    <strong>Среден успех за учебната
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        DataSourceID="SqlDataSource1" DataTextField="StudyYear" 
                        DataValueField="StudyYearID" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    година:</strong></span></h3>
            </td>
        </tr>
        <tr>
            <td class="style12" style="width: 105px">
                на училището:<asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtAvgSchoolScore" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style12" style="width: 105px">
                по предмети:</td>
            <td>
                <asp:GridView ID="GridViewAvgsubjectScore" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" 
                    onpageindexchanging="GridViewAvgsubjectScore_PageIndexChanging" PageSize="5" 
                    Width="303px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Subject" HeaderText="Предмет" />
                        <asp:BoundField DataField="ScoreNum" HeaderText="Оценка" />
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
            <td class="style12" style="width: 105px">
                по класове:</td>
            <td>
                <asp:GridView ID="GridViewAvgClassScore" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" onpageindexchanging="GridViewAvgClassScore_PageIndexChanging" 
                    PageSize="5" Width="301px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Class" HeaderText="Клас" />
                        <asp:BoundField DataField="AVGScore" HeaderText="Оценка" />
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
            <td class="style12" style="width: 105px">
                <span style="font-weight: normal; font-family: Arial, Helvetica, sans-serif">
                <strong>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>" 
                    SelectCommand="SELECT * FROM [StudyYear]"></asp:SqlDataSource>
                </strong></span>
            </td>
            <td>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
