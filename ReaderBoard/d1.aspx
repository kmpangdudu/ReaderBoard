<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReaderBoard._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DarkTheme</title>
    <script src="http://d3js.org/d3.v3.min.js" lang="JavaScript"></script>
    <script src="Scripts/liquidFillGauge.js" lang="JavaScript"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="Scripts/googleGauge.js"></script>
    <link href="Content/dark.css" rel="stylesheet" />
 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="phone" class="flex-container effect5 borderLineThick">
            <div class="midfont_title  borderLine"  style="flex-basis: 15%" >
                <div class="logodiv">
                    <img src="Content/KHP_EN_RGB.svg" alt="Home" class="logostyle">
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
                            <asp:Label ID="lblTime" runat="server" Text="Refreshing"   CssClass="clock"></asp:Label>
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
                <div class="midfont">Grade of Service (%)</div>
                <div class="container">
                    <asp:HiddenField ID="lblPhoneGradeService24" runat="server"></asp:HiddenField>
                    <div id="chart_div2" class="center_child"></div>
                </div>
            </div>



            <!-- Phone wait time  -->
            <div class="  borderLine">
                <div class="borderShadow">
                    <div class="bigfont">
                        <asp:Label ID="lblPhoneLongestWaitTime" runat="server" Text=""></asp:Label>  
                        
                    </div>
                    <div class="midfont">Current wait time (min.)</div>
                </div>
                <div class="borderShadow">
                    <div class="bigfont">
                        <asp:Label ID="lblPhoneAverageWaitTime" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="midfont">Average wait time (min.)</div>
                </div>
                <div class="borderShadow">
                    <div class="bigfont">
                        <asp:Label ID="lblPhoneCallToday" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="midfont">Calls today</div>
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
                        config4.circleColor = "#00FFFF";
                        config4.textColor = "#FCFCFC";
                        config4.waveTextColor = "#FFFFAA";
                        config4.waveColor = "#00FFFF";
                        config4.textVertPosition = 0.55; //0.8
                        config4.waveAnimateTime = 1000;
                        config4.waveHeight = 0.1;
                        config4.waveAnimate = true;
                        config4.waveRise = false; //false
                        config4.waveHeightScaling = true;
                        config4.waveOffset = 0.35; //0.25
                        config4.textSize = 2.2;//0.75
                        config4.waveCount = 4;//3
                        config4.displayPercent = false; //true
                        var thevalue = document.getElementById('lblPhonePeopleInQueue').value;
                        var gauge5 = loadLiquidFillGauge("fillgauge_PhoneQueued", thevalue, config4);
                    </script>
                    <div class="midfont Top-min-XXpx">In Queued</div>
                </div>
            </div>



            <!-- Phone Counselor Availabele  -->
            <div class=" borderLine">
                <div class="midfont">Counselor Available</div>
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


       <%-- <p style="height:-1px;">&nbsp;</p>--%>


        <div id="chat" class="flex-container effect5 borderLineThick">  
            <div class="midfont_title  borderLine" style="flex-basis: 15%" >
                <div class="logodiv">
                    <img src="Content/KHP_EN_RGB.svg" alt="Home" class="logostyle">
                </div>
                <div>
                    <h2>Live Chat</h2>
                </div>
            </div>


            <!--- Chat Grade of Service   --->
            <div class="container_parent  borderLine">
                <div>
                    <div>
                        <asp:HiddenField ID="lblChatGradeService" runat="server" />
                    </div>
                    <div id="chart_div3" class="center_child"></div>
                </div>
                <div class="midfont">Grade of Service (%)</div>
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
                    <div class="bigfont">
                        <asp:Label ID="lblChatLongestWaitTime" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="midfont">Current wait time (min.)</div>
                </div>
                <div class="borderShadow">
                    <div class="bigfont">
                        <asp:Label ID="lblChatAverageWaitTime" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="midfont">Average wait time (min.)</div>
                </div>
                <div class="borderShadow">
                    <div class="bigfont">
                        <asp:Label ID="lblChatCallToday" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="midfont">Chats today</div>
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
                        config5.circleColor = "#00FFFF";//808015
                        config5.textColor = "#FCFCFC";
                        config5.waveTextColor = "#FFFFAA";//FFFFAA
                        config5.waveColor = "#00FFFF";   //AAAA39
                        config5.textVertPosition = 0.55; //0.8
                        config5.waveAnimateTime = 1000;
                        config5.waveHeight = 0.3;
                        config5.waveAnimate = true;
                        config5.waveRise = true; //false
                        config5.waveHeightScaling = true;
                        config5.waveOffset = 0.35; //0.25
                        config5.textSize = 2.1;//0.75
                        config5.waveCount = 3;//3
                        config5.displayPercent = false; //true
                        var thevalue = document.getElementById('lblChatPeopleInQueue').value;
                        var gauge5 = loadLiquidFillGauge("fillgauge_ChatQueued", thevalue, config5);
                    </script>
                </div>
                <div class="midfont Top-min-XXpx">In Queued</div>
            </div>



            <!-- Chat Counselor Available       -->
            <div class="borderLine ">
                <div class="midfont emptyline">Counselor Available</div>
                <div class="bigfont">
                    <asp:Label ID="lblChatCounselorAvailable" runat="server" Text=""></asp:Label>
                </div>
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