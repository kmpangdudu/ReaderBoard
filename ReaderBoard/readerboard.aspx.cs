using ReaderBoard.DataModel;
using ReaderBoard.iceCTI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;

namespace ReaderBoard
{
    struct RealTimeDataShort
    {
        public string _HandledToday { get; set; } //NumHandledInThisQueue, Number of handled in this queue.
        public string _CurrentInQueued { get; set; }
        public string _LongestWaitTime { get; set; }
    }
    struct agent
    {
        public int weight { get; set; }
        public int agentID { get; set; }
        public string agentName { get; set; }
        public string statusecode { get; set; }
        public String status { get; set; }

    }

    public partial class readerboard : System.Web.UI.Page
    {

       ReaderBoardEntities efContext = new ReaderBoardEntities();
       AgentEntities efagent = new AgentEntities();

       CTIServiceClient client = new CTIServiceClient();

      
        List<agent> agents = new List<agent>();

        DateTime today = DateTime.Now;
       string refreshing = Properties.Settings.Default.DashboardRefreshing;//Default 3- second;
       string szServerName = Properties.Settings.Default.szServerName; //"ice1"
       string dwSwitchID = Properties.Settings.Default.dwSwitchID; //"11006";

       string iQueueID_Phone_ENG = Properties.Settings.Default.Phone_ENG;//"6001";
       string iQueueID_Phone_FRE = Properties.Settings.Default.Phone_FRE;//"6002";

       string iQueueID_G2T_ENG = Properties.Settings.Default.G2T_ENG;//"6013";
       string iQueueID_G2T_FRE = Properties.Settings.Default.G2T_FRE;//"6014";

       string iQueueID_Hlth_ENG = Properties.Settings.Default.Hlth_ENG;//"6017";
       string iQueueID_Hlth_FRE = Properties.Settings.Default.Hlth_FRE;//"6018";

       string iQueueID_Chat_ENG = Properties.Settings.Default.Chat_ENG;//"6007";
       string iQueueID_Chat_FRE = Properties.Settings.Default.Chat_FRE;//"6008";

       string iQueueID_ChatApp_ENG = Properties.Settings.Default.ChatApp_ENG;//"6020";
       string iQueueID_ChatApp_FRE = Properties.Settings.Default.ChatApp_FRE;//"6021";

        RealTimeDataShort stru_Phone_ENG;
        RealTimeDataShort stru_Phone_FRE;

        RealTimeDataShort stru_G2T_ENG;
        RealTimeDataShort stru_G2T_FRE;

        RealTimeDataShort stru_Hlth_ENG;
        RealTimeDataShort stru_Hlth_FRE;

        RealTimeDataShort stru_Chat_ENG;
        RealTimeDataShort stru_Chat_FRE;

        RealTimeDataShort stru_ChatApp_ENG;
        RealTimeDataShort stru_ChatApp_FRE;
        protected void Page_Load(object sender, EventArgs e)
        {
            string errMsg = "";  //for debug only

            // refreshing is the number of seconds , default value is 300 = 5 mintues in setting section
            Response.AppendHeader("Refresh", refreshing);

            if (!IsPostBack)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try
            {
                

                // get agents
                getAgents();

                //process Counsellor status
                gvCounsellor.DataSource = DSCounsellor(); // generate DataSet of Counsellor
                gvCounsellor.DataBind();

                //errMsg = "Done agent";

                // get SOAP DATA
                getSOAP();

                //errMsg = "Done SOAP";

                // process phone stuffs
                Phone();

                //errMsg = "Done PHONE";

                
                // process chat stuffs
                Chat();

                //errMsg = "Done Chat";



            }
            catch (Exception erd)
            {
                //lblerror.Text = erd.ToString();
                errMsg = erd.ToString();
            }

        } //Page_Load

        protected void getSOAP()
        {
            //Phone_eng          
            stru_Phone_ENG._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_ENG, szServerName);
            stru_Phone_ENG._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Phone_ENG, szServerName);
    
            //phone_fre
            stru_Phone_FRE._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Phone_FRE, szServerName);
            stru_Phone_FRE._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Phone_FRE, szServerName);
                            
            //G2T_ENG
            stru_G2T_ENG._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_ENG, szServerName);
            stru_G2T_ENG._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_G2T_ENG, szServerName);

            //G2T_FRE
            stru_G2T_FRE._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_G2T_FRE, szServerName);
            stru_G2T_FRE._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_G2T_FRE, szServerName);

            //Hlth_EN
            stru_Hlth_ENG._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Hlth_ENG, szServerName);
            stru_Hlth_ENG._HandledToday =   client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Hlth_ENG, szServerName);
            stru_Hlth_ENG._CurrentInQueued = client.GetCurQueued(           dwSwitchID, iQueueID_Hlth_ENG, szServerName);

            //Hlth_FR
            stru_Hlth_FRE._LongestWaitTime = client.GetCurLongestQueuedTime( dwSwitchID, iQueueID_Hlth_FRE, szServerName);
            stru_Hlth_FRE._HandledToday =    client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Hlth_FRE, szServerName);
            stru_Hlth_FRE._CurrentInQueued = client.GetCurQueued(            dwSwitchID, iQueueID_Hlth_FRE, szServerName);

            //Chat_ENG
            stru_Chat_ENG._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_ENG, szServerName);
            stru_Chat_ENG._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Chat_ENG, szServerName);

            //Chat_FRE
            stru_Chat_FRE._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_Chat_FRE, szServerName);
            stru_Chat_FRE._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_Chat_FRE, szServerName);

            //ChatApp_ENG
            stru_ChatApp_ENG._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);
            stru_ChatApp_ENG._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_ENG, szServerName);

            //ChatApp_FRE
            stru_ChatApp_FRE._LongestWaitTime = client.GetCurLongestQueuedTime(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE._HandledToday = client.GetNumHandledInThisQueue(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);
            stru_ChatApp_FRE._CurrentInQueued = client.GetCurQueued(dwSwitchID, iQueueID_ChatApp_FRE, szServerName);

            
            
        }

        protected void Phone()
        {

            try
            {
                // Current in the Queue
                int Queued_Phone_ENG = Convert.ToInt32(stru_Phone_ENG._CurrentInQueued);
                int Queued_Phone_FRE = Convert.ToInt32(stru_Phone_FRE._CurrentInQueued);
                int Queued_G2T_ENG = Convert.ToInt32(stru_G2T_ENG._CurrentInQueued);
                int Queued_G2T_FRE = Convert.ToInt32(stru_G2T_FRE._CurrentInQueued);
                int Queued_Hlth_ENG = Convert.ToInt32(stru_Hlth_ENG._CurrentInQueued);
                int Queued_Hlth_FRE = Convert.ToInt32(stru_Hlth_FRE._CurrentInQueued);

                lblInQueue_Phone_ENG.Text = Queued_Phone_ENG.ToString();
                lblInQueue_Phone_FRE.Text = Queued_Phone_FRE.ToString();
                lblInQueue_G2T_ENG.Text = Queued_G2T_ENG.ToString();
                lblInQueue_G2T_FRE.Text = Queued_G2T_FRE.ToString();
                lblInQueue_Hlth_ENG.Text = Queued_Hlth_ENG.ToString();
                lblInQueue_Hlth_FRE.Text = Queued_Hlth_FRE.ToString();

                HiddenlblInQueue_Phone_ENG.Value = Queued_Phone_ENG.ToString();
                HiddenlblInQueue_Phone_FRE.Value = Queued_Phone_FRE.ToString();
                HiddenlblInQueue_G2T_ENG.Value = Queued_G2T_ENG.ToString();
                HiddenlblInQueue_G2T_FRE.Value = Queued_G2T_FRE.ToString();
                HiddenlblInQueue_Hlth_ENG.Value = Queued_Hlth_ENG.ToString();
                HiddenlblInQueue_Hlth_FRE.Value = Queued_Hlth_FRE.ToString();

                // Total in the Queue ; to be display on the left hand column
                lblTotalNumOfInQueue_Phone.Text = 
                    (Queued_Phone_ENG 
                    + Queued_Phone_FRE 
                    + Queued_G2T_ENG 
                    + Queued_G2T_FRE 
                    + Queued_Hlth_ENG 
                    + Queued_Hlth_FRE).ToString();


                //Longest wait time 
                double LongestWaitTime_Phone_ENG = Convert.ToDouble(stru_Phone_ENG._LongestWaitTime) / 60;// Convert to mintue
                double LongestWaitTime_Phone_FRE = Convert.ToDouble(stru_Phone_FRE._LongestWaitTime) / 60; // Convert to mintue
                double LongestWaitTime_G2T_ENG =   Convert.ToDouble(stru_G2T_ENG._LongestWaitTime) / 60; // Convert to mintue
                double LongestWaitTime_G2T_FRE =   Convert.ToDouble(stru_G2T_FRE._LongestWaitTime) / 60; // Convert to mintue
                double LongestWaitTime_Hlth_ENG =  Convert.ToDouble(stru_Hlth_ENG._LongestWaitTime) / 60; // Convert to mintue
                double LongestWaitTime_Hlth_FRE =  Convert.ToDouble(stru_Hlth_FRE._LongestWaitTime) / 60; // Convert to mintue

                var timeSpan = TimeSpan.FromMinutes(LongestWaitTime_Phone_ENG);
                lblPhoneLongestWaitTime_Phone_ENG.Text = timeSpan.Hours.ToString("0") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
                HiddenPhoneEnLongestWaitTime.Value = lblPhoneLongestWaitTime_Phone_ENG.Text;

                var timeSpan2 = TimeSpan.FromMinutes(LongestWaitTime_Phone_FRE);
                lblPhoneLongestWaitTime_Phone_FRE.Text = timeSpan2.Hours.ToString("0") + ":" + timeSpan2.Minutes.ToString("00") + ":" + timeSpan2.Seconds.ToString("00");
                HiddenPhoneFrLongestWaitTime.Value = lblPhoneLongestWaitTime_Phone_FRE.Text;

                var timeSpan3 = TimeSpan.FromMinutes(LongestWaitTime_G2T_ENG);
                lblPhoneLongestWaitTime_G2T_ENG.Text = timeSpan3.Hours.ToString("0") + ":" + timeSpan3.Minutes.ToString("00") + ":" + timeSpan3.Seconds.ToString("00");
                HiddenG2TEnLongestWaitTime.Value = lblPhoneLongestWaitTime_G2T_ENG.Text;

                var timeSpan4 = TimeSpan.FromMinutes(LongestWaitTime_G2T_FRE);
                lblPhoneLongestWaitTime_G2T_FRE.Text = timeSpan4.Hours.ToString("0") + ":" + timeSpan4.Minutes.ToString("00") + ":" + timeSpan4.Seconds.ToString("00");
                HiddenG2TFrLongestWaitTime.Value = lblPhoneLongestWaitTime_G2T_FRE.Text;

                var timeSpan5 = TimeSpan.FromMinutes(LongestWaitTime_Hlth_ENG);
                lblPhoneLongestWaitTime_Hlth_ENG.Text = timeSpan5.Hours.ToString("0") + ":" + timeSpan5.Minutes.ToString("00") + ":" + timeSpan5.Seconds.ToString("00");
                HiddenG2TEnLongestWaitTime.Value = lblPhoneLongestWaitTime_G2T_ENG.Text;

                var timeSpan6 = TimeSpan.FromMinutes(LongestWaitTime_Hlth_FRE);
                lblPhoneLongestWaitTime_Hlth_FRE.Text = timeSpan6.Hours.ToString("0") + ":" + timeSpan6.Minutes.ToString("00") + ":" + timeSpan6.Seconds.ToString("00");
                HiddenG2TFrLongestWaitTime.Value = lblPhoneLongestWaitTime_G2T_FRE.Text;


                // total phone handled totay , display on the bottom of phone scation 
                int TotalPhoneHandled = 0;
                TotalPhoneHandled = Convert.ToInt32(stru_Phone_ENG._HandledToday)
                                    + Convert.ToInt32(stru_Phone_FRE._HandledToday)
                                    + Convert.ToInt32(stru_G2T_ENG._HandledToday)
                                    + Convert.ToInt32(stru_G2T_FRE._HandledToday)
                                    + Convert.ToInt32(stru_Hlth_ENG._HandledToday)
                                    + Convert.ToInt32(stru_Hlth_FRE._HandledToday)
                                    ;

                lblTotalPhoneHandled.Text = TotalPhoneHandled.ToString();  // <-- sum

            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }
        } //end process phone


        protected void Chat()
        {
            try
            {
                // Current in the Queue
                int Queued_Chat_ENG = Convert.ToInt32(stru_Chat_ENG._CurrentInQueued);
                int Queued_Chat_FRE = Convert.ToInt32(stru_Chat_FRE._CurrentInQueued);
                int Queued_ChatApp_ENG = Convert.ToInt32(stru_ChatApp_ENG._CurrentInQueued);
                int Queued_ChatApp_FRE = Convert.ToInt32(stru_ChatApp_FRE._CurrentInQueued);

                lblInQueue_Chat_ENG.Text = Queued_Chat_ENG.ToString();
                lblInQueue_Chat_FRE.Text = Queued_Chat_FRE.ToString();
                lblInQueue_ChatApp_ENG.Text = Queued_ChatApp_ENG.ToString();
                lblInQueue_ChatApp_FRE.Text = Queued_ChatApp_FRE.ToString();
                HiddenlblInQueue_Chat_ENG.Value = Queued_Chat_ENG.ToString();
                HiddenlblInQueue_Chat_FRE.Value = Queued_Chat_FRE.ToString();
                HiddenlblInQueue_ChatApp_ENG.Value = Queued_ChatApp_ENG.ToString();
                HiddenlblInQueue_ChatApp_FRE.Value = Queued_ChatApp_FRE.ToString();

                // Total in the Queue
                lblTotalNumOfInQueue_Chat.Text = (Queued_Chat_ENG + Queued_Chat_FRE + Queued_ChatApp_ENG + Queued_ChatApp_FRE).ToString();


                //Longest wait time 
                double LongestWaitTime_Chat_ENG = Convert.ToDouble(stru_Chat_ENG._LongestWaitTime) / 60;// Convert to mintue
                double LongestWaitTime_Chat_FRE = Convert.ToDouble(stru_Chat_FRE._LongestWaitTime) / 60; // Convert to mintue
                double LongestWaitTime_ChatApp_ENG = Convert.ToDouble(stru_ChatApp_ENG._LongestWaitTime) / 60; // Convert to mintue
                double LongestWaitTime_ChatApp_FRE = Convert.ToDouble(stru_ChatApp_FRE._LongestWaitTime) / 60; // Convert to mintue

                var timeSpan = TimeSpan.FromMinutes(LongestWaitTime_Chat_ENG);
                lblLongestWaitTime_Chat_ENG.Text = timeSpan.Hours.ToString("0") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
                HiddenChatWebEnLongestWaitTime.Value = lblLongestWaitTime_Chat_ENG.Text;

                var timeSpan2 = TimeSpan.FromMinutes(LongestWaitTime_Chat_FRE);
                lblLongestWaitTime_Chat_FRE.Text = timeSpan2.Hours.ToString("0") + ":" + timeSpan2.Minutes.ToString("00") + ":" + timeSpan2.Seconds.ToString("00");
                HiddenChatWebFrLongestWaitTime.Value = lblLongestWaitTime_Chat_FRE.Text;

                var timeSpan3 = TimeSpan.FromMinutes(LongestWaitTime_ChatApp_ENG);
                lblLongestWaitTime_ChatApp_ENG.Text = timeSpan3.Hours.ToString("0") + ":" + timeSpan3.Minutes.ToString("00") + ":" + timeSpan3.Seconds.ToString("00");
                HiddenChatAppEnLongestWaitTime.Value = lblLongestWaitTime_ChatApp_ENG.Text;

                var timeSpan4 = TimeSpan.FromMinutes(LongestWaitTime_ChatApp_FRE);
                lblLongestWaitTime_ChatApp_FRE.Text = timeSpan4.Hours.ToString("0") + ":" + timeSpan4.Minutes.ToString("00") + ":" + timeSpan4.Seconds.ToString("00");
                HiddenChatAppFrLongestWaitTime.Value = lblLongestWaitTime_ChatApp_FRE.Text;


                // total Chat handled totay
                int TotalChatHandled = 0;
                TotalChatHandled = Convert.ToInt32(stru_Chat_ENG._HandledToday)
                                    + Convert.ToInt32(stru_Chat_FRE._HandledToday)
                                    + Convert.ToInt32(stru_ChatApp_ENG._HandledToday)
                                    + Convert.ToInt32(stru_ChatApp_FRE._HandledToday);

                lblTotalChatHandled.Text = TotalChatHandled.ToString();  // <-- sum

            }
            catch (Exception erd)
            {
                lblerror.Text = erd.ToString();
            }

        } //end process chat

        protected void getAgents()
        {
            var _status = new Proc_GetAgentStatus_Result();
            _status.status = "";
            _status.Weight = 1;
            var _agents =  efagent.Proc_GetAgent( ).ToList();
            string errmsg = "";
            try
            {
                int i = 1;
                foreach (Proc_GetAgent_Result _x in _agents)
                {
                    // check agent status
                    string agentstatuscode = client.GetIceAgentState(dwSwitchID, _x.AgentID.ToString(), szServerName);// all string
                    string[] codes = agentstatuscode.Split(','); // split codes by " ,  "
                    string agentstatus = "";
                    int weight = 0;
                    
                    //errmsg = "AgentID="+_x.AgentID.ToString() + " <====> " + i.ToString() +"   <---->  Agent Name = " + _x.AgentName + " <---->    Codes="+codes[0];

                    //i = i + 1; 
                    //if (i == 51)
                    //{
                    //    errmsg += "";
                    //}





                    if ((!String.IsNullOrEmpty(codes[0]) ) && ( (  codes[0]  != "25"))  )
                    {
                        try
                        {
                            _status = efContext.Proc_GetAgentStatus(Convert.ToInt32(codes[0])).FirstOrDefault();
                            agentstatus = _status.status;
                            weight = Convert.ToInt32(_status.Weight);
                        }
                        catch
                        {
                            continue;
                        }
                        

               

                        agents.Add(new agent() {
                            agentID = _x.AgentID
                            , agentName = _x.AgentName
                            , statusecode = codes[0]
                            , status = agentstatus
                            , weight = weight
                        });
                    }
                    else
                    {
                        continue;
                    }
   
                }
            }
            catch (Exception erd)
            {
                //lblerror.Text = erd.ToString();
                //errmsg += "  <----->   "+  erd.ToString();
            }
        }

        protected  DataSet DSCounsellor()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("counsellor");
            dt.Clear();
            dt.Columns.Add("Weight", typeof(int));
            dt.Columns.Add("Counsellor", typeof(string));
            dt.Columns.Add("Status", typeof(string));


            if (agents != null)
            { 
                foreach (agent _x in agents)
                {
                    dt.Rows.Add(new object[] {  _x.weight, _x.agentName, _x.status});
                }

                //Sort by weight 
                DataView dv = new DataView(dt);
                dv.Sort = "Weight ASC, Counsellor ASC";
                dt = dv.ToTable();
                // add data table to DataSet
                ds.Tables.Add(dt);
 
            }
 
            return ds;
        }

         
        protected void gvCounsellor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCounsellor.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数
        }
        void BindData()
        {
            this.gvCounsellor.DataSource = DSCounsellor(); //就是连接数据库那些，
                                                         //SqlConnection,SqlCommand,SqlAdapter,…..
            this.gvCounsellor.DataBind();
        }

        protected void gvCounsellor_Sorting(object sender, GridViewSortEventArgs e)
        {
            // 从事件参数获取排序数据列
            string sortExpression = e.SortExpression.ToString();

            // 假定为排序方向为“顺序”
            string sortDirection = "ASC";

            // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
            if (sortExpression == this.gvCounsellor.Attributes["SortExpression"])
            {
                //获得下一次的排序状态
                sortDirection = (this.gvCounsellor.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
            }

            // 重新设定GridView排序数据列及排序方向
            this.gvCounsellor.Attributes["SortExpression"] = sortExpression;
            this.gvCounsellor.Attributes["SortDirection"] = sortDirection;

            //this.BindGridView();

        }

  
    } // end class readerboard
}