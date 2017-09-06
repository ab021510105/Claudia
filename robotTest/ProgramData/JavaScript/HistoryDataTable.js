var Table_ClickedBtnid = "";
function Week_Click() {
    var _data = Test.ObjectTest.Week_Click().value;
    var data_Max = 100.0;
    var x = [1, 2, 3, 4, 5, 6, 7];
    var line_Tile = ["综合"];
    var rowData = _data.split("#");
    var Data = new Array();
    for (i = 0; i < rowData.length - 1; i++) {
        Data[i] = new Array();
    }
    for (i = 0; i < rowData.length - 1; i++) {
        var colddata = rowData[i].split("d");
        for (var k = 0; k < colddata.length - 1; k++) {
            Data[i][k] = parseFloat(colddata[k]);
        }
    }
    j.jqplot.diagram.base("DataTable", Data, line_Tile, "综合趋势分析图", x, "天", "准确率(%)", data_Max, 1);
    var clickedbtn = document.getElementById(Table_ClickedBtnid);
    if (clickedbtn != null) {
        clickedbtn.style.borderColor = "black";
    }
    Table_ClickedBtnid = "week";
    document.getElementById("week").style.backgroundColor = "#95f6f3";
}

function Month_Click() {
    var Data_Max = 100.0;
    var _data = Test.ObjectTest.Month_Click().value;
    var x = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
    var line_Title = ["综合"];
    var RowData = _data.split("#");
    var Data = new Array();
    for (i = 0; i < RowData.length - 1; i++) {
        Data[i] = new Array();
    }
    for (i = 0; i < RowData.length - 1; i++) {
        var colddata = RowData[i].split("d");
        for (var k = 0; k < colddata.length - 1; k++) {
            Data[i][k] = parseFloat(colddata[k]);
        }
    }
    j.jqplot.diagram.base("DataTable", Data, line_Title, "综合趋势分析图", x, "月", "准确率(%)", Data_Max, 1);
    var clickedbtn = document.getElementById(Table_ClickedBtnid);
    if (clickedbtn != null) {
        clickedbtn.style.borderColor = "black";
    }
    Table_ClickedBtnid = "Month";
    document.getElementById("Month").style.backgroundColor = "#95f6f3";
}