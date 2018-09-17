using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyBookings : System.Web.UI.Page
{
    public List<Event> eventList = new List<Event>();
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
        User user = (User)Session["loggedUser"];
        DataOperations dop = new DataOperations();
        List<Event> temp = dop.getRegisteredEvents(user);
        if(temp != null && temp.Count > 0)
        {
            eventList = temp;
        }
    }
}