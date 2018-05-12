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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
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
            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }
        }
    }
}