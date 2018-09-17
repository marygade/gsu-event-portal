<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingEvents.aspx.cs" Inherits="PendingEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pending Events</title>
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>GSU Event Portal</h1>
            <h4 runat="server" id="loggedUserName">Hello <%=((User)Session["loggedUser"]).name %></h4>
        </div>
        <div class="navigation">
            <ul>
                <li><a href="PendingEvents.aspx">Home</a></li>
                <li><a href="Logout.aspx">Logout</a></li>
            </ul>
        </div>
        <%
            if(eventList.Count > 0)
            {
                %>
                    <table>
                        <caption>Pending Events</caption>
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Category</th>
                                <th>Place</th>
                                <th>Date</th>
                                <th>Time</th>
                                <th>Duration</th>
                                <th>Price</th>
                                <th>Cover</th>
                                <th>Approve</th>
                                <th>Reject</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%
                                foreach(Event eve in eventList)
                                {
                                    %>
                                        <tr>
                                            <td><%=eve.name %></td>
                                            <td><%=eve.description %></td>
                                            <td><%=eve.category_name %></td>
                                            <td><%=eve.place %></td>
                                            <td><%=eve.date %></td>
                                            <td><%=eve.start_time %></td>
                                            <td><%=eve.duration %> Min</td>
                                            <td><%=eve.price %></td>
                                            <td><img src="uploads/<%=eve.image_url %>" /></td>
                                            <td><a href="ApproveEvent.aspx?id=<%=eve.id %>">Approve</a></td>
                                            <td><a href="RejectEvent.aspx?id=<%=eve.id %>">Reject</a></td>
                                        </tr>
                                    <%
                                }
                            %>
                        </tbody>
                    </table>
                <%
            }
            else
            {
                %>
                    <h3 class="text-center">There are no pending events</h3>
                <%
            }
        %>
    </form>
</body>
</html>
