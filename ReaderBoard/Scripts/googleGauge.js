google.charts.load("current", { "packages": ["gauge"] });
google.charts.setOnLoadCallback(drawPhoneChart);

var colorPink = "F45B69";  //pink 4062BB
var colorBlue = "4062BB";  //blue #1a1aff
var colorYellow = "FFFB33";  //yellow
var colorPuler = "9933ff"; //puler
var colorGreen = "4CAF50";
var colorBlack = "333333";
var colorWhite = "FCFCFC";

var dayTimeStart = 8; //= document.getElementById('HiddendayTimeStart').value;

var dayTimeEnd = 17;  //= document.getElementById('HiddendayTimeEnd').value;
 
var hours = new Date();
 
 
var options = {
    width: 250, height: 200,  //Gauge height  250*200 id best
    redColor: colorPink,
    redFrom: 0, redTo: 50,
    yellowColor: colorYellow,
    yellowFrom: 50, yellowTo: 75,
    greenColor: colorGreen,
    greenFrom: 75, greenTo: 100,
    minorTicks: 5,
    majorTicks: ["", ""],
    minorTicks: 0, 
    backgroundColor: { fill: "000000", stroke: "red" },
};

function drawPhoneChart() {

    var v1 = document.getElementById("lblPhoneGradeService").value;//57.88;
    var v2 = document.getElementById("lblPhoneGradeService24").value;//19.01;
    v1 = parseFloat(v1);
    v2 = parseFloat(v2);
    var data1 = google.visualization.arrayToDataTable([
        ["Label", "Value"],
        ["Rolling", v1],
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
        ["Rolling", v3],
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


var varHeight = 280;
var chartAreaHeight = "95%";
var chartAreaWidth = "68%";
var bargroupWidth = "75%";
var lablefontsize = 22;
 
var opt_Phone = {
    height: varHeight,
    isStacked: 'percent',
    //legend: { position: 'top', maxLines: 3, textStyle: { color: colorBlack, fontSize: 14, bold: true } },
    legend: { position: 'none' },
    bar: { groupWidth: bargroupWidth },
    chartArea: { left: 95, top:15, width: chartAreaWidth, height: chartAreaHeight},
    backgroundColor: { fill: "transparent" },
    colors: [colorGreen, colorBlue, colorPink],

    hAxis: { // actual H.
        TextStyle: { color: colorBlack, fontSize: 20, bold: true, italic: false },
        textPosition: 'none',
        gridlines: { color: 'transparent' },
        baselineColor: "none" 
    },
    vAxis: { //actual V
        textStyle: { color: colorBlack, fontSize: 20, bold: true, italic: false },
        gridlines: { color: 'transparent' },
        baselineColor:"none"
    },
  


    annotations: {
        textStyle: {
            fontSize: lablefontsize,
            bold: true,
            alwaysOutside: false,
            // The color of the text.
            color: ["FF0000", "00FF00"],
            // The color of the text outline.
            //auraColor: "#d799ae",
            // The transparency of the text.
            opacity: 1 // annotations text font opacity, 1 = no-transparent; 0 fully transparent
        }
    },
};

//william means in day time
if (dayTimeStart <= hours.getHours() && hours.getHours() <= dayTimeEnd - 1) {
    opt_Phone.vAxis.textStyle.color = colorBlack;
}
else {
    opt_Phone.vAxis.textStyle.color = colorWhite;
};



google.charts.load("current", { "packages": ["corechart"] });
google.charts.setOnLoadCallback(drawPhoneCounslor);
function drawPhoneCounslor() {
    
    //English start
    var sPhoneEN_In = document.getElementById("HiddenPhone_Eng_In").value;
    var PhoneEN_In = parseInt(sPhoneEN_In);
    var lPhoneEN_In = PhoneEN_In === 0 ? null : PhoneEN_In;

    var sPhoneEN_Avai = document.getElementById("HiddenPhone_Eng_Availabe").value;
    var PhoneEN_Avai = parseInt(sPhoneEN_Avai);
    var lPhoneEN_Avai = PhoneEN_Avai === 0 ? null : PhoneEN_Avai;

    var sPhoneEN_onContact = document.getElementById("HiddenPhone_Eng_AgentOnContact").value;
    var PhoneEN_onContact = parseInt(sPhoneEN_onContact);
    var lPhoneEN_onContact = PhoneEN_onContact === 0 ? null : PhoneEN_onContact;

    var phoneEN_NotReady = PhoneEN_In - PhoneEN_Avai - PhoneEN_onContact;
    var lphoneEN_NotReady = phoneEN_NotReady === 0 ? null : phoneEN_NotReady;

    var busyPhoneEn = PhoneEN_In - PhoneEN_Avai;
    var lbusyPhoneEn = busyPhoneEn === 0 ? null : busyPhoneEn;

    // French Start
    var sPhoneFr_In = document.getElementById("HiddenPhone_Fre_In").value;
    var PhoneFr_In = parseInt(sPhoneFr_In);
    var lPhoneFr_In = PhoneFr_In === 0 ? null : PhoneFr_In;

    var sPhoneFr_Avai = document.getElementById("HiddenPhone_Fre_Availabe").value;
    var PhoneFr_Avai = parseInt(sPhoneFr_Avai);
    var lPhoneFr_Avai = PhoneFr_Avai === 0 ? null : PhoneFr_Avai;

    var sPhoneFR_onContact = document.getElementById("HiddenPhone_Fre_AgentOnContact").value;
    var PhoneFR_onContact = parseInt(sPhoneFR_onContact);
    var lPhoneFR_onContact = PhoneFR_onContact === 0 ? null : PhoneFR_onContact;

    var busyPhoneFr = PhoneFr_In - PhoneFr_Avai;
    var lbusyPhoneFr = busyPhoneFr === 0 ? null : busyPhoneFr;

    var phoneFR_NotReady = PhoneFr_In - PhoneFr_Avai - PhoneFR_onContact;
    var lphoneFR_NotReady = phoneFR_NotReady === 0 ? null : phoneFR_NotReady;

    //G2T EN start
    var sG2Ten_In = document.getElementById("HiddenG2T_Eng_In").value;
    var G2Ten_In = parseInt(sG2Ten_In);
    var lG2Ten_In = G2Ten_In === 0 ? null : G2Ten_In;

    var sG2Ten_Avai = document.getElementById("HiddenG2T_Eng_Availabe").value;
    var G2Ten_Avai = parseInt(sG2Ten_Avai);
    var lG2Ten_Avai = G2Ten_Avai === 0 ? null : G2Ten_Avai;

    var sG2Ten_onContact = document.getElementById("HiddenG2T_Eng_AgentOnContact").value;
    var G2Ten_onContact = parseInt(sG2Ten_onContact);
    var lG2Ten_onContact = G2Ten_onContact === 0 ? null : G2Ten_onContact;

    var busyG2TEn = G2Ten_In - G2Ten_Avai;
    var lbusyG2TEn = busyG2TEn === 0 ? null : busyG2TEn;

    var G2TEN_NotReady = G2Ten_In - G2Ten_Avai - G2Ten_onContact;
    var lG2TEN_NotReady = G2TEN_NotReady === 0 ? null : G2TEN_NotReady;


    ////G2T FR start
    var sG2Tfr_In = document.getElementById("HiddenG2T_Fre_In").value;
    var G2Tfr_In = parseInt(sG2Tfr_In);
    var lG2Tfr_In = G2Tfr_In === 0 ? null : G2Tfr_In;

    var sG2Tfr_OnContact = document.getElementById("HiddenG2T_Fre_AgentOnContact").value;
    var G2Tfr_OnContact = parseInt(sG2Tfr_OnContact);
    var lG2Tfr_OnContact = G2Tfr_OnContact === 0 ? null : G2Tfr_OnContact;

    var sG2Tfr_Avai = document.getElementById("HiddenG2T_Fre_Availabe").value;
    var G2Tfr_Avai = parseInt(sG2Tfr_Avai);
    var lG2Tfr_Avai = G2Tfr_Avai === 0 ? null : G2Tfr_Avai;

    var busyG2TFr = G2Tfr_In - G2Tfr_Avai;
    busyG2TFr = busyG2TFr == 0 ? null : busyG2TFr;

    var G2Tfr_NotReady = G2Tfr_In - G2Tfr_Avai - G2Tfr_OnContact;
    var lG2Tfr_NotReady = G2Tfr_NotReady === 0 ? null : G2Tfr_NotReady;

    var PhoneData = google.visualization.arrayToDataTable([
        ["Queue", "Availabe", { role: "style" }, { role: "annotation" }, "On Contact", { role: "style" }, { role: "annotation" }, "Not Ready", { role: "style" }, { role: "annotation" }],
        ["English", PhoneEN_Avai, colorGreen, lPhoneEN_Avai, PhoneEN_onContact, colorBlue, lPhoneEN_onContact, phoneEN_NotReady, colorPink, lphoneEN_NotReady],
        ["French", PhoneFr_Avai, colorGreen, lPhoneFr_Avai, PhoneFR_onContact, colorBlue, lPhoneFR_onContact, phoneFR_NotReady, colorPink, lphoneFR_NotReady],
        ["G2T En", G2Ten_Avai, colorGreen, lG2Ten_Avai, G2Ten_onContact, colorBlue, lG2Ten_onContact, G2TEN_NotReady, colorPink, lG2TEN_NotReady],
        ["G2T Fr", G2Tfr_Avai, colorGreen, lG2Tfr_Avai, G2Tfr_OnContact, colorBlue, lG2Tfr_OnContact, G2Tfr_NotReady, colorPink, lG2Tfr_NotReady]
    ]);
     


    //document.getElementById("lblPhoneCounselorLogin").innerText = busyPhoneEn + busyPhoneFr + busyG2TEn + busyG2TFr;
    var Phonechart = new google.visualization.BarChart(document.getElementById("PhoneCounslor"));
    Phonechart.draw(PhoneData, opt_Phone);
}


google.charts.setOnLoadCallback(drawChatCounslor);
function drawChatCounslor() {
    var sChatEN_In = document.getElementById("HiddenWebChat_Eng_In").value;
    var ChatEN_In = parseInt(sChatEN_In);
    var lChatEN_In = ChatEN_In ===0 ? null : ChatEN_In;

    var sChatEN_Avai = document.getElementById("HiddenWebChat_Eng_Avaiable").value;
    var ChatEN_Avai = parseInt(sChatEN_Avai);
    var lChatEN_Avai = ChatEN_Avai ===0 ? null : ChatEN_Avai;

    var sChatEn_OnContact = document.getElementById("HiddenWebChat_Eng_AgentOnContact").value;
    var ChatEn_OnContact = parseInt(sChatEn_OnContact);
    var lChatEn_OnContact = ChatEn_OnContact ===0 ? null : ChatEn_OnContact;

    var ChatEn_NoteRady = ChatEN_In - ChatEN_Avai - ChatEn_OnContact;
    var lChatEn_NoteRady = ChatEn_NoteRady ===0 ? null : ChatEn_NoteRady;

    var busyChatEn = ChatEN_In - ChatEN_Avai;
    var lbusyChatEn = busyChatEn ===0 ? null : busyChatEn;

    var sChatFr_In = document.getElementById("HiddenWebChat_Fre_In").value;
    var ChatFr_In = parseInt(sChatFr_In);
    var lChatFr_In = ChatFr_In ===0? null: ChatFr_In;

    var sChatFr_Avai = document.getElementById("HiddenWebChat_Fre_Avaiable").value;
    var ChatFr_Avai = parseInt(sChatFr_Avai);
    var lChatFr_Avai = ChatFr_Avai ===0 ? null : ChatFr_Avai;

    var sChatFr_OnContact = document.getElementById("HiddenWebChat_Fre_AgentOnContact").value;
    var ChatFr_OnContact = parseInt(sChatFr_OnContact);
    var lChatFr_OnContact = ChatFr_OnContact ===0 ? null : ChatFr_OnContact;

    var ChatFr_NotReady = ChatFr_In - ChatFr_Avai - ChatFr_OnContact;
    var lChatFr_NotReady = ChatFr_NotReady ===0 ? null : ChatFr_NotReady;

    var busyChatFr = ChatFr_In - ChatFr_Avai;
    var lbusyChatFr = busyChatFr ===0 ? null : busyChatFr;

    var sChatAppEN_In = document.getElementById("HiddenChatApp_Eng_In").value;
    var ChatAppEN_In = parseInt(sChatAppEN_In);
    var lChatAppEN_In = ChatAppEN_In ===0 ? null : ChatAppEN_In;

    var sChatAppEN_Avai = document.getElementById("HiddenChatApp_Eng_Avaiable").value;
    var ChatAppEN_Avai = parseInt(sChatAppEN_Avai);
    var lChatAppEN_Avai = ChatAppEN_Avai ===0 ? null : ChatAppEN_Avai;

    var sChatAppEn_OnContact = document.getElementById("HiddenChatApp_Eng_AgentOnContact").value;
    var ChatAppEn_OnContact = parseInt(sChatAppEn_OnContact);
    var lChatAppEn_OnContact = ChatAppEn_OnContact ===0 ? null : ChatAppEn_OnContact;

    var ChatAppEn_NotReady = ChatAppEN_In - ChatAppEN_Avai - ChatAppEn_OnContact;
    var lChatAppEn_NotReady = ChatAppEn_NotReady ===0 ? null : ChatAppEn_NotReady;

    var busyChatAppEn = ChatAppEN_In - ChatAppEN_Avai;
    var lbusyChatAppEn = busyChatAppEn ===0 ? null : busyChatAppEn;

    var sChatAppfr_In = document.getElementById("HiddenChatApp_Fre_In").value;
    var ChatAppfr_In = parseInt(sChatAppfr_In);
    var lChatAppfr_In = ChatAppfr_In ===0 ? null : ChatAppfr_In;

    var sChatAppfr_Avai = document.getElementById("HiddenChatApp_Fre_Avaiable").value;
    var ChatAppfr_Avai = parseInt(sChatAppfr_Avai);
    var lChatAppfr_Avai = ChatAppfr_Avai ===0 ? null : ChatAppfr_Avai;

    var sChatAppFr_OnContact = document.getElementById("HiddenChatApp_Fre_AgentOnContact").value;
    var ChatAppFr_OnContact = parseInt(sChatAppFr_OnContact);
    var lChatAppFr_OnContact = ChatAppFr_OnContact ===0 ? null : ChatAppFr_OnContact;

    var ChatAppFr_NotReady = ChatAppfr_In - ChatAppfr_Avai - ChatAppFr_OnContact;
    var lChatAppFr_NotReady = ChatAppFr_NotReady ===0 ? null : ChatAppFr_NotReady;

    var busyChatAppFr = ChatAppfr_In - ChatAppfr_Avai;
    var lbusyChatAppFr = busyChatAppFr ===0 ? null : busyChatAppFr;


    var ChatData = google.visualization.arrayToDataTable([
        ["Queue", "Availabe", { role: "style" }, { role: "annotation" }, "OnContact", { role: "style" }, { role: "annotation" }, "NotReady", { role: "style" }, { role: "annotation" }],
        ["Web En", ChatEN_Avai, colorGreen, lChatEN_Avai, ChatEn_OnContact, colorBlue, lChatEn_OnContact, ChatEn_NoteRady, colorPink, lChatEn_NoteRady],
        ["Web Fr", ChatFr_Avai, colorGreen, lChatFr_Avai, ChatFr_OnContact, colorBlue, lChatFr_OnContact, ChatFr_NotReady, colorPink, lChatFr_NotReady],
        ["App En", ChatAppEN_Avai, colorGreen, lChatAppEN_Avai, ChatAppEn_OnContact, colorBlue, lChatAppEn_OnContact, ChatAppEn_NotReady, colorPink, lChatAppEn_NotReady],
        ["App Fr", ChatAppfr_Avai, colorGreen, lChatAppfr_Avai, ChatAppFr_OnContact, colorBlue, lChatAppFr_OnContact, ChatAppFr_NotReady, colorPink, lChatAppFr_NotReady]
    ]);

    //document.getElementById("lblChatCounselorLogin").innerText = busyChatEn + busyChatFr + busyChatAppEn + busyChatAppFr;
    var Phonechart = new google.visualization.BarChart(document.getElementById("ChatCounslor"));
    Phonechart.draw(ChatData, opt_Phone);
}