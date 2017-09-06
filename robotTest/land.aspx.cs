using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class land : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection s = new MySqlConnection(Info.datasource);
        Session["TempInfo"] = "" + this.username.Value + "#" + Info.MD5Text(this.pwd.Text);
        try
        {
            s.Open();
        }
        catch(Exception)
        {
            Response.Redirect("error.aspx?error=00");
        }
        MySqlCommand cmd = new MySqlCommand("Select Userid, Username,Usertype From UserInfo0 where Userid='" + this.username.Value + "' and Password='" + Info.MD5Text(this.pwd.Text) + "'", s);
        MySqlDataReader read = cmd.ExecuteReader();
        if (read.Read())
        {
            Info.userid = read.GetString(0);
            Info.uername = read.GetString(1);
            Info.usertype = read.GetInt32(2);
            s.Close();
            //HttpCookie cookie = Request.Cookies["UserInfo"];
            //if (cookie != null)
            //{
            //    Response.Cookies["UserInfo"].Expires = System.DateTime.Now.AddDays(-1);
            //}
            //cookie = new HttpCookie("UserInfo");
            //cookie.Values.Set("user", Info.userid + "#" + Info.uername + "#" + Info.usertype);
            Session["UserInfo"] = Info.userid + "#" + Info.uername + "#" + Info.usertype;
            Session.Timeout = 12 * 60;
            Response.Redirect("start.aspx");
        }
        else
        {
            Response.Redirect("error.aspx?error=01");
        }

        
    }
    private void close(object sender, EventArgs e)
    {

    }
    protected void showpwd_CheckedChanged(object sender, EventArgs e)
    {
        string Temp = this.pwd.Text;
        if (this.showpwd.Checked == true)
        {
            this.pwd.TextMode = TextBoxMode.SingleLine;
        }
        else
        {
            this.pwd.TextMode = TextBoxMode.Password;           
        }
    }
    protected void changword_Click(object sender, EventArgs e)
    {

    }
}