window.onload = function onLoad() {
 
    startTime();

 

    var phoneENLWT = document.getElementById('HiddenPhoneEnLongestWaitTime').value;
    var phoneENHour =   parseInt(phoneENLWT.substr(0, 1), 10);
    var phoneENMinute = parseInt(phoneENLWT.substr(2, 2), 10);
    var phoneENSecond = parseInt(phoneENLWT.substr(-2), 10);
    var phoneENmillisecond = 0;


    var G2TENLWT = document.getElementById('HiddenG2TEnLongestWaitTime').value;
    var G2TENNHour =  parseInt(G2TENLWT.substr(0, 1), 10);
    var G2TENMinute = parseInt(G2TENLWT.substr(2, 2), 10);
    var G2TENSecond = parseInt(G2TENLWT.substr(-2), 10);
    var G2TENmillisecond = 0;

    var HlthENLWT = document.getElementById('HiddenHlthEnLongestWaitTime').value;
    var HlthENNHour =  parseInt(HlthENLWT.substr(0, 1), 10);
    var HlthENMinute = parseInt(HlthENLWT.substr(2, 2), 10);
    var HlthENSecond = parseInt(HlthENLWT.substr(-2), 10);
    var HlthENmillisecond = 0;

    var phoneFrLWT = document.getElementById('HiddenPhoneFrLongestWaitTime').value;
    var phoneFrHour =   parseInt(phoneFrLWT.substr(0, 1), 10);
    var phoneFrMinute = parseInt(phoneFrLWT.substr(2, 2), 10);
    var phoneFrSecond = parseInt(phoneFrLWT.substr(-2), 10);
    var phoneFrmillisecond = 0;


    var G2TFrLWT = document.getElementById('HiddenG2TFrLongestWaitTime').value;
    var G2TFrHour =   parseInt(G2TFrLWT.substr(0, 1), 10);
    var G2TFrMinute = parseInt(G2TFrLWT.substr(2, 2), 10);
    var G2TFrSecond = parseInt(G2TFrLWT.substr(-2), 10);
    var G2TFrmillisecond = 0;

    var HlthFrLWT = document.getElementById('HiddenHlthFrLongestWaitTime').value;
    var HlthFrHour =   parseInt(HlthFrLWT.substr(0, 1), 10);
    var HlthFrMinute = parseInt(HlthFrLWT.substr(2, 2), 10);
    var HlthFrSecond = parseInt(HlthFrLWT.substr(-2), 10);
    var HlthFrmillisecond = 0;




    var chatWebENLWT = document.getElementById('HiddenChatWebEnLongestWaitTime').value;
    var chatWebENHour = parseInt(chatWebENLWT.substr(0, 1), 10);
    var chatWebENMinute = parseInt(chatWebENLWT.substr(2, 2), 10);
    var chatWebENSecond = parseInt(chatWebENLWT.substr(-2), 10);
    var chatWebENmillisecond = 0;
     
    var chatAppENLWT = document.getElementById('HiddenChatAppEnLongestWaitTime').value;
    var chatAppENHour = parseInt(chatAppENLWT.substr(0, 1), 10);
    var chatAppENMinute = parseInt(chatAppENLWT.substr(2, 2), 10);
    var chatAppENSecond = parseInt(chatAppENLWT.substr(-2), 10);
    var chatAppENmillisecond = 0;
     
    var chatWebFrLWT = document.getElementById('HiddenChatWebFrLongestWaitTime').value;
    var chatWebFrHour = parseInt(chatWebFrLWT.substr(0, 1), 10);
    var chatWebFrMinute = parseInt(chatWebFrLWT.substr(2, 2), 10);
    var chatWebFrSecond = parseInt(chatWebFrLWT.substr(-2), 10);
    var chatWebFrmillisecond = 0;
     
    var chatAppFrLWT = document.getElementById('HiddenChatAppFrLongestWaitTime').value;
    var chatAppFrHour = parseInt(chatAppFrLWT.substr(0, 1), 10);
    var chatAppFrMinute = parseInt(chatAppFrLWT.substr(2, 2), 10);
    var chatAppFrSecond = parseInt(chatAppFrLWT.substr(-2), 10);
    var chatAppFrmillisecond = 0;

    //Timestamp on the left hand
    function startTime() {
        var today = new Date();
        var hr = today.getHours();
        var min = today.getMinutes();
        var sec = today.getSeconds();
        ap = (hr < 12) ? "<span>AM</span>" : "<span>PM</span>";
        hr = (hr === 0) ? 12 : hr;
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
 
        ticks("PhoneEN_LongestWaitTime", phoneENmillisecond, phoneENSecond, phoneENMinute, phoneENHour);
    } else {
  
        document.getElementById("PhoneEN_LongestWaitTime").innerHTML = "00:00";
    }



    // G2T English
    var G2TEnQueued = document.getElementById('HiddenlblInQueue_G2T_ENG').value;
    G2TEnQueued = parseInt(G2TEnQueued, 10);
    if (G2TEnQueued > 0) {
        ticks("G2TEN_LongestWaitTime", G2TENmillisecond, G2TENSecond, G2TENMinute, G2TENNHour);
    } else {
        document.getElementById("G2TEN_LongestWaitTime").innerHTML = "00:00";
    }

    // Health English
    var HlthEnQueued = document.getElementById('HiddenlblInQueue_Hlth_ENG').value;
    HlthEnQueued = parseInt(HlthEnQueued, 10);
    if (HlthEnQueued > 0) {
        ticks("HlthEN_LongestWaitTime", HlthENmillisecond, HlthENSecond, HlthENMinute, HlthENNHour);
    } else {
        document.getElementById("HlthEN_LongestWaitTime").innerHTML = "00:00";
    }


    // Phone French
    var phoneFrQueued = document.getElementById('HiddenlblInQueue_Phone_FRE').value;
    phoneFrQueued = parseInt(phoneFrQueued, 10);
    if (phoneFrQueued > 0) {
        ticks("phoneFR_LongestWaitTime", phoneFrmillisecond, phoneFrSecond, phoneFrMinute, phoneFrHour);
    } else {
        document.getElementById("phoneFR_LongestWaitTime").innerHTML = "00:00";
    }
    // G2T French
    var G2TFrQueued = document.getElementById('HiddenlblInQueue_G2T_FRE').value;
    G2TFrQueued = parseInt(G2TFrQueued, 10);
    if (G2TFrQueued > 0) {
        ticks("G2TFR_LongestWaitTime", G2TFrmillisecond, G2TFrSecond, G2TFrMinute, G2TFrHour);
    } else {
        document.getElementById("G2TFR_LongestWaitTime").innerHTML = "00:00";
    }
    // Health French
    var HlthFrQueued = document.getElementById('HiddenlblInQueue_Hlth_FRE').value;
    HlthFrQueued = parseInt(HlthFrQueued, 10);
    if (HlthFrQueued > 0) {
        ticks("HlthFR_LongestWaitTime", HlthFrmillisecond, HlthFrSecond, HlthFrMinute, HlthFrHour);
    } else {
        document.getElementById("HlthFR_LongestWaitTime").innerHTML = "00:00";
    }



    // Chat Web English
    var ChatWebEnQueued = document.getElementById('HiddenlblInQueue_Chat_ENG').value;
    ChatWebEnQueued = parseInt(ChatWebEnQueued, 10);
    if (ChatWebEnQueued > 0) {
        ticks("cWebEn_LongestWaitTime", chatWebENmillisecond, chatWebENSecond, chatWebENMinute, chatWebENHour);
    } else {
        document.getElementById("cWebEn_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat App English
    var ChatAppEnQueued = document.getElementById('HiddenlblInQueue_ChatApp_ENG').value;
    ChatAppEnQueued = parseInt(ChatAppEnQueued, 10);
    if (ChatAppEnQueued > 0) {
        ticks("cAppEn_LongestWaitTime", chatAppENmillisecond, chatAppENSecond, chatAppENMinute, chatAppENHour);
    } else {
        document.getElementById("cAppEn_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat Web French
    var ChatWebFrQueued = document.getElementById('HiddenlblInQueue_Chat_FRE').value;
    ChatWebFrQueued = parseInt(ChatWebFrQueued, 10);
    if (ChatWebFrQueued > 0) {
        ticks("cWebFr_LongestWaitTime", chatWebFrmillisecond, chatWebFrSecond, chatWebFrMinute, chatWebFrHour);
    } else {
        document.getElementById("cWebFr_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat App French
    var ChatAppFrQueued = document.getElementById('HiddenlblInQueue_ChatApp_FRE').value;
    ChatAppFrQueued = parseInt(ChatAppFrQueued, 10);
    if (ChatAppFrQueued > 0) {
        ticks("cAppFr_LongestWaitTime", chatAppFrmillisecond, chatAppFrSecond, chatAppFrMinute, chatAppFrHour);
    } else {
        document.getElementById("cAppFr_LongestWaitTime").innerHTML = "00:00";
    }



    function ticks(_LWT, _ms, _sec, _mins, _hrs) {
        _ms = _ms + 50;
        if (_ms >= 1000) {
            _ms = 0;
            _sec = _sec + 1;
        }
        if (_sec >= 60) {
            _sec = 0;
            _mins = _mins + 1;
        }
        if (_mins >= 60) {
            _mins = 0;
            _hrs = _hrs + 1;
        }

        //Add a zero in front of numbers<10
        hr = checkTime(_hrs);
        min = checkTime(_mins);
        sec = checkTime(_sec);
        document.getElementById(_LWT).innerHTML = hr == 0 ? (min + ':' + sec) : (hr + ':' + min + ':' + sec);
        ticker = setTimeout(function () { ticks(_LWT, _ms, _sec, _mins, _hrs) }, 50);
    }





    var circle = new ProgressBar.Circle(progress, {
        color: '#00ff00',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10, //10
        trailWidth: 250, //150
        easing: 'easeInOut',
        duration: 5000, //7000 扫的快慢 ， 1000：一秒； 7000： 7秒
        text: {
            autoStyleContainer: true
        },
        from: { color: '#00FF00', width: 100 }, //0095C8(KHP Blue)
        to: { color: '#0095C8', width: 0 }, //#FFF(White) 0000FF(Blue) 00FF00(Green)
        // Set default step function for all animate calls
        step: function (state, circle) {
            circle.path.setAttribute('stroke', state.color);
            circle.path.setAttribute('stroke-width', state.width);

            var value = Math.round(circle.value() * 100);
            if (value === 0) {
                circle.setText('');
            } else {
                circle.setText(value);
            }
        }
    });
    //circle.text.style.fontFamily = '"Raleway", Helvetica, sans-serif';
    //circle.text.style.fontSize = '2rem';
    circle.animate(1.0);  // Number from 0.0 to 1.0 ; 
    // 扫过的周长，0，就不扫， 1 扫一半，就是半圆 ，0.75 扫3/4个圆

};