<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="EditTeachers.aspx.cs" Inherits="eRegister1.Admin.EditTeachers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
<table class="style14">
        <tr>
            <td style="text-decoration: underline; text-align: left; width: 105px;">
                Учители:
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 105px" class="style12">
                <asp:GridView ID="GridViewAllTeachers" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="False" AllowPaging="True"
                    OnPageIndexChanging="GridViewAllTeachers_PageIndexChanging" PageSize="14" 
                    Width="121px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonAllTeachers" runat="server" Text='<%# Eval("[Name]")%>'
                                    OnCommand="Get_Teachers" CommandName='<%#Eval("[ActorID]")%>' 
                                    Font-Bold="False"></asp:LinkButton>
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
                <asp:DetailsView ID="DetailsViewTeacherInfo" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Height="50px" Width="336px" 
                    AutoGenerateRows="False" onitemupdating="DetailsViewTeacherInfo_ItemUpdating" 
                    onmodechanging="DetailsViewTeacherInfo_ModeChanging" 
                    onpageindexchanging="DetailsViewTeacherInfo_PageIndexChanging" 
                    style="text-align: left">
                    <AlternatingRowStyle BackColor="White" />
                    <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
                    <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
                    <Fields>
                        <asp:TemplateField HeaderText="Име">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Име") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Име") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Име") %>'></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Презиме">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Презиме") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMName" runat="server" Text='<%# Bind("Презиме") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Презиме") %>'></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Фамилия">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Фамилия") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLName" runat="server" Text='<%# Bind("Фамилия") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Фамилия") %>'></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="e-mail">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("[e-mail]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("[e-mail]") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("[e-mail]") %>'></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Телефон">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Телефон") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("Телефон") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Телефон") %>'></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Класен е на:">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("[Класен е на:]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownListClass" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="Class" 
                                    DataValueField="ClassDevisionDetailsID" Height="19px" Width="107px">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>" 
                                    SelectCommand="sp_GetAllClasses" SelectCommandType="StoredProcedure">
                                </asp:SqlDataSource>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("[Класен е на:]") %>'></asp:TextBox>
                            </InsertItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField CancelText="Отказ" EditText="Редакция" ShowEditButton="True" 
                            UpdateText="Запис" />
                    </Fields>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                </asp:DetailsView>
                </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 105px">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                    SelectCommand="sp_GetAllClasses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
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
