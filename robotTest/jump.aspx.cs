using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class jump : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Condition"] == "TimeOut")
        {
            this.labelinfo.InnerText = "ObjectTest.aspx";
            //object answer = AnsStates.Read();
            DataTable dt = (DataTable)Session["UploadTable"];
            string TestRelationship = Session["TestRelationshipID"].ToString();
            Lock.UpdateAnswers update = new Lock.UpdateAnswers();
            bool sec = update.InOrder(dt, TestRelationship);
            int times = 0;
            int Sleep = 0;
            while(!sec&&times<4)
            {
                Sleep += 1000;
                System.Threading.Thread.Sleep(Sleep);
                sec = update.InOrder(dt, TestRelationship);
                times++;
            }
            Session["UploadTable"] = null;
            Session["TestRelationshipID"] = null;
        }
    }
}