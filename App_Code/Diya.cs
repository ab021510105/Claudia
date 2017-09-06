using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Text;
using Security;
using System.Web.UI.WebControls;
using System.Net.Mail;
/// <summary>
/// Diya 常用的方法
/// </summary>
public class Diya
{
    static LogInfo userInfo = null;
    static public string ServerAdd = "www.onlyrobotedu.com/robotTest";
    //public static string ConectionString = @"Data Source=localhost;Initial Catalog=robotedu;user id=root;password=root";
    public static string ConectionString = @"Data Source=106.14.99.79;Initial Catalog=robotedu;user id=john;password=ab021510105";




    //public static string ConectionString = @"Data Source=mssql.sql95.cdncenter.net;Initial Catalog=sq_robotedu ;Persist Security Info=True;User ID=sq_robotedu;Password=robotedu123";
    // public static string ConectionString = @"Data Source=JOHN-PC;Initial Catalog=sq_robotedu;Persist Security Info=True; Integrated Security=SSPI";

    //public static string ConectionString = @"Data Source=112.124.2.254\SQLEXPRESS;Initial Catalog=sq_robotedu;Persist Security Info=True; User ID=robotedu;Password=robotedu123;";
    public static string[] UserInfo()
    {
        if (userInfo == null)
        {
            return null;
        }
        else
        {
            return userInfo.PopData();
        }
    }

    public static void  GetUserInfo(int Type,string ID,string Name)
    {
        userInfo = new LogInfo();
        userInfo.PushData(Type, ID, Name);
    }
    /// <summary>
    /// 用于MD5加密的函数
    /// </summary>
    /// <param name="text">需要加密的明文</param>
    /// <returns></returns>
    public  string GetMD5Text(string text)
    {
        security secur = new security();
        return secur.MD5Text(text);
    }
    /// <summary>
    /// DES加密函数：64bit
    /// </summary>
    /// <param name="text">需要加密的明文</param>
    /// <returns></returns>
    public  string GetDESEncrypt(string text)
    {
        security secur = new security();
        return secur.DESEncrypt(text);
    }
    /// <summary>
    /// DES的解密函数
    /// </summary>
    /// <param name="text">需要解密的密文</param>
    /// <returns></returns>
    public  string GetDESDecrypt(string text)
    {
        security secur = new security();
        return secur.DESDecrypt(text);
    }
    /// <summary>
    /// AES的加密函数:256bit
    /// </summary>
    /// <param name="text">需要加密的明文</param>
    /// <returns></returns>
    public  string GetAESEncrypt(string text)
    {
        security secur = new security();
        return secur.AESEncrypt(text);
    }
    /// <summary>
    /// AES的解密函数
    /// </summary>
    /// <param name="text">需要解密的密文</param>
    /// <returns></returns>
    public  string GetAESDecrypt(string text)
    {
        security secur = new security();
        return secur.AESDecrypt(text);
    }
    /// <summary>
    /// 用于给GridView绑定数据并且返回数据表单
    /// </summary>
    /// <param name="Gw">需要绑定的GridView</param>
    /// <param name="SelectCommand">Sql的select语句</param>
    /// <returns></returns>
    public  DataTable Gridviewbind(GridView Gw, string SelectCommand)
    {
        
        DataSet ds_m = new DataSet();
        using (MySqlConnection s = new MySqlConnection(ConectionString))
        {
            s.Open();
            MySqlDataAdapter Da = new MySqlDataAdapter(SelectCommand, s);
            Da.Fill(ds_m);
            Gw.DataSource = ds_m.Tables[0];
            Gw.DataBind();
        }
        return ds_m.Tables[0];
    }

    public MySqlDataReader RowReader(string Sql_Comman)
    {
        MySqlDataReader read;
        MySqlConnection Sc = new MySqlConnection(ConectionString);
        Sc.Open();
        MySqlCommand Scmd = new MySqlCommand(Sql_Comman, Sc);
        read = Scmd.ExecuteReader(CommandBehavior.CloseConnection);
        return read;
    }
    /// <summary>
    /// 用于检测文本
    /// </summary>
    /// <param name="Mode">检测模式。N:只检测是否是数字，PHONENUMBER:检测是否满足电话号码的需求</param>
    /// <param name="Text">需要检测的文本</param>
    /// <returns></returns>
    public bool checktext(string Mode, string Text)
    {
        bool flag = true;
        if (Mode.ToUpper() == "PHONENUMBER")
        {
            if ((Text.Length < 11 && (Text.Length > 9 || Text.Length < 8)) || Text.Length > 11)
            {
                flag = false;
            }
            foreach (char c in Text)
            {
                if (c > 57 ||c < 48)
                {
                    flag = false;
                    break;
                }
            }
        }
        else if (Mode.ToUpper() == "N")
        {
            foreach (char c in Text)
            {
                if (c > 57 || c < 48)
                {
                    flag = false;
                    break;
                }
            }
        }
        return flag;
    }
    /// <summary>
    /// 用于发送邮件，注意发信的邮件必须要开启SMTP服务
    /// </summary>
    /// <param name="sender_user"></param>
    /// <param name="sender_password"></param>
    /// <param name="target"></param>
    /// <param name="host"></param>
    /// <param name="title"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public  bool Sender(string sender_user, string sender_password, string target, string host, string title, string body)
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
 



public class LogInfo
{
    public void PushData(int User_t,string Id,string Name)
    {
        UserType = User_t;
        UserID = Id;
        UserName = Name;
    }
    public string[] PopData()
    {
        string[] info = new string[3];
        info[0] = Convert.ToString(UserType);
        info[1] = UserID;
        info[2] = UserName;
        return info;
    }
    private int UserType = 0;
    private string UserID = "";
    private string UserName = "";
}
