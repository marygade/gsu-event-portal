using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingEvents : System.Web.UI.Page
{
    public List<Event> eventList = new List<Event>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loggedUser"] != null)
        {
            if (((User)Session["loggedUser"]).type.Equals("admin"))
            {
                
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }
        User user = (User)Session["loggedUser"];
        DataOperations dop = new DataOperations();
        List<Event> temp = dop.getEvents();
        if (temp != null && temp.Count > 0)
        {
            foreach (Event eve in temp)
            {
                if (eve.approved == 0)
                {
                    eventList.Add(eve);
                }
            }
        }
    }
}