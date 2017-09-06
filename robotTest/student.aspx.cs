using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SqlDataSource1.ConnectionString = Info.datasource;
        this.SqlDataSource2.ConnectionString = Info.datasource;
        this.SqlDataSource3.ConnectionString = Info.datasource;
        this.LinkButton2.Text = "返回主页";
        if (!IsPostBack)
        {
            if (Session["UserInfo"]== null)
            {
                Response.Redirect("land.aspx");
            }
            //HttpCookie cookie = Request.Cookies["UserInfo"];
            if (Session["UserInfo"].ToString() != "")
            {
                string[] Data = Session["UserInfo"].ToString().Split(new char[] { '#' });
                Info.userid = Data[0];
                Info.uername = Data[1];
                Info.usertype = Convert.ToInt32(Data[2]);
            }
            GridView1.DataKeyNames = new string[] { "Contactid", "Relationshipid" };
            ViewState["data"] = (DataTable)Info.Gridviewbind(this.GridView1, Selectstr).Tables[0];
            Session["Command"] = Selectstr;
        }
      classcommand = this.SqlDataSource2.SelectCommand;
      
     }
    //
    private string Selectstr = "SELECT classinfo.Classid, classinfo.ClassName, classinfo.Courseid, CourseInfo.CourseName, ConsultingInfo.ParentsCall, ConsultingInfo.ChildrenCall, ConsultingInfo.Contact, ConsultingInfo.ChildrenAge, ConsultingInfo.ChildrenSex, ConsultingInfo.Remarks, ConsultingInfo.School, ConsultingInfo.SignUp, CSrelationship.Registrarion, CSrelationship.Relationshipid, ConsultingInfo.Contactid, CSrelationship.Payment FROM classinfo INNER JOIN CourseInfo ON classinfo.Courseid = CourseInfo.Courseid INNER JOIN CSrelationship ON classinfo.Classid = CSrelationship.Classid INNER JOIN ConsultingInfo ON CSrelationship.Contactid = ConsultingInfo.Contactid WHERE (ConsultingInfo.SignUp = 1 And CSrelationship.Classid!=0)";
    //private string sch = "SELECT classinfo.Classid, classinfo.ClassName, classinfo.Courseid, CourseInfo.CourseName, ConsultingInfo.ParentsCall, ConsultingInfo.ChildrenCall, ConsultingInfo.Contact, ConsultingInfo.ChildrenAge, ConsultingInfo.ChildrenSex, ConsultingInfo.Remarks, ConsultingInfo.School, ConsultingInfo.SignUp, ConsultingInfo.Registrarion, CSrelationship.Relationshipid, ConsultingInfo.Contactid FROM classinfo,ConsultingInfo,CourseInfo,CSrelationship Where (CSrelationship.Classid=classinfo.Classid And CSrelationship.Contactid=ConsultingInfo.Contactid And CourseInfo.Courseid=ConsultingInfo.Courseid) or (ConsultingInfo.Courseid=CourseInfo.Courseid)";
    private string sch = "SELECT classinfo.Classid, classinfo.ClassName, classinfo.Courseid, CourseInfo.CourseName, ConsultingInfo.ParentsCall, ConsultingInfo.ChildrenCall, ConsultingInfo.Contact, ConsultingInfo.ChildrenAge, ConsultingInfo.ChildrenSex, ConsultingInfo.Remarks, ConsultingInfo.School, ConsultingInfo.SignUp, CSrelationship.Registrarion, CSrelationship.Relationshipid, ConsultingInfo.Contactid,CSrelationship.Payment FROM classinfo INNER JOIN CourseInfo ON classinfo.Courseid = CourseInfo.Courseid INNER JOIN CSrelationship ON classinfo.Classid = CSrelationship.Classid INNER JOIN ConsultingInfo ON CSrelationship.Contactid = ConsultingInfo.Contactid";
    //

    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string error = null;
        if(!Info.checktext("PhoneNumber",this.Contactadd.Text))
        {
            error += "电话号码非法!";
        }
        if(!Info.checktext("N",this.ChildrenAge.Text))
        {
            error += "年龄必须是数字!";
        }
        if (!Info.checktext("N", this.Payment.Text))
        {
            error += "价格仅能为数字!";
        }
        if (this.ChildrenCall.Text == "")
        {
            error += "学生必须要有名字!";
        }
        if (this.ChildrenAge.Text == "")
        {
            error += "就算不知道几岁也要猜一个啊!";
        }
        if (this.ChildrenSex.SelectedValue == "")
        {
            error += "作为一个人类能没有性别么?";
        }
        if (error != null)
        {
            this.ErrorLab.Text = error;
            this.ErrorLab.Visible = true;
        }
        else
        {
            Info i = new Info();
            string id = System.DateTime.Today.ToString("yyMM") + "0001";
            using (MySqlDataReader read = i.SelectCountUnit("select", " ConsultingInfo ", " Contactid ", "  Contactid=(Select Max(Contactid) From ConsultingInfo)"))
            {
                if (read.Read())
                {
                    int temp = Convert.ToInt32(id);
                    temp += 1;
                    id = Convert.ToString(temp);
                }
                read.Close();
            }
            Info.InsertUpdateUnit("Insert Into ConsultingInfo(Contactid,Userid,ConsultingTime,ChildrenCall,ParentsCall,Contact,ChildrenAge,ChildrenSex,Courseid,School,SignUp) values(" + id + ",'" + Info.userid + "','" + System.DateTime.Today.ToShortDateString() + "','" + this.ChildrenCall.Text + "','" + this.ParentsCall.Text + "','" + this.Contactadd.Text + "','" + this.ChildrenAge.Text + "','" + this.ChildrenSex.SelectedItem.Text + "','" + this.Course.SelectedItem.Value + "','" + School.Text + "',1)");
            Info.InsertUpdateUnit("Insert Into CSrelationship(Classid,Contactid,Payment,Registrarion) values(" + this.Class.SelectedItem.Value + "," + id + "," + this.Payment.Text + ",'" + System.DateTime.Today.ToShortDateString() + "')");
            //Info.InsertUpdateUnit("Update classinfo Set RemainingNumber=RemainingNumber-1 Where Classid="+this.Class.SelectedValue+"");
            Response.AddHeader("Refresh", "0");
        }
    }
    protected void Contactadd_TextChanged(object sender, EventArgs e)
    {
        sch += " And  ConsultingInfo.Contact = '" + this.Contactadd.Text + "'";
        Session["Command"] = sch;
        using (MySqlDataReader read = new Info().FindData(sch))
        {
            if (read.Read())
            {
                this.Button1.Enabled = false;
                this.Button1.BackColor = System.Drawing.Color.Gray;
            }
            read.Close();
        }
       ViewState["data"]= (DataTable)Info.Gridviewbind(this.GridView1, sch).Tables[0];
    }
    protected void ChildrenCall_TextChanged(object sender, EventArgs e)
    {
        sch += " And ConsultingInfo.ChildrenCall Like '%" + this.ChildrenCall.Text + "%'";
        Session["Command"] = sch;
        ViewState["data"] = (DataTable)Info.Gridviewbind(this.GridView1, sch).Tables[0];
    }
    protected void ParentsCall_TextChanged(object sender, EventArgs e)
    {
        sch += " And ConsultingInfo.ParentsCall Like '%" + this.ParentsCall.Text + "%'";
        ViewState["data"] = (DataTable)Info.Gridviewbind(this.GridView1, sch).Tables[0];
        Session["Command"]= sch;
    }
    private string classcommand;
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //command_0 = Selectstr + " ORDER BY ConsultingInfo.Contactid DESC";
        //Session["Command"] = command_0;
        //Info.Gridviewbind(this.GridView1, command_0);
        Response.Redirect("student.aspx");
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SqlDataSource3.SelectCommand = classcommand + " where Courseid=" + this.DropDownList5.SelectedValue + "";
        this.DropDownList6.DataBind();
        //command0 = SqlDataSource3.SelectCommand;
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cmd= Selectstr + " And CSrelationship.Classid=" + this.DropDownList6.SelectedValue + "";
        Session["Command"] = cmd;
        Info.Gridviewbind(this.GridView1, cmd);
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = ((DropDownList)GridView1.FindControl("DropDownList7")).SelectedValue;
        this.SqlDataSource2.SelectCommand = classcommand + " where Courseid="+str+"";
        ((DropDownList)GridView1.FindControl("DorpDownList4")).DataBind();
    }
    protected void Course_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SqlDataSource2.SelectCommand =classcommand+ " where Courseid=" + this.Course.SelectedValue + "";
        this.Class.DataBind();
    }
    protected void CsInfoIndexChanged(object sender, EventArgs e)
    {
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //using (MySqlConnection s = new MySqlConnection(Info.datasource))
        //{
        //    MySqlDataAdapter da = new MySqlDataAdapter("Select ClassName,Classid From classinfo Where Courseid=" + ((DropDownList)this.GridView1.FindControl("DropDownList7")).SelectedValue + "", s);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    DropDownList dl = ((DropDownList)this.GridView1.FindControl("DropDownList4"));
        //    ((DropDownList)this.GridView1.FindControl("DropDownList4")).DataSource = ds;
        //    dl.DataTextField = "ClassName";
        //    dl.DataValueField = "Classid";
        //    dl.DataBind();

        //}
        //((SqlDataSource)this.GridView1.FindControl("SqlDataSource0")).SelectCommand += "Where Classid=" + ((DropDownList)this.GridView1.FindControl("DropDownList7")).SelectedValue + "";
        //((DropDownList)this.GridView1.FindControl("DropDownList4")).DataBind();
        //((SqlDataSource)this.GridView1.FindControl("SqlDataSource0")).ConnectionString = Info.datasource;
        
        string Cid = this.GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string CSid = this.GridView1.DataKeys[e.RowIndex].Values[1].ToString();
        //string Contactid = ((DropDownList)this.GridView1.Rows[e.RowIndex].FindControl("DorpDownList4")).SelectedValue;
        string ChildrenCall = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string ParentsCall = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
        string Contact = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[1]).Text;
        string Age = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[4].Controls[1]).Text;
        string Sex = ((DropDownList)this.GridView1.Rows[e.RowIndex].Cells[5].Controls[1]).SelectedItem.Text;
        string School = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
        string Courseid = ((DropDownList)this.GridView1.Rows[e.RowIndex].FindControl("DropDownList7")).SelectedValue;
        string Classid = ((DropDownList)this.GridView1.Rows[e.RowIndex].FindControl("DropDownList4")).SelectedValue;
        string Signedup = ((DropDownList)this.GridView1.Rows[e.RowIndex].FindControl("DropDownList2")).SelectedValue;
        string Remarks = ((TextBox)this.GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        string PayMent = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[11].Controls[0]).Text;
        string time = ((HtmlInputControl)this.GridView1.Rows[e.RowIndex].FindControl("input1")).Value ;
        //
        //
        //
        if (time == "")
        {
            time = "null";
        }
        else
        {
            time = "'" + time + "'";
        }
        string updateContactstr = "Update ConsultingInfo SET ChildrenCall='"+ChildrenCall+"', ParentsCall='"+ParentsCall+"',Contact='"+Contact+"', ChildrenAge="+Age+", ChildrenSex='"+Sex+"',School='"+School+"',Courseid="+Courseid+",SignUp="+Signedup+",Remarks='"+Remarks+"' Where Contactid="+Cid+"";
        if (PayMent == "")
            PayMent = "null";
        string updateCSrelationshipstr;
        if (Temp._Courseid == Courseid)
        {
            updateCSrelationshipstr = "UPDATE CSrelationship SET Classid=" + Classid + ",Payment=" + PayMent + ",Registrarion=" + time + " Where Relationshipid=" + CSid;
        }
        else
        {
            updateCSrelationshipstr = "Insert INTO CSrelationship(Classid,Payment,Contactid,Registrarion) Values (" + Classid + "," + PayMent + "," + Cid + "," + time + ")";
        }
        Info.InsertUpdateUnit(updateContactstr);
        Info.InsertUpdateUnit(updateCSrelationshipstr);
        //if (Signedup == "0")
        //{
        //    Info.InsertUpdateUnit("Update classinfo Set RemainingNumber=RemainningNumber+1 Where Classid="+Classid+"");
        //}
        this.GridView1.EditIndex = -1;
        Response.Redirect("student.aspx");
    }
    //新增加代码
    //
    private void SortExprssion()
    {
        GridView1.Columns[8].SortExpression = GridView1.Columns[8].HeaderText.ToString();
    }
    private void SetGridView()
    {
        GridView1.AllowPaging = true;
        GridView1.AllowSorting = true;
    }
    //private void BindGridView()
    //{
    //    string QueryCon = "SELECT classinfo.Classid, classinfo.ClassName, CSrelationship.Classid AS Expr1, CSrelationship.Contactid, CSrelationship.Relationshipid, ConsultingInfo.Contactid AS Expr2, ConsultingInfo.Userid, ConsultingInfo.ChildrenCall, ConsultingInfo.ParentsCall, ConsultingInfo.Contact, ConsultingInfo.ChildrenAge, ConsultingInfo.ChildrenSex, ConsultingInfo.Courseid, ConsultingInfo.School, ConsultingInfo.Remarks, ConsultingInfo.SignUp, ConsultingInfo.Registrarion, CourseInfo.Courseid AS Expr3, CourseInfo.CourseName FROM classinfo INNER JOIN CourseInfo ON classinfo.Courseid = CourseInfo.Courseid INNER JOIN ConsultingInfo ON CourseInfo.Courseid = ConsultingInfo.Courseid INNER JOIN CSrelationship ON classinfo.Classid = CSrelationship.Classid AND ConsultingInfo.Contactid = CSrelationship.Contactid WHERE (ConsultingInfo.SignUp = 1)";
    //    using (MySqlConnection NorthWindCon = new MySqlConnection(Info.datasource))
    //    {
    //        MySqlDataAdapter NorthWindDa = new MySqlDataAdapter(QueryCon, NorthWindCon);
    //        DataSet Ds = new DataSet();
    //        NorthWindDa.Fill(Ds, "ConsultingInfo");
    //        GridView1.DataKeyNames = new string[] { "Contactid","Relationsthipid" };
    //        DataView Dv = Ds.Tables["ConsultingInfo"].DefaultView;
    //        //排序表达式
    //        //string SortExpress = (string)ViewState["ChildrenCall"] + " " + (string)ViewState["Contactid"];
    //        //Dv.Sort = SortExpress;
    //        //GridView1.DataSource = Ds.Tables["Suppliers"];
    //        //绑定数据源
    //        GridView1.DataSource = Dv;
    //        GridView1.DataBind();
    //    }
    //}
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

        if (GridView1.EditIndex != -1)
        {
            e.Cancel = true;
            Literal TxtMsg = new Literal();
            TxtMsg.Text = "<script>alert('编辑模式下禁止换行')</script>";
            Page.Controls.Add(TxtMsg);
        }
        else
        {
            GridView1.EditIndex = e.NewEditIndex;
            ViewState["data"] = (DataTable)Info.Gridviewbind(this.GridView1, Session["Command"].ToString()).Tables[0];
            Temp._Courseid = ((DropDownList)this.GridView1.Rows[e.NewEditIndex].FindControl("DropDownList4")).SelectedValue;
           //((SqlDataSource)this.GridView1.Rows[e.NewEditIndex].FindControl("SqlDataSource0")).ConnectionString = Info.datasource;

           
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        this.GridView1.DataSource = (DataTable)ViewState["data"];
        this.GridView1.DataBind();
    }

    protected void DropDownList7_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ((SqlDataSource)this.GridView1.Rows[GridView1.EditIndex].FindControl("SqlDataSource0")).SelectCommand += "Where Classid=" + ((DropDownList)this.GridView1.Rows[GridView1.EditIndex].FindControl("DropDownList7")).SelectedValue + "";
        ((DropDownList)this.GridView1.Rows[GridView1.EditIndex].FindControl("DropDownList4")).DataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("student.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Welcom.aspx");
    }
}