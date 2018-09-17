using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void register_Click(object sender, EventArgs e)
    {
        string un = userName.Text;
        string em = email.Text;
        string ps = password.Text;
        string sq = securityQuestion.Text;
        string sa = securityAnswer.Text;

        DataOperations dop = new DataOperations();
        User user = new User(0, un, em, ps, "normal", sq, sa);
        if(dop.registerUser(user))
        {
            userName.Text = "";
            email.Text = "";
            password.Text = "";
            securityAnswer.Text = "";
            securityQuestion.Text = "";
            confirmPassword.Text = "";
            successMsg.InnerText = "User registered";
        }
        else
        {
            errorMsg.InnerText = "Please try again";
        }
    }
}