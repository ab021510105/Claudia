using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_TIA_function__TIA_TIA : System.Web.UI.Page
{
    protected string echo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string stid = Request["stid"];
            this._stid.Value = stid;
            StartTest(stid);
        }
    }

    protected void StartTest(string stid)
    {
        using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlCommand Scmd = new MySqlCommand("select testid from TSRelationship where RelationshipID=" + stid, Sc);
            MySqlDataReader read = Scmd.ExecuteReader();
            read.Read();
            string TestID = read["testid"].ToString();
            read.Close();
            this.testid.Value = TestID;
            string GetTopic = "select topic.topicId,topic.topicContent,topic.haveContent,topic.moreContent ,ttrelationship.relationshipId from TTRelationship inner join Topic on Topic.TopicID = TTRelationship.TopicID where TTRelationship.TestID="+TestID;
            Scmd.CommandText = GetTopic;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(Scmd);
            da.Fill(dt);
            int PageSize = 5;
            int PageCount = dt.Rows.Count % PageSize == 0 ? dt.Rows.Count / PageSize : (int)(dt.Rows.Count / PageSize)+1;
            this.PageCount.Text = PageCount + "";
            int pindex = 0;
            int tindex = 1;
            
            echo += "<div style=\'display:block; width:100%\' id=\'page" + pindex + "\'>";
            ListItem item = new ListItem((pindex + 1) + "", pindex + "");
            item.Selected = true;
            this.PageSelect.Items.Add(item);
            for(tindex=0;tindex<dt.Rows.Count;tindex++)
            {
                if(tindex!=0&&tindex%PageSize==0)
                {
                    pindex++;
                    item = new ListItem((pindex + 1) + "", pindex + "");
                    this.PageSelect.Items.Add(item);
                    echo += "</div>";
                    echo += "<div style=\"width:100%;display:none\" id=\"page" + pindex + "\" >";
                }
                //InsertTopicContent
                echo += "<div id=\"t"+dt.Rows[tindex]["topicId"]+"\" class=\"topicContent\">";
                echo += "<div style=\"border:2px solid white; margin-bottom:5px;font-size:30px;margin-top:10px\" class=\"Topic\" id=\""+dt.Rows[tindex]["topicId"]+"\">";
                echo += "<span style=\"color:#808080\">" + (tindex + 1) + "." + "</span>" + CheckText(dt.Rows[tindex]["topicContent"].ToString());
                if(dt.Rows[tindex]["haveContent"].ToString()=="1")
                {
                    echo += "</br>"+CheckText(dt.Rows[tindex]["moreContent"].ToString());
                }
                echo += "</div>";
                string GetOptions = "select Options.optionId,Options.optionContent from OTRelationship inner join Options on OTRelationship.OptionID=Options.OptionID where TTRelationshipID=" + dt.Rows[tindex]["relationshipId"].ToString();
                Scmd.CommandText = GetOptions;
                DataTable odt = new DataTable();
                da.SelectCommand = Scmd;
                da.Fill(odt);
                int oindex = 0;
                foreach(DataRow odr in odt.Rows)
                {
                    string oid = "op" + odr["optionId"];
                    echo += "<div style=\"width:100%;border:2px solid white;margin:5px;font-size:20px\" class=\"option\" title=\"unselected\"  id=\"" + oid + "\" onclick=\"OnOptClick('" + oid + "')\" onmouseover=\"OnMouseIn('" + oid + "')\" onmouseout=\"OnMouseOut('"+oid+"')\">";
                    echo += "<span style=\"color:#00c7fe \">" + (char)(oindex + 'A') + "</span>." + CheckText(odr["optionContent"].ToString());
                    echo += "</div>";
                    oindex++;
                }
                echo += "</div>";
            }
            echo += "</div>";
        }

        return;
    }
    protected string CheckText(string text)
    {
        //string html = "";
        text = text.Replace("&", "&amp;");
        text = text.Replace("\"", "&quot;");
        text = text.Replace("<", "&lt;");
        text = text.Replace(">", "&gt;");
        text = text.Replace("\n", "<br/>");
        text = text.Replace(" ", "&nbsp;");
        text = text.Replace("Λ", "&Lambda;");
        text = text.Replace("∩", "&cap;");
        text = text.Replace("∪", "&cup;");
        return text;
    }
}