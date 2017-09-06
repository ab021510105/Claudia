using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class robotTest_temp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       using(MySqlConnection sc=new MySqlConnection(Diya.ConectionString))
       {
           sc.Open();
           string password = new Diya().GetMD5Text("tadeasdze");
           MySqlCommand Scmd = new MySqlCommand("update ConsultingInfo set Password = '"+password+ "'    where contactid = 14050002", sc);
           Scmd.ExecuteNonQuery();
       }
    }
}