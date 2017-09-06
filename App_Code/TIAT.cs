using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient
;

/// <summary>
/// Class1 的摘要说明
/// </summary>
/// 
[Serializable]
public class TIAT
{
	public TIAT()
	{
        
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public DataStates Dst = new DataStates();
    private  string BindQuizable(string testid)
    {
        //string htmltext = ChecekMode?"<table class=\"History_Quiz_tabel\">":"<table class=\"Quiz_table\">";
        string htmltext = "";
            DataSet Ds = new DataSet();
            string SelectCmd_Q = "Select TTRelationship.RelationshipID,Topic.TopicID,Topic.TopicContent,Topic.HaveContent,Topic.MoreContent From TTRelationship inner join Topic on TTRelationship.TopicID=Topic.TopicID where TTRelationship.TestID=" + testid;
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();MySqlDataAdapter Da = new MySqlDataAdapter(SelectCmd_Q, Sc);
                Da.Fill(Ds);
            }
            int TestCount = 0;
            DataTable Dt = Ds.Tables[0];
            using (MySqlDataReader read = new Diya().RowReader("select TestCount from TestInfo where TestID=" + testid))
            {
                if (read.Read())
                {
                    TestCount = read.GetInt32(0);
                }
                else
                {
                    TestCount = 0;
                }
                read.Close();
            }
            for (int i = 0; i < TestCount; i++)
            {
                htmltext = "<tr class=\"item_Quiz\"><td style=\text-align:left\"><label>" + (i + 1) + " ." + Dt.Rows[i]["TopicContent"] + "</label></td></tr>";
                DataSet Dso = new DataSet();
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();MySqlDataAdapter da = new MySqlDataAdapter("Select Options.OptionID,Options.OptionContent From Options inner join OTRelationship on OTRelationship.OptionID=Options.OptionID Where OTRelationship.TTRelationshipID=" + Dt.Rows[i]["RelationshipID"].ToString(), Sc);
                    da.Fill(Dso);
                }
                DataTable Options = Dso.Tables[0];
                for (int j = 0; j < Options.Rows.Count; j++)
                {
                    htmltext += "<tr style=\"height:2%\"><td>&nbsp;</td></tr>";
                    htmltext += "<tr><td><div class=\"item_Options\"> title=\"\"  id=\"" + Options.Rows[j]["OptionID"] + "n\"><input type=\"checkbox\" runat=\"server\" id=\"" + Options.Rows[j]["OptionID"] + "\" onserverchange=\"test_ServerChange\" disabled=\"disabled\" style=\"border:1px solid Black\">" + Convert.ToChar(65 + j) + ". " + Options.Rows[j]["OptionContent"] + "</div></td></tr>";
                    if (j == Options.Rows.Count - 1)
                    {
                        htmltext += "<tr style=\"height:5%\"><td>&nbsp</td></tr>";
                    }
                }
                Dst.Addstate(htmltext);
            }
        
        return htmltext;
    }

    private  void BindQuizable(string testid, string TSRelationshipID)
    {
        string HtmlText = "";
        string SelectCmd = "Select TTRelationship.RelationshipID,Topic.TopicID,Topic.TopicContent,Topic.HaveContent,Topic.MoreContent From TTRelationship inner join Topic on TTRelationship.TopicID=Topic.TopicID where TTRelationship.TestID=" + testid;
        DataSet TDs = new DataSet();
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();MySqlDataAdapter Da = new MySqlDataAdapter(SelectCmd, Sc);
            Da.Fill(TDs);
            Sc.Close();
        }
        int testcount;
        using( MySqlDataReader read = new Diya().RowReader("Select TestCount from TestInfo where TestID="+testid))
        {
            read.Read();
            testcount = read.GetInt32(0);
            read.Close();
        }
        QuizCount = testcount;
        DataTable Tdt = TDs.Tables[0];
        for (int i = 0; i < testcount; i++)
        {
            string Topic = UpdateEnter(Tdt.Rows[i]["TopicContent"].ToString());
            if (TDs.Tables[0].Rows[i]["HaveContent"].ToString() == "1")
            {
                Topic += UpdateEnter("\n" + Tdt.Rows[i]["MoreContent"].ToString());
            }
            DataSet ODs = new DataSet();
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();MySqlDataAdapter da = new MySqlDataAdapter("Select Options.OptionID,Options.OptionContent,Options.IsTrue From Options inner join OTRelationship on OTRelationship.OptionID=Options.OptionID Where OTRelationship.TTRelationshipID=" + Tdt.Rows[i]["RelationshipID"].ToString(),Sc);
                da.Fill(ODs);
                Sc.Close();
            }
            DataTable Odt = ODs.Tables[0];
            HtmlText = "<tr class=\"item_Quiz\"> <td style=\"text-align:left\"><label>"+(i+1)+" ."+Topic+"</label></td></tr>";
            int j = 0;
            foreach (DataRow dr in Odt.Rows)
            {
                HtmlText += "<tr style=\"height:2%\"><td>&nbsp;</td></tr>";
                string div = "<div class=\"item_Options\" title=\"\"  id=\"" + dr["OptionID"] + "n\" >";
                using( MySqlDataReader read = new Diya().RowReader("select * From HTRelationship where SelectedOptionID="+dr["OptionID"]+" and TSRelationshipID="+TSRelationshipID))
                {
                    if (read.Read())
                    {
                        div = "<div style=\"border:2px solid red\">";
                    }
                }
                string input = "<input type=\"checkbox\" runat=\"server\" id=\"" + dr["OptionID"] + "\" onserverchange=\"test_ServerChange\" disabled=\"disabled\" style=\"border:1px solid Black\"/>";
                if (dr["IsTrue"].ToString() == "1")
                {
                    input = " <input type=\"checkbox\" id=\"" + dr["OptionID"] + "\" checked=\"checked\" disabled=\"disabled\" style=\"border:1px solid Black\"/>";
                }
                HtmlText += "<tr><td>" + div + input + Convert.ToChar(65+j) + " ." + UpdateEnter(dr["OptionContent"].ToString())+"</div></td></tr>";
                if (j == Odt.Rows.Count - 1)
                {
                    HtmlText += "<tr style=\"height:5%\"><td>&nbsp</td></tr>";
                }
                j++;
            }
            Dst.Addstate(HtmlText);
        }
    }


    private  string UpdateEnter(string str)
    {
        string htm = "";
        foreach (char i in str)
        {
            if (i== '\n')
            {
                 htm += "<br>";
            }
            else if (i == '<')
            {
                htm += " &lt;";
            }
            else if (i == '>')
            {
                htm += "&gt;";
            }
            else if (i == ' ')
            {
                htm += "&nbsp";
            }
            else
            {
                htm += i;
            }

        }
        return htm;
    }
    
    public  int QuizPagerCount = 0;
    public  int PageItems = 0;
    private int QuizCount = 0;
    public  string Quizeloader(string TestID, int _PageItems, int pageindex, string TSRelationshipID)
    {
        string htmltext = "";
        if(Dst.statecount==0)
        {
            BindQuizable(TestID, TSRelationshipID);
        }
        htmltext += "<table class=\"Quiz_table\">";
        if (_PageItems != 0)
        {
            PageItems = _PageItems;
            int Pages = QuizCount % PageItems == 0 ? QuizCount / PageItems : (int)(QuizCount / PageItems) + 1;
            QuizPagerCount = Pages;
            for (int j = 0; j < PageItems; j++)
            {
                int ex = pageindex * _PageItems - _PageItems + j;
                string temp = Dst.Readex(ex) + "";
                if (temp != "")
                {
                    htmltext += temp;
                }
            }
        }
        else
        {
            string temp = Dst.Read() + "";
            while (temp != "")
            {
                htmltext += temp;
                temp = Dst.Read() + "";
            }
        }
        htmltext += "</table>";
        return htmltext;
    }
    public  string Quizeloader(string TestID, int _PageItems, int pageindex)
    {
        string html = "";
        if (Dst.statecount == 0)
        {
            BindQuizable(TestID);
        }
        html += "<table class=\"Quiz_table\">";
        if (_PageItems != 0)
        {
            PageItems = _PageItems;
            int Pages = QuizCount % PageItems == 0 ? QuizCount / PageItems : (int)(QuizCount / PageItems) + 1;
            QuizPagerCount = Pages;
            for (int j = 0; j < PageItems; j++)
            {
                int ex = pageindex * _PageItems - _PageItems + j;
                string temp = Dst.Readex(ex) + "";
                if (temp != "")
                {
                    html += temp;
                }
            }
        }
        else
        {
            string temp = Dst.Read() + "";
            while (temp != "") 
            {
                html += temp;
                temp = Dst.Read() + "";
            }
        }
        html += "</table>";
        return html;
    }
    public string BoundQuizTable_W( string SelectCommand)
    {
        string html = "";
        using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            DataTable Buf = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(SelectCommand, Sc);
            da.Fill(Buf);
            QuizCount = Buf.Rows.Count;
            int i = 0;
            foreach(DataRow Dr in Buf.Rows)
            {
                string Topic = UpdateEnter(Dr["TopicContent"].ToString());
                if (Dr["HaveContent"].ToString() == "1")
                {
                    Topic += UpdateEnter("\n" + Dr["MoreContent"].ToString());
                }
                html = "<tr class=\"item_Quiz\"> <td style=\"text-align:left\"><label>" + (i + 1) + " ." + Topic + "</label><a id=\"a" + i + "\" onclick=\"naClick(\'a"+i+"\')\" href=\"#\" style=\"text-decoration:none\">+</a></td></tr>";
                DataTable ODT = new DataTable();
                using(MySqlConnection _sc=new MySqlConnection(Diya.ConectionString))
                {
                    _sc.Open();
                    MySqlDataAdapter Da = new MySqlDataAdapter("Select * from Options where TopicID="+Dr["TopicID"],_sc);
                    Da.Fill(ODT);
                }
                int j = 0;
                html += "<tr><td><table style=\"display:none\" id=\"a"+i+"d\">";
                foreach (DataRow dr in ODT.Rows)
                {
                    html += "<tr style=\"height:2%\"><td>&nbsp;</td></tr>";
                    string div = "<div class=\"item_Options\" title=\"\"  id=\"" + dr["OptionID"] + "n\" >";
                    if(Dr["SelectedOptionID"].ToString()==dr["OptionID"].ToString())
                    {
                        div = "<div style=\"border:2px solid red\">";
                    }
                    string input = "<input type=\"checkbox\" runat=\"server\" id=\"" + dr["OptionID"] + "\" onserverchange=\"test_ServerChange\" disabled=\"disabled\" style=\"border:1px solid Black\"/>";
                    if (dr["IsTrue"].ToString() == "1")
                    {
                        input = " <input type=\"checkbox\" id=\"" + dr["OptionID"] + "\" checked=\"checked\" disabled=\"disabled\" style=\"border:1px solid Black\"/>";
                    }
                    html += "<tr><td>" + div + input + Convert.ToChar(65 + j) + " ." + UpdateEnter(dr["OptionContent"].ToString()) + "</div></td></tr>";
                    if (j == ODT.Rows.Count - 1)
                    {
                        html += "<tr style=\"height:5%\"><td>&nbsp</td></tr>";
                    }
                    j++;
                }
                html += "</table></td></tr>";
                i++;
                Dst.Addstate(html);
            }
        }
        return html;
    }

    public string Quizeloader(int _PageItems, int pageindex,string selectcommand)
    {
        string html = "";
        if (Dst.statecount == 0)
        {
            BoundQuizTable_W(selectcommand);
        }
        html += "<table class=\"Quiz_table\">";
        if (_PageItems != 0)
        {
            PageItems = _PageItems;
            int Pages = QuizCount % PageItems == 0 ? QuizCount / PageItems : (int)(QuizCount / PageItems) + 1;
            QuizPagerCount = Pages;
            for (int j = 0; j < PageItems; j++)
            {
                int ex = pageindex * _PageItems - _PageItems + j;
                string temp = Dst.Readex(ex) + "";
                if (temp != "")
                {
                    html += temp;
                }
            }
        }
        else
        {
            string temp = Dst.Read() + "";
            while (temp != "")
            {
                html += temp;
                temp = Dst.Read() + "";
            }
        }
        html += "</table>";
        return html;
    }

    public string CreateTable(float[,] data, float data_Max, string[] LineTitel, string X_label, string Y_label, float[] x, string Title,string ControlID)
    {
        string html = "<script>\n";
        html += "var data=[";
        for (int i = 0; i < data.GetLength(0); i++)
        {
            html += "[";
            for (int j = 0; j < data.GetLength(1); j++)
            {
                if (j == data.GetLength(1) - 1)
                {
                    html += data[i, j];
                }
                else
                {
                    html += data[i, j] + ",";
                }

            }

            if (i < data.GetLength(0) - 1)
            {
                html += "],";
            }
            else
            {
                html += "]";
            }
        }
        html += "];\n";
        html += "var data_max=" + data_Max + ";\n";
        html += "var line_title=[";
        for (int i = 0; i < LineTitel.Length; i++)
        {
            if (i < LineTitel.Length - 1)
            {
                html += "\"" + LineTitel[i] + "\",";
            }
            else
            {
                html += "\"" + LineTitel[i] + "\"";
            }

        }
        html += "];\n";
        html += "var y_label=\"" + Y_label + "\";\n";
        html += "var x_label=\"" + X_label + "\";\n";
        html += "var x=[";
        for (int i = 0; i < x.Length; i++)
        {
            if (i < x.Length - 1)
            {
                html += x[i] + ",";
            }
            else
            {
                html += x[i];
            }
        }
        html += "];\n";
        html += "document.onreadystatechange = function () {\n";
        html += " if (document.readyState == \"complete\") {\n";
        html += "j.jqplot.diagram.base(\""+ControlID+"\", data, line_title, \"" + Title + "\", x, x_label, y_label, data_max, 1);\n";
        html += "var body = document.getElementsByTagName('body');\n";
        html+="body[0].style.height = screen.height.toString()+\"px\";\n";
        html+="Button_L();\n";
        html+="Button_S();\n";
        html+="Timer();\n";
        html+="item_Options();\n";
        html+="Nav();\n";
        html+="CheckTimeOut();\n";
        html += " LoadingProgress();\n";
        html += "  }\n";
        html += "}\n";
        html += "</script>";
        return html;
    }
}