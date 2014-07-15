<%@ Page Title="Main Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainChat.aspx.cs" Inherits="Chater.MainChat" %>

<%@ Register Src="~/Code/Controlers/MessageWindow.ascx" TagPrefix="uc1" TagName="MessageWindow" %>
<%@ Register Src="~/Code/Controlers/UserList.ascx" TagPrefix="uc1" TagName="UserList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Login" runat="server"></asp:Label> | <span id="logOutMe" style="cursor:pointer"><u>Log Out</u></span>
    
    <div class="container">
        <div class="msg">
            <uc1:MessageWindow runat="server" ID="MessageWindow" />
        </div>
        <div class="users">
            <uc1:UserList runat="server" ID="UserList" />
        </div>
    </div>

    <%--Ogarnij to docelowo managerem scriptow--%>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery.signalR-2.1.0.js"></script>
    <script src="/signalr/hubs"></script>
    <script src="Scripts/Obj/manageClientUsers.js"></script>

</asp:Content>
