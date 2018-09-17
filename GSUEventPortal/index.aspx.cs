using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    public List<Event> eventList = new List<Event>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.To.Add("sanjaykumar2763@gmail.com");
        //    mailMessage.From = new MailAddress("sanjaykumar2763@gmail.com");
        //    mailMessage.Subject = "Booking for event magic show";
        //    mailMessage.Body = "Hello sanjay\n\n";
        //    mailMessage.Body += "You booked 3 for event magic show.<br />";
        //    mailMessage.Body += "Place : Hyderabad. Time : 12:30. Duration : 90 min.";
        //    mailMessage.Body += "<br /><br />Thank you";
        //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        //    NetworkCredential nc = new NetworkCredential("sanjaykumar2763@gmail.com", "password)");
        //    smtpClient.EnableSsl = true;
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = nc;
        //    smtpClient.Send(mailMessage);
        //    mailMessage.IsBodyHtml = true;
        //    //Response.Write("E-mail sent!");
        //}
        //catch (Exception ex)
        //{
        //    Response.Write("Could not send the e-mail - error: " + ex.Message);
        //}

        DataOperations dop = new DataOperations();
        List<Event> temp = dop.getEvents();
        if (temp != null && temp.Count > 0)
        {
            foreach (Event eve in temp)
            {
                if (eve.approved == 1)
                {
                    eventList.Add(eve);
                }
            }
        }
        if (!IsPostBack)
        {
            searchPlace.Items.Add(new ListItem("Any", "Any"));
            foreach (string place in dop.getPlaces())
            {
                searchPlace.Items.Add(new ListItem(place, place));
            }
        }
    }
    protected void login_Click(object sender, EventArgs e)
    {
        string em = email.Value;
        string ps = password.Value;
        DataOperations dop = new DataOperations();
        User user = dop.login(em, ps);
        if (user != null)
        {
            Session["loggedUser"] = user;
            if (user.type.Equals("admin"))
            {
                Response.Redirect("PendingEvents.aspx");
            }
            else
            {
                Response.Redirect("UserHome.aspx");
            }
        }
        else
        {
            errorMsg.InnerText = "Invalid Login";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<Event> temp = new List<Event>();
        string key = searchKey.Value.Trim().ToLower();
        //Resetting other filters
        searchDuration.SelectedIndex = 0;
        searchCategory.SelectedIndex = 0;
        searchPlace.SelectedIndex = 0;

        foreach (Event eve in eventList)
        {
            if (eve.name.ToLower().Contains(key) || eve.place.ToLower().Equals(key) || eve.category_name.ToLower().Equals(key))
            {
                temp.Add(eve);
            }
        }
        eventList = temp;
    }
    protected void searchCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(searchCategory.SelectedIndex == 0))
        {
            searchDuration.SelectedIndex = 0;
            searchPlace.SelectedIndex = 0;

            List<Event> temp = new List<Event>();
            string key = searchCategory.SelectedValue.ToLower();
            foreach (Event eve in eventList)
            {
                if (eve.category_name.ToLower().Equals(key))
                {
                    temp.Add(eve);
                }
            }
            eventList = temp;
        }
    }
    protected void searchDuration_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(searchDuration.SelectedIndex == 0))
        {
            searchCategory.SelectedIndex = 0;
            searchPlace.SelectedIndex = 0;

            List<Event> temp = new List<Event>();
            int key = int.Parse(searchDuration.SelectedValue.ToString());
            foreach (Event eve in eventList)
            {
                if (eve.duration == key)
                {
                    temp.Add(eve);
                }
            }
            eventList = temp;
        }
    }
    protected void searchPlace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(searchPlace.SelectedIndex == 0))
        {
            searchDuration.SelectedIndex = 0;
            searchCategory.SelectedIndex = 0;

            List<Event> temp = new List<Event>();
            string key = searchPlace.SelectedValue.ToLower();
            foreach (Event eve in eventList)
            {
                if (eve.place.ToLower().Equals(key))
                {
                    temp.Add(eve);
                }
            }
            eventList = temp;
        }
    }
    protected void searchPrice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(searchPrice.SelectedIndex == 0))
        {
            searchDuration.SelectedIndex = 0;
            searchCategory.SelectedIndex = 0;
            searchPlace.SelectedIndex = 0;

            List<Event> temp = new List<Event>();
            int key = int.Parse(searchPrice.SelectedValue.ToString());
            if (key == 10)
            {
                foreach (Event eve in eventList)
                {
                    if (eve.price == 0)
                    {
                        temp.Add(eve);
                    }
                }
            }
            else if (key == 20)
            {
                foreach (Event eve in eventList)
                {
                    if (eve.price < 50)
                    {
                        temp.Add(eve);
                    }
                }
            }
            else if (key == 30)
            {
                foreach (Event eve in eventList)
                {
                    if (eve.price >= 50 && eve.price <= 100)
                    {
                        temp.Add(eve);
                    }
                }
            }
            else if (key == 40)
            {
                foreach (Event eve in eventList)
                {
                    if (eve.price > 100)
                    {
                        temp.Add(eve);
                    }
                }
            }
            eventList = temp;
        }
    }   
}