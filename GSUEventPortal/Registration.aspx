<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
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
        <fieldset class="designFieldset">
            <legend>Registration</legend>
            <asp:TextBox ID="userName" runat="server" placeholder="Name"></asp:TextBox>
            <asp:RegularExpressionValidator ID="nameValidator" runat="server" ErrorMessage="Inavlid Name"
                ControlToValidate="userName" Display="Dynamic" ValidationExpression="^[a-zA-Z'.\s]{1,50}"
                ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="nameReqValidator" runat="server" ErrorMessage="Enter Name"
                ControlToValidate="userName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="email" runat="server" placeholder="Email"></asp:TextBox>
            <asp:RegularExpressionValidator ID="emailValidator" runat="server" ErrorMessage="Invalid Email"
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="email" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="emailReqValidator" runat="server" ErrorMessage="Enter Email"
                ControlToValidate="email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="password" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
            <asp:RegularExpressionValidator ID="passwordLengthValidator" runat="server" ErrorMessage="Password length should be between 6 - 10"
                ControlToValidate="password" ValidationExpression="^[\s\S]{6,10}$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="passwordReqValidator" runat="server" ErrorMessage="Enter Password"
                ControlToValidate="password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="confirmPassword" TextMode="Password" runat="server" placeholder="Confirm Password"></asp:TextBox>
            <asp:CompareValidator ID="passwordCompareValidator" runat="server" ErrorMessage="Both passwords must match" ForeColor="Red"
                ControlToValidate="confirmPassword" ControlToCompare="password" Display="Dynamic"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="confirmPasswordReqValidator" runat="server" ErrorMessage="Enter Confirm Password"
                ControlToValidate="confirmPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="securityQuestion" runat="server" placeholder="Question"></asp:TextBox>
            <asp:RegularExpressionValidator ID="securityQuestionRegValidator" runat="server" ErrorMessage="Max 20 characters"
                ControlToValidate="securityQuestion" ValidationExpression="^[\s\S]{1,20}$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="securityQuestionReqValidator" runat="server" ErrorMessage="Enter Password"
                ControlToValidate="securityQuestion" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="securityAnswer" runat="server" placeholder="Answer"></asp:TextBox>
            <asp:RegularExpressionValidator ID="securityAnswerRegValidator" runat="server" ErrorMessage="Max 20 characters"
                ControlToValidate="securityAnswer" ValidationExpression="^[\s\S]{1,20}$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="securityAnswerReqValidator" runat="server" ErrorMessage="Enter Password"
                ControlToValidate="securityAnswer" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="register" CssClass="btn" runat="server" Text="Register" OnClick="register_Click" />
            <br />
            <span runat="server" id="errorMsg" class="error"></span>
            <span runat="server" id="successMsg" class="success"></span>
        </fieldset>
    </form>
    <div class="footer">
        <ul>
            <li><a href="AboutUs.aspx">About Us</a></li>
            <li><a href="ContactUs.aspx">Contact Us</a></li>
        </ul>
    </div>
</body>
</html>
