using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class robotTest_TIA_function_TestHisInfo_main : System.Web.UI.Page
{
    protected string echo = "";
    string uid ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            uid = Request["uid"];
            if (Request["d"] == "1")
            {
                this.endTime.Value = "" + DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                this.startTime.Value = "" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00");
            }
            else
            {
                this.endTime.Value =Request["et"];
                this.startTime.Value=Request["st"];
            }
            getTestInfo();
        }
     

    }
    
    protected void getTestInfo()
    {
        using (MySqlConnection sc=new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            string SelectCommand = "select tsrelationship.completiontime as time,testinfo.testname as name,testInfo.testcount as count,tsrelationship.score as acr,tsrelationship.relationshipid as tsid from testinfo inner join tsrelationship on tsrelationship.testid=testinfo.testid where tsrelationship.contactid=" + uid + " and tsrelationship.completiontime between '" + this.startTime.Value + "' and '" + this.endTime.Value + "' order by tsrelationship.completiontime desc";
            MySqlCommand scmd = new MySqlCommand();
            scmd.Connection = sc;
            scmd.CommandText = SelectCommand;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(scmd);
            da.Fill(dt);
            int page = 0;
            int rowcount = dt.Rows.Count;
            if(rowcount==0)
            {
                echo += "没有发现记录";
                this.PageNextBtn.Disabled = true;
                this.PageFrontBtn.Disabled = true;
            }
            int pagesize = 5;
            int pagecount = rowcount % pagesize == 0 ? rowcount / pagesize :(int)(rowcount / pagesize) + 1;
            ListItem item = new ListItem("1","0");
            echo += "<div id=\"page" + page + "\">";
            this.PageSelect.Items.Add(item);
            this.PageCount.Text = pagecount+"";
            for(int i=0;i<rowcount;i++)
            {
                if (i % (pagesize) == 0&&i!=0)
                {
                    page++;
                    echo += "</div>";
                    echo += "<div id=\"page" + page + "\" style=\"display:none;\">";
                    item = new ListItem((page + 1) + "", page + "");
                    this.PageSelect.Items.Add(item);
                }
                echo += " <div style=\"width:98%;margin-bottom:10px;margin-left:auto;margin-right:auto\" id=\""+dt.Rows[i]["tsid"]+"\">";
                echo += " <div style=\"width:100%;text-align:center;background-color:gray;color:white;\" class=\"title\">"+dt.Rows[i]["name"]+"</div>";
                echo += " <table border=\"1\" style=\"width:100%;border:1px solid gray;text-align:center\">";
                echo += "<thead>";
                echo += "<tr>";
                echo += "<td>提交时间</td>";
                echo += " <td>题目总数</td>";
                echo += "<td>正确数</td>";
                echo += "<td></td>";
                echo += "<td></td>";
                echo += "</tr>";
                echo += "</thead>";
                echo += "<tbody>";
                echo += "<tr>";
                echo += "<td>";
                echo += ""+dt.Rows[i]["time"];
                echo += "</td>";
                echo += "<td>";
                echo += ""+dt.Rows[i]["count"];
                echo += "</td>";
                echo += "<td>";
                echo += ""+dt.Rows[i]["acr"];
                echo += "</td>";
                echo += "<td>";
                echo += "<a href=\"javascript:void(0);\" style=\"color:gray\" onclick=\"GetTest('" + dt.Rows[i]["tsid"]+"')\">查看考试</a> ";
                echo += "</td>";
                echo += "<td>";
                echo += " <a href=\"javascript:void(0);\" style=\"color:gray\" onclick=\"SeeMore('" + dt.Rows[i]["tsid"] + "')\">更多</a>";
                echo += "</td>";
                echo += "</tr>";
                echo += "</tbody>";
                echo += "</table>";
                echo += "</div>";
                echo += "<div id=\""+dt.Rows[i]["tsid"]+"more\" style=\"width:100%\" class=\"void\">";
                echo += "</div>";
                //echo += "</div>";
            }
            echo += "</div>";
        }
    }


}