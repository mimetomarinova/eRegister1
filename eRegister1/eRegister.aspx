<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true"
    CodeBehind="eRegister.aspx.cs" Inherits="eRegister1.eRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            width: 100%;
        }
        .style11
        {
            color: #990000;
        }
        .style12
        {
            text-align: left;
        }
        .style13
        {
            text-align: left;
            width: 215px;
            color: #800000;
            font-size: large;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style14
        {
            width: 215px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div style="margin-left: 80px; margin-right: 80px;">
        <table class="style10">
            <tr>
                <td colspan="2">
                    <h2 class="style11">
                        Вход в системата</h2>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Потребителско име:
                </td>
                <td class="style12">
                    <asp:TextBox ID="txtUserName" runat="server" Width="200px" MaxLength="19"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="Моля полълнете!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Парола:
                </td>
                <td class="style12">
                    <asp:TextBox ID="txtPassword" runat="server" Style="margin-bottom: 0px" TextMode="Password"
                        Width="200px" MaxLength="19"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Моля попълнете!" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:Button ID="ButtonLogIn" runat="server" Text="Вход " BackColor="#FF9933" Font-Bold="True"
                        ForeColor="Maroon" Style="text-align: center" Width="100px" OnClick="ButtonLogIn_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" BackColor="#FF9933" Font-Bold="True"
                        ForeColor="Maroon" OnClick="ButtonCancel_Click" Text="Отказ" Width="100px" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
