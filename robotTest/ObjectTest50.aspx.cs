using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class robotTest_ObjectTest50 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["LandInfo"]==null)
        {
           Response.Redirect("Login.aspx");
        }
        this.userid_lab.Text=this.userid.Value = Session["LandInfo"].ToString();
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
    protected void LogOut_Click1(object sender, EventArgs e)
    {
        
    }
}