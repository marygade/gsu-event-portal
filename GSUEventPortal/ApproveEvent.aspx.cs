using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApproveEvent : System.Web.UI.Page
{
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
        int eventId = int.Parse(Request["id"].ToString());
        DataOperations dop = new DataOperations();
        dop.approveEvent(eventId);
        Response.Redirect("PendingEvents.aspx");
    }
}