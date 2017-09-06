using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class AddConsluting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] != null)
            {
                using (MySqlDataReader read = new Diya().RowReader("Select * From classinfo Where Classid!=0"))
                {
                    while (read.Read())
                    {
                        ListItem item = new ListItem(read["ClassName"].ToString(),read["Classid"].ToString());
                        this.ClassInfo_Dorp.Items.Add(item);
                    }
                }
                string[] Info = Session["UserInfo"].ToString().Split(new char[] { '#' });
                Diya.GetUserInfo(Convert.ToInt32(Info[0]), Info[1], Info[2]);
                this.landinfo.Text = Info[2];
                if (Request["Mode"] == "Add")
                {
                    ListItem[] items = new ListItem[2];
                    items[0] = new ListItem("男", "1");
                    items[1] = new ListItem("女", "0");
                    this.Sex.Items.AddRange(items);
                    using (MySqlDataReader read = new Diya().RowReader("Select Canalid,CanalName From CanalInfo"))
                    {
                        while (read.Read())
                        {
                            ListItem item = new ListItem(read["CanalName"].ToString(), read["Canalid"].ToString());
                            this.Cannel.Items.Add(item);
                        }
                    }
                }
                else
                {
                    this.ClassInfo_Dorp.Enabled = false;//目前还没有很好的方法去更新CSRelationship表，先禁用之
                    string _id = Request["Mode"];
                    string id = Session["ConEditInfo"].ToString();
                    ViewState["UpdateID"] = id;
                    Session["ConEditInfo"] = null;
                    using (MySqlDataReader read = new Diya().RowReader("Select * From ConsultingInfo where Contactid="+id))
                    {
                        read.Read();
                        this.Children_Call.Value = read["ChildrenCall"].ToString();
                        this.Parent_Call.Value = read["ParentsCall"].ToString();
                        this.Age.Value = read["ChildrenAge"].ToString();
                        this.ClassLV.Value = read["ClassLv"].ToString();
                        this.Sex.Items.Add(new ListItem("男","男"));
                        this.Sex.Items.Add(new ListItem("女","女"));
                        if (read["ChildrenSex"].ToString() == "男")
                        {
                            this.Sex.SelectedIndex = 0;
                        }
                        else 
                        {
                            this.Sex.SelectedIndex = 1;
                        }
                        this.School.Value = read["School"].ToString();
                        this.Contact.Value = read["Contact"].ToString();
                        this.arrive.Value = read["ReceptionTime"] == DBNull.Value ? "" : read["ReceptionTime"].ToString();
                        string Canalid = read["Canalid"].ToString();
                        using(MySqlDataReader Cread=new Diya().RowReader("select * from CanalInfo"))
                        {
                            while(Cread.Read())
                            {
                                ListItem item = new ListItem(Cread["CanalName"].ToString(),Cread["Canalid"].ToString());
                                if(item.Value==Canalid)
                                {
                                    item.Selected = true;
                                }
                                this.Cannel.Items.Add(item);
                            }
                        }
                        this.remark.Text = read["Remarks"].ToString();
                    }
                }
            }
        }
    }
    protected void Confirm_Click(object sender, EventArgs e)
    {
        using( MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            bool Error = false;
            if (this.Parent_Call.Value == "")
            {
                Error = true ;
            }
            if (ClassLV.Value == "")
            {
                Error = true;
            }
            if(this.School.Value=="")
            {
                Error = true ;
            }
            if (this.Contact.Value == ""||!new Diya().checktext("Phonenumber",this.Contact.Value))
            {
                Error = true;
            }
            if (!Error)
            {
                if (Request["Mode"] == "Add")
                {
                    MySqlCommand Scmd = new MySqlCommand("Select Max(Contactid) as id from ConsultingInfo", Sc);
                    MySqlDataReader read = Scmd.ExecuteReader();
                    read.Read();
                    int previd = Convert.ToInt32(read["id"].ToString());
                    int now = Convert.ToInt32(DateTime.Now.ToString("yyMM") + "0000");
                    string id;
                    if (previd < now)
                    {
                        id = Convert.ToString(now + 1);
                    }
                    else
                    {
                        id = Convert.ToString(previd + 1);
                    }
                    using (MySqlConnection InSc = new MySqlConnection(Diya.ConectionString))
                    {
                        InSc.Open();
                        if (Session["UserInfo"] == null)
                        {
                            Session["TheScene"] = "4";
                            Response.Redirect("Consultion.aspx");
                        }
                        Diya diya = new Diya();
                        MySqlCommand InScmd = new MySqlCommand("Insert Into ConsultingInfo(Contactid,Userid,ConsultingTime,ChildrenCall,ParentsCall,Contact,ChildrenAge,ChildrenSex,School,Remarks,SignUp,ClassLv,Canalid,Password) values(" + id + ",'" + Session["UserInfo"].ToString().Split(new char[] { '#' })[1] + "','" + System.DateTime.Now.ToShortDateString() + "','" + this.Children_Call.Value + "','" + this.Parent_Call.Value + "','" + Contact.Value + "'," + this.Age.Value + ",'" + this.Sex.SelectedValue + "','" + this.School.Value + "','" + this.remark.Text + "',0,'" + ClassLV.Value + "'," + this.Cannel.SelectedValue + ",'" +diya.GetMD5Text("11111111") + "')", InSc);
                        InScmd.ExecuteNonQuery();
                      
                    }
                    using (MySqlConnection InSc = new MySqlConnection(Diya.ConectionString))
                    {
                        InSc.Open();
                        MySqlCommand InScmd = new MySqlCommand("insert into CSrelationship(Classid,Contactid,Payment,Registrarion,InReading) values(" + this.ClassInfo_Dorp.SelectedValue + "," + id + "," + "0" + ",0" + ",1" + ")", InSc);
                        InScmd.ExecuteNonQuery();
                    }
                    Session["TheScene"] = "4";
                    Response.Redirect("Consultion.aspx");
                }
                else
                {
                    MySqlCommand Scmd = new MySqlCommand("Update ConsultingInfo set ChildrenCall='" + this.Children_Call.Value + "',ParentsCall='" + this.Parent_Call.Value + "',ChildrenAge=" + this.Age.Value + ",ClassLv='" + this.ClassLV.Value + "',ChildrenSex='" + this.Sex.SelectedValue + "',School='" + this.School.Value + "',Contact='" + this.Contact.Value + "',ReceptionTime='" + this.arrive.Value + "',Canalid=" + this.Cannel.SelectedValue + ",Remarks='" + this.remark.Text + "' where Contactid=" + ViewState["UpdateID"],Sc);
                    Scmd.ExecuteNonQuery();
                    Session["TheScene"] = "4";
                    Response.Redirect("Consultion.aspx");
                }
              
            }
            else
            {

            }
        }
    }
    protected void return_Click(object sender, EventArgs e)
    {
        Session["TheScene"] = "4";
        Response.Redirect("Consultion.aspx");
    }
}