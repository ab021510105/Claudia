var option = {
    title: {
        test: '统计',
        subtext: '近10日'
    },
    tooltip: {
        trigger: 'axis'
    },
    toolbox: {
        show: true,
        feature: {
            magicType: { show: true, type: ['stack', 'tiled'] },
            saveAsImage: { show: true }
        }
    },
    dataZoom: [{
        startValue: ''
    }, {
        type: 'inside'
    }],
    visualMap: {
        top: 10,
        right: 10,
    },
    legend: {
        data: ['正确率']
    },
    xAxis: {
        type: 'category',
        boundaryGap: false,
        data: []
    },
    yAxis: {
        type: 'value'
        //data: ["正确率"]
    },
    series: [{
        name: '正确率',
        type: 'line',
        smooth: true,
        //clipOverflow:false,
        data: []
    }]

};

function overview_ActiveChart()
{
    var testchart = echarts.init(document.getElementById("TestCountChart"));
    var names = document.getElementById("OverViewTestName").value.split("#");
    var values = document.getElementById("OverViewTestValue").value.split("#");
    option.dataZoom[0].startValue = names[0];
    for (i = 0; i < values.length - 1; i++) {
        option.series[0].data[i] = values[i];
    }
    var name = '';
    var j = 0;
    for (i = 0; i < names.length - 1; i++) {
        if (names[i] == name) {
            names[i] = names[i] + "" + (++j);
        }
        else {
            name = names[i];
        }
        option.xAxis.data[i] = names[i];
    }
    testchart.setOption(option);
}