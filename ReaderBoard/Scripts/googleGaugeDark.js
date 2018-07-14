google.charts.load("current", { "packages": ["gauge"] });
google.charts.setOnLoadCallback(drawPhoneChart);

var color1 = "e6005c";
var color2 = "1a1aff";
var color3 = "FFFB33";
var color4 = "9933ff";
var colorGreen = "00FF00";

var options = {
    width: 250, height: 200,  //Gauge height  250*200 id best
    redColor: color1,
    redFrom: 0, redTo: 50,
    yellowColor: color3,
    yellowFrom: 50, yellowTo: 75,
    greenColor: colorGreen,
    greenFrom: 75, greenTo: 100,
    minorTicks: 5


};

function drawPhoneChart() {

    var v1 = document.getElementById("lblPhoneGradeService").value;//57.88;
    var v2 = document.getElementById("lblPhoneGradeService24").value;//19.01;
    v1 = parseFloat(v1);
    v2 = parseFloat(v2);
    var data1 = google.visualization.arrayToDataTable([
        ["Label", "Value"],
        ["Rolling", v1]
    ]);
    var data2 = google.visualization.arrayToDataTable([
        ["Label", "Value"],
        ["Last 24 hr.", v2]
    ]);



    var chart1 = new google.visualization.Gauge(document.getElementById("chart_div1"));
    chart1.draw(data1, options);
    setInterval(function () {
        data1.setValue(0, 1, v1);
        chart1.draw(data1, options);
    }, 1000);

    var chart2 = new google.visualization.Gauge(document.getElementById("chart_div2"));
    chart2.draw(data2, options);
    setInterval(function () {
        data2.setValue(1, 1, v2);
        chart2.draw(data2, options);
    }, 1000);
}


google.charts.setOnLoadCallback(drawChatChart);
function drawChatChart() {

    var v3 = document.getElementById("lblChatGradeService").value;//57.88;
    var v4 = document.getElementById("lblChatGradeService24").value;//19.01;
    v3 = parseFloat(v3);
    v4 = parseFloat(v4);
    var data3 = google.visualization.arrayToDataTable([
        ["Label", "Value"],
        ["Rolling", v3]
    ]);
    var data4 = google.visualization.arrayToDataTable([
        ["Label", "Value"],
        ["Last 24 hr.", v4]
    ]);



    var chart3 = new google.visualization.Gauge(document.getElementById("chart_div3"));
    chart3.draw(data3, options);
    setInterval(function () {
        data3.setValue(0, 1, v3);
        chart3.draw(data3, options);
    }, 1000);

    var chart4 = new google.visualization.Gauge(document.getElementById("chart_div4"));
    chart4.draw(data4, options);
    setInterval(function () {
        data4.setValue(1, 1, v4);
        chart4.draw(data4, options);
    }, 1000);
}


var varHeight = 250;
var chartAreaHeight = "100%";
var chartAreaWidth = "48%";
var bargroupWidth = "75%";
var lablefontsize = 22;

var opt_Phone = {
    height: varHeight,
    isStacked: true,
    bar: { groupWidth: bargroupWidth },
    chartArea: { width: chartAreaWidth, height: chartAreaHeight },
    backgroundColor: { fill: "transparent" },
    legend: "none",
    gridlines: { color: "FF0000"  },
    hAxis: {
        title: "Counselor \n Avail/SignIn",
        titleTextStyle: { color: "FCFCFC", fontSize: 24, bold: true, italic: false },
        format: "#",
        TextStyle: { color: "FCFCFC", fontSize: 28, bold: true },
        colors: ["FCFCFC", "FCFCFC"],
        gridlines: { color: "333333" }
    },
    vAxis: {
        textStyle: {fontSize: 20, bold: true, color: "#FCFCFC"},
        gridlines: { color: "#333333" }
    },
    //colors: ["#e0440e", "#e6693e", "#ec8f6e", "#f3b49f", "#f6c7b6"],


    annotations: {
        textStyle: {
            fontSize: lablefontsize,
            bold: true,
            // The color of the text.
            color: ["FF0000", "00FF00"]
            // The color of the text outline.
            //auraColor: "#d799ae",
            // The transparency of the text.
            // opacity: 1
        }
    }
};




google.charts.load("current", { "packages": ["corechart"] });
google.charts.setOnLoadCallback(drawPhoneCounslor);
function drawPhoneCounslor() {

    //English start
    var sPhoneEN_In = document.getElementById("HiddenPhone_Eng_In").value;
    var PhoneEN_In = parseInt(sPhoneEN_In);
    PhoneEN_In = PhoneEN_In < 1 ? null : PhoneEN_In;

    var sPhoneEN_Avai = document.getElementById("HiddenPhone_Eng_Availabe").value;
    var PhoneEN_Avai = parseInt(sPhoneEN_Avai);
    PhoneEN_Avai = PhoneEN_Avai < 1 ? null : PhoneEN_Avai;

    var sPhoneEN_onContact = document.getElementById("HiddenPhone_Eng_AgentOnContact").value;
    var PhoneEN_onContact = parseInt(sPhoneEN_onContact);
    PhoneEN_onContact = PhoneEN_onContact < 1 ? null : PhoneEN_onContact;

    var phoneEN_NotReady = PhoneEN_In - PhoneEN_Avai - PhoneEN_onContact;
    phoneEN_NotReady = phoneEN_NotReady < 1 ? null : phoneEN_NotReady;

    var busyPhoneEn = PhoneEN_In - PhoneEN_Avai;
    busyPhoneEn = busyPhoneEn < 1 ? null : busyPhoneEn;

    // French Start
    var sPhoneFr_In = document.getElementById("HiddenPhone_Fre_In").value;
    var PhoneFr_In = parseInt(sPhoneFr_In);
    PhoneFr_In = PhoneFr_In < 1 ? null : PhoneFr_In;

    var sPhoneFr_Avai = document.getElementById("HiddenPhone_Fre_Availabe").value;
    var PhoneFr_Avai = parseInt(sPhoneFr_Avai);
    PhoneFr_Avai = PhoneFr_Avai < 1 ? null : PhoneFr_Avai;

    var sPhoneFR_onContact = document.getElementById("HiddenPhone_Fre_AgentOnContact").value;
    var PhoneFR_onContact = parseInt(sPhoneFR_onContact);
    PhoneFR_onContact = PhoneFR_onContact < 1 ? null : PhoneFR_onContact;

    var busyPhoneFr = PhoneFr_In - PhoneFr_Avai;
    busyPhoneFr = busyPhoneFr < 1 ? null : busyPhoneFr;

    var phoneFR_NotReady = PhoneFr_In - PhoneFr_Avai - PhoneFR_onContact;
    phoneFR_NotReady = phoneFR_NotReady < 1 ? null : phoneFR_NotReady;

    //G2T EN start
    var sG2Ten_In = document.getElementById("HiddenG2T_Eng_In").value;
    var G2Ten_In = parseInt(sG2Ten_In);
    G2Ten_In = G2Ten_In < 1 ? null : G2Ten_In;

    var sG2Ten_Avai = document.getElementById("HiddenG2T_Eng_Availabe").value;
    var G2Ten_Avai = parseInt(sG2Ten_Avai);
    G2Ten_Avai = G2Ten_Avai < 1 ? null : G2Ten_Avai;

    var sG2Ten_onContact = document.getElementById("HiddenG2T_Eng_AgentOnContact").value;
    var G2Ten_onContact = parseInt(sG2Ten_onContact);
    G2Ten_onContact = G2Ten_onContact < 1 ? null : G2Ten_onContact;

    var busyG2TEn = G2Ten_In - G2Ten_Avai;
    busyG2TEn = busyG2TEn < 1 ? null : busyG2TEn;

    var G2TEN_NotReady = G2Ten_In - G2Ten_Avai - G2Ten_onContact;
    G2TEN_NotReady = G2TEN_NotReady < 1 ? null : G2TEN_NotReady;


    ////G2T FR start
    var sG2Tfr_In = document.getElementById("HiddenG2T_Fre_In").value;
    var G2Tfr_In = parseInt(sG2Tfr_In);
    G2Tfr_In = G2Tfr_In < 1 ? null : G2Tfr_In;

    var sG2Tfr_OnContact = document.getElementById("HiddenG2T_Fre_AgentOnContact").value;
    var G2Tfr_OnContact = parseInt(sG2Tfr_OnContact);
    G2Tfr_OnContact = G2Tfr_OnContact < 1 ? null : G2Tfr_OnContact;

    var sG2Tfr_Avai = document.getElementById("HiddenG2T_Fre_Availabe").value;
    var G2Tfr_Avai = parseInt(sG2Tfr_Avai);
    G2Tfr_Avai = G2Tfr_Avai < 1 ? null : G2Tfr_Avai;

    var busyG2TFr = G2Tfr_In - G2Tfr_Avai;
    busyG2TFr = busyG2TFr < 1 ? null : busyG2TFr;

    var G2Tfr_NotReady = G2Tfr_In - G2Tfr_Avai - G2Tfr_OnContact;
    G2Tfr_NotReady = G2Tfr_NotReady < 1 ? null : G2Tfr_NotReady;

    var PhoneData = google.visualization.arrayToDataTable([
        ["Queue", "Availabe", { role: "style" }, { role: "annotation" }, "OnContact", { role: "style" }, { role: "annotation" }, "NotReady", { role: "style" }, { role: "annotation" }],
        ["English", PhoneEN_Avai, colorGreen, PhoneEN_Avai, PhoneEN_onContact, color1, PhoneEN_onContact, busyPhoneEn, color2, busyPhoneEn],
        ["French", PhoneFr_Avai, colorGreen, PhoneFr_Avai, PhoneFR_onContact, color1, PhoneFR_onContact, phoneFR_NotReady, color2, phoneFR_NotReady],
        ["G2T En", G2Ten_Avai, colorGreen, G2Ten_Avai, G2Ten_onContact, color1, G2Ten_onContact, G2TEN_NotReady, color2, G2TEN_NotReady],
        ["G2T Fr", G2Tfr_Avai, colorGreen, G2Tfr_Avai, G2Tfr_OnContact, color1, G2Tfr_OnContact, G2Tfr_NotReady, color2, G2Tfr_NotReady]
    ]);



    //document.getElementById("lblPhoneCounselorLogin").innerText = busyPhoneEn + busyPhoneFr + busyG2TEn + busyG2TFr;
    var Phonechart = new google.visualization.BarChart(document.getElementById("PhoneCounslor"));
    Phonechart.draw(PhoneData, opt_Phone);
}





google.charts.setOnLoadCallback(drawChatCounslor);
function drawChatCounslor() {
    var sChatEN_In = document.getElementById("HiddenWebChat_Eng_In").value;
    var ChatEN_In = parseInt(sChatEN_In);
    var sChatEN_Avai = document.getElementById("HiddenWebChat_Eng_Avaiable").value;
    var ChatEN_Avai = parseInt(sChatEN_Avai);
    var busyChatEn = ChatEN_In - ChatEN_Avai;

    var sChatFr_In = document.getElementById("HiddenWebChat_Fre_In").value;
    var ChatFr_In = parseInt(sChatFr_In);
    var sChatFr_Avai = document.getElementById("HiddenWebChat_Fre_Avaiable").value;
    var ChatFr_Avai = parseInt(sChatFr_Avai);
    var busyChatFr = ChatFr_In - ChatFr_Avai;

    var sChatAppEN_In = document.getElementById("HiddenChatApp_Eng_In").value;
    var ChatAppEN_In = parseInt(sChatAppEN_In);
    var sChatAppEN_Avai = document.getElementById("HiddenChatApp_Eng_Avaiable").value;
    var ChatAppEN_Avai = parseInt(sChatAppEN_Avai);
    var busyChatAppEn = ChatAppEN_In - ChatAppEN_Avai;

    var sChatAppfr_In = document.getElementById("HiddenChatApp_Fre_In").value;
    var ChatAppfr_In = parseInt(sChatAppfr_In);
    var sChatAppfr_Avai = document.getElementById("HiddenChatApp_Fre_Avaiable").value;
    var ChatAppfr_Avai = parseInt(sChatAppfr_Avai);
    var busyChatAppFr = ChatAppfr_In - ChatAppfr_Avai;


    var ChatData = google.visualization.arrayToDataTable([
        ["Queue", "Availabe", { role: "style" }, { role: "annotation" }, "SignIn", { role: "style" }, { role: "annotation" }],
        ["Web En", ChatEN_Avai, colorGreen, ChatEN_Avai, busyChatEn, color1, busyChatEn],
        ["Web Fr", ChatFr_Avai, colorGreen, ChatFr_Avai, busyChatFr, color2, busyChatFr],
        ["App En", ChatAppEN_Avai, colorGreen, ChatAppEN_Avai, busyChatAppEn, color3, busyChatAppEn],
        ["App Fr", ChatAppfr_Avai, colorGreen, ChatAppfr_Avai, busyChatAppFr, color4, busyChatAppFr]
    ]);

    document.getElementById("lblChatCounselorLogin").innerText = busyChatEn + busyChatFr + busyChatAppEn + busyChatAppFr;
    var Phonechart = new google.visualization.BarChart(document.getElementById("ChatCounslor"));
    Phonechart.draw(ChatData, opt_Phone);
}