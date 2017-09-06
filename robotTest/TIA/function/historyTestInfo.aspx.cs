using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient
;
using MySql;

public partial class robotTest_TIA_function_historyTestInfo : System.Web.UI.Page
{
    public string Gv1 = "";
    public string Gv2 = "";
    protected string uid = "";
    protected string startTime;
    protected string endTime;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["UID"] == null)
        {
            Response.Write("UID is losted");
            return;
        }
        uid = Request["UID"];
        if (Request["TStart"] != null && Request["TEnd"] != null)
        {
            startTime = Request["TStart"];
            endTime = Request["TEnd"];
        }
        else if (Request["Today"] != null)
        {
            startTime = System.DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            endTime = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            this.TestStartTimeTextFront.Value = startTime;
            this.TestStartTimeTextRoot.Value = endTime;
        }
        else if (Request["Week"] != null)
        {
            startTime = System.DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd 00:00:00");
            endTime = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            this.TestStartTimeTextFront.Value = startTime;
            this.TestStartTimeTextRoot.Value = endTime;
        }
        else if (Request["Month"] != null)
        {
            startTime = System.DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00");
            startTime = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            this.TestStartTimeTextFront.Value = startTime;
            this.TestStartTimeTextRoot.Value = endTime;
        }
        else
        {
            startTime = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00");
            endTime = System.DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            this.TestStartTimeTextFront.Value = startTime;
            this.TestStartTimeTextRoot.Value = endTime;
        }
        GetCountTable();
        GetHistortyTest();
    }
    protected void GetCountTable()
    {
        const int pageSize = 6;
        int Count = 0;
        int Pindex = 0;
        //string startTime = this.TestStartTimeTextFront.Value;
        //stringstring endTime = this.TestStartTimeTextRoot.Value;
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            DataTable KnowledgeTable = new DataTable();
            Sc.Open();
            MySqlDataAdapter

 da = new MySqlDataAdapter

("select KnowledgePointID From KnowledgePoint", Sc);
            da.Fill(KnowledgeTable);
            DataTable header = new DataTable();
            header.Columns.Add("a");
            DataTable table = new DataTable();
            table.Columns.Add("a");
            MySqlCommand


 Scmd=new MySqlCommand


();
            Scmd.Connection = Sc;
            MySqlDataReader


 read;
            foreach (DataRow dr in KnowledgeTable.Rows)
            {
                Scmd .CommandText="select count(*) as a from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join TKrelationship on TKrelationship.TopicID=HTRelationship.TopicID where TKrelationship.KnowledgePointID="+dr["KnowledgePoint"].ToString()+" And TSRelationship.Contactid='"+uid+"' and TestInfo.TestStartTime between '"+TestStartTimeTextFront+"' and '"+TestStartTimeTextRoot+"'";
                read = Scmd.ExecuteReader();
                read.Read();
                string count = read["a"].ToString();
                read.Close();
                if (count != "0")
                {
                    read.Close();
                    Scmd.CommandText = "Select KnowledgePointName from KnowledgePoint where KnowledgePointID="+dr["KnowledgePointID"];
                    read = Scmd.ExecuteReader();
                    string kpname = read[0].ToString();
                    read.Close();
                    Scmd.CommandText = "select count(*) as a from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join TKrelationship on TKrelationship.TopicID=HTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where TKrelationship.KnowledgePointID="+dr["KnowledgePoint"].ToString()+" And TSRelationship.Contactid='"+uid+"' and TestInfo.TestStartTime between '"+TestStartTimeTextFront+"' and '"+TestStartTimeTextRoot+"' and Options.IsTrue=1";
                   read = Scmd.ExecuteReader();
                   read.Read();
                   header.Rows.Add(header.NewRow());
                   header.Rows[header.Rows.Count - 1][0] = kpname;
                   table.Rows.Add(table.NewRow());
                   table.Rows[table.Rows.Count - 1][0] = read["a"].ToString() + "/" + count+"("+System.Math.Round((double)Convert.ToInt32(read["a"].ToString())/Convert.ToInt32(count),2)+"%)";
                   read.Close();
                }
            }
            int Pcount = header.Rows.Count % pageSize == 0 ? header.Rows.Count / pageSize : (int)(header.Rows.Count / pageSize) + 1;
            Count = Pcount;
            string[] Gv1tables = new string[Pcount];
            for (Pindex = 0; Pindex < Pcount; Pindex++)
            {
                if (Pindex != 0)
                {
                    Gv1 += "<table style=\"width:100%; background-color:white; border:1px solid gray;border-spacing:0px;display:none \" border=\"1 \" id=\"Gv1P" + Pindex + "\">";
                }
                else
                {
                    Gv1 += "<table style=\"width:100%; background-color:white; border:1px solid gray;border-spacing:0px\" border=\"1\" id=\"Gv1P" + Pindex + "\">";
                }
                string head = "<tr>";
                string body = "<tr>";
                int pi = 0;
                for (int i = Pindex * pageSize;pi<pageSize; i++)
                {
                    head += "<th>" + header.Rows[i][0] + "</th>";
                    body += "<td>" + table.Rows[i][0] + "</td>";
                    pi++;
                }
                head += "</tr>";
                body += "</tr>";
                Gv1 += head+body+"</table>";
            }
            Gv1 += "<input id=\"Gv1pageCount\" type=\"hidden\" value=\""+Pcount+"\"/>";
            //Gv1 += "<table style=\"width:100%; background-color:white; border:1px solid gray;border-spacing:0px\" border=\"1\" id=\"Gv1P"+Pindex+"\">";


        }
    }
    protected void GetHistortyTest()
    {
        const int PageSize=10;
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            string GetHistoryTestInfo = "select * from TestInfo inner join TSRelationship on TSRelationship.TestID=TestInfo.TestID where TSRelationship.Contactid='"+uid+"' and TestInfo.TestStartTime between '"+TestStartTimeTextFront+"' and '"+TestStartTimeTextRoot+"' and TSRelationship.Score!=0";
            DataTable TestInfoTd = new DataTable();
            MySqlDataAdapter

 da = new MySqlDataAdapter

(GetHistoryTestInfo, Sc);
            da.Fill(TestInfoTd);
            int pageCount = TestInfoTd.Rows.Count % PageSize == 0 ? TestInfoTd.Rows.Count / PageSize : 1+(int)(TestInfoTd.Rows.Count / PageSize);
            Gv2 += "<input type=\"hidden\" id=\"Gv2pageCount\" value=\""+pageCount+"\"/>";
            for (int i = 0; i < pageCount; i++)
            {
                ListItem item = new ListItem("" + (i + 1), i+"");
                this.Gv2Select.Items.Add(item);
            }
            this.Gv2Select.SelectedIndex = 0;
            int pindex = 0;
            bool ReturnedPage = true;
            int rCount = 0;
            foreach (DataRow tinfodr in TestInfoTd.Rows)
            {
                if (ReturnedPage)
                {
                    rCount = 0;
                    if (pindex != 0)
                    {
                        Gv2 += " <table style=\"width:100%; background-color:white; border:1px solid gray;border-spacing:0px;display:none \" border=\"1 \" id=\"Gv2P" + pindex + "\">";
                        Gv2 += "<tr><th>练习名称</th><th>考试开始时间</th><th>正确率</th><th>&nbsp</th><th>&nbsp</th></tr>";

                    }
                    else
                    {
                        Gv2 += "<table style=\"width:100%; background-color:white; border:1px solid gray;border-spacing:0px; \" border=\"1 \" id=\"Gv2P" + pindex + "\"> ";
                        Gv2 += "<tr><th>练习名称</th><th>考试开始时间</th><th>正确率</th><th>&nbsp</th><th>&nbsp</th></tr>";

                    }
                    ReturnedPage = !ReturnedPage;
                }
                if (rCount < PageSize)
                {
                    string GetTestR = "Select Count(*) as right from HTRelationship inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where Options.IsTrue=1 and HTRelationship.TSRelationshipID="+tinfodr["RelationshipID"];
                    string GetTestW = "Select Count(*) as wrong from HTRelationship inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where Options.IsTrue=0 and HTRelationship.TSRelationshipID="+tinfodr["RelationshipID"];
                    MySqlCommand Scmd = new MySqlCommand();
                    Scmd.Connection = Sc;
                    Scmd.CommandText = GetTestR;
                    MySqlDataReader read = Scmd.ExecuteReader();
                    read.Read();
                    double testright = Convert.ToDouble(read["right"].ToString());
                    read.Close();
                    Scmd.CommandText = GetTestW;
                    read = Scmd.ExecuteReader();
                    read.Read();
                    double testworng = Convert.ToDouble(read["wrong"].ToString());
                    read.Close();
                    Gv2 += "<tr><td>" + tinfodr["TestName"] + "</td><td>" + tinfodr["TestStartTime"] + "</td>";
                    Gv2 += "<td>"+Math.Round((testright/testworng),2,MidpointRounding.ToEven)+"%("+Convert.ToInt32(testright)+"/"+Convert.ToInt32(testright+testworng)+")"+"</td>";
                    Gv2 += "<td>" + " < input type =\"button\" value=\"查看练习\" onclick=\"GetHistoryTest('"+tinfodr["RelationshipID"]+"')\" style=\"border - radius:15px 15px; background - color:black; color: white\"  /></td>";
                    Gv2 += "<td>" + " < input type =\"button\" value=\"更多\" onclick=\"GetHistoryInfo('" + tinfodr["RelationshipID"] + "')\" style=\"border - radius:15px 15px; background - color:black; color: white\"  />"+"</td></tr>";
                    rCount++;
                    
                }
                    
                else
                {
                    ReturnedPage = true;
                    pindex++;
                    Gv2 += "</table>";
                }

            }
        }
    }


}