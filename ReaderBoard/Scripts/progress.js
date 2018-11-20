window.onload = function onLoad() {

    startTime();


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
};