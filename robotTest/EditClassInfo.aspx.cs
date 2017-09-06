using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class EditClassInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)//需要Session[ClassInfo_id];需要Mode:Edit;Add ViewStat[Classid]
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                if (Request.Cookies["UserConfig"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            using (MySql.Data.MySqlClient.MySqlDataReader read = new Diya().RowReader("Select * from CourseInfo"))
            {
                while (read.Read())
                {
                    ListItem item = new ListItem(read["CourseName"].ToString(), read["Courseid"].ToString());
                    this.CourseInfo_Drop.Items.Add(item);
                }
            }
            if (Request["Mode"] == "Edit")
            {
                ViewState["Classid"] = Session["ClassInfo_id"];
                Session["ClassInfo_id"] = null;
                string SelectCmd = "select * from classinfo Where Classid=" + ViewState["Classid"];
                using (MySql.Data.MySqlClient.MySqlDataReader read = new Diya().RowReader(SelectCmd))
                {
                    read.Read();
                    this.OpenAnAccount.Value = read["OpenAnAccount"].ToString();
                    this.ClassName.Value = read["ClassName"].ToString();
                    this.ClassTime.Value = read["ClassTime"].ToString();
                    this.WEEK.Value = read["Week"].ToString();
                    this.RemainingNumber.Value = read["RemainingNumber"].ToString();
                    foreach (ListItem item in this.CourseInfo_Drop.Items)
                    {
                        if (item.Value == read["Courseid"].ToString())
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                    if (read["MF"].ToString() == "0")
                    {
                        this.MF_Dorp.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MF_Dorp.SelectedIndex = 1;
                    }
                }
            }
        }
    }

    protected void UpLoad_Click(object sender, EventArgs e)
    {
        if (ViewState["Classid"] != null)
        {
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string Sqlcmd = "update classinfo set OpenAnAccount='" + this.OpenAnAccount.Value + "', ClassTime=" + this.ClassTime.Value + ",RemainingNumber=" + this.RemainingNumber.Value + ",Courseid=" + this.CourseInfo_Drop.SelectedValue + ",ClassName='" + this.ClassName.Value + "',Week='" + this.WEEK.Value + "',MF=" + this.MF_Dorp.SelectedValue + " where Classid=" + ViewState["Classid"];
                MySqlCommand Scmd = new MySqlCommand(Sqlcmd, Sc);
                Scmd.ExecuteNonQuery();
            }
          
        }
        else
        {
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string Sqlcmd = "insert into classinfo(OpenAnAccount,ClassTime,RemainingNumber,Courseid,ClassName,MF,Week)values('"+this.OpenAnAccount.Value+"',"+this.ClassTime.Value+","+this.RemainingNumber.Value+","+this.CourseInfo_Drop.SelectedValue+",'"+this.ClassName.Value+"',"+MF_Dorp.SelectedValue+",'"+this.WEEK.Value+"')";
                MySqlCommand Scmd = new MySqlCommand(Sqlcmd,Sc);
                Scmd.ExecuteNonQuery();
            }
        }
        Session["TheScene"] = "3";
        Response.Redirect("Consultion.aspx");
    }
}