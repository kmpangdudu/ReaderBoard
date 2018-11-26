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
        document.getElementById("pLongestWaitTime").innerHTML =  "0:00:00" ;
    }
    

    var chatQueued = document.getElementById('lblChatPeopleInQueue').value;
    chatQueued = parseInt(chatQueued, 10);  
    if (chatQueued > 0) {
        
        chatLongestWaitTime();
    } else {
        document.getElementById("cLongestWaitTime").innerHTML = "0:00:00";
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
        document.getElementById('pLongestWaitTime').innerHTML = phoneHour + ':' + min + ':' + sec ;
        int = setTimeout(function () { phoneLongestWaitTime() }, 50);
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
        document.getElementById('cLongestWaitTime').innerHTML = chatHour + ':' + min + ':' + sec;
        int = setTimeout(function () { chatLongestWaitTime() }, 50);
    }
};