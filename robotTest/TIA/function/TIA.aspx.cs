using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient
;
//using MySql.Data.MySqlClient;
//using MySql.Data;

public partial class robotTest_TIA_function_TIA : System.Web.UI.Page
{
    public string Test = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string TestID = "";
        //string TestInfo = "";
        int pageSize = 2;
        //char cut = (char)3;
        using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand("select * from TSRelationship where RelationshipID=" + Request["RID"], sc);
            //MyMyMyMySqlCommand
            MySqlDataReader read = scmd.ExecuteReader(CommandBehavior.CloseConnection);
            //MyMyMyMySqlDataReader
            read.Read();
            TestID = read["TestID"].ToString();
            string GetTopic = "select * from TTRelationship inner join Topic on Topic.TopicID = TTRelationship.TopicID where TTRelationship.TestID=" + TestID;
            sc.Close();
            sc.Open();
            scmd = new MySqlCommand(GetTopic, sc);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            //MyMyMyMySqlDataAdapter
            da.SelectCommand = scmd;
            da.Fill(dt);
            int i = 1;
            int Pindex = 0;
            int p = 0;
            int pCount =dt.Rows.Count % pageSize == 0 ? dt.Rows.Count / pageSize : (int)(dt.Rows.Count / pageSize) + 1;
            foreach(DataRow Tdr in dt.Rows )
            {
                if(p==0)
                {
                    Test += "<div style=\'display:none\' id=\'p"+Pindex+"\'>";
                }
                Test += "<div class=\'TopicInfo\' id=\'"+Tdr["TopicID"]+"\' >";
                Test += " <div class=\'Topic\' style=\'font-size:large\'>" +i+"."+ UpdateEnter(Tdr["TopicContent"].ToString()) ;
                if(Tdr["HaveContent"].ToString()=="1")
                {
                    Test += "<br/>"+UpdateEnter(Tdr["MoreContent"].ToString());
                }
                Test += "</div>";
                using (MySqlConnection osc = new MySqlConnection(Diya.ConectionString))
                {
                    osc.Open();
                    string GetOptions = "select * from OTRelationship inner join Options on OTRelationship.OptionID=Options.OptionID where TTRelationshipID="+Tdr["RelationshipID"].ToString();
                    MySqlCommand Scmd = new MySqlCommand(GetOptions,osc);
                    DataTable Odt = new DataTable();
                    MySqlDataAdapter oda = new MySqlDataAdapter();
                    oda.SelectCommand = Scmd;
                    oda.Fill(Odt);
                    int k = 0;
                    foreach(DataRow odr in Odt.Rows)
                    {
                        Test += "<div class=\'option\' title=\'\' style=\'border: 1px solid white\' onclick=\'onSelected()\'>" +"<input  type = \'checkbox\' id = \'"+odr["OptionID"]+"\' style = \'border-color:black\' class=\'ioption\' />"+ (char)(k+65)+ "." +UpdateEnter(odr["OptionContent"].ToString())+"</div>";
                        k++;
                    }
                }
                i++;
                p++;
                Test += "</div>";
                if(p==pageSize||i==pCount)
                {
                    Test += "</div>";
                    p = 0;
                    Pindex++;
                }
            }
           
            Test += "<input id=\"TestCount\" type=\"hidden\" value=\"" + pCount + "\"/>";
            Test += "<input id=\"TestPageIndex\" type=\"hidden\" value=\"0\"/>";
            Test += "<input id=\"tsid\" type=\"hidden\" value=\"" + Request["RID"] + "\"/>";
            Test += " <div style=\"border - top:1px solid #dbd9d9;text-align:right\">";
            Test += "<input type=\"button\" id=\"lastPage\"  value=\"上一页\" style=\"   color: white; font - size:large; background: -webkit - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -ms - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -moz - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80));\" onclick=\"onTestLastClick()\"  disabled=\"disabled\"/>";
            Test += "<a id=\"pageInfo\" runat=\"server\">1/"+pCount+"</a>";
            Test += "<input type=\"button\" id=\"nextPage\"  value=\"下一页\" style=\"  color: white; font - size:large; background: -webkit - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -ms - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -moz - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); \" onclick=\"onTestNextClick()\" />";
            Test += "</div>";
        }

    }
    private string UpdateEnter(string str)
    {
        string htm = str.Replace("\n", "<br/>");
        htm = htm.Replace("<", "&lt;");
        htm = htm.Replace(">", "&gt;");
        htm = htm.Replace(" ", "&nbsp;");
        htm = htm.Replace("\"", "&quot;");
        htm = htm.Replace("'", "&apos;");
        return htm;
    }
}