using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class robotTest_ajaxrequest_s_time : System.Web.UI.Page
{
    public string echo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["getServerTime"] != null)
        {
            echo = "<rvalue>"+GetSeverTime(Request["getServerTime"]) + "<rvalue>";
        }
        else if (Request["getCodeTime"] != null)
        {
            echo = "<rvalue>" + GetCodeTime() + "<rvalue>";
        }
        else if (Request["clearSessionTime"] != null)
        {
            echo = "<rvalue>" + ClearSessionTime() + "<rvalue>";
        }
        else if (Request["getCode"] != null)
        {
            echo = "<rvalue>" + GetCode() + "<rvalue>";
        }
    }
    public int GetCodeTime()
    {
        return Convert.ToInt32(Session["Time"]);
    }
    public int GetSeverTime(string format)
    {
        //return Convert.ToInt32(DateTime.Now.ToString("mmss"));
        return Convert.ToInt32(DateTime.Now.ToString(format));
    }
    public int ClearSessionTime()
    {
        Session["Time"] = 0;
        return 0;
    }
    public string GetCode()
    {
        Random r = new Random(Convert.ToInt32(DateTime.Now.ToString("HHmmss")));
        Diya diya = new Diya();

        Session["Time"] = Convert.ToInt32(DateTime.Now.ToString("mmss"));
        string Code = "";
        int x = r.Next(1, 10);
        Session["Code"] = diya.GetMD5Text(x.ToString());
        ///Random r = new Random(Convert.ToInt32(DateTime.Now.ToString("HHmmss")));
        int sign1 = r.Next(0, 3);
        int sign2 = r.Next(0, 2);
        int y = 0;
        int t;
        switch (sign1)
        {
            case 0:
                t = r.Next(1, 10);
                y = x * t;
                Code += t + "#*#x";
                break;
            case 1:
                t = r.Next(1, 10);
                y = x + t;
                Code += "x#+#" + t;
                break;
            case 2:
                t = r.Next(1, 10);
                y = x - t;
                Code += "x#-#" + t;
                break;
            default:
                break;
        }
        switch (sign2)
        {
            case 0:
                t = r.Next(1, 10);
                y += t;
                Code += "#+" + t + "#" + y;
                break;
            case 1:
                t = r.Next(1, 10);
                y -= t;
                Code += "#-" + t + "#" + y;
                break;
        }

        return Code;
    }

}