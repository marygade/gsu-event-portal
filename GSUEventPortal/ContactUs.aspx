<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
</head>
<body>
    <div class="header">
        <h1>GSU Event Portal</h1>
    </div>
    <div class="navigation">
        <ul>
            <li><a href="index.aspx">Home</a></li>
            <li><a href="Registration.aspx">Create Account</a></li>
        </ul>
    </div>
    <form id="form1" runat="server">
        <br />
        <h2 class="text-center">Contact Us</h2>
        <br />
        <div class="contactUs">
            <span class="heading">Email:</span>
            <span class="value">contact@gpsu.com</span>
            <br />
            <span class="heading">Mobile:</span>
            <span class="value">1231231231</span>
            <br />
            <span class="heading">Address:</span>
            <span class="value">36 Avenue, CA, 54052</span>
            <br />
        </div>
    </form>
    <div class="footer">
        <ul>
            <li><a href="AboutUs.aspx">About Us</a></li>
            <li><a href="ContactUs.aspx">Contact Us</a></li>
        </ul>
    </div>
</body>
</html>
