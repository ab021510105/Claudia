using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class testweb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (MySqlConnection tsc = new MySqlConnection(Diya.ConectionString))
            {
                tsc.Open();
                MySqlCommand tcmd = new MySqlCommand();
                tcmd.Connection = tsc;
                tcmd.CommandText = "update tsrelationship set Score=-1 where score=null";
            }
            string sqlcommand = "SELECT  name from sysobjects where xtype='U'";
            if (this.list != null)
            {
                this.list.ClearSelection();
                this.list.Items.Clear();
            }
            using (MySql.Data.MySqlClient.MySqlDataReader read = new Diya().RowReader(sqlcommand))
            {
                ListItem item = new ListItem("", "");
                item.Selected = true;
                this.list.Items.Add(item);
                while (read.Read())
                {
                    item = new ListItem(read["Name"].ToString(), read["Name"].ToString());
                    this.list.Items.Add(item);
                }
            }
        }
    }
    protected void list_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.list.SelectedValue != "")
        {
            this.command.Text = "select * From ["+this.list.SelectedValue+"]";
        }
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        if (this.command.Text != "")
        {
            if (this.command.Text.Split(new char[] { ' ' })[0].ToUpper() == "SELECT")
            {
                try
                {
                    DataSet ds = new DataSet();
                    using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString) )
                    {
                        Sc.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(this.command.Text,Sc);
                        da.Fill(ds);
                    }
                    ViewState["data1"] = this.gridview1.DataSource=ds.Tables[0];
                    this.gridview1.DataBind();
                }
                catch (Exception err)
                {
                    this.l1.Text = err.Message;
                    this.l1.Visible = true;
                }
            }
            else
            {
                using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
                {
                    try
                    {
                        Sc.Open();
                        MySqlCommand Scmd = new MySqlCommand(this.command.Text, Sc);
                        this.l1.Text = Scmd.ExecuteNonQuery()+"–– ‹”∞œÏ.";
                        this.l1.Visible = true;
                    }
                    catch (Exception err)
                    {
                        this.l1.Text = err.Message;
                        this.l1.Visible = true;
                    }
                }
            }
        }
    }
    protected void gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gridview1.PageIndex = e.NewPageIndex;
        this.gridview1.DataSource = ViewState["data1"];
        this.gridview1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string Comd = "select * from syscolumns where id=object_id('"+this.list.SelectedValue+"') ";
        this.command.Text = Comd;
        DataSet ds=new DataSet();
        using( MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            MySqlDataAdapter da=new MySqlDataAdapter(Comd,Sc);
            da.Fill(ds);
          
        }
        ViewState["data1"] = gridview1.DataSource = ds;
        gridview1.DataBind();
    }
}