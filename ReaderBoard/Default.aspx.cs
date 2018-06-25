using ReaderBoard.iceCTI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }


    public partial class _Default : Page
    {
        CTIServiceClient client = new CTIServiceClient();
        string refreshing = Properties.Settings.Default.Refreshing;//Default 3- second;
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

        RealTimeData stru_Phone_ENG;
        RealTimeData stru_Phone_FRE;
        RealTimeData stru_G2T_ENG;
        RealTimeData stru_G2T_FRE;
        RealTimeData stru_Chat_ENG;
        RealTimeData stru_Chat_FRE;
        RealTimeData stru_ChatApp_ENG;
        RealTimeData stru_ChatApp_FRE;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            };

            try
            {
                Grap();
                Phone();
                Chat();
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }


            Response.AppendHeader("Refresh", refreshing);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();

            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        //phone = phone_eng + phone_fre + G2T_eng + G2T_fre
        protected void Phone()
        {

            try
            {
                int iNumOffered               = Convert.ToInt32(stru_Phone_ENG.NumOffered) + Convert.ToInt32(stru_Phone_FRE.NumOffered) + Convert.ToInt32(stru_G2T_ENG.NumOffered) + Convert.ToInt32(stru_G2T_FRE.NumOffered);
                int iNumhundledLessThanTarget = Convert.ToInt32(stru_Phone_ENG.NumHandledLessThanTarget) + Convert.ToInt32(stru_Phone_FRE.NumHandledLessThanTarget) + Convert.ToInt32(stru_G2T_ENG.NumHandledLessThanTarget) + Convert.ToInt32(stru_G2T_FRE.NumHandledLessThanTarget);
                int LongestWaitTime           = Convert.ToInt32(stru_Phone_ENG.LongestWaitTime) + Convert.ToInt32(stru_Phone_FRE.LongestWaitTime) + Convert.ToInt32(stru_G2T_ENG.LongestWaitTime) + Convert.ToInt32(stru_G2T_FRE.LongestWaitTime);
                LongestWaitTime = LongestWaitTime / 60; // Convert to mintue
                int AverageWaitTime           = Convert.ToInt32(stru_Phone_ENG.AverageWaitTime) + Convert.ToInt32(stru_Phone_FRE.AverageWaitTime) + Convert.ToInt32(stru_G2T_ENG.AverageWaitTime) + Convert.ToInt32(stru_G2T_FRE.AverageWaitTime);
                AverageWaitTime = AverageWaitTime / 60; // Convert to mintue
                int CallToday                 = Convert.ToInt32(stru_Phone_ENG.HandledToday) + Convert.ToInt32(stru_Phone_FRE.HandledToday) + Convert.ToInt32(stru_G2T_ENG.HandledToday) + Convert.ToInt32(stru_G2T_FRE.HandledToday);
                int PeopleInQueue             = Convert.ToInt32(stru_Phone_ENG.CurrentInQueued) + Convert.ToInt32(stru_Phone_FRE.CurrentInQueued) + Convert.ToInt32(stru_G2T_ENG.CurrentInQueued) + Convert.ToInt32(stru_G2T_FRE.CurrentInQueued);
                int CounselorAvailable        = Convert.ToInt32(stru_Phone_ENG.CounselorAvailable) + Convert.ToInt32(stru_Phone_FRE.CounselorAvailable) + Convert.ToInt32(stru_G2T_ENG.CounselorAvailable) + Convert.ToInt32(stru_G2T_FRE.CounselorAvailable);

                Double ASA = 100.0 * iNumhundledLessThanTarget / iNumOffered;
                lblPhoneGradeService.Value = (iNumOffered != 0 ?  ASA : 0.00 ).ToString("N2");
                lblPhoneGradeService24.Value = (iNumOffered != 0 ? ASA : 0.00 ).ToString("N2"); 
                lblPhoneLongestWaitTime.Text = LongestWaitTime.ToString();
                lblPhoneAverageWaitTime.Text = AverageWaitTime.ToString();
                lblPhoneCallToday.Text = CallToday.ToString();
                lblPhonePeopleInQueue.Value = PeopleInQueue.ToString();
                lblPhoneCounselorAvailable.Text = CounselorAvailable.ToString();
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
                int iNumOffered =               Convert.ToInt32(stru_Chat_ENG.NumOffered) + Convert.ToInt32(stru_Chat_FRE.NumOffered) + Convert.ToInt32(stru_ChatApp_ENG.NumOffered) + Convert.ToInt32(stru_ChatApp_FRE.NumOffered);
                int iNumhundledLessThanTarget = Convert.ToInt32(stru_Chat_ENG.NumHandledLessThanTarget) + Convert.ToInt32(stru_Chat_FRE.NumHandledLessThanTarget) + Convert.ToInt32(stru_ChatApp_ENG.NumHandledLessThanTarget) + Convert.ToInt32(stru_ChatApp_FRE.NumHandledLessThanTarget);
                int LongestWaitTime =           Convert.ToInt32(stru_Chat_ENG.LongestWaitTime) + Convert.ToInt32(stru_Chat_FRE.LongestWaitTime) + Convert.ToInt32(stru_ChatApp_ENG.LongestWaitTime) + Convert.ToInt32(stru_ChatApp_FRE.LongestWaitTime);
                LongestWaitTime = LongestWaitTime / 60; //changing to minute
                int AverageWaitTime =           Convert.ToInt32(stru_Chat_ENG.AverageWaitTime) + Convert.ToInt32(stru_Chat_FRE.AverageWaitTime) + Convert.ToInt32(stru_ChatApp_ENG.AverageWaitTime) + Convert.ToInt32(stru_ChatApp_FRE.AverageWaitTime);
                AverageWaitTime = AverageWaitTime / 60 ; //changing to minute
                int CallToday =                 Convert.ToInt32(stru_Chat_ENG.HandledToday) + Convert.ToInt32(stru_Chat_FRE.HandledToday) + Convert.ToInt32(stru_ChatApp_ENG.HandledToday) + Convert.ToInt32(stru_ChatApp_FRE.HandledToday);
                int PeopleInQueue =             Convert.ToInt32(stru_Chat_ENG.CurrentInQueued) + Convert.ToInt32(stru_Chat_FRE.CurrentInQueued) + Convert.ToInt32(stru_ChatApp_ENG.CurrentInQueued) + Convert.ToInt32(stru_ChatApp_FRE.CurrentInQueued);
                int CounselorAvailable =        Convert.ToInt32(stru_Chat_ENG.CounselorAvailable) + Convert.ToInt32(stru_Chat_FRE.CounselorAvailable) + Convert.ToInt32(stru_ChatApp_ENG.CounselorAvailable) + Convert.ToInt32(stru_ChatApp_FRE.CounselorAvailable);

                double asa1 = 100.00 * iNumhundledLessThanTarget / iNumOffered;
                lblChatGradeService.Value = (iNumOffered != 0 ? asa1 : 0.00).ToString("N2"); 
                lblChatGradeService24.Value = (iNumOffered != 0 ? asa1 : 0.00).ToString("N2"); 

                lblChatLongestWaitTime.Text = LongestWaitTime.ToString();
                lblChatAverageWaitTime.Text = AverageWaitTime.ToString();
                lblChatCallToday.Text = CallToday.ToString();
                lblChatPeopleInQueue.Value = PeopleInQueue.ToString();
                lblChatCounselorAvailable.Text = CounselorAvailable.ToString();
            }

            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }
        }

        protected void  Grap()
        {
            //Phone_eng          
            stru_Phone_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Phone_ENG, szServerName); 
            stru_Phone_ENG.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_Phone_ENG, szServerName);

            //phone_fre
            stru_Phone_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_Phone_FRE, szServerName);


            //G2T_ENG
            stru_G2T_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_G2T_ENG, szServerName);

            //G2T_FRE
            stru_G2T_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_G2T_FRE, szServerName);

            //Chat_ENG
            stru_Chat_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_Chat_ENG, szServerName);

            //Chat_FRE
            stru_Chat_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_Chat_FRE, szServerName);

            //ChatApp_ENG
            stru_ChatApp_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_ChatApp_ENG, szServerName);

            //ChatApp_FRE
            stru_ChatApp_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE.NumOffered               = client.GetNumOffered(                 dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE.LongestWaitTime          = client.GetCurLongestQueuedTime(       dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE.AverageWaitTime          = client.GetEstimatedWaitTime(          dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE.HandledToday             = client.GetNumHandledInThisQueue(      dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE.CurrentInQueued          = client.GetCurQueued(                  dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE.CounselorAvailable       = client.GetNumAgentsReady(             dwSwitchID, iQueueID_ChatApp_FRE, szServerName);

        }

    }
}