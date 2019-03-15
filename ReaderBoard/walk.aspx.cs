using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ReaderBoard
{
    public partial class walk : System.Web.UI.Page
    {
        public string url = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                {
                url = Properties.Settings.Default.walkUrl;
            }

            gvdonor.DataSource = getDonor(url);
            gvdonor.DataBind();

        }


        protected DataSet getDonor(string url)
        {
            XmlDocument doc = new XmlDocument();
            DataSet ds = new DataSet();
            double collect = 0.0;
            string name = "";

            DataTable dt = new DataTable("donor");
            dt.Clear();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("amount", typeof(double));

            try
            {
                doc.Load(url);
            }
            catch
            {

            }

            XmlNodeList root = doc.SelectNodes("//root//ParticipantScoreBoard_collection");
            XmlNodeList ParticipantScoreBoard_List = doc.SelectNodes("//ParticipantScoreBoard");
            if (ParticipantScoreBoard_List != null)
            {
                foreach (XmlNode ParticipantScoreBoard in ParticipantScoreBoard_List)
                {
                    string fn = ParticipantScoreBoard["ParticipantFirstName"].InnerText;
                    string ln = ParticipantScoreBoard["ParticipantLastName"].InnerText;
                    string collect1 = ParticipantScoreBoard["onlineTotalCollected"].InnerText;
                    string collect2 = ParticipantScoreBoard["offlineTotalCollected"].InnerText;
                   
                    try
                    {
                        if (!string.IsNullOrEmpty(fn))
                        {
                            name = fn + " ";
                        }
                        if (!string.IsNullOrEmpty(ln))
                        {
                            name = name + ln;
                        }


                        collect = Convert.ToDouble(collect1) + Convert.ToDouble(collect2);
                    }
                    catch
                    {
                        collect = 0.00;
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        dt.Rows.Add(new object[] { name, collect });
                    }
                }

                ds.Tables.Add(dt);
            }


            return ds;
        }
    }
}