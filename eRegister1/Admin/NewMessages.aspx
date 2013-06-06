<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true"
    CodeBehind="NewMessages.aspx.cs" Inherits="eRegister1.Admin.NewMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Ново съобщение" Style="font-size: large">
        <div style="text-align: left">
            <asp:Button ID="ButtonSend" runat="server" Text="Изпращане" OnClick="ButtonSend_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="#990000"></asp:Label>
        </div>
        <br />
        <div style="text-align: left">
            <asp:Label ID="Label1" runat="server" Text="До: "></asp:Label>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text=" - учители "></asp:Label>
            <asp:DropDownList ID="DropDownListTeacher" runat="server" Height="22px" Width="200px">
            </asp:DropDownList>
            <asp:CheckBox ID="chbAllTeacher" runat="server" Text="До всички учители" />
            <br />
            <asp:Label ID="Label4" runat="server" Text=" - родители "></asp:Label>
            <asp:DropDownList ID="DropDownListParent" runat="server" Height="22px" Width="200px">
            </asp:DropDownList>
            <asp:CheckBox ID="chbAllParent" runat="server" Text="До всички родители" />
            <br />
            <asp:Label ID="Label5" runat="server" Text=" - ученици "></asp:Label>
            <asp:DropDownList ID="DropDownListStudent" runat="server" Height="22px" Width="200px">
            </asp:DropDownList>
            <asp:CheckBox ID="chbAllStudents" runat="server" Text="До всички ученици" />
            <br />
        </div>
        <div style="text-align: left">
            <asp:Label ID="Label2" runat="server" Text="Тема: "></asp:Label>
            <asp:DropDownList ID="DropDownListMessageType" runat="server" Height="22px" Width="200px"
                AutoPostBack="True" OnSelectedIndexChanged="DropDownListMessageType_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:TextBox ID="txtMessage" runat="server" Height="205px" Width="543px" Rows="50"
                Style="margin-left: 0px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </asp:Panel>
</asp:Content>
