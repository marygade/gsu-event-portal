<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

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
                        %>
                <span class="heading">Tickets:</span>
                <span class="value"><select runat="server" id="numberOfTickets">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                      </select>
                </span>
                <br />
                <span class="heading">Email:</span>
                <span class="value"><input type="email" required="required" /></span>
                <br />
                <span class="heading">Name:</span>
                <span class="value"><input type="text" required="required" /></span>
                <br />
                <%
                        if (eve.price > 0)
                        {
                %>
                
                <br />
                <input type="text" placeholder="Credit Card Number" required="required" pattern="[0-9]{16}" title="Enter valid number" />
                <br />
                <select>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                    <option>6</option>
                    <option>7</option>
                    <option>8</option>
                    <option>9</option>
                    <option>10</option>
                    <option>11</option>
                    <option>12</option>
                </select>
                <select>
                    <option>2016</option>
                    <option>2017</option>
                    <option>2018</option>
                    <option>2019</option>
                    <option>2020</option>
                    <option>2021</option>
                    <option>2022</option>
                    <option>2023</option>
                    <option>2024</option>
                    <option>2025</option>
                    <option>2026</option>
                    <option>2027</option>
                </select>
                <br />
                <input type="text" placeholder="CVV" required="required" pattern="[0-9]{3}" title="Enter valid number" />
                <%
                        }
                %>
                <br />
                
                
            <asp:LinkButton runat="server" ID="btnAttend" Text="Attend" OnClick="btnAttend_Click"></asp:LinkButton>
                <%
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
