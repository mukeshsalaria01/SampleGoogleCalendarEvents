<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASPCalendarEvent.aspx.cs" Inherits="ASPCalendarEvent.ASPCalendarEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google Calendar Events</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <style>
        .align-center {
            text-align: center;
            width: 100px;
        }

        .margin-top10 {
            margin-top: 10px;
        }

        .margin-top0 {
            margin: 0 0 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container bs-docs-container margin-top10">
            <div class="row">
                <asp:Repeater runat="server" ID="rptEvents">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="table-responsive">
                            <table class="table table-bordered">
                                <thead>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th class="align-center">Date
                                            <h2 class="margin-top0">
                                                <asp:Label runat="server" ID="lblDay" Text='<% #Eval("Day")%>'></asp:Label></h2>
                                            <h5 class="margin-top0">
                                                <asp:Label runat="server" ID="lblMonth" Text='<%#Eval("Month") %>'></asp:Label></h5>
                                        </th>
                                        <th>Location:
                                    <asp:Label runat="server" ID="lblLocation" Text='<% #Eval("Location")%>'></asp:Label>
                                            <br />
                                            <asp:Label runat="server" ID="titleTime">Time: </asp:Label>
                                            <asp:Label runat="server" ID="lblTime" Text='<% #Eval("Time")%>'></asp:Label>
                                            <br />
                                            <asp:Label runat="server" ID="titleMap">Map: </asp:Label>
                                            <asp:HyperLink runat="server" ID="lblMap" NavigateUrl='<% #Eval("Map")%>' Target="_blank" Style="cursor: pointer" Text="View map"></asp:HyperLink>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </form>
</body>
</html>
