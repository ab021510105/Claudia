using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Confirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request["Command"]=="delete")
        {
            if (Session["ConfirmInfo"] == null)
            {
                Response.Redirect("start.aspx");
            }
            else
            {
                string key = Session["ConfirmInfo"].ToString();
                Info i = new Info();
                MySql.Data.MySqlClient.MySqlDataReader read = i.SelectCountUnit("Select", " ConsultingInfo ", " ChildrenCall ", " Contactid=" + key);
                read.Read();
                this.info.Text = "ɾ��";
                this.Val.Text = read.GetString(0) + " ID=" + key;
                this.info.ForeColor = System.Drawing.Color.Red;
            }
        }
        else if(Request["Command"]=="Add")
        {
            if(this.AddCanalid!=null)
            {
                this.AddCanalid.ClearSelection();
                this.AddCanalid.Items.Clear();
            }
            Info i = new Info();
            using(MySql.Data.MySqlClient.MySqlDataReader read=i.SelectCountUnit("Select"," CanalInfo "," Canalid,CanalName "," Canalid!=0 "))
            {
                while(read.Read())
                {
                    ListItem item = new ListItem(read.GetString(1),Convert.ToString(read.GetInt32(0)));
                    this.AddCanalid.Items.Add(item);
                }
                if(!IsPostBack)
                this.AddCanalid.SelectedIndex = 0;
            }
            string key = Session["ConfirmInfo"].ToString();
            this.info.Text = "����ֶ�";
            Info j = new Info();
            MySql.Data.MySqlClient.MySqlDataReader read1 = j.SelectCountUnit("Select", " ConsultingInfo ", " ChildrenCall ", " Contactid=" + key);
            read1.Read();
            this.Canalid.Visible = true;
            this.Val.Text = read1.GetString(0) + " ID=" + key;
            this.info.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ac2_Click(object sender, EventArgs e)
    {
        if(Request["Command"]=="delete")
        {
            string DelConsultingCommand = "Delete ConsultingInfo Where Contactid=" +Session["ConfirmInfo"].ToString();
            Info.InsertUpdateUnit(DelConsultingCommand);
            Session["FeedBack"] += System.DateTime.Now.ToString("hh��mm��ss") + " ����" + Session["ConfirmInfo"].ToString() + "ִ�гɹ�";
            Session["FeedBack"] += "#";
            Session["ConfirmInfo"] = null;
            Session["Command"] = null;
            Response.Redirect("start.aspx");
        }
        else if(Request["Command"]=="Add")
        {
            Info.InsertUpdateUnit("Update ConsultingInfo set Canalid=" + this.AddCanalid.SelectedValue + " where Contactid=" + Session["ConfirmInfo"].ToString());
            Session["FeedBack"] += System.DateTime.Now.ToString("hh��mm��ss") + " ����" + Session["ConfirmInfo"].ToString() + "ִ�гɹ�";
            Session["FeedBack"] += "#";
            Session["ConfirmInfo"] = null;
            Session["Command"] = null;
            Literal MeGTex = new Literal();
            MeGTex.Text = "<script>alert('��ӳɹ�!');</script>";
            this.Controls.Add(MeGTex);
            Response.Redirect("start.aspx");
        }
    }
    protected void ac3_Click(object sender, EventArgs e)
    {
        Session["FeedBack"] += System.DateTime.Now.ToString("hh��mm��ss") + " �û���ȡ������";
        Session["FeedBack"] += "#";
        Session["ConfirmInfo"] = null;
        Session["Command"] = null;
        Response.Redirect("start.aspx");
    }
}