<%@ Page Title="" Language="C#" MasterPageFile="~/Student/MasterPage5.master" AutoEventWireup="true" CodeBehind="NewMessages.aspx.cs" Inherits="eRegister1.Student.NewMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="nestedmain" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Ново съобщение" 
        style="font-size: large">
        <div style="text-align: left">
            <asp:Button ID="ButtonSend" runat="server" Text="Изпращане" 
                onclick="ButtonSend_Click" CommandName="Send" />
            <asp:Button ID="ButtonSave"
                runat="server" Text="Запази" onclick="ButtonSave_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="#990000"></asp:Label>
        </div><br/>
        <div style="text-align: left">
            <asp:Label ID="Label1" runat="server" Text="До: "></asp:Label>
            <asp:DropDownList
                ID="DropDownListTeacher" runat="server" Height="22px" Width="441px">
            </asp:DropDownList>
        </div>
          <div style="text-align: left">
              <asp:Label ID="Label2" runat="server" Text="Изберете файл:   "></asp:Label>
              <asp:FileUpload ID="FileUploadHomework" runat="server" />
              <asp:Button ID="ButtonAttach" runat="server" Text="Прикачи" 
                  onclick="ButtonAttach_Click" />
                  &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="#990000"></asp:Label>
        </div><br/>
        <div>
            <asp:TextBox ID="txtMessage" runat="server" Height="200px" Width="550px" 
                Rows="50" style="margin-left: 0px" TextMode="MultiLine" ></asp:TextBox>
        </div>
    </asp:Panel>
</asp:Content>
