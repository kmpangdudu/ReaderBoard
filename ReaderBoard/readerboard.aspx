<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readerboard.aspx.cs" Inherits="ReaderBoard.readerboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Readerboard</title>

    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/readerboard1.css" rel="stylesheet" />
    <script src="http://d3js.org/d3.v3.min.js" lang="JavaScript"></script>
    <script src="https://www.gstatic.com/charts/loader.js" type="text/javascript"></script>
    <script src="https://cdn.rawgit.com/kimmobrunfeldt/progressbar.js/0.5.6/dist/progressbar.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/process1.js"></script>

    <!-- add     background-color: #CCC; commented .row margin R786 of bootstrap.css   -->
</head>
<body>
    <form id="form1" runat="server">
        <div id="all_contain" class="container-fluid">
            <div class="row divbgcWithPage">
                <div class="col-xs-12 col-md-12 divbgcWithPage">
                    <div class="divbgcWithPage center" style="color: #FFF">
                        <h2>KHP Real-Time Services Status</h2>
                    </div>
                </div>
            </div>
            <!--  Left hand column to show clock, icon  -->
            <div id="imgColumn" class="col-xs-12 col-md-2 divbgcWithPage borderLine1 ">

                <div id="divlock" class="row ">
                    <div class="borderLine1">
                        <div class="clock1">
                            <div id="clock"></div>
                            <div id="date"></div>
                        </div>
                    </div>
                </div>
                <%--   <div class="blank4r"><!-- add 4px space --></div>--%>
                <div class="row ">
                    <div class="col ChatDivDown borderLine1">
                        <div>
                            <div class="blank4r divbgcWithPageFCFCFC">
                                <!-- add 4px space -->
                            </div>
                            <h2>Phone</h2>
                            <img src="Content/phone-icon3.png" class="phone" />
                            <div class="blank12r divbgcWithPageFCFCFC">
                                <!-- add 4px space -->
                            </div>
                            <h4 class="font34">
                                <asp:Label ID="lblTotalNumOfInQueue_Phone" runat="server"></asp:Label>
                            </h4>
                            <h3 class="font24">In the Queue</h3>
                            <div class="blank4r divbgcWithPageFCFCFC">
                                <!-- add 4px space -->
                            </div>
                        </div>
                    </div>
                </div>
                <div class="blank4r">
                    <!-- add 4px space -->
                </div>
                <div class="row">
                    <div class="col ChatDivDown borderLine1">
                        <div>
                            <div class="blank4r divbgcWithPageFCFCFC">
                                <!-- add 4px space -->
                            </div>
                            <h2>Chat</h2>
                            <div id="progress" class="center_child"></div>
                            <div class="blank8r divbgcWithPageFCFCFC">
                                <!-- add 4px space -->
                            </div>
                            <h4 class="font34">
                                <asp:Label ID="lblTotalNumOfInQueue_Chat" runat="server"></asp:Label>
                            </h4>
                            <h3 class="font24">In the Queue</h3>
                            <div class="blank2r divbgcWithPageFCFCFC">
                                <!-- add 4px space -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <%--  start display SOAP Status parts--%>
            <div id="num" class="col-xs-12 col-md-7 divbgcWithPage borderLine1">

                <%--start Phone SOAP display row --%>
                <div id="phone" class="row divbgcWithPage">

                    <div id="colEng" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
                        <div id="English" class="row">
                            <div class="col-xs-12 col borderLine1">
                                <div>
                                    <h3 class="font30">English </h3>
                                </div>
                            </div>
                        </div>

                        <%--                <div class="blank4r">
                     <!-- add 4px space -->
                 </div>--%>
                        <div id="KHPG2T_EN" class="row">
                            <div id="KHP_EN" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">KHP </h3>
                                </div>
                            </div>
                            <div id="G2T_EN" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">G2T </h3>
                                </div>
                            </div>
                            <div id="Hlth_EN" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">Health </h3>
                                </div>
                            </div>
                        </div>

                        <%--           <div class="blank4r">
                     <!-- add 4px space -->
                 </div>--%>

                        <div id="Phone_EN" class="row ">
                            <!-- English KHP Phone -->
                            <div id="KHP_PHONE_EN" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">In the Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_Phone_ENG" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_Phone_ENG" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblPhoneLongestWaitTime_Phone_ENG" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenPhoneEnLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="PhoneEN_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC theplan">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>

                            <!-- English G2T Phone -->
                            <div id="G2T_PHONE_EN" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">In the Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_G2T_ENG" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_G2T_ENG" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>

                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblPhoneLongestWaitTime_G2T_ENG" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenG2TEnLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="G2TEN_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>

                            <!-- English Health Phone -->
                            <div id="Hlth_PHONE_EN" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">In the Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_Hlth_ENG" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_Hlth_ENG" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>

                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblPhoneLongestWaitTime_Hlth_ENG" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenHlthEnLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="HlthEN_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                    <!-- French start -->
                    <div id="ColFre" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
                        <div id="French" class="row">
                            <div class="col-xs-12 col borderLine1">
                                <div>
                                    <h3 class="font30">French</h3>
                                </div>
                            </div>
                        </div>
                        <%--          <div class="blank4r">
                     <!-- add 4px space -->
                 </div>--%>
                        <div id="KHP_G2T_Fr" class="row">
                            <div id="KHP_FR" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">KHP </h3>
                                </div>
                            </div>
                            <div id="G2T_FR" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">G2T </h3>
                                </div>
                            </div>
                            <div id="Hlth_FR" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">Health </h3>
                                </div>
                            </div>
                        </div>
                        <%--                 <div class="blank4r">
                     <!-- add 4px space -->
                 </div>--%>

                        <!--  French KHP Phone -->
                        <div class="row ">
                            <div id="KHP_PHONE_FR" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">In the Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_Phone_FRE" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_Phone_FRE" runat="server" />
                                    </h4>

                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblPhoneLongestWaitTime_Phone_FRE" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenPhoneFrLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="phoneFR_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>

                            <!--  French G2T Phone -->
                            <div id="G2T_PHONE_FR" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">In the Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_G2T_FRE" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_G2T_FRE" runat="server" />
                                    </h4>

                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblPhoneLongestWaitTime_G2T_FRE" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenG2TFrLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="G2TFR_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>

                            <!--  French Health Phone -->
                            <div id="Hlth_PHONE_FR" class="col-xs-12 col-md-4 borderLine1">
                                <div>
                                    <h3 class="font24">In the Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_Hlth_FRE" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_Hlth_FRE" runat="server" />
                                    </h4>

                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblPhoneLongestWaitTime_Hlth_FRE" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenHlthFrLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="HlthFR_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--End Phone SOAP display row--%>





                <%--Start Phone Contacted row--%>
                <div id="PhoneContact" class="row divbgcWithPage">
                    <div class="col-xs-12 col-md-12 borderLine1">
                        <div class="row " style="padding: 0px 3px;">
                            <div class="col-xs-12 col">
                                <div style="height: 120px;">

                                    <h3 class="font24">Total Phone Contacts Today</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblTotalPhoneHandled" runat="server"></asp:Label>
                                    </h4>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--end Phone Contact row--%>

                <div class="blank2r divbgcWithPage">
                    <!-- add 4px space -->
                </div>


                <%--start Chat SOAP display row --%>
                <div id="chat" class="row divbgcWithPage">

                    <div id="ChatColEng" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">

                        <div id="Chat_EN" class="row ">
                            <!-- Web Chat English -->
                            <div id="WebChat_EN" class="col-xs-12 col-md-6   borderLine1">
                                <div>
                                    <h3 class="font24">Web Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_Chat_ENG" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_Chat_ENG" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblLongestWaitTime_Chat_ENG" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenChatWebEnLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="cWebEn_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>

                            </div>


                            <!-- App Chat English -->
                            <div id="AppChat_EN" class="col-xs-12 col-md-6 borderLine1">
                                <div>
                                    <h3 class="font24">App Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_ChatApp_ENG" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_ChatApp_ENG" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblLongestWaitTime_ChatApp_ENG" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenChatAppEnLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="cAppEn_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="ChatColFre" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
                        <!-- Web Chat French -->
                        <div class="row divbgcWithPage">

                            <div id="WebChat_FR" class="col-xs-12 col-md-6  borderLine1">
                                <div>
                                    <h3 class="font24">Web Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_Chat_FRE" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_Chat_FRE" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblLongestWaitTime_Chat_FRE" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenChatWebFrLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="cWebFr_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>

                            <!-- App Chat French -->
                            <div id="AppChat_FR" class="col-xs-12 col-md-6 borderLine1">
                                <div>
                                    <h3 class="font24">App Queue</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblInQueue_ChatApp_FRE" runat="server"></asp:Label>
                                        <asp:HiddenField ID="HiddenlblInQueue_ChatApp_FRE" runat="server" />
                                    </h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                    <h3 class="font24">Longest Wait</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblLongestWaitTime_ChatApp_FRE" runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenChatAppFrLongestWaitTime" runat="server" />
                                    </h4>
                                    <h4 id="cAppFr_LongestWaitTime" class="font34">00:00</h4>
                                    <div class="blank4r divbgcWithPageFCFCFC">
                                        <!-- add 4px space -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--End Chat SOAP display row--%>






                <%-- start Chat contacted row --%>
                <div id="ChatContact" class="row divbgcWithPage">
                    <div class="col-xs-12 col-md-12 borderLine1">
                        <div class="row" style="padding: 0px 3px;">
                            <div class="col-xs-12 col  ">
                                <div style="height: 120px">
                                    <%--                <div class="blank4r divbgcWithPageFCFCFC">
                                 <!-- add 4px space -->
                             </div>--%>
                                    <h3 class="font24">Total Chat Contacts Today</h3>
                                    <h4 class="font34">
                                        <asp:Label ID="lblTotalChatHandled" runat="server"></asp:Label>
                                    </h4>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--end Chat Contact row--%>
            </div>
            <%-- end display SOAP Status column--%>







            <div id="Counsellor" class="col-xs-12 col-md-3 divbgcWithPage borderLine1">
                <div class="row ">
                    <div class="col borderLine1">
                        <div class="padding-top16" style="height: 115px;">
                            <h3 class="font30">Counsellor
                                <br />
                                Status</h3>
                            <%--   <h3 class="font30">Status</h3>--%>
                            <p></p>
                        </div>
                    </div>
                </div>

                <%--   <div class="blank4r"><!-- add 4px space --></div>--%>


                <div class="row ">
                    <div class="col borderLine1">
                        <div class="padding-top16" style="height: 710px;">
                            <asp:GridView ID="gvCounsellor" runat="server"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="15"
                                OnSorting="gvCounsellor_Sorting"
                                ShowHeader="False" OnPageIndexChanging="gvCounsellor_PageIndexChanging"
                                BorderStyle="None" GridLines="None"
                                PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                RowStyle-Width="100%" Width="100%" Height="100%">
                                <AlternatingRowStyle BackColor="#e8e8e8" />
                                <Columns>
                                    <asp:BoundField DataField="Weight" HeaderText="Weight"
                                        ItemStyle-BorderStyle="None"
                                        ItemStyle-CssClass="text_right"
                                        HeaderStyle-HorizontalAlign="Right" Visible="False" ReadOnly="True" SortExpression="Weight">
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemStyle BorderStyle="None" CssClass="text_right"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Counsellor" HeaderText="Counsellor" ReadOnly="True"
                                        ItemStyle-CssClass="text_left font22" HeaderStyle-HorizontalAlign="Left" ShowHeader="False" ItemStyle-Height="30px">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle BorderStyle="None" CssClass="text_left font22" Width="55%" Wrap="False"></ItemStyle>
                                    </asp:BoundField>


                                    <asp:BoundField DataField="Status" HeaderText="Status"
                                        ItemStyle-BorderStyle="None"
                                        ItemStyle-CssClass="text_right"
                                        HeaderStyle-HorizontalAlign="Right" ReadOnly="True" ShowHeader="False">
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemStyle BorderStyle="None" CssClass="text_right font20" Width="45%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="20"></PagerSettings>

                                <PagerStyle BorderStyle="None" Font-Size="20px" />

                                <RowStyle Width="100%"></RowStyle>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <asp:Label ID="lblerror" runat="server" Text="" Visible="false"></asp:Label>
    </form>
   <script src="Scripts/readerboard.js" lang="JavaScript"></script>
</body>
</html>
