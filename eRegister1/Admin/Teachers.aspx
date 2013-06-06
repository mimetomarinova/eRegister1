<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="Teachers.aspx.cs" Inherits="eRegister1.Admin.Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <table style="width: 82%">
        <tr>
            <td style="text-align: left; width: 179px">
                <asp:Label ID="Label3" runat="server" Text="Списък на учителите:"></asp:Label><br />
                <asp:ListBox ID="ListBox1" runat="server" Height="343px" Width="145px" DataSourceID="SqlDataSource4"
                    DataTextField="Name" DataValueField="ActorID"></asp:ListBox>
            </td>
            <td>
                <asp:Wizard ID="Wizard1" runat="server" Height="202px" Width="73px" ActiveStepIndex="0"
                    BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderWidth="1px" Font-Names="Verdana"
                    Font-Size="0.8em" DisplaySideBar="False" StepNextButtonText="Напред" StepPreviousButtonText="Назад"
                    OnNextButtonClick="Wizard1_NextButtonClick" CancelButtonText="Отказ" FinishCompleteButtonText="Край"
                    FinishPreviousButtonText="Назад" OnFinishButtonClick="Wizard1_FinishButtonClick">
                    <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px"
                        Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
                    <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                    <SideBarButtonStyle ForeColor="White" />
                    <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
                    <StepNavigationTemplate>
                        <asp:Button ID="StepPreviousButton" runat="server" BackColor="White" BorderColor="#CC9966"
                            BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="MovePrevious"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Text="Назад" />
                        <asp:Button ID="StepNextButton" runat="server" BackColor="White" BorderColor="#CC9966"
                            BorderStyle="Solid" BorderWidth="1px" CommandName="MoveNext" Font-Names="Verdana"
                            Font-Size="0.8em" ForeColor="#990000" Text="Напред" />
                    </StepNavigationTemplate>
                    <WizardSteps>
                        <asp:WizardStep runat="server" Title="Лични данни" AllowReturn="false">
                            <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DefaultMode="Insert"
                                Width="354px" Style="text-align: left">
                                <InsertItemTemplate>
                                    <div style="text-align: right">
                                        <table class="style14">
                                            <tr>
                                                <td style="text-align: center; color: #990000;" colspan="2">
                                                    <h4>
                                                        <span style="font-weight: normal"><em>Лични данни за учителя</em></span></h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Име:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameTextBox"
                                                        Display="Dynamic" ErrorMessage="Моля, попълнете име!" ForeColor="#990000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Презиме:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MiddleNameTextBox"
                                                        Display="Dynamic" ErrorMessage="Моля, попълнете презиме!" ForeColor="#990000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Фамилия:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LastNameTextBox"
                                                        Display="Dynamic" ErrorMessage="Моля, попълнете фамилия!" ForeColor="#990000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Пол:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="false">Жена</asp:ListItem>
                                                        <asp:ListItem Value="true">Мъж</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="RadioButtonList1"
                                                        Display="Dynamic" ErrorMessage="Моля, изберете пол!" ForeColor="#990000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    ЕГН:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="EGNTextBox" runat="server" Text='<%# Bind("EGN") %>' />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="EGNTextBox"
                                                        Display="Dynamic" ErrorMessage="Моля, попълнете ЕГН!" ForeColor="#990000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    e-mail:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailTextBox"
                                                        Display="Dynamic" ErrorMessage="Невалиден e-mail!" ForeColor="#990000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="emailTextBox"
                                                        Display="Dynamic" ForeColor="#990000">Моля, въведете e-mail!</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Телефон:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="PhoneNumberTextBox" runat="server" Text='<%# Bind("PhoneNumber") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Училище
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource5"
                                                        DataTextField="SchooName" DataValueField="SchoolID">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 96px">
                                                    Потребителско име:
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style12" style="width: 96px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        &nbsp;<br />
                                    </div>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    FirstName:
                                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
                                    <br />
                                    MiddleName:
                                    <asp:Label ID="MiddleNameLabel" runat="server" Text='<%# Bind("MiddleName") %>' />
                                    <br />
                                    LastName:
                                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
                                    <br />
                                    Gender:&nbsp;Gender:&nbsp;<asp:CheckBox ID="GenderCheckBox" runat="server" Checked='<%# Bind("Gender") %>'
                                        Enabled="false" />
                                    <br />
                                    EGN:
                                    <asp:Label ID="EGNLabel" runat="server" Text='<%# Bind("EGN") %>' />
                                    <br />
                                    email:
                                    <asp:Label ID="emailLabel" runat="server" Text='<%# Bind("email") %>' />
                                    <br />
                                    PhoneNumber:
                                    <asp:Label ID="PhoneNumberLabel" runat="server" Text='<%# Bind("PhoneNumber") %>' />
                                    <br />
                                    SchooName:
                                    <asp:Label ID="SchooNameLabel" runat="server" Text='<%# Bind("SchooName") %>' />
                                    <br />
                                    UserName:
                                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Bind("UserName") %>' />
                                    <br />
                                </ItemTemplate>
                            </asp:FormView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                                SelectCommand="SELECT Actors.FirstName, Actors.MiddleName, Actors.LastName, Actors.Gender, Actors.EGN, Actors.email, Actors.PhoneNumber, Schools.SchooName, Users.UserName FROM Actors INNER JOIN Schools ON Actors.SchoolID = Schools.SchoolID INNER JOIN Users ON Actors.UserID = Users.UserID">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                                SelectCommand="sp_GetSchooleInfo" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="9" Name="ActorID" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            <br />
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" Title="По кой предмет преподава" AllowReturn="False">
                            <table class="style14">
                                <tr>
                                    <td colspan="2">
                                        <h5 style="color: #990000">
                                            Избор на предмет, по който преподава</h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 66px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 66px; text-align: left; color: #990000">
                                        <b>Учител:</b>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtTeacher" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 66px; text-align: left; color: #990000">
                                        <b>Предмет:</b>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:ListBox ID="ListBoxSubjects" runat="server" DataSourceID="SqlDataSource6" DataTextField="Name"
                                            DataValueField="SubjectID" Height="242px" SelectionMode="Multiple" Width="149px">
                                        </asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 66px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMessageSubject" runat="server" ForeColor="#990000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 66px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                                            SelectCommand="SELECT * FROM [Subjects] ORDER BY [Name]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="На кой клас преподава" AllowReturn="False"
                            StepType="Finish">
                            <table class="style14" style="width: 96%">
                                <tr>
                                    <td colspan="2">
                                        <h5 style="color: #990000">
                                            &nbsp;Класен ръководител на:</h5>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #990000; font-family: Arial, Helvetica, sans-serif; text-align: right;
                                        width: 138px">
                                        <strong><span style="font-size: small">клас</span>:</strong>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="DropDownListAllClasses" runat="server" DataSourceID="SqlDataSource7"
                                            DataTextField="Class" DataValueField="ClassDevisionDetailsID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="2">
                                        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                                            SelectCommand="sp_GetAllClasses" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr style="text-align: justify">
                                    <td class="style12" colspan="2" style="text-align: right">
                                        <asp:Label ID="lblMessageClass" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                    </WizardSteps>
                </asp:Wizard>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 179px">
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:eRegisterConnectionString %>"
                    SelectCommand="sp_GetActors" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="2" Name="UserTypeID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
