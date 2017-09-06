using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_TestMould : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                if (Request.Cookies["UserConfig"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    HttpCookie cookie = Request.Cookies["UserConfig"];
                    Session["UserInfo"] = Server.HtmlEncode(new Diya().GetDESDecrypt(cookie.Value));
                }
            }
            string[] Info = Session["UserInfo"].ToString().Split(new char[] { '#' });
            Diya.GetUserInfo(Convert.ToInt32(Info[0]), Info[1], Info[2]);
            this.landinfo.Text = Info[2];
            ViewState["UserID"] = Info[1];       
            ViewState["TestMouldInfo"] = new Diya().Gridviewbind(this.TestMouldGV, "select * from TestMouldInfo where Userid='"+ViewState["UserID"]+ "' order by  MouldID desc");
            
            if(this.TestMouldGV.Rows.Count==0)
            {
                this.TestMouldGV.Visible =false;
                this.NullData.Visible = true;
            }
            else
            {
                this.TestMouldGV.Visible = true;
                this.NullData.Visible = false;
            }
        }
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ++this.TestMouldGV.PageIndex;
        this.TestMouldGV.DataSource=(DataTable)ViewState["TestMouldInfo"];
        this.TestMouldGV.DataBind();
    }
    protected void FirsetPage_Click(object sender, EventArgs e)
    {
        this.TestMouldGV.PageIndex = 0;
        this.TestMouldGV.DataSource = (DataTable)ViewState["TestMouldInfo"];
        this.TestMouldGV.DataBind();
    }
    protected void PagerControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index =Convert.ToInt32(this.PagerControl.SelectedValue);
        this.TestMouldGV.PageIndex = index;
        this.TestMouldGV.DataSource = (DataTable)ViewState["TestMouldInfo"];
        this.TestMouldGV.DataBind();
    }
    protected void FrontPage_Click(object sender, EventArgs e)
    {
        --this.TestMouldGV.PageIndex;
        this.TestMouldGV.DataSource = (DataTable)ViewState["TestMouldInfo"];
        this.TestMouldGV.DataBind();
    }
    protected void lastPage_Click(object sender, EventArgs e)
    {
        this.TestMouldGV.PageIndex = this.TestMouldGV.PageCount - 1;
        this.TestMouldGV.DataSource = (DataTable)ViewState["TestMouldInfo"];
        this.TestMouldGV.DataBind();
    }

    protected void TestMouldGV_DataBound(object sender, EventArgs e)
    {
        if(this.PagerControl!=null)
        {
            this.PagerControl.ClearSelection();
            this.PagerControl.Items.Clear();
        }
        if(this.TestMouldGV.PageCount!=0)
        {
            this.PagerControl.Enabled = true;
            this.NextPage.Enabled = true;
            this.FrontPage.Enabled = true;
            this.FirsetPage.Enabled = true;
            this.lastPage.Enabled = true;
            for(int i=0;i<this.TestMouldGV.PageCount;i++)
            {
                ListItem item = new ListItem((i+1)+"",i+"");
                if(this.TestMouldGV.PageIndex==i)
                {
                    item.Selected = true;
                }
                this.PagerControl.Items.Add(item);
            }
            this.PageCounts.Text = (this.TestMouldGV.PageIndex+1)+"/"+this.TestMouldGV.PageCount;
            if(this.TestMouldGV.PageIndex==0)
            {
                this.FrontPage.Enabled = false;
            }
            else
            {
                this.FrontPage.Enabled = true;
            }
            if(this.TestMouldGV.PageIndex==this.TestMouldGV.PageCount-1)
            {
                this.NextPage.Enabled = false;
            }
            else
            {
                this.NextPage.Enabled = true;
            }
        }
        else
        {
            this.PagerControl.Enabled = false;
            this.NextPage.Enabled = false;
            this.FrontPage.Enabled = false;
            this.FirsetPage.Enabled = false;
            this.lastPage.Enabled = false;
            this.PageCounts.Text = "0/0";
            this.NullData.Visible = true;
        }
    }

    protected void doBuf(string MouldId)
    {
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
        DataTable MouldTb = new DataTable();
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * From TestMouldInfo inner join MKRelationship on MKRelationship.MouldID=TestMouldInfo.MouldID inner join KnowledgePoint on KnowledgePoint.KnowledgePointID=MKRelationship.KnowledgePointID inner join Section on Section.SectionID=KnowledgePoint.SectionID where TestMouldInfo.Userid='" + ViewState["UserID"] + "' and TestMouldInfo.MouldID="+MouldId, Sc);
            da.Fill(MouldTb);
        }
        foreach (DataRow dr in MouldTb.Rows)
        {
            this.ReturnBuf.Value += dr["KnowledgePointID"].ToString() + "#";
            this.SurfaceBuf.Value += dr["Section"].ToString() + "$" + dr["KnowledgePointName"].ToString() + "#";
        }

    }


    protected int IDCount(string[] Str, string ID)
    {
        int count = 0;
        foreach (string s in Str)
        {
            if (ID == s)
            {
                count++;
            }
        }
        return count;
    }


    protected void TestMouldGV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="More")
        {
            ViewState["MouldID"] = e.CommandArgument;
            this.SurfaceBuf.Value = "";
            this.ReturnBuf.Value = "";
            this.SelectionBuf.Value = "";
            doBuf(e.CommandArgument.ToString());
            this.Sigen.Value = "1";
            this.MouldView.Visible = true;
            using (MySqlDataReader read = new Diya().RowReader("select * from TestMouldInfo where MouldID="+e.CommandArgument.ToString()))
            {
                read.Read();
                this.TestName.Value =read["MouldName"]+ "";
            }
            //Literal startScript = new Literal();
            //startScript.Text = "<script>document.onreadystatechange = function () {if (document.readyState ==\"complete\") { CreateRow() }}</script>";
            //this.Page.Controls.Add(startScript);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "StartScript", "<script>CreateRow();CreateNewRow();Finddivs();</script>");
            

        }       
        else if(e.CommandName=="Delete")
        {
            using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlCommand Scmd = new MySqlCommand("delete From MKRelationship where MouldID="+e.CommandArgument,Sc);
                Scmd.ExecuteNonQuery();
                Scmd.CommandText = "Delete Form TestMouldInfo where MouldID="+e.CommandArgument;
                Scmd.ExecuteNonQuery();
                ViewState["TestMouldInfo"] = new Diya().Gridviewbind(this.TestMouldGV, "select * from TestMouldInfo where Userid='" + ViewState["UserID"] + "'");

            }
        }
        else if(e.CommandName=="ToTest")
        {

        }
    }
    protected void Confirm_Click(object sender, EventArgs e)
    {

       
        
    }
    protected bool CreateTest(string M_Updatid)
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
                    Scmd.CommandText = "Update TestMouldInfo set  TopicCount="+testcount+" where MouldID="+M_Updatid;
                    Scmd.ExecuteNonQuery();
                    MySqlDataReader read;
                    //Scmd.CommandText = "Select max(MouldID) as a from TestMouldInfo where Userid='" + ViewState["UserID"].ToString() + "'";
                    //read = Scmd.ExecuteReader();
                    //read.Read();
                    //int MouldID = Convert.ToInt32(read["a"]);
                    //read.Close();
                    int Testid;
                    Scmd.CommandText = "select max(TestID) as a from TestInfo ";
                    read = Scmd.ExecuteReader();
                    read.Read();
                    
                    Testid = read.GetInt32(0);
                    read.Close();
                    Scmd.CommandText = "Select RelationshipID From MKRelationship where MouldID="+M_Updatid;
                    read = Scmd.ExecuteReader();
                    int index = 0;
                    while(read.Read())
                    {
                        using (MySqlConnection inSc = new MySqlConnection(Diya.ConectionString))
                        {
                            inSc.Open();
                            MySqlCommand inScmd = new MySqlCommand();
                            inScmd.CommandText = "Update MKRelationship set KnowledgePointID=" + knowledgepointIds[index] + " where RelationshipID=" + read.GetInt32(0);
                            inScmd.Connection = inSc;
                            inScmd.ExecuteNonQuery();
                        }
                        index++;
                    }
                    read.Close();
                    for (; index < knowledgepointIds.Length - 1;index++)
                    {
                        Scmd.CommandText = "Insert into MKRelationship(MouldID,KnowledgePointID)values(" + M_Updatid + "," + knowledgepointIds[index] + ")";
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
                        using (MySqlConnection Dsc = new MySqlConnection(Diya.ConectionString))
                        {
                            Dsc.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("Select OptionID from Options where TopicID=" + TopicID, Dsc);
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


    protected void ToTest_Click(object sender, EventArgs e)
    {
        //Literal Messsage = new Literal();
        //Messsage.Text = "<script>alert('"+this.ReturnBuf.Value+"')</script>";
        //this.Page.Controls.Add(Messsage);
        bool sec = CreateTest(ViewState["MouldID"].ToString());
        int sleep = 0;
        int Times = 0;
        while (!sec && Times < 4)
        {
            sleep += 1000;
            System.Threading.Thread.Sleep(sleep);
            sec = CreateTest(ViewState["MouldID"].ToString());
            Times++;
        }
        Literal Message = new Literal();
        Message.Text = "<script>alert('试卷添加未成功，稍后再试')</script>";
        this.Page.Controls.Add(Message);
    }
    protected void TestMouldGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}