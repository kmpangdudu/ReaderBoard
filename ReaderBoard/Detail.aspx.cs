using ReaderBoard.iceCTI;
using System;
using System.Net;

namespace ReaderBoard
{
    public partial class Detail : System.Web.UI.Page
    {
        CTIServiceClient client = new CTIServiceClient();
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
        string AgentID = "1502";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            };

            try
            {
                Phone_ENG();
                Phone_FRE();
                G2T_ENG();
                G2T_FRE();
                Chat_ENG();
                Chat_FRE();
                ChatApp_ENG();
                ChatApp_FRE();

                Test();
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblDate1.Text = DateTime.Now.ToShortDateString();

            lblTime1.Text = DateTime.Now.ToLongTimeString();
        }


        protected void Phone_ENG()
        {
            try
            {
                lblCurQueued.Text = client.GetCurQueued(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblAgentsLoggedOn.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblAgentsReady.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lbloffered.Text = client.GetNumOffered(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblHandled.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblWaitTime.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblLongestwaitTime.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblNumAgentsOnContact.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblGetHandledQueuedTime.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                string iSessionID = "0";
                string iIceID = tbAgentID.Text; 
                string szDN = "0";

                iSessionID = client.GetSessionIDIceID(iIceID); //string
                client.GetSessionIDDN(szDN); //string GetSessionIDDN
                lblGetCTIUserData.Text = client.GetCTIUserData(iSessionID); //string
                lblGetIceUserData.Text = client.GetIceUserData(iSessionID); //string
                
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }
        protected void Phone_FRE()
        {
            try
            {
                lblCurQueued_F.Text = client.GetCurQueued(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblAgentsLoggedOn_F.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblAgentsReady_F.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lbloffered_F.Text = client.GetNumOffered(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblHandled_F.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblWaitTime_F.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblLongestwaitTime_F.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblNumAgentsOnContact_F.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                lblGetHandledQueuedTime_F.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);

                string iSessionID = "0";
                string iIceID = tbAgentID.Text;
                iSessionID = client.GetSessionIDIceID(iIceID);
                lblGetCTIUserData_F.Text = client.GetCTIUserData(iSessionID);
                lblGetIceUserData_F.Text = client.GetIceUserData(iSessionID);

            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }

        protected void G2T_ENG()
        {
            try
            {
                lblCurQueued_g2t.Text = client.GetCurQueued(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblAgentsLoggedOn_g2t.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblAgentsReady_g2t.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lbloffered_g2t.Text = client.GetNumOffered(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblHandled_g2t.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblWaitTime_g2t.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblLongestwaittime_g2t.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblNumAgentsOnContact_g2t.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                lblGetHandledQueuedTime_g2t.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }

        }

        protected void G2T_FRE()
        {
            try
            {
                lblCurQueued_g2t_f.Text = client.GetCurQueued(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblAgentsLoggedOn_g2t_f.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblAgentsReady_g2t_f.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lbloffered_g2t_f.Text = client.GetNumOffered(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblHandled_g2t_f.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblLongestwaitTime_g2t_f.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblWaitTime_g2t_f.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblNumAgentsOnContact_g2t_f.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                lblGetHandledQueuedTime_g2t_f.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }

        protected void Chat_ENG()
        {
            try
            {
                lblCurQueued_ChatE.Text = client.GetCurQueued(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblAgentsLoggedOn_ChatE.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblAgentsReady_ChatE.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lbloffered_ChatE.Text = client.GetNumOffered(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblHandle_ChatEd.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblWaitTime_ChatE.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblLongestwaittime_ChatE.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblNumAgentsOnContact_ChatE.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblGetHandledQueuedTime_ChatE.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }

        protected void Chat_FRE()
        {
            try
            {
                lblCurQueued_ChatF.Text = client.GetCurQueued(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblAgentsLoggedOn_ChatF.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblAgentsReady_ChatF.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lbloffered_ChatF.Text = client.GetNumOffered(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblHandled_ChatF.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblLongestwaitTime_ChatF.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblWaitTime_ChatF.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblNumAgentsOnContact_ChatF.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                lblGetHandledQueuedTime_ChatF.Text= client.GetHandledQueuedTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }


        protected void ChatApp_ENG()
        {
            try
            {
                lblCurQueued_ChatAppE.Text = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblAgentsLoggedOn_ChatAppE.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblAgentsReady_ChatAppE.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lbloffered_ChatAppE.Text = client.GetNumOffered(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblHandled_ChatAppE.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblWaitTime_ChatAppE.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblLongestwaittime_ChatAppE.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblNumAgentsOnContact_ChatAppE.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                lblGetHandledQueuedTime_ChartAppE.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }

        protected void ChatApp_FRE()
        {
            try
            {
                lblCurQueued_ChatAppF.Text = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblAgentsLoggedOn_ChatAppF.Text = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblAgentsReady_ChatAppF.Text = client.GetNumAgentsReady(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lbloffered_ChatAppF.Text = client.GetNumOffered(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblHandled_ChatAppF.Text = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblWaitTime_ChatAppF.Text = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblLongestwaittime_ChatAppF.Text = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblNumAgentsOnContact_ChatAppF.Text = client.GetNumAgentsOnContact(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                lblGetHandledQueuedTime_charAppF.Text = client.GetHandledQueuedTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }


        protected void Test()
        {
            string aaa = "10";
            try
            {
                lblQueueStats.Text = client.GetQueueStatsString(dwSwitchID, iQueueID_Phone_ENG, aaa, szServerName);
                lblChat_Eng.Text = client.GetQueueStatsString(dwSwitchID, iQueueID_Chat_ENG, aaa, szServerName);
                lblChatApp_Eng.Text = client.GetQueueStatsString(dwSwitchID, iQueueID_ChatApp_ENG, aaa, szServerName);

                GetTargetASA_phone_Eng.Text = client.GetTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                GetTargetASA_Chat_Eng.Text = client.GetTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                GetTargetASA_ChatApp_Eng.Text = client.GetTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);

                lblHandledLessThanTargetASA_Phone_E.Text = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Phone_ENG, szServerName);
                lblHandledLessThanTargetASA_Chat_E.Text = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                lblHandledLessThanTargetASA_ChatApp_E.Text = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            }
            catch (Exception erd)
            {
                lblerror1.Text = erd.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Test();
 
        }
    }
}