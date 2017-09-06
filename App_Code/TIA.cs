using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;

/// <summary>
/// TIA 的摘要说明
/// </summary>
[Serializable]
public  class TIA
{
    public  DataStates Dst = new DataStates();
    /// <summary>
    ///  所有的选项情况都记录在这里
    /// </summary>
    public DataTable dt = new DataTable();
    /// <summary>
    /// 每题在dt缓存中的下标列表
    /// </summary>
    public DataTable indexList = new DataTable();
    public void BindQuizes(string TestID)
    {
        indexList.Columns.Add("Index");
        dt.Columns.Add("TopicID");
        dt.Columns.Add("OptionID");
        dt.Columns.Add("Selected");
        dt.Columns.Add("Index");
        dt.Columns["Index"].DefaultValue = 0;
        dt.Columns["Selected"].DefaultValue = 0;
        string SelectCmd = "Select TTRelationship.RelationshipID,Topic.TopicID,Topic.TopicContent,Topic.HaveContent,Topic.MoreContent From TTRelationship inner join Topic on TTRelationship.TopicID=Topic.TopicID where TTRelationship.TestID="+TestID;
        char OptionC = Convert.ToChar(20);
        char TopicC = Convert.ToChar(17);
        char OPidC = Convert.ToChar(19);
        char Op = Convert.ToChar(21);
        char TopicIDc = Convert.ToChar(18);
        string buf = "";
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            DataSet Ds = new DataSet();
            MySqlDataAdapter Da = new MySqlDataAdapter(SelectCmd, Sc);
            Da.Fill(Ds);
            int index = 0;
              foreach(DataRow Dr in Ds.Tables[0].Rows)  //获取所有题目
            {
                //QuizCount++;
                buf += UpdateEnter(Dr["TopicContent"].ToString());
                if (Dr["HaveContent"].ToString() == "1")
                {
                    buf += UpdateEnter("\n"+Dr["MoreContent"].ToString());
                }
                buf += TopicIDc;
                buf+=Dr["TopicID"].ToString();
                buf+=OptionC;
                using (MySqlConnection Scq = new MySqlConnection(Diya.ConectionString))
                {
                    Scq.Open();
                    MySqlCommand Scmd1 = new MySqlCommand("Select Options.OptionID,Options.OptionContent From Options inner join OTRelationship on OTRelationship.OptionID=Options.OptionID Where OTRelationship.TTRelationshipID=" + Dr["RelationshipID"].ToString(), Scq);//选项查询
                    MySqlDataReader read2 = Scmd1.ExecuteReader();
                    indexList.Rows.Add(indexList.NewRow()); 
                    indexList.Rows[indexList.Rows.Count - 1][0] = index;                   
                    while (read2.Read())//选项
                    {
                        buf += UpdateEnter(read2["OptionID"].ToString() + Convert.ToChar(19) + read2["OptionContent"].ToString() + Convert.ToChar(21));
                        dt.Rows.Add(dt.NewRow());
                        dt.Rows[dt.Rows.Count - 1]["TopicID"] = Dr["TopicID"];
                        dt.Rows[dt.Rows.Count - 1]["OptionID"] = read2["OptionID"];
                        index++;
                    }
                   
                    buf += TopicC;
                   
                }

            }
            string[] Topics = buf.Split(new char[] { Convert.ToChar(17) });
            //int[] TopicsIndex = new int[Topics.Length-1];
            //for (int i = 0; i < TopicsIndex.Length; i++) //随机
            //{
            //    Random r = new Random();
            //    TopicsIndex[i] = r.Next(0, Topics.Length-1);
            //    for (int j = 0; j <= i - 1; j++)
            //    {
            //        if (TopicsIndex[i] == TopicsIndex[j])
            //        {
            //            TopicsIndex[i] = r.Next(0, Topics.Length-1);
            //            j = -1;
            //        }

            //    }
            //}
                 //开始写页面
            int TestCount;
            using (MySqlConnection inSc= new MySqlConnection(Diya.ConectionString))
            {
                inSc.Open();
                MySqlCommand Scmd=new MySqlCommand("select TestCount from TestInfo where TestID="+TestID,inSc);
                MySqlDataReader read = Scmd.ExecuteReader();
                if (read.Read())
                {
                    TestCount = read.GetInt32(0);
                }
                else
                {
                    TestCount = 0;
                }
                QuizCount = TestCount;
            }
            if (TestCount > Topics.Length - 1)
            {
                TestCount = Topics.Length - 1;
            }
            for (int i = 0; i < TestCount; i++)
            {
                string Quizes = "";
                //string[] Topic = Topics[TopicsIndex[i]].Split(new char[] { Convert.ToChar(20) });
                string[] Topic = Topics[i].Split(new char[] { Convert.ToChar(20) });
                string TopicID =Topic[0].Split(new char[]{Convert.ToChar(18)})[1];
                string _Topic =Topic[0].Split(new char[]{Convert.ToChar(18)})[0];
                Quizes += "<tr class=\"item_Quiz\"><td style=\"text-align:left\"><label>" +(i+1)+" ."+ _Topic + "</label></td></tr>"; //题目
                string[] Options = Topic[1].Split(new char[] { Convert.ToChar(21) });
                int[] OptionsIndex = new int[Options.Length-1];
                //RandomArray(OptionsIndex);//随机
                for (int j = 0; j < Options.Length-1; j++)
                {
                    //string[] idorop = Options[OptionsIndex[j]].Split(new char[] { Convert.ToChar(19) });//随机
                    string[] idorop = Options[j].Split(new char[]{Convert.ToChar(19)});
                    Quizes += "<tr style=\"height:2%\"><td>&nbsp</td></tr>";
                    if (j != Options.Length - 2)
                    {
                        Quizes += "<tr> <td ><div class=\"item_Options\" title=\"\" onclick=\"Getid(" + idorop[0] + ","+TopicID+")\" id=\"" + idorop[0] + "n\" ><input type=\"checkbox\" runat=\"server\" id=\"" + idorop[0] + "\" onchange=\"test_ServerChange(this)\" >" + Convert.ToChar(65 + j) + ". " + idorop[1] + "</div></td></tr>";
                    }
                    else
                    {
                       Quizes += "<tr> <td ><div class=\"item_Options\" title=\"\" onclick=\"Getid(" + idorop[0] + ","+TopicID+")\" id=\"" + idorop[0] + "n\" ><input type=\"checkbox\" runat=\"server\" id=\""+idorop[0]+"\" onchange=\"test_ServerChange(this)\">" + Convert.ToChar(65 + j) + ". " + idorop[1] + "</div></td></tr>";
                        Quizes += "<tr style=\"height:5%\"><td>&nbsp</td></tr>";
                    }
                }
                Dst.Addstate(Quizes);
                
            }
        }
        buf = "";
    }


    public  void RandomArray(int[] arr,int maxrange)
    {
        Random r = new Random(Convert.ToInt32(System.DateTime.Now.ToString("hhmmss")));
        for (int i = 0; i < arr.Length; i++)
        {
            
            arr[i] = r.Next(0, maxrange);
            for (int j = 0; j <i; j++)
            {
                if (arr[j] == arr[i])
                { 
                    arr[i] = r.Next(0, maxrange);
                    j = -1;
                   
                }
            }
        }
      
    }
    //
    //
    //
    public  int QuizPagerCount = 0;
    public  int PageItems = 0;
    public  int QuizCount = 0;

    public  string Quizeloader(string TestID,int _PageItems,int Index)
    {
        string html = "";
        if (Dst.statecount == 0)
        {
            BindQuizes(TestID);
        }
        html += "<table class=\"Quiz_table\">";
        if (_PageItems != 0)
        {
            PageItems = _PageItems;
            int  Pages = QuizCount % PageItems==0?QuizCount/PageItems:(int)(QuizCount/PageItems)+1;
            QuizPagerCount = Pages;
            //QuizPagerCount = 9;
            for (int j = 0; j < PageItems; j++)
            {
                int ex = Index * _PageItems - _PageItems + j;
                string temp = Dst.Readex(ex) + "";
                if (temp != "")
                {
                    html += temp;
                }
            }
        }
        else
        {
            string temp=Dst.Read()+"";            
            while (temp != "")
            {
                html += temp;
                temp = Dst.Read()+"";
            }
        }
        html += "</table>";
        return html;

    }

    private  string UpdateEnter(string str)
    {
        string htm = "";
        foreach (char i in str)
        {
            if (i == '\n')
            {
                htm += "<br>";
            }
            else if(i=='<')
            {
                htm += " &lt;";
            }
            else if (i == '>')
            {
                htm += "&gt;";
            }
            else if (i == ' ')
            {
                htm += "&nbsp;";
            }
            else
            {
                htm += i;
            }
            
        }
        return htm;
    }

    public  void UpdateQuizPager(int PageIndex, string Quize)
    {
        int StateStrint = PageIndex * PageItems - PageItems;
        for (int i = 0; i < PageItems; i++)
        {
            Dst.UpdateData(Quize, StateStrint + i);
        }
    }

    private  string AajaxFunction(string ID)
    {
        string ajax = "<script src=\"Jquery/jquery-1.4.2-vsdoc.js\" type=\"text/javascript\"></script><script type=\"text/javascript\">$(document).ready(function() {  $(\"#"+ID+"\").click(function() {    $.ajax({    type: \"POST\", url: \"ObjectTest.aspx/test_ServerChange\",  data:\"{id:"+ID+"}\", contentType: \"application/json; charset=utf-8\",    dataType: \"json\",   success: function(data) {   alert(data.d);    }}); }); });</script>";
        return ajax;
    }
}