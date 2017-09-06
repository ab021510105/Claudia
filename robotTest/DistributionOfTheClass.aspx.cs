using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;

public partial class DistributionOfTheClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (MySqlDataReader read = new Diya().RowReader("Select CourseName,CourseID from CourseInfo where CourseID!=0"))
            {
                while (read.Read())
                {
                    ListItem item = new ListItem(read["CourseName"].ToString(), read["CourseID"].ToString());
                    this.CouresInfo.Items.Add(item);
                }
                this.CouresInfo.Items[0].Selected = true;
            }
            using (MySqlDataReader read =new Diya().RowReader("Select ClassName ,Classid from classinfo where Courseid=" + this.CouresInfo.SelectedValue))
            {
                ListItem item = new ListItem("全部班级", "0");
                this.Classes.Items.Add(item);
                while (read.Read())
                {
                    item = new ListItem(read["ClassName"].ToString(), read["ClassID"].ToString());
                    this.Classes.Items.Add(item);
                }
            }
        }
    }

    protected void Upload_Click(object sender, EventArgs e)
    {
        if (!Classes.Items[0].Selected)
        {
            for (int i = 1; i < Classes.Items.Count; i++)
            {
                if (Classes.Items[i].Selected)
                {
                    using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                    {
                        Sc.Open();
                        MySqlTransaction Transacn = Sc.BeginTransaction();
                        MySqlCommand Scmd = new MySqlCommand();
                        Scmd.Connection = Sc;
                        Scmd.Transaction = Transacn;
                        //MySqlDataReader read;
                        Scmd.CommandText = "Select Contactid from CSRelationship where Classid=" + this.Classes.Items[i].Value;
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = Scmd;
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            string[] ids = Request["Test"].Split(new char[] { '#' });
                            foreach (string id in ids)
                            {
                                if (id.Replace(" ", "") != "")
                                {

                                    Scmd.CommandText = "Insert Into TSRelationship (TestID,ContactID,Score) values(" + id + "," + dr["ContactID"].ToString() + ",-1)";
                                    Scmd.ExecuteNonQuery();
                                   
                                }
                            }
                        }
                        Transacn.Commit();
                    }

                }
            }
        }
        else
        {
            for (int i = 1; i < Classes.Items.Count; i++)
            {
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();
                    MySqlTransaction Transaction = Sc.BeginTransaction();
                    MySqlCommand Scmd = new MySqlCommand();
                    Scmd.Connection = Sc;
                    Scmd.Transaction = Transaction;
                    //MySqlDataReader read;
                    Scmd.CommandText = "Select ContactID from CSRelationship where ClassID=" + this.Classes.Items[i].Value;
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = Scmd;
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string[] ids = Request["Test"].Split(new char[] { '#' });
                        foreach (string id in ids)
                        {
                            if (id.Replace(" ", "") != "")
                            {
                                Scmd.CommandText = "Insert Into TSRelationship (TestID,ContactID,Score) values(" + id + "," + dr["ContactID"].ToString() + ",-1)";
                                Scmd.ExecuteNonQuery();

                            }
                        }
                    }
               
                    Transaction.Commit();
                }
                    
            }
        }
        Session["TheScene"] = "2";
        Response.Redirect("Consultion.aspx");
    }

    protected void CouresInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Classes.ClearSelection();
        this.Classes.Items.Clear();
        using (MySqlDataReader read = new Diya().RowReader("Select ClassName ,ClassID from classinfo where CourseID=" + this.CouresInfo.SelectedValue))
        {
            ListItem item = new ListItem("全部班级", "0");
            this.Classes.Items.Add(item);
            while (read.Read())
            {
                item = new ListItem(read["ClassName"].ToString(), read["ClassID"].ToString());
                this.Classes.Items.Add(item);
            }
        }
    }
    protected void Classes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.Classes.Items[0].Selected == true)
        {
            for (int i = 1; i < this.Classes.Items.Count; i++)
            {
                this.Classes.Items[i].Enabled = false;
            }
        }
        else
        {
            for (int i = 1; i < this.Classes.Items.Count; i++)
            {
                this.Classes.Items[i].Enabled = true;
            }
        }
    }
}