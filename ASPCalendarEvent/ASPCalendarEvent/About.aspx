<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ASPCalendarEvent.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">



     <h2>Basic Initialization</h2>
 
    <%= Model.Render() %> 


</asp:Content>