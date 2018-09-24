// Util Function
 
//william made

$(document).ready(function () {
    var gradient = function (domId, scale) {
 
        var grade = scale;
         
        var id = domId;
        var colorGreen = "#4CAF50"; //00E600
        var colorOrange = "#FF8C00";
        var colorRed = "#F45B69"; //E6005C
        var colorBlue = "#4062BB"; //1a1aff
        var lightGrey = "#f4f3f8";
        var darkGrey = "#4d4d4d"; 

        var createShadow = function (svg) {
            var defs = svg.append("svg:defs");

            var inset_shadow = defs.append("svg:filter")
                .attr("id", "inset-shadow");

            inset_shadow.append("svg:feOffset")
                .attr({
                    dx: 0, //0
                    dy: 0
                });

            inset_shadow.append("svg:feGaussianBlur")
                .attr({
                    stdDeviation: 3,
                    result: 'offset-blur'
                });

            inset_shadow.append("svg:feComposite")
                .attr({
                    operator: 'out',
                    in: 'SourceGraphic',
                    in2: 'offset-blur',
                    result: 'inverse'
                });

            inset_shadow.append("svg:feFlood")
                .attr({
                    'flood-color': 'black',
                    'flood-opacity': .1,
                    result: 'color'
                });

            inset_shadow.append("svg:feComposite")
                .attr({
                    operator: 'in',
                    in: 'color',
                    in2: 'inverse',
                    result: 'shadow'
                });

            inset_shadow.append("svg:feComposite")
                .attr({
                    operator: 'over',
                    in: 'shadow',
                    in2: 'SourceGraphic'
                });
        };

        var createGradient = function (svg, id, color1, color2) {

            var defs = svg.append("svg:defs");

            var red_gradient = defs.append("svg:linearGradient")
                .attr("id", id)  //   ID <---------------------
                .attr("x1", "0%")
                .attr("y1", "0%")
                .attr("x2", "50%")
                .attr("y2", "100%")
                .attr("spreadMethod", "pad");

            //william use color2 only 

            if (scale <= 30) {

                red_gradient.append("svg:stop")
                    .attr("offset", "50%")//50
                    .attr("stop-color", colorRed) //red
                    .attr("stop-opacity", 1);
            }
            else if ((scale > 30) && (scale < 60)) {

                red_gradient.append("svg:stop")
                    .attr("offset", "50%")//50
                    .attr("stop-color", colorOrange) //Orange
                    .attr("stop-opacity", 1);
            }
            else {

                red_gradient.append("svg:stop")
                    .attr("offset", "50%")//50
                    .attr("stop-color", colorGreen) //green
                    .attr("stop-opacity", 1);
            }

 

        };

        //william comment testing pass value , var grade is made by william
        var percent = grade; //60



        var pie = d3.layout.pie()
            .value(function (d) { return d })
            .sort(null);

        var w = 195, h = 195;  //default 300*300   //william extenal circle R

        var outerRadius = (w / 2) - 10;
        var innerRadius = 76; //default 110   //william inner circle R


        var arcBackground = d3.svg.arc()
            .innerRadius(innerRadius)
            .outerRadius(outerRadius)
            .startAngle(0)
            .endAngle(2 * Math.PI);

        //The circle is following this Dummy Arc
        var arcDummy = d3.svg.arc()
            .innerRadius(125)
            .outerRadius(125) //125
            .startAngle(0);


        var arcProgress = d3.svg.arc()
            .innerRadius(innerRadius)
            .outerRadius(outerRadius)
            .cornerRadius(20)//画笔头圆度
            .startAngle(-0.1);  //画笔起点离头圆圈的距离

        // domid
        var svg = d3.select("#"  + domId)      
            .append("svg")
            .attr({
                width: w,
                height: h,
                class: 'shadow'
            }).append('g')
            .attr({
                transform: 'translate(' + w / 2 + ',' + h / 2 + ')'  //william w离左边距离；h 离顶的距离
            });




        createShadow(svg);
        // domid
        createGradient(svg, "gradient" + domId, "#FF0000", "#00FF00");
        //william start pen color"#40a6f8";  and end pen color "1a70e7"


        //background
        var pathBackground = svg.append('path')
            .attr({
                d: arcBackground
            })
            .style({
                fill: lightGrey,  //william   pathBackground未填充圆形的颜色  f4f3f8
                stroke: '#e2e7eb',
                'stroke-width': 1
            });

        //william 
        var dayTimeStart = document.getElementById('HiddendayTimeStart').value;
        var dayTimeEnd = document.getElementById('HiddendayTimeEnd').value;
        var hours = new Date();
        // william means in day time
        if ((parseInt(dayTimeStart) <= hours.getHours() && hours.getHours() <= parseInt(dayTimeEnd)-1)) {
            pathBackground.style.fill = lightGrey;
        }
        else {
            
            pathBackground = svg.append('path')
                .attr({
                    d: arcBackground
                })
                .style({
                    fill: darkGrey,  //william   pathBackground未填充圆形的颜色  f4f3f8
                    stroke: '#000000', //e2e7eb pathBackground未填充圆形的边线
                    'stroke-width': 1
                });
        };


        var pathForeground = svg.append('path')
            .datum({ endAngle: 0 })
            .attr({
                d: arcProgress
            })
            // domid
            .style({
                fill: 'url(#gradient' + domId + ')',
                filter: 'url(#inset-shadow)',
                //stroke: '#3285fb',  //william pen-border
                'stroke-width': 1
            });
        //line Arc for Circle
        var pathDummy = svg.append('path')
            .datum({ endAngle: 0 })
            .attr({
                d: arcDummy
            }).style({
                fill: '#A92602' //A92602
            });

        var endCircle = svg.append('circle')
            .attr({
                r: 4,
                transform: 'translate(0,' + (-outerRadius + 6) + ')'
            })
            .style({
                stroke: '#0751b7',
                'stroke-width': 1.5,
                'stroke-opacity': .5,
                opacity: 0,
                fill: '#ffffff',                                  // william end little cricile color
                filter: 'url(#inset-shadow)'
            });

        var startCircle = svg.append('circle')//circle
            .attr({
                r: 4, //启点小圆圈的大小
                transform: 'translate(0,' + (-outerRadius + 6) + ')'   //+的数字是起点小圆圈的上下调整
            })
            .style({
                stroke: '#0751b7',
                'stroke-width': 1.5,
                'stroke-opacity': .2,
                fill: '#fff',  // william start little cricile color
                filter: 'url(#inset-shadow)'
            });

        var middleTextCount = svg.append('text')
            .datum(0)
            .text(function (d) {
                //return d + '%';
                return d  ;
            })

            .attr({
                class: 'middleText',
                'text-anchor': 'middle',
                dy: 24,  // william center Text V position ,default 10
                dx: 0
            })
            //domID
            .style({
                 
                fill: 'url(#gradient' + domId + ')',
                'font-size': '80px',// william display foreSize default 32px
                'font-weight': 'bold',
                'color': '#FF0000'
            });


        var arcTween = function (transition, percent, oldValue) {
            transition.attrTween("d", function (d) {

                var newAngle = (percent / 100) * (2 * Math.PI);

                var interpolateForeground = d3.interpolate(d.endAngle, newAngle);

                var interpolateText = d3.interpolate(oldValue, percent);

                return function (t) {
                    d.endAngle = interpolateForeground(t);

                    //middleTextCount.text(Math.floor(interpolateText(t)) + '%'); //william middle text 
                   // middleTextCount.text(interpolateText(t) + '%');
                    middleTextCount.text(interpolateText(t));


                    return arcProgress(d);
                };
            });
        };

        var arcTweenDummy = function (transition, percent) {
            transition.attrTween("d", function (d) {

                var newAngle = (percent / 100) * (2 * Math.PI);

                var interpolateCircle = d3.interpolate(d.endAngle, newAngle - .13);

                return function (t) {

                    d.endAngle = interpolateCircle(t);
                    var pathDummyCircle = arcDummy(d);

                    var coordinate = pathDummyCircle.split("L")[1].split("A")[0];

                    if (d.endAngle > .25 && d.endAngle < (2 * Math.PI - .14))
                        endCircle.style('opacity', 1);
                    else
                        endCircle.style('opacity', 0);

                    //endCircle.attr('transform', 'translate(' + coordinate + ')');   //william end little circle 

                    return pathDummyCircle;
                };
            });
        };

        var oldValue = 0;

        var animate = function () {
            pathForeground.transition()
                .duration(2500)
                .ease('cubic')
                .call(arcTween, percent, oldValue); // william will not process 

            pathDummy.transition()
                .duration(2500)
                .ease('cubic')
                .call(arcTweenDummy, percent);  //william 注释后末端小圆圈不在


            oldValue = percent;
            //percent=(Math.random() * 60) + 20;//william hard code 
            percent = grade;
            //setTimeout(animate, 3000); //william hard code 
        };

        setTimeout(animate, 0);



    }

    var v1 = document.getElementById("lblPhoneGradeService").value;//57.88;
    var v2 = document.getElementById("lblPhoneGradeService24").value;//19.01;
    if ((isNaN(v1)) || (v1 < 1)) {
        v1 = 0;
    }
    v1 = parseFloat(v1).toFixed(2);
    
    if ((isNaN(v2)) || (v2 < 1)) {
        v2 = 0;
    }
    v2 = parseFloat(v2).toFixed(2);
    gradient("GradePhone", v1);//10.12
    gradient("GradePhone24", v2);//89.12

    var v3 = document.getElementById("lblChatGradeService").value;//57.88;
    var v4 = document.getElementById("lblChatGradeService24").value;//19.01;
    if ((isNaN(v3))||(v3<1)) {
        v3 = 0;
    }
    v3 = parseFloat(v3).toFixed(2);

    if ((isNaN(v4)) || (v4 < 1)) {
        v4 = 0;
    }
    v4 = parseFloat(v4).toFixed(2);
    gradient("GradeChat", v3);
    gradient("GradeChat24", v4);
});