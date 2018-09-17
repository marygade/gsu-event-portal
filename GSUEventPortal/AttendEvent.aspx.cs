using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AttendEvent : System.Web.UI.Page
{
    public Event eve = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loggedUser"] != null)
        {
            if (((User)Session["loggedUser"]).type.Equals("admin"))
            {
                Response.Redirect("index.aspx");
            }
            else
            {

            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }
        User user = ((User)Session["loggedUser"]);
        int eventId = int.Parse(Request["eventid"].ToString());
        DataOperations dop = new DataOperations();
        Event ev = dop.getEvent(eventId);
        int numberoftickets = int.Parse(Request["numberoftickets"].ToString());
        dop.registerForEvent(eventId, user.id, numberoftickets);

        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(user.email);
            NetworkCredential nc = new NetworkCredential("email@gmail.com", "password");
            mailMessage.From = new MailAddress("admi@eventportal.com");
            mailMessage.Subject = "Booking for event " + ev.name;
            mailMessage.Body = "Hello " + user.name + "\n\n";
            mailMessage.Body += "You booked " + numberoftickets + " for event " + ev.name + ".\n\n";
            mailMessage.Body += "Place : " + ev.place + ". Date : " + ev.date + " Time : " + ev.start_time + ". Duration : " + ev.duration + ".\n\n";
            mailMessage.Body += "\n\nThank you\nGSU Event Portal";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = nc;
            smtpClient.Send(mailMessage);
            mailMessage.IsBodyHtml = true;
            //Response.Write("E-mail sent!");
        }
        catch (Exception ex)
        {
            Response.Write("Could not send the e-mail - error: " + ex.Message);
        }
        
        Session["eventRegistered"] = "Your booking is successful!!! :)";
        Response.Redirect("MyBookings.aspx");
    }
}