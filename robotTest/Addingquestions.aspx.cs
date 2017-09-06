using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Addingquestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Selectcomd = "Select * from Topic";
            ViewState["TopicInfoData"] = new Diya().Gridviewbind(this.Topic_Gw, Selectcomd);
        }

    }
    protected void Topic_Gw_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Topic_Gw.PageIndex = e.NewPageIndex;
        this.Topic_Gw.DataSource = (DataTable)ViewState["TopicInfoData"];
        this.Topic.DataBind();
    }
    protected void Topic_Gw_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Topic_Gw_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}