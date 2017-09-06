document.onreadystatechange = function () {
    if (document.readyState == "complete") {
        var tr = document.getElementsByTagName('tr');
        for (i = 0; i < tr.length; i++) {
            tr[i].style.height = '20%';
        }
        var td = document.getElementsByTagName('td');
        for (i = 0; i < td.length; i++) {
            td[i].style.height = '100%';
            td[i].style.fontSize = 'x-large';

        }

    }
}

function textcliked() {
    var input = document.getElementsByTagName("input");
    for (i = 0; i < input.length; i++) {
        if (input[i].type=="text") {
            input[i].style.border = "1px solid #000000";
        }
    }
    //this.style.border = "5px solid #ff6a00";
    
}