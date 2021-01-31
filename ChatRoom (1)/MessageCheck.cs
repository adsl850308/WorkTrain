using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    class MessageCheck
    {
        public delegate void DelAddNameHandler(string message);
        public DelAddNameHandler Addusername;
        public delegate void DelCancelUserNameHandler();
        public DelCancelUserNameHandler cancelName;
        public delegate void DelRepeatUserNameHadler();
        public DelRepeatUserNameHadler repeatName;
        public delegate void DelAddHistoryHandler(string message);
        public DelAddHistoryHandler addHistory;

        private UdpChat udpchat;
        private ChatRoom chatRoom;
        public string otherUser = "";

        

        public MessageCheck(UdpChat udpChat)
        {
            udpchat = udpChat;
        }
        public void MessageJudgment(string message)
        {

            if (message.StartsWith("Online"))
            {
                if (message.Substring(6) == ChatRoom.username)
                {
                    udpchat.SendMessage("ISREPEAT");

                }
                else
                {

                    Addusername.Invoke(message.Substring(6));
                    chatRoom.AdddUserNAME(message.Substring(6));
                    otherUser = message.Substring(6);
                    udpchat.SendMessage("Respones" + ChatRoom.username);
                }
            }
            else if (message.StartsWith("Offline"))
            {

                cancelName.Invoke();
            }
            else if (message.StartsWith("Respones"))
            {

                Addusername.Invoke(message.Substring(8));

            }
            else if (message.StartsWith("ISREPEAT"))
            {
                Login lg = new Login();

                repeatName.Invoke();
                MessageBox.Show("Repeat Name!!");

                lg.Owner = chatRoom;

                if (lg.ShowDialog(chatRoom) == DialogResult.OK)
                {
                    ChatRoom.username = lg.GetName();
                    chatRoom.SetText(ChatRoom.username);
                    udpchat.SendMessage("Online" + ChatRoom.username);
                }
                else
                {
                    //_button.Enabled = true;
                }
            }
            else
            {
                addHistory.Invoke(message);
            }

        }

        private void ChatRoom_E_AdddUserNAME1(string username)
        {
            throw new NotImplementedException();
        }

        private void ChatRoom_E_AdddUserNAME(string username)
        {
            throw new NotImplementedException();
        }


    }
}

