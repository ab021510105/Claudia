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
                this.errortex.Text= error += "SqlServer����������ʧ��!\n";
            }
            else if (Request["error"] == "01")
            {
                error += "�����֤ʧ�ܣ���ֹ����\\n";
            }
            else if (Request["error"] == "02")
            {
                error += "��ȡ�����û���ʧ��!,�޷����ӱ�����Զ�̵�sqlserver\\n";
            }
            else if (Request["error"] == "03")
            {
                error += "Զ��sqlserver����ʧ�ܣ��������ӱ���sqlserverʧ��!\\n";
            }
            else if (Request["error"] == "04")
            {
                error += "gridview �ֶΰ�ʧ��!\\n";
            }
            else if (Request["error"] == "05")
            {
                error += @"�޷����ֶε���ϸ�б�\n";
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