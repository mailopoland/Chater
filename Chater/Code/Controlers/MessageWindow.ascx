<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageWindow.ascx.cs" Inherits="Chater.Code.WebUserControl1" %>

<textarea style="height: 50px; width: 300px;" id="CurMessage"></textarea><br />
<button style="width:280px; overflow:auto;" id="SendMsg" onclick="return false;">Send</button><br /><br />
<span id="AllMessages"></span>