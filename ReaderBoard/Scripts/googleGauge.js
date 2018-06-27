google.charts.load('current', { 'packages': ['gauge'] });
google.charts.setOnLoadCallback(drawPhoneChart);

var options = {
    width: 250,   height:220,  //Gauge height  250*220 id best
    redColor: "#FF00FF",
    redFrom: 0, redTo: 50,
    yellowColor: "#FFFF00",
    yellowFrom: 50, yellowTo: 75,
    greenColor: "00FF00",
    greenFrom: 75, greenTo: 100,
    minorTicks: 5
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





google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawPhoneCounslor);
function drawPhoneCounslor() {
    var sPhoneEN_In = document.getElementById('HiddenPhone_Eng_In').value;
    var PhoneEN_In = parseInt(sPhoneEN_In);
    var sPhoneEN_Avai = document.getElementById('HiddenPhone_Eng_Availabe').value;
    var PhoneEN_Avai = parseInt(sPhoneEN_Avai);

    var sPhoneFr_In = document.getElementById('HiddenPhone_Fre_In').value;
    var PhoneFr_In = parseInt(sPhoneFr_In);
    var sPhoneFr_Avai = document.getElementById('HiddenPhone_Fre_Availabe').value;
    var PhoneFr_Avai = parseInt(sPhoneFr_Avai);

    var sG2Ten_In = document.getElementById('HiddenG2T_Eng_In').value;
    var G2Ten_In = parseInt(sG2Ten_In);
    var sG2Ten_Avai = document.getElementById('HiddenG2T_Eng_Availabe').value;
    var G2Ten_Avai = parseInt(sG2Ten_Avai);

    var sG2Tfr_In = document.getElementById('HiddenG2T_Fre_In').value;
    var G2Tfr_In = parseInt(sG2Tfr_In);
    var sG2Tfr_Avai = document.getElementById('HiddenG2T_Fre_Availabe').value;
    var G2Tfr_Avai = parseInt(sG2Tfr_Avai);


    var PhoneData = google.visualization.arrayToDataTable([
        ['Queue', 'Availabe', { role: 'style' }, { role: 'annotation' }, 'SignIn', { role: 'style' }, { role: 'annotation' }],
        ['Phone En', PhoneEN_Avai, '#00FF00', PhoneEN_Avai, PhoneEN_In - PhoneEN_Avai, '#FF0000', PhoneEN_In ],
        ['Phone Fr', PhoneFr_Avai, '#00FF00', PhoneFr_Avai, PhoneFr_In - PhoneFr_Avai, '#00FFFF', PhoneFr_In ],
        ['G2T En', G2Ten_Avai, '#00FF00', G2Ten_Avai, G2Ten_In - G2Ten_Avai, '#0000FF', G2Ten_In],
        ['G2T Fr', G2Tfr_Avai, '#00FF00', G2Tfr_Avai, G2Tfr_In - G2Tfr_Avai, '#FF0FFF', G2Tfr_In]
    ]);

    var opt_Phone = {
        //title: "Counslor status",
        width: 300, height: 300, isStacked: true,
        bar: { groupWidth: '75%' },
        legend: 'none',
        //vAxis: { title: "Queue" },
        hAxis: {
            title: "Counslor Availabe / SignIn",
            //color: '#FF0000',
            //fontSize: 20,
        },

        annotations: {
            textStyle: {
                fontSize: 18,

                bold: true,
                // The color of the text.
                color: '#FF0000',
                // The color of the text outline.
                //auraColor: '#d799ae',
                // The transparency of the text.
                // opacity: 1
            }
        },
    };
    var Phonechart = new google.visualization.BarChart(document.getElementById('PhoneCounslor'));
    Phonechart.draw(PhoneData, opt_Phone);
}





google.charts.setOnLoadCallback(drawChatCounslor);
function drawChatCounslor() {
    var sPhoneEN_In = document.getElementById('HiddenPhone_Eng_In').value;
    var PhoneEN_In = parseInt(sPhoneEN_In);
    var sPhoneEN_Avai = document.getElementById('HiddenPhone_Eng_Availabe').value;
    var PhoneEN_Avai = parseInt(sPhoneEN_Avai);

    var sPhoneFr_In = document.getElementById('HiddenPhone_Fre_In').value;
    var PhoneFr_In = parseInt(sPhoneFr_In);
    var sPhoneFr_Avai = document.getElementById('HiddenPhone_Fre_Availabe').value;
    var PhoneFr_Avai = parseInt(sPhoneFr_Avai);

    var sG2Ten_In = document.getElementById('HiddenG2T_Eng_In').value;
    var G2Ten_In = parseInt(sG2Ten_In);
    var sG2Ten_Avai = document.getElementById('HiddenG2T_Eng_Availabe').value;
    var G2Ten_Avai = parseInt(sG2Ten_Avai);

    var sG2Tfr_In = document.getElementById('HiddenG2T_Fre_In').value;
    var G2Tfr_In = parseInt(sG2Tfr_In);
    var sG2Tfr_Avai = document.getElementById('HiddenG2T_Fre_Availabe').value;
    var G2Tfr_Avai = parseInt(sG2Tfr_Avai);


    var ChatData = google.visualization.arrayToDataTable([
        ['Queue', 'Availabe', { role: 'style' }, { role: 'annotation' }, 'SignIn', { role: 'style' }, { role: 'annotation' }],
        ['Phone En', PhoneEN_Avai, '#00FF00', PhoneEN_Avai, PhoneEN_In - PhoneEN_Avai, '#FF0000', PhoneEN_In],
        ['Phone Fr', PhoneFr_Avai, '#00FF00', PhoneFr_Avai, PhoneFr_In - PhoneFr_Avai, '#00FFFF', PhoneFr_In],
        ['G2T En', G2Ten_Avai, '#00FF00', G2Ten_Avai, G2Ten_In - G2Ten_Avai, '#0000FF', G2Ten_In],
        ['G2T Fr', G2Tfr_Avai, '#00FF00', G2Tfr_Avai, G2Tfr_In - G2Tfr_Avai, '#FF0FFF', G2Tfr_In]
    ]);

    var opt_Chat = {
        //title: "Counslor status",
        width: 300, height: 300, isStacked: true,
        bar: { groupWidth: '75%' },
        legend: 'none',
        //vAxis: { title: "Queue" },
        hAxis: {
            title: "Counslor Availabe / SignIn",
            //color: '#FF0000',
            //fontSize: 20,
        },

        annotations: {
            textStyle: {
                fontSize: 18,

                bold: true,
                // The color of the text.
                color: '#FF0000',
                // The color of the text outline.
                //auraColor: '#d799ae',
                // The transparency of the text.
                // opacity: 1
            }
        },
    };
    var Phonechart = new google.visualization.BarChart(document.getElementById('ChatCounslor'));
    Phonechart.draw(ChatData, opt_Chat);
}