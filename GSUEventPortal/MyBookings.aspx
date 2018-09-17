<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyBookings.aspx.cs" Inherits="MyBookings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Bookinsg</title>
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
                if (Session["eventRegistered"] != null)
                {
                    %>
                    <%=Session["eventRegistered"].ToString() %>
                    <%
                    Session["eventRegistered"] = null;
                }
            %>
        </h3>
        <%
            if(eventList.Count > 0)
            {
                %>
                    <table>
                        <caption>My Bookings</caption>
                        <thead>
                            <tr>
                                <th>Cover</th>
                                <th>Name</th>
                                <th>Number of Bookings</th>
                                <th>Price</th>
                                <th>Category</th>
                                <th>Place</th>
                                <th>Date</th>
                                <th>Time</th>
                                <th>Duration</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%
                                foreach(Event eve in eventList)
                                {
                                    %>
                                        <tr>
                                            <td style="width:200px"><a href="ViewEvent.aspx?id=<%=eve.id %>"><img src="uploads/<%=eve.image_url %>" /></a></td>
                                            <td><%=eve.name %></td>
                                            <td><%=eve.number_of_bookings %></td>
                                            <td><%=eve.price * eve.number_of_bookings %></td>
                                            <td><%=eve.category_name %></td>
                                            <td><%=eve.place %></td>
                                            <td><%=eve.date %></td>
                                            <td><%=eve.start_time %></td>
                                            <td><%=eve.duration %> Min</td>
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
                    <h3 class="text-center">There are no Bookings</h3>
                <%
            }
        %>
    </form>
</body>
</html>
