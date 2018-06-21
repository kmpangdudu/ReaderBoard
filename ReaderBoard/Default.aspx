<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReaderBoard._Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://d3js.org/d3.v3.min.js" lang="JavaScript"></script>
    <script src="Scripts/liquidFillGauge.js" lang="JavaScript"></script>
    <script src="Scripts/liquidFillGauge.js" lang="JavaScript"></script>
    <style>
        .liquidFillGaugeText { font-family: Helvetica; font-weight: bold; }
        .container {
            display: flex;
        }
        .container > div {
          flex: 1; /*grow*/
        }
        #ENG,#phone {
            background-color:lightcoral;padding:5px,10px,5px,10px;margin: 5px,10px,5px,5px;border:double;border-color:lightcoral;border-width:10px
        }
        #FRE,#chat{
        background-color:lightgrey;padding:5px,10px,5px,10px;margin: 0px,10px,5px,10px;border:double;border-color:lightgrey;border-width:10px
        }
        p{padding:0px,0px,0px,10px; margin:0px;}

        #phoneE{background-color:lightblue;padding:2px,5px;margin: 2px,5px;}
        #G2TE{background-color:plum;padding:2px,5px;margin: 2px,5px;}
        #ChatE{background-color:lightgoldenrodyellow;padding:2px,5px;margin: 2px,5px;}
        #ChatAppE {background-color:lightgray;padding:2px,5px;margin: 2px,5px;}

        #PhoneF{background-color:coral;padding:2px,5px;margin: 2px,5px;}
        #G2TF{background-color:lightgoldenrodyellow;padding:2px,5px;margin: 2px,5px;}
        #ChatF{background-color:lime;padding:2px,5px;margin: 2px,5px;}
        #ChatAppF {background-color:lightblue;padding:2px,5px;margin: 2px,5px;}
        .bigfont {
            font-size:116px;
        }
        .midfont {
            font-size:42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="phone" class="container">
            <div class="midfont">
                <h2>Phones</h2>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblDate" runat="server" Text="Refreshing" CssClass="midfont"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblTime" runat="server" Text="Refreshing" CssClass="midfont"></asp:Label>
                        </div>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                        </asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <div class="bigfont">
                    <asp:Label ID="lblPhoneGradeService" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Grade of Service</div>
            </div>

            <div>
                <div class="bigfont">
                    <asp:Label ID="lblPhoneLongestWaitTime" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Longest Current wait time </div>

                <div class="bigfont">
                    <asp:Label ID="lblPhoneAverageWaitTime" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Average wait time</div>

                <div class="bigfont">
                    <asp:Label ID="lblPhoneCallToday" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Calls today</div>
            </div>
            <div>
                <div class="bigfont">
                    <asp:HiddenField ID="lblPhonePeopleInQueue" runat="server"></asp:HiddenField></div>
             
                   <div>
                    <svg id="fillgauge_PhoneQueued" width="320" height="550" onclick="gauge5.update(NewValue());"></svg>
                    <script>
                        var config4 = liquidFillGaugeDefaultSettings();
                        config4.circleThickness = 0.15; //0.15
                        config4.circleColor = "#808015";
                        config4.textColor = "#555500";
                        config4.waveTextColor = "#FFFFAA";
                        config4.waveColor = "#AAAA39";
                        config4.textVertPosition = 0.55; //0.8
                        config4.waveAnimateTime = 1000;
                        config4.waveHeight = 0.1;
                        config4.waveAnimate = true;
                        config4.waveRise = false; //false
                        config4.waveHeightScaling = true;
                        config4.waveOffset = 0.35; //0.25
                        config4.textSize = 2.0;//0.75
                        config4.waveCount = 4;//3
	                    config4.displayPercent = false; //true
	                    var thevalue=document.getElementById('lblPhonePeopleInQueue').value; 
                        var gauge5 = loadLiquidFillGauge("fillgauge_PhoneQueued", thevalue, config4);
                    </script>
                </div>
                <div class="midfont">Young people in queue</div>

            </div>
            <div>
                <div class="bigfont">
                    <asp:Label ID="lblPhoneCounselorAvailable" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Counselor Available</div>

            </div>
        </div>
        <br />
        <div id="chat" class="container">
            <div class="midfont">
                <h2>Live Chat</h2>
            </div>

            <div> 
                <div class="bigfont"><asp:Label ID="lblChatGradeService" runat="server" Text=""></asp:Label></div>
                <div class="midfont">
                    Grade of Service:&nbsp
                   
                </div>
            </div>
            <div>
                <div class="bigfont">
                    <asp:Label ID="lblChatLongestWaitTime" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Longest Current wait time</div>

                <div class="bigfont">
                    <asp:Label ID="lblChatAverageWaitTime" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Average wait time</div>

                <div class="bigfont">
                    <asp:Label ID="lblChatCallToday" runat="server" Text=""></asp:Label>
                </div>
                <div class="midfont">Calls today</div>
            </div>
            <div>
                <div class="bigfont">
                    <asp:HiddenField ID="lblChatPeopleInQueue" runat="server" ></asp:HiddenField>
                </div>
                <div>
                    <svg id="fillgauge_ChatQueued" width="320" height="550" onclick="gauge5.update(NewValue());"></svg>
                    <script>
                        var config5 = liquidFillGaugeDefaultSettings();
                        config5.circleThickness = 0.15; //0.15
                        config5.circleColor = "#808015";
                        config5.textColor = "#555500";
                        config5.waveTextColor = "#FFFFAA";
                        config5.waveColor = "#AAAA39";
                        config5.textVertPosition = 0.55; //0.8
                        config5.waveAnimateTime = 1000;
                        config5.waveHeight = 0.2;
                        config5.waveAnimate = true;
                        config5.waveRise = true; //false
                        config5.waveHeightScaling = true;
                        config5.waveOffset = 0.25; //0.25
                        config5.textSize = 2.0;//0.75
                        config5.waveCount = 4;//3
	                    config5.displayPercent = false; //true
	                    var thevalue=document.getElementById('lblChatPeopleInQueue').value; 
                        var gauge5 = loadLiquidFillGauge("fillgauge_ChatQueued", thevalue, config5);
                    </script>
                </div>
                <div class="midfont">Young people in queue</div>
            </div>
            <div>
                <div class="bigfont">

                    <asp:Label ID="lblChatCounselorAvailable" runat="server" Text=""></asp:Label>

                </div>
                <div class="midfont">Counselor Available</div>
            </div>
        </div>
        <div style="display: none">
            <div>
                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
            </div>
        </div>

    </form>
</body>
</html>
