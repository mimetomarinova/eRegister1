<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage2.master" AutoEventWireup="true" CodeBehind="DefaultAdmin.aspx.cs" Inherits="eRegister1.Admin.DefaultAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Text="Информация за Електронния дневник" 
            style="font-size: large; font-weight: 700"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblContent" runat="server" 
            Text="Полезна информация, за администратора, какво да очаква от Електронния дневник, какво може да прави от профила си!" 
            style="font-size: large"></asp:Label>
    </div>
</asp:Content>
