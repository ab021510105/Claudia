using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using MySql.Data.MySqlClient;

public partial class error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string error = "'Access failed\\n";
        if (Request["error"] != null)
        {
            if (Request["error"] == "00")
            {
                this.errortex.Text= error += "SqlServer服务器连接失败!\n";
            }
            else if (Request["error"] == "01")
            {
                error += "身份验证失败，禁止访问\\n";
            }
            else if (Request["error"] == "02")
            {
                error += "获取本地用户名失败!,无法连接本地与远程的sqlserver\\n";
            }
            else if (Request["error"] == "03")
            {
                error += "远程sqlserver连接失败，尝试连接本地sqlserver失败!\\n";
            }
            else if (Request["error"] == "04")
            {
                error += "gridview 字段绑定失败!\\n";
            }
            else if (Request["error"] == "05")
            {
                error += @"无法绑定字段到详细列表\n";
            }
            error += "ErrorCode:"+Request["error"] + "'";
            Literal MeGTex = new Literal();
            MeGTex.Text = "<script>alert(" + error + "); top.location = 'land.aspx';</script>";
            Page.Controls.Add(MeGTex);
        }
        else
        {
            Response.Redirect("land.aspx");
        }

    }
}