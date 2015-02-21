<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCalendarEvent._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Label runat="server" ID="lblDays">Enter Days</asp:Label>
    <asp:TextBox runat="server" ID="txtDays"/>
    <asp:Button runat="server" ID="btnGetEvents" OnClick="btnGetEvents_OnClick" Text="Get Events"/>
   
</asp:Content>
