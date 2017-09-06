<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // 在应用程序启动时运行的代码

    }

    void Application_End(object sender, EventArgs e)
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码
        sign = 1;
        //Diya diya = new Diya();
        Exception ex = Server.GetLastError();
        string error = ex.Message;
        MySql.Data.MySqlClient.MySqlConnection.ClearAllPools();
        Exception objErr = Server.GetLastError().GetBaseException();
        string IP;
        //HttpRequest request = HttpContext.Current.Request;
        if(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]!="")
        {
            IP = Request.ServerVariables["REMOTE_ADDR"];
        }
        else
        {
            IP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
        if(IP==null||IP=="")
        {
            IP = Request.UserHostAddress;
        }
        System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
        xml.Load("MaintenanceLog.xml");
        
        Server.ClearError();
        //Response.Redirect("/robotTest/ERROR01.aspx");
    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码

    }
    int sign = 0;
    void Session_End(object sender, EventArgs e)
    {
        if (sign != 1)
        {
            try
            {
                Response.Redirect("Login.aspx");
            }
            catch (Exception)
            {
            }
        }
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。
    }

</script>
