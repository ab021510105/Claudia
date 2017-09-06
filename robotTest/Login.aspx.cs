using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace Login
{
    public partial class land : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.disktop.ImageUrl = @"~\Bin\Desk\desk01.png";
            //this.AuthCode1.ClearSession();
            //AjaxPro.Utility.RegisterTypeForAjax(typeof(Login.land));
           if(Request["LO"]=="1")
           {
               Session.Clear();
           }
           
            // this.AuthCode1.NextImgText = "Next picture";
        }

        
        //[AjaxPro.AjaxMethod]
        public int  GetCodeTime()
        {
            return Convert.ToInt32(Session["Time"]);
        }

        //[AjaxPro.AjaxMethod]
        public int GetSeverTime()
        {
            return Convert.ToInt32(DateTime.Now.ToString("mmss"));
        }

        //[AjaxPro.AjaxMethod]
        public int ClearSessionTime()
        {
            Session["Time"] = 0;
            return 0;
        }

        //[AjaxPro.AjaxMethod]
        public string GetCode()
        {
            Random r = new Random(Convert.ToInt32(DateTime.Now.ToString("HHmmss")));
            Diya diya = new Diya();
            
            Session["Time"] = Convert.ToInt32(DateTime.Now.ToString("mmss"));
            string Code = "";
            int x = r.Next(1,10);
            Session["Code"] = diya.GetMD5Text(x.ToString());
            ///Random r = new Random(Convert.ToInt32(DateTime.Now.ToString("HHmmss")));
            int sign1 = r.Next(0,3);
            int sign2 = r.Next(0,2);
            int y = 0;
            int t;
            switch (sign1)
            {                    
                case 0:
                    t=r.Next(1, 10);
                    y = x * t;
                    Code += t+"#*#x";
                    break;
                case 1:
                    t = r.Next(1, 10);
                    y = x + t;
                    Code += "x#+#"+t;
                    break;
                case 2:
                    t = r.Next(1, 10);
                    y = x - t;
                    Code += "x#-#"+t;
                    break;
                default:
                    break;
            }
            switch (sign2)
            {
                case 0:
                    t = r.Next(1, 10);
                    y += t; 
                    Code += "#+"+t+"#"+y;
                    break;
                case 1:
                    t = r.Next(1, 10);
                    y -= t;
                    Code += "#-"+t+"#"+y;
                    break;
            }
           
            return Code;
        }


        protected void buuton1_Click(object sender, EventArgs e)
        {
            if (!new Diya().checktext("N", this.UserId_text.Value))
            {
                try
                {
                    Diya diay = new Diya();
                    using (MySqlDataReader read = new Diya().RowReader("select UserID ,UserName, UserType from UserInfo0 where Userid='" + this.UserId_text.Value + "'and Password='" + diay.GetMD5Text(this.PassWorld.Value) + "'"))
                    {
                        bool login = read.Read();
                        if (login && diay.GetMD5Text(this.VerificationCode.Value) == Session["Code"].ToString())
                        {
                            //this.AuthCode1.ClearSession();
                            //this.AuthCode1.NextImgText = "Next picture";
                            Session["UserInfo"] = read["UserType"].ToString() + '#' + read["UserID"].ToString() + '#' + read["UserName"].ToString();

                            Response.Redirect("Consultion.aspx");

                        }
                        else
                        {
                           // this.AuthCode1.ClearSession();
                            if (!login)
                            {
                                Literal MeGTex = new Literal();
                                MeGTex.Text = "<script>alert('用户名或密码错误'); </script>";
                                Page.Controls.Add(MeGTex);
                            }
                            else
                            {

                                Literal MeGTex = new Literal();
                                MeGTex.Text = "<script>alert('验证码错误');GreatCaptcha();</script>";
                                Page.Controls.Add(MeGTex);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    Literal MeGTex = new Literal();
                    MeGTex.Text = "<script>alert('" + err.Message + "');</script>";
                    Page.Controls.Add(MeGTex);
                }
            }
            else if (new Diya().checktext("N", this.UserId_text.Value))
            {
                try
                {
                    Diya diya = new Diya();
                    using (MySqlDataReader read = new Diya().RowReader("select * From ConsultingInfo where Contactid=" + this.UserId_text.Value + " and Password='" + diya.GetMD5Text(this.PassWorld.Value) + "'"))
                    {
                        bool Connect=read.Read();
                        if (Connect&&diya.GetMD5Text(this.VerificationCode.Value)==Session["Code"].ToString())
                        {
                           // this.AuthCode1.ClearSession();
                            // this.AuthCode1.NextImgText="Next picture";
                            Session["LandInfo"] = this.UserId_text.Value;
                            if (Session["Disabled"] == null)
                            {
                                Response.Redirect("ObjectTest50.aspx");
                            }
                            else
                            {
                                Literal MegText = new Literal();
                                MegText.Text = "<script>alert('网站正在维护');GreatCaptcha(); </script>";
                                Page.Controls.Add(MegText);
                                Response.Write(MegText);
                                //Page.Controls.AddAt(Page.Controls.Count - 1, MegText);
                            }
                        }
                        else
                        {
                           // this.AuthCode1.ClearSession();
                            //this.AuthCode1.NextImgText = "Next picture";
                            if (!Connect)
                            {
                                Literal MeGTex = new Literal();
                                MeGTex.Text = "<script>alert('用户名或密码错误'); </script>";
                                Page.Controls.Add(MeGTex);
                            }
                            else
                            {
                                Literal MeGTex = new Literal();
                                MeGTex.Text = "<script>alert('验证码错误');GreatCaptcha(); </script>";
                                Page.Controls.Add(MeGTex);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    Literal MegTex = new Literal();
                    MegTex.Text = "<script> alert('"+err.Message+"');</script>";
                    Page.Controls.Add(MegTex);
                }
            }

        }

        protected void changword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}