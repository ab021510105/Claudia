using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected static string Quiz_Table_B = "";
    protected void  hidealluntile()
    {
        this.TitaPager.Visible = false;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            hidealluntile();
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Consultion.aspx");
            }
            if (Session["DataScoure_TIA"] == null)
            {
                ViewState["PageIndex_Q"] = 0;
                TIAT tiat = new TIAT();
                tiat.Dst.Clear();
                Quiz_Table_B = tiat.Quizeloader(Session["TestID"].ToString(), 2, 0 + 1, Session["TSRelationshipID"].ToString());
                QuizabelDataBound(tiat);
                using (MySql.Data.MySqlClient.MySqlDataReader read = new Diya().RowReader("select * from TestInfo where TestID=" + Session["TestID"]))
                {
                    read.Read();
                    this.TestInfo_Titel.Text = read["TestName"].ToString();
                    this.Title = read["TestName"].ToString();
                }
                Session["TestID"] = null;
                if (Session["Contactid_S"] != null)
                {
                    ViewState["Contactid"] = Session["Contactid_S"];
                    Session["Contactid_S"] = null;
                }
                ViewState["TIAT"] = tiat;
                this.TitaPager.Visible = true;
            }
            else
            {
                if (Session["Contactid_S"] != null)
                {
                    ViewState["Contactid"] = Session["Contactid_S"];
                    Session["Contactid_S"] = null;
                }
                ViewState["PageIndex_QW"] = 0;
                TIAT tiat = new TIAT();
                tiat.Dst.Clear();
                Quiz_Table_B = tiat.Quizeloader(20, 0 + 1, Session["DataScoure_TIA"].ToString());
                Quiz_WDataBound(tiat);
                ViewState["TIAT"] = tiat;
                this.TitaPager_w.Visible = true;
                ViewState["DataCommand"] = Session["DataScoure_TIA"].ToString();

                
            }
        }
    }
    protected void TrunBack_Click(object sender, EventArgs e)
    {

        if (Session["DataScoure_TIA"] != null)
        {
            Session["Contactid_S"] = ViewState["Contactid"];
            Response.Redirect("History_Test.aspx");
        }
        if (ViewState["Contactid"] != null)
        {
            Session["Contactid_S"] = ViewState["Contactid"];
            Response.Redirect("History_Test.aspx");
        }
        else
        {
            Session["TheScene"] = "7";
            Response.Redirect("Consultion.aspx");
        }
    }
    protected void NextButton_Click(object sender, EventArgs e)
    {
        TIAT tiat = (TIAT)ViewState["TIAT"];
        ViewState["PageIndex_Q"] = Convert.ToInt32(ViewState["PageIndex_Q"]) + 1;
        string t=tiat.Quizeloader("0", 2, Convert.ToInt32(ViewState["PageIndex_Q"]) + 1);
        Quiz_Table_B = t;
        QuizabelDataBound(tiat);
        ViewState["TIAT"] = tiat;
    }
    protected void FrontButton_Click(object sender, EventArgs e)
    {
        TIAT tiat = (TIAT)ViewState["TIAT"];
        ViewState["PageIndex_Q"] = Convert.ToInt32(ViewState["PageIndex_Q"]) - 1;
        Quiz_Table_B = tiat.Quizeloader("0", 2, Convert.ToInt32(ViewState["PageIndex_Q"]) + 1);
        QuizabelDataBound(tiat);
        ViewState["TIAT"] = tiat;
    }


    protected void QuizabelDataBound( TIAT tiat)
    {
        this.pageCount.Text= (Convert.ToInt32(ViewState["PageIndex_Q"]) + 1) + "/" + tiat.QuizPagerCount;
        if (Convert.ToInt32(ViewState["PageIndex_Q"]) == tiat.QuizPagerCount - 1)
        {
            this.NextButton.Enabled = false;
        }
        else
        {
            this.NextButton.Enabled = true;
        }
        if (Convert.ToInt32(ViewState["PageIndex_Q"]) == 0)
        {
            this.FrontButton.Enabled = false;
        }
        else
        {
            this.FrontButton.Enabled = true;
        }

    }
    protected void Tita_FrontButton_Click(object sender, EventArgs e)
    {
        TIAT tiat = (TIAT)ViewState["TIAT"];
        ViewState["PageIndex_QW"] = Convert.ToInt32(ViewState["PageIndex_QW"]) - 1;
        string t = tiat.Quizeloader(20, Convert.ToInt32(ViewState["PageIndex_QW"]) + 1, ViewState["DataCommand"].ToString());
        Quiz_Table_B = t;
        Quiz_WDataBound(tiat);
        ViewState["TIAT"] = tiat;
    }
    protected void Tita_NextButton_Click(object sender, EventArgs e)
    {
        TIAT tiat = (TIAT)ViewState["TIAT"];
        ViewState["PageIndex_QW"] = Convert.ToInt32(ViewState["PageIndex_QW"]) +1;
        string t = tiat.Quizeloader(20, Convert.ToInt32(ViewState["PageIndex_QW"]) + 1, ViewState["DataCommand"].ToString());
        Quiz_Table_B = t;
        Quiz_WDataBound(tiat);
        ViewState["TIAT"] = tiat;
    }
    protected void Quiz_WDataBound(TIAT tiat)
    {
        this.Tiata_Pagecount.Text = (Convert.ToInt32(ViewState["PageIndex_QW"]) + 1) + "/" + tiat.QuizPagerCount;
        if (Convert.ToInt32(ViewState["PageIndex_QW"]) == tiat.QuizPagerCount - 1)
        {
            this.Tita_NextButton.Enabled = false;
        }
        else
        {
            this.Tita_NextButton.Enabled = true;
        }
        if (Convert.ToInt32(ViewState["PageIndex_QW"]) == 0)
        {
            this.Tita_FrontButton.Enabled = false;
        }
        else
        {
            this.Tita_FrontButton.Enabled = true;
        }
    }
}