function SetColor(color) {
    var item = document.getElementById('Precedes_item');
    item.style.backgroundColor = color;
}
function Precedes(Percent) {
    Target = Percent;
    Do();
}
function Dialog(Text) {
    var labe = document.getElementById('Precedes_label');
    if (labe != null) {
        labe.innerHTML += "<br>"+Text;
    }
}



function FinshPrecedes() {
    P = 0;
    sign = 0;
    Target = 0;
    var press = document.getElementById('Precedes');
    var Item = document.getElementById('Precedes_item');
    var labe = document.getElementById('Precedes_label');
    press.style.display = "none";
    Item.style.width = "0px";
    Item.style.display = "none";
    if (labe != null) {
        labe.innerHTML = "0%";
        labe.style.display = "none";
    }
}
var P = 0;
var Target;
var sign = 0;


function Do() {
    
   sign = 1;
    var press = document.getElementById('Precedes');
    var Item = document.getElementById('Precedes_item');
    var labe = document.getElementById('Precedes_label');
   
    var Wide = parseInt(press.style.width);

    if (P < Target) {
        Item.style.width = ++P + "%";
        if (labe != null) {
            labe.innerHTML = P + "%";
        }
        var Wait = P / 5 + Wide / 6;
        setTimeout(Do, Wait);
    } 
    else
    {
        sign = 0;
    }
}
