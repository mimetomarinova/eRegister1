<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="eRegister1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <p class="style10">
        <strong>Новини!</strong></p>
    <div style="margin-left: 70px; text-align: left;">
        <asp:ListView ID="ListView1" runat="server" EnableViewState="False">
        <ItemTemplate>
            <a href="NewsDetail.aspx?newID=<%#Eval("NewsID") %>" style="font-size: large; font-weight: bold; color: #990000;"><%#(Eval("Title"))%></a>
                <br></br>
                <asp:Label ID="LabelNews" runat="server" Text='<%# Eval("DatePublication")%>' Font-Italic="True"></asp:Label>
            <hr />
                <br></br>
        </ItemTemplate>
        </asp:ListView>
         
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" 
            PageSize="3" onprerender="DataPager1_PreRender">
            <Fields>
                <asp:NextPreviousPagerField NextPageText="Следваща &gt;&gt;" 
                    PreviousPageText="&lt;&lt; Предишна" />
                <asp:NumericPagerField />
            </Fields>
        </asp:DataPager>
       
        <asp:Label ID="LabelErr" runat="server"></asp:Label>
    </div>
</asp:Content>
