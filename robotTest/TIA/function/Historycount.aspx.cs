using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using MySql.Data.MySqlClien;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_TIA_function_Historycount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UID = Request["UID"];
        if (UID == null)
        {
            Response.Redirect("error.html");
        } 
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            //MyMyMyMyMySqlDataAdapterda = new MySqlDataAdapter();
            //da.Fill(
            //string getHRT = "select * from HTRelationship inner join TKrelationship on TKrelationship.TopicID=HTRelationship.TopicID inner join KnowledgePoint on KnowledgePoint.KnowledgePointID=TKrelationship.KnowledgePointID where HTRelationship.TSRelationshipID="+UID+" order by KnowledgePoint.KnowledgePointID ";
            //MyMyMyMySqlCommandScmd = new MyMyMyMySqlCommand(getHRT, Sc);
            //DataTable HTAK = new DataTable();
           // MyMyMyMySqlDataAdapter da = new MyMyMyMySqlDataAdapter();
            //da.SelectCommand = Scmd;
            //da.Fill(HTAK);
            //foreach (DataRow dr in HTAK.Rows)
            //{

            //}
            string GetKpID = "select * from KnowledgePoint";
            MySqlDataAdapter da = new MySqlDataAdapter(GetKpID, Sc);
            DataTable Knowldedges = new DataTable();
            da.Fill(Knowldedges);
            DataTable data = new DataTable();
            data.Rows.Add(data.NewRow());
            foreach (DataRow knowledge in Knowldedges.Rows)
            {
                string getTotal = "select count(*)as a from HTRelationship inner join TKrelationship on TKrelationship.TopicID=HTRelationship.TopicID inner join KnowledgePoint on KnowledgePoint.KnowledgePointID=TKrelationship.KnowledgePointID where HTRelationship.TSRelationshipID=" + UID+" and Tkrelationship.KnowledgePointID="+knowledge["KnowledgePointID"] ;
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = Sc;
                Scmd.CommandText = getTotal;
                MySqlDataReader read = Scmd.ExecuteReader();
                read.Read();
                int total = 0;
                if ((total=Convert.ToInt32(read["a"].ToString())) != 0)
                {
                    data.Columns.Add(knowledge["KnowledgePointName"].ToString());
                    string GetRights = "select count(*) as a from HTRelationship inner join TKrelationship on TKrelationship.TopicID=HTRelationship.TopicID inner join KnowledgePoint on KnowledgePoint.KnowledgePointID=TKrelationship.KnowledgePointID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where HTRelationship.TSRelationshipID=" + UID + " and Tkrelationship.KnowledgePointID=" + knowledge["KnowledgePointID"]+" and Options.IsTrue=1";
                    double rights = 0.0f;
                    using (MySqlConnection scl = new MySqlConnection(Diya.ConectionString))
                    {
                        scl.Open();
                        MySqlCommand stemp = new MySqlCommand(GetRights, scl);
                        MySqlDataReader sread = stemp.ExecuteReader();
                        sread.Read();
                        rights = Convert.ToDouble(sread["a"].ToString());
                    }
                    data.Rows[0][knowledge["KnowledgePointName"].ToString()] =Math.Round(rights/total,2)+"%("+rights+"/"+total+")";
                }
                read.Close();
            }
            this.TestCountGV.DataSource = data;
            this.TestCountGV.DataBind();
        }
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            string GetTopic = "select * from HTRelationshipship";
        }
    

    }
}