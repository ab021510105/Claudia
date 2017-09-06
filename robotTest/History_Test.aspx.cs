using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class History_Test : System.Web.UI.Page
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
            ViewState["Contactid"] = Session["Contactid_S"];
            //string Selectcmd = "Select * from TSRelationship inner join TestInfo on TestInfo.Testid=TSRelationship.Testid where TSRelationship.Score is not null and TSRelationship.Contactid=" + Session["Contactid_S"];
            //ViewState["DataSource"] = Diya.Gridviewbind(this.Myhistory_Gw, Selectcmd);
            using (MySql.Data.MySqlClient.MySqlDataReader read = new Diya().RowReader("select * from ConsultingInfo where Contactid=" + ViewState["Contactid"].ToString()))
            {
                read.Read();
                this.landinfo.Text = read["ChildrenCall"].ToString() + "的考试信息";
            }
            string Contactid = Session["Contactid_S"].ToString();
            string startTime = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endTime = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.MinTime.Value = startTime +" 00:00:00";
            this.MaxTime.Value = endTime+" 23:59:59" ;
            DataTable KnowledgePoints = new DataTable();
            DataTable Knowledgelest = new DataTable();
            Knowledgelest.Columns.Add("KonwledgePointID");
            Knowledgelest.Columns.Add("Count");
            Knowledgelest.Columns.Add("Rights");
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select TKRelationship.KnowledgePointID from TSRelationship inner join TTRelationship on TTRelationship.TestID=TSRelationship.TestID inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join TestInfo on TSRelationship.TestID=TestInfo.TestID where TestInfo.TestStartTime Between '" + this.MinTime.Value + "' and '" + this.MaxTime.Value + "' and TSRelationship.Contactid=" + ViewState["Contactid"].ToString() + " order by TKRelationship.KnowledgePointID ", Sc);
                da.Fill(KnowledgePoints);
            }
            int Knowledgecount = 0;
            if (KnowledgePoints.Rows.Count != 0)
            {
                this.TestCount_div.Visible = true;
                this.Myhistory_Gw.Visible = true;
                string KnowledgeIDFlage = KnowledgePoints.Rows[0][0].ToString();
                foreach (DataRow Dr in KnowledgePoints.Rows)
                {
                    if (Dr[0].ToString() == KnowledgeIDFlage)
                    {
                        Knowledgecount++;
                    }
                    else
                    {
                        Knowledgelest.Rows.Add(Knowledgelest.NewRow());
                        Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["Count"] = Knowledgecount;
                        Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["KonwledgePointID"] = KnowledgeIDFlage;
                        Knowledgecount = 1;
                        KnowledgeIDFlage = Dr[0].ToString();
                    }
                }
                KnowledgeIDFlage = KnowledgePoints.Rows[KnowledgePoints.Rows.Count - 1][0].ToString();
                Knowledgecount = 0;
                for (int i = KnowledgePoints.Rows.Count - 1; i >= 0; i--)
                {
                    if (KnowledgePoints.Rows[i][0].ToString() == KnowledgeIDFlage)
                    {
                        Knowledgecount++;
                    }
                    else
                    {
                        Knowledgelest.Rows.Add(Knowledgelest.NewRow());
                        Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["Count"] = Knowledgecount;
                        Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["KonwledgePointID"] = KnowledgeIDFlage;
                        break;
                    }
                }
                foreach (DataRow Dr in Knowledgelest.Rows)
                {
                    int Rights = 0;
                    using (MySqlDataReader read = new Diya().RowReader("Select Count(*) as a from TSRelationship inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TestInfo.TestStartTime between '" + startTime + "' and '" + endTime + "' and TKRelationship.KnowledgePointID=" + Dr["KonwledgePointID"] + " and TSRelationship.Contactid=" + ViewState["Contactid"].ToString() + " and Options.IsTrue=1"))
                    {
                        read.Read();
                        Rights = read.GetInt32(0);
                    }
                    Dr["Rights"] = Rights;
                }

                DataSet Datasource = new DataSet();
                int Colindex = 0;
                for (int i = 0; i < Knowledgelest.Rows.Count; i++)
                {
                    if (i % 6 == 0)
                    {
                        Datasource.Tables.Add(new DataTable());
                        Colindex = 0;
                        //foreach (DataRow Dr in Knowledgelest.Rows)
                        //{
                        for (int j = i; j < i + 6 && j < Knowledgelest.Rows.Count; j++)
                        {
                            string KnowledgeName = "";
                            using (MySqlDataReader read = new Diya().RowReader("Select KnowledgePointName from KnowledgePoint where KnowledgePointID=" + Knowledgelest.Rows[j]["KonwledgePointID"]))
                            {
                                read.Read();
                                KnowledgeName = read["KnowledgePointName"].ToString();
                            }
                            Datasource.Tables[Datasource.Tables.Count - 1].Columns.Add(KnowledgeName);
                            //}
                        }
                        Datasource.Tables[Datasource.Tables.Count - 1].Rows.Add(Datasource.Tables[Datasource.Tables.Count - 1].NewRow());
                    }
                    double score = Convert.ToDouble(Knowledgelest.Rows[i]["Rights"]) / Convert.ToDouble(Knowledgelest.Rows[i]["Count"]);

                    Datasource.Tables[Datasource.Tables.Count - 1].Rows[0][Colindex++] = score.ToString("P") + "(" + Knowledgelest.Rows[i]["Rights"] + "/" + Knowledgelest.Rows[i]["Count"] + ")";
                }
                ViewState["GvIndex"] = 0;
                ViewState["CountData"] = Datasource;
                this.Count.Columns.Clear();
                this.Count.DataSource = Datasource.Tables[0];
                this.Count.DataBind();
                string Selectcmd = "Select * from TSRelationship inner join TestInfo on TestInfo.Testid=TSRelationship.Testid where TSRelationship.Score is not null and TSRelationship.Contactid=" + ViewState["Contactid"] + " and TestInfo.TestStartTime Between '" + startTime + "' and '" + endTime + "' order by TSRelationship.RelationshipID DESC";
                ViewState["DataSource"] = new Diya().Gridviewbind(this.Myhistory_Gw, Selectcmd);
            }
            else
            {
                Literal Message = new Literal();
                Message.Text = "<script>alert('目前没有任何记录')</script>";
                this.Page.Controls.Add(Message);
                this.TestCount_div.Visible = false;
                this.Myhistory_Gw.Visible = false;
            }
            BindWorngPageInfo();
        //    string Selectcmd = "Select * from TSRelationship inner join TestInfo on TestInfo.Testid=TSRelationship.Testid where TSRelationship.Score is not null and TSRelationship.Contactid=" + ViewState["Contactid"]+" order by TSRelationship.RelationshipID DESC";
        //ViewState["DataSource"] = Diya.Gridviewbind(this.Myhistory_Gw, Selectcmd);
        }
       
     
      
    }
    protected void TrunBack_Click(object sender, EventArgs e)
    {
        Session["TheScene"] = "5";
        Response.Redirect("Consultion.aspx");
    }
    protected void Myhistory_Gw_PageIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void Myhistory_Gw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Myhistory_Gw.PageIndex = e.NewPageIndex;
        this.Myhistory_Gw.DataSource =(System.Data.DataTable)ViewState["DataSource"];
        this.Myhistory_Gw.DataBind();
    }
    protected void My_Test_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string DeleteCmd = "Delete From HTRelationship Where TSRelationshipID="+e.CommandArgument;
                MySqlCommand Scmd = new MySqlCommand(DeleteCmd,Sc);
                Scmd.ExecuteNonQuery();
            }
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string DeleCmd = "Delete From TSRelationship Where RelationshipID="+e.CommandArgument;
                MySqlCommand Scmd = new MySqlCommand(DeleCmd, Sc);
                Scmd.ExecuteNonQuery();
            }
            string Selectcmd = "Select * from TSRelationship inner join TestInfo on TestInfo.Testid=TSRelationship.Testid where TSRelationship.Score is not null and TSRelationship.Contactid=" + ViewState["Contactid"].ToString();
            ViewState["DataSource"] = new Diya().Gridviewbind(this.Myhistory_Gw, Selectcmd);
        }
        else if(e.CommandName!="Page")
        {
            Session["TestID"] = e.CommandArgument;
            Session["TSRelationshipID"] = e.CommandName;
            Session["Contactid_S"] = ViewState["Contactid"];
            Response.Redirect("TestInfo_detailed.aspx");
        }
    }
    protected void Myhistory_Gw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void FrontPage_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)ViewState["CountData"];
        int pageinde = (int)ViewState["GvIndex"];
        this.Count.DataSource = ds.Tables[--pageinde];
        ViewState["GvIndex"] = pageinde;
        this.Count.DataBind();
        //this.Myhistory_Gw.PageIndex =Myhistory_Gw.PageIndex;
        //this.Myhistory_Gw.DataSource = (System.Data.DataTable)ViewState["DataSource"];
        //this.Myhistory_Gw.DataBind();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)ViewState["CountData"];
        int pageinde = (int)ViewState["GvIndex"];
        this.Count.DataSource = ds.Tables[++pageinde];
        ViewState["GvIndex"] = pageinde;
        this.Count.DataBind();
        //this.Myhistory_Gw.PageIndex = Myhistory_Gw.PageIndex;
        //this.Myhistory_Gw.DataSource = (System.Data.DataTable)ViewState["DataSource"];
        //this.Myhistory_Gw.DataBind();
    }
    protected void Count_DataBound(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)ViewState["CountData"];
        int pindex = (int)ViewState["GvIndex"];
        this.PageCount.Text = (pindex + 1) + "/" + ds.Tables.Count;
        if(ds.Tables.Count==0)
        {
            this.NextPage.Enabled = false;
            this.FrontPage.Enabled = false;
        }
        else
        {
            this.NextPage.Enabled = true;
            this.FrontPage.Enabled = true;
        }
        if(pindex==0)
        {
            this.FrontPage.Enabled = false;
        }
        else
        {
            this.FrontPage.Enabled = true;
        }
        if(pindex==ds.Tables.Count-1)
        {
            this.NextPage.Enabled = false;
        }
        else
        {
            this.NextPage.Enabled = true;
        }
    }
    protected void ScreachBtn_Click(object sender, EventArgs e)
    {
        string startTime = this.MinTime.Value;
        string endTime = this.MaxTime.Value;
        DataTable KnowledgePoints = new DataTable();
        DataTable Knowledgelest = new DataTable();
        Knowledgelest.Columns.Add("KonwledgePointID");
        Knowledgelest.Columns.Add("Count");
        Knowledgelest.Columns.Add("Rights");
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select TKRelationship.KnowledgePointID from TSRelationship inner join TTRelationship on TTRelationship.TestID=TSRelationship.TestID inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join TestInfo on TSRelationship.TestID=TestInfo.TestID where TestInfo.TestStartTime Between '"+this.MinTime.Value+"' and '"+this.MaxTime.Value+"' and TSRelationship.Contactid="+ViewState["Contactid"].ToString() +" order by TKRelationship.KnowledgePointID " ,Sc);
            da.Fill(KnowledgePoints);
        }
        int Knowledgecount = 0;
        if (KnowledgePoints.Rows.Count != 0)
        {
            this.TestCount_div.Visible = true;
            this.Myhistory_Gw.Visible = true;
            string KnowledgeIDFlage = KnowledgePoints.Rows[0][0].ToString();

            for(int i=0;i<KnowledgePoints.Rows.Count;i++)
            {
                if (KnowledgePoints.Rows[i][0].ToString() == KnowledgeIDFlage)
                {
                    Knowledgecount++;
                }
                else
                {
                    Knowledgelest.Rows.Add(Knowledgelest.NewRow());
                    Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["Count"] = Knowledgecount;
                    Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["KonwledgePointID"] = KnowledgeIDFlage;
                    Knowledgecount = 1;
                    KnowledgeIDFlage = KnowledgePoints.Rows[i][0].ToString();
                }
                
            }
            KnowledgeIDFlage = KnowledgePoints.Rows[KnowledgePoints.Rows.Count - 1][0].ToString();
            Knowledgecount = 0;
            for (int i = KnowledgePoints.Rows.Count - 1; i >= 0; i--)
            {
                if (KnowledgePoints.Rows[i][0].ToString() == KnowledgeIDFlage)
                {
                    Knowledgecount++;
                }
                else
                {
                    Knowledgelest.Rows.Add(Knowledgelest.NewRow());
                    Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["Count"] = Knowledgecount;
                    Knowledgelest.Rows[Knowledgelest.Rows.Count - 1]["KonwledgePointID"] = KnowledgeIDFlage;
                    break;
                }
            }

            foreach (DataRow Dr in Knowledgelest.Rows)
            {
                int Rights = 0;
                using (MySqlDataReader read = new Diya().RowReader("Select Count(*) as a from TSRelationship inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TestInfo.TestStartTime between '" + this.MinTime.Value + "' and '" + this.MaxTime.Value + "' and TKRelationship.KnowledgePointID=" + Dr["KonwledgePointID"] + " and TSRelationship.Contactid=" + ViewState["Contactid"].ToString() + " and Options.IsTrue=1"))
                {
                    read.Read();
                    Rights = read.GetInt32(0);
                }
                Dr["Rights"] = Rights;
            }

            DataSet Datasource = new DataSet();
            int Colindex = 0;
            for (int i = 0; i < Knowledgelest.Rows.Count; i++)
            {
                if (i % 6 == 0)
                {
                    Datasource.Tables.Add(new DataTable());
                    Colindex = 0;
                    //foreach (DataRow Dr in Knowledgelest.Rows)
                    //{
                    for(int j=i;j<i+6&&j<Knowledgelest.Rows.Count;j++)
                    {
                        string KnowledgeName = "";
                        using (MySqlDataReader read = new Diya().RowReader("Select KnowledgePointName from KnowledgePoint where KnowledgePointID=" + Knowledgelest.Rows[j]["KonwledgePointID"]))
                        {
                            read.Read();
                            KnowledgeName = read["KnowledgePointName"].ToString();
                        }
                        Datasource.Tables[Datasource.Tables.Count - 1].Columns.Add(KnowledgeName);
                    //}
                    }
                    Datasource.Tables[Datasource.Tables.Count - 1].Rows.Add(Datasource.Tables[Datasource.Tables.Count - 1].NewRow());
                }
                double score = Convert.ToDouble(Knowledgelest.Rows[i]["Rights"]) / Convert.ToDouble(Knowledgelest.Rows[i]["Count"]);

                Datasource.Tables[Datasource.Tables.Count - 1].Rows[0][Colindex++] = score.ToString("P") + "(" + Knowledgelest.Rows[i]["Rights"] + "/" + Knowledgelest.Rows[i]["Count"] + ")";
            }
            ViewState["GvIndex"] = 0;
            ViewState["CountData"] = Datasource;
            this.Count.Columns.Clear();
            this.Count.DataSource = Datasource.Tables[0];
            this.Count.DataBind();
            string Selectcmd = "Select * from TSRelationship inner join TestInfo on TestInfo.Testid=TSRelationship.Testid where TSRelationship.Score is not null and TSRelationship.Contactid=" + ViewState["Contactid"] + " and TestInfo.TestStartTime Between '" + this.MinTime.Value + "' and '" + this.MaxTime.Value + "' order by TSRelationship.RelationshipID DESC";
            ViewState["DataSource"] = new Diya().Gridviewbind(this.Myhistory_Gw, Selectcmd);
            BindWorngPageInfo();
        }
        else
        {
            Literal Message = new Literal();
            Message.Text = "<script>alert('目前没有任何记录')</script>";
            this.Page.Controls.Add(Message);
            this.TestCount_div.Visible = false;
            this.Myhistory_Gw.Visible = false;
        }
    }
    protected void TheLast1Day_Click(object sender, EventArgs e)
    {
        this.MaxTime.Value = System.DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        this.MinTime.Value = System.DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
    }
    protected void TheLast3Day_Click(object sender, EventArgs e)
    {
        this.MinTime.Value = System.DateTime.Now.AddDays(-3.0).ToString("yyyy-MM-dd");
        this.MaxTime.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
    }
    protected void TheLast7Day_Click(object sender, EventArgs e)
    {
        this.MinTime.Value = System.DateTime.Now.AddDays(-7.0).ToString("yyyy-MM-dd");
        this.MaxTime.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
    }
    protected void LastOneMonth_Click(object sender, EventArgs e)
    {
        this.MinTime.Value = System.DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
        this.MaxTime.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
    }
    protected void ResetScore_Btn_Click(object sender, EventArgs e)
    {
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlTransaction Tran = Sc.BeginTransaction();
            MySqlCommand Scmd = new MySqlCommand();
            Scmd.Transaction = Tran;
            Scmd.Connection = Sc;
            try
            {

                Scmd.CommandText = "Select RelationshipID From TSRelationship where Score is not null";
                MySqlDataReader RelationShipIDReader = Scmd.ExecuteReader();
                DataTable RelationshipIDTable = new DataTable();
                RelationshipIDTable.Columns.Add("RelationshipID");
                while (RelationShipIDReader.Read())
                {
                    RelationshipIDTable.Rows.Add(RelationshipIDTable.NewRow());
                    RelationshipIDTable.Rows[RelationshipIDTable.Rows.Count - 1][0] = RelationShipIDReader["RelationshipID"];
                }
                RelationShipIDReader.Close();
                foreach (DataRow dr in RelationshipIDTable.Rows)
                {
                    string Sqlcom = "select * From HTRelationship where TSRelationshipID=" + dr[0] + " order by TopicID";
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    Scmd.CommandText = Sqlcom;
                    da.SelectCommand = Scmd;
                    DataTable bufdt = new DataTable();
                    da.Fill(bufdt);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TSRelationshipID");
                    dt.Columns["TSRelationshipID"].DefaultValue = dr[0];
                    dt.Columns.Add("TopicID");
                    dt.Columns.Add("SelectedOptionID");
                    dt.Rows.Add(dt.NewRow());
                    if (bufdt.Rows.Count != 0)
                    {
                        dt.Rows[0]["TopicID"] = bufdt.Rows[0]["TopicID"];
                        dt.Rows[0]["SelectedOptionID"] = bufdt.Rows[0]["SelectedOptionID"];
                        for (int i = 1; i < bufdt.Rows.Count; i++)
                        {
                            if (bufdt.Rows[i]["TopicID"].ToString() != bufdt.Rows[i - 1]["TopicID"].ToString())
                            {
                                dt.Rows.Add(dt.NewRow());
                                dt.Rows[dt.Rows.Count - 1]["TopicID"] = bufdt.Rows[i]["TopicID"];
                                dt.Rows[dt.Rows.Count - 1]["SelectedOptionID"] = bufdt.Rows[i]["SelectedOptionID"];
                            }
                        }
                        //MySqlCommand Scmd = new MySqlCommand("Delete From HTRelationship where TSRelationshipID=252", Sc);
                        Scmd.CommandText = "Delete From HTRelationship where TSRelationshipID=" + dr[0];
                        Scmd.ExecuteNonQuery();
                        foreach (DataRow _dr in dt.Rows)
                        {
                            Scmd.CommandText = "insert into HTRelationship(TSRelationshipID,TopicID,SelectedOptionID)values(" + dr[0] + "," + _dr["TopicID"] + "," + _dr["SelectedOptionID"] + ")";
                            Scmd.ExecuteNonQuery();
                        }
                    }



                    Scmd.CommandText = "Select Count(*) From HTRelationship inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where Options.IsTrue=1 and HTRelationship.TSRelationshipID=" + dr[0];
                    MySqlDataReader read = Scmd.ExecuteReader();
                    read.Read();
                    int Righters = read.GetInt32(0);
                    read.Close();
                    Scmd.CommandText = "Update TSRelationship set Score=" + Righters + " where RelationshipID=" + dr[0];
                    Scmd.ExecuteNonQuery();

                }


                Tran.Commit();
            }
            catch (Exception)
            {
                Tran.Rollback();
                Literal Messange = new Literal();
                Messange.Text = "<Script>alert('失败')</Script>";
                this.Page.Controls.Add(Messange);
            }
        }
    }
    protected void Worng_Q_T_FirstPage_Click(object sender, EventArgs e)//ViewState["WrongKnowLedgeData"]
    {
        this.Worng_Q_T.PageIndex = 0;
        this.Worng_Q_T.DataSource = (DataTable)ViewState["WrongKnowLedgeData"];
        this.Worng_Q_T.DataBind();
    }
    protected void Wrong_Q_T_FonrPage_Click(object sender, EventArgs e)
    {
        this.Worng_Q_T.PageIndex--;
        this.Worng_Q_T.DataSource= (DataTable)ViewState["WrongKnowLedgeData"];
        this.Worng_Q_T.DataBind();
    }
    protected void Wrong_Q_TDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Worng_Q_T.PageIndex = Convert.ToInt32(this.Wrong_Q_TDropDownList.SelectedValue);
        this.Worng_Q_T.DataSource = (DataTable)ViewState["WrongKnowLedgeData"];
        this.Worng_Q_T.DataBind();
    }
    protected void Wrong_Q_T_NextPage_Click(object sender, EventArgs e)
    {
        this.Worng_Q_T.PageIndex++;
        this.Worng_Q_T.DataSource = (DataTable)ViewState["WrongKnowLedgeData"];
        this.Worng_Q_T.DataBind();
    }
    protected void Wrong_Q_T_LastPage_Click(object sender, EventArgs e)
    {
        this.Worng_Q_T.PageIndex = this.Worng_Q_T.PageCount - 1;
        this.Worng_Q_T.DataSource = (DataTable)ViewState["WrongKnowLedgeData"];
        this.Worng_Q_T.DataBind();
    }
    protected void Worng_Q_T_DataBound(object sender, EventArgs e)
    {
        if (this.Wrong_Q_TDropDownList != null)
        {
            this.Wrong_Q_TDropDownList.ClearSelection();
            this.Wrong_Q_TDropDownList.Items.Clear();
        }
        for (int i = 0; i < this.Worng_Q_T.PageCount; i++)
        {
            ListItem item = new ListItem(Convert.ToString(i + 1),Convert.ToString(i));
            if (i == this.Worng_Q_T.PageIndex)
            {
                item.Selected = true;
            }
            this.Wrong_Q_TDropDownList.Items.Add(item);
        }
        this.Wrong_Q_T_PageCount.Text = (this.Worng_Q_T.PageIndex+1)+"/"+this.Worng_Q_T.PageCount;
        if (this.Worng_Q_T.PageIndex == this.Worng_Q_T.PageCount - 1)
        {
            this.Wrong_Q_T_NextPage.Enabled = false;
        }
        else
        {
            this.Wrong_Q_T_NextPage.Enabled = true;
        }
        if (this.Worng_Q_T.PageIndex == 0)
        {
            this.Wrong_Q_T_FonrPage.Enabled = false;
        }
        else
        {
            this.Wrong_Q_T_FonrPage.Enabled = true;
        }
    }
    protected void BindWorngPageInfo()
    {
        DataTable DataBase = new DataTable();
        DataBase.Columns.Add("KnowledgePointName");
        DataBase.Columns.Add("WorngCount");
        DataBase.Columns.Add("KnowledgePointID");
        string SelectCmd = "Select  KnowledgePoint.KnowledgePointID,KnowledgePoint.KnowledgePointName from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID inner join KnowledgePoint on KnowledgePoint.KnowledgePointID=TKRelationship.KnowledgePointID where TSRelationship.Contactid=" + ViewState["Contactid"].ToString()+" and Options.IsTrue=0 and TestInfo.TestStartTime between '"+this.MinTime.Value+"' and '"+this.MaxTime.Value+"' order by KnowledgePoint.KnowledgePointID";
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlCommand Scmd = new MySqlCommand(SelectCmd,Sc);
            DataTable Dbuf = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = Scmd;
            da.Fill(Dbuf);
            for (int i = 0; i < Dbuf.Rows.Count - 1; i++)
            {
                if (Dbuf.Rows[i]["KnowledgePointID"].ToString() != Dbuf.Rows[i + 1]["KnowledgePointID"].ToString())
                {
                    DataRow dr = DataBase.NewRow();
                    dr["KnowledgePointName"] = Dbuf.Rows[i]["KnowledgePointName"].ToString();
                    dr["KnowledgePointID"] = Dbuf.Rows[i]["KnowledgePointID"].ToString();
                    DataBase.Rows.Add(dr);
                }
                else if(i+1==Dbuf.Rows.Count-1)
                {
                    if (Dbuf.Rows[i + 1]["KnowledgePointID"].ToString() != DataBase.Rows[DataBase.Rows.Count - 1]["KnowledgePointID"].ToString())
                    {
                        DataRow dr = DataBase.NewRow();
                        dr["KnowledgePointName"] = Dbuf.Rows[i + 1]["KnowledgePointName"].ToString();
                        dr["KnowledgePointID"] = Dbuf.Rows[i+1]["KnowledgePointID"].ToString();
                        DataBase.Rows.Add(dr);
                    }
                }
            }
            foreach (DataRow Dr in DataBase.Rows)
            {
                SelectCmd = "Select Count(*) as a from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID where TKRelationship.KnowledgePointID="+Dr["KnowledgePointID"]+" and Options.IsTrue=0 and TestInfo.TestStartTime between '"+this.MinTime.Value+"' and '"+this.MaxTime.Value+"' and TSRelationship.Contactid="+ViewState["Contactid"].ToString();
                Diya diya = new Diya();
                using (MySqlDataReader read = diya.RowReader(SelectCmd))
                {
                    read.Read();
                    Dr["WorngCount"] = read["a"].ToString();
                }

            }
            this.Worng_Q_T.DataSource = DataBase;
            ViewState["WrongKnowLedgeData"] = DataBase;
            this.Worng_Q_T.DataBind();
        }
    }

    protected void Worng_Q_T_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ConvertToTIA")
        {
            Session["DataScoure_TIA"] = "select Topic.TopicID,Topic.TopicContent,Topic.HaveContent,Topic.MoreContent,HTRelationship.SelectedOptionID from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join Topic on Topic.TopicID=HTRelationship.TopicID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID where Options.IsTrue=0 and TestInfo.TestStartTime between '" + this.MinTime.Value + "' and '" + this.MaxTime.Value + "' and TSRelationship.Contactid=" + ViewState["Contactid"].ToString() + " and TKRelationship.KnowledgePointID="+e.CommandArgument+" order by Topic.TopicID DESC";
            Session["Contactid_S"] = ViewState["Contactid"].ToString();
            Response.Redirect("TestInfo_detailed.aspx");
        }
    }
}