using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;

/// <summary>
/// TIA 的摘要说明
/// </summary>

    public static class TIA
    {
        public static string ContactInfo = @"Data Source=mssql.sql95.cdncenter.net;Initial Catalog=sq_robotedu ;Persist Security Info=True;User ID=sq_robotedu;Password=robotedu123;";
        public static void BindQuizes(string TestID)
        {
            string SelectCmd = "Select TTRelationship.RelationshipID,Topic.TopicID,Topic.TopicContent,Topic.HaveContent,Topic.MoreContent From TTRelationship inner join Topic on TTRelationship.TopicID=Topic.TopicID where TTRelationship.TestID=" + TestID;
            DataTable TopicesDs = new DataTable();
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlDataAdapter Da = new MySqlDataAdapter(SelectCmd, Sc);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                TopicesDs = Ds.Tables[0];
                QuizCount = TopicesDs.Rows.Count;
                foreach (DataRow Dr in TopicesDs.Rows)
                {

                }
                
            }
        }
        private static int QuizCount = 0;

}