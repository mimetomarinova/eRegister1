<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="eRegister1.Teachers" EnableEventValidation="False" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style11
        {
            text-align: center;
            width: 709px;
            margin-left: 0px;
        }
        .style12
        {
            font-size: large;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" >
    </asp:ScriptManager>
    
            <asp:DropDownList  ID="DropDownListSubject" runat="server" CssClass="style12" Height="33px" 
                Width="178px" >
            </asp:DropDownList>
            <asp:CascadingDropDown ID="DropDownListSubject_CascadingDropDown" runat="server" 
                Enabled="True" TargetControlID="DropDownListSubject" UseContextKey="True" 
                Category="Subj" EmptyText="Няма елементи" 
                LoadingText="Зарежда се списък на предметите" PromptText="Изберете предмет" 
                ServiceMethod="GetSubj" ServicePath="~/WebService1.asmx">
                
            </asp:CascadingDropDown>
            <br class="style12" />
            <span class="style12">Избери учител:&nbsp;&nbsp; </span>
            <asp:DropDownList ID="DropDownListTeacher" runat="server" CssClass="style12" 
                Height="47px" Width="178px"  AutoPostBack="true"
        onselectedindexchanged="DropDownListTeacher_SelectedIndexChanged" >
            </asp:DropDownList>
            <asp:CascadingDropDown ID="DropDownListTeacher_CascadingDropDown" runat="server" 
                Enabled="True" TargetControlID="DropDownListTeacher" Category="Teacher" 
                LoadingText="Зарежда се списък учители" 
                ParentControlID="DropDownListSubject" PromptText="Изберете учител" 
                ServiceMethod="GetTeachersInSubj" ServicePath="~/WebService1.asmx">
            </asp:CascadingDropDown>
           
  <asp:Panel ID="Panel2" runat="server" GroupingText="Информация" Width="670px" 
            style="font-size: x-large; margin-left: 79px" Visible="False">
      <asp:GridView ID="GridView1" runat="server">
      </asp:GridView>
      <asp:Label ID="lblErr" runat="server" ></asp:Label>
            </asp:Panel>


</asp:Content>
