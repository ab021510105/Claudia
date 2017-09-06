using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
//using MySql.MySqlClinet;


public partial class robotTest_TIA_function_HTIA : System.Web.UI.Page
{
    public string desk = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        const int PageSize = 2;
        //string UID = Request["UID"];
        string RID = Request["RID"];
        if (RID==null)
        {
            desk = "<img src=\"Desk/Error.PNG\" />";
        }        
        using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            string GetTopicInfo = "Select * from HTRelationship inner join Topic on Topic.TopicID=HTRelationship.TopicID where HTRelationship.TSRelationshipID="+RID;
            DataTable TopicInf = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(GetTopicInfo, sc);
            da.Fill(TopicInf);
            int i = 1;
            int Pindex = 0;
            int p = 0;
            int pCount = TopicInf.Rows.Count % PageSize == 0 ? TopicInf.Rows.Count / PageSize : (int)(TopicInf.Rows.Count / PageSize) + 1;
            foreach (DataRow Tdr in TopicInf.Rows)
            {
                if (p == 0)
                {
                    desk += "<div style=\'display:none\' id=\'p" + Pindex + "\'>";
                }
                desk += "<div class=\'TopicInfo\' id=\'" + Tdr["TopicID"] + "\' >";
                desk += " <div class=\'Topic\' style=\'font-size:large\'>" + i + "." + UpdateEnter(Tdr["TopicContent"].ToString());
                if (Tdr["HaveContent"].ToString() == "1")
                {
                    desk += "<br/>" + UpdateEnter(Tdr["MoreContent"].ToString());
                }
                desk += "</div>";
                using (MySqlConnection osc = new MySqlConnection(Diya.ConectionString))
                {
                    osc.Open();
                    string GetOptions = "select * from Options inner join HTRelationship on Options.TopicID=HTRelationship.TopicID where HTRelationship.RelationshipID="+Tdr["RelationshipID"];
                    MySqlCommand Scmd = new MySqlCommand(GetOptions, osc);
                    DataTable Odt = new DataTable();
                    MySqlDataAdapter oda = new MySqlDataAdapter();
                    oda.SelectCommand = Scmd;
                    oda.Fill(Odt);
                    int k = 0;
                    foreach (DataRow odr in Odt.Rows)
                    {
                        string color = odr["OptionsID"].ToString() == Tdr["SelectedOptionID"].ToString() ? "Red" : "white";
                        string selected = odr["IsTrue"].ToString() == "1" ? "checked=/'checked/'" : "";
                        desk += "<div class=\'option\' title=\'\' style=\'border: 1px solid "+color+"\' >" + "<input  type = \'checkbox\' id = \'" + odr["OptionID"] + "\' style = \'border-color:black\' class=\'ioption\' onclick=\'return false;\'"+selected+"/>" + (char)(k + 65) + "." + UpdateEnter(odr["OptionContent"].ToString()) + "</div>";
                        k++;
                    }
                }
                i++;
                p++;
                desk += "</div>";
                if (p == PageSize || i == pCount)
                {
                    desk += "</div>";
                    p = 0;
                    Pindex++;
                }
            }
            desk += "<input id=\"TestCount\" type=\"hidden\" value=\"" + pCount + "\"/>";
            //desk += "<input id=\"TestPageIndex\" type=\"hidden\" value=\"0\"/>";
            //desk += "<input id=\"tsid\" type=\"hidden\" value=\"" + Request["RID"] + "\"/>";
            desk += " <div style=\"border - top:1px solid #dbd9d9;text-align:right\">";
            desk += "<input type=\"button\" id=\"lastPage\"  value=\"上一页\" style=\"   color: white; font - size:large; background: -webkit - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -ms - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -moz - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80));\" onclick=\"onTestLastClick()\"  disabled=\"disabled\"/>";
            desk += "<a id=\"pageInfo\" runat=\"server\">1/" + pCount + "</a>";
            desk += "<input type=\"button\" id=\"nextPage\"  value=\"下一页\" style=\"  color: white; font - size:large; background: -webkit - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -ms - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); background: -moz - linear - gradient(top, rgba(117, 115, 115, 0.80), rgba(55, 41, 41, 0.80)); \" onclick=\"onTestNextClick()\" />";
            desk += "</div>";
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