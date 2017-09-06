using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;

public partial class robotTest_Busy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LandInfo"] == null&&Session["UploadTable"]==null)
        {
            Response.Redirect("Login.aspx");
        }
        if(Session["UploadTable"]!=null)
        {
            BeginProgressBar();
            bool sec = Upload();
            int time = 0;
            int Sleep = 0;
            while(!sec&&time<4)
            {
                Sleep += 1000;
                System.Threading.Thread.Sleep(Sleep);
                sec = Upload();
                time++;
            }
                Session["UploadTable"] = null;
                Session["TestRelationshipID"] = null;
            
            Session["CallBack"]=sec;
            //Response.Redirect("ObjectTest.aspx");
            Response.Write("<script>Dialog('ÕýÔÚÌø×ª...')</script>"); 
            Response.Flush();
            Literal jump = new Literal();
            jump.Text = "<script>window.location.href='ObjectTest.aspx';</script>";
            this.Page.Controls.Add(jump);
        }
     
        //ShowProgressBar(40);
        //System.Threading.Thread.Sleep(3000);
        //ShowProgressBar(100);
       
    }
    protected bool Upload()
    {
        DataTable dt = (DataTable)Session["UploadTable"];
        string TestRelationship = Session["TestRelationshipID"].ToString();
        ShowProgressBar(20);
       // System.Threading.Thread.Sleep(1000);
        bool sec = true;
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {

            Sc.Open();
            MySqlTransaction myTrans = Sc.BeginTransaction();
            MySqlCommand Scmd = new MySqlCommand();
            Scmd.Connection = Sc;
            Scmd.Transaction = myTrans;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Selected"].ToString() == "1")
                    {


                        Scmd.CommandText = "insert into HTRelationship(TSRelationshipID,TopicID,SelectedOptionID) values(" + TestRelationship + "," + dr["TopicID"] + "," + dr["OptionID"] + ")";
                        Scmd.ExecuteNonQuery();
                    }

                }
                ShowProgressBar(40);
               // System.Threading.Thread.Sleep(1000);
                int Rights = 0;
                //int rid = Convert.ToInt32(Session["TestRelationshipID"].ToString());
                int rid = Convert.ToInt32(TestRelationship);
                MySqlDataReader read;
                //Scmd.CommandText = 
                DataSet Anwers = new DataSet();
                Scmd.CommandText = "Select TopicID from HTRelationship where TSRelationshipID=" + rid;
                read = Scmd.ExecuteReader();
                DataTable TidTemp = new DataTable();
                TidTemp.Columns.Add("TopicID");
                while (read.Read())
                {
                    TidTemp.Rows.Add(TidTemp.NewRow());
                    TidTemp.Rows[TidTemp.Rows.Count - 1][0] = read.GetInt32(0);
                }
                read.Close();
                ShowProgressBar(50);
               // System.Threading.Thread.Sleep(1000);
                foreach (DataRow dr in TidTemp.Rows)
                {
                    // int topid = read.GetInt32(0);

                    DataTable Options = new DataTable();
                    Options.Columns.Add("SelectedOptionID");
                    Scmd.CommandText = "Select SelectedOptionID from HTRelationship where TopicID=" + dr[0] + " and TSRelationshipID=" + rid;
                    read = Scmd.ExecuteReader();
                    while (read.Read())
                    {
                        Options.Rows.Add(Options.NewRow());
                        Options.Rows[Options.Rows.Count - 1][0] = read["SelectedOptionID"];
                    }
                    //da.Fill(Options);
                    read.Close();
                    Anwers.Tables.Add(Options);
                    Anwers.Tables[Anwers.Tables.Count - 1].TableName = dr[0] + "";

                }
                ShowProgressBar(60);
               // System.Threading.Thread.Sleep(1000);
                foreach (DataTable Adr in Anwers.Tables)
                {
                    bool worng = true;
                    foreach (DataRow Odr in Adr.Rows)
                    {
                        Scmd.CommandText = "Select * From Options where IsTrue=0 and OptionID=" + Odr[0].ToString();
                        read = Scmd.ExecuteReader();
                        if (read.Read())
                        {
                            worng = false;
                        }
                        read.Close();
                    }

                    if (worng)
                    {
                        Rights++;
                    }
                }
                //Righs = read.GetInt32(0);
                ShowProgressBar(80);
               // System.Threading.Thread.Sleep(1000);
                Scmd.CommandText = "update TSRelationship set Score=" + Rights + " where RelationshipID=" + rid;
                Scmd.ExecuteNonQuery();
                myTrans.Commit();
                ShowProgressBar(100);
                //System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                myTrans.Rollback();
                //return false;
                sec = false;
            }
        }
        return sec;
    }




    protected int P = 0;
   
    protected void ShowProgressBar(int Precent)
    {
        if (P >= 100)
        {
            return;
        }
       
        if (P == 0)
        {
            
            for (int i = 0; i <= Precent; i++)
            {
                SetProgressBar(i);
                System.Threading.Thread.Sleep(i / 5 + 10);
            }
            if (Precent < 100)
            {
                P = Precent;
            }
            
        }
        else
        {
            
            int start = P;
            for (int i = start + 1; i <= Precent; i++)
            {
                SetProgressBar(i);
                System.Threading.Thread.Sleep(i / 5 + 10);
            }
            P = Precent;
        }
        
    }

    protected void SetProgressBar(int Precent)
    {

        Response.Write("<script>Precedes(" + Precent + ")</script>");
        Response.Flush();
    }

    protected void BeginProgressBar()
    {
        string templateFileName = Path.Combine(Server.MapPath("."), "TIA/UI/Progressbar.html");
        StreamReader reader = new StreamReader(@templateFileName, System.Text.Encoding.GetEncoding("UTF-8"));
        string html = reader.ReadToEnd();
        reader.Close();
        Response.Write(html);
        Response.Flush();
    }
}