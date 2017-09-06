using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_TIA_function_TestHisInfo_HTIAT : System.Web.UI.Page
{
    protected string echo = "";
    protected string tsid="73";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           tsid = Request["tsid"];
           this.etime.Value = Request["et"];
           this.stime.Value=Request["st"];
           GetTestData();
        }
    }
    protected void GetTestData()
    {
        using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand();
            scmd.Connection = sc;
            scmd.CommandText = "select count(*) as count from htrelationship where tsrelationshipid=" + tsid;

            MySqlDataReader testreader = scmd.ExecuteReader();
            testreader.Read();
            int hcount = Convert.ToInt32(testreader["count"]);
            testreader.Close();

            if (hcount != 0)
            {
                DataTable HTestIntotd = new DataTable();
                string command = "select topic.topiccontent as tname,topic.havecontent as flage,topic.morecontent as more, topic.topicid as tpid,htrelationship.selectedoptionid as soid from htrelationship inner join topic on topic.topicid=htrelationship.topicid where htrelationship.tsrelationshipid=" + tsid;
                scmd.CommandText = command;
                MySqlDataAdapter da = new MySqlDataAdapter(scmd);
                da.Fill(HTestIntotd);
                DataTable tSource = new DataTable();
                tSource.Columns.Add("tpid");
                string prvtpid = "";
                foreach (DataRow dr in HTestIntotd.Rows)
                {
                    if (dr["tpid"].ToString() != prvtpid)
                    {
                        tSource.Rows.Add(tSource.NewRow());
                        tSource.Rows[tSource.Rows.Count - 1]["tpid"] = dr["tpid"].ToString();
                        prvtpid = dr["tpid"].ToString();
                    }
                }
                int pageSize = 5;
                int PageCount = tSource.Rows.Count % pageSize == 0 ? tSource.Rows.Count / pageSize : (int)(tSource.Rows.Count / pageSize) + 1;
                this.PageCount.Text = "" + PageCount;
                int pageindex = 0;
                ListItem item = new ListItem((pageindex + 1) + "", pageindex + "");
                item.Selected = true;
                echo += "<div style=\"width:100%;display:block\" id=\"page" + pageindex + "\" >";
                this.PageSelect.Items.Add(item);
                for (int tindex = 0; tindex < tSource.Rows.Count; tindex++)
                {
                    if (tindex != 0 && tindex % pageSize == 0)
                    {
                        pageindex++;
                        item = new ListItem((pageindex + 1) + "", pageindex + "");
                        this.PageSelect.Items.Add(item);
                        echo += "</div>";
                        echo += "<div style=\"width:100%;display:none\" id=\"page" + pageindex + "\" >";
                    }
                    scmd.CommandText = "select topiccontent as tname,havecontent as flage, morecontent as more from topic where topicid=" + tSource.Rows[tindex]["tpid"];
                    MySqlDataReader read = scmd.ExecuteReader();
                    read.Read();
                    echo += "<div style=\"border:2px solid white; margin-bottom:5px;font-size:30px;margin-top:10px\" class=\"Topic\">";
                    echo += "<span style=\"color:#808080\">" + (tindex + 1) + "." + "</span>" + CheckText(read["tname"].ToString());
                    if (read["flage"].ToString() == "1")
                    {
                        echo += "<br/>" + CheckText(read["more"].ToString());
                    }
                    echo += "</div>";
                    read.Close();
                    DataTable SelectOptions = new DataTable();
                    scmd.CommandText = "select selectedoptionid as soid from htrelationship where topicid=" + tSource.Rows[tindex]["tpid"] + " and tsrelationshipid=" + tsid;
                    da.SelectCommand = scmd;
                    da.Fill(SelectOptions);

                    string selectedoptid = HTestIntotd.Rows[tindex]["soid"].ToString();
                    string Options = "select optionid as oid,optioncontent as content,istrue from options where topicid=" + tSource.Rows[tindex]["tpid"];
                    DataTable odt = new DataTable();
                    scmd.CommandText = Options;
                    da.SelectCommand = scmd;
                    da.Fill(odt);
                    int optindex = 0;
                    foreach (DataRow odr in odt.Rows)
                    {
                        char index = (char)('A' + optindex++);
                        if (CheckOptionsSelected(SelectOptions, odr["oid"].ToString()))
                        {
                            echo += " <div style=\"width:100%;border:2px solid #007acc;margin:5px;font-size:20px\" class=\"option_selected\">";
                        }
                        else
                        {
                            echo += "<div style=\"width:100%;border:2px solid white;margin:5px;font-size:20px\" class=\"option\">";
                        }
                        echo += "<span style=\"color:#00c7fe \">" + index + "</span>" + "." + CheckText(odr["content"].ToString());
                        if (odr["istrue"].ToString() == "1")
                        {
                            echo += "<span style=\"color:red\">--正确选项" + "</span>";
                        }
                        echo += "</div>";

                    }
                   


                }
                echo += "</div>";
                if(tSource.Rows.Count<=pageSize)
                {
                    PageNextBtn.Disabled = true;
                }
            }
            else
            {
                scmd.CommandText = "select topic.topiccontent,topic.havecontent,topic.morecontent,ttrelationship.relationshipid as ttrelationshipid from tsrelationship inner join ttrelationship on ttrelationship.testid=tsrelationship.testid inner join topic on topic.topicid=ttrelationship.topicid where tsrelationship.relationshipid="+tsid;
                DataTable test_t_info = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(scmd);
                da.Fill(test_t_info);
                int pagesize = 5;
                int PageCount = test_t_info.Rows.Count % pagesize == 0 ? test_t_info.Rows.Count / pagesize : (int)(test_t_info.Rows.Count / pagesize) + 1;
                this.PageCount.Text = PageCount+"";
                int pageindex = 0;
                ListItem item = new ListItem((pageindex + 1) + "", pageindex + "");
                item.Selected = true;
                this.PageSelect.Items.Add(item);
                echo += "<div style=\"width:100%;display:block\" id=\"page" + pageindex + "\" >";
                for(int tindex=0;tindex<test_t_info.Rows.Count;tindex++)
                {
                    if (tindex != 0 && tindex % pagesize == 0)
                    {
                        pageindex++;
                        item = new ListItem((pageindex + 1) + "", pageindex + "");
                        this.PageSelect.Items.Add(item);
                        echo += "</div>";
                        echo += "<div style=\"width:100%;display:none\" id=\"page" + pageindex + "\" >";
                    }

                    echo += "<div style=\"border:2px solid white; margin-bottom:5px;font-size:30px;margin-top:10px\" class=\"Topic\">";
                    echo += "<span style=\"color:#808080\">" + (tindex + 1) + "." + "</span>" + CheckText(test_t_info.Rows[tindex]["topiccontent"].ToString());
                    if (test_t_info.Rows[tindex]["havecontent"].ToString() == "1")
                    {
                        echo += "<br/>" + CheckText(test_t_info.Rows[tindex]["morecontent"].ToString());
                    }
                    echo += "</div>";
                    scmd.CommandText = "select options.optioncontent,options.istrue from options inner join otrelationship on otrelationship.optionid=options.optionid where otrelationship.ttrelationshipid=" + test_t_info.Rows[tindex]["ttrelationshipid"].ToString() ;
                    DataTable odt = new DataTable();
                    da.SelectCommand = scmd;
                    da.Fill(odt);
                    int optindex = 0;
                    foreach (DataRow odr in odt.Rows)
                    {
                        char index = (char)('A' + optindex++);
                        echo += "<div style=\"width:100%;border:2px solid white;margin:5px;font-size:20px\" class=\"option\">";
                        echo += "<span style=\"color:#00c7fe \">" + index + "</span>" + "." + CheckText(odr["optioncontent"].ToString());
                        if (odr["istrue"].ToString() == "1")
                        {
                            echo += "<span style=\"color:red\">--正确选项" + "</span>";
                        }
                        echo += "</div>";

                    }
                }
                echo += "</div>";
                if (test_t_info.Rows.Count<=pagesize)
                {
                    PageNextBtn.Disabled = true;
                }
            }
            
        }
    }
    protected string CheckText(string text)
    {
        //string html = "";
        text = text.Replace("&", "&amp;");
        text = text.Replace("\"", "&quot;");        
        text=text.Replace("<", "&lt;");
        text=text.Replace(">","&gt;");
        text=text.Replace("\n","<br/>");
        text = text.Replace(" ","&nbsp;");
        text = text.Replace("Λ", "&Lambda;");
        text = text.Replace("∩", "&cap;");
        text = text.Replace("∪", "&cup;");
        return text;
    }
    protected bool CheckOptionsSelected(DataTable options,string optid)
    {
        bool flage = false;
        foreach(DataRow dr in options.Rows)
        {
            if(dr["soid"].ToString()==optid)
            {
                flage = true;
                break;
            }
        }
        return flage;
    }


}