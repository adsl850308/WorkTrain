using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ChatRoom
{
    class SaveXml
    {
       private XmlDocument doc = new XmlDocument();

        public void SetXml()
        {
            try
            {
                XmlElement root = doc.CreateElement("ChatRoom");
                doc.AppendChild(root);

                string[] s = ChatRoom.history.Split(new string[] { ":", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] t = ChatRoom.historytime.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                for (int n = 0; n < s.Length; n += 2)
                {

                    XmlElement messagesend = doc.CreateElement("MessageSend");
                    root.AppendChild(messagesend);

                    XmlElement user = doc.CreateElement("User");
                    messagesend.AppendChild(user);
                    user.InnerText = s[n];


                    XmlElement content = doc.CreateElement("Message");
                    messagesend.AppendChild(content);
                    content.InnerText = s[n + 1];


                    XmlElement time = doc.CreateElement("Time");
                    messagesend.AppendChild(time);
                    time.InnerText = t[n / 2];

                }
                doc.Save("D:/MSI_AIO_Assignment/ChatHistory.xml");
            }
            catch (Exception ) {


            }
            
        }
        
        public void SetFolder() {
           bool dir = Directory.Exists("D:/MSI_AIO_Assignment");
            if (dir == false)
            {
                Directory.CreateDirectory("D:/MSI_AIO_Assignment");
            }
        }

        public string ReadXml(string file) {
            string s = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNodeList xmlNodeList = doc.SelectNodes("ChatRoom/MessageSend");
            foreach (XmlNode xmlNode in xmlNodeList) {
              s += xmlNode.SelectSingleNode("User").InnerText+":"+ xmlNode.SelectSingleNode("Message").InnerText+Environment.NewLine;
            }
            return s;
         }

        public void AutoSetXml() {
            try
            {
                XmlElement root = doc.CreateElement("ChatRoom");
                doc.AppendChild(root);

                string[] s = ChatRoom.history.Split(new string[] { ":", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] t = ChatRoom.historytime.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                for (int n = 0; n < s.Length; n += 2)
                {

                    XmlElement messagesend = doc.CreateElement("MessageSend");
                    root.AppendChild(messagesend);

                    XmlElement user = doc.CreateElement("User");
                    messagesend.AppendChild(user);
                    user.InnerText = s[n];


                    XmlElement content = doc.CreateElement("Message");
                    messagesend.AppendChild(content);
                    content.InnerText = s[n + 1];


                    XmlElement time = doc.CreateElement("Time");
                    messagesend.AppendChild(time);
                    time.InnerText = t[n / 2];

                }
                doc.Save("D:/MSI_AIO_Assignment/ChatHistory_Auto.xml");

               
            }
            catch (Exception )
            {


            }


        }
    }
}
