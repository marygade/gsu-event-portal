using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["loggedUser"] != null)
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
    }
    protected void createEvent_Click(object sender, EventArgs e)
    {
        if(coverImage.HasFile)
        {
            User user = (User)Session["loggedUser"];
            string en = eventName.Value;
            string cn = category.Value;
            string pl = place.Value;
            string dt = date.Value;
            int st = int.Parse(hours.Value.ToString());
            int min = int.Parse(minutes.Value.ToString());
            string strtime = st + ":" + min;
            int dr = int.Parse(duration.Value.ToString());
            int pr = int.Parse(price.Value.ToString());
            string desc = description.Value;
            string ci = coverImage.FileName;
            int user_id = user.id;
            DataOperations dop = new DataOperations();
            string path = Server.MapPath("~/uploads/" + user_id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            coverImage.SaveAs(path + "/" + ci);
            Event eve = new Event(0, user_id, en, desc, cn, pl, dt, strtime, dr, pr, user_id + "/" + ci, 0);
            if(dop.createEvent(eve))
            {
                Session["eventCreated"] = "Event Created Successfully. Sent for admin Approval.";
                Response.Redirect("MyEvents.aspx");
            }
            else
            {
                errorMsg.InnerText = "Please try again";
            }
        }
        else
        {
            errorMsg.InnerText = "Please select a cover image";
        }
    }
}