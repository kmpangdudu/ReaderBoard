<%@ Page Title="KHP Status" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReaderBoard._Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Readerboard</title>
    <script src="http://d3js.org/d3.v3.min.js" lang="JavaScript"></script>
    <script src="Scripts/liquidFillGauge.js" lang="JavaScript"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="Scripts/googleGauge.js"></script>
    <link href="Content/readerboard.css" rel="stylesheet" />
 <link href="https://fonts.googleapis.com/css?family=Raleway:400,300,600,800,900" rel="stylesheet" type="text/css">
<script src="Scripts/processBar.js"></script>
    <script src="https://rawgit.com/kimmobrunfeldt/progressbar.js/1.0.0/dist/progressbar.js" lang="JavaScript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="phone" class="flex-container effect5  borderLineThick">
            <div class="midfont_title  borderLine"  style="flex-basis: 15%" >
                <div class="logodiv">
                    <img src="Content/KHP_EN_RGB.svg" alt="Home" class="logostyle" />
                </div>
                <div>
                    <h2>Phone</h2>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblDate" runat="server" Text="Refreshing" CssClass="clock"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblTime" runat="server" Text="Refreshing" CssClass="clock"></asp:Label>
                        </div>
                        <asp:Timer ID="Timer1" runat="server" Interval="500" OnTick="Timer1_Tick">
                        </asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

 


            <!--  phone Grade of Service  -->
            <div class="container_parent  borderLine">
                <div>
                    <div>
                        <asp:HiddenField ID="lblPhoneGradeService" runat="server"></asp:HiddenField>
                    </div>
                    <div id="chart_div1" class="center_child"></div>
                </div>
                <h3 class="">Grade of Service (%)</h3>
                <div class="container">
                    <asp:HiddenField ID="lblPhoneGradeService24" runat="server"></asp:HiddenField>
                    <div id="chart_div2" class="center_child"></div>
                </div>
            </div>



            <!-- Phone wait time  -->
            <div class="  borderLine">
                <div class="borderShadow">
                    <h1 class="bigfont">
                        <asp:Label ID="lblPhoneLongestWaitTime" runat="server" Text=""></asp:Label>  
                    </h1>
                    <h3 class="">Current wait time (min.)</h3>
                </div>
                <div class="borderShadow">
                    <h1 class="bigfont">
                        <asp:Label ID="lblPhoneAverageWaitTime" runat="server" Text=""></asp:Label>
                    </h1>
                    <h3 class="">Average wait time (min.)</h3>
                </div>
                <div class="borderShadow">
                    <h1 class="bigfont">
                        <asp:Label ID="lblPhoneCallToday" runat="server" Text=""></asp:Label>
                    </h1>
                    <h3 class="">Calls today</h3>
                </div>
            </div>



            <!-- Phone in Queued -->
            <div class=" borderLine">
                <div class="bigfont">
                    <asp:HiddenField ID="lblPhonePeopleInQueue" runat="server"></asp:HiddenField>
                </div>
                <div>
                    <svg id="fillgauge_PhoneQueued" width="280" height="500" onclick="gauge5.update(NewValue());"></svg>
                    <script>
                        var config4 = liquidFillGaugeDefaultSettings();
                        config4.circleThickness = 0.10; //0.15
                        config4.circleColor = "#0462F7";
                        config4.textColor = "#333333";
                        config4.waveTextColor = "#FFFFAA";
                        config4.waveColor = "#AAAA39";
                        config4.textVertPosition = 0.55; //0.8
                        config4.waveAnimateTime = 1000;
                        config4.waveHeight = 0.3;
                        config4.waveAnimate = true;
                        config4.waveRise = false; //false
                        config4.waveHeightScaling = true;
                        config4.waveOffset = 0.35; //0.25
                        config4.textSize = 2.2;//0.75
                        config4.waveCount = 3;//3
                        config4.displayPercent = false; //true
                        var thevalue = document.getElementById('lblPhonePeopleInQueue').value;
                        var gauge5 = loadLiquidFillGauge("fillgauge_PhoneQueued", thevalue, config4);
                    </script>
                    <h3 class=" Top-min-XXpx">In Queued</h3>
                </div>
            </div>



            <!-- Phone Counselor Availabele  -->
            <div class=" borderLine">
                <h3 class="">Counselor Available</h3>
                <div class="bigfont">
                    <asp:Label ID="lblPhoneCounselorAvailable" runat="server" Text=""></asp:Label>
                </div>
                <div style="background-color:lightblue; ">
                    <p>phone_Eng: XXXX</p>
                    <p>phone_Fre: XXXX</p>
                    <p>G2T_Eng: #####</p>
                    <p>G2T_Fre: #####</p>
                </div>
            </div>
        </div>


        <p style="height:7px;">&nbsp;</p>


        <div id="chat" class="flex-container effect5 borderLineThick">  
            <div class="midfont_title  borderLine" style="flex-basis: 15%" >
                <div class="logodiv">
                    <img src="Content/KHP_EN_RGB.svg" alt="Home" class="logostyle">
                </div>
                <div>
                    <h2>Live Chat</h2>
                </div>
                
                   <div id="BarContainer" style="background-color:blue"></div>
                
            </div>


            <!--- Chat Grade of Service   --->
            <div class="container_parent  borderLine">
                <div>
                    <div>
                        <asp:HiddenField ID="lblChatGradeService" runat="server" />
                    </div>
                    <div id="chart_div3" class="center_child"></div>
                </div>
                <h3 class="">Grade of Service (%)</h3>
                <div>
                    <div class="bigfont">
                        <asp:HiddenField ID="lblChatGradeService24" runat="server"></asp:HiddenField>
                    </div>
                    <div id="chart_div4" class="center_child"></div>
                </div>
            </div>



            <!--  Chat wait time    -->
            <div class=" borderLine">
                <div class="borderShadow">
                    <h1 class="bigfont">
                        <asp:Label ID="lblChatLongestWaitTime" runat="server" Text=""></asp:Label>
                    </h1>
                    <h3 class="">Current wait time (min.)</h3>
                </div>
                <div class="borderShadow">
                    <h1 class="bigfont">
                        <asp:Label ID="lblChatAverageWaitTime" runat="server" Text=""></asp:Label>
                    </h1>
                    <h3 class="">Average wait time (min.)</h3>
                </div>
                <div class="borderShadow">
                    <h1 class="bigfont">
                        <asp:Label ID="lblChatCallToday" runat="server" Text=""></asp:Label>
                    </h1>
                    <h3 class="">Chats today</h3>
                </div>
            </div>



            <!-- Chat In Queued       -->
            <div class="borderLine ">
                <div class="bigfont">
                    <asp:HiddenField ID="lblChatPeopleInQueue" runat="server"></asp:HiddenField>
                </div>
                <div>
                    <svg id="fillgauge_ChatQueued" width="280" height="500" onclick="gauge5.update(NewValue());"></svg>
                    <%--width 280 X height="500"  down  best --%>
                    <script>
                        var config5 = liquidFillGaugeDefaultSettings();
                        config5.circleThickness = 0.10; //0.15
                        config5.circleColor = "#0462F7";//808015
                        config5.textColor = "#333333";
                        config5.waveTextColor = "#FFFFAA";//FFFFAA
                        config5.waveColor = "#AAAA39";   //AAAA39
                        config5.textVertPosition = 0.55; //0.8
                        config5.waveAnimateTime = 1000;
                        config5.waveHeight = 0.2;
                        config5.waveAnimate = true;
                        config5.waveRise = true; //false
                        config5.waveHeightScaling = true;
                        config5.waveOffset = 0.25; //0.25
                        config5.textSize = 2.1;//0.75
                        config5.waveCount = 4;//3
                        config5.displayPercent = false; //true
                        var thevalue = document.getElementById('lblChatPeopleInQueue').value;
                        var gauge5 = loadLiquidFillGauge("fillgauge_ChatQueued", thevalue, config5);
                    </script>
                </div>
                <div class=" Top-min-XXpx">In Queued</div>
            </div>



            <!-- Chat Counselor Available       -->
            <div class="borderLine ">
                <h3 class=" emptyline">Counselor Available</h3>
                <h1 class="bigfont">
                    <asp:Label ID="lblChatCounselorAvailable" runat="server" Text=""></asp:Label>
                </h1>
                <p>WebChat_Eng: XXXX</p>
                <p>WebChat_Fre: XXXX</p>
                <p>ChatApp_Eng: #####</p>
                <p>ChatApp_Fre: #####</p>

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
