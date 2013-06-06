<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="Schoole.aspx.cs" Inherits="eRegister1.Schoole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <div style="margin-left: 70px; margin-top: 40px;" align="center">
        <asp:FormView ID="FormView1" runat="server">
            <ItemTemplate>
                <table class="style10" style="text-align: left">
                    <tr>
                        <td align="center">
                           <h2> <asp:Label ID="LabelSchooleName" runat="server" Text='<%# Eval("SchooName")%>' Font-Bold="True" ForeColor="#990000"></asp:Label></h2>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAddress" runat="server" Text='<%# Eval("[Address]")%>' Font-Size="Medium"></asp:Label>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                            <asp:Label ID="LabelHistory" runat="server" Text='<%# Eval("History")%>'></asp:Label>
                        </td>
                    </tr>

                </table>
            </ItemTemplate>
        </asp:FormView>
        <br />
        
        <asp:Label ID="lblErr" runat="server"></asp:Label>
    </div>
</asp:Content>
