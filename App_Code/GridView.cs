using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// GridView 的摘要说明
/// </summary>
/// 
namespace MyTheme
{
    public class GridView
    {
        public GridView()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public class GridViewButton
        {
            public string ButtonText="Button1";
            public string OnClickFunction = "";
            public bool disabled =false;
            public string ButtonDataFeld = null;
            public string ButtonID =null;
        }
        public class Rowsender
        {
            public object sender;
            public DataRow datarow;
        }

        public class GvStyle1
        {
            public string Title = "";
            public string Gvname = "";
            public int Pageindex = 0;
            public int PageSize = 5;
            public string RefreshFunctionName = "";
            public int PageCount = 0;
            public object[] Buttons;
            public DataTable Datasocure = null;
            public string[,] ColDataFlied = null;
            public EventHandler OnRowBound=null;
            public string PrimaryKey = "";
            public bool AutoWidth = false;
            public bool display = true;
            public string CreateGridView()
            {
                string html = "";
                html += "<div id=\"" + Gvname + "\" class=\"GridView\" "+(display?"":"style=\"display:none\"")+">";
               PageCount = Datasocure.Rows.Count % PageSize == 0 ? Datasocure.Rows.Count / PageSize : ((int)Datasocure.Rows.Count / PageSize) + 1;
                html += "<label style=\"display:none\" id=\"" + Gvname + "Count\">" + PageCount + "</label>";
                html += "<label style=\"display:none \" id=\"" + Gvname + "Index\">" + Pageindex + "</label>";

                //html += "";
                html += "<div style=\"border:1px solid black\">";
                html += "<table style=\""+(AutoWidth?"":"width:100%; ")+"height:100%;text-align:center\" border=\"1\">";
                html += "<tr>";
                if (ColDataFlied == null)
                {
                    foreach (DataColumn dc in Datasocure.Columns)
                    {
                        html += "<td>" + dc.ColumnName + "</td>";

                    }
                    html += "</tr>";
                    int count=0;
                    for (int i = PageSize * (Pageindex + 1) - PageSize; count < PageSize&&i<Datasocure.Rows.Count; i++)
                    {
                        html += "<tr>";
                        
                        if (OnRowBound != null)
                        {
                        Rowsender send = new Rowsender();
                        send.sender = this;
                        send.datarow = Datasocure.Rows[i];
                        OnRowBound(send, EventArgs.Empty);
                        }
                        for (int j = 0; j < Datasocure.Columns.Count; j++)
                        {
                            html += "<td>" + Datasocure.Rows[i][j].ToString() + "</td>";
                        }
                        //if (Buttons_Texts != null)
                        //{
                        //    html += "<td>";
                        //    int k = 0;
                        //    foreach (string str in Buttons_Texts)
                        //    {
                        //        html += "<input type=\"button\" id=\"b" + i + k + "\" value=\"" + str + "\" onclick=\"studentinfoCommand(\"" + "\")\"";
                        //        k++;
                        //    }
                        //}
                        html += "</tr>";
                        count++;
                    }
                    html += "</tabel>";
                    html += "</div>";
                }
                else
                {
                    for (int i = 0; i < ColDataFlied.GetLength(0); i++)
                    {
                        html += "<td>"+ColDataFlied[i,0]+"</td>";
                    }
                    html += "</tr>";
                    int count = 0;
                    for (int i = PageSize * (Pageindex + 1) - PageSize;count < PageSize&&i<Datasocure.Rows.Count; i++)
                    {
                        count++;
                        html += "<tr>";
                        if (OnRowBound != null)
                        {
                            Rowsender send = new Rowsender();
                            send.sender = this;
                            send.datarow = Datasocure.Rows[i];
                            OnRowBound(send, EventArgs.Empty);
                        }
                        for (int j = 0; j < ColDataFlied.GetLength(0); j++)
                        {
                            html += "<td>" + Datasocure.Rows[i][ColDataFlied[j,1]].ToString() + "</td>";
                        }
                        if ( Buttons != null)
                        {
                            html += "<td>";
                            for (int k = 0; k < Buttons.Length; k++)
                            {
                                html += "<input id=\"";
                                html += ((GridViewButton)Buttons[k]).ButtonID == null ? i + "" + k : ((GridViewButton)Buttons[k]).ButtonID;
                                html += "\" value=\"" + ((GridViewButton)Buttons[k]).ButtonText + "\" type=\"button\" onclick=\""+Gvname+"Command(\'";
                                html += Datasocure.Rows[i][((GridViewButton)Buttons[k]).ButtonDataFeld] + "#";
                                html += ((GridViewButton)Buttons[k]).ButtonID == null ? i + "" + k : ((GridViewButton)Buttons[k]).ButtonID;
                                html+="#"+(PrimaryKey==""?"":Datasocure.Rows[i][PrimaryKey])+"\')\" class=\"Button_S_B\" ";
                                html += ((GridViewButton)Buttons[k]).disabled?"disabled=\"disabled\"":"";
                                html += "/>";
                                html += "&nbsp;";
                            }
                            html += "</td>";
                        }
                        html += "</tr>";
                    }
                    html += "</tabel>";
                    html += "</div>";
                    html += "</div>";
                }
               
                return html;
            }
        }
       //////////////////////Gv1End////////////////////////////


      ////////////////////Gv2Start////////////////////////////
        public class Gvstyle2
        {
            public string Title = "";
            public string Gvname = "";
            public int Pageindex = 0;
            public int PageSize = 5;
            public string RefreshFunctionName = "";
            public int PageCount = 0;
            public object[] Buttons;
            public DataTable Datasocure = null;
            public string[,] ColDataFlied = null;
            public EventHandler OnRowBound = null;
            public GvStyle1 RowGridItems=null;
            public string display = "block";
            public string width = "100%";
            public string CreateGridView()
            {
                string html = "";
                html += "<div id=\"" + Gvname + "\" class=\"GridView\" style=\"display:"+display+";width:"+width+"; \" >";
                PageCount = Datasocure.Rows.Count % PageSize == 0 ? Datasocure.Rows.Count / PageSize : ((int)Datasocure.Rows.Count / PageSize) + 1;
                html += "<label style=\"display:none\" id=\"" + Gvname + "Count\">" + PageCount + "</label>";
                html += "<label style=\"display:none \" id=\"" + Gvname + "Index\">" + Pageindex + "</label>";

                //html += "";
                html += "<div style=\"border:1px solid black\">";
                html += "<table style=\"width:100%;height:100%;text-align:center\" border=\"1\" >";
                html += "<tr>";
                if (ColDataFlied == null)
                {
                    foreach (DataColumn dc in Datasocure.Columns)
                    {
                        html += "<td>" + dc.ColumnName + "</td>";

                    }
                    html += "<td>&nbsp;</td>";
                    html += "<td>&nbsp;</td>";
                    html += "</tr>";
                    //html += "</table>";
                    int count = 0;
                    for (int i = PageSize * (Pageindex + 1) - PageSize; count < PageSize && i < Datasocure.Rows.Count; i++)
                    {
                       // html += "<table style=\"width:100%;height:100%;text-align:center\" border=\"1\">";
                        html += "<tr>";

                        if (OnRowBound != null)
                        {
                            Rowsender send = new Rowsender();
                            send.sender = this;
                            send.datarow = Datasocure.Rows[i];
                            OnRowBound(send, EventArgs.Empty);
                        }
                        for (int j = 0; j < Datasocure.Columns.Count; j++)
                        {
                            html += "<td>" + Datasocure.Rows[i][j].ToString() + "</td>";
                        }
                        
                       
                       
                        if (RowGridItems!=null)
                        {
                            html += "<td><a href=\"#\" onclick=\"ShowGv('"+RowGridItems.Gvname+"')\">+</a></td>";
                            html += "</tr>";
                            html += RowGridItems.CreateGridView();

                        }
                        else
                        {  
                            html += "</tr>";
                            //html += "</table>";

                        }
                        count++;
                    }
                    html += "</tabel>";
                    html += "</div>";
                }
                else
                {
                    for (int i = 0; i < ColDataFlied.GetLength(0); i++)
                    {
                        html += "<td>" + ColDataFlied[i, 0] + "</td>";
                    }
                    html += "</tr>";
                    //html += "</table>";
                    int count =0;
                    for (int i = PageSize * (Pageindex + 1) - PageSize; count < PageSize && i < Datasocure.Rows.Count; i++)
                    {
                       // html += "<table style=\"width:100%;height:100%;text-align:center\" border=\"1\">";
                        html += "<tr>";
                        if (OnRowBound != null)
                        {
                            Rowsender send = new Rowsender();
                            send.sender = this;
                            send.datarow = Datasocure.Rows[i];
                            OnRowBound(send, EventArgs.Empty);
                        }
                        for (int j = 0; j < ColDataFlied.GetLength(0); j++)
                        {
                            html += "<td>" + Datasocure.Rows[i][ColDataFlied[j, 1]].ToString() + "</td>";
                        }
                        if (Buttons != null)
                        {
                            html += "<td>";
                            for (int k = 0; k < Buttons.Length; k++)
                            {
                                html += "<input id=\"";
                                html += ((GridViewButton)Buttons[k]).ButtonID == null ? i + "" + k : ((GridViewButton)Buttons[k]).ButtonID;
                                html += "\" value=\"" + ((GridViewButton)Buttons[k]).ButtonText + "\" type=\"button\" onclick=\"" + Gvname + "Command(\'";
                                html += Datasocure.Rows[i][((GridViewButton)Buttons[k]).ButtonDataFeld].ToString() + "#";
                                html += ((GridViewButton)Buttons[k]).ButtonID == null ? i + "" + k : ((GridViewButton)Buttons[k]).ButtonID;
                                html += "\')\" class=\"Button_S_B\" ";
                                html += ((GridViewButton)Buttons[k]).disabled ? "disabled=\"disabled\"" : "";
                                html += "/>";
                                html += "&nbsp;";
                            }
                            html += "</td>";
                        }


                        if (RowGridItems!=null)
                        {
                            html += "<td><a href=\"#\" onclick=\"ShowGv('" + RowGridItems.Gvname + "')\"  style=\"text-decoration:none;\" id=\""+RowGridItems.Gvname+"btn\">+</a></td>";
                            html += "</tr>";
                            html += "<tr id=\""+RowGridItems.Gvname+"\" style=\" display:none\"><td>";
                            html += RowGridItems.CreateGridView();
                            html += "</tr></td>";

                        }
                        else
                        {
                            html += "</tr>";
                           // html += "</table>";

                        }
                        html += "</table>";
                        count++;
                    }
                  
                    html += "</div>";
                    html += "</div>";


                    
                }
                return html;
            }
        }





    }
}