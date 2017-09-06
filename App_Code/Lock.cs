using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.EnterpriseServices;
using System.Data;
using MySql.Data.MySqlClient
;
using System.Reflection;
/// <summary>
/// Lock 的摘要说明
/// 事务中心
/// </summary>
/// 
//[assembly: ApplicationName("keyPairPublic")]
//[assembly: AssemblyKeyFileAttribute("~/keyPairPublic.snk")]
namespace Lock
{
   public class UpdateAnswers
   {
     // DataTable dt=null;
      //string TestRelationship = null;

      public bool InOrder(DataTable dt, string TestRelationship)
      {
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
                      if (dr["Selected"].ToString()=="1")
                      {


                          Scmd.CommandText = "insert into HTRelationship(TSRelationshipID,TopicID,SelectedOptionID) values(" + TestRelationship + "," + dr["TopicID"] + "," + dr["OptionID"] + ")";
                          Scmd.ExecuteNonQuery();
                      }

                  }
                  int Rights = 0;
                  //int rid = Convert.ToInt32(Session["TestRelationshipID"].ToString());
                  int rid = Convert.ToInt32(TestRelationship);
                  MySqlDataReader read;
                  //Scmd.CommandText = 
                  DataSet Anwers = new DataSet();
                  Scmd.CommandText = "Select TopicID from HTRelationship where TSRelationshipID="+rid;
                  read = Scmd.ExecuteReader();
                  DataTable TidTemp = new DataTable();
                  TidTemp.Columns.Add("TopicID");
                    while(read.Read())
                    {
                        TidTemp.Rows.Add(TidTemp.NewRow());
                        TidTemp.Rows[TidTemp.Rows.Count - 1][0] = read.GetInt32(0);
                    }
                    read.Close();
                    foreach(DataRow dr in TidTemp.Rows)
                    {
                       // int topid = read.GetInt32(0);
                      
                             DataTable Options = new DataTable();
                             Options.Columns.Add("SelectedOptionID");
                             Scmd.CommandText="Select SelectedOptionID from HTRelationship where TopicID=" + dr[0] + " and TSRelationshipID=" + rid;
                             read = Scmd.ExecuteReader();
                        while(read.Read())
                        {
                            Options.Rows.Add(Options.NewRow());
                            Options.Rows[Options.Rows.Count - 1][0] = read["SelectedOptionID"];
                        }
                            //da.Fill(Options);
                        read.Close();
                            Anwers.Tables.Add(Options);
                            Anwers.Tables[Anwers.Tables.Count - 1].TableName = dr[0] + "";
                        
                    }
                    foreach(DataTable Adr in Anwers.Tables)
                    {
                        bool worng = true;
                        foreach(DataRow Odr in Adr.Rows)
                        {
                            Scmd.CommandText = "Select * From Options where IsTrue=0 and OptionID="+Odr[0].ToString();
                            read = Scmd.ExecuteReader();
                            if(read.Read())
                            {
                                worng = false;
                            }
                            read.Close();
                        }
                       
                        if(worng)
                        {
                            Rights++;
                        }
                    }
                  //Righs = read.GetInt32(0);
                  
                  Scmd.CommandText = "update TSRelationship set Score=" + Rights + " where RelationshipID=" + rid;
                  Scmd.ExecuteNonQuery();
                  myTrans.Commit();
              }
              catch(Exception)
              {
                  myTrans.Rollback();
                  return false;
              }
          }
          return sec;
      }
   }
}