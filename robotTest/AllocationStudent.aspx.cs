using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class AllocationStudent : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                if (Request.Cookies["UserConfig"] == null)
                {
                    Response.Redirect("Consultion.aspx");
                }
                else
                {
                    HttpCookie cookie = Request.Cookies["UserConfig"];
                    Session["UserInfo"] = Server.HtmlEncode(new Diya().GetDESDecrypt(cookie.Value));
                }
            }
            string[] Info = Session["UserInfo"].ToString().Split(new char[] { '#' });
            Diya.GetUserInfo(Convert.ToInt32(Info[0]), Info[1], Info[2]);
            this.UserInfoTitel.Text = Info[2];
            ViewState["ClassID"] = Session["ClassID_A"];
            Session["ClassID_A"] = null;
            ViewState["StudentInfo"] = new Diya().Gridviewbind(this.GW1, "Select * from ConsultingInfo");
            using (MySqlDataReader read = new Diya().RowReader("Select * From classinfo  where classinfo.Classid=" + ViewState["ClassID"]))
            {
                read.Read();
                this.ClassName_Label.Text = read["ClassName"].ToString();
            }
            DataTable Dt = new DataTable();
            for (int i = 0; i < this.GW1.Rows.Count; i++)
            {
                DataColumn Dc = new DataColumn(Convert.ToString(i) + "#");
                Dc.DefaultValue = "0";
                Dt.Columns.Add(Dc);
            }
            for (int i = 0; i < this.GW1.PageCount; i++)
            {
                Dt.Rows.Add(Dt.NewRow());
            }
            ViewState["Selection"] = Dt;
        }
    }

    protected void Confrim_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["Selection"];
        for (int i = 0; i < this.GW1.PageCount; i++)
        {
            for(int j=0;j<this.GW1.Rows.Count;j++)
            {
                if (dt.Rows[i][Convert.ToString(j)+"#"].ToString()!="0")
                {
                    using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                    {
                        Sc.Open();
                        MySqlCommand Scmd = new MySqlCommand("insert into CSrelationship(Classid,Contactid) Values (" + ViewState["ClassID"].ToString() + "," + dt.Rows[i][Convert.ToString(j)+"#"] + ")", Sc);
                        Scmd.ExecuteNonQuery();
                    }
                }
            }
        }
        for(int i=0;i<this.GW1.Rows.Count;i++)
        {
            CheckBox CKB = this.GW1.Rows[i].FindControl("CheckBox") as CheckBox;
            if (CKB.Checked)
            {
                Label lab = this.GW1.Rows[i].FindControl("label1") as Label;
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();
                    MySqlCommand Scmd = new MySqlCommand("insert into CSrelationship(Classid,Contactid) Values (" + ViewState["ClassID"].ToString() + "," + lab.Text + ")", Sc);
                    Scmd.ExecuteNonQuery();
                }
            }
        }
        Session["TheScene"] = "1";
        Response.Redirect("Consultion.aspx");
    }

    protected void GW1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable Dt = (DataTable)ViewState["Selection"];
        for (int i = 0; i < this.GW1.Rows.Count; i++)
        {
            CheckBox CKB = this.GW1.Rows[i].FindControl("CheckBox") as CheckBox;
            if (CKB.Checked)
            {
                Label lab = this.GW1.Rows[i].FindControl("label1") as Label;
                Dt.Rows[this.GW1.PageIndex][i + "#"] = lab.Text;
            }
            else
            {
                Dt.Rows[this.GW1.PageIndex][i + "#"] = "0";
            }
        }
        ViewState["Selection"] = Dt;
        this.GW1.PageIndex = e.NewPageIndex;
        this.GW1.DataSource = ViewState["StudentInfo"] as DataTable;
        this.GW1.DataBind();
    }
    protected void GW1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void GW1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Selection"] != null)
            {
                DataTable dt = (DataTable)ViewState["Selection"];
                if (dt.Rows[this.GW1.PageIndex][Convert.ToString(e.Row.RowIndex) + "#"].ToString() != "0")
                {
                        CheckBox Chkb = e.Row.FindControl("CheckBox") as CheckBox;
                        Chkb.Checked = true;
                }
                else
                {
                    CheckBox Chkb = e.Row.FindControl("CheckBox") as CheckBox;
                    Chkb.Checked = false;
                }
            }
        }
    }
    protected void GW1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }
    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        
            for (int i = 0; i < this.GW1.Rows.Count; i++)
            {
                CheckBox Ch = this.GW1.Rows[i].FindControl("CheckBox") as CheckBox;
                if (!Ch.Checked)
                {
                    if (ViewState["Selection"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["Selection"];
                        dt.Rows[this.GW1.PageIndex][Convert.ToString(i) + "#"] = "0";
                        ViewState["Selection"] = dt;
                    }
                }
            }
    }
    protected void BackUp_Click(object sender, EventArgs e)
    {
        Session["TheScene"] = "1";
        Response.Redirect("Consultion.aspx");
    }
}