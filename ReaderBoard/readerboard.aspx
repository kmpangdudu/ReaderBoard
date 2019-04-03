<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readerboard.aspx.cs" Inherits="ReaderBoard.readerboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Readerboard</title>
    <meta http-equiv="refresh" content="3000" />
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="http://d3js.org/d3.v3.min.js" lang="JavaScript"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/readerboard1.css" rel="stylesheet" />
    <script src="https://www.gstatic.com/charts/loader.js" type="text/javascript" ></script>
    <script src="https://cdn.rawgit.com/kimmobrunfeldt/progressbar.js/0.5.6/dist/progressbar.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" type="text/javascript" ></script>
    <script src="Scripts/progress.js"></script>
    <script src="Scripts/custom2.js"></script>
    <script src="Scripts/googleGauge.js"></script>
    <script src="Scripts/liquidFillGauge.js"></script>
    <!-- commented .row margin R786 of bootstrap.css  -->
</head>
<body>
    <form id="form1" runat="server">
 <div id ="all_contain" class ="container-fluid">
     <div id ="imgColumn" class="col-xs-12 col-md-2 divbgcWithPage borderLine1 ">

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
                     <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                     <h2>Phone</h2>
                     <img src="Content/phone-icon3.png" class="phone" />
                     <div class="blank12r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                     <h4 class="font42">28</h4>
                     <h3 class="font26">In the Queue</h3>
                     <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                 </div>
             </div>
         </div>
         <div class="blank4r"><!-- add 4px space --></div>
         <div class="row">
             <div class="col ChatDivDown borderLine1">
                 <div>
                     <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                     <h2>Chat</h2>
                     <div id="progress" class="center_child"></div>
                     <div class="blank8r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                     <h4 class="font42">33</h4>
                     <h3 class="font26">In the Queue</h3>
                     <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                 </div>
             </div>
         </div>
</div>


<%--  start display SOAP Status parts--%>
     <div id="num" class="col-xs-12 col-md-7 divbgcWithPage borderLine1">
        


         <%--start Phone SOAP display row --%>
         <div id="phone" class="row divbgcWithPage">

             <div id="colEng" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
                 <div>
                     <h3 class="font26">English</h3>
                 </div>
                 <div class="blank4r">
                     <!-- add 4px space -->
                 </div>
                 <div class="row">
                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">KHP </h3>
                         </div>
                     </div>
                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">G2T </h3>
                         </div>
                     </div>
                 </div>

      <%--           <div class="blank4r">
                     <!-- add 4px space -->
                 </div>--%>

                 <div class="row ">
                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">In the Queue</h3>
                             <h4 class="font42">32</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">21:12</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>

                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">In the Queue</h3>
                             <h4 class="font42">15</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">25:12</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>
                 </div>
             </div>


             <div id="ColFre" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
                 <div>
                     <h3 class="font26">French</h3>
                 </div>
                 <div class="blank4r">
                     <!-- add 4px space -->
                 </div>
                 <div class="row">
                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">KHP </h3>
                         </div>
                     </div>
                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">G2T </h3>
                         </div>
                     </div>
                 </div>
<%--                 <div class="blank4r">
                     <!-- add 4px space -->
                 </div>--%>


                 <div class="row ">
                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">In the Queue</h3>
                             <h4 class="font42">9</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">22:12</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>

                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">In the Queue</h3>
                             <h4 class="font42">14</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">45:31</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
         <%--End Phone SOAP display row--%>


    


         <%--Start Phone Contacted row--%>
         <div id="PhoneContact" class="row divbgcWithPage">
             <div class="col-xs-12 col-md-12 borderLine1">
                 <div>
                   <h3 class="font26">Total Phone Contacts Today</h3>
                 <h4 class="font42">60</h4></div>
             </div>
         </div> <%--end Phone Contact row--%>

          


         <%--start Chat SOAP display row --%>
         <div id="chat" class="row divbgcWithPage">

             <div id="ChatColEng" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
          
                 <div class="row ">

                     <div class="col-xs-12 col-md-6   borderLine1">
                         <div>
                             <h3 class="font26">Web Queue</h3>
                             <h4 class="font42">8</h4>
                             <div class="blank4r divbgcWithPageFCFCFC">
                                 <!-- add 4px space -->
                             </div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">15:21</h4>
                             <div class="blank4r divbgcWithPageFCFCFC">
                                 <!-- add 4px space -->
                             </div>
                         </div>

                     </div>



                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">App Queue</h3>
                             <h4 class="font42">12</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">21:33</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>
                 </div>
             </div>


             <div id="ChatColFre" class="col-xs-12 col-md-6 divbgcWithPage borderLine1">
                 
                 <div class="row ">

                     <div class="col-xs-12 col-md-6  borderLine1">
                         <div>
                             <h3 class="font26">Web Queue</h3>
                             <h4 class="font42">32</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">43:12</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>

                     <div class="col-xs-12 col-md-6 borderLine1">
                         <div>
                             <h3 class="font26">App Queue</h3>
                             <h4 class="font42">16</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                             <h3 class="font26">Longest Wait</h3>
                             <h4 class="font42">19:12</h4>
                             <div class="blank4r divbgcWithPageFCFCFC"><!-- add 4px space --></div>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
         <%--End Chat SOAP display row--%>


     



        <%-- start Chat contacted row --%>
         <div id="ChatContact" class="row divbgcWithPage">
             <div class="col-xs-12 col-md-12 borderLine1">
                 <div>
                     <h3 class="font26">Total Chat Contacts Today</h3>
                     <h4 class="font42">50</h4>
                 </div>
             </div>
         </div> <%--end Chat Contact row--%>

     </div> <%-- end display SOAP Status column--%>







     <div id="Counsellor" class="col-xs-12 col-md-3 divbgcWithPage borderLine1">
         <div class="row ">
             <div class="col borderLine1">
                 <div class="padding-top16">
                     <h3 class="font26">Counsellor</h3>
                     <h3 class="font26">Status</h3>
                 </div>
             </div>
         </div>

      <%--   <div class="blank4r"><!-- add 4px space --></div>--%>

         <div class="row ">
             <div class="col divbgcWithPageFCFCFC borderLine1">
                 <ul style="font-size: 28px; text-align: left">
                     <li>Mary Simon   on a call</li>
                     <li>Bill Simth  ready</li>
                     <li>David Bush   available</li>
                     <li>Joe  logged on</li>
                     <li>John  on hold</li>
                     <li>Brittany Hunt  logged off</li>
                     <li>Anupreet Minhas on external conference</li>
                     <li>Andrée-Anne Forest alerted of an incoming call</li>
                     <li>Carley Leathem  responding to customer email</li>
                 </ul>
             </div>
         </div>
  </div>

 </div>
    </form>
</body>
</html>
