<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Chater.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        Put here your login:<asp:TextBox ID="GetLogin" runat="server"></asp:TextBox><br /><asp:Button ID="LogIn" runat="server" Text="Log in" />
        <br /><asp:Label ID="Communicate" runat="server"></asp:Label>
        &nbsp;</div>
</asp:Content>
