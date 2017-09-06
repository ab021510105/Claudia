using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using MySql.Data.MySqlClient;

public partial class start : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("land.aspx");
        }
        else
        {
            string[] data = Session["UserInfo"].ToString().Split(new char[] { '#' });
            Info.userid = data[0];
            Info.uername = data[1];
            Info.usertype = Convert.ToInt32(data[2]);
            this.username.Text = "��ӭ��," + Info.uername;            
            if (!IsPostBack)
            {
                SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " �����֤...";
                Info _i = new Info();
                MySqlDataReader read= _i.SelectCountUnit("Select", " UserInfo0 "," Userid "," Userid='"+Info.userid+"' And UserName='"+Info.uername+"' And Usertype="+Info.usertype+" And Password="+"'"+Session["TempInfo"].ToString().Split(new char[]{'#'})[1]+"'");
                //Session["TempInfo"] = null;
                if(!read.Read())
                {
                    Response.Redirect("error.aspx?error=01");
                }
                try
                {
                    Info.InsertUpdateUnit("update UserInfo0 set IsOnLine=1 where Userid='"+Info.userid+"'");
                    SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " ����׼������...";
                    ViewState["ConsultingInfo_N"] = (DataTable)Info.Gridviewbind(this.GridView1, selectcommand_N).Tables[0];
                    ViewState["TitlePageCount"] = this.GridView1.PageCount;
                    if (Session["BackUp"] != null)
                    {
                        Session["BackUp"] = null;
                    }
                    if (Session["FeedBack"] != null)
                    {
                        string[] inf = Session["FeedBack"].ToString().Split(new char[] { '#' });
                        Session["FeedBack"] = null;
                        for (int i = 0; i < inf.Length; i++)
                        {
                            SenderMessage().Text = inf[i];
                        }

                    }
                    //this.GridView1.DataKeyNames = new string[] { "Contactid", "Relationshipid" };
                    //Info.StartCheck();
                }
               catch (Exception)
               {
                   Info.InsertUpdateUnit(@"Insert Into Log(Time,Logic)Values(" + System.DateTime.Today + "," + this.Info0.Text + "\n" + this.Info1.Text + "\n" + this.Info2.Text + "\n" + this.Info3.Text + "\n" + this.Info4.Text + "\n" + System.DateTime.Now.ToString("hh��mm��ss") + " ϵͳ��������Code:04" + ")");
                   Session["FeedBack"] += SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " ϵͳ��������Code:04,�ѱ�����־";
                   Response.Redirect("error.aspx?error=04");
                }
                SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " ϵͳ����!";
            }
            Info i1 = new Info();
            using(MySqlDataReader read=i1.SelectCountUnit("Select"," UserInfo0 ","  Username ", " IsOnLine=1 And Userid='"+Info.userid+"'"))
            {
                if(!read.Read())
                {
                    Session.Clear();
                }
            }
        }
    }
    string selectcommand_ALL = "SELECT UserInfo0.Username, ConsultingInfo.ConsultingTime, ConsultingInfo.ParentsCall, ConsultingInfo.Contact, CourseInfo.CourseName, ConsultingInfo.ChildrenSex, ConsultingInfo.Contactid, ConsultingInfo.ChildrenCall, ConsultingInfo.ChildrenAge, ConsultingInfo.School, ConsultingInfo.Remarks, ConsultingInfo.SignUp, ConsultingInfo.Courseid ,CSrelationship.Relationshipid,ConsultingInfo.ReceptionTime FROM UserInfo0 INNER JOIN ConsultingInfo ON UserInfo0.Userid = ConsultingInfo.Userid INNER JOIN CourseInfo ON ConsultingInfo.Courseid = CourseInfo.Courseid INNER JOIN CSrelationship ON CSrelationship.Contactid=ConsultingInfo.Contactid";
    string selectcommand_N = "Select ConsultingInfo.Contact,ConsultingInfo.Contactid,ConsultingInfo.ParentsCall,ConsultingInfo.ChildrenCall,ConsultingInfo.ReceptionTime From ConsultingInfo";

    public System.Web.UI.WebControls.Label SenderMessage()
    {
        System.Web.UI.WebControls.Label[] label = { this.Info0, this.Info1,this.Info2,this.Info3,this.Info4 };
        string[] mov = { this.Info0.Text, this.Info1.Text, this.Info2.Text, this.Info3.Text, this.Info4.Text };
        System.Web.UI.WebControls.Label lab = label[0];
        int i = 0;
        while (true)
        {
            if (i == label.Length - 1)
            {
                lab = label[i];
                for (int j = label.Length - 1; j > 0; j--)
                {
                   mov[j - 1]=label[j].Text;
                }
                for (int k = 0; k < label.Length;k++ )
                {
                    label[k].Text = mov[k];
                }
                    break;
            }
            else if (label[i].Text != "")
            {
                i++;
            }
            else
            {
                lab = label[i];
                break;
            }
        }
        return lab;
    }
    protected void landout_Click(object sender, EventArgs e)
    {
        Session["UserInfo"] = null;
        Session["TempInfo"] = null;
        Session["FeedBack"]+=SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " ��ǰȨ���Ѿ�ע������Ҫ�����ݲ�����ˢ��ҳ�����µ���";
        Session["FeedBack"] += "#";
        this.username.Text = null;
        this.land.Visible = true;
    }
    protected void home_Click(object sender, EventArgs e)
    {
        Session["FeedBack"]+=System.DateTime.Now.ToString("hh��mm��ss") + " ִ������ҳ��";
        Session["FeedBack"] += "#";
        Response.AddHeader("refresh", "0");
        
    }
    protected void searchbutton_Click(object sender, ImageClickEventArgs e)
    {
        string serchcmd = selectcommand_ALL + " where 1>0";
        string serchtext = Request.Form["search"];
        string[] vaule = serchtext.Split(new char[] { ' ' });
        for (int i = 0; i < vaule.Length; i++)
        {
            if (vaule[i] == "")
            {
                continue;
            }
            if (Info.checktext("PhoneNumber", vaule[i]))
            {
                serchcmd += " and ConsultingInfo.Contact='"+vaule[i]+"'";
            }
            else if (Info.checktext("n", vaule[i]))
            {
                serchcmd += " and ConsultingInfo.ChildrenAge=" + vaule[i];
            }
            else
            {
                serchcmd += " and ( ConsultingInfo.ParentsCall like '%" + vaule[i] + "%' or ConsultingInfo.Contact like '%" + vaule[i] + "%' or CourseInfo.CourseName like '%" + vaule[i] + "%' or ConsultingInfo.ChildrenSex like '%" + vaule[i] + "%' or ConsultingInfo.ChildrenCall like '%" + vaule[i] + "%' or  ConsultingInfo.School like '%" + vaule[i] + "%' or ConsultingInfo.Remarks like '%" + vaule[i] + "%')";
            }
        }

        ViewState["ConsultingInfo_N"] = (DataTable)Info.Gridviewbind(this.GridView1, serchcmd).Tables[0];
        //this.GridView1.DataKeyNames = new string[] { "Contactid" };
        Tips.Text = "��ǰ�����Ĺؼ���Ϊ:" + serchtext;
        this.Tips.Visible = true;
        Session["FeedBack"]+=SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + Tips.Text;
        Session["FeedBack"] += "#";
        this.moretable.Visible = false;
        this.GridView1.Visible = true;
        this.addtable.Visible = false;
        SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " Gridview�Ѿ�ȡ��ֵ�������б���ʱ����";
    }
    protected void Add_button_Click(object sender, EventArgs e)
    {
        if (Session["Command"] != null)
        {
            if (Session["Command"].ToString() == "Edit")
            {
                string error = null;
                int j = 0;
                string[] name = new string[7];
                if (!Info.checktext("PhoneNumber", this.PhoneNumber.Text))
                {
                    error += "�绰����Ƿ�!//n ";
                    name[j] = "PhoneNumber";
                    j++;
                }
                if (!Info.checktext("N", this.Age.Text))
                {
                    error += "�������������!//n";
                    name[j] = "Age";
                    j++;
                }
                if (this.childsex.Text != "��" && this.childsex.Text != "Ů")
                {
                    error += "�Ա�ֻ�����л���Ů!//n";
                    name[j] = "childsex";
                    j++;
                }
                if (error != null)
                {
                    Literal MeGTex = new Literal();
                    MeGTex.Text = "<script>alert('" + error + "');</script>";
                    Page.Controls.Add(MeGTex);
                    for (j = 0; j < name.Length; j++)
                    {
                        TextBox tb = (TextBox)this.FindControl(name[j]);
                        tb.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    string Reception = "NULL";
                    if (this.Reception.Value != "")
                    {
                        Reception =  "'"+this.Reception.Value+"'" ;
                    }
                    string UpdateCommand = "Update ConsultingInfo set ParentsCall='" + this.ParentsCall.Text + "',Contact='" + PhoneNumber.Text + "', ChildrenSex='" + childsex.Text + "', ChildrenCall='" + chrildname.Text + "',ChildrenAge=" + Age.Text + ",School='" + school_TextBox.Value + "',Remarks='" + Remark_TextBox.Text + "', ClassLv='"+this.ClassLv.Text+"',ReceptionTime="+Reception+" where Contactid="+Temp._Courseid;                   
                    Info.InsertUpdateUnit(UpdateCommand);
                    //ViewState["ConsultingInfo_N"] = (DataTable)Info.Gridviewbind(this.GridView1, selectcommand_N).Tables[0];
                    Session["Command"] = null;
                    Response.AddHeader("refresh", "0");
                }
            }
            else
            {
                Tips.Text = "�޷���ӣ����ȳ�����һ������!";
                SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " ��鵽Command->" + Session["Command"].ToString() + ",�޷����в���";
            }
        }
        else
        {
            //string CourseName = null;
            string Courseid = "0";
            string error = null;
            if (!Info.checktext("PhoneNumber", this.PhoneNumber.Text))
            {
                error += "�绰����Ƿ�!//n ";
                this.PN_error.Text = "�绰����Ƿ�!";
                this.PN_error.Visible = true;
            }
            if (!Info.checktext("N", this.Age.Text))
            {
                error += "�������������!//n";
                this.Age_error.Text = "�������������!//n";
                this.Age_error.Visible = true;
            }
            if (this.childsex.Text != "��" && this.childsex.Text != "Ů")
            {
                error += "�Ա�ֻ�����л���Ů!//n";
                this.sex_errorlab.Text = "�Ա�ֻ�����л���Ů!";
                this.sex_errorlab.Visible = true;
            }
            if (error != null)
            {
                Literal MeGTex = new Literal();
                MeGTex.Text = "<script>alert('" + error + "');</script>";
                Page.Controls.Add(MeGTex);
                //for (j = 0; j < name.Length; j++)
                //{
                //    TextBox tb = (TextBox)this.FindControl(name[j]);
                //    tb.ForeColor = System.Drawing.Color.Red;
                //}
            }
            else
            {
                Info i = new Info();
                string id = System.DateTime.Today.ToString("yyMM") + "0001";
                using (MySqlDataReader read = i.SelectCountUnit("select", " ConsultingInfo ", " Contactid ", "  Contactid=(Select Max(Contactid) From ConsultingInfo)"))
                {
                    if (read.Read())
                    {
                        int yn = read.GetInt32(0) / 10000;
                        if (yn == Convert.ToInt32(System.DateTime.Today.ToString("yyMM")))
                        {
                            int temp = read.GetInt32(0);
                            temp += 1;
                            id = Convert.ToString(temp);
                        }
                    }
                    read.Close();
                    Session["FeedBack"] += SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " ID" + id + "�Ѿ�����";
                    Session["FeedBack"] += "#";
                }
                if (Info.userid == null)
                {
                    Response.Redirect("land.aspx");
                }
                //foreach (char c in this.Remark_TextBox.Text)
                //{
                //    if (c != '#')
                //    {
                //        Info.remarks += c;
                //    }
                //    else
                //    {
                //        CourseName += c;
                //    }
                //}
                //if (CourseName != null)
                //{
                //    using (MySqlDataReader read = i.SelectCountUnit("select", " CourseInfo", " Courseid", " CourseName=" + CourseName))
                //    {
                //        if (read.Read())
                //        {
                //            Courseid = read.GetString(0);
                //        }
                //        read.Close();
                //    }
                //}
                Info.InsertUpdateUnit("Insert Into ConsultingInfo(Contactid,Userid,ConsultingTime,ParentsCall,Contact,ChildrenCall,ChildrenSex,ChildrenAge,School,Remarks,Courseid,SignUp,ClassLv,Canalid) Values (" + id + ",'" + Info.userid + "','" + DateTime.Now + "','" + this.ParentsCall.Text + "','" + this.PhoneNumber.Text + "','" + this.chrildname.Text + "','" + this.childsex.Text + "','" + this.Age.Text + "','" + this.school_TextBox.Value + "','" + this.Remark_TextBox.Text + "','" + Courseid + "',0,'"+this.ClassLv.Text+"',0)");
                Info.InsertUpdateUnit("Insert Into CSrelationship(Classid,Contactid) Values (0," + id + ")");
                if (this.Reception.Value != "")
                {
                    Info.InsertUpdateUnit("Update ConsultingInfo set ReceptionTime='"+this.Reception.Value+"' where Contactid="+id);
                }

                Info.remarks = null;
                Session["ConfirmInfo"] = id;
                Response.Redirect("Confirm.aspx?Command=Add");
                Literal MeGTex = new Literal();
                MeGTex.Text = "<script>alert('��ӳɹ�!');</script>";
                Session["FeedBack"] += SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " �ֶ��ѽ������ݿ�!";
                Session["FeedBack"] += "#";
                Page.Controls.Add(MeGTex);
                Response.AddHeader("Refresh", "0");
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "More")
        {
            this.Tips.Text = "��ǰ����:�鿴��ϸ����";
            this.Tips.Visible = true;
            string test = e.CommandArgument.ToString();
            SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss")+" ��ȡ��ID\""+test+"\" ��ִ������չ������";
            Session["SelectID_More"] = e.CommandArgument.ToString();
            Info i = new Info();
            try
            {
                MySqlDataReader read;
                using (read = i.SelectCountUnit("select", " UserInfo0 INNER JOIN ConsultingInfo ON UserInfo0.Userid = ConsultingInfo.Userid INNER JOIN CourseInfo ON ConsultingInfo.Courseid = CourseInfo.Courseid INNER JOIN CSrelationship ON CSrelationship.Contactid=ConsultingInfo.Contactid INNER JOIN CanalInfo ON CanalInfo.Canalid=ConsultingInfo.canalid ", " CanalInfo.CanalName,  UserInfo0.Username, ConsultingInfo.ConsultingTime, ConsultingInfo.ParentsCall, ConsultingInfo.Contact, CourseInfo.CourseName, ConsultingInfo.ChildrenSex, ConsultingInfo.Contactid, ConsultingInfo.ChildrenCall, ConsultingInfo.ChildrenAge, ConsultingInfo.School, ConsultingInfo.Remarks, ConsultingInfo.SignUp, ConsultingInfo.Courseid ,CSrelationship.Relationshipid,ConsultingInfo.SignUp,ConsultingInfo.ReceptionTime,ConsultingInfo.ClassLv ", " ConsultingInfo.Contactid=" + test))
                {//                                                                                                                                                                                                                                                                                            0                      1                               2                           3                        4                   5                           6                               7                8                           9                          10                   11                 12                                13                     14                  15                                   16  
                    read.Read();
                    this.UserName_Label.Text = read.GetString(0+1);
                    this.Time_Label.Text = read.GetDateTime(1+1).ToString("yyyy��MM��dd��  hh:mm");
                    this.childerName_label.Text = read.GetString(7+1);
                    this.Sex_label.Text = read.GetString(5+1);
                    this.Age_Label.Text = read.GetInt32(8+1).ToString() + "��";
                    this.School_Label.Text = read.GetString(9+1);
                    this.Contact_label.Text = read.GetString(3+1);
                    this.Parents_Call.Text = read.GetString(2+1);
                    this.Remarks_label.Text = read.GetString(10+1);
                    this.SignUp_Label.Text = read.GetInt32(14+1)==1?"�ѱ���":"δ����";
                    this.ClassLv_label.Text =read["ClassLv"]!=DBNull.Value?read.GetString(16+1): "";
                    this.Canal.Text =read["CanalName"] != DBNull.Value? read.GetString(0):"δ֪";
                    if (read["ReceptionTime"] != DBNull.Value)
                    {
                        this.Reception_label.Text = read.GetDateTime(15+1).ToString("yyyy-MM-dd");
                        this.Reception_label.ForeColor = Convert.ToInt32(System.DateTime.Today.ToString("yyMMdd")) >= Convert.ToInt32(read.GetDateTime(15+1).ToString("yyMMdd")) ? System.Drawing.Color.Black : System.Drawing.Color.Red;
                    }
                    else
                    {
                        this.Reception_label.Text = "";
                    }


                }
            }
            catch (Exception)
            {
               // Info.InsertUpdateUnit("Insert Into Log(Time,Logic)Values(" + System.DateTime.Today + "," + this.Info0.Text + "\n" + this.Info1.Text + "\n" + this.Info2.Text + "\n" + this.Info3.Text + "\n" + this.Info4.Text + "\n" + System.DateTime.Now.ToString("hh��mm��ss") + " ϵͳ��������Code:05" + ")");
                Session["FeedBack"] += SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " ϵͳ��������Code:05,�ѱ�����־";
                Response.Redirect("error.aspx?error=05");
            }
            finally
            {

                this.moretable.Visible = true;
                this._GridView.Visible = false;
                SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " ID\"" + test + "\" չ�����!";
            }

        }
        else if (e.CommandName == "Select")
        {
            string Key = e.CommandArgument.ToString();
            SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " �Ѿ���ȡID\""+Key+"\"";
            if (Session["Command"].ToString() == "Edit")
            {
                SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " ����Ϊ�޸Ĳ���չ������";
                this.Tips.Text = "��ǰ����Ϊ:�޸�";
                this._GridView.Visible = false;
                this.moretable.Visible = false;
                this.addtable.Visible = true;
                this.Add_button.Text = "����";
                Info inf = new Info();
                MySqlDataReader read;
                using (read = inf.SelectCountUnit("select", " UserInfo0 INNER JOIN ConsultingInfo ON UserInfo0.Userid = ConsultingInfo.Userid INNER JOIN CourseInfo ON ConsultingInfo.Courseid = CourseInfo.Courseid INNER JOIN CSrelationship ON CSrelationship.Contactid=ConsultingInfo.Contactid", " ConsultingInfo.ReceptionTime  , ConsultingInfo.ClassLv ,UserInfo0.Username, ConsultingInfo.ConsultingTime, ConsultingInfo.ParentsCall, ConsultingInfo.Contact, CourseInfo.CourseName, ConsultingInfo.ChildrenSex, ConsultingInfo.Contactid, ConsultingInfo.ChildrenCall, ConsultingInfo.ChildrenAge, ConsultingInfo.School, ConsultingInfo.Remarks, ConsultingInfo.SignUp, ConsultingInfo.Courseid ,CSrelationship.Relationshipid ", " ConsultingInfo.Contactid=" + Key))
                {
                     read.Read();
                     this.chrildname.Text = read.GetString(7+1+1);
                     this.childsex.Text = read.GetString(5+1+1);
                     this.PhoneNumber.Text = read.GetString(3+1+1);
                     this.Age.Text = read.GetInt32(8+1+1).ToString();
                     this.ParentsCall.Text = read.GetString(2+1+1);
                     this.school_TextBox.Value = read.GetString(9+1+1);
                     this.Remark_TextBox.Text = read.GetString(10+1+1);
                     this.ClassLv.Text = read["ClassLv"] == DBNull.Value ? null : read.GetString(0+1);
                     this.Reception.Value = read["ReceptionTime"]==DBNull.Value? null:read.GetDateTime(0).ToString("yyyy-MM-dd");
                     Temp._Courseid = Key;
                 }
                SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " չ�����";
            }
            else if (Session["Command"].ToString() == "delete")
            {
                Session["ConfirmInfo"] = Key;
                Response.Redirect("Confirm.aspx?Command=delete");
            }
        }
        //Literal MeGTex = new Literal();
        //MeGTex.Text = "<script>alert('CommdMore');</script>";
        //Page.Controls.Add(MeGTex);



    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        Session["BackUp"] = this.GridView1.PageIndex;
        this.GridView1.DataSource = (DataTable)ViewState["ConsultingInfo_N"];
        this.GridView1.DataBind();
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        this.Add_button.Text = "���";
        if (Session["Command"] != null && Session["Command"].ToString() == "Edit")
        {
            this.Tips.Text = "ִ�������������ȡ���༭���ݲ���";
            this.Tips.Visible = true;
            Session["Command"] = "Stop";
        }
        else
        {
            this.Tips.Text = "��ǰ����:�������";
            this.Tips.Visible = true;
            this._GridView.Visible = false;
            this.moretable.Visible = false;
            this.addtable.Visible = true;
        }
    }
    protected void ClassInfo_Click(object sender, EventArgs e)
    {
        Response.Write("<script> window.open('ClassInfo.aspx')</script>");
    }
    protected void Edit_Click(object sender, EventArgs e)
    {
        Session["Command"] = "Edit";
        //this.GridView1.AutoGenerateSelectButton = true;
        Session["FeedBack"]= SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " �ỰCommand->Edit�Ѿ�����";
        Session["FeedBack"] += "#";
        this.GridView1.Columns[0].Visible = true;
        this._GridView.Visible = true;
        this.addtable.Visible = false;
        this.moretable.Visible = false;
        this.Tips.Text = "��ѡ��Ҫ�޸ĵ��ֶ�";
        this.Tips.Visible = true;
    }

    protected void Delete_Click(object sender, EventArgs e)
    {

        this.Tips.Text = "׼��ִ��ɾ������,��ѡ��Ҫɾ���ļ�¼";
        Session["Command"] = "delete";
        Session["FeedBack"]=SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " �ỰCommand->delete�Ѿ�����";
        Session["FeedBack"] += "#";
        this.GridView1.Columns[0].Visible = true;
        this._GridView.Visible = true;
        this.addtable.Visible = false;
        this.moretable.Visible = false;
        this.Tips.Visible = true;
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        this.Tips.Text = " ";
        this.moretable.Visible = false;
        this._GridView.Visible = true;
    }
    protected void About_Click(object sender, EventArgs e)
    {
        Literal MeGTex = new Literal();
        MeGTex.Text = "<script>alert('version 2.0 \\nMineRobot DateSource System\\nCode:Eris\\nNext time will be Update:\\nStudent management module;\\nOpen the internal forum;\\nSearch module');</script>";
        Page.Controls.Add(MeGTex);
    }


    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //SenderMessage().Text = DateTime.Now.ToString("hh��mm��ss") + " ���ڰ�ID";
    //    LinkButton btn1 = (LinkButton)e.Row.FindControl("More");
    //    LinkButton btn2 = (LinkButton)e.Row.FindControl("Select");
    //    if (btn1 != null && btn2 != null)
    //    {
    //        btn1.CommandArgument = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
    //        btn2.CommandArgument = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
    //    }
        
    //}
    protected void land_Click(object sender, EventArgs e)
    {
        Response.Redirect("land.aspx");
    }
   
    protected void Retrun_Click(object sender, EventArgs e)
    {
        this.addtable.Visible = false;
        this._GridView.Visible = true;
        this.chrildname.Text = null;
        this.childsex.Text = null;
        this.PhoneNumber.Text = null;
        this.Age.Text = null;
        this.ParentsCall.Text = null;
        this.school_TextBox.Value = null;
        this.Remark_TextBox.Text = null;
        Session["Command"] = null;
        SenderMessage().Text = System.DateTime.Now.ToString("hh��mm��ss") + " �ỰCommand->Edit�ѳ���";
        this.Tips.Text = "";
        this.GridView1.Columns[0].Visible = false;
    }
        
        //Session["UserInfo"] = null;
        //Session["TempInfo"] = null;
        //Session["Command"] = null;

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (GridView1.PageIndex == 0)
        {

            this.frontpage.Enabled = false;
            this.frontpage.ForeColor = System.Drawing.Color.Gray;

        }

        else
        {

            this.frontpage.Enabled = true;
            this.frontpage.ForeColor = System.Drawing.Color.Blue;

        }

        //ĩҳ��ҳ�밴ť����

        if (GridView1.PageIndex == GridView1.PageCount - 1)
        {
            this.nextpage.Enabled = false;
            this.nextpage.ForeColor = System.Drawing.Color.Gray;

        }

        else
        {
            this.nextpage.Enabled = true;
            this.nextpage.ForeColor = System.Drawing.Color.Blue;

        }

        //ҳ��Ϊ0����������

        if (GridView1.PageCount <= 0)
        {
            this.nextpage.Enabled = false;
            this.nextpage.ForeColor = System.Drawing.Color.Gray;
            this.frontpage.Enabled = false;
            this.frontpage.ForeColor = System.Drawing.Color.Gray;
        }

        //ҳ�������������

        if (this.pagecontrol != null)
        {

            this.pagecontrol.ClearSelection();

            this.pagecontrol.Items.Clear();

            for (int i = 0; i < GridView1.PageCount; i++)
            {

                int pageNumber = i + 1;

                ListItem item = new ListItem(pageNumber.ToString(), pageNumber.ToString());

                if (i == GridView1.PageIndex)
                {

                    item.Selected = true;

                }

                this.pagecontrol.Items.Add(item);

            }

        }
        this.Pagecount.Text=this.GridView1.PageIndex+1+"/"+ this.GridView1.PageCount;

    }
    protected void lestpage_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.GridView1.PageCount-1;
        Session["BackUp"] = this.GridView1.PageIndex;
        this.GridView1.DataSource = (DataTable)ViewState["ConsultingInfo_N"];
        this.GridView1.DataBind();
    }
    protected void firstpage_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = 0;
        this.GridView1.DataSource = (DataTable)ViewState["ConsultingInfo_N"];
        this.GridView1.DataBind();
    }
    protected void frontpage_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex -= 1; 
        Session["BackUp"] = this.GridView1.PageIndex;
        this.GridView1.DataSource = (DataTable)ViewState["ConsultingInfo_N"];
        this.GridView1.DataBind();
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex +=1; 
        Session["BackUp"] = this.GridView1.PageIndex;
        this.GridView1.DataSource = (DataTable)ViewState["ConsultingInfo_N"];
        this.GridView1.DataBind();
    }
    protected void pagecontrol_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = Convert.ToInt32(this.pagecontrol.SelectedValue) - 1;
        Session["BackUp"] = this.GridView1.PageIndex;
        this.GridView1.DataSource = (DataTable)ViewState["ConsultingInfo_N"];
        this.GridView1.DataBind();
    }
    MySqlDataReader Reception_All;
    protected void GridView1_Load(object sender, EventArgs e)
    {

        Info i = new Info();
        Reception_All = i.SelectCountUnit(" select "," ConsultingInfo "," ReceptionTime "," where 1>0 ");

    }
    protected void studentinfo_Click(object sender, EventArgs e)
    {
        Session["ToStudentsInfo"] = ViewState["ConsultingInfo_N"];
        Response.Redirect("StudentsInfo.aspx");
    }
}
