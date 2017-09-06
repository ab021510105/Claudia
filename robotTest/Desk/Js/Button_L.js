document.onreadystatechange = function () {
    if (document.readyState == "complete") {
        var Button_L = document.getElementsByClassName('Button_L');
        for (i = 0; i < Button_L.length; i++) {
            Button_L[i].onmouseover = function () {
                if(this.disabled==false)
                    this.style.border = "1px solid white";
            }
            Button_L[i].onmouseout = function () {
                this.style.border = "none"
            }
        }
    }
}