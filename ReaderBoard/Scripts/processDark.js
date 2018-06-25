window.onload = function onLoad() {
    var circle = new ProgressBar.Circle(progress, {
        color: '#00ff00',
        // This has to be the same size as the maximum width to
        // prevent clipping
        strokeWidth: 10,
        trailWidth: 150,
        easing: 'easeInOut',
        duration: 7000,
        text: {
            autoStyleContainer: true
        },
        from: { color: '#FCFCFC', width: 100 }, //0095C8(KHP Blue)
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
    circle.animate(1);  // Number from 0.0 to 1.0
};