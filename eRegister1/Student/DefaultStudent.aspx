<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true" CodeBehind="DefaultStudent.aspx.cs" Inherits="eRegister1.Student.DefaultStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="lblInfo" runat="server" Text="Информация за Електронния дневник" 
            style="font-size: large; font-weight: 700"></asp:Label><br/><br/>
        <asp:Label ID="lblContent" runat="server" 
            
            Text="&quot;Полезна информация, за потребителя, какво да очаква като информация от Електронния дневник, какво може да прави от профила си&quot;" 
            style="font-size: large"></asp:Label>
    </asp:Panel>
</asp:Content>
