window.onload = function onLoad() {
 
    startTime();

 

    var phoneENLWT = document.getElementById('HiddenPhoneEnLongestWaitTime').value;
    var phoneENHour = parseInt(phoneENLWT.substr(0, 1), 10);
    var phoneENMinute = parseInt(phoneENLWT.substr(2, 2), 10);
    var phoneENSecond = parseInt(phoneENLWT.substr(-2), 10);
    var phoneENmillisecond = 0;


    var G2TENLWT = document.getElementById('HiddenG2TEnLongestWaitTime').value;
    var G2TENNHour = parseInt(phoneENLWT.substr(0, 1), 10);
    var G2TENMinute = parseInt(phoneENLWT.substr(2, 2), 10);
    var G2TENSecond = parseInt(phoneENLWT.substr(-2), 10);
    var G2TENmillisecond = 0;

    var phoneFrLWT = document.getElementById('HiddenPhoneFrLongestWaitTime').value;
    var phoneFrHour = parseInt(phoneENLWT.substr(0, 1), 10);
    var phoneFrMinute = parseInt(phoneENLWT.substr(2, 2), 10);
    var phoneFrSecond = parseInt(phoneENLWT.substr(-2), 10);
    var phoneFrmillisecond = 0;


    var G2TFrLWT = document.getElementById('HiddenG2TFrLongestWaitTime').value;
    var G2TFrHour = parseInt(phoneENLWT.substr(0, 1), 10);
    var G2TFrMinute = parseInt(phoneENLWT.substr(2, 2), 10);
    var G2TFrSecond = parseInt(phoneENLWT.substr(-2), 10);
    var G2TFrmillisecond = 0;





    var chatWebENLWT = document.getElementById('HiddenChatWebEnLongestWaitTime').value;
    var chatWebENHour = parseInt(chatLWT.substr(0, 1), 10);
    var chatWebENMinute = parseInt(chatLWT.substr(2, 2), 10);
    var chatWebENSecond = parseInt(chatLWT.substr(-2), 10);
    var chatWebENmillisecond = 0;
     
    var chatAppENLWT = document.getElementById('HiddenChatAppEnLongestWaitTime').value;
    var chatAppENHour = parseInt(chatLWT.substr(0, 1), 10);
    var chatAppENMinute = parseInt(chatLWT.substr(2, 2), 10);
    var chatAppENSecond = parseInt(chatLWT.substr(-2), 10);
    var chatAppENmillisecond = 0;
     
    var chatWebFrLWT = document.getElementById('HiddenChatWebFrLongestWaitTime').value;
    var chatWebFrHour = parseInt(chatLWT.substr(0, 1), 10);
    var chatWebFrMinute = parseInt(chatLWT.substr(2, 2), 10);
    var chatWebFrSecond = parseInt(chatLWT.substr(-2), 10);
    var chatWebFrmillisecond = 0;
     
    var chatAppFrLWT = document.getElementById('HiddenChatAppFrLongestWaitTime').value;
    var chatAppFrHour = parseInt(chatLWT.substr(0, 1), 10);
    var chatAppFrMinute = parseInt(chatLWT.substr(2, 2), 10);
    var chatAppFrSecond = parseInt(chatLWT.substr(-2), 10);
    var chatAppFrmillisecond = 0;

    //Timestamp on the left hand
    function startTime() {
        var today = new Date();
        var hr = today.getHours();
        var min = today.getMinutes();
        var sec = today.getSeconds();
        ap = (hr < 12) ? "<span>AM</span>" : "<span>PM</span>";
        hr = (hr == 0) ? 12 : hr;
        hr = (hr > 12) ? hr - 12 : hr;
        //Add a zero in front of numbers<10
        hr = checkTime(hr);
        min = checkTime(min);
        sec = checkTime(sec);
        document.getElementById("clock").innerHTML = hr + ":" + min + ":" + sec + " " + ap;

        var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
        var curWeekDay = days[today.getDay()];
        var curDay = today.getDate();
        var curMonth = months[today.getMonth()];
        var curYear = today.getFullYear();
        var date = curWeekDay + ", " + curDay + " " + curMonth + " " + curYear;
        document.getElementById("date").innerHTML = date;

        var time = setTimeout(function () { startTime() }, 500);
    }
    function checkTime(i) {
        if (i < 10) {
            i = "0" + i;
        }
        return i;
    }


 



    // phone English
    var phoneEnQueued = document.getElementById('HiddenlblInQueue_Phone_ENG').value;
   
    phoneEnQueued = parseInt(phoneEnQueued, 10);
    if (phoneEnQueued > 0) {
 
        tick_PhoneEn_LongestWaitTime();
    } else {
  
        document.getElementById("PhoneEN_LongestWaitTime").innerHTML = "12:34";
    }



    // G2T English
    var G2TEnQueued = document.getElementById('HiddenlblInQueue_G2T_ENG').value;
    G2TEnQueued = parseInt(G2TEnQueued, 10);
    if (G2TEnQueued > 0) {
        tick_G2TEn_LongestWaitTime();
    } else {
        document.getElementById("G2TEN_LongestWaitTime").innerHTML = "00:00";
    }
    // Phone French
    var phoneFrQueued = document.getElementById('HiddenlblInQueue_Phone_FRE').value;
    phoneFrQueued = parseInt(phoneFrQueued, 10);
    if (phoneFrQueued > 0) {
        tick_PhoneFr_LongestWaitTime();
    } else {
        document.getElementById("phoneFR_LongestWaitTime").innerHTML = "00:00";
    }
    // G2T French
    var G2TFrQueued = document.getElementById('HiddenlblInQueue_G2T_FRE').value;
    G2TFrQueued = parseInt(G2TFrQueued, 10);
    if (G2TFrQueued > 0) {
        tick_G2TFr_LongestWaitTime();
    } else {
        document.getElementById("G2TFR_LongestWaitTime").innerHTML = "00:00";
    }

    // Chat Web English
    var ChatWebEnQueued = document.getElementById('HiddenlblInQueue_Chat_ENG').value;
    ChatWebEnQueued = parseInt(ChatWebEnQueued, 10);
    if (ChatWebEnQueued > 0) {
        tick_ChatWebEN_LongestWaitTime();
    } else {
        document.getElementById("cWebEn_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat App English
    var ChatAppEnQueued = document.getElementById('HiddenlblInQueue_ChatApp_ENG').value;
    ChatAppEnQueued = parseInt(ChatAppEnQueued, 10);
    if (ChatAppEnQueued > 0) {
        tick_ChatAppEN_LongestWaitTime();
    } else {
        document.getElementById("cAppEn_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat Web French
    var ChatWebFrQueued = document.getElementById('HiddenlblInQueue_Chat_FRE').value;
    ChatWebFrQueued = parseInt(ChatWebFrQueued, 10);
    if (ChatWebFrQueued > 0) {
        tick_ChatWebFr_LongestWaitTime();
    } else {
        document.getElementById("cWebFr_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat App French
    var ChatAppFrQueued = document.getElementById('HiddenlblInQueue_ChatApp_FRE').value;
    ChatAppFrQueued = parseInt(ChatAppFrQueued, 10);
    if (ChatAppFrQueued > 0) {
        tick_ChatAppFr_LongestWaitTime();
    } else {
        document.getElementById("cAppFr_LongestWaitTime").innerHTML = "00:00";
    }


    function tick_PhoneEn_LongestWaitTime() {
        pmillisecond = pmillisecond + 50;
        if (pmillisecond >= 1000) {
            pmillisecond = 0;
            phoneSecond = phoneSecond + 1;
        }
        if (phoneSecond >= 60) {
            phoneSecond = 0;
            phoneMinute = phoneMinute + 1;
        }
        if (phoneMinute >= 60) {
            phoneMinute = 0;
            phoneHour = phoneHour + 1;
        }

        //Add a zero in front of numbers<10
        hr = checkTime(phoneHour);
        min = checkTime(phoneMinute);
        sec = checkTime(phoneSecond);
        document.getElementById('pLongestWaitTime').innerHTML = hr == 0 ? (min + ':' + sec) : (phoneHour + ':' + min + ':' + sec);
        ticker = setTimeout(function () { tick_PhoneEn_LongestWaitTime() }, 50);
    }

    function tick_G2TEn_LongestWaitTime() {
    }

    function tick_PhoneFr_LongestWaitTime() {
    }

    function tick_G2TFr_LongestWaitTime() {
    }

    function tick_ChatWebEN_LongestWaitTime() {
    }

    function tick_ChatAppEN_LongestWaitTime() {
    }

    function tick_ChatWebFr_LongestWaitTime() {
    }

    function tick_ChatAppFr_LongestWaitTime() {
    }

};