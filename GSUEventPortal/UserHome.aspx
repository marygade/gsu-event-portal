<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Home</title>
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
        <div class="searchBar">
            <span>Category</span>
            <asp:DropDownList runat="server" ID="searchCategory" OnSelectedIndexChanged="searchCategory_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="Any" Text="Any" />
                <asp:ListItem Value="Comedy" Text="Comedy" />
                <asp:ListItem Value="Charity" Text="Charity" />
                <asp:ListItem Value="Magic" Text="Magic" />
                <asp:ListItem Value="Health" Text="Health" />
                <asp:ListItem Value="Others" Text="Others" />
            </asp:DropDownList>
            <span>Place</span>
            <asp:DropDownList runat="server" ID="searchPlace" OnSelectedIndexChanged="searchPlace_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <span>Duration</span>
            <asp:DropDownList runat="server" ID="searchDuration" OnSelectedIndexChanged="searchDuration_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="Any" Text="Any" />
                <asp:ListItem Value="30" Text="30 Min" />
                <asp:ListItem Value="60" Text="60 Min" />
                <asp:ListItem Value="90" Text="90 Min" />
                <asp:ListItem Value="120" Text="120 Min" />
            </asp:DropDownList>
            <span>Price</span>
            <asp:DropDownList runat="server" ID="searchPrice" OnSelectedIndexChanged="searchPrice_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="Any" Text="Any" />
                <asp:ListItem Value="10" Text="Free" />
                <asp:ListItem Value="20" Text="< 50" />
                <asp:ListItem Value="30" Text="50 - 100" />
                <asp:ListItem Value="40" Text="> 100" />
            </asp:DropDownList>
            <input type="search" runat="server" id="searchKey" placeholder="Search" required="required" />
            <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Go" />
        </div>
        <%
            if (eventList.Count > 0)
            {
        %>
        <div class="events">
            <%
                int pg = 1;
                if (Request["page"] != null)
                {
                    pg = int.Parse(Request["page"]);
                }
                pg--;
                for (int i = (pg * 4); i < (pg + 1) * 4 && i < eventList.Count; i++)
                {
                    Event eve = eventList[i];
            %>
            <div class="eventBox">
                <span><a href="ViewEvent.aspx?id=<%=eve.id%>"><%=eve.name%></a></span>
                <br />
                <a href="ViewEvent.aspx?id=<%=eve.id%>">
                    <img src="uploads/<%=eve.image_url%>" /></a>
                <br />
                <span>Category: <%=eve.category_name%></span>
                <br />
                <span>Place: <%=eve.place%></span>
                <br />
                <span>Date: <%=eve.date%></span>
                <br />
                <span>Time: <%=eve.start_time%></span>
                <br />
                <span>Duration: <%=eve.duration%> Min</span>
                <br />
                <span>Price: <%=eve.price%></span>
            </div>
            <%
                }
            %>
            <div class="pagination">
                <%
                for (int i = 1; i <= pagesCount; i++)
                {
                %>
                <a href="UserHome.aspx?page=<%=i %>"><%=i %></a>
                <%
                    }
                %>
            </div>
        </div>
        <%
            }
            else
            {
        %>
        <h3 class="text-center">There are no events</h3>
        <%
            }
        %>
    </form>
</body>
</html>
