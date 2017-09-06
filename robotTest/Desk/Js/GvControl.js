function ShowGridViewItem(sid, ev) {
    ev = ev || window.event;
    var target = ev.target || ev.srcElement;
    var div = document.getElementById("Div" + sid);
    div.style.display = div.style.display == "none" ? "block" : "none";
    //target.innerhtml = 
    target.innerHTML = div.style.display == "none" ? "+" : "-";
}