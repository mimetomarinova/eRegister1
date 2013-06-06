<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true"
    CodeBehind="NewsDetail.aspx.cs" Inherits="eRegister1.NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            font-size: small;
        }
        .style11
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div style="margin-left: 70px; margin-top: 40px;" align="center">
        <asp:FormView ID="FormView1" runat="server">
            <ItemTemplate>
                <table class="style10" style="text-align: left">
                    <tr>
                        <td align="center">
                           <h2> <asp:Label ID="LabelTitleNews" runat="server" Text='<%# Eval("Title")%>' Font-Bold="True" ForeColor="#990000"></asp:Label></h2>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDescription" runat="server" Text='<%# Eval("Description")%>' Font-Size="Medium"></asp:Label>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <em><span class="style11">Дата:</span></em>
                            <asp:Label ID="LabelDate" runat="server" Text='<%# Eval("DatePublication")%>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
        <br />
        
        <asp:Label ID="lblErr" runat="server"></asp:Label>
    </div>
    <div style="margin-left: 70px" align="left"><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" meta:resourcekey="LinkButton4Resource1"
            Style="text-align: left">назад</asp:LinkButton></div>
</asp:Content>
