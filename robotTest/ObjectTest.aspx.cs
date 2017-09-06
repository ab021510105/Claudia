 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient
;
using System.IO;
//using System.Xml.Linq;
namespace Test
{
    public partial class ObjectTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            
           // AjaxPro.Utility.RegisterTypeForAjax(typeof(Test.ObjectTest));
            if (!IsPostBack)
            { 
               // weather();
               //Session["LandInfo"] = "15050003";
               //LandInfo_Userid.Value = "15050003";
                if (Session["LandInfo"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                
                //TestInfoBind();
                //MyTheme.GridView.GvStyle1 gv = Session["TestInfo"] as MyTheme.GridView.GvStyle1;
                //string str = gv.CreateGridView();
            }
           
        }
        //[AjaxPro.AjaxMethod]
        public int SignOut()
        {
            Session["LandInfo"] = null;
            return 0;
        }

        //[AjaxPro.AjaxMethod]
        public string GetUserInfo()
        {
            string Info = "";
            using (MySqlDataReader read = new Diya().RowReader("select * From ConsultingInfo where Contactid="+Session["LandInfo"].ToString()))
            {
                read.Read();
                Info+=Session["LandInfo"].ToString()+"#"+read["ChildrenCall"].ToString();
            }


            return Info;
        }



        protected string getFile(string FileName)
        {
            string templateFileName = Path.Combine(Server.MapPath("."), FileName);
            string[] buf = templateFileName.Split(new char[]{'\\'});
            templateFileName = "";
            for (int i = 0; i < buf.Length - 1; i++)
            {
                if (buf[i] != "ajaxpro")
                {
                    templateFileName += buf[i]+"\\";
                }
            }
            templateFileName+=buf[buf.Length-1];
            //templateFileName = buf[0] + "\\" + buf[1] + "\\" + buf[3];
            StreamReader reader = new StreamReader(@templateFileName, System.Text.Encoding.GetEncoding("UTF-8"));
            string html = reader.ReadToEnd();
            reader.Close();
            return html;
        }
        //[AjaxPro.AjaxMethod]
        public string StartMyTest()
        {
            
            return  getFile("robotTest/ProgramData/MyTest.soc");
        }



        protected void ClearSession()
        {
            string temp = Session["LandInfo"].ToString();
            Session.Clear();
            Session["LandInfo"] = temp;
        }
        
        //[AjaxPro.AjaxMethod]
        public string getuserid()
        {
            if (Session["LandInfo"] != null)
            {
                return Session["LandInfo"].ToString();
            }
            else
            {
                return "noID";
            }
        }
        //[AjaxPro.AjaxMethod]
        public string GetUserName()
        {
            string UserName;
            using (MySqlDataReader read = new Diya().RowReader("Select * from ConsultiongInfo where Contactid=" + Session["LandInfo"].ToString()))
            {
                read.Read();
                UserName = read["Children"].ToString();
            }
            return UserName;
            
        }

       protected void getTest()
       {

       }
        public string GetServerTime()
        {
           int week=Convert.ToInt32(DateTime.Now.DayOfWeek);
           return DateTime.Now.ToString("HH:mm#yyyy年MM月dd日")+"#"+week;
        }

        protected void TestInfoBind()
        {
            //string selectcommand = "select * from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.Score is NULL and TSRelationship.Contactid=" + Session["LandInfo"].ToString();
            string selectcommand = "select * from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.Score is NULL and TSRelationship.Contactid=" + Session["LandInfo"].ToString();
            MyTheme.GridView.GvStyle1 Gv1 = new MyTheme.GridView.GvStyle1();
            MyTheme.GridView.GridViewButton GvButton = new MyTheme.GridView.GridViewButton();
            Gv1.PageSize = 10;
            GvButton.ButtonText = "开始考试";
            GvButton.ButtonDataFeld = "TestID";
            GvButton.ButtonID = "StartTest_btn";
            Gv1.Title = "考试信息";
            Gv1.Gvname = "TestInfo";
            Gv1.RefreshFunctionName = "TestInfoRef";
            Gv1.Buttons = new object[] {GvButton};
            Gv1.PrimaryKey = "RelationshipID";
            Gv1.ColDataFlied = new string[,] { {"考试名称","TestName" },{"考试开始时间","TestStartTime"},{"考试结束时间","TestEndTime"} };
            using (MySqlConnection Sc = new MySqlConnection(""))
            {
                Sc.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(selectcommand,Sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Gv1.Datasocure = dt;
            }
            Gv1.OnRowBound = new EventHandler(TestInfo_OnRowBound);
            Session["TestInfo"] = Gv1;
        }
        //[AjaxPro.AjaxMethod]
        public int  CleanMyTestInfo()
        {
            Session["TestInfo"] = null;
            return 0;
        }

        //[AjaxPro.AjaxMethod]
        public string BindMyTestInfo(int Pageindex)
        {
            if (Session["TestInfo"] == null)
            {
                TestInfoBind();
            }
            MyTheme.GridView.GvStyle1 Gv = (MyTheme.GridView.GvStyle1)Session["TestInfo"];
            string html = Gv.CreateGridView();
            if (Gv.PageCount == 0)
            {
                return "<div style=\"border:1px solid black;width:100%\">目前没有考试信息</div>";
            }
            else
            {
                Gv.Pageindex = Pageindex;
                return html;
            }
        }
        //[AjaxPro.AjaxMethod]
        public string GetQuizTitle(string TestID)
        {
            string Title = "";
            Diya diya = new Diya();
            int  TestLong=0;
            using (MySqlDataReader read = diya.RowReader("Select * from TestInfo where TestID="+TestID))
            {
                read.Read();
                Title += read["TestName"].ToString()+"#"+read["TestCount"]+"#";
                DateTime End = Convert.ToDateTime(read["TestEndTime"]);
                int EndValue =Convert.ToInt32(End.ToString("ddHHmm"));
                int NowValue = Convert.ToInt32(DateTime.Now.ToString("ddHHmm"));
                TestLong = EndValue - NowValue;
            }
            Title += TestLong;
            return Title;
        }

        //[AjaxPro.AjaxMethod]
        public int NeedRefresh()
        {
            if(Session["NeedRefresh"]!=null)
            {
                return Convert.ToInt32(Session["NeedRefresh"].ToString());
            }
            else
            {
                return 0;
            }
        }


        protected void TestInfo_OnRowBound(object sender, EventArgs e)
        {
            Session["NeedRefresh"] = 0;
            MyTheme.GridView.Rowsender s = (MyTheme.GridView.Rowsender)sender;
            DataRow dr=s.datarow;
            DateTime TestStartTime =Convert.ToDateTime( dr["TestStartTime"]);
            DateTime TestEndTime =Convert.ToDateTime(dr["TestEndTime"]);
            long TodayNow =Convert.ToInt64(System.DateTime.Now.ToString("yyMMddHHmmss"));
            long start = Convert.ToInt64(TestStartTime.ToString("yyMMddHHmmss"));
            long end = Convert.ToInt64(TestEndTime.ToString("yyMMddHHmmss"));
            string btnid = "StartTest_btn";           
            MyTheme.GridView.GvStyle1 gv = s.sender as MyTheme.GridView.GvStyle1;
            object[] buttons = gv.Buttons;
            if (TodayNow<start)
            {
                foreach (object btn in buttons)
                {
                    MyTheme.GridView.GridViewButton _btn = (MyTheme.GridView.GridViewButton)btn;
                    if (_btn.ButtonID == btnid)
                    {
                        _btn.disabled = true;
                        _btn.ButtonText = "不在时间段内";
                        break;
                    }
                }
            }
            else if(TodayNow>=end)
            {
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();
                    MySqlCommand


 Scmd = new MySqlCommand


();
                    Scmd.CommandText = "update TSRelationship set Score=0 where RelationshipID="+dr["RelationshipID"].ToString();
                    Scmd.Connection = Sc;
                    Scmd.ExecuteNonQuery();
                }
                Session["TestInfo"] = null;
                TestInfoBind();
                Session["NeedRefresh"] = 1;
            }
           
        }
        //[AjaxPro.AjaxMethod]
        public string QuizBlind(int pagindex,string TestID,int PageItem)
        {
            TIA tia;
            if (Session["tia"] == null)
            {
                 Session["tia"]= new TIA();
            }
            string html = "";
            tia = (TIA)Session["tia"];
            html+= tia.Quizeloader(TestID,PageItem,pagindex+1);
            Session["tia"] = tia;
            //tia.Dst.Clear();
            //tia.indexList = new DataTable();
            //tia.Dst = new DataStates(); 
            return html;

        }
        //[AjaxPro.AjaxMethod]
        public int GetQuizPageCount()
        {
            TIA tia=(TIA)Session["tia"];
            return tia.QuizPagerCount;
        }


        //[AjaxPro.AjaxMethod]
        public int CreateUploadeTabel(int pagindex,string TestID,int PageItem)
        {
            TIA tia;
            if(Session["tia"]==null)
            {
                tia = new TIA();
                tia.Quizeloader(TestID, PageItem, pagindex);
                Session["tia"] = tia;
            }
            tia=(TIA)Session["tia"];
            Session["UploadDataTable"] = tia.dt;
            return 0;
        }

        //[AjaxPro.AjaxMethod]
        public int AddOptionsid(string OptionsID)
        {
            DataTable dt=(DataTable)Session["UploadDataTable"];
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["OptionID"].ToString() == OptionsID)
                {
                    dr["Selected"] = 1;
                    break;
                }
            }
            Session["UploadDataTable"] = dt;
            return 0;
        }
        //[AjaxPro.AjaxMethod]
        public string RemoveOptionsid(string OptionsID, string TopicID)
        {
            string note = "";
            TIA tia = (TIA)Session["tia"];
            //Session.Timeout += 10;
            foreach (DataRow dr in tia.dt.Rows)
            {
                if (dr["OptionID"].ToString() == OptionsID)
                {
                    dr["Selected"] = 0;
                    note += dr["OptionID"].ToString() + dr["Selected"].ToString(); ;
                    break;
                }
            }
            Session["tia"] = tia;
            if (note != "")
            {
                return note;
            }
            else
            {
                foreach (DataRow dr in tia.dt.Rows)
                {
                    note += dr["OptionID"].ToString();
                }
                return note;
            }
        }
        //[AjaxPro.AjaxMethod]
        public string ResetQuizTable()
        {
            TIA tia = (TIA)Session["tia"];
           // Session.Timeout += 10;
            string optionIDs = "";
            foreach (DataRow dr in tia.dt.Rows)
            {
                if (dr["Selected"].ToString() == "1")
                {
                    optionIDs += dr["OptionID"].ToString() + "#";
                }
            }
            return optionIDs;
        }
        //[AjaxPro.AjaxMethod]
        public int ReadyUpLoad( string TestRelationship)
        {
            TIA tai = (TIA)Session["tia"];
            bool complete = true;
            for (int i = 0; i < tai.indexList.Rows.Count - 1; i++)
            {
                int start = Convert.ToInt32(tai.indexList.Rows[i][0]);
                int end = Convert.ToInt32(tai.indexList.Rows[i + 1][0]);
                bool Done = false;
                for (int j = start; j < end; j++)
                {
                    if (tai.dt.Rows[j]["Selected"].ToString() == "1")
                    {
                        Done = true;
                        break;
                    }
                }
                if (!Done)
                {
                    complete = false;
                }
            }
            if (complete)
            {
                Session["UploadTable"] = (DataTable)Session["UploadDataTable"];
                Session["TestRelationshipID"] = TestRelationship;
                //Session["LandInfo"] = Session["LandInfo"].ToString();
                Session["LandInfo"] = "15050003";
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //[AjaxPro.AjaxMethod]
        public string CheckCallBack()
        {
            if (Session["CallBack"] != null)
            {
                bool sec = (bool)Session["CallBack"];
                if (sec)
                {
                    return "Done";
                }
                else
                {
                    return "fail";
                }
            }
            else
            {
                return null;
            }
        }
        //[AjaxPro.AjaxMethod]
        public string GetDateTime_Days(int AddDays)
        {
            string dateTime="";
            dateTime = DateTime.Now.AddDays(AddDays).ToString("yyyy-MM-dd");
            return dateTime;
        }
        //[AjaxPro.AjaxMethod]
        public string GetDateTime_Month(int Month)
        {
            string _dateTime;
            _dateTime = DateTime.Now.AddMonths(Month).ToString("yyyy-MM-dd");
            return _dateTime;
        }
        ////////////////////////////////////////////////////////
        //[AjaxPro.AjaxMethod]
        public int GetMyHistoryPageCount()
        {
            return Session["HistoryCount_DataSource"] == null ? 0 : ((DataSet)Session["HistoryCount_DataSource"]).Tables.Count;
        }

        //[AjaxPro.AjaxMethod]
        public string MyHistoryBind(int index,string startTime,string endTime)
        {
            //ClearViewSate();
            //this.HistoryTest.BackColor = System.Drawing.Color.FromName("#1855c2");
            //this.MyTest.BackColor = System.Drawing.Color.Blue;
            //hidealluntile();
            //string startTime = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            //string endTime = System.DateTime.Now.ToString("yyyy-MM-dd");
            //this.TestStartTimeTextFront.Value = startTime;
            // this.TestStartTimeTextRoot.Value = endTime;
            DataTable KnowledgePoints = new DataTable();
            DataTable Knowledgelest = new DataTable();
            Knowledgelest.Columns.Add("KonwledgePointID");
            Knowledgelest.Columns.Add("Count");
            Knowledgelest.Columns.Add("Rights");
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select TKRelationship.KnowledgePointID from TSRelationship inner join TTRelationship on TTRelationship.TestID=TSRelationship.TestID inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join TestInfo on TSRelationship.TestID=TestInfo.TestID where TestInfo.TestStartTime Between '" + startTime + "' and '" + endTime + "' and TSRelationship.Contactid=" + Session["LandInfo"].ToString()+ " order by TKRelationship.KnowledgePointID ", Sc);
                da.Fill(KnowledgePoints);
            }
            int Knowledgecount = 0;
            if (KnowledgePoints.Rows.Count != 0)
            {
                string KnowledgeIDFlage = KnowledgePoints.Rows[0][0].ToString();

                for (int i = 0; i < KnowledgePoints.Rows.Count; i++)
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
                    using (MySqlDataReader


 read = new Diya().RowReader("Select Count(*) as a from TSRelationship inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TestInfo.TestStartTime between '" + startTime + "' and '" + endTime + "' and TKRelationship.KnowledgePointID=" + Dr["KonwledgePointID"] + " and TSRelationship.Contactid=" + Session["LandInfo"].ToString() + " and Options.IsTrue=1"))
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
                            using (MySqlDataReader


 read = new Diya().RowReader("Select KnowledgePointName from KnowledgePoint where KnowledgePointID=" + Knowledgelest.Rows[j]["KonwledgePointID"]))
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
                //ViewState["GvIndex"] = 0;
                //ViewState["CountData"] = Datasource;
                MyTheme.GridView.GvStyle1 gv1 = new MyTheme.GridView.GvStyle1();
                gv1.Datasocure = Datasource.Tables[0];
                Session["HistoryCount_DataSource"] = Datasource;
                gv1.Pageindex = index;
                string html = gv1.CreateGridView();
                Session["HistroyCount"] = gv1;
                return html;
               // this.Count.Columns.Clear();
               // this.Count.DataSource = Datasource.Tables[0];
               // this.Count.DataBind();
                //HistoryBound();
                //FinshProgressBar();
            }
            else
            {
                return null;
            }

            //this.MyHistory_Div.Visible = true;
        }

        //[AjaxPro.AjaxMethod]
        public int ClearMyHistoryTestCount()
        {
            Session["HistroyCount"] = null;
            Session["HistoryCount_DataSource"] = null;
            return 0;
        }
        //[AjaxPro.AjaxMethod]
        public string MyHistoryTestPageControl(int Pageindex)
        {
            MyTheme.GridView.GvStyle1 Gv1 = (MyTheme.GridView.GvStyle1)Session["HistroyCount"];
            DataSet ds = (DataSet)Session["HistoryCount_DataSource"];
            Gv1.Datasocure = ds.Tables[Pageindex];
            return Gv1.CreateGridView();
        }
        //[AjaxPro.AjaxMethod]
        public string StartMyHistory()
        {
            return getFile("robotTest/ProgramData/MyHistoryTest.soc");
        }
////////////////////////////////////////////////////////////////
        //[AjaxPro.AjaxMethod]
        public int BindHistoryTestInfo(string MinTime,string MaxTime)
        {
            MyTheme.GridView.GridViewButton Gvbtn = new MyTheme.GridView.GridViewButton();
            Gvbtn.ButtonDataFeld = "RelationshipID";
            Gvbtn.ButtonText = "考题回顾";
            MyTheme.GridView.Gvstyle2 gv2 = new MyTheme.GridView.Gvstyle2();
            gv2.Buttons = new MyTheme.GridView.GridViewButton[] { Gvbtn };
            gv2.Gvname = "MyHistroyTestGridView";
            gv2.OnRowBound = new EventHandler(OnHistoryTestInfoRowBound);
            gv2.ColDataFlied = new string[,] { { "考试名称", "TestName" }, { "正确数", "Score" },{"考试时间","TestStartTime"} };
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
               string Sqlcommand = "Select * From TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.Score is not NULL and TSRelationship.ContactID=" + Session["LandInfo"].ToString() +" and TestInfo.TestStartTime between '"+MinTime+"' and  '"+MaxTime+"'";
                //string Sqlcommand = "Select * From TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.Score is not NULL and TSRelationship.ContactID=" + Session["LandInfo"].ToString() + " and TestInfo.TestStartTime between '2015-06-01' and  '2015-08-26'";
                MySqlDataAdapter da = new MySqlDataAdapter

(Sqlcommand,Sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gv2.Datasocure = dt;
            }
            Session["MyHistoryTestInfo"] = gv2;
            return 0;
        }
        //[AjaxPro.AjaxMethod]
        public int CleanMyHistoryTestInfo()
        {
            Session["MyHistoryTestInfo"] = null;
            return 0;
        }

        //[AjaxPro.AjaxMethod]
        public int GetMyHistoryTestInfoPageCount()
        {
            MyTheme.GridView.Gvstyle2 gv2=(MyTheme.GridView.Gvstyle2)Session["MyHistoryTestInfo"];
            return gv2.PageCount;
        }


        protected void OnHistoryTestInfoRowBound(object sender, EventArgs e)
        {
            MyTheme.GridView.Rowsender _sender = (MyTheme.GridView.Rowsender)sender;
            MyTheme.GridView.Gvstyle2 MainGv =(MyTheme.GridView.Gvstyle2)_sender.sender;
            DataTable Kcount = new DataTable();
            Kcount.Columns.Add("KnowledgePointID");
            DataTable Dtbuf = new DataTable();
            DataTable DtDataSource = new DataTable();
            string RelationshipID = _sender.datarow["RelationshipID"].ToString();
            string TestCount = _sender.datarow["TestCount"].ToString();
            string Testid;
            DataTable Knowids = new DataTable();
            Knowids.Columns.Add("KnowledgePointID");
            using (MySqlDataReader


 read = new Diya().RowReader("Select TestID From TSRelationship where RelationshipID=" + RelationshipID))
            {
                read.Read();
                Testid = read["TestID"].ToString();
            }
            using (MySqlDataReader


 read = new Diya().RowReader("Select TopicID From TTRelationship where TestID=" + Testid))
            {
                Diya diya = new Diya();
                while (read.Read())
                {
                    using (MySqlDataReader


 _read = diya.RowReader("Select KnowledgePointID as a From TKRelationship where TopicID=" + read["TopicID"].ToString()))
                    {
                        while (_read.Read())
                        {
                            Kcount.Rows.Add(Kcount.NewRow());
                            Kcount.Rows[Kcount.Rows.Count - 1][0] = _read["a"];
                        }
                    }
                }
            }
            for (int i = 0; i < Kcount.Rows.Count; i++)
            {
                if (i == 0)
                {
                    Knowids.Rows.Add(Knowids.NewRow());
                    Knowids.Rows[i][0] = Kcount.Rows[i][0].ToString();
                }
                else
                {
                    bool flage = true;
                    for (int j = 0; j < Knowids.Rows.Count; j++)
                    {
                        if (Kcount.Rows[i][0].ToString() == Knowids.Rows[j][0].ToString())
                        {
                            flage = false;
                            break;
                        }
                    }
                    if (flage)
                    {
                        Knowids.Rows.Add(Knowids.NewRow());
                        Knowids.Rows[Knowids.Rows.Count - 1][0] = Kcount.Rows[i][0].ToString();
                    }
                }
            }

            foreach (DataRow dr in Knowids.Rows)
            {
                using (MySqlDataReader


 read = new Diya().RowReader("Select KnowledgePointName From KnowledgePoint Where KnowledgePointID=" + dr[0].ToString()))
                {
                    read.Read();
                    DtDataSource.Columns.Add(read["KnowledgePointName"].ToString());
                }

            }
            DtDataSource.Rows.Add(DtDataSource.NewRow());
            int cindex = 0;
            DataTable TopicIDs = new DataTable();
            DataTable RelTopicIDs = new DataTable();
            RelTopicIDs.Columns.Add("Ids");

            foreach (DataRow dr in Knowids.Rows)
            {
                int TopicsCount = 0;
                int Rtopics = 0;
                using (MySqlDataReader


 read = new Diya().RowReader("select count(*) as a From TTRelationship inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID where TTRelationship.TestID=" + Testid + " and TKRelationship.KnowledgePointID=" + dr[0].ToString()))
                {
                    read.Read();
                    TopicsCount = read.GetInt32(0);
                }
                using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
                {
                    sc.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter

("select  TTRelationship.TopicID From TTRelationship inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join HTRelationship on HTRelationship.TopicID=TTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where TTRelationship.TestID=" + Testid + " and TKRelationship.KnowledgePointID=" + dr[0].ToString() + " and HTRelationship.TSRelationshipID=" + RelationshipID, sc);
                    da.Fill(TopicIDs);
                }
                for (int i = 0; i < TopicIDs.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        RelTopicIDs.Rows.Add(RelTopicIDs.NewRow());
                        RelTopicIDs.Rows[i][0] = TopicIDs.Rows[i][0].ToString();
                    }
                    else
                    {
                        bool flage = true;
                        for (int j = 0; j < RelTopicIDs.Rows.Count; j++)
                        {
                            if (TopicIDs.Rows[i][0].ToString() == RelTopicIDs.Rows[j][0].ToString())
                            {
                                flage = false;
                                break;
                            }
                        }
                        if (flage)
                        {
                            RelTopicIDs.Rows.Add(RelTopicIDs.NewRow());
                            RelTopicIDs.Rows[RelTopicIDs.Rows.Count - 1][0] = TopicIDs.Rows[i][0].ToString();
                        }
                    }
                }

                foreach (DataRow Dr in RelTopicIDs.Rows)
                {
                    Diya diya = new Diya();
                    if (Dr[0].ToString() != "")
                    {
                        using (MySqlDataReader


 read = diya.RowReader("select  * From TTRelationship inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join HTRelationship on HTRelationship.TopicID=TTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where TTRelationship.TestID=" + Testid + " and TKRelationship.KnowledgePointID=" + dr[0].ToString() + " and HTRelationship.TSRelationshipID=" + RelationshipID + " and Options.IsTrue=1 and TTRelationship.TopicID=" + Dr[0]))
                        {
                            if (read.Read())
                                Rtopics++;
                        }
                    }
                }
                double p = Rtopics / (float)TopicsCount;
                DtDataSource.Rows[0][cindex] = p.ToString("P") + "(" + Rtopics + "/" + TopicsCount + ")";
                Rtopics = 0;

                cindex++;
            }
            MyTheme.GridView.GvStyle1 gv2 = new MyTheme.GridView.GvStyle1();
            gv2.Datasocure = DtDataSource;
            gv2.Gvname = _sender.datarow["RelationshipID"].ToString()+"GvItem";
            gv2.AutoWidth = true;
            //gv2.display = false;
            MainGv.RowGridItems = gv2;
            //MainGv.RowGridItems item=new MyTheme.GridView.Gvstyle2[MainGv.Datasocure.Rows.Count];

        }

        //[AjaxPro.AjaxMethod]
        public string HistoryTestInfoPageControler(int pageindex)
        {
            string html = "";
            MyTheme.GridView.Gvstyle2 gv2;
            if (Session["MyHistoryTestInfo"] != null)
            {
                gv2 = (MyTheme.GridView.Gvstyle2)Session["MyHistoryTestInfo"];
            }
            else
            {
                return "NULL";
            }
            gv2.Pageindex = pageindex;
            html = gv2.CreateGridView();
            Session["MyHistoryTestInfo"] = gv2;
            return html;
        }



        //protected void Myhistory_Gw_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //        //int RowIndex = e.Row.RowIndex;
        //       // int RowCount = ((DataTable)Myhistory_Gw.DataSource).Rows.Count;
        //        //int Precent = (RowIndex / RowCount) * 100;
        //        //ShowProgressBar(Precent);
        //        DataTable Kcount = new DataTable();
        //        Kcount.Columns.Add("KnowledgePointID");
        //        DataTable Dtbuf = new DataTable();
        //        DataTable DtDataSource = new DataTable();
        //        Label RelationshipID = e.Row.FindControl("IDBound") as Label;
        //        Label TestCount = e.Row.FindControl("TestCount") as Label;
        //        GridView gwitem = e.Row.FindControl("Gvitem") as GridView;
        //        string Testid;
        //        DataTable Knowids = new DataTable();
        //        Knowids.Columns.Add("KnowledgePointID");
        //        using (MyMyMySqlDataReader read = new Diya().RowReader("Select TestID From TSRelationship where RelationshipID=" + RelationshipID.Text))
        //        {
        //            read.Read();
        //            Testid = read["TestID"].ToString();
        //        }
        //        using (MyMyMySqlDataReaderread = new Diya().RowReader("Select TopicID From TTRelationship where TestID=" + Testid))
        //        {
        //            Diya diya = new Diya();
        //            while (read.Read())
        //            {
        //                using (MyMyMySqlDataReader_read = diya.RowReader("Select KnowledgePointID as a From TKRelationship where TopicID=" + read["TopicID"].ToString()))
        //                {
        //                    while (_read.Read())
        //                    {
        //                        Kcount.Rows.Add(Kcount.NewRow());
        //                        Kcount.Rows[Kcount.Rows.Count - 1][0] = _read["a"];
        //                    }
        //                }
        //            }
        //        }
        //        for (int i = 0; i < Kcount.Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                Knowids.Rows.Add(Knowids.NewRow());
        //                Knowids.Rows[i][0] = Kcount.Rows[i][0].ToString();
        //            }
        //            else
        //            {
        //                bool flage = true;
        //                for (int j = 0; j < Knowids.Rows.Count; j++)
        //                {
        //                    if (Kcount.Rows[i][0].ToString() == Knowids.Rows[j][0].ToString())
        //                    {
        //                        flage = false;
        //                        break;
        //                    }
        //                }
        //                if (flage)
        //                {
        //                    Knowids.Rows.Add(Knowids.NewRow());
        //                    Knowids.Rows[Knowids.Rows.Count - 1][0] = Kcount.Rows[i][0].ToString();
        //                }
        //            }
        //        }

        //        foreach (DataRow dr in Knowids.Rows)
        //        {
        //            using (MyMyMySqlDataReaderread = new Diya().RowReader("Select KnowledgePointName From KnowledgePoint Where KnowledgePointID=" + dr[0].ToString()))
        //            {
        //                read.Read();
        //                DtDataSource.Columns.Add(read["KnowledgePointName"].ToString());
        //            }

        //        }
        //        DtDataSource.Rows.Add(DtDataSource.NewRow());
        //        int cindex = 0;
        //        DataTable TopicIDs = new DataTable();
        //        DataTable RelTopicIDs = new DataTable();
        //        RelTopicIDs.Columns.Add("Ids");

        //        foreach (DataRow dr in Knowids.Rows)
        //        {
        //            int TopicsCount = 0;
        //            int Rtopics = 0;
        //            using (MyMyMySqlDataReader read = new Diya().RowReader("select count(*) as a From TTRelationship inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID where TTRelationship.TestID=" + Testid + " and TKRelationship.KnowledgePointID=" + dr[0].ToString()))
        //            {
        //                read.Read();
        //                TopicsCount = read.GetInt32(0);
        //            }
        //            using (MyMySqlConnection sc = new MyMySqlConnection(Diya.ConectionString))
        //            {
        //                sc.Open();
        //                MyMyMySqlDataAdapterda = new MyMyMySqlDataAdapter("select  TTRelationship.TopicID From TTRelationship inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join HTRelationship on HTRelationship.TopicID=TTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where TTRelationship.TestID=" + Testid + " and TKRelationship.KnowledgePointID=" + dr[0].ToString() + " and HTRelationship.TSRelationshipID=" + RelationshipID.Text, sc);
        //                da.Fill(TopicIDs);
        //            }
        //            for (int i = 0; i < TopicIDs.Rows.Count; i++)
        //            {
        //                if (i == 0)
        //                {
        //                    RelTopicIDs.Rows.Add(RelTopicIDs.NewRow());
        //                    RelTopicIDs.Rows[i][0] = TopicIDs.Rows[i][0].ToString();
        //                }
        //                else
        //                {
        //                    bool flage = true;
        //                    for (int j = 0; j < RelTopicIDs.Rows.Count; j++)
        //                    {
        //                        if (TopicIDs.Rows[i][0].ToString() == RelTopicIDs.Rows[j][0].ToString())
        //                        {
        //                            flage = false;
        //                            break;
        //                        }
        //                    }
        //                    if (flage)
        //                    {
        //                        RelTopicIDs.Rows.Add(RelTopicIDs.NewRow());
        //                        RelTopicIDs.Rows[RelTopicIDs.Rows.Count - 1][0] = TopicIDs.Rows[i][0].ToString();
        //                    }
        //                }
        //            }

        //            foreach (DataRow Dr in RelTopicIDs.Rows)
        //            {
        //                Diya diya = new Diya();
        //                if (Dr[0].ToString() != "")
        //                {
        //                    using (MyMyMySqlDataReader read = diya.RowReader("select  * From TTRelationship inner join TKRelationship on TKRelationship.TopicID=TTRelationship.TopicID inner join HTRelationship on HTRelationship.TopicID=TTRelationship.TopicID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID where TTRelationship.TestID=" + Testid + " and TKRelationship.KnowledgePointID=" + dr[0].ToString() + " and HTRelationship.TSRelationshipID=" + RelationshipID.Text + " and Options.IsTrue=1 and TTRelationship.TopicID=" + Dr[0]))
        //                    {
        //                        if (read.Read())
        //                            Rtopics++;
        //                    }
        //                }
        //            }
        //            double p = Rtopics / (float)TopicsCount;
        //            DtDataSource.Rows[0][cindex] = p.ToString("P") + "(" + Rtopics + "/" + TopicsCount + ")";
        //            Rtopics = 0;

        //            cindex++;
        //        }
        //        gwitem.DataSource = DtDataSource;
        //        gwitem.DataBind();
        //}











///////////////////////////////////////////////////////////////
        //[AjaxPro.AjaxMethod]
        public string startTita()
        {
            return getFile("robotTest/ProgramData/Tiat.soc");
        }

        //[AjaxPro.AjaxMethod]
        public string GetTiatName(string TSRelationshipid)
        {
            Diya diya = new Diya();
            string name = "";
            using (MySqlDataReader read = diya.RowReader("select * from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.RelationshipID= "+TSRelationshipid))
            {
                read.Read();
                name = read["TestName"].ToString();
            }
            return name;
        }

        //[AjaxPro.AjaxMethod]
        public string startTiatDesk(string TSRelationshipID)
        {
            TIAT tiat = new TIAT();
            tiat.Dst.Clear();
            string TestID;
            using (MySqlDataReader read=new Diya().RowReader("select * from TSRelationship where RelationshipID="+TSRelationshipID))
            {
                read.Read();
                TestID = read["TestID"].ToString();
            }
            string buf = tiat.Quizeloader(TestID, 2, 1, TSRelationshipID);
            Session["Tiat"] = tiat;
            return buf;
        }

        //[AjaxPro.AjaxMethod]
        public string TiatPageControl(int pageindex)
       {
            if(Session["Tiat"]==null)
            {
                return "NULL";
            }
           TIAT tiat=(TIAT)Session["Tiat"];
           return tiat.Quizeloader("0", 2, pageindex);
       }
       
        //[AjaxPro.AjaxMethod]
        public int GetTiatCount()
        {
            TIAT tiat = (TIAT)Session["Tiat"];
            return tiat.QuizPagerCount;
        }
///////////////////////////////////////////////////////////////////////////////////////////
        //[AjaxPro.AjaxMethod]
        public string Worng_Q_TBind(string MinTime,string MaxTime)
        {
            //hidealluntile();
            //this.WormgTopicCount.Visible = true;
            DataTable DataBase = new DataTable();
            DataBase.Columns.Add("KnowledgePointName");
            DataBase.Columns.Add("WorngCount");
            DataBase.Columns.Add("KnowledgePointID");
            string SelectCmd = "Select  KnowledgePoint.KnowledgePointID,KnowledgePoint.KnowledgePointName from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID inner join KnowledgePoint on KnowledgePoint.KnowledgePointID=TKRelationship.KnowledgePointID where TSRelationship.Contactid=" + Session["LandInfo"].ToString() + " and Options.IsTrue=0 and TestInfo.TestStartTime between '" + MinTime + "' and '" + MaxTime + "' order by KnowledgePoint.KnowledgePointID";
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlCommand Scmd = new MySqlCommand(SelectCmd, Sc);
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
                    else if (i + 1 == Dbuf.Rows.Count - 1)
                    {
                        if (Dbuf.Rows[i + 1]["KnowledgePointID"].ToString() != DataBase.Rows[DataBase.Rows.Count - 1]["KnowledgePointID"].ToString())
                        {
                            DataRow dr = DataBase.NewRow();
                            dr["KnowledgePointName"] = Dbuf.Rows[i + 1]["KnowledgePointName"].ToString();
                            dr["KnowledgePointID"] = Dbuf.Rows[i + 1]["KnowledgePointID"].ToString();
                            DataBase.Rows.Add(dr);
                        }
                    }
                }
                foreach (DataRow Dr in DataBase.Rows)
                {
                    SelectCmd = "Select Count(*) as a from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID where TKRelationship.KnowledgePointID=" + Dr["KnowledgePointID"] + " and Options.IsTrue=0 and TestInfo.TestStartTime between '" + MinTime + "' and '" + MaxTime + "' and TSRelationship.Contactid=" + Session["LandInfo"].ToString();
                    Diya diya = new Diya();
                    using (MySqlDataReader read = diya.RowReader(SelectCmd))
                    {
                        read.Read();
                        Dr["WorngCount"] = read["a"].ToString();
                    }

                }
                MyTheme.GridView.GvStyle1 Gv1 = new MyTheme.GridView.GvStyle1();
                Gv1.AutoWidth = false;
                Gv1.ColDataFlied = new string[,] { { "知识点名称", "KnowledgePointName" }, { "错题数", "WorngCount" } };
                MyTheme.GridView.GridViewButton btn = new MyTheme.GridView.GridViewButton();
                btn.ButtonDataFeld = "KnowledgePointID";
                btn.ButtonText = "查看";
                Gv1.Buttons = new MyTheme.GridView.GridViewButton[] { btn };
                Gv1.PageSize = 5;
                Gv1.Datasocure = DataBase;
                Gv1.Gvname = "Worng_Q_T";
                string html = Gv1.CreateGridView();
                Session["Worng_Q_T"] = Gv1;
                return html;
                //this.Worng_Q_T.DataSource = DataBase;
               // ViewState["WrongKnowLedgeData"] = DataBase;
                //this.Worng_Q_T.DataBind();
            }
        }
        //[AjaxPro.AjaxMethod]
        public string Wrong_Q_TPageControl(int index)
        {
            if(Session["Worng_Q_T"]!=null)
            {
                MyTheme.GridView.GvStyle1 Gv1 = (MyTheme.GridView.GvStyle1)Session["Worng_Q_T"];
                Gv1.Pageindex = index;
                string html = Gv1.CreateGridView();
                Session["Worng_Q_T"] = Gv1;
                return html;
            }
            else
            {
                return "NULL";
            }
        }
        //[AjaxPro.AjaxMethod]
        public int GetQuizPageCountCount()
        {
            MyTheme.GridView.GvStyle1 gv1=(MyTheme.GridView.GvStyle1)Session["Worng_Q_T"];
            return gv1.PageCount;
        }
        //[AjaxPro.AjaxMethod]
        public string startWTiat()
        {
            return getFile("robotTest/ProgramData/Wtiat.soc");
        }
        //[AjaxPro.AjaxMethod]
        public string GetKonowledgeName(string id)
        {

            using (MySqlDataReader read = new Diya().RowReader("Select KnowledgePointName From KnowledgePoint where KnowledgePointID=" + id))
            {
                read.Read();
                return read["KnowledgePointName"].ToString();
            }
        }

        //[AjaxPro.AjaxMethod]
        public string WTiatPageControlBlind(string KnowledgePointID, string MinTime, string MaxTime)
        {
            string SelectCommand = "select Topic.TopicID,Topic.TopicContent,Topic.HaveContent,Topic.MoreContent,HTRelationship.SelectedOptionID from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on Options.OptionID=HTRelationship.SelectedOptionID inner join Topic on Topic.TopicID=HTRelationship.TopicID inner join TKRelationship on TKRelationship.TopicID=HTRelationship.TopicID where Options.IsTrue=0 and TestInfo.TestStartTime between '" + MinTime + "' and '" + MaxTime + "' and TSRelationship.Contactid=" + Session["LandInfo"].ToString() +" and TKRelationship.KnowledgePointID=" + KnowledgePointID + " order by Topic.TopicID DESC";
            TIAT tiat = new TIAT();
            tiat.Dst.Clear();
            tiat.PageItems = 10;
            string html=  tiat.Quizeloader(10,1, SelectCommand);
            Session["Wtiat"] = tiat;
            Session["WtiatDataCommand"] = SelectCommand;
            return html;
            
        }
        //[AjaxPro.AjaxMethod]
        public int GetWtiatPagecount()
        {
            TIAT tiat=(TIAT)Session["Wtiat"];
            return tiat.QuizPagerCount;
        }

        //[AjaxPro.AjaxMethod]
        public string WtiatPagerControl(int index)
        {
            if(Session["Wtiat"]!=null)
            {
                TIAT tiat = (TIAT)Session["Wtiat"];
                return tiat.Quizeloader(10, index, Session["WtiatDataCommand"].ToString());
            }
            else
            {
                return "NULL";
            }
        }

        //[AjaxPro.AjaxMethod]
        public string startWront_Q_T()
        {
            return getFile("robotTest/ProgramData/Wron_Q_T.soc");
        }

        ///////////////////////////////////////////////////////
       // [AjaxPro.AjaxMethod]
        public string Week_Click()
        {
            string Data = "";
            //ResetAllDateButton();
            //this.KnowledgeButtons.Controls.Clear();
            //btn.BorderColor = System.Drawing.Color.FromName("#95f6f3");
            //btn.CssClass = "ButtomForTable";
            //this.Week.BorderColor = System.Drawing.Color.FromName("#95f6f3");
            //this.Week.CommandArgument = "1";
            //float[,] data = new float[1, 7];
            //float dataMax = 100;
            //float[] x = new float[7];
            //int j = 0;
            Diya diya = new Diya();
            for (int i = 7; i >= 1; i--)
            {
                string Date = System.DateTime.Now.AddDays(i * -1).ToString("yyyy-MM-dd");
                string Start = Date + " 00:00:00";
                string End = Date + " 23:59:59";
                string SqlSelectCmdTotle = "Select Count(*) as a from TSRelationship inner join TTRelationship on TTRelationship.TestID=TSRelationship.TestID inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.Contactid=" + Session["LandInfo"] + " and TestInfo.TestStartTime between '" + Start + "' and '" + End + "'";
                string SqlSelectCmdCount = "select count (*) as a from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on HTRelationship.SelectedOptionID=Options.OptionID where TestInfo.TestStartTime between '" + Start + "' and '" + End + "' and TSRelationship.Contactid=" + Session["LandInfo"] + " and Options.IsTrue=1";
                float Totle = 0;
                float Count = 0;
                using (MySqlDataReader read = diya.RowReader(SqlSelectCmdTotle))
                {
                    read.Read();
                    Totle = Convert.ToInt32(read["a"]);
                }
                using (MySqlDataReader read = diya.RowReader(SqlSelectCmdCount))
                {
                    read.Read();
                    Count = Convert.ToInt32(read["a"]);
                }
                float precent = (Count / Totle) * 100;
                if (float.IsNaN(precent))
                {
                    precent = 0;
                }
                //data[0, j] = precent;
                Data += precent + "d";
                //x[j] = j + 1;
                //j++;
            }
            Data += "#";
            return Data;
            // this.KnowledgeButtons.Controls.Add(btn);
            //hidealluntile();
            //this.MyhistortCount.Visible = true;
            //TabelCommand = new TIAT().CreateTable(data, dataMax, new string[] { "综合" }, "天", "准确率(%)", x, "综合趋势分析图", "dataTable");
            //this.KnowledgeButtons.Controls.Add(new Button());
        }
       // [AjaxPro.AjaxMethod]
        public int GetMonth()
        {
            return DateTime.Now.Month;
        }

        //[AjaxPro.AjaxMethod]
        public string Month_Click()
        {
            string Data = "";
           // ResetAllDateButton();
            //this.KnowledgeButtons.Controls.Clear();
            //this.Month.BorderColor = System.Drawing.Color.FromName("#95f6f3");
            //float[,] data = new float[1, DateTime.Now.Month];
            //float dataMax = 100;
            //float[] x = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            Diya diya = new Diya();
            for (int i = 1; i <= 12; i++)
            {
                if (i > DateTime.Now.Month)
                {
                    break;
                }
                string Date = DateTime.Now.ToString("yyyy") + "-" + i + "-01";
                string Start = Date + " 00:00:00";
                int DaysinMonth = System.DateTime.DaysInMonth(DateTime.Now.Year, i);
                string End = DateTime.Now.Year + "-" + i + "-" + DaysinMonth.ToString() + " 23:59:59";
                string SqlSelectCmdTotle = "Select Count(*) as a from TSRelationship inner join TTRelationship on TTRelationship.TestID=TSRelationship.TestID inner join TestInfo on TestInfo.TestID=TSRelationship.TestID where TSRelationship.Contactid=" + Session["LandInfo"] + " and TestInfo.TestStartTime between '" + Start + "' and '" + End + "'";
                string SqlSelectCmdCount = "select count (*) as a from TSRelationship inner join TestInfo on TestInfo.TestID=TSRelationship.TestID inner join HTRelationship on HTRelationship.TSRelationshipID=TSRelationship.RelationshipID inner join Options on HTRelationship.SelectedOptionID=Options.OptionID where TestInfo.TestStartTime between '" + Start + "' and '" + End + "' and TSRelationship.Contactid=" + Session["LandInfo"] + " and Options.IsTrue=1";
                float Totle = 0;
                float Count = 0;
                using (MySqlDataReader read = diya.RowReader(SqlSelectCmdTotle))
                {
                    read.Read();
                    Totle = Convert.ToInt32(read["a"]);
                }
                using (MySqlDataReader read = diya.RowReader(SqlSelectCmdCount))
                {
                    read.Read();
                    Count = Convert.ToInt32(read["a"]);
                }

                float precent = (Count / Totle) * 100;
                if (float.IsNaN(precent))
                {
                    precent = 0;
                }
                Data += (precent + "d");
                //data[0, i - 1] = precent;
                //x[i-1] = i;
                //j++;
            }
            Data += "#";
            return Data;
           // hidealluntile();
           // this.MyhistortCount.Visible = true;
           // TabelCommand = new TIAT().CreateTable(data, dataMax, new string[] { "综合" }, "月", "准确率(%)", x, "综合趋势分析图", "dataTable");

        }
        //[AjaxPro.AjaxMethod]
        public string StartHistoryDataTable()
        {
            return getFile("robotTest/ProgramData/HistoryDataTable.soc");
        }




   }
}