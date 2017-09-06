using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_advanceLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         //using (MySqlDataReader read = Diya.RowReader("Select RelationshipID from TTRelationship where TestID=" + 58))
         //     {
         //               while (read.Read())
         //               {
         //                   using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
         //                   {
         //                       Sc.Open();
         //                       MySqlCommand Scmd = new MySqlCommand("delete From OTRelationship where TTRelationshipID=" + read["RelationshipID"], Sc);
         //                       Scmd.ExecuteNonQuery();
         //                   }
         //               }
         //         }
         //           using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
         //           {
         //               Sc.Open();
         //               MySqlCommand Scmd = new MySqlCommand("delete From TTRelationship where TestID=" + 58, Sc);
         //               Scmd.ExecuteNonQuery();
         //           }

         //           //using (MySqlDataReader read = Diya.RowReader("Select RelationshipID from TSRelationship where TestID="+58))
         //           //{
         //           //    while (read.Read())
         //           //    {
         //           //        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
         //           //        {
         //           //            Sc.Open();
         //           //            MySqlCommand Scmd = new MySqlCommand("delete from HTRelationship where TSRelationshipID="+read.GetInt32(0), Sc);
         //           //            Scmd.ExecuteNonQuery();
         //           //        }
         //           //    }
         //           //}
         //           //using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
         //           //{
         //           //    Sc.Open();
         //           //    MySqlCommand Scmd = new MySqlCommand("delete TSRelationship where TestID=" + 58, Sc);
         //           //    Scmd.ExecuteNonQuery();
         //           //}
         //           using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
         //           {
         //               Sc.Open();
         //               MySqlCommand Scmd = new MySqlCommand("delete from TestInfo where TestID=" + 58, Sc);
         //               Scmd.ExecuteNonQuery();
         //           }
                

    }

    protected void Cnfirm_Click(object sender, EventArgs e)
    {
         using (MySql.Data.MySqlClient.MySqlDataReader read = new Diya().RowReader("select * From ConsultingInfo where Contactid=" +this.UserID.Text))
         {
             if(read.Read())
             {
                 Session["LandInfo"] = this.UserID.Text;
                 Response.Redirect("ObjectTest.aspx");
             }
         }
    }
}