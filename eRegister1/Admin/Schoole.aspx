<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="Schoole.aspx.cs" Inherits="eRegister1.Admin.Schoole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <div align="center">
        <asp:FormView ID="FormViewSchoole" runat="server" CellPadding="4" ForeColor="#333333"
            HeaderText="Информация за училището" DefaultMode="Insert">
            <EditItemTemplate>
                <table class="style14">
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Училище:
                        </td>
                        <td style="text-align: right">
                            <asp:DropDownList ID="DropDownSchools" runat="server" Width="300px"  
                                 >
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Град/Село:
                        </td>
                        <td style="text-align: right">
                            <asp:DropDownList ID="DropDownList1" runat="server"
                                DataSourceID="SqlDataSource1" DataTextField="Name" 
                                DataValueField="CityVillageID" Width="300px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>" 
                                SelectCommand="SELECT [CityVillageID], [Name] FROM [CityVillage]">
                            </asp:SqlDataSource>
                            
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Адрес:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtAddress" runat="server" Width="300px" ></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Мисия:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtMission" runat="server" Height="100px" TextMode="MultiLine" Width="300px"
                                ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Стратегия:
                        </td>
                        <td style="text-align: right;">
                            <asp:TextBox ID="txtStrategy" runat="server" Height="100px" TextMode="MultiLine" 
                                Width="300px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Визия:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtVision" runat="server" Height="100px" TextMode="MultiLine" Width="300px"  
                                ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right">
                            <asp:Button ID="ButtonSave" runat="server" Font-Bold="True" Text="Запис" 
                                Width="90px" onclick="ButtonSave_Click"  />
                            <asp:Button ID="Button1" runat="server" Font-Bold="True" 
                                onclick="Button1_Click" Text="Отказ" Width="90px" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                <table class="style14">
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Училище:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtSchoole" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSchoole" runat="server" ControlToValidate="txtSchoole"
                                Display="Dynamic" ErrorMessage="Моля попълнете!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Град/Село:
                        </td>
                        <td style="text-align: right">
                            <asp:DropDownList ID="DropDownListCity" runat="server" DataSourceID="SqlDataSource1"
                                DataTextField="Name" DataValueField="CityVillageID" Width="300px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                                SelectCommand="SELECT [CityVillageID], [Name] FROM [CityVillage] order by Name">
                            </asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ControlToValidate="DropDownListCity"
                                Display="Dynamic" ErrorMessage="Моля попълнете!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Адрес:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="txtAddress"
                                Display="Dynamic" ErrorMessage="Моля попълнете!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Мисия:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtMission" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Стратегия:
                        </td>
                        <td style="text-align: right;">
                            <asp:TextBox ID="txtStrategy" runat="server" Height="100px" TextMode="MultiLine"
                                Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Визия:
                        </td>
                        <td style="text-align: right">
                            <asp:TextBox ID="txtVision" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right">
                            <asp:Button ID="ButtonInsert" runat="server" Font-Bold="True" Text="Въведи" Width="90px"
                                OnClick="ButtonInsert_Click" />
                            <asp:Button ID="ButtonEdit" runat="server" Font-Bold="True" OnClick="ButtonEdit_Click"
                                Text="Промени" Width="90px" CausesValidation="False" />
                            <asp:Button ID="ButtonCancel" runat="server" Font-Bold="True" OnClick="ButtonCancel_Click"
                                Text="Отказ" Width="90px" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                <table class="style14">
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            УчилищеНомер:
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("SchoolID") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Училище:
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LabelSchoole" runat="server" Text='<%# Eval("SchooName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Град/Село:
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LabelCity" runat="server" Text='<%# Eval("CityVillageID") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Адрес:
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LabelAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium; height: 23px;">
                            Мисия:
                        </td>
                        <td style="text-align: right; height: 23px;">
                            <asp:Label ID="lblMision" runat="server" Text='<%# Eval("Mission") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Стратегия:
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LabelStrategy" runat="server" Text='<%# Eval("Strategy") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; color: #990000; font-size: medium;">
                            Визия:
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Vision" runat="server" Text='<%# Eval("Vision") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        </asp:FormView>
        <asp:Label ID="lblMessage" runat="server" 
            style="color: #990000; font-weight: 700"></asp:Label>
    </div>
</asp:Content>
