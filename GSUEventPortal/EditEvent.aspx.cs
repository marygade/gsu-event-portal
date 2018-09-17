using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditEvent : System.Web.UI.Page
{
    public Event eve;
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
        DataOperations dop = new DataOperations();
        int eventId = int.Parse(Request["id"].ToString());
        eve = dop.getEvent(eventId);
        if(eve == null)
        {
            Response.Redirect("MyEvents.aspx");
        }
        else
        {
            if(!IsPostBack)
            {
                eventName.Value = eve.name;
                place.Value = eve.place;
                category.Value = eve.category_name;
                date.Value = eve.date;
                hours.Value = eve.start_time.Substring(0, eve.start_time.IndexOf(':'));
                minutes.Value = eve.start_time.Substring(eve.start_time.IndexOf(':') + 1);
                duration.Value = eve.duration.ToString();
                price.Value = eve.price.ToString();
            }
        }
    }
    protected void editEvent_Click(object sender, EventArgs e)
    {
        User user = (User)Session["loggedUser"];
        DataOperations dop = new DataOperations();
        int eventId = int.Parse(Request["id"].ToString());
        eve = dop.getEvent(eventId);

        
        string cn = category.Value;
        string pl = place.Value;
        string dt = date.Value;
        int st = int.Parse(hours.Value.ToString());
        int min = int.Parse(minutes.Value.ToString());
        string strtime = st + ":" + min;
        int dr = int.Parse(duration.Value.ToString());


        eve.category_name = cn;
        eve.place = pl;
        eve.date = dt;
        eve.start_time = strtime;
        eve.duration = dr;

        if (dop.editEvent(eve))
        {
            Response.Redirect("MyEvents.aspx");
        }
        else
        {
            errorMsg.InnerText = "Please try again";
        }
    }
}