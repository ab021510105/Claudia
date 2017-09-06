function OnOptClick(eid)
{
    var a = document.getElementById(eid);
    if (a.title == "unselected")
    {
        a.title = "selected";
        a.style.border = "2px solid #ff6a00";
    }
    else if(a.title == "selected")
    {
        a.title = "unselected";
        a.style.border = "2px solid white";
    }
}

function OnMouseIn(eid)
{
    var a = document.getElementById(eid);
    if(a.title != "selected")
    {
        a.style.border = "2px solid #007acc";
    }
}

function OnMouseOut(eid)
{
    var a = document.getElementById(eid);
    if (a.title != "selected") {
        a.style.border = "2px solid white";
    }
}

function OnUpLoad()
{

    var Topics = document.getElementsByClassName('topicContent');
    var Info = "tid=" + document.getElementById("_stid").value + "&data=";
    var pass = false;
    for(i=0;i<Topics.length;i++)
    {
        var topicid = Topics[i].id.split("t")[1];
        var options = Topics[i].getElementsByClassName("option");
        Info += "$" + topicid;
        pass = false;
        for(j=0;j<options.length;j++)
        {
            if(options[j].title == "selected")
            {
                var oid = options[j].id.split("op")[1];
                Info += "#" + oid;
                pass = true;
            }
        }
        if (!pass)
        {
            alert("你有题目未完成");
            return;
        }
    }
    var uid = $("#userid").val();
    //Arequest('maindesk', 'TIA/function/_TIA/UpLoad.aspx?'+Info, true);
    var xmla = $.ajax({
        type: "POST",
        url: 'TIA/function/_TIA/UpLoad.aspx?uid='+uid,
        dataType: "json",
        data: { "selection": Info },
        async: true,
        beforeSend: function () {
            document.getElementById('maindesk').innerHTML = " <div style=\"text-align:center\"><img src=\"Desk/busy.jpg\" /><a id=\"message\">请稍后。。。</a></div>";

        },
        complete: function () {
           // if (getStatus(xmla.responseText) != "sec") {
              //  document.getElementById('maindesk').innerHTML = xmla.responseText;
            //}
           // else {
                document.getElementById("message").innerHTML = "提交完成";
                setTimeout(function () {
                    //var uid = $("#userid").val();
                    Arequest('maindesk', "TIA/function/TestHisInfo/main.aspx?uid=" + uid + "&d=1", true);
                },
                1000);
           // }
        },
        success: function () {
            document.getElementById("message").innerHTML = "提交完成";
            setTimeout(function () {
                //var uid = $("#userid").val();
                Arequest('maindesk', "TIA/function/TestHisInfo/main.aspx?uid=" + uid + "&d=1", true);
            },
                1000);
        }
    });
}