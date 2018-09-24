using ReaderBoard.DataModel;
using ReaderBoard.iceCTI;
using System;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;

namespace ReaderBoard
{
    struct RealTimeData
    {
        public string NumHandledLessThanTarget;
        public string NumOffered;
        public string LongestWaitTime;
        public string AverageWaitTime; // Estimate wait time;
        public string HandledToday; //NumHandledInThisQueue, Number of handled in this queue.
        public string CurrentInQueued;
        public string CounselorAvailable;
        public string CounselorLogin;
        public string CounselorOnContact;
        public string HandledQueueTime;
    }

    struct Last24hrGrade
    {
        public decimal PhoneAllGrade;
        public decimal PhoneGrade;
        public decimal G2TGrade;

        public decimal ChatAllGrade;
        public decimal ChatGrade;
        public decimal ChatAppGrade;

    }


    struct LastHourGrade
    {
        public decimal PhoneAllGrade;
        public decimal PhoneGrade;
        public decimal G2TGrade;

        public decimal ChatAllGrade;
        public decimal ChatGrade;
        public decimal ChatAppGrade;

    }


    struct LastHourWaitTime
    {
        public decimal PhoneWaitTime;
        public decimal ChatWaitTime;
    }


    public partial class _Default : Page
    {
        RAMEntities efContext = new RAMEntities();

        CTIServiceClient client = new CTIServiceClient();

        DateTime today = DateTime.Now;
        string refreshing = Properties.Settings.Default.DashboardRefreshing;//Default 3- second;
        string szServerName = Properties.Settings.Default.szServerName; //"ice1"
        string dwSwitchID = Properties.Settings.Default.dwSwitchID; //"11006";
        string iQueueID_Phone_ENG = Properties.Settings.Default.Phone_ENG;//"6001";
        string iQueueID_Phone_FRE = Properties.Settings.Default.Phone_FRE;//"6002";
        string iQueueID_G2T_ENG = Properties.Settings.Default.G2T_ENG;//"6013";
        string iQueueID_G2T_FRE = Properties.Settings.Default.G2T_FRE;//"6014";
        string iQueueID_Chat_ENG = Properties.Settings.Default.Chat_ENG;//"6007";
        string iQueueID_Chat_FRE = Properties.Settings.Default.Chat_FRE;//"6008";
        string iQueueID_ChatApp_ENG = Properties.Settings.Default.ChatApp_ENG;//"6020";
        string iQueueID_ChatApp_FRE = Properties.Settings.Default.ChatApp_FRE;//"6021";

 

        int dayTimeStart = Properties.Settings.Default.dayTimeStart;
        int dayTimeEnd = Properties.Settings.Default.dayTimeEnd;

        int ChatEnDayStart = Properties.Settings.Default.ChatEnDayStart;
        int ChatEnDayEnd = Properties.Settings.Default.ChatEnDayEnd;
        int ChatEnTimeStart = Properties.Settings.Default.ChatEnTimeStart;
        int ChatEnTimeEnd = Properties.Settings.Default.ChatEnTimeEnd;

        int ChatFrDayStart = Properties.Settings.Default.ChatFrDayStart;
        int ChatFrDayEnd = Properties.Settings.Default.ChatFrDayEnd;
        int ChatFrTimeStart = Properties.Settings.Default.ChatFrTimeStart;
        int ChatFrTimeEnd = Properties.Settings.Default.ChatFrTimeEnd;

        int ChatClosed = Properties.Settings.Default.ChatClosed;


         RealTimeData  stru_Phone_ENG;
         RealTimeData  stru_Phone_FRE;
         RealTimeData  stru_G2T_ENG  ;
         RealTimeData  stru_G2T_FRE  ;
         RealTimeData  stru_Chat_ENG ;
         RealTimeData  stru_Chat_FRE;
         RealTimeData  stru_ChatApp_ENG ;
         RealTimeData  stru_ChatApp_FRE;

         Last24hrGrade stru_last24HrGrade ;
         LastHourGrade stru_lastHourGrade;

         LastHourWaitTime stru_lastHourWaitTime;
   

        protected bool ChatWorking()
        {
            //if ((Convert.ToInt32(today.DayOfWeek) == 2) ||
            //        (ChatEnTimeEnd <= today.Hour && today.Hour < ChatEnTimeStart))
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // refreshing is the number of seconds , default value is 300 = 5 mintues in setting section
            //Response.AppendHeader("Refresh", refreshing);
         

            if (!IsPostBack)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                   
                // var   queues = efContext.Proc_GetQueue();
                //foreach (Proc_GetQueue_Result x in queues)
                //{
                //    switch  (x.Queue)
                //    {
                //        case "szServerName" : szServerName = x.QueueValue; break;
                //        case "dwSwitchID"   : dwSwitchID = x.QueueValue; break;
                //        case "Phone_ENG"    : iQueueID_Phone_ENG =x.QueueValue; break;
                //        case "Phone_FRE"    : iQueueID_Phone_FRE =   x.QueueValue; break;
                //        case "G2T_ENG"      : iQueueID_G2T_ENG =     x.QueueValue; break;
                //        case "G2T_FRE"      : iQueueID_G2T_FRE =     x.QueueValue; break;
                //        case "Chat_ENG"     : iQueueID_Chat_ENG =    x.QueueValue; break;
                //        case "Chat_FRE"     : iQueueID_Chat_FRE =    x.QueueValue; break;
                //        case "ChatApp_ENG"  : iQueueID_ChatApp_ENG = x.QueueValue; break;
                //        case "ChatApp_FRE"  : iQueueID_ChatApp_FRE = x.QueueValue; break;
                //    }
                //}

                HiddendayTimeStart.Value =     dayTimeStart.ToString();
                HiddendayTimeEnd.Value =       dayTimeEnd.ToString();

                HiddenChatEnDayStart.Value =   ChatEnDayStart.ToString();
                HiddenChatEnDayEnd.Value =     ChatEnDayEnd.ToString();

                HiddenChatEnTimeStart.Value =  ChatEnTimeStart.ToString();
                HiddenChatEnTimeEnd.Value =    ChatEnTimeEnd.ToString();
                HiddenChatFrDayStart.Value =   ChatFrDayStart.ToString();
                HiddenChatFrDayEnd.Value =     ChatFrDayEnd.ToString();
                HiddenChatFrTimeStart.Value =  ChatFrTimeStart.ToString();
                HiddenChatFrTimeEnd.Value =    ChatFrTimeEnd.ToString();
                HiddenChatClosed.Value =       ChatClosed.ToString();

            };

            try
            {
                // applying theme
                ApplyTheme();

                // get SOAP DATA
                getSOAP();

                //get cached last hour grade value from SQL SERVER
                getLastHourGrade();

                //get cached last 24 hours grade value from SQL SERVER
                getLast24HrGrade();

                //get catched last hour weighted mean wait time
                getLastHourWaitTime();

                Phone();

                //if today is not Tuesday or now is not between 2am and 6pm (18:00)
                // need process Chat section and add a shadow on it
                if (ChatWorking())
                {
                    //processing 
                    Chat();
                }
                else
                {
                    //chat div add a shadow
                    //dimmed is a <div runnat= 'server' /> 
                    dimmed.Attributes.CssStyle.Add("opacity", Properties.Settings.Default.dimOpacity);
                }

                // when Tuesday in the night add more gery
                if ((dayTimeEnd <= today.Hour) && ((Convert.ToInt32(today.DayOfWeek) == 2)) )
                {
                    dimmed.Attributes.CssStyle.Add("opacity", Properties.Settings.Default.dimOpacityNight);
                }

                //DrawChat();   //<-- visual studio chart control

            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }

        }

        protected void ApplyTheme()
        {
 
 
            if ((dayTimeStart <= today.Hour) & (today.Hour < dayTimeEnd))  // Day light theme
            {
                HtmlGenericControl myCss = new HtmlGenericControl();
                myCss.TagName = "link";
                myCss.Attributes.Add("type", "text/css");
                myCss.Attributes.Add("rel", "stylesheet");
                myCss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("Content/readerboard.css")));
                this.Page.Header.Controls.AddAt(1, myCss);

            }
            else  // Night Dark Theme
            {
                HtmlGenericControl myCss = new HtmlGenericControl();
                myCss.TagName = "link";
                myCss.Attributes.Add("type", "text/css");
                myCss.Attributes.Add("rel", "stylesheet");
                myCss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("Content/dark.css")));
                this.Page.Header.Controls.AddAt(1, myCss);

            }
        }
 
        protected void Phone()
        {

            try
            {
                double[] QLongestWaitTime = new double[4];
                QLongestWaitTime[0] = Convert.ToDouble(stru_Phone_ENG.LongestWaitTime);
                QLongestWaitTime[1] = Convert.ToDouble(stru_Phone_FRE.LongestWaitTime);
                QLongestWaitTime[2] = Convert.ToDouble(stru_G2T_ENG.LongestWaitTime);
                QLongestWaitTime[3] = Convert.ToDouble(stru_G2T_FRE.LongestWaitTime);
                double LongestWaitTime = QLongestWaitTime.Max() / 60; // Convert to mintue
                LongestWaitTime = LongestWaitTime < 0 ? 0 : LongestWaitTime;

                // *****   AverageWaitTime **** //
                Double AverageWaitTime = 0.0;
                //AverageWaitTime = Convert.ToDouble(stru_lastHourWaitTime.PhoneWaitTime);  //weighted mean

                int TotalNumOfHandledInThisQueue = 0;
                    TotalNumOfHandledInThisQueue = Convert.ToInt32(stru_Phone_ENG.HandledToday)
                        + Convert.ToInt32(stru_Phone_FRE.HandledToday)
                        + Convert.ToInt32(stru_G2T_ENG.HandledToday)
                        + Convert.ToInt32(stru_G2T_FRE.HandledToday);

                AverageWaitTime = Convert.ToInt32(stru_Phone_ENG.HandledQueueTime) //* Convert.ToInt32(stru_Phone_ENG.HandledToday)
                                + Convert.ToInt32(stru_Phone_FRE.HandledQueueTime) //* Convert.ToInt32(stru_Phone_FRE.HandledToday)
                                + Convert.ToInt32(stru_G2T_ENG.HandledQueueTime) //* Convert.ToInt32(stru_G2T_ENG.HandledToday)
                                + Convert.ToInt32(stru_G2T_FRE.HandledQueueTime) //* Convert.ToInt32(stru_G2T_FRE.HandledToday);
                                ;
                AverageWaitTime = AverageWaitTime / TotalNumOfHandledInThisQueue;
                AverageWaitTime = (AverageWaitTime) / 60; // Average , Convert to mintue
                AverageWaitTime = AverageWaitTime < 0 ? 0 : AverageWaitTime;







                int CallToday = 
                   Convert.ToInt32(stru_Phone_ENG.HandledToday) 
                    +Convert.ToInt32(stru_Phone_FRE.HandledToday) 
                    +Convert.ToInt32(stru_G2T_ENG.HandledToday) 
                    +Convert.ToInt32(stru_G2T_FRE.HandledToday);
                CallToday = CallToday < 0 ? 0 : CallToday;

                int PeopleInQueue = 
                   Convert.ToInt32(stru_Phone_ENG.CurrentInQueued) 
                    +Convert.ToInt32(stru_Phone_FRE.CurrentInQueued) 
                    +Convert.ToInt32(stru_G2T_ENG.CurrentInQueued) 
                    +Convert.ToInt32(stru_G2T_FRE.CurrentInQueued);
                PeopleInQueue = PeopleInQueue < 0 ? 0 : PeopleInQueue;

                int CounselorAvailable = 
                   Convert.ToInt32(stru_Phone_ENG.CounselorAvailable) 
                    +Convert.ToInt32(stru_Phone_FRE.CounselorAvailable) 
                    +Convert.ToInt32(stru_G2T_ENG.CounselorAvailable) 
                    +Convert.ToInt32(stru_G2T_FRE.CounselorAvailable);
                CounselorAvailable = CounselorAvailable < 1 ? 0 : CounselorAvailable;

                int CounselorLogin = 
                   Convert.ToInt32(stru_Phone_ENG.CounselorLogin) 
                    +Convert.ToInt32(stru_Phone_FRE.CounselorLogin) 
                    +Convert.ToInt32(stru_G2T_ENG.CounselorLogin) 
                    +Convert.ToInt32(stru_G2T_FRE.CounselorLogin);
                CounselorLogin = CounselorLogin < 1 ? 0 : CounselorLogin;

                int CounselorOnContact =
                   Convert.ToInt32(stru_Phone_ENG.CounselorOnContact)
                    +Convert.ToInt32(stru_Phone_FRE.CounselorOnContact)
                    +Convert.ToInt32(stru_G2T_ENG.CounselorOnContact)
                    +Convert.ToInt32(stru_G2T_FRE.CounselorOnContact);
                CounselorOnContact = CounselorOnContact < 1 ? 0 : CounselorOnContact;

 

                //lblPhoneGradeService.Value = (iNumOffered != 0 ? ASA : 0.00 ).ToString("N2"); 
                decimal p = stru_lastHourGrade.PhoneAllGrade;
                p = (p != (decimal)0.0 ? p : (decimal)0.00);
                //lblPhoneGradeService.Value = ((decimal)1.00 * p).ToString("N2");
                lblPhoneGradeService.Value = Math.Round(p).ToString();

                //lblPhoneGradeService24.Value = (iNumOffered != 0 ? ASA : 0.00 ).ToString("N2"); 
                decimal p24 = stru_last24HrGrade.PhoneAllGrade;
                p24 = (p24 != (decimal)0.0 ? p24 : (decimal)0.00);
                //lblPhoneGradeService24.Value = ((decimal)1.00 * p24).ToString("N2");
                lblPhoneGradeService24.Value = Math.Round(p24).ToString();



                var timeSpan = TimeSpan.FromMinutes(LongestWaitTime);
                lblPhoneLongestWaitTime.Text = timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");

                timeSpan = TimeSpan.FromMinutes(AverageWaitTime);
                //lblPhoneAverageWaitTime.Text = timeSpan.Hours.ToString("0") +":"+ timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
                lblPhoneAverageWaitTime.Text =  timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");


                lblPhoneCallToday.Text = CallToday.ToString();
                lblPhonePeopleInQueue.Value = PeopleInQueue.ToString();
                //lblPhoneCounselorAvailable.Text = CounselorAvailable.ToString();  // <-- sum
                lblPhoneCounselorAvailable.Text = stru_Phone_ENG.CounselorAvailable==null? "0" : stru_Phone_ENG.CounselorAvailable;
                lblPhoneCounselorLogin.Text = CounselorLogin.ToString();
                //lblPhoneCounselorOnContact.Text = CounselorOnContact.ToString(); // <-- sum
                lblPhoneCounselorOnContact.Text = stru_Phone_ENG.CounselorOnContact==null?"0": stru_Phone_ENG.CounselorOnContact;
                //lblPhoneCounselorNotReady.Text = (CounselorLogin - CounselorAvailable - CounselorOnContact).ToString();  // <-- sum
                lblPhoneCounselorNotReady.Text = (Convert.ToInt32 (stru_Phone_ENG.CounselorLogin)
                                                    -Convert.ToInt32(stru_Phone_ENG.CounselorAvailable )
                                                    -Convert.ToInt32(stru_Phone_ENG.CounselorOnContact)).ToString();
                 
                HiddenPhone_Eng_In.Value = stru_Phone_ENG.CounselorLogin == null? "0" : stru_Phone_ENG.CounselorLogin;
                HiddenPhone_Eng_Availabe.Value = stru_Phone_ENG.CounselorAvailable == null ?  "0" : stru_Phone_ENG.CounselorAvailable;
                HiddenPhone_Fre_In.Value = stru_Phone_FRE.CounselorLogin == null ?  "0" : stru_Phone_FRE.CounselorLogin;
                HiddenPhone_Fre_Availabe.Value = stru_Phone_FRE.CounselorAvailable == null ?  "0" : stru_Phone_FRE.CounselorAvailable;
                HiddenG2T_Eng_In.Value = stru_G2T_ENG.CounselorLogin == null ?  "0" : stru_G2T_ENG.CounselorLogin;
                HiddenG2T_Eng_Availabe.Value = stru_G2T_ENG.CounselorAvailable == null ?  "0" : stru_G2T_ENG.CounselorAvailable;
                HiddenG2T_Fre_In.Value = stru_G2T_FRE.CounselorLogin == null ?  "0" : stru_G2T_FRE.CounselorLogin;
                HiddenG2T_Fre_Availabe.Value = stru_G2T_FRE.CounselorAvailable == null ?  "0" : stru_G2T_FRE.CounselorAvailable;
                HiddenPhone_Eng_AgentOnContact.Value = stru_Phone_ENG.CounselorOnContact == null ?  "0" : stru_Phone_ENG.CounselorOnContact;
                HiddenPhone_Fre_AgentOnContact.Value = stru_Phone_FRE.CounselorOnContact == null ?  "0" : stru_Phone_FRE.CounselorOnContact;
                HiddenG2T_Eng_AgentOnContact.Value = stru_G2T_ENG.CounselorOnContact == null ?  "0" : stru_G2T_ENG.CounselorOnContact;
                HiddenG2T_Fre_AgentOnContact.Value = stru_G2T_FRE.CounselorOnContact == null ?  "0" : stru_G2T_FRE.CounselorOnContact;
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }
        }


        protected void Chat()
        {
            
            try
            {

                double[] QLongestWaitTime = new double[4];
                QLongestWaitTime[0] = Convert.ToDouble(stru_Chat_ENG.LongestWaitTime);
                QLongestWaitTime[1] = Convert.ToDouble(stru_Chat_FRE.LongestWaitTime);
                QLongestWaitTime[2] = Convert.ToDouble(stru_ChatApp_ENG.LongestWaitTime);
                QLongestWaitTime[3] = Convert.ToDouble(stru_ChatApp_FRE.LongestWaitTime);
                double LongestWaitTime = QLongestWaitTime.Max()  / 60; //changing to minute
                LongestWaitTime = LongestWaitTime < 0 ? 0 : LongestWaitTime;

                double AverageWaitTime = 0.0;

                //AverageWaitTime = Convert.ToDouble(stru_lastHourWaitTime.ChatWaitTime);  //weighted mean;

                int TotalNumOfHandledInThisQueue = 0;
                TotalNumOfHandledInThisQueue = Convert.ToInt32(stru_Chat_ENG.HandledToday)
                                            + Convert.ToInt32(stru_Chat_FRE.HandledToday)
                                            + Convert.ToInt32(stru_ChatApp_ENG.HandledToday)
                                            + Convert.ToInt32(stru_ChatApp_FRE.HandledToday);

                AverageWaitTime = Convert.ToInt32(stru_Chat_ENG.HandledQueueTime) //* Convert.ToInt32(stru_Chat_ENG.HandledToday)
                                + Convert.ToInt32(stru_Chat_FRE.HandledQueueTime) //* Convert.ToInt32(stru_Chat_FRE.HandledToday)
                                + Convert.ToInt32(stru_ChatApp_ENG.HandledQueueTime) //* Convert.ToInt32(stru_ChatApp_ENG.HandledToday)
                                + Convert.ToInt32(stru_ChatApp_FRE.HandledQueueTime) //* Convert.ToInt32(stru_ChatApp_FRE.HandledToday);
                                ;
                AverageWaitTime = AverageWaitTime / TotalNumOfHandledInThisQueue;

                AverageWaitTime = (AverageWaitTime) / 60 ; //sverage, changing to minute
                AverageWaitTime = AverageWaitTime < 0 ? 0 : AverageWaitTime;

                int CallToday =                 
                   Convert.ToInt32(stru_Chat_ENG.HandledToday) 
                    +Convert.ToInt32(stru_Chat_FRE.HandledToday) 
                    +Convert.ToInt32(stru_ChatApp_ENG.HandledToday) 
                    +Convert.ToInt32(stru_ChatApp_FRE.HandledToday);
                CallToday = CallToday < 0 ? 0 : CallToday;

                int PeopleInQueue =             
                   Convert.ToInt32(stru_Chat_ENG.CurrentInQueued) 
                    +Convert.ToInt32(stru_Chat_FRE.CurrentInQueued) 
                    +Convert.ToInt32(stru_ChatApp_ENG.CurrentInQueued) 
                    +Convert.ToInt32(stru_ChatApp_FRE.CurrentInQueued);
                PeopleInQueue = PeopleInQueue < 0 ? 0 : PeopleInQueue;

                int CounselorAvailable =        
                   Convert.ToInt32(stru_Chat_ENG.CounselorAvailable) 
                    +Convert.ToInt32(stru_Chat_FRE.CounselorAvailable) 
                    +Convert.ToInt32(stru_ChatApp_ENG.CounselorAvailable) 
                    +Convert.ToInt32(stru_ChatApp_FRE.CounselorAvailable);
                CounselorAvailable = CounselorAvailable < 1 ? 0 : CounselorAvailable;

                int CounselorLogin =            
                   Convert.ToInt32(stru_Chat_ENG.CounselorLogin) 
                    +Convert.ToInt32(stru_Chat_FRE.CounselorLogin) 
                    +Convert.ToInt32(stru_ChatApp_ENG.CounselorLogin) 
                    +Convert.ToInt32(stru_ChatApp_FRE.CounselorLogin);
                CounselorLogin = CounselorLogin < 1 ? 0 : CounselorLogin;

                int CounselorOnContact =
                   Convert.ToInt32(stru_Chat_ENG.CounselorOnContact)
                    +Convert.ToInt32(stru_Chat_FRE.CounselorOnContact)
                    +Convert.ToInt32(stru_ChatApp_ENG.CounselorOnContact)
                    +Convert.ToInt32(stru_ChatApp_FRE.CounselorOnContact);
                CounselorOnContact = CounselorOnContact < 1 ? 0 : CounselorOnContact;
 

                //lblChatGradeService.Value = (iNumOffered != 0 ? asa1 : 0.00).ToString("N2");
                decimal c = stru_lastHourGrade.ChatAllGrade;
                c = (c != (decimal)0.0 ? c : (decimal)0.00);
                //lblChatGradeService.Value = ((decimal)1.00 * c).ToString("N2");
                lblChatGradeService.Value = Math.Round(c).ToString();

                //lblChatGradeService24.Value = (iNumOffered != 0 ? asa1 : 0.00).ToString("N2");
                decimal c24 = stru_last24HrGrade.ChatAllGrade;
                c24 = (c24 != (decimal)0.0 ? c24 : (decimal)0.00);
                //lblChatGradeService24.Value = ((decimal)1.00 * c24).ToString("N2");
                lblChatGradeService24.Value = Math.Round(c24).ToString();

                var timeSpan = TimeSpan.FromMinutes(LongestWaitTime);
                lblChatLongestWaitTime.Text = timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");

                timeSpan = TimeSpan.FromMinutes(AverageWaitTime);
                lblChatAverageWaitTime.Text = timeSpan.Minutes.ToString("00") + ":"+timeSpan.Seconds.ToString("00");
                //lblChatAverageWaitTime.Text = timeSpan.Hours.ToString("0") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");

                lblChatCallToday.Text = CallToday.ToString();
                lblChatPeopleInQueue.Value = PeopleInQueue.ToString();
                //lblChatCounselorAvailable.Text = CounselorAvailable.ToString(); // <-- sum
                lblChatCounselorAvailable.Text = stru_Chat_ENG.CounselorAvailable == null? "0": stru_Chat_ENG.CounselorAvailable;
                lblChatCounselorLogin.Text = stru_Chat_ENG.CounselorLogin;
                //lblChatCounselorOnContact.Text = CounselorOnContact.ToString();  // <-- sum
                lblChatCounselorOnContact.Text = stru_Chat_ENG.CounselorOnContact == null? "0": stru_Chat_ENG.CounselorOnContact;
                //lblChatCounselorNotReady.Text = (CounselorLogin - CounselorAvailable - CounselorOnContact).ToString(); //<-- sum
                lblChatCounselorNotReady.Text = (Convert.ToInt32(stru_Chat_ENG.CounselorLogin)
                    -Convert.ToDecimal (stru_Chat_ENG.CounselorAvailable )
                    -Convert.ToDecimal (stru_Chat_ENG.CounselorOnContact)).ToString();

                HiddenWebChat_Eng_In.Value = stru_Chat_ENG.CounselorLogin == null? "0" : stru_Chat_ENG.CounselorLogin;
                HiddenWebChat_Eng_Avaiable.Value = stru_Chat_ENG.CounselorAvailable == null ? "0" : stru_Chat_ENG.CounselorAvailable;
                HiddenWebChat_Fre_In.Value = stru_Chat_FRE.CounselorLogin == null ? "0" : stru_Chat_FRE.CounselorLogin;
                HiddenWebChat_Fre_Avaiable.Value = stru_Chat_FRE.CounselorAvailable == null ? "0" : stru_Chat_FRE.CounselorAvailable;
                HiddenChatApp_Eng_In.Value = stru_ChatApp_ENG.CounselorLogin == null ? "0" : stru_ChatApp_ENG.CounselorLogin;
                HiddenChatApp_Eng_Avaiable.Value = stru_ChatApp_ENG.CounselorAvailable == null ? "0" : stru_ChatApp_ENG.CounselorAvailable;
                HiddenChatApp_Fre_In.Value = stru_ChatApp_FRE.CounselorLogin == null ? "0" : stru_ChatApp_FRE.CounselorLogin;
                HiddenChatApp_Fre_Avaiable.Value = stru_ChatApp_FRE.CounselorAvailable == null ? "0" : stru_ChatApp_FRE.CounselorAvailable;
                HiddenWebChat_Eng_AgentOnContact.Value = stru_Chat_ENG.CounselorOnContact == null ? "0" : stru_Chat_ENG.CounselorOnContact;
                HiddenWebChat_Fre_AgentOnContact.Value = stru_Chat_FRE.CounselorOnContact == null ? "0" : stru_Chat_FRE.CounselorOnContact;
                HiddenChatApp_Eng_AgentOnContact.Value = stru_ChatApp_ENG.CounselorOnContact == null ? "0" : stru_ChatApp_ENG.CounselorOnContact;
                HiddenChatApp_Fre_AgentOnContact.Value = stru_ChatApp_FRE.CounselorOnContact == null ? "0" : stru_ChatApp_FRE.CounselorOnContact;
            }

            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }
        }

        protected void getSOAP()
        {
            //Phone_eng          
            stru_Phone_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);


            //phone_fre
            stru_Phone_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);

            //G2T_ENG
            stru_G2T_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);

            //G2T_FRE
            stru_G2T_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);


            if ( ChatWorking() ) // Day light theme 在6:00Pm 到 凌晨 2：00am 就 不做下面的
            {
                //Chat_ENG
                stru_Chat_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);

                //Chat_FRE
                stru_Chat_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);

                //ChatApp_ENG
                stru_ChatApp_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);

                //ChatApp_FRE
                stru_ChatApp_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CounselorOnContact = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.HandledQueueTime = client.GetHandledQueuedTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            }


        }


        protected void getLast24HrGrade()
        {
            //Proc_Last24Grade_Result
            var last24HrGrade = efContext.Proc_Last24Grade();

            foreach (Proc_Last24Grade_Result x in last24HrGrade)
            {
            stru_last24HrGrade.PhoneAllGrade = (decimal)x.PhoneAllGrade;
            stru_last24HrGrade.PhoneGrade = (decimal)x.PhoneGrade;
            stru_last24HrGrade.G2TGrade = (decimal)x.G2TGrade;
            
                if (ChatWorking())
                {
                    stru_last24HrGrade.ChatAllGrade = (decimal)x.ChatAllGrade;
                    stru_last24HrGrade.ChatAppGrade = (decimal)x.ChatAppGrade;
                    stru_last24HrGrade.ChatGrade = (decimal)x.ChatGrade;
                }
                else
                {
                    stru_last24HrGrade.ChatAllGrade = 0.0m;
                    stru_last24HrGrade.ChatAppGrade = 0.0m;
                    stru_last24HrGrade.ChatGrade = 0.0m;
                }

            }
        }



        protected void getLastHourGrade()
        {
            //Proc_LastHourGrade_Result
            var lastHourGrade = efContext.Proc_LastHourGrade();

            foreach (Proc_LastHourGrade_Result x in lastHourGrade)
            {
                stru_lastHourGrade.PhoneAllGrade = (decimal)x.PhoneAllGrade;
                stru_lastHourGrade.PhoneGrade = (decimal)x.PhoneGrade;
                stru_lastHourGrade.G2TGrade = (decimal)x.G2TGrade;

                if (ChatWorking())
                {
                    stru_lastHourGrade.ChatAllGrade = (decimal)x.ChatAllGrade;
                    stru_lastHourGrade.ChatAppGrade = (decimal)x.ChatAppGrade;
                    stru_lastHourGrade.ChatGrade = (decimal)x.ChatGrade;
                }
                else
                {
                    stru_lastHourGrade.ChatAllGrade = 0.0m;
                    stru_lastHourGrade.ChatAppGrade = 0.0m;
                    stru_lastHourGrade.ChatGrade = 0.0m;
                }

            }
        }



        protected void getLastHourWaitTime()
        {
            //Proc_LastHourWaitTime_Result
            var lasthourWaitTime = efContext.Proc_LastHourWaitTime();



            foreach (Proc_LastHourWaitTime_Result x in lasthourWaitTime)
            {

                stru_lastHourWaitTime.PhoneWaitTime = (decimal)x.phoneWaitTime;

                if (ChatWorking())
                {
                    stru_lastHourWaitTime.ChatWaitTime = (decimal)x.ChatWaitTime;
                }
                else
                {
                    stru_lastHourWaitTime.ChatWaitTime = 0.0m;
                }

            }
        }
    }
}