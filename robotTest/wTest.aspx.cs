using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using MySql.Data.MySqlClient;


public partial class wTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand("update consultinginfo set password='"+new Diya().GetMD5Text("11111111")+"' where contactid='"+14120001+"'", sc);
            scmd.ExecuteNonQuery();
        }
        //WebClient wc = new WebClient();
        //string cityCode = "101020100";
        //string xml = wc.DownloadString(Uri.EscapeUriString("http://www.weather.com.cn/adat/cityinfo/" + cityCode + ".html"));
        //Encoding d = Encoding.Default;
        //Encoding gb2312 = Encoding.GetEncoding("GB2312");
        //byte[] temp = Encoding.Convert(Encoding.UTF8, d, gb2312.GetBytes(xml));
        //xml = gb2312.GetString(temp);
        //this.Label1.Text = xml;
        //string[] n1 = xml.Split(new char[] { '\"' });
        //this.inamd.ImageUrl = "http://m.weather.com.cn/img/" + n1[23];
        
    }
    //string xml = wc.DownloadString("http://apistore.baidu.com/microservice/weather?citypinyin="+City);
//ÐÐ 22:         XDocument doc = XDocument.Parse(xml); 
//ÐÐ 23:         string city = doc.Descendants("currentCity").Single().Value; 
//ÐÐ 24:         IEnumerable<XElement> results = doc.Root.Elements("results"); 
    int i = 0;
    protected void Btn1_Click(object sender, EventArgs e)
    {
        this.Label1.Text = i + "";
        i++;
    }
}