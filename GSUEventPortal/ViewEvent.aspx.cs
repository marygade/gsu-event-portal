using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewEvent : System.Web.UI.Page
{
    public Event eve = null;
    public List<string> userNames = new List<string>();
    public User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["loggedUser"] != null)
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
        }*/
        if (Session["loggedUser"] != null)
        {
            user = ((User)Session["loggedUser"]);
        }
        
        int eventId = int.Parse(Request["id"].ToString());
        DataOperations dop = new DataOperations();
        eve = dop.getEvent(eventId);
        List<User> temp = dop.getRegisteredUserForEvent(eventId);
        foreach(User u in temp)
        {
            userNames.Add(u.name);
        }
    }
    protected void btnAttend_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout.aspx?id=" + Request["id"]);
    }
}