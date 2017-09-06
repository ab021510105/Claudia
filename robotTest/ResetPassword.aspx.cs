using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Done_Click(object sender, EventArgs e)
    {
        string userid = this.Userid.Value;
        if (this.Userid.Value != "" && this.OldPassword.Value != "")
        {
            string selectcmd = "";
            if (new Diya().checktext("N", this.Userid.Value))
            {
                selectcmd = "Select * from ConsultingInfo where Contactid="+this.Userid.Value+" and Password='"+new Diya().GetMD5Text(this.OldPassword.Value)+"'";
                using (MySqlDataReader read = new Diya().RowReader(selectcmd))
                {
                    if (read.Read())
                    {
                        if (this.NewPasssword.Value != "")
                        {
                            if (this.NewPasssword.Value == this.CNewPssword.Value)
                            {
                                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                                {
                                    Sc.Open();
                                    MySqlCommand Scmd = new MySqlCommand("Update ConsultingInfo set Password='"+new Diya().GetMD5Text(this.NewPasssword.Value)+"' where Contactid="+userid,Sc);
                                    Scmd.ExecuteNonQuery();
                                    Response.Redirect("Login.aspx");
                                }
                            }
                            else
                            {
                                this.ConPassordError.Text = "Your new Password is not confirmation";
                                this.ConPassordError.Visible = true;
                            }
                        }
                        else
                        {
                            this.ConPassordError.Text = "Please enter your new passworld";
                            this.ConPassordError.Visible = true;
                        }
                    }
                    else
                    {
                        this.errorOldPasss.Text = "Worng Passworld or UserID";
                        this.errorOldPasss.Visible = true;
                    }
                }
            }
            else
            {
                selectcmd = "select UserID ,UserName, UserType from UserInfo0 where Userid='" + this.Userid.Value + "'and Password='" +new Diya().GetMD5Text(this.OldPassword.Value) + "'";
                using (MySqlDataReader read = new Diya().RowReader(selectcmd))
                {
                    if (read.Read())
                    {
                        if (this.NewPasssword.Value != "")
                        {
                            if (this.NewPasssword.Value == this.CNewPssword.Value)
                            {
                                using (MySqlConnection Sc = new MySqlConnection(Diya.ConectionString))
                                {
                                    Sc.Open();
                                    MySqlCommand Scmd = new MySqlCommand("Update UserInfo0 set Password='" + new Diya().GetMD5Text(this.NewPasssword.Value) + "' where UserID='" + userid+"'", Sc);
                                    Scmd.ExecuteNonQuery();
                                    Response.Redirect("Login.aspx");
                                }
                            }
                            else
                            {
                                this.ConPassordError.Text = "Your new Password is not confirmation";
                                this.ConPassordError.Visible = true;
                            }
                        }
                        else
                        {
                            this.ConPassordError.Text = "Please enter your new passworld";
                            this.ConPassordError.Visible = true;
                        }
                    }
                    else
                    {
                        this.errorOldPasss.Text = "Worng Passworld or UserID";
                        this.errorOldPasss.Visible = true;
                    }
                }
            }

        }

    }
}