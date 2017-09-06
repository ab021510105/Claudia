using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;

public partial class robotTest_TIA_function_overview : System.Web.UI.Page
{
    string studentid ;
    protected void Initial()
    {

       //this.TestCountChart.Series["Count_s"].IsValueShownAsLabel = true;
       //this.TestCountChart.ChartAreas["Count_Sa"].AxisX.TitleAlignment = StringAlignment.Far;
       //this.TestCountChart.ChartAreas["Count_Sa"].AxisY.TitleAlignment = StringAlignment.Far;
       //this.TestCountChart.ChartAreas["Count_Sa"].AxisX.Interval = 1;//X轴数据的间距
       // this.TestCountChart.ChartAreas["Count_Sa"].AxisY.Title = "准确率（%）";
       // this.TestCountChart.ChartAreas["Count_Sa"].AxisX.Title = "练习";
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initial();
        if (!this.IsPostBack)
        {
            studentid = Request["uid"];
            //studentid = "15050003";
            string[] testNames = new string[10];
            float[] scoure = new float[10];
            int i = 9;
            Array.Clear(testNames, 0, testNames.Length);
            Array.Clear(scoure, 0, scoure.Length);
            string getTest = "select testinfo.testcount, testinfo.testid,testinfo.teststarttime,testinfo.testname,tsrelationship.relationshipid from tsrelationship inner join testinfo on testinfo.testid=tsrelationship.testid where tsrelationship.contactid=" + studentid + " order by testinfo.teststarttime desc limit 5";
            using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString)) 
            {
                sc.Open();
                MySqlCommand scmd = new MySqlCommand();
                scmd.Connection = sc;
                scmd.CommandText = getTest;
                DataTable testsTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(scmd);
                da.Fill(testsTable);
                foreach (DataRow TestInfo in testsTable.Rows)
                {
                    //当前的题目和选中的答案
                    string TsRelationshipID = TestInfo["relationshipid"].ToString();
                    float TopicCount = Convert.ToInt32(TestInfo["testcount"]);
                    string GetSelection = "select topicid ,selectedoptionid from htrelationship where tsrelationshipid=" + TsRelationshipID + " order by topicid";
                    DataTable SelectionTable = new DataTable();
                    scmd.CommandText = GetSelection;
                    da.SelectCommand = scmd;
                    da.Fill(SelectionTable);
                    int selectionHit = 0;
                    string fontTopic = "-1";
                    //判题
                    foreach (DataRow selecion in SelectionTable.Rows)
                    {
                        //当前已选择的选项
                        if (selecion["topicid"].ToString() == fontTopic)
                        {
                            continue;
                        }
                        fontTopic = selecion["topicid"].ToString();
                        string GetOptions = "select selectedoptionid from htrelationship where tsrelationshipid=" + TsRelationshipID + " and topicid=" + selecion["topicid"].ToString();
                        scmd.CommandText = GetOptions;
                        da.SelectCommand = scmd;
                        DataTable Options = new DataTable();
                        da.Fill(Options);
                        bool pass = true;
                        foreach (DataRow option in Options.Rows)
                        {
                            string optid = option["selectedoptionid"].ToString();
                            scmd.CommandText = "select istrue from options where optionid=" + optid;
                            MySqlDataReader read = scmd.ExecuteReader();
                            read.Read();
                            if (read["istrue"].ToString() == "0")
                            {
                                pass = false;
                                read.Close();
                                break;
                            }
                            read.Close();
                        }
                        if (pass)
                            selectionHit++;
                    }
                    double score = Math.Round(((selectionHit) / TopicCount) * 100.0, 2);
                    testNames[i] = TestInfo["testname"].ToString();
                    scoure[i--] = (float)score;
                }
            }
            DataTable tcdt = new DataTable();
            tcdt.Columns.Add("value");
            tcdt.Columns.Add("name");
            for (int j = 0; j < 5; j++)
            {
                DataRow dr = tcdt.NewRow();
                if (scoure[j] != 0)
                {
                    //this.OverViewTestScore.Value += scoure[j]+"#";
                    dr["value"] = scoure[j];
                }
                else
                {
                    //this.OverViewTestScore.Value += "0#";\
                    dr["value"] = "0";
                }
                if (testNames[j] != null)
                {
                    //this.OverViewTestRow.Value += testNames+"#";
                    dr["name"] = testNames[j];
                }
                else
                {
                    //this.OverViewTestRow.Value += "unknow"+"#";
                    dr["name"] = "unknow";
                }
                tcdt.Rows.Add(dr);
            }
            foreach(DataRow dr in tcdt.Rows)
            {
                this.OverViewTestName.Value += dr["name"]+"#";
                this.OverViewTestValue.Value += dr["value"]+"#";
            }
           // this.TestCountChart.DataSource = tcdt;
            //this.TestCountChart.Series[0].XValueMember = "name";
            //this.TestCountChart.Series[0].YValueMembers = "value";
            getKnowledgePointPercent();
        }
    }
    protected void getKnowledgePointPercent()
    {
        using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            DataTable GvDataSource = new DataTable();
            string getKnowledges = "select Knowledgepoint.knowledgepointname as name ,options.istrue from tsrelationship inner join htrelationship on tsrelationship.relationshipid=htrelationship.tsrelationshipid inner join tkrelationship on tkrelationship.topicid=htrelationship.topicid inner join knowledgepoint on knowledgepoint.knowledgepointid=tkrelationship.knowledgepointid inner join options on options.optionid=htrelationship.selectedoptionid inner join testinfo on testinfo.testid=tsrelationship.testid where tsrelationship.contactid="+studentid+" and testinfo.teststarttime between '"+DateTime.Now.AddMonths(-1).ToShortDateString()+ "' and '"+DateTime.Now.ToShortDateString()+"' order by knowledgepoint.knowledgepointid asc";
            MySqlCommand scmd = new MySqlCommand(getKnowledges, Sc);
            DataTable Knowledges = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(scmd);
            da.Fill(Knowledges);
            string knowledgename = "";
            int knowledgecount = 0;
            int knowledgehit = 0;
            string Knames="";
            string scores = "";
            string counts = "";
            string hits = "";
            //DataView dv = new DataView(Knowledges);
            //Knowledges = dv.ToTable(true, "name");
            foreach(DataRow knowledge in Knowledges.Rows)
            {
                if (knowledge["name"].ToString() == knowledgename)
                {
                    knowledgecount ++;
                    if (knowledge["istrue"].ToString() == "1")
                    {
                        knowledgehit ++;
                    }
                }
                else
                {
                    if (knowledgename != "")
                    {
                        Knames += knowledgename + "#";
                        scores += ((knowledgehit / (float)knowledgecount) * 100) + "#";
                        counts += knowledgecount+"#";
                        hits += knowledgehit + "#";
                    }
                    knowledgecount = 1;
                    if(knowledge["istrue"].ToString()=="1")
                    {
                        knowledgehit = 1;
                    }
                    else
                    {
                        knowledgehit = 0;
                    }
                    knowledgename = knowledge["name"].ToString();
                }
            }
            GvDataSource.Columns.Add("KnowledgeName");
            GvDataSource.Columns.Add("KnowledgeCount");
            GvDataSource.Columns.Add("KnowledgeHit");
            GvDataSource.Columns.Add("KnowledgeLevel");
            GvDataSource.Columns.Add("KnowledgeScore");
            for(int i=0;i<Knames.Split(new char[]{'#'}).Length;i++)
            {
                string name = Knames.Split(new char[] { '#' })[i];
                string score = scores.Split(new char[] { '#' })[i];
                string count = counts.Split(new char[] { '#' })[i];
                string hit = hits.Split(new char[] { '#' })[i];
                if(name!="")
                {
                    GvDataSource.Rows.Add(GvDataSource.NewRow());
                    GvDataSource.Rows[GvDataSource.Rows.Count - 1]["KnowledgeName"] = name;
                    GvDataSource.Rows[GvDataSource.Rows.Count - 1]["KnowledgeCount"] = count;
                    GvDataSource.Rows[GvDataSource.Rows.Count - 1]["KnowledgeHit"] = hit;
                    GvDataSource.Rows[GvDataSource.Rows.Count - 1]["KnowledgeScore"] = score;
                    scmd.CommandText = "select gradename from grade where minscore= (select max(minscore) from grade where minscore<="+score+");";
                    MySqlDataReader read = scmd.ExecuteReader();
                    read.Read();
                    GvDataSource.Rows[GvDataSource.Rows.Count - 1]["KnowledgeLevel"] = read["gradename"].ToString();
                    read.Close();
                }
            }
            this.TestCount.DataSource = GvDataSource;
            this.TestCount.DataBind();
        }
    }



}