using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class DataSource : System.Web.UI.Page
{
    protected void hidealluntil()
    {
        this.Consultion_Gw.Visible = false;
        //this.TestInfo_Div.Visible = false;
        TestInfo.Visible = false;
        this.ClassInfo_Div.Visible = false;
        
    }

    protected void BindScene1()
    {
        hidealluntil();
        this.ClassInfo_Div.Visible = true;
        ViewState["ClassInfoDataScouce"] = new Diya().Gridviewbind(this.GridView1, "Select * From classinfo inner join CourseInfo on CourseInfo.Courseid=classinfo.Courseid where Classid!=" + 0+ " order by classinfo.OpenAnAccount desc");
    }

    protected void BindScene2()
    {
        this.TestSartTime.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00");
        this.TestEndTime.Value = System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59");
        hidealluntil();
        this.TestInfo.Visible = true;
        string selectComd = "select * from TestInfo where TestStartTime between '" + System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59") + "' Order By TestID DESC";
        ViewState["TestInfoDataScoure"] = new Diya().Gridviewbind(this.TestGw, selectComd);
        if (this.TestGw.PageCount == 0)
        {
            this.Title = "没有考试信息";
        }
    }

    protected void BindScene3()
    {
        hidealluntil();
        this.ClassInfo_Div.Visible = true;
        ViewState["ClassInfoDataScouce"] = new Diya().Gridviewbind(this.GridView1, "Select * From classinfo inner join CourseInfo on CourseInfo.Courseid=classinfo.Courseid where Classid!=" + 0+ " order by classinfo.OpenAnAccount desc");
    }

    protected void BindScene4()
    {
        hidealluntil();
        ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, "Select ChildrenCall,ParentsCall,Contact,Contactid from ConsultingInfo ");
        this.Consultion_Gw.Visible = true;
    }

    protected void BindScene5()
    {
        hidealluntil();
        ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, "Select ChildrenCall,ParentsCall,Contact,Contactid from ConsultingInfo ");
        this.Consultion_Gw.Visible = true;
    }

    protected void BindScene6()
    {
        this.TestSartTime.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00");
        this.TestEndTime.Value = System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59");
        hidealluntil();
        this.TestInfo.Visible = true;
        string selectComd = "select * from TestInfo where TestStartTime between '" + System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59") + "' Order By TestID DESC";
        ViewState["TestInfoDataScoure"] = new Diya().Gridviewbind(this.TestGw, selectComd);
        if (this.TestGw.PageCount == 0)
        {
            this.Title = "没有考试信息";
        }

    }
    protected void BindScene7()
    {
        this.TestSartTime.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00");
        this.TestEndTime.Value = System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59");
        hidealluntil();
        this.TestInfo.Visible = true;
        string selectComd = "select * from TestInfo where TestStartTime between '" + System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59") + "' Order By TestID DESC";
        ViewState["TestInfoDataScoure"] = new Diya().Gridviewbind(this.TestGw, selectComd);
        if (this.TestGw.PageCount == 0)
        {
            this.Title = "没有考试信息";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //ViewState=Consultion_Info
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
            {
                if (Request.Cookies["UserConfig"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    HttpCookie cookie = Request.Cookies["UserConfig"];
                    Diya diya = new Diya();
                    Session["UserInfo"] = Server.HtmlEncode(diya.GetDESDecrypt(cookie.Value));
                }
            }
            if (Session["TheScene"] != null)
            {
                switch (Convert.ToInt32(Session["TheScene"].ToString()))
                {
                    case 1: BindScene1();
                        break;
                    case 2: BindScene2();
                        break;
                    case 3: BindScene3();
                        break;
                    case 4: BindScene4();
                        break;
                    case 5: BindScene5();
                        break;
                    case 6: BindScene6();
                        break;
                    case 7: BindScene7();
                        break;
                    default:
                        break;
                }
                Session["TheScene"] = null;
            }
            string[] Info = Session["UserInfo"].ToString().Split(new char[] { '#' });
            Diya.GetUserInfo(Convert.ToInt32(Info[0]), Info[1], Info[2]);
            this.landinfo.Text = Info[2];
            ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, "Select ChildrenCall,ParentsCall,Contact,Contactid from ConsultingInfo ");
            if (this.ClassInfo != null)
            {
                ClassInfo.ClearSelection();
                ClassInfo.Items.Clear();
            }
            ListItem item = new ListItem("全部班级", "0");
            item.Selected = true;
            MySqlDataReader read =new Diya().RowReader("Select ClassID,ClassName From classinfo order by ClassID asc");
            while (read.Read())
            {
                item = new ListItem(read["ClassName"].ToString(),read["ClassID"].ToString());
                this.ClassInfo.Items.Add(item);
            }

        }
    }



    DataStates Dst_id = new DataStates();



    protected void ChecekChanged(object sender, EventArgs e)
    {
        
        CheckBox checkbox = sender as CheckBox;
        if (checkbox.Checked)
        {   string id = checkbox.Text;
            Dst_id.Addstate(id);
        }
        else
        {
            Dst_id.DeleteOneData(checkbox.Text);
        }
    }

    protected void Consul_Add_button_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditConsluting.aspx?Mode=Add");
    }
    protected void Consul_Edit_button_Click(object sender, EventArgs e)
    {
        //Session["ConsulEditID"]=
        hidealluntil();
        this.Consultion_Gw.Visible = true;
        this.Consultion.Columns[0].Visible = true;
        ViewState["EditInfo"] = "edit";
    }
    protected void Consultion_button_Click(object sender, EventArgs e)
    {
        hidealluntil();
        this.Consultion_Gw.Visible = true;
    }
    protected void First_Page_C_Click(object sender, EventArgs e)
    {
        this.Consultion.PageIndex = 0;
        this.Consultion.DataSource = ViewState["Consultion_Info"];
        this.Consultion.DataBind();
    }
    protected void Front_page_C_Click(object sender, EventArgs e)
    {
        this.Consultion.PageIndex -= 1;
        this.Consultion.DataSource = ViewState["Consultion_Info"];
        this.Consultion.DataBind();
    }
    protected void Next_Page_C_Click(object sender, EventArgs e)
    {
        this.Consultion.PageIndex += 1;
        this.Consultion.DataSource = ViewState["Consultion_Info"];
        this.Consultion.DataBind();
    }
    protected void Last_Page_C_Click(object sender, EventArgs e)
    {
        this.Consultion.PageIndex = this.Consultion.PageCount - 1;
        this.Consultion.DataSource=ViewState["Consultion_Info"];
        this.Consultion.DataBind();
    }
    protected void Consultion_DataBound(object sender, EventArgs e)
    {
        
        if (this.PageControl != null)
        {
            this.PageControl.ClearSelection();
            this.PageControl.Items.Clear();
        }
        for (int i = 0; i < this.Consultion.PageCount; i++)
        {
            ListItem item = new ListItem(Convert.ToString(i+1),Convert.ToString(i));
            if (this.Consultion.PageIndex == i)
            {
                item.Selected = true;
            }
            this.PageControl.Items.Add(item);
        }
        if (this.Consultion.PageIndex == 0)
        {
            this.Front_page_C.Enabled = false;
            this.Front_page_C.ForeColor = System.Drawing.Color.Gray;
        }
        else
        {
            this.Front_page_C.Enabled = true;
            this.Front_page_C.ForeColor = System.Drawing.Color.White;
        }
         if(this.Consultion.PageIndex==this.Consultion.PageCount-1)
        {
         
            this.Next_Page_C.Enabled = false;
            this.Next_Page_C.ForeColor = System.Drawing.Color.Gray;
            
        }
        else
        {
            this.Next_Page_C.Enabled = true;
           
            
            this.Next_Page_C.ForeColor = System.Drawing.Color.White;
        }
        this.PageCount.Text=(Consultion.PageIndex+1)+"/"+Consultion.PageCount;
    }
    protected void PageControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Consultion.PageIndex = Convert.ToInt32(this.PageControl.SelectedValue);
        this.Consultion.DataSource = ViewState["Consultion_Info"];
        this.Consultion.DataBind();
    }
    protected void Consultion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            if (e.CommandName == "More")
            {
                LinkButton lb = this.Consultion.Rows[Convert.ToInt32(e.CommandArgument.ToString())].FindControl("Lb1") as LinkButton;
                lb.Text = lb.Text == "+" ? "-" : "+";

                this.Consultion.Rows[Convert.ToInt32(e.CommandArgument.ToString())].FindControl("test1").Visible = lb.Text == "+" ? false : true;
            }
            else if (e.CommandName == "select")
            {

            }
            else if (e.CommandName == "HistoryTest")
            {
                Session["Contactid_S"] = e.CommandArgument;
                Response.Redirect("History_Test.aspx");
            }
            else if (e.CommandName == "RemoveClass")
            {
                this.Consultion.Columns[1].Visible = false;
                string DeleteCommand = "Delete From CSrelationship where Contactid=" + e.CommandArgument.ToString()+" and Classid="+ClassInfo.SelectedValue ;
                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                {
                    Sc.Open();
                    MySqlTransaction Stransaction = Sc.BeginTransaction();
                    MySqlCommand Scmd = new MySqlCommand();
                    Scmd.Transaction = Stransaction;
                    Scmd.Connection = Sc;
                    try
                    {                        
                        Scmd.CommandText = DeleteCommand;
                        Scmd.ExecuteNonQuery();
                        Stransaction.Commit();
                    }
                    catch (Exception)
                    {
                        Stransaction.Rollback();
                    }
                    string SelectCmd = "Select * From ConsultingInfo ";
                    SelectCmd += " inner join CSrelationship on CSrelationship.Contactid=ConsultingInfo.Contactid where CSrelationship.Classid!=0 and CSrelationship.Classid=" + this.ClassInfo.SelectedValue;
                    ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, SelectCmd);

                }
            }
        }
    }
    protected void Consultion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void Con_Com_Click(object sender, EventArgs e)
    {
        if (this.templet.Value != "")
        {
            string[] contactid = this.templet.Value.Split(new char[] { '#' });
            for (int i = 0; i < contactid.Length - 1; i++)
            {
                string deletecommand = "Delete  from ConsultingInfo where Contactid=" + contactid[i];
                using (MySqlConnection sc = new MySqlConnection(Diya.ConectionString))
                {
                    sc.Open();
                    MySqlCommand cmd = new MySqlCommand(deletecommand, sc);
                    Literal MESText = new Literal();
                    MESText.Text = "<script> alert('" + cmd.ExecuteNonQuery() + "条记录受到影响');</script>";
                    Page.Controls.Add(MESText);

                }
            }
        }
        else
        {

        }
    }
    protected void Consule_Delete_button_Click(object sender, EventArgs e)
    {
        this.Consultion.Columns[0].Visible = true;
        ViewState["EditInfo"] = "Delete";
    }
    protected void Consultion_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void Search_Button_Click(object sender, EventArgs e)
    {

    }

    protected void SutdentInfo_button_Click(object sender, EventArgs e)//测验信息
    {
        this.TestSartTime.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00");
        this.TestEndTime.Value = System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59");
        hidealluntil();
        this.TestInfo.Visible = true;
        string selectComd = "select * from TestInfo where TestStartTime between '" + System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00") + "' and '" + System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59")+"' Order By TestID DESC";
        ViewState["TestInfoDataScoure"] =new Diya().Gridviewbind(this.TestGw,selectComd);
       if( this.TestGw.PageCount == 0)
       {
           this.Title = "没有考试信息";
       }
    }

    protected void Consul_MoveTo_button_Click(object sender, EventArgs e)
    {

    }
    protected void Consultion_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void Consultion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label idlable = e.Row.FindControl("IDBound") as Label;
        //    GridView gwitem = e.Row.FindControl("Gvitem") as GridView;
        //    string itemselectcmd = "select ChildrenSex,ChildrenAge,School,Remarks,ClassLv,ConsultingTime from ConsultingInfoRecavery where Contactid='" + idlable.Text + "'";
        //    Diya.Gridviewbind(gwitem,itemselectcmd);
        //}
    }
    protected void ClassInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SelectCmd = "Select * From ConsultingInfo ";
        if (this.ClassInfo.SelectedIndex == 0)
        {
            ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, SelectCmd);
            this.Consultion.Columns[1].Visible = false;
        }
        else
        {
            SelectCmd += " inner join CSrelationship on CSrelationship.Contactid=ConsultingInfo.Contactid where CSrelationship.Classid!=0 and CSrelationship.Classid="+this.ClassInfo.SelectedValue;
            ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, SelectCmd);
            this.Consultion.Columns[1].Visible = true;
        }
        hidealluntil();
        this.Consultion_Gw.Visible = true;
    }
 
    protected void StudentInfo_Edit_button_Click(object sender, EventArgs e)// 分配班级
    {
        this.TestGw.Columns[0].Visible = true;
        ViewState["TestCommand"] = "SelectClass";
        //object id = Dst_id.Read();

        //if (id == null)
        //{
        //    Literal Mess = new Literal();
        //    Mess.Text = "<script>alert('请先选择考试信息')</script>";
        //    Page.Controls.Add(Mess);
        //}
        //else
        //{
        //    string idlist = "";
        //    while (id != null)
        //    {
        //        idlist += id + "#";
        //        id = Dst_id.Read();
        //    }
        //    Dst_id.Clear();
        //    Response.Redirect("DistributionOfTheClass.aspx?Test=" + idlist);
        //}
    }
    protected void StudentInfo_Move_button_Click(object sender, EventArgs e)
    {
        this.TestGw.Columns[0].Visible = true;
        ViewState["TestCommand"] = "DeleteTestInfo";
        //object id = Dst_id.Read();
        //if (id == null)
        //{
        //    Literal Mess = new Literal();
        //    Mess.Text = "<script>alert('请先选择考试信息')</script>";
        //    Page.Controls.Add(Mess);
        //}
        //else
        //{
        //    while(id!=null)
        //    {

        //    }
        //}
    }

    protected void linkbutton_Click(object sender, EventArgs e)
    {
        if (ViewState["EditInfo"].ToString() == "edit")
        {
            LinkButton linb = sender as LinkButton;
            string url = "EditConsluting.aspx?Mode=Edit";
            Session["ConEditInfo"] =linb.CommandArgument.ToString();
            Response.Redirect(url);
        }
        else if(ViewState["EditInfo"].ToString()=="Delete")
        {
            LinkButton linb = sender as LinkButton;
            using(MySqlConnection Sc=new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                MySqlCommand Scmd = new MySqlCommand("delete From ConsultingInfo where Contactid="+linb.CommandArgument,Sc);
                Scmd.ExecuteNonQuery();
                ViewState["Consultion_Info"] = new Diya().Gridviewbind(this.Consultion, "Select ChildrenCall,ParentsCall,Contact,Contactid from ConsultingInfo ");
                this.Consultion.Columns[0].Visible = false;
            }
        }
    }
    protected void ClassInfo_edit_button_Click(object sender, EventArgs e)
    {
        this.GridView1.Columns[0].Visible = true;
        this.GridView1.Columns[1].Visible = false;
    }
    protected void ClassInfo_add_button_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditClassInfo.aspx?Mode=Add");
    }
    protected void ClassInfo_delete_button_Click(object sender, EventArgs e)
    {
        this.GridView1.Columns[0].Visible = false;
        this.GridView1.Columns[1].Visible = true;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            this.GridView1.Columns[0].Visible = false;
            if (ViewState["AddStudent"] != null)
            {
                ViewState["AddStudent"] = null;
                Session["ClassID_A"] = e.CommandArgument;
                Response.Redirect("AllocationStudent.aspx");
            }
            else
            {
                Session["ClassInfo_id"] = e.CommandArgument;
                Response.Redirect("EditClassInfo.aspx?Mode=Edit");
            }
        }
        else if (e.CommandName == "Delete")
        {
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string DelCmd = "Delete From CSrelationship where Classid="+e.CommandArgument;
                MySqlCommand Scmd = new MySqlCommand(DelCmd, Sc);
                Scmd.ExecuteNonQuery();
            }
            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
            {
                Sc.Open();
                string DelCmd = "Delete From classinfo where Classid="+e.CommandArgument;
                MySqlCommand Scmd = new MySqlCommand(DelCmd,Sc);
                Scmd.ExecuteNonQuery();
            }
            hidealluntil();
            this.ClassInfo_Div.Visible = true;
            ViewState["ClassInfoDataScouce"] = new Diya().Gridviewbind(this.GridView1, "Select * From classinfo inner join CourseInfo on CourseInfo.Courseid=classinfo.Courseid where Classid!=" + 0);
            this.ClassInfo.ClearSelection();
            this.ClassInfo.Items.Clear();
            ListItem item = new ListItem("全部班级", "0");
            item.Selected = true;
            using (MySqlDataReader read =new Diya().RowReader("Select ClassID,ClassName From classinfo order by ClassID asc"))
            {
                while (read.Read())
                {
                    item = new ListItem(read["ClassName"].ToString(), read["ClassID"].ToString());
                    this.ClassInfo.Items.Add(item);
                }
            }
        }
    }
    protected void AddTestInfo_button_Click(object sender, EventArgs e)
    {
        Response.Redirect("TryToPreview.aspx");
    }

    protected void TestGw_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName!="Page")
        {
        this.TestGw.Columns[0].Visible = false;
        if (e.CommandName == "Edit")
        {
            this.TestGw.Columns[3].Visible = false;
            this.TestGw.Columns[2].Visible = true;
        }
        else if (e.CommandName == "More")
        {
            Session["TestID"] = e.CommandArgument;
            Session["TSRelationshipID"] = 0;
            Response.Redirect("TestInfo_detailed.aspx");
        }
        else if (e.CommandName == "Update")
        {
            Session["TestID_Up"] = e.CommandArgument;
            Response.Redirect("TestInfo.aspx?Mode=Up");
        }
        else
        {

            if (ViewState["TestCommand"] != null)
            {
                if (ViewState["TestCommand"].ToString() == "SelectClass")
                {
                    ViewState["TestCommand"] = null;
                    Response.Redirect("DistributionOfTheClass.aspx?Test=" + e.CommandArgument + "#");
                }
                //else if (ViewState["TestCommand"].ToString() == "DeleteTestInfo")
                //{
                //    ViewState["TestCommand"] = null;
                //    using (MySqlDataReader read = Diya.RowReader("Select RelationshipID from TTRelationship where TestID=" + e.CommandArgument))
                //    {
                //        while (read.Read())
                //        {
                //            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                //            {
                //                Sc.Open();
                //                MySqlCommand Scmd = new MySqlCommand("delete From OTRelationship where TTRelationshipID=" + read["RelationshipID"], Sc);
                //                Scmd.ExecuteNonQuery();
                //            }
                //        }
                //    }
                //    using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                //    {
                //        Sc.Open();
                //        MySqlCommand Scmd = new MySqlCommand("delete From TTRelationship where TestID=" + e.CommandArgument, Sc);
                //        Scmd.ExecuteNonQuery();
                //    }

                //    using (MySqlDataReader read = Diya.RowReader("Select RelationshipID from TSRelationship where TestID="+e.CommandArgument))
                //    {
                //        while (read.Read())
                //        {
                //            using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                //            {
                //                Sc.Open();
                //                MySqlCommand Scmd = new MySqlCommand("delete from HTRelationship where TSRelationshipID="+read.GetInt32(0), Sc);
                //                Scmd.ExecuteNonQuery();
                //            }
                //        }
                //    }
                //    using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                //    {
                //        Sc.Open();
                //        MySqlCommand Scmd = new MySqlCommand("delete TSRelationship where TestID=" + e.CommandArgument, Sc);
                //        Scmd.ExecuteNonQuery();
                //    }
                //    using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                //    {
                //        Sc.Open();
                //        MySqlCommand Scmd = new MySqlCommand("delete from TestInfo where TestID=" + e.CommandArgument, Sc);
                //        Scmd.ExecuteNonQuery();
                //    }
                //}
            }
        }

        }
       
        string selectComd = "select * from TestInfo order by TestID DESC";
        new Diya().Gridviewbind(this.TestGw, selectComd);
        if (this.TestGw.PageCount == 0)
        {
            this.Title = "没有考试信息";
        }
    }
    protected void ClassInfo_button_Click(object sender, EventArgs e)
    {
        hidealluntil();
        this.ClassInfo_Div.Visible = true;
        ViewState["ClassInfoDataScouce"] = new Diya().Gridviewbind(this.GridView1, "Select * From classinfo inner join CourseInfo on CourseInfo.Courseid=classinfo.Courseid where Classid!="+0 + " order by classinfo.OpenAnAccount desc");

    }
    protected void TestGw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.TestGw.PageIndex = e.NewPageIndex;
        this.TestGw.DataSource =(System.Data.DataTable)ViewState["TestInfoDataScoure"];
        this.TestGw.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataSource = (System.Data.DataTable)ViewState["ClassInfoDataScouce"];
        this.GridView1.DataBind();
    }

    protected void TestGw_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.TestGw.EditIndex = e.NewEditIndex;
        this.TestGw.DataBind();
    }
    protected void TestGw_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlInputText TestStartTime = (System.Web.UI.HtmlControls.HtmlInputText)this.TestGw.Rows[e.RowIndex].FindControl("TestStartTime");
        System.Web.UI.HtmlControls.HtmlInputText TestEndTime = (System.Web.UI.HtmlControls.HtmlInputText)this.TestGw.Rows[e.RowIndex].FindControl("TestEndTime");
        Label id = (Label)this.TestGw.Rows[e.RowIndex].FindControl("TestID");
        using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
        {
            Sc.Open();
            string updatestring="Update TestInfo Set TestStartTime='" + TestStartTime.Value + "',TestEndTime='"+TestEndTime.Value+"' where TestID="+id.Text;
            MySqlCommand Scmd = new MySqlCommand(updatestring, Sc);
            Scmd.ExecuteNonQuery();
        }
        using (MySqlDataReader read = new Diya().RowReader("select ContactID From TSRelationship where TestID="+id.Text))
        {
            while (read.Read())
            {
                using (MySqlConnection Scin = new MySqlConnection(Diya.ConectionString))
                {
                    Scin.Open();
                    MySqlCommand Scmd = new MySqlCommand("insert into TSRelationship(TestID,ContactID,Score)Values("+id.Text+","+read["ContactID"]+","+"null)", Scin);
                    Scmd.ExecuteNonQuery();
                }
            }
        }
        
    }
    protected void TestGw_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
        
    }
    protected void ClassInfo_add_student_button_Click(object sender, EventArgs e)
    {
        hidealluntil();
        this.ClassInfo_Div.Visible = true;
        this.GridView1.Columns[0].Visible = true;
        ViewState["AddStudent"] = 1;
    }
    protected void Questions_button_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void Consultion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void TestGw_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
        }
        catch(Exception)
        {

        }
        Response.Redirect("Login.aspx");
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        //this.TestSartTime.Value = System.DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        //this.TestEndTime.Value = System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd 23:59:59");
        hidealluntil();
        this.TestInfo.Visible = true;
        string selectComd = "select * from TestInfo where TestStartTime between '" + this.TestSartTime.Value + "' and '" + TestEndTime.Value + "' Order By TestID DESC";
        ViewState["TestInfoDataScoure"] = new Diya().Gridviewbind(this.TestGw, selectComd);
        if (this.TestGw.PageCount == 0)
        {
            this.Title = "没有考试信息";
        }
    }
}                         