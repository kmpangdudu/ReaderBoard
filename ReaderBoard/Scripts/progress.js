window.onload = function onLoad() {

    startTime();
 
    var phoneHour, phoneMinute, phoneSecond, chatHour, chatMinute, chatSecond, pmillisecond, cmillisecond;
    var phoneLWT, chatLWT;

  
    phoneLWT = document.getElementById('HiddenPhoneLongestWaitTime').value;
    chatLWT = document.getElementById('HiddenChatLongestWaitTime').value;

    phoneHour = parseInt(phoneLWT.substr(0, 1),10);
    phoneMinute = parseInt(phoneLWT.substr(2, 2),10);
    phoneSecond = parseInt(phoneLWT.substr(-2),10);
    pmillisecond = 0;


    chatHour = parseInt(chatLWT.substr(0, 1), 10);
    chatMinute = parseInt(chatLWT.substr(2, 2), 10);
    chatSecond = parseInt(chatLWT.substr(-2), 10);
    cmillisecond = 0;
    
    var phoneQueued = document.getElementById('lblPhonePeopleInQueue').value;
    phoneQueued = parseInt(phoneQueued, 10);  
    if (phoneQueued > 0) {
           phoneLongestWaitTime();
    } else {
        document.getElementById("pLongestWaitTime").innerHTML =  "00:00" ;
    }
    

    var chatQueued = document.getElementById('lblChatPeopleInQueue').value;
    chatQueued = parseInt(chatQueued, 10);  
    if (chatQueued > 0) {
        
        chatLongestWaitTime();
    } else {
        document.getElementById("cLongestWaitTime").innerHTML = "00:00";
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

    function phoneLongestWaitTime() {
       
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
        document.getElementById('pLongestWaitTime').innerHTML = hr == 0 ? ( min + ':' + sec) : (phoneHour + ':' + min + ':' + sec) ;
        ticker = setTimeout(function () { phoneLongestWaitTime() }, 50);
    }

    function chatLongestWaitTime() {
        cmillisecond = cmillisecond + 50;
        if (cmillisecond >= 1000) {
            cmillisecond = 0;
            chatSecond = chatSecond + 1;
        }
        if (chatSecond >= 60) {
            chatSecond = 0;
            chatMinute = chatMinute + 1;
        }
        if (chatMinute >= 60) {
            chatMinute = 0;
            chatHour = chatHour + 1;
        }

        //Add a zero in front of numbers<10
        hr = checkTime(chatHour);
        min = checkTime(chatMinute);
        sec = checkTime(chatSecond);
        document.getElementById('c').innerHTML = hr == 0 ? ( min + ':' + sec) : (chatHour + ':' + min + ':' + sec);
        ticker = setTimeout(function () { chatLongestWaitTime() }, 50);
    }



    // phone English
    var phoneEnQueued = document.getElementById('lblInQueue_Phone_ENG').value;
    alert("phoneEnQueued = " + phoneEnQueued);
    phoneEnQueued = parseInt(phoneEnQueued, 10);
    if (phoneEnQueued > 0) {
        alert("will call function");
        tickLongestWaitTime("PhoneEN_LongestWaitTime");
    } else {
        alert("phoneEnQueued  is zero ");
        document.getElementById("PhoneEN_LongestWaitTime").innerHTML = "12:34";
    }
    // G2T English
    var G2TEnQueued = document.getElementById('lblInQueue_G2T_ENG').value;
    G2TEnQueued = parseInt(G2TEnQueued, 10);
    if (G2TEnQueued > 0) {
        tickLongestWaitTime("G2TEN_LongestWaitTime");
    } else {
        document.getElementById("G2TEN_LongestWaitTime").innerHTML = "g2:en";
    }
    // Phone French
    var phoneFrQueued = document.getElementById('lblInQueue_Phone_FRE').value;
    phoneFrQueued = parseInt(phoneFrQueued, 10);
    if (phoneFrQueued > 0) {
        tickLongestWaitTime("phoneFR_LongestWaitTime");
    } else {
        document.getElementById("phoneFR_LongestWaitTime").innerHTML = "00:00";
    }
    // G2T French
    var G2TFrQueued = document.getElementById('lblInQueue_G2T_FRE').value;
    G2TFrQueued = parseInt(G2TFrQueued, 10);
    if (G2TFrQueued > 0) {
        tickLongestWaitTime("G2TFR_LongestWaitTime");
    } else {
        document.getElementById("G2TFR_LongestWaitTime").innerHTML = "00:00";
    }

    // Chat Web English
    var ChatWebEnQueued = document.getElementById('lblInQueue_Chat_ENG').value;
    ChatWebEnQueued = parseInt(ChatWebEnQueued, 10);
    if (ChatWebEnQueued > 0) {
        tickLongestWaitTime("cWebEn_LongestWaitTime");
    } else {
        document.getElementById("cWebEn_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat App English
    var ChatAppEnQueued = document.getElementById('lblInQueue_ChatApp_ENG').value;
    ChatAppEnQueued = parseInt(ChatAppEnQueued, 10);
    if (ChatAppEnQueued > 0) {
        tickLongestWaitTime("cAppEn_LongestWaitTime");
    } else {
        document.getElementById("cAppEn_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat Web French
    var ChatWebFrQueued = document.getElementById('lblInQueue_Chat_FRE').value;
    ChatWebFrQueued = parseInt(ChatWebFrQueued, 10);
    if (ChatWebFrQueued > 0) {
        tickLongestWaitTime("cWebFr_LongestWaitTime");
    } else {
        document.getElementById("cWebFr_LongestWaitTime").innerHTML = "00:00";
    }
    // Chat App French
    var ChatAppFrQueued = document.getElementById('lblInQueue_ChatApp_FRE').value;
    ChatAppFrQueued = parseInt(ChatAppFrQueued, 10);
    if (ChatAppFrQueued > 0) {
        tickLongestWaitTime("cAppFr_LongestWaitTime");
    } else {
        document.getElementById("cAppFr_LongestWaitTime").innerHTML = "00:00";
    }





    function tickLongestWaitTime(caller) {
        var abc = caller;
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
        document.getElementById(abc).innerHTML = hr == 0 ? (min + ':' + sec) : (phoneHour + ':' + min + ':' + sec);
        ticker = setTimeout(function () { tickLongestWaitTime(abc) }, 50);
    }
};