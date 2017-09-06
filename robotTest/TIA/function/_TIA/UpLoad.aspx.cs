using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_TIA_function__TIA_UpLoad : System.Web.UI.Page
{
    protected string echo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = Request["uid"];
        string data = Context.Request["selection"];
        string stid = data.Split(new string[] { "tid=" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(new string[] { "&data=" }, StringSplitOptions.RemoveEmptyEntries)[0];
        string selection = data.Split(new string[] { "&data=" }, StringSplitOptions.RemoveEmptyEntries)[1];
        //echo += uid + "s" + selection+"t"+tid;
        JudgeUpLoad(uid, stid, selection);
    }

    protected void JudgeUpLoad(string uid,string stid,string selection)
    {
        using(MySqlConnection sc=new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlTransaction st = sc.BeginTransaction();
            MySqlCommand scmd = new MySqlCommand();
            scmd.Connection = sc;
            scmd.Transaction = st;
            string UpLoadTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            try
            {
                string[] Topics = selection.Split(new string[] { "$" }, StringSplitOptions.RemoveEmptyEntries);
                int getr_count = 0;
                for (int i = 0; i < Topics.Length;i++ )
                {
                    string[] T_ops = Topics[i].Split(new string[]{"#"},StringSplitOptions.RemoveEmptyEntries);
                    string TopicID = T_ops[0];
                    bool flage = true;
                    for(int j=1;j<T_ops.Length;j++)
                    {
                        string optionId = T_ops[j];
                        scmd.CommandText = "insert into HTRelationship(TSRelationshipID,TopicID,SelectedOptionID) values(" + stid + ","+TopicID+","+T_ops[j]+")";
                        scmd.ExecuteNonQuery();
                        scmd.CommandText = "select istrue from Options where OptionID="+T_ops[j];
                        MySqlDataReader read = scmd.ExecuteReader();
                        read.Read();
                        if(read["istrue"].ToString()!="1")
                        {
                            flage = false;
                        }
                        read.Close();
                    }
                    if(flage)
                    {
                        getr_count++;
                    }
                }
                scmd.CommandText = "Update TSRelationship set Score=" + getr_count + ",CompletionTime='"+UpLoadTime+"'  where RelationshipID=" + stid;
                scmd.ExecuteNonQuery();
                st.Commit();

            }
            catch(Exception)
            {
                st.Rollback();
            }
        }
    }

}