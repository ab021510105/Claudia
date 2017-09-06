using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Sql;

public partial class Teacher : System.Web.UI.Page
{   
    DataStates Dst = new DataStates();
    protected void Page_Load(object sender, EventArgs e)
    { 

        this.KnowledgePointInfo.RepeatColumns = 10;
        this.SectionInfo.RepeatColumns = 10;
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Consultion.aspx");
            }
            ListItem Item;
            Item = new ListItem("全部章节","0");
            //Item.Selected = true;
            this.SectionInfo.Items.Add(Item);
            using (MySqlDataReader read = new Diya().RowReader("Select * From Section"))
            {
                while (read.Read())
                {
                    Item = new ListItem(read["Section"].ToString(),read["SectionID"].ToString());
                    Item.Selected = true;
                    this.SectionInfo.Items.Add(Item);
                }
            }
            Item = new ListItem("全部知识点", "0");
            this.KnowledgePointInfo.Items.Add(Item);
            using (MySqlDataReader read = new Diya().RowReader("Select KnowledgePointID,KnowledgePointName from KnowledgePoint"))
            {
                while (read.Read())
                {
                    Item = new ListItem(read["KnowledgePointName"].ToString(),read["KnowledgePointID"].ToString());
                    this.KnowledgePointInfo.Items.Add(Item);
                }
            }
            if (Request["Mode"] == "Up")
            {
                this.SectionInfo.Visible = false;
                this.KnowledgePointInfo.Visible = false;
                this.TestCount.Enabled = false;
                this.TextScore.Enabled = false;
                this.TestName.Enabled = false;
                ViewState["id"]=Session["TestID_Up"];
                Session["TestID_Up"] = null;
                using (MySqlDataReader read = new Diya().RowReader("Select * From TestInfo where TestID="+ViewState["id"]))
                {
                    read.Read();
                    this.TestName.Text = read["TestName"].ToString();
                    this.TestStartDate.Value = read["TestStartTime"].ToString();
                    this.TestEndDate.Value = read["TestEndTime"].ToString();
                }
            }
        }
    }
    
    protected void TestInfo_Click(object sender, EventArgs e)
    {

    }
   
    protected void Students_Click(object sender, EventArgs e)
    {
        



    }
    protected void AddClass_Click(object sender, EventArgs e)
    {

    }


    protected void SectionInfo_SelectedIndexChanged(object sender, EventArgs e)
   {
       if (this.KnowledgePointInfo != null)
       {
           this.KnowledgePointInfo.ClearSelection();
           this.KnowledgePointInfo.Items.Clear();
       }
       if (this.SectionInfo.Items[0].Selected)
       {
           for (int i = 1; i < this.SectionInfo.Items.Count; i++)
           {
               this.SectionInfo.Items[i].Enabled = false;
           }

           ListItem Item = new ListItem("全部知识点", "0");
           this.KnowledgePointInfo.Items.Add(Item);
           using (MySqlDataReader read = new Diya().RowReader("Select KnowledgePointID,KnowledgePointName from KnowledgePoint"))
           {
               while (read.Read())
               {
                   Item = new ListItem(read["KnowledgePointName"].ToString(), read["KnowledgePointID"].ToString());
                   this.KnowledgePointInfo.Items.Add(Item);
               }
           }


       }
       else
       { 
           ListItem Item = new ListItem("全部知识点", "0");
           this.KnowledgePointInfo.Items.Add(Item);
           int i = 0;
           for (int j = 1; j < this.SectionInfo.Items.Count; j++)
           {
               this.SectionInfo.Items[j].Enabled = true;
           }
           for (i = 1; i < SectionInfo.Items.Count; i++)
           {
               if (SectionInfo.Items[i].Selected)
               {

                   string cmd = "Select KnowledgePointID,KnowledgePointName from KnowledgePoint where SectionID=" + SectionInfo.Items[i].Value;
                   using (MySqlDataReader read = new Diya().RowReader(cmd))
                   {
                       while (read.Read())
                       {
                           ListItem item = new ListItem(read["KnowledgePointName"].ToString(), read["KnowledgePointID"].ToString());
                           this.KnowledgePointInfo.Items.Add(item);
                       }
                   }
               }
           }
         
              
               //using (MySqlDataReader read = Diya.RowReader(Kcomd))
               //{
               //    while (read.Read())
               //    {
               //        Item = new ListItem(read["KnowledgePointName"].ToString(), read["KnowledgePointID"].ToString());
               //        this.KnowledgePointInfo.Items.Add(Item);
               //    }
               //}
           
       }
        
    }
    protected void KnowledgePointInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.KnowledgePointInfo.Items[0].Selected)
        {
            for (int i = 1; i < KnowledgePointInfo.Items.Count; i++)
            {
                //this.KnowledgePointInfo.Items[i].Selected = true;
                this.KnowledgePointInfo.Items[i].Enabled = false;
            }
        }
        else
        {
            for (int i = 1; i < this.KnowledgePointInfo.Items.Count; i++)
            {
                this.KnowledgePointInfo.Items[i].Enabled = true;
            }
        }
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        //this.PlaseWait.Visible = true;
        if (Request["Mode"] != "Up")
        {
            
            string SelectT_idCmd = "Select TopicID From TKRelationship where 1>0";
            string Score = this.TextScore.Text == "" ? "1" : this.TextScore.Text;
            string Err = "";
            if (this.TestName.Text == "")
            {
                Err += "考试名称不能为空";
            }
            if (!new Diya().checktext("N", this.TextScore.Text))
            {
                Err += "<br>考试分值只能是数字";
                this.TextScore.ForeColor = System.Drawing.Color.Red;
            }
            if (!new Diya().checktext("N", this.TestCount.Text))
            {
                Err += "<br>考题数量只能是数字";
                this.TestCount.ForeColor = System.Drawing.Color.Red;
            }
            if (Err == "")
            {
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();
                    MySqlCommand Scmd = new MySqlCommand("Insert Into TestInfo(TestName,TestCount,TopicScore,TestStartTime,TestEndTime) values('" + this.TestName.Text + "'," + this.TestCount.Text + "," + this.TextScore.Text + ",'" + this.TestStartDate.Value + "','" + this.TestEndDate.Value + "')", Sc);
                    Scmd.ExecuteNonQuery();

                }
                string TestID = "";
                using (MySqlDataReader read = new Diya().RowReader("select max(TestID) as a From TestInfo"))
                {
                    read.Read();
                    TestID = read["a"].ToString();
                }
                if (this.KnowledgePointInfo.Items[0].Selected)
                {
                    for (int i = 1; i < KnowledgePointInfo.Items.Count; i++)
                    {
                        SelectT_idCmd += " or KnowledgePointID=" + this.KnowledgePointInfo.Items[i].Value;
                        //using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                        //{
                        //    Sc.Open();
                        //    MySqlCommand Scmd = new MySqlCommand("insert into TTRelationship(TestID,KnowledgePointID) values("+TestID+","+this.KnowledgePointInfo.Items[i].Value+")", Sc);
                        //    Scmd.ExecuteNonQuery();
                        //}
                    }
                }
                else
                {
                    for (int i = 1; i < this.KnowledgePointInfo.Items.Count; i++)
                    {
                        if (this.KnowledgePointInfo.Items[i].Selected)
                        {
                            SelectT_idCmd += " or KnowledgePointID=" + this.KnowledgePointInfo.Items[i].Value;
                            //using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                            //{
                            //    Sc.Open();
                            //    MySqlCommand Scmd = new MySqlCommand("insert into TTRelationship(TestID,KnowledgePointID) values(" + TestID + "," + this.KnowledgePointInfo.Items[i].Value + ")", Sc);
                            //    Scmd.ExecuteNonQuery();
                            //}

                        }
                    }
                }
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();
                    MySqlDataAdapter Da = new MySqlDataAdapter(SelectT_idCmd, Sc);
                    DataSet Ds = new DataSet();
                    Da.Fill(Ds);
                    int TopicCount = Ds.Tables[0].Rows.Count;
                    int count = Convert.ToInt32(this.TestCount.Text);
                    if (count > Ds.Tables[0].Rows.Count)
                    {
                        count = Ds.Tables[0].Rows.Count;
                        //
                        using (MySqlConnection Sc_Up = new MySqlConnection(Diya.ConectionString))
                        {
                            Sc_Up.Open();
                            MySqlCommand Scmd_Up = new MySqlCommand("Update TestInfo set TestCount="+count+" where TestID="+TestID, Sc_Up);
                            Scmd_Up.ExecuteNonQuery();
                        }

                    }
                    int[] randomindexes = new int[count];
                    new TIA().RandomArray(randomindexes,TopicCount);
                    for (int i = 0; i < count; i++)
                    {
                        using (MySqlConnection Scin = new MySqlConnection(Diya.ConectionString))
                        {
                            Scin.Open();
                            MySqlCommand Scmd = new MySqlCommand("insert into TTRelationship(TestID,TopicID)values(" + TestID + "," + Ds.Tables[0].Rows[randomindexes[i]]["TopicID"] + ")", Scin);
                            Scmd.ExecuteNonQuery();
                        }
                        string TTRelationship_id = "";
                        using (MySqlDataReader read = new Diya().RowReader("select max(RelationshipID) as id from TTRelationship"))//获取新生成的relationshipid
                        {
                            read.Read();
                            TTRelationship_id = read["id"].ToString();

                        }
                        DataSet ODS = new DataSet();
                        using (MySqlConnection Scin = new MySqlConnection(Diya.ConectionString))//获取相应的选项id
                        {
                            Scin.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("Select OptionID From Options where TopicID=" + Ds.Tables[0].Rows[randomindexes[i]]["TopicID"], Scin);

                            da.Fill(ODS);
                        }
                        int[] Optidsindex = new int[ODS.Tables[0].Rows.Count];
                        new TIA().RandomArray(Optidsindex,Optidsindex.Length);
                        for (int j = 0; j < Optidsindex.Length; j++)
                        {
                            using (MySqlConnection Scin = new MySqlConnection(Diya.ConectionString))
                            {
                                Scin.Open();
                                MySqlCommand Scmd = new MySqlCommand("insert into OTRelationship(TTRelationshipID,OptionID) values (" + TTRelationship_id + "," + ODS.Tables[0].Rows[Optidsindex[j]]["OptionID"] + ")", Scin);
                                Scmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
               
            }
            else
            {

            }
        }
        else
        {
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string updatestring = "Update TestInfo Set TestStartTime='" +this.TestStartDate.Value+ "',TestEndTime='" + this.TestEndDate.Value + "' where TestID=" + ViewState["id"];
                MySqlCommand Scmd = new MySqlCommand(updatestring, Sc);
                Scmd.ExecuteNonQuery();
            }
            using (MySqlDataReader read = new Diya().RowReader("select ContactID From TSRelationship where TestID=" + ViewState["id"]))
            {
                while (read.Read())
                {
                    using (MySqlConnection Scin = new MySqlConnection(Diya.ConectionString))
                    {
                        Scin.Open();
                        MySqlCommand Scmd = new MySqlCommand("insert into TSRelationship(TestID,ContactID,Score)Values(" + ViewState["id"] + "," + read["ContactID"] + "," + "1)", Scin);
                        Scmd.ExecuteNonQuery();
                    }
                }
            }
        }
        Session["TheScene"] = "6";
         Response.Redirect("Consultion.aspx");
    }
}