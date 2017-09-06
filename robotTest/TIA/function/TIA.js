var selection = "";
function getStatus(text)
{
    var status;
    var temp1 = text.split("<Status>")[1];
    status = temp1.split("</Status>")[0];
    return status;
}

function bindSelection() {
    var t = document.getElementsByClassName('TopicInfo');
    var f = true;
    for (i = 0; t.length; i++) {
        selection += t[i].id + "$";
        var options = t[i].getElementsByClassName('ioption');
        f = true;
        for (j = 0; j < options.length; j++) {
            if (options[i].checked) {
                f = false;
                selection += options[j].id + "$";
            }
        }
        if (f) {
            return f;
        }
        selection += "#";
    }
    return f;
}

function Upload() {
    var uid = document.getElementById('userid_lable').innerHTML;
    var tid = document.getElementById('tsid').value;
    if (!bindSelection()) {
        alert('你有题目没有完成，请检查');
        return;
    }
    var xmla = $.ajax({
        type: "POST",
        url: "upload.aspx?UID="+uid+"&TSID="+tid,
        dataType: "json",
        data: { "selection": selection },
        async: true,
        beforeSend: function () {
            document.getElementById('maindesk').innerHTML = " <div style=\"text-align:center\"><img src=\"Desk/busy.jpg\" /><a id=\"message\">请稍后。。。</a></div>";
            
        },
        complete: function () {
            //if (getStatus(xmla.responseText) != "sec") {
            //    document.getElementById('maindesk').innerHTML = xmla.responseText;
            //}
            //else {
            //    document.getElementById("message").innerHTML = "提交完成";
            //    setTimeout(function () {
            //        Arequest('maindesk', 'TIA/function/historyTestInfo.aspx?UID=' + uid + "&Pindex=0", true);
            //    },
            //        1000);
            //}
        },
        success : function()
        {
           // MyCountClick('MyCount_btn');

            //if (getStatus(xmla.responseText) != "sec") {
            //    document.getElementById('maindesk').innerHTML = xmla.responseText;
            //}
             
                document.getElementById("message").innerHTML = "提交完成";
                setTimeout(function () {
                    Arequest('maindesk', 'TIA/function/historyTestInfo.aspx?UID=' + uid + "&Pindex=0", true);
                },
                    1000);
        }
    });
}

function initialize()
{
    var opts = document.getElementsByClassName('option');
    for(i=0;i<opts.length;i++)
    {
        opts[i].onmouseover=function()
        {
            opts[i].style.border = "1px solid #95f6f3";
        }
        .onmouseleave = function () {
            if (opts[i].title != "Selected") {
                this.style.border = "1px solid #FFFFFF";
            }
        }
    }
    document.getElementById("p0").style.display = "";
}

function onSelected()
{
    var input = this.getElementsByTagName('input')[0];
    input.checked = input.checked ? false : true;
    //if(input.checked)
    //{
    //    var topicid = input.id.split("#")[0];
    //    var optionid = input.id.split("#")[1];
    //    var f = true;
    //    var sle = selection.split("#");
    //    for(i=0;i<sle.length;i++)
    //    {
    //        if(sle[i].split("$")[0]==topicid)
    //        {
    //            f = false;
    //            sle[i] += optionid + "$";
    //            break;
    //        }
    //    }
    //    if(f)
    //    {
    //        selection += topicid + "$" + optionid + "$#";
    //    }
    //    else
    //    {
    //        selection = "";
    //        for(i=0;i<sle.length;i++)
    //        {
    //            selection += sle[i];
    //        }
    //    }
    //}
    //else
    //{
    //    var topicid = input.id.split("#")[0];
    //    var optionid = input.id.split("#")[1];
    //    var sle = selection.split("#");
    //    for (i = 0; i < sle.length; i++) {
    //        if (sle[i].split("$")[0] == topicid) {
    //            var temp = sle[i].split(optionid + "$");
    //            sle[i] = "";
    //            for (j = 0; j < temp.length; j++) {
    //                sle[i] += temp;
    //            }
    //            break;
    //        }

    //    }
    //    selection = "";
    //    for (i = 0; i < sle.length; i++) {
    //        selection += sle[i];
    //    }

    //}
}

function TIAchang()
{
    var desk = document.getElementById('desk');
    var TestInfo =document.getElementById('TestInfo').value.split(String.fromCharCode(3));
    var Pcount = parseInt(document.getElementById('TestCount').value);
    var Pindex = parseInt(document.getElementById('TestPageIndex').value);
    var Pinfo = document.getElementById('pageInfo');
    Pinfo.innerHTML = (Pindex + 1) + "/" + Pcount;
    if(Pindex==0)
    {
        document.getElementById('lastPage').disabled = true;
    }
    else
    {
        document.getElementById('lastPage').disabled = false;
    }
    if(Pindex+1==Pcount)
    {
        document.getElementById('nextPage').value = "上传";
        document.getElementById('nextPage').onclick = Upload();
    }
    else
    {
        document.getElementById('nextPage').value = "下一页";
        document.getElementById('nextPage').onclick = onTestNextClick();
    }
    for(i=0;i<Pcount;i++)
    {
        document.getElementById('p' + i).style.display = "none";
    }
    document.getElementById('p' + Pindex).style.display = "";
}

function onTestLastClick()
{
    var Pindex = parseInt(document.getElementById('TestPageIndex').value);
    document.getElementById('TestPageIndex').value = (Pindex - 1) + '';
    TIAchang();
}

function onTestNextClick()
{
    var Pindex = parseInt(document.getElementById('TestPageIndex').value);
    document.getElementById('TestPageIndex').value = (Pindex + 1) + '';
    TIAchang();
}