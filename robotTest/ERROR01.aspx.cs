using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Condition"] == "TimeOut")
        {
            Literal message = new Literal();
            message.Text = "<script>alert('�������ӳ�ʱ')</script>";
            this.Page.Controls.Add(message);
            Response.Redirect("ObjectTest.aspx");
        }
    }
}