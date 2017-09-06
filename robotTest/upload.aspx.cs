using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;
public partial class robotTest_upload : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string userID = Request["UID"];
        string TSRelationsipID = Request["TSID"];
        string data = Context.Request["selection"];
        System.Threading.Thread.Sleep(1000);
        int i = 0;
        while(Upload(userID,TSRelationsipID,data)&&i<3)
        {
            i++;
        }
        if (i == 3)
        {
            Response.Write("<Status>err</Status> <div style=\"text-align:center\"><img src=\"Desk/Error.PNG\" /></div>");
        }
        else
        {
            Response.Write("<Status>sec</Status>");
        }
    }
    const int OpMaxLength = 16;
    protected bool Upload(string uid,string tsid,string data)
    {
        bool sec = true;
        string[] Topics = data.Split(new char[] { '#' });
        string[,] selections = new string[Topics.Length-1,OpMaxLength];
        Array.Clear(selections, 0, selections.Length);
        for (int i=0;i<Topics.Length-1;i++)
        {
            string[] options = Topics[i].Split(new char[] { '$' });
            selections[i, 0] =options[0];
            for(int j=1;j<options.Length-1&&j<OpMaxLength;j++)
            {
                selections[i, j] = options[j];
            }
        }
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlTransaction sqlt = Sc.BeginTransaction();
            MySqlCommand Scmd = new MySqlCommand();
            Scmd.Connection = Sc;
            Scmd.Transaction = sqlt;
            try
            { 
                int rights = 0;
                for (int i = 0; i < Topics.Length-1; i++) //insert History Test Info
                {
                    bool flage = true;
                    int j = 1;
                    for (; j < OpMaxLength && selections[i, j] != null; j++)
                    {
                        Scmd.CommandText = "insert into HTRelationship(TSRelationshipID,TopicID,SelectedOptionID) values(" + tsid + "," + selections[i, 0]+","+selections[i,j]+")";
                        Scmd.ExecuteNonQuery(); 
                        Scmd.CommandText = "Select IsTrue from Options where OptionID="+selections[i,j];
                        MySqlDataReader read = Scmd.ExecuteReader();
                        read.Read();
                        if (Convert.ToInt32(read["IsTrue"].ToString()) != 1)
                        {
                            flage = false;
                            read.Close();
                            break;
                        }
                        read.Close();
                    }
                    if (flage&&j!=1)
                    {
                        rights++;
                    }
                }          
                Scmd.CommandText = "Update TSRelationship set Score="+rights+" where RelationshipID="+tsid;
                Scmd.ExecuteNonQuery();
                sqlt.Commit();

            }
            catch (Exception)
            {
                sqlt.Rollback();
                sec = false;
            }

        }

        return sec;
    }


}