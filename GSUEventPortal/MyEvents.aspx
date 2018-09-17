<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyEvents.aspx.cs" Inherits="MyEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Events</title>
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
                <li><a href="UserHome.aspx">Home</a></li>
                <li><a href="CreateEvent.aspx">Create Event</a></li>
                <li><a href="MyEvents.aspx">My Events</a></li>
                <li><a href="MyBookings.aspx">My Bookings</a></li>
                <li><a href="Logout.aspx">Logout</a></li>
            </ul>
        </div>
        <h3 class="text-center success">
            <%
                if (Session["eventCreated"] != null)
                {
                    %>
                    <%=Session["eventCreated"].ToString() %>
                    <%
                    Session["eventCreated"] = null;
                }
            %>
        </h3>
        <%
            if(eventList.Count > 0)
            {
                %>
                    <table>
                        <caption>My Events</caption>
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
                                <th>Approved</th>
                                <th>Edit</th>
                                <th>Delete</th>
                                <th>Bookings</th>
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
                                            <td style="width:200px"><img src="uploads/<%=eve.image_url %>" /></td>
                                            <td><%=eve.approved == 0 ? "No" : "Yes" %></td>
                                            <td><a class="normalLink" href="EditEvent.aspx?id=<%=eve.id %>">Edit</a></td>
                                            <td><a class="normalLink" href="DeleteEvent.aspx?id=<%=eve.id %>">Delete</a></td>
                                            <td><a class="normalLink" href="ViewEvent.aspx?id=<%=eve.id %>&show=bookings">Bookings</a></td>
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
                    <h3 class="text-center">There are no events created by you</h3>
                <%
            }
        %>
    </form>
</body>
</html>
