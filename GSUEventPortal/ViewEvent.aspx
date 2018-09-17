<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEvent.aspx.cs" Inherits="ViewEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=eve.name %></title>
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>GSU Event Portal</h1>
            <%
                if (Session["loggedUser"] != null)
                {
            %>
            <h4 runat="server" id="loggedUserName">Hello <%=((User)Session["loggedUser"]).name %></h4>
            <%
                }
            %>
        </div>
        <div class="navigation">
            <ul>
                <%
                    if (user == null)
                    {
                %>
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Registration.aspx">Create Account</a></li>
                <%
                    }
                    else
                    {
                %>
                <li><a href="UserHome.aspx">Home</a></li>
                <li><a href="CreateEvent.aspx">Create Event</a></li>
                <li><a href="MyEvents.aspx">My Events</a></li>
                <li><a href="MyBookings.aspx">My Bookings</a></li>
                <li><a href="Logout.aspx">Logout</a></li>
                <%
                    }
                %>
            </ul>
        </div>
        <h1 class="text-center"><%=eve.name %></h1>
        <div class="specificEvent">
            <div class="cover">
                <img src="uploads/<%=eve.image_url %>" />
            </div>
            <div class="details">
                <span class="heading">Description:</span>
                <span class="value"><%=eve.description %></span>
                <br />
                <span class="heading">Category:</span>
                <span class="value"><%=eve.category_name %></span>
                <br />
                <span class="heading">Place:</span>
                <span class="value"><%=eve.place %></span>
                <br />
                <span class="heading">Date:</span>
                <span class="value"><%=eve.date %></span>
                <br />
                <span class="heading">Time:</span>
                <span class="value"><%=eve.start_time %></span>
                <br />
                <span class="heading">Duration:</span>
                <span class="value"><%=eve.duration %> Min</span>
                <br />
                <span class="heading">Price:</span>
                <span class="value"><%=eve.price %></span>
                <br />

                <%
                    if (user != null && user.id != eve.user_id)
                    {
                        if (eve.price > 0)
                        {
                %>


                <asp:LinkButton runat="server" ID="btnAttend" Text="Book" OnClick="btnAttend_Click"></asp:LinkButton>
                <%
                        }
                    }
                    
                %>
            </div>
            <%
                if (Request["show"] != null)
                {
            %>
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Bookings</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                    foreach (string u in userNames)
                    {
                        %>
                        <tr>
                            <td><%=u %></td>
                        </tr>
                        <%
                    }
                        %>
                    </tbody>
                </table>
            </div>
            <%
                }
            %>
        </div>
    </form>
</body>
</html>
