using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class robotTest_TIA_function_Complie : System.Web.UI.Page
{
    public string echo = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        //if(Request["path"]!=null)
        //{
            
            
         //}
    }

    protected bool Compile(out string result, string compilerName, string path, string sourcefile, string executableFile, int timeOut)
    {
        result = "";
        bool sec = true;
        Process p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;
        p.Start(); 
        p.StandardInput.AutoFlush = true;
        p.StandardInput.WriteLine(compilerName +" "+ path + "/" + sourcefile + " -o " + executableFile);       
        result = p.StandardOutput.ReadToEnd();
        p.StandardInput.WriteLine("exit");
        if(!p.WaitForExit(timeOut))
        {
            p.Kill();
            sec = false;
        }
        return sec;
    }

    protected bool execut(out string result, string path, string executableFile, string inputs, int timeOut, int testTimeOut, out int UsedTime)
    {
        bool sec = true;
        result = "";
        Process p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;
        p.Start();
        p.StandardInput.AutoFlush = true;
        p.StandardInput.WriteLine(path+"/"+executableFile);
        if(inputs!=null)
        {
            p.StandardInput.WriteLine(inputs);
        }
        result = p.StandardOutput.ReadLine();
        p.StandardInput.WriteLine("exit");
        if(!p.WaitForExit(timeOut))
        {
            p.Kill();
            UsedTime = timeOut;
            sec = false;
        }
        else
        {
            UsedTime = (int)p.TotalProcessorTime.TotalMilliseconds;
        }
        return sec;
    }

}