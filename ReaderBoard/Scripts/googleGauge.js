google.charts.load('current', { 'packages': ['gauge'] });
google.charts.setOnLoadCallback(drawPhoneChart);

var options = {
    width: 350,   height:230,  //Gauge height
    redColor: "#FF0000",
    redFrom: 0, redTo: 40,
    yellowColor: "#FFFF00",
    yellowFrom: 40, yellowTo: 80,
    greenColor: "00FF00",
    greenFrom: 80, greenTo: 100,
    minorTicks: 20
};

function drawPhoneChart() {

    var v1 = document.getElementById('lblPhoneGradeService').value;//57.88;
    var v2 = document.getElementById('lblPhoneGradeService24').value;//19.01;
    v1 = parseFloat(v1);
    v2 = parseFloat(v2);
    var data1 = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Rolling', v1],
    ]);
    var data2 = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Last 24 hr.', v2]
    ]);



    var chart1 = new google.visualization.Gauge(document.getElementById('chart_div1'));
    chart1.draw(data1, options);
    setInterval(function () {
        data1.setValue(0, 1, v1);
        chart1.draw(data1, options);
    }, 1000);

    var chart2 = new google.visualization.Gauge(document.getElementById('chart_div2'));
    chart2.draw(data2, options);
    setInterval(function () {
        data2.setValue(1, 1, v2);
        chart2.draw(data2, options);
    }, 1000);
}


google.charts.setOnLoadCallback(drawChatChart);
function drawChatChart() {

    var v3 = document.getElementById('lblChatGradeService').value;//57.88;
    var v4 = document.getElementById('lblChatGradeService24').value;//19.01;
    v3 = parseFloat(v3);
    v4 = parseFloat(v4);
    var data3 = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Rolling', v3],
    ]);
    var data4 = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Last 24 hr.', v4]
    ]);



    var chart3 = new google.visualization.Gauge(document.getElementById('chart_div3'));
    chart3.draw(data3, options);
    setInterval(function () {
        data3.setValue(0, 1, v3);
        chart3.draw(data3, options);
    }, 1000);

    var chart4 = new google.visualization.Gauge(document.getElementById('chart_div4'));
    chart4.draw(data4, options);
    setInterval(function () {
        data4.setValue(1, 1, v4);
        chart4.draw(data4, options);
    }, 1000);
}