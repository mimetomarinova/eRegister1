<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="eRegister1.Student.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <div align="center">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <h2 style="color: #990000">
                        Смяна на парола</h2>
                </td>
            </tr>
            <tr>
                <td class="style14" style="text-align: left; font-family: Arial, Helvetica, sans-serif;
                    width: 227px">
                    Парола:
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="19" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Моля въведете парола!"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style14" style="text-align: left; font-family: Arial, Helvetica, sans-serif;
                    width: 227px">
                    Нова парола:
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" MaxLength="19"
                        Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                        Display="Dynamic" ErrorMessage="Моля въведете нова парола!"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style14" style="text-align: left; font-family: Arial, Helvetica, sans-serif;
                    width: 227px">
                    Повторете новата парола:
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password" MaxLength="19"
                        Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRepeatPassword"
                        Display="Dynamic" ErrorMessage="Моля въведете нова парола!"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                        ControlToValidate="txtRepeatPassword" Display="Dynamic"
                        ErrorMessage="Грешно потвърждение на парола" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 227px; text-align: right">
                    <asp:Button ID="ButtonOk" runat="server" Text="Потвърди" BackColor="#FF6600" Font-Bold="True"
                        ForeColor="Maroon" Width="100px" onclick="ButtonOk_Click" />
                </td>
                <td style="text-align: left">
                    <asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" Text="Откажи"
                        BackColor="#FF6600" Font-Bold="True" ForeColor="Maroon" OnClick="ButtonCancel_Click"
                        Width="100px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
