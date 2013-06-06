<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="ClassDevisionDetails.aspx.cs" Inherits="eRegister1.Admin.ClassDevisionDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style14">
        <tr>
            <td style="text-decoration: underline; text-align: left; width: 105px;">
                Класове:
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
                <asp:GridView ID="GridViewClassList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridViewClassList_PageIndexChanging"
                    OnRowCancelingEdit="GridViewClassList_RowCancelingEdit" OnRowEditing="GridViewClassList_RowEditing"
                    OnRowUpdating="GridViewClassList_RowUpdating" PageSize="14">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="№ в системата"  HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Height="21px" ReadOnly="True" 
                                    Text='<%# Bind("StudentID") %>' Width="46px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="№ в класа">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("[Номер в класа]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("[Номер в класа]") %>'></asp:TextBox>
                               
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ученик">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Ученик") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Ученик") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Дата на промяна">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("[Дата на промяна]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" 
                                    Text='<%# Bind("[Дата на промяна]") %>'></asp:TextBox>
                            
                                <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                    Format="dd.MM.yyyy" TargetControlID="TextBox1">
                                </asp:CalendarExtender>
                            
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="От клас">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("[ClassDevisionDetailsID]") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownListAllClasses" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="Class" 
                                    DataValueField="ClassDevisionDetailsID">
                                </asp:DropDownList>
                            </EditItemTemplate>
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
