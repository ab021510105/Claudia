
document.onreadystatechange = function () {
    if (document.readyState == "complete") {
        var txt = document.getElementsByClassName("TextBox_1");
        for (i = 0; i < txt.length; i++) {
                    txt[i].onclick = function () {
                        this.style.border = " 5px solid #12e6f3";
                    var a = document.getElementsByClassName("TextBox_1");
                    for (i = 0; i < txt.length; i++) {
                        if (a[i] != this ) {
                            a[i].style.border = "1px solid Gray";
                        }
                    }
                }
            }
        
    }
}