using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
//using System.Data.SqlClient;\
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.Net.Mail;

/// <summary>
/// Info 的摘要说�?
/// </summary>
public class Info
{
    public static string SelectedID = null;
    public static string uername=null;
    public static string userid=null;
    public static int usertype=-1;
    public static string remarks=null;
    public static string datasource =@"Data Source=localhost;Initial Catalog=robotedu;user id=root;password=root";
   //public static string datasource = @"Data Source=FREEWING;Initial Catalog=SMDB;Integrated Security=True";
    //public static string datasource = @"Data Source=JOHN-PC;Initial Catalog=SMDB;Integrated Security=True";
    public static string MD5Text(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(text), 0, text.Length);
        char[] temp = new char[res.Length];
        System.Array.Copy(res, temp, res.Length);
        string password = new string(temp);
        return password;
    }
    public static void InsertUpdateUnit(string cmd)
    {

        using (MySqlConnection s = new MySqlConnection(datasource))
        {
            MySqlCommand cmmd = new MySqlCommand(cmd, s);
            s.Open();
            cmmd.ExecuteScalar();
            s.Close();
        }
    }
    public MySqlDataReader SelectCountUnit(string Mode,string table ,string Values ,string condition)
    {
        MySqlConnection s1 = new MySqlConnection(datasource);
        s1.Open();
        MySqlDataReader read = null;
        if (Mode.ToUpper() == "SELECT")
          {
             MySqlCommand cmd = new MySqlCommand(Mode + Values + " From " + table + " Where " + condition, s1);
             read = cmd.ExecuteReader();
          }
        else if (Mode.ToUpper() == "COUNT")
         {
            MySqlCommand cmd = new MySqlCommand(Mode  + Values  + " From " + table + " Where " + condition, s1);
            read = cmd.ExecuteReader();
         }
       return read;
    }
    public static int Getid(MySqlDataReader read)
    {
        int id = 0;
        if (read.Read())
        {
            id = read.GetInt32(0) + 1;
            return id;
        }
        else
        {
            return id;
        }
    }
    public static DataSet Gridviewbind(GridView Gw, string SelectCommand)
    {
        DataSet ds = new DataSet();
        using (MySqlConnection s = new MySqlConnection(datasource))
        {
            MySqlDataAdapter da = new MySqlDataAdapter(SelectCommand, s);
            s.Open();
            da.Fill(ds);
            Gw.DataSource = ds;
            Gw.DataBind();
        }
         return ds;
    }
    public static bool checktext(string Mode, string Text)
    {
        bool flag = true;
        if (Mode.ToUpper() == "PHONENUMBER")
        {
            if ((Text.Length<11&&(Text.Length>9||Text.Length<8))||Text.Length>11)
            {
                flag = false;
            }
            foreach(char c in Text)
            {
                if (Convert.ToInt32(c) > 57 || Convert.ToInt32(c) < 48)
                {
                    flag = false;
                }
            }
        }
        else if (Mode.ToUpper() == "N")
        {
            foreach (char c in Text)
            {
                if (Convert.ToInt32(c) > 57 || Convert.ToInt32(c) < 48)
                {
                    flag = false;
                }
            }
        }
        return flag;
    }
    public MySqlDataReader FindData(string Selectstr)
    {
        MySqlConnection s = new MySqlConnection(datasource);       
          MySqlCommand cmd = new MySqlCommand(Selectstr, s);
          s.Open();
          MySqlDataReader read = cmd.ExecuteReader();
          return read;
     }
    public static bool Sender(string sender_user, string sender_password, string target, string host, string title, string body)
    {
        bool scu = true;
        System.Net.Mail.SmtpClient client = new SmtpClient();
        client.Host = host;
        client.UseDefaultCredentials = false;
        //client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential(sender_user, sender_password);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        try
        {
            MailMessage message = new MailMessage(sender_user, target);
            message.Subject = title;
            message.Body = body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Send(message);
        }
        catch (Exception)
        {
            scu = false;
        }
        return scu;
    }

}