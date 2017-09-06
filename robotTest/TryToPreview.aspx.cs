using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class TryToPreview : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Consultion.aspx");
            }
            ViewState["UserID"] = Session["UserInfo"].ToString().Split(new char[] { '#' })[1];
            using (MySqlDataReader read = new Diya().RowReader("select * from Section"))
            {
                while (read.Read())
                {
                    this.SelectionBuf.Value += read["Section"] + "*" + read["SectionID"] + "$";
                }
                this.SelectionBuf.Value += "#";
            }
            using (MySqlDataReader read = new Diya().RowReader("Select * From Section"))
            {
                while (read.Read())
                {
                    using (MySqlDataReader Kread = new Diya().RowReader("select * From KnowledgePoint where SectionID=" + read["SectionID"]))
                    {
                        this.SelectionBuf.Value += read["SectionID"] + "$";
                        while (Kread.Read())
                        {
                            this.SelectionBuf.Value += Kread["KnowledgePointName"] + "*" + Kread["KnowledgePointID"] + "+";
                        }
                        this.SelectionBuf.Value += "%";
                    }
                }
            }
        }
    }

    protected int IDCount(string[] Str,string ID)
    {
        int count=0;
        foreach(string s in Str)
        {
            if(ID==s)
            {
                count++;
            }
        }
        return count;
    }
    protected bool InsertTest()
    {
        bool sec = true;
        bool check = true;
        string[] knowledgepointIds = this.ReturnBuf.Value.Split(new char[] { '#' });
        int testcount = 0;
        DataSet ds = new DataSet();
        DataTable optdt = new DataTable();
        for (int i = 0; i < knowledgepointIds.Length - 1; i++)
        {
            ds.Tables.Add(new DataTable());
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select TopicID from TKRelationship where KnowledgePointID=" + knowledgepointIds[i], Sc);
                da.Fill(ds.Tables[i]);
                if (ds.Tables[i].Rows.Count != 0)
                {
                    testcount++;
                }
                if (ds.Tables[i].Rows.Count < IDCount(knowledgepointIds, knowledgepointIds[i]))
                {
                    check = false;
                }
            }
        }
        if (check)
        {
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlTransaction Tramd = Sc.BeginTransaction();
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = Sc;
                Scmd.Transaction = Tramd;
                try
                {
                    Scmd.CommandText = "Insert into TestInfo(TestName,TestStartTime,TestCount,TopicScore,TestEndTime) values ('" + this.TestName.Value + "','" + this.TestStartTime.Value + "'," + testcount + "," + this.TopicScore.Value + ",'" + this.TestEndTime.Value + "')";
                    Scmd.ExecuteNonQuery();
                    Scmd.CommandText = "Insert into TestMouldInfo(Userid,MouldName,TopicCount) values('" + ViewState["UserID"].ToString() + "','" + this.TestName.Value + "'," + testcount + ")";
                    Scmd.ExecuteNonQuery();
                    MySqlDataReader read;
                    Scmd.CommandText = "Select max(MouldID) as a from TestMouldInfo where Userid='" + ViewState["UserID"].ToString() + "'";
                    read = Scmd.ExecuteReader();
                    read.Read();
                    int MouldID = Convert.ToInt32(read["a"]);
                    read.Close();
                    int Testid;
                    Scmd.CommandText = "select max(TestID) as a from TestInfo ";
                    read = Scmd.ExecuteReader();
                    read.Read();
                    Testid = read.GetInt32(0);
                    read.Close();
                    for(int i=0;i<knowledgepointIds.Length-1;i++)
                    {
                        Scmd.CommandText = "Insert into MKRelationship(MouldID,KnowledgePointID)values("+MouldID+","+knowledgepointIds[i]+")";
                        Scmd.ExecuteNonQuery();
                    }
                    string[] TopicIDs = new string[ds.Tables.Count];
                    int k = 0;
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        Random r = new Random(Convert.ToInt32(DateTime.Now.ToString("ddmmss")));
                        if (ds.Tables[i].Rows.Count != 0)
                        {
                            TopicIDs[k] = ds.Tables[i].Rows[r.Next(0, ds.Tables[i].Rows.Count)][0].ToString();
                            //int IDsCount=IDCount(knowledgepointIds,ds.Tables[i])
                            for (int j = 0; j < k; j++)
                            {
                                if (TopicIDs[k] == TopicIDs[j])
                                {
                                    TopicIDs[k] = ds.Tables[i].Rows[r.Next(0, ds.Tables[i].Rows.Count)][0].ToString();
                                    j = -1;
                                }
                            }
                        }
                        else
                        {
                            k--;
                        }
                        k++;
                    }

                    for (int j = 0; j < TopicIDs.Length; j++)
                    {
                        string TopicID = TopicIDs[j];
                        DataTable odt = new DataTable();
                        using (MySqlConnection Dsc=new MySqlConnection(Diya.ConectionString))
                        {
                            Dsc.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter("Select OptionID from Options where TopicID=" + TopicID,Dsc);
                        da.Fill(odt);   
                        }
                        int[] optindex = new int[odt.Rows.Count];
                        new TIA().RandomArray(optindex, optindex.Length);
                        Scmd.CommandText = "insert into TTRelationship(TestID,TopicID)values(" + Testid + "," + TopicID + ")";
                        Scmd.ExecuteNonQuery();
                        string TTRealtionshipID;
                        Scmd.CommandText = "select max(RelationshipID) as a from TTRelationship";
                        read = Scmd.ExecuteReader();
                        read.Read();
                        TTRealtionshipID = Convert.ToString(read.GetInt32(0));
                        read.Close();
                        for (int i = 0; i < odt.Rows.Count; i++)
                        {
                           Scmd.CommandText = "insert into OTRelationship(TTRelationshipID ,OptionID)values(" + TTRealtionshipID + "," + odt.Rows[optindex[i]][0] + ")";
                           Scmd.ExecuteNonQuery();
                        }
                    }
                    Tramd.Commit();
                    Session["TheScene"] = "6";
                    Response.Redirect("Consultion.aspx");
                }

                catch (Exception)
                {
                    Tramd.Rollback();
                    sec = false;
                }
            }
        }
        else
        {
            Literal merss = new Literal();
            merss.Text = "<script>alert('题库数量不足')</script>";
            this.Controls.Add(merss);
            return true;
        }
        return sec;
    }






    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
         bool sec=InsertTest();
         int Times = 0;
         int Sleep = 0;
        while(!sec &&Times<5)
        {
            Sleep += 1000;
            System.Threading.Thread.Sleep(Sleep);
            sec = InsertTest();
            Times++;
        }
    }

    protected void ToMould_Click(object sender, EventArgs e)
    {
        Response.Redirect("TestMould.aspx");
    }
}