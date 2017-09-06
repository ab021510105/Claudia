using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class robotTest_TIA_function_testInfo : System.Web.UI.Page
{
    protected string echo = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string temcmd = "select tsRelationship.testid,tsrelationship.relationshipid,testinfo.teststarttime,testinfo.testendtime,testinfo.testcount,testinfo.testname from TestInfo inner join TSRelationship on TSRelationship.TestID=TestInfo.TestID where TSRelationship.Contactid='" + Request["uid"] + "' and TSRelationship.Score=-1";
            GetInfo(temcmd);
        }
    }

    protected void GetInfo(string select)
    {
        using(MySqlConnection sc=new MySqlConnection(Diya.ConectionString))
        {
            sc.Open();
            MySqlCommand scmd = new MySqlCommand(select, sc);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(scmd);
            da.Fill(dt);
            if(dt.Rows.Count==0)
            {
                echo += "Ŀǰû����ϰ";
                sc.Close();
                return;
            }
            echo+="<div style=\"width:100%;background-color:gray;color:white\">�ҵ���ϰ</div>";
            echo += "<table border=\"1\" style=\"width:100%;border:1px solid gray;text-align:center\">";
            echo += "<thead>";
            echo += "<tr>";
            echo += "<td>��ϰ����</td>";
            echo += "<td>��ϰʱ�ζ�</td>";
            echo += "<td>��ϰ����</td>";
            echo += "<td></td>";
            echo += "</tr>";
            echo += "</thead>";
            echo += "<tbody>";
            foreach(DataRow dr in dt.Rows)
            {
                echo += "<tr>";
                echo += "<td>" + dr["testname"]+"</td>";
                echo += "<td>" + dr["teststarttime"] + " �� "+dr["testendtime"] + "</td>";
                echo += "<td>" + dr["testcount"] + "</td>" ;
                DateTime now = DateTime.Now;
                DateTime endTime = Convert.ToDateTime(dr["testendtime"].ToString());
                if(endTime>=now)
                {
                    DateTime startTime = Convert.ToDateTime(dr["teststarttime"].ToString());
                    if (startTime <= now)
                    {
                        echo += "<td> <input type=\"button\" value=\"��ʼ\"  onclick=\"startTest('" + dr["relationshipid"] + "')\"/></td>";
                    }
                    else
                    {
                        echo += "<td> <input type=\"button\" value=\"����ʱ�ζ���\" disabled=\"disabled\" /></td>";
                    }
                }
                else
                {
                    echo += "<td> <input type=\"button\" value=\"�ѹ���\" disabled=\"disabled\" /></td>";
                    scmd.CommandText = "update TSRelationship set Score=0,completiontime='"+dr["testendtime"] + "'    where RelationshipID=" + dr["relationshipid"];
                    scmd.ExecuteNonQuery();
                }
                echo += "</tr>";
            }
            echo += "</tbody>";


            //echo += "</div>";
        }
    }




}