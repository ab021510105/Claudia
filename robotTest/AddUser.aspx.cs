using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string errorinfo = null;
        if (this.TextBox1.Text == "")
        {
            errorinfo += "用户名不得为空！";
        }
        if (this.TextBox2.Text == "")
        {
            errorinfo += "ID不得为空！";
        }
        if (this.TextBox3.Text == "")
        {
            errorinfo += "密码不得为空！";
        }
        if (this.TextBox3.Text != this.TextBox4.Text)
        {
            errorinfo += "两次输入的密码不一致！";
        }
        if (errorinfo != null)
        {
            this.Label1.Text = errorinfo;
            this.Label1.Visible = true;
        }
        else
        {
            MySqlConnection s = new MySqlConnection(Info.datasource);
            MySqlCommand cmd = new MySqlCommand("Insert Into UserInfo0 (Userid,Username,password,usertype ) values('"+this.TextBox2.Text+"','"+this.TextBox1.Text+"','"+Info.MD5Text(this.TextBox4.Text)+"',"+this.DropDownList1.SelectedItem.Text+")", s);
            s.Open();
            cmd.ExecuteScalar();
            s.Close();
            this.Label1.Text = "添加成功！";
            this.Label1.Visible = true;
            Response.AddHeader("Refresh", "1");
        }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        MySqlConnection s = new MySqlConnection(Info.datasource);
        MySqlCommand cmd = new MySqlCommand("Select * From UserInfo0 where Userid='"+this.TextBox2.Text+"'",s);
        s.Open();
        MySqlDataReader read = cmd.ExecuteReader();
        if (read.Read())
        {
            this.Label1.Text = "该用户名已经存在！";
            this.Label1.Visible = true;
            this.Button1.Enabled = false;
        }
        s.Close();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        this.Label1.Visible = false;
        this.Button1.Enabled = true;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Welcom.aspx");
    }
}