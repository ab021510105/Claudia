using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class robotTest_TIA_function_TestHisInfo_MoreInfo : System.Web.UI.Page
{
    protected string echo = "";
    protected string tsid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            tsid += Request["tsid"];
            GetKnowCount();
        }
    }
    protected int GetKnowledgepointCount(string Knowledgeid )
    {
        int count = 0;
        string knowLedgePoint = " select count(*) as count from htrelationship inner join tkrelationship on tkrelationship.topicid=htrelationship.topicid inner join options on options.optionid=htrelationship.selectedoptionid where htrelationship.tsrelationshipid=" + tsid + "  and tkrelationship.knowledgepointid=" + Knowledgeid;
        using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand(knowLedgePoint, sc);
            MySqlDataReader read = scmd.ExecuteReader();
            read.Read();
            count = Convert.ToInt32(read["count"]);
        }
        return count;
    }


    protected int GetKnowledgepointCount_r(string Knowledgeid)
    {
        int count = 0;
        string knowLedgePoint = " select count(*) as count from htrelationship inner join tkrelationship on tkrelationship.topicid=htrelationship.topicid inner join options on options.optionid=htrelationship.selectedoptionid where htrelationship.tsrelationshipid="+tsid+" and options.isTrue=1 and tkrelationship.knowledgepointid="+Knowledgeid;
        using(MySqlConnection sc=new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand(knowLedgePoint, sc);
            MySqlDataReader read = scmd.ExecuteReader();
            read.Read();
            count = Convert.ToInt32(read["count"]);
        }
        return count;
    }
    protected void GetKnowCount()
    {
        string GetTestInfo = "Select testinfo.testid,testinfo.testname from tsrelationship inner join testinfo on testinfo.testid=tsrelationship.testid where tsrelationship.relationshipid=" + tsid;
        using(MySqlConnection sc=new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand();
            scmd.CommandText = GetTestInfo;
            scmd.Connection = sc;
            MySqlDataReader read = scmd.ExecuteReader();
            read.Read();
            string TestName=read["testname"].ToString();
            string TestId = read["testid"].ToString();
            read.Close();
            string GetKpoints = "select  distinct  knowledgepoint.knowledgepointname as name,knowledgepoint.knowledgepointid as id from ttrelationship inner join topic on topic.topicid=ttrelationship.topicid inner join tkrelationship on tkrelationship.topicid=topic.topicid inner join knowledgepoint on knowledgepoint.knowledgepointid=tkrelationship.knowledgepointid  where ttrelationship.testid=" + TestId + " order by tkrelationship.knowledgepointid desc";
            DataTable knowledgeTable = new DataTable();
            scmd.CommandText = GetKpoints;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = scmd;
            da.Fill(knowledgeTable);
            int index=0;
            DataTable SourceTable = new DataTable();
            double[] Kcount = new double[knowledgeTable.Rows.Count];
            foreach(DataRow knowledgename in knowledgeTable.Rows)
            {
                SourceTable.Columns.Add(knowledgename["name"].ToString());
                int kCount = GetKnowledgepointCount(knowledgename["id"].ToString());
                Kcount[index++] = (float)GetKnowledgepointCount_r(knowledgename["id"].ToString()) / kCount*100;
            }
            SourceTable.Rows.Add(SourceTable.NewRow());
            for(int i=0;i<Kcount.Length;i++)
            {
                string item= Math.Round(Kcount[i])+"%";
                SourceTable.Rows[0][i] = item;
            }
            echo += "<div style=\"width:auto;margin-bottom:10px;margin-left:auto;margin-right:auto\" id=\"" +tsid + "Info\">";
            echo += "<div style=\"width:100%;text-align:center;background-color:gray;color:white;\" class=\"title\">"+TestName+"的统计"+"</div>";
            echo += "<table border=\"1\" style=\"width:100%;border:1px solid gray;text-align:center\">";
            echo += "<thead>";
            echo += "<tr>";
            foreach(DataColumn dc in SourceTable.Columns)
            {
                echo += "<td>"+dc.ColumnName+"</td>";
            }
            echo += "</tr>";
            echo += "</thead>";
            echo += "<tbody>";
            echo += "<tr>";
            for(int i=0;i<SourceTable.Columns.Count;i++)
            {
                echo += "<td>"+SourceTable.Rows[0][i]+"</td>";
            }
            echo += "</tr>";
            echo += "</tdoby>";
            echo += "</table>";
            echo += "</div>";
        }

    }




}