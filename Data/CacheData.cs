using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.iceCTIService;
using System.Timers;

namespace Data
{
    public class CacheData
    {
        //for display windows size and position
        static int origWidth = 75;
        static int origHeight = 22;
        //static int Window2Left = 50;
        //static int Windod2Top = 50;


        public struct RealTimeData
        {
            public string NumHandledLessThanTarget;
            public string NumOffered;
            public string LongestWaitTime;
            public string AverageWaitTime;
            public string HandledToday;
            public string CurrentInQueued;
            public string CounselorAvailable;
            public string CounselorLogin;
        }

        public struct Last24hrGrade
        {
            public decimal PhoneAllGrade;
            public decimal PhoneGrade;
            public decimal G2TGrade;

            public decimal ChatAllGrade;
            public decimal ChatGrade;
            public decimal ChatAppGrade;
        }



        static RAMEntities  efContext = new RAMEntities();

        static CTIServiceClient client = new CTIServiceClient();

        //static int cacheInterval = Properties.Settings.Default.cacheInterval;//Default 300 second , 5 mintues;
        static string szServerName = Properties.Settings.Default.szServerName; //"ice1"
        static string dwSwitchID = Properties.Settings.Default.dwSwitchID; //"11006";
        static string iQueueID_Phone_ENG = Properties.Settings.Default.Phone_ENG;//"6001";
        static string iQueueID_Phone_FRE = Properties.Settings.Default.Phone_FRE;//"6002";
        static string iQueueID_G2T_ENG = Properties.Settings.Default.G2T_ENG;//"6013";
        static string iQueueID_G2T_FRE = Properties.Settings.Default.G2T_FRE;//"6014";
        static string iQueueID_Chat_ENG = Properties.Settings.Default.Chat_ENG;//"6007";
        static string iQueueID_Chat_FRE = Properties.Settings.Default.Chat_FRE;//"6008";
        static string iQueueID_ChatApp_ENG = Properties.Settings.Default.ChatApp_ENG;//"6020";
        static string iQueueID_ChatApp_FRE = Properties.Settings.Default.ChatApp_FRE;//"6021";
        static int cacheInterval = Properties.Settings.Default.cacheInterval;//Default 300 second , 5 mintues;
        //static string szServerName; //"ice1"
        //static string dwSwitchID; //"11006";
        //static string iQueueID_Phone_ENG;//"6001";
        //static string iQueueID_Phone_FRE;//"6002";
        //static string iQueueID_G2T_ENG;//"6013";
        //static string iQueueID_G2T_FRE;//"6014";
        //static string iQueueID_Chat_ENG;//"6007";
        //static string iQueueID_Chat_FRE;//"6008";
        //static string iQueueID_ChatApp_ENG;//"6020";
        //static string iQueueID_ChatApp_FRE;//"6021";


        static public RealTimeData stru_Phone_ENG;
        static public RealTimeData stru_Phone_FRE;
        static public RealTimeData stru_G2T_ENG;
        static public RealTimeData stru_G2T_FRE;
        static public RealTimeData stru_Chat_ENG;
        static public RealTimeData stru_Chat_FRE;
        static public RealTimeData stru_ChatApp_ENG;
        static public RealTimeData stru_ChatApp_FRE;

        static public  Last24hrGrade stru_last24HrGrade;

        static public int Counter = 0; //counting cached grades in current session

        static void Main(string[] args)
        {

            //var queues = efContext.Proc_GetQueue();
            //foreach (Proc_GetQueue_Result x in queues)
            //{
            //    switch (x.Queue)
            //    {
            //        case "szServerName": szServerName = x.QueueValue; break;
            //        case "dwSwitchID": dwSwitchID = x.QueueValue; break;
            //        case "Phone_ENG": iQueueID_Phone_ENG = x.QueueValue; break;
            //        case "Phone_FRE": iQueueID_Phone_FRE = x.QueueValue; break;
            //        case "G2T_ENG": iQueueID_G2T_ENG = x.QueueValue; break;
            //        case "G2T_FRE": iQueueID_G2T_FRE = x.QueueValue; break;
            //        case "Chat_ENG": iQueueID_Chat_ENG = x.QueueValue; break;
            //        case "Chat_FRE": iQueueID_Chat_FRE = x.QueueValue; break;
            //        case "ChatApp_ENG": iQueueID_ChatApp_ENG = x.QueueValue; break;
            //        case "ChatApp_FRE": iQueueID_ChatApp_FRE = x.QueueValue; break;
            //    }
            //}

            Console.Clear();
            Console.SetWindowSize(origWidth, origHeight);
            //Console.SetWindowPosition(Window2Left, Windod2Top);


            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(insertData);

            //Default live interval 300 second , 5 mintues;
            aTimer.Interval = cacheInterval; //Default Debug interval value 2000, (2 second , 5 mintues);
            aTimer.Enabled = true;

            Console.SetCursorPosition(10, 2);
            Console.WriteLine("The system is grabbing data from remote Web Services!");
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("This session started on " + DateTime.Now.ToShortDateString() + " @ " + DateTime.Now.ToShortTimeString());


            Console.SetCursorPosition(15, 18);
            Console.WriteLine("Press \'q\' to quit the caching data procrss.");
            while (Console.Read() != 'q') ;
        }
 

        static void insertData(object source, ElapsedEventArgs e)
        {
            
            getSOAP();

            //insert into DATABASE
            try
            {
                var thisEF = efContext.Proc_Insert_Grade(
                       Convert.ToDecimal(stru_Phone_ENG.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_Phone_FRE.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_G2T_ENG.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_G2T_FRE.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_Chat_ENG.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_Chat_FRE.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_ChatApp_ENG.NumHandledLessThanTarget)
                     , Convert.ToDecimal(stru_ChatApp_FRE.NumHandledLessThanTarget)

                     , Convert.ToDecimal(stru_Phone_ENG.NumOffered)
                     , Convert.ToDecimal(stru_Phone_FRE.NumOffered)
                     , Convert.ToDecimal(stru_G2T_ENG.NumOffered)
                     , Convert.ToDecimal(stru_G2T_FRE.NumOffered)
                     , Convert.ToDecimal(stru_Chat_ENG.NumOffered)
                     , Convert.ToDecimal(stru_Chat_FRE.NumOffered)
                     , Convert.ToDecimal(stru_ChatApp_ENG.NumOffered)
                     , Convert.ToDecimal(stru_ChatApp_FRE.NumOffered)
                     );

                Counter++;
            }
            catch
            {
                Console.SetCursorPosition(15, 15);
                Console.Write("Network Fault when inserts into DB:" + DateTime.Now.ToString());
            }


            Console.SetCursorPosition(33, 8);
            Console.Write("NOW:");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(25, 10);
            Console.Write(DateTime.Now.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 12);
            Console.Write("Cached: " + Counter.ToString());

            Console.SetCursorPosition(33, 15);
            
        }



        public static void getLast24HrGrade()
        {
            try
            {
                Proc_Last24Grade_Result last24HrGrade = efContext.Proc_Last24Grade().FirstOrDefault();

                stru_last24HrGrade.PhoneAllGrade = (decimal)last24HrGrade.PhoneAllGrade;
                stru_last24HrGrade.PhoneGrade = (decimal)last24HrGrade.PhoneGrade;
                stru_last24HrGrade.G2TGrade = (decimal)last24HrGrade.G2TGrade;

                stru_last24HrGrade.ChatAllGrade = (decimal)last24HrGrade.ChatAllGrade;
                stru_last24HrGrade.ChatAppGrade = (decimal)last24HrGrade.ChatAppGrade;
                stru_last24HrGrade.ChatGrade = (decimal)last24HrGrade.ChatGrade;
            }
            catch
            {
                Console.SetCursorPosition(15, 15);
                Console.Write("Network Fault when gets data from DB:" + DateTime.Now.ToString());
                
            }

        }



        public static void getSOAP()
        {
            try
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


                //phone_fre
                stru_Phone_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                stru_Phone_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Phone_FRE, szServerName);


                //G2T_ENG
                stru_G2T_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_G2T_ENG, szServerName);
                stru_G2T_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_G2T_ENG, szServerName);


                //G2T_FRE
                stru_G2T_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_G2T_FRE, szServerName);
                stru_G2T_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_G2T_FRE, szServerName);


                //Chat_ENG
                stru_Chat_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Chat_ENG, szServerName);
                stru_Chat_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Chat_ENG, szServerName);


                //Chat_FRE
                stru_Chat_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_Chat_FRE, szServerName);
                stru_Chat_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_Chat_FRE, szServerName);


                //ChatApp_ENG
                stru_ChatApp_ENG.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
                stru_ChatApp_ENG.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);


                //ChatApp_FRE
                stru_ChatApp_FRE.NumHandledLessThanTarget = client.GetNumHandledLessThanTargetASA(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.NumOffered = client.GetNumOffered(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.AverageWaitTime = client.GetEstimatedWaitTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CounselorAvailable = client.GetNumAgentsReady(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
                stru_ChatApp_FRE.CounselorLogin = client.GetNumAgentsLoggedOn(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);

            }
            catch
            {
                Console.SetCursorPosition(15, 15);
                Console.Write("Network Fault when gets data from SOAP:" + DateTime.Now.ToString());
            }
 
        }
    }
}
