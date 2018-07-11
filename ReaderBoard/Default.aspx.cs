using ReaderBoard.DataModel;
using ReaderBoard.iceCTI;
using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ReaderBoard
{
    struct RealTimeData
    {
        public string NumHandledLessThanTarget;
        public string NumOffered;
        public string LongestWaitTime;
        public string AverageWaitTime;
        public string HandledToday;
        public string CurrentInQueued;
        public string CounselorAvailable;
        public string CounselorLogin;
        public string CounselorOnContact;
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


    public partial class _Default : Page
    {
        RAMEntities efContext = new RAMEntities();

        CTIServiceClient client = new CTIServiceClient();

        //string refreshing =  Properties.Settings.Default.DashboardRefreshing;//Default 3- second;
        //string szServerName = Properties.Settings.Default.szServerName; //"ice1"
        //string dwSwitchID = Properties.Settings.Default.dwSwitchID; //"11006";
        //string iQueueID_Phone_ENG = Properties.Settings.Default.Phone_ENG;//"6001";
        //string iQueueID_Phone_FRE = Properties.Settings.Default.Phone_FRE;//"6002";
        //string iQueueID_G2T_ENG = Properties.Settings.Default.G2T_ENG;//"6013";
        //string iQueueID_G2T_FRE = Properties.Settings.Default.G2T_FRE;//"6014";
        //string iQueueID_Chat_ENG = Properties.Settings.Default.Chat_ENG;//"6007";
        //string iQueueID_Chat_FRE = Properties.Settings.Default.Chat_FRE;//"6008";
        //string iQueueID_ChatApp_ENG = Properties.Settings.Default.ChatApp_ENG;//"6020";
        //string iQueueID_ChatApp_FRE = Properties.Settings.Default.ChatApp_FRE;//"6021";

        int dayTimeStart = Properties.Settings.Default.dayTimeStart;
        int dayTimeEnd = Properties.Settings.Default.dayTimeEnd;
        string refreshing =  Properties.Settings.Default.DashboardRefreshing;//Default 3- second;
        string szServerName    ; //"ice1"
        string dwSwitchID ; //"11006";
        string iQueueID_Phone_ENG;//"6001";
        string iQueueID_Phone_FRE;//"6002";
        string iQueueID_G2T_ENG;//"6013";
        string iQueueID_G2T_FRE;//"6014";
        string iQueueID_Chat_ENG;//"6007";
        string iQueueID_Chat_FRE;//"6008";
        string iQueueID_ChatApp_ENG;//"6020";
        string iQueueID_ChatApp_FRE  ;//"6021";

         RealTimeData  stru_Phone_ENG;
         RealTimeData  stru_Phone_FRE;
         RealTimeData  stru_G2T_ENG  ;
         RealTimeData  stru_G2T_FRE  ;
         RealTimeData  stru_Chat_ENG ;
         RealTimeData  stru_Chat_FRE;
         RealTimeData  stru_ChatApp_ENG ;
         RealTimeData  stru_ChatApp_FRE;

         Last24hrGrade stru_last24HrGrade ;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                var queues = efContext.Proc_GetQueue();
                foreach (Proc_GetQueue_Result x in queues)
                {
                    switch  (x.Queue)
                    {
                        case "szServerName" : szServerName = x.QueueValue; break;
                        case "dwSwitchID"   : dwSwitchID = x.QueueValue; break;
                        case "Phone_ENG"    : iQueueID_Phone_ENG =x.QueueValue; break;
                        case "Phone_FRE"    : iQueueID_Phone_FRE =   x.QueueValue; break;
                        case "G2T_ENG"      : iQueueID_G2T_ENG =     x.QueueValue; break;
                        case "G2T_FRE"      : iQueueID_G2T_FRE =     x.QueueValue; break;
                        case "Chat_ENG"     : iQueueID_Chat_ENG =    x.QueueValue; break;
                        case "Chat_FRE"     : iQueueID_Chat_FRE =    x.QueueValue; break;
                        case "ChatApp_ENG"  : iQueueID_ChatApp_ENG = x.QueueValue; break;
                        case "ChatApp_FRE"  : iQueueID_ChatApp_FRE = x.QueueValue; break;
                    }
                }

            };

            try
            {
                // applying theme
                ApplyTheme();

                // get SOAP DATA
                getSOAP(); 

                //get cached grade value from SQL SERVER
                getLast24HrGrade(); 

                Phone();

                Chat();
        }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
        }

        // refreshing is the number of seconds , default value is 300 = 5 mintues in setting section
        Response.AppendHeader("Refresh", refreshing);  

        }

        protected void ApplyTheme()
        {
            HtmlGenericControl myJs1 = new HtmlGenericControl();
            HtmlGenericControl myJs2 = new HtmlGenericControl();
            HtmlGenericControl myJs3 = new HtmlGenericControl();
            myJs1.TagName = "script";
            myJs1.Attributes.Add("type", "text/javascript");
            myJs1.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("http://d3js.org/d3.v3.min.js")));
            this.Page.Header.Controls.AddAt(2, myJs1);
            myJs2.TagName = "script";
            myJs2.Attributes.Add("type", "text/javascript");
            myJs2.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("https://www.gstatic.com/charts/loader.js")));
            this.Page.Header.Controls.AddAt(3, myJs2);
            myJs3.TagName = "script";
            myJs3.Attributes.Add("type", "text/javascript");
            myJs3.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("https://cdn.rawgit.com/kimmobrunfeldt/progressbar.js/0.5.6/dist/progressbar.js")));
            this.Page.Header.Controls.AddAt(4, myJs3);



            DateTime dt = DateTime.Now;
            int hour = dt.Hour;

            if ((dayTimeStart <= hour) & (hour < dayTimeEnd))  // Day light theme
            {

                HtmlGenericControl myCss = new HtmlGenericControl();
                myCss.TagName = "link";
                myCss.Attributes.Add("type", "text/css");
                myCss.Attributes.Add("rel", "stylesheet");
                myCss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("Content/readerboard.css")));
                this.Page.Header.Controls.AddAt(1, myCss);


                HtmlGenericControl myJs11 = new HtmlGenericControl();
                HtmlGenericControl myJs12 = new HtmlGenericControl();
                HtmlGenericControl myJs13 = new HtmlGenericControl();
                myJs11.TagName = "script";
                myJs11.Attributes.Add("type", "text/javascript");
                myJs11.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("Scripts/googleGauge.js")));
                this.Page.Header.Controls.AddAt(5,myJs11);

                myJs12.TagName = "script";
                myJs12.Attributes.Add("type", "text/javascript");
                myJs12.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("Scripts/progress.js")));
                this.Page.Header.Controls.AddAt(6, myJs12);

                myJs13.TagName = "script";
                myJs13.Attributes.Add("type", "text/javascript");
                myJs13.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("Scripts/liquidFillGauge.js")));
                this.Page.Header.Controls.AddAt(7, myJs13);
            }
            else  // Night Dark Theme
            {
                HtmlGenericControl myCss = new HtmlGenericControl();
                myCss.TagName = "link";
                myCss.Attributes.Add("type", "text/css");
                myCss.Attributes.Add("rel", "stylesheet");
                myCss.Attributes.Add("href", ResolveUrl(Page.ResolveClientUrl("Content/Dark.css")));
                this.Page.Header.Controls.AddAt(1, myCss);

                HtmlGenericControl myJs11 = new HtmlGenericControl();
                HtmlGenericControl myJs12 = new HtmlGenericControl();
                HtmlGenericControl myJs13 = new HtmlGenericControl();

                myJs11.TagName = "script";
                myJs11.Attributes.Add("type", "text/javascript");
                myJs11.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("Scripts/googleGaugeDark.js")));
                this.Page.Header.Controls.AddAt(5, myJs11);

                myJs12.TagName = "script";
                myJs12.Attributes.Add("type", "text/javascript");
                myJs12.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("Scripts/progressDark.js")));
                this.Page.Header.Controls.AddAt(6, myJs12);

                myJs13.TagName = "script";
                myJs13.Attributes.Add("type", "text/javascript");
                myJs13.Attributes.Add("src", ResolveUrl(Page.ResolveClientUrl("Scripts/liquidFillGaugeDark.js")));
                this.Page.Header.Controls.AddAt(7, myJs13);
            }
        }
 
        protected void Phone()
        {

            try
            {
                int iNumOffered = 
                    Convert.ToInt32(stru_Phone_ENG.NumOffered) 
                    + Convert.ToInt32(stru_Phone_FRE.NumOffered) 
                    + Convert.ToInt32(stru_G2T_ENG.NumOffered) 
                    + Convert.ToInt32(stru_G2T_FRE.NumOffered);
                iNumOffered = iNumOffered < 0 ? 0 : iNumOffered;

                int iNumhundledLessThanTarget = 
                    Convert.ToInt32(stru_Phone_ENG.NumHandledLessThanTarget) 
                    + Convert.ToInt32(stru_Phone_FRE.NumHandledLessThanTarget) 
                    + Convert.ToInt32(stru_G2T_ENG.NumHandledLessThanTarget) 
                    + Convert.ToInt32(stru_G2T_FRE.NumHandledLessThanTarget);
                iNumhundledLessThanTarget = iNumhundledLessThanTarget < 0 ? 0 : iNumhundledLessThanTarget;

                int LongestWaitTime = 
                    Convert.ToInt32(stru_Phone_ENG.LongestWaitTime) 
                    + Convert.ToInt32(stru_Phone_FRE.LongestWaitTime) 
                    + Convert.ToInt32(stru_G2T_ENG.LongestWaitTime) 
                    + Convert.ToInt32(stru_G2T_FRE.LongestWaitTime);
                LongestWaitTime = (LongestWaitTime / 4) / 60; // Average , Convert to mintue
                LongestWaitTime = LongestWaitTime < 0 ? 0 : LongestWaitTime;

                int AverageWaitTime = 
                    Convert.ToInt32(stru_Phone_ENG.AverageWaitTime) 
                    + Convert.ToInt32(stru_Phone_FRE.AverageWaitTime) 
                    + Convert.ToInt32(stru_G2T_ENG.AverageWaitTime) 
                    + Convert.ToInt32(stru_G2T_FRE.AverageWaitTime);
                AverageWaitTime = (AverageWaitTime / 4) / 60; // Average , Convert to mintue
                AverageWaitTime = AverageWaitTime < 0 ? 0 : AverageWaitTime;


                int CallToday = 
                    Convert.ToInt32(stru_Phone_ENG.HandledToday) 
                    + Convert.ToInt32(stru_Phone_FRE.HandledToday) 
                    + Convert.ToInt32(stru_G2T_ENG.HandledToday) 
                    + Convert.ToInt32(stru_G2T_FRE.HandledToday);
                CallToday = CallToday < 0 ? 0 : CallToday;

                int PeopleInQueue = 
                    Convert.ToInt32(stru_Phone_ENG.CurrentInQueued) 
                    + Convert.ToInt32(stru_Phone_FRE.CurrentInQueued) 
                    + Convert.ToInt32(stru_G2T_ENG.CurrentInQueued) 
                    + Convert.ToInt32(stru_G2T_FRE.CurrentInQueued);
                PeopleInQueue = PeopleInQueue < 0 ? 0 : PeopleInQueue;

                int CounselorAvailable = 
                    Convert.ToInt32(stru_Phone_ENG.CounselorAvailable) 
                    + Convert.ToInt32(stru_Phone_FRE.CounselorAvailable) 
                    + Convert.ToInt32(stru_G2T_ENG.CounselorAvailable) 
                    + Convert.ToInt32(stru_G2T_FRE.CounselorAvailable);
                CounselorAvailable = CounselorAvailable < 0 ? 0 : CounselorAvailable;

                int CounselorLogin = 
                    Convert.ToInt32(stru_Phone_ENG.CounselorLogin) 
                    + Convert.ToInt32(stru_Phone_FRE.CounselorLogin) 
                    + Convert.ToInt32(stru_G2T_ENG.CounselorLogin) 
                    + Convert.ToInt32(stru_G2T_FRE.CounselorLogin);
                CounselorLogin = CounselorLogin < 0 ? 0 : CounselorLogin;

                int CounselorOnContact =
                    Convert.ToInt32(stru_Phone_ENG.CounselorOnContact)
                    + Convert.ToInt32(stru_Phone_FRE.CounselorOnContact)
                    + Convert.ToInt32(stru_G2T_ENG.CounselorOnContact)
                    + Convert.ToInt32(stru_G2T_FRE.CounselorOnContact);
                CounselorOnContact = CounselorOnContact < 0 ? 0 : CounselorOnContact;

                Double ASA = 0.0;
                if (iNumOffered !=0)
                {
                    ASA = 100.0 * iNumhundledLessThanTarget / iNumOffered;
                    lblPhoneGradeService.Value = ASA.ToString("N2");
                }
                else
                {
                    ASA = 0.0;
                    lblPhoneGradeService.Value = "0.00";
                }



                //lblPhoneGradeService24.Value = (iNumOffered != 0 ? ASA : 0.00 ).ToString("N2"); 
                decimal p24 = stru_last24HrGrade.PhoneAllGrade;
                p24 = (p24 != (decimal)0.0 ? p24 : (decimal)0.00);
                lblPhoneGradeService24.Value = ((decimal)1.00 * p24).ToString("N2");



                lblPhoneLongestWaitTime.Text = LongestWaitTime.ToString();
                lblPhoneAverageWaitTime.Text = AverageWaitTime.ToString();
                lblPhoneCallToday.Text = CallToday.ToString();
                lblPhonePeopleInQueue.Value = PeopleInQueue.ToString();
                lblPhoneCounselorAvailable.Text = CounselorAvailable.ToString();
                lblPhoneCounselorLogin.Text = CounselorLogin.ToString();
                lblPhoneCounselorOnContact.Text = CounselorOnContact.ToString();
                lblPhoneCounselorNotReady.Text = (CounselorLogin - CounselorAvailable - CounselorOnContact).ToString();

                HiddenPhone_Eng_In.Value = stru_Phone_ENG.CounselorLogin;
                HiddenPhone_Eng_Availabe.Value = stru_Phone_ENG.CounselorAvailable;
                HiddenPhone_Fre_In.Value = stru_Phone_FRE.CounselorLogin;
                HiddenPhone_Fre_Availabe.Value = stru_Phone_FRE.CounselorAvailable;
                HiddenG2T_Eng_In.Value = stru_G2T_ENG.CounselorLogin;
                HiddenG2T_Eng_Availabe.Value = stru_G2T_ENG.CounselorAvailable;
                HiddenG2T_Fre_In.Value = stru_G2T_FRE.CounselorLogin;
                HiddenG2T_Fre_Availabe.Value = stru_G2T_FRE.CounselorAvailable;
                HiddenPhone_Eng_AgentOnContact.Value = stru_Phone_ENG.CounselorOnContact;
                HiddenPhone_Fre_AgentOnContact.Value = stru_Phone_FRE.CounselorOnContact;
                HiddenG2T_Eng_AgentOnContact.Value = stru_G2T_ENG.CounselorOnContact;
                HiddenG2T_Fre_AgentOnContact.Value = stru_G2T_FRE.CounselorOnContact;
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }
        }

        //Chat = Chat_eng + Chat_fre + CHatApp_eng + ChatApp_fre
        protected void Chat()
        {
            try
            {
                int iNumOffered = 
                    Convert.ToInt32(stru_Chat_ENG.NumOffered) 
                    + Convert.ToInt32(stru_Chat_FRE.NumOffered) 
                    + Convert.ToInt32(stru_ChatApp_ENG.NumOffered) 
                    + Convert.ToInt32(stru_ChatApp_FRE.NumOffered);
                iNumOffered = iNumOffered < 0 ? 0 : iNumOffered;

                int iNumhundledLessThanTarget = 
                    Convert.ToInt32(stru_Chat_ENG.NumHandledLessThanTarget) 
                    + Convert.ToInt32(stru_Chat_FRE.NumHandledLessThanTarget) 
                    + Convert.ToInt32(stru_ChatApp_ENG.NumHandledLessThanTarget) 
                    + Convert.ToInt32(stru_ChatApp_FRE.NumHandledLessThanTarget);
                iNumhundledLessThanTarget = iNumhundledLessThanTarget < 0 ? 0 : iNumhundledLessThanTarget;

                int LongestWaitTime =           
                    Convert.ToInt32(stru_Chat_ENG.LongestWaitTime) 
                    + Convert.ToInt32(stru_Chat_FRE.LongestWaitTime) 
                    + Convert.ToInt32(stru_ChatApp_ENG.LongestWaitTime) 
                    + Convert.ToInt32(stru_ChatApp_FRE.LongestWaitTime);
                LongestWaitTime = (LongestWaitTime / 4) / 60; //average, changing to minute
                LongestWaitTime = LongestWaitTime < 0 ? 0 : LongestWaitTime;

                int AverageWaitTime =           
                    Convert.ToInt32(stru_Chat_ENG.AverageWaitTime) 
                    + Convert.ToInt32(stru_Chat_FRE.AverageWaitTime) 
                    + Convert.ToInt32(stru_ChatApp_ENG.AverageWaitTime) 
                    + Convert.ToInt32(stru_ChatApp_FRE.AverageWaitTime);
                AverageWaitTime = (AverageWaitTime / 4) / 60 ; //sverage, changing to minute
                AverageWaitTime = AverageWaitTime < 0 ? 0 : AverageWaitTime;

                int CallToday =                 
                    Convert.ToInt32(stru_Chat_ENG.HandledToday) 
                    + Convert.ToInt32(stru_Chat_FRE.HandledToday) 
                    + Convert.ToInt32(stru_ChatApp_ENG.HandledToday) 
                    + Convert.ToInt32(stru_ChatApp_FRE.HandledToday);
                CallToday = CallToday < 0 ? 0 : CallToday;

                int PeopleInQueue =             
                    Convert.ToInt32(stru_Chat_ENG.CurrentInQueued) 
                    + Convert.ToInt32(stru_Chat_FRE.CurrentInQueued) 
                    + Convert.ToInt32(stru_ChatApp_ENG.CurrentInQueued) 
                    + Convert.ToInt32(stru_ChatApp_FRE.CurrentInQueued);
                PeopleInQueue = PeopleInQueue < 0 ? 0 : PeopleInQueue;

                int CounselorAvailable =        
                    Convert.ToInt32(stru_Chat_ENG.CounselorAvailable) 
                    + Convert.ToInt32(stru_Chat_FRE.CounselorAvailable) 
                    + Convert.ToInt32(stru_ChatApp_ENG.CounselorAvailable) 
                    + Convert.ToInt32(stru_ChatApp_FRE.CounselorAvailable);
                CounselorAvailable = CounselorAvailable < 0 ? 0 : CounselorAvailable;

                int CounselorLogin =            
                    Convert.ToInt32(stru_Chat_ENG.CounselorLogin) 
                    + Convert.ToInt32(stru_Chat_FRE.CounselorLogin) 
                    + Convert.ToInt32(stru_ChatApp_ENG.CounselorLogin) 
                    + Convert.ToInt32(stru_ChatApp_FRE.CounselorLogin);
                CounselorLogin = CounselorLogin < 0 ? 0 : CounselorLogin;

                int CounselorOnContact =
                    Convert.ToInt32(stru_Chat_ENG.CounselorOnContact)
                    + Convert.ToInt32(stru_Chat_FRE.CounselorOnContact)
                    + Convert.ToInt32(stru_ChatApp_ENG.CounselorOnContact)
                    + Convert.ToInt32(stru_ChatApp_FRE.CounselorOnContact);
                CounselorOnContact = CounselorOnContact < 0 ? 0 : CounselorOnContact;


                double asa1 = 0.00;

                if (iNumOffered !=0)
                {
                    asa1 = 100.00 * iNumhundledLessThanTarget / iNumOffered;
                    lblChatGradeService.Value = asa1.ToString("N2");
                }
                else
                {
                    asa1 = 0.00;
                    lblChatGradeService.Value = "0.00";
                }

                //lblChatGradeService24.Value = (iNumOffered != 0 ? asa1 : 0.00).ToString("N2");
                decimal c24 = stru_last24HrGrade.ChatAllGrade;
                c24 = (c24 != (decimal)0.0 ? c24 : (decimal)0.00);
                lblChatGradeService24.Value = ((decimal)1.00 * c24).ToString("N2");



                lblChatLongestWaitTime.Text = LongestWaitTime.ToString();
                lblChatAverageWaitTime.Text = AverageWaitTime.ToString();
                lblChatCallToday.Text = CallToday.ToString();
                lblChatPeopleInQueue.Value = PeopleInQueue.ToString();
                lblChatCounselorAvailable.Text = CounselorAvailable.ToString();
                lblChatCounselorLogin.Text = CounselorLogin.ToString();
                lblChatCounselorOnContact.Text = CounselorOnContact.ToString();
                lblChatCounselorNotReady.Text = (CounselorLogin - CounselorAvailable - CounselorOnContact).ToString();

                HiddenWebChat_Eng_In.Value = stru_Chat_ENG.CounselorLogin;
                HiddenWebChat_Eng_Avaiable.Value = stru_Chat_ENG.CounselorAvailable;
                HiddenWebChat_Fre_In.Value = stru_Chat_FRE.CounselorLogin;
                HiddenWebChat_Fre_Avaiable.Value = stru_Chat_FRE.CounselorAvailable;
                HiddenChatApp_Eng_In.Value = stru_ChatApp_ENG.CounselorLogin;
                HiddenChatApp_Eng_Avaiable.Value = stru_ChatApp_ENG.CounselorAvailable;
                HiddenChatApp_Fre_In.Value = stru_ChatApp_FRE.CounselorLogin;
                HiddenChatApp_Fre_Avaiable.Value = stru_ChatApp_FRE.CounselorAvailable;
                HiddenWebChat_Eng_AgentOnContact.Value = stru_Chat_ENG.CounselorOnContact;
                HiddenWebChat_Fre_AgentOnContact.Value = stru_Chat_FRE.CounselorOnContact;
                HiddenChatApp_Eng_AgentOnContact.Value = stru_ChatApp_ENG.CounselorOnContact;
                HiddenChatApp_Fre_AgentOnContact.Value = stru_ChatApp_FRE.CounselorOnContact;
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
            HiddenPhone_Eng_In.Value = stru_Phone_ENG.CounselorLogin;
            HiddenPhone_Eng_Availabe.Value = stru_Phone_ENG.CounselorAvailable;

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
            HiddenPhone_Fre_In.Value = stru_Phone_FRE.CounselorLogin;
            HiddenPhone_Fre_Availabe.Value = stru_Phone_FRE.CounselorAvailable;

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
            HiddenG2T_Eng_In.Value = stru_G2T_ENG.CounselorLogin;
            HiddenG2T_Eng_Availabe.Value = stru_G2T_ENG.CounselorAvailable;

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
            HiddenG2T_Fre_In.Value = stru_G2T_FRE.CounselorLogin;
            HiddenG2T_Fre_Availabe.Value = stru_G2T_FRE.CounselorAvailable;

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
            HiddenWebChat_Eng_In.Value = stru_Chat_ENG.CounselorLogin;
            HiddenWebChat_Eng_Avaiable.Value = stru_Chat_ENG.CounselorAvailable;

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
            HiddenWebChat_Fre_In.Value = stru_Chat_FRE.CounselorLogin;
            HiddenWebChat_Fre_Avaiable.Value = stru_Chat_FRE.CounselorAvailable;

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
            HiddenChatApp_Eng_In.Value = stru_ChatApp_ENG.CounselorLogin;
            HiddenChatApp_Eng_Avaiable.Value = stru_ChatApp_ENG.CounselorAvailable;

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
            HiddenChatApp_Fre_In.Value = stru_ChatApp_FRE.CounselorLogin;
            HiddenChatApp_Fre_Avaiable.Value = stru_ChatApp_FRE.CounselorAvailable;



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

            stru_last24HrGrade.ChatAllGrade = (decimal)x.ChatAllGrade;
            stru_last24HrGrade.ChatAppGrade = (decimal)x.ChatAppGrade;
            stru_last24HrGrade.ChatGrade = (decimal)x.ChatGrade;
            }
        }

    }
}