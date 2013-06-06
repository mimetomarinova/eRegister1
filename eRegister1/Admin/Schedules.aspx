<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="Schedules.aspx.cs" Inherits="eRegister1.Admin.Schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <table class="style14">
        <tr>
            <td colspan="3">
                <h3 style="color: #990000">
                    Редакция на програмата
                </h3>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 89px;">
                <span style="color: #990000"><strong>клас:</strong></span>
                <asp:DropDownList ID="DropDownListClasses" runat="server">
                </asp:DropDownList>
            </td>
            <td style="color: #990000; text-align: left; width: 115px">
                <strong>срок: </strong>
                <asp:DropDownList ID="DropDownListTerm" runat="server">
                </asp:DropDownList>
            </td>
            <td style="color: #990000; text-align: left; width: 264px;">
                <strong>ден от седмицата:</strong><asp:DropDownList ID="DropDownListWeekDay" runat="server"
                    Width="155px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lblMessage" runat="server" Style="color: #CC0000"></asp:Label>
                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Style="color: #990000;
                    font-weight: 700" Text="Търсене" Width="94px" />
            </td>
        </tr>
        <tr>
            <td class="style12" style="width: 89px">
                &nbsp;
            </td>
            <td style="width: 115px" class="style12">
                &nbsp;
            </td>
            <td style="width: 264px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridViewSchedules" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AutoGenerateColumns="False" OnRowCancelingEdit="GridViewSchedules_RowCancelingEdit"
                    OnRowEditing="GridViewSchedules_RowEditing" OnRowUpdating="GridViewSchedules_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("[№ в системата]") %>' ></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("[№ в системата]") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Часове">
                         <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("[Часове]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Часове]") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Предмети">
                           
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownSubject" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="SubjectID" 
                                    Width="200px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>" 
                                    SelectCommand="SELECT * FROM [Subjects]"></asp:SqlDataSource>
                            </EditItemTemplate>
                           
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("[Предмети]") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="Отказ" EditText="Редактирай" ShowEditButton="True"
                            UpdateText="Запис" />
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
