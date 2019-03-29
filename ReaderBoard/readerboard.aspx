<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readerboard.aspx.cs" Inherits="ReaderBoard.readerboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Readerboard</title>
    <meta http-equiv="refresh" content="300" />
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script src="http://d3js.org/d3.v3.min.js" lang="JavaScript"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/readerboard.css" rel="stylesheet" />
    <script src="https://www.gstatic.com/charts/loader.js" type="text/javascript" ></script>
    <script src="https://cdn.rawgit.com/kimmobrunfeldt/progressbar.js/0.5.6/dist/progressbar.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" type="text/javascript" ></script>
    <script src="Scripts/progress.js"></script>
    <script src="Scripts/custom2.js"></script>
    <script src="Scripts/googleGauge.js"></script>
    <script src="Scripts/liquidFillGauge.js"></script>

</head>
<body>
    <form id="form1" runat="server">
 <div id ="all_contain" class ="row borderLine1">
     <div id ="imgColumn" class="col-xs-12 col-md-2 borderLine1">

         <div id="divlock" class="row borderLine1">
             <div >
                 <div class="clock1">
                     <div id="clock"></div>
                     <div id="date"></div>
                 </div>
             </div>
         </div>
         <div class="row borderLine1">
             <div class="ChatDivDown">
                 <h2>Phone</h2>
             </div>
             <div>
                 <img src="Content/phone-icon3.png" class="phone" />
             </div>
             <div class="padding37">
                 <h4 class="font48">28</h4>
                 <h3 class="font28">In the Queue</h3>
                 
             </div>
         </div>
         <div class="row borderLine1">
             <div class="ChatDivDown">
                 <h2>Chat</h2>
             </div>
             <div class="container_parent">
                 <div id="progress" class="center_child"></div>

             </div>
             <div class="">
                 <h4 class="font48">33</h4>
                 <h3 class="font28">In the Queue</h3>
                 
             </div>


         </div>
     </div>



<%--  start display SOAP Status parts--%>
     <div id="num" class="col-xs-12 col-md-7 borderLine1">
        


         <%--start Phone SOAP display row --%>
         <div id="phone" class="row borderLine1">

             <div id="colEng" class="col-xs-12 col-md-6 borderLine1">
                 <h3 class="font28">English</h3>
                 <div class="row borderLine1">

                     <div class="col-xs-12 col-md-6 borderLine1">
                         <h3 class="font28">KHP </h3>
                         <h3 class="font28">In the Queue</h3>
                         <h4 class="font48">32</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">21:12</h4>
                     </div>



                     <div class="col-xs-12 col-md-6 borderLine1">
                         <h3 class="font28">G2T</h3>
                         <h3 class="font28">In the Queue</h3>
                         <h4 class="font48">15</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">25:12</h4>
                     </div>
                 </div>
             </div>


             <div id="ColFre" class="col-xs-12 col-md-6 borderLine1">
                 <h3 class="font28">French</h3>
                 <div class="row borderLine1">

                     <div class="col-xs-12 col-md-6 borderLine1">
                         <h3 class="font28">KHP </h3>
                         <h3 class="font28">In the Queue</h3>
                         <h4 class="font48">9</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">22:12</h4>
                     </div>

                     <div class="col-xs-12 col-md-6 borderLine1">
                         <h3 class="font28">G2T</h3>
                         <h3 class="font28">In the Queue</h3>
                         <h4 class="font48">14</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">45:31</h4>
                     </div>
                 </div>
             </div>
         </div>
         <%--End Phone SOAP display row--%>





         <%--Start Phone Contacted row--%>
         <div id="PhoneContact" class="row borderLine1">
             <div class="col-xs-12 col-md-12 borderLine1">
                   <h3 class="font28">Total Phone Contacts Today</h3>
                 <h4 class="font48">60</h4>
             </div>
         </div> <%--end Phone Contact row--%>






         <%--start Chat SOAP display row --%>
         <div id="chat" class="row borderLine1">

             <div id="ChatColEng" class="col-xs-12 col-md-6 borderLine1">
          
                 <div class="row borderLine1">

                     <div class="col-xs-12 col-md-6 borderLine1">
                       
                         <h3 class="font28">Web Queue</h3>
                         <h4 class="font48">8</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">15:21</h4>
                     </div>



                     <div class="col-xs-12 col-md-6 borderLine1">
                  
                         <h3 class="font28">App Queue</h3>
                         <h4 class="font48">12</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">21:33</h4>
                     </div>
                 </div>
             </div>


             <div id="ChatColFre" class="col-xs-12 col-md-6 borderLine1">
                 
                 <div class="row borderLine1">

                     <div class="col-xs-12 col-md-6 borderLine1">
                  
                         <h3 class="font28">Web Queue</h3>
                         <h4 class="font48">32</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">43:12</h4>
                     </div>

                     <div class="col-xs-12 col-md-6 borderLine1">
                       
                         <h3 class="font28">APP Queue</h3>
                         <h4 class="font48">16</h4>
                         <h3 class="font28">Longest Wait</h3>
                         <h4 class="font48">19:12</h4>
                     </div>
                 </div>
             </div>
         </div>
         <%--End Chat SOAP display row--%>






        <%-- start Chat contacted row --%>
            <div id="ChatContact" class="row borderLine1">
             <div class="col-xs-12 col-md-12 borderLine1">
                 <h3 class="font28">Total Chat Contacts Today</h3>
                 <h4 class="font48">50</h4>
             </div>
         </div> <%--end Chat Contact row--%>

     </div> <%-- end display SOAP Status column--%>







     <div id ="Counsellor" class="col-xs-12 col-md-3 borderLine1"> 
      <div class="row borderLine1">
          <h3 class="font28">Counsellor</h3>
          <h3 class="font28">Status</h3>
      </div>
       <div class="row borderLine1" >
           <ul style="font-size:28px; text-align:left"  >
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
    </form>
</body>
</html>
