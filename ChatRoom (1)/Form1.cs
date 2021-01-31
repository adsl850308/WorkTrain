using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class ChatRoom : Form
    {
        //有關 textbox 不同class 用法
        public  List<string> namelist = new List<string>();
        public  List<string> li = new List<string>();
        private bool onlineStatus = false;
        public static string history;
        public static string historytime;
        public static string username="";

        private MessageCheck messageCheck;
        private  UdpChat UdpChat;



        public ChatRoom()
        {
            InitializeComponent();
            
        }
        public void BtnUpdate()
        {
            if (SendText.Text == "")
            {
                SendBtn.Enabled = false;
            } else if (SendText.Text != "" && LoginBtn.Enabled == false)
            {
                SendBtn.Enabled = true;
            }
            else if (MessageShow.Text == "")
            {
                SaveBtn.Enabled = false;

            } 
            else if (SendText.Text != "")
            {
                SendBtn.Enabled = true;
            }
            else if (LoginBtn.Enabled == false)
            {
                OpenBtn.Enabled = false;

            }
            else if (LoginBtn.Enabled == true) {
                OpenBtn.Enabled = true;
            }
        }
        public string SetText(string text)
        {

            if (namelist.Contains(text))
            {
                MessageBox.Show("Repeat Name!!");
                return "LoginFALSE";
            }
            else
            {
                username = text;
                UserName.Text =  username;

                return "LoginOK";
            }

        }

      

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Owner = this;
 
            if (loginForm.ShowDialog(this) == DialogResult.OK)
            {
                UdpChat = new UdpChat(loginForm.port1, loginForm.port2);

                messageCheck = new MessageCheck(UdpChat);
                messageCheck.Addusername = AdddUserNAME;
                messageCheck.cancelName = CancelUserName;
                messageCheck.repeatName = RepeatUserName;
                messageCheck.addHistory = AddTextHistory;
                UdpChat.messageCheck = messageCheck;

                UdpChat.ReceiveStart();

                UdpChat.SendMessage("Online" + username);

                LoginBtn.Enabled = false;
                BtnUpdate();
                onlineStatus = true;
                //TODO: Login -> Username.
            }
            else
            {
                LoginBtn.Enabled = true;
                BtnUpdate();

            }
        }




        private void SendBtn_Click(object sender, EventArgs e)
        {
            MessageShow.AppendText(username+":"+SendText.Text+ Environment.NewLine);
            li.Add(DateTime.Now.ToString("MM-dd-yyyy,HH:mm"));
            try
            {
               
                UdpChat.SendMessage(username + ":" + SendText.Text);
                SendText.Text = "";
            }
            catch (Exception) {
                SendText.Text = "";

            }

        }
        private void SendText_TextChanged(object sender, EventArgs e)
        {

            BtnUpdate();
        }

        private void SendText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendBtn_Click(null, null);
                SendText.Focus();
            }
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            history = MessageShow.Text;
            historytime = string.Join("/", li);
            
            SaveXml saveXml = new SaveXml();
            saveXml.SetFolder();
            saveXml.SetXml();
            
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            
            OpenFile openFile = new OpenFile();
            openFile.ShowDialog();

            MessageShow.Text = openFile.sss;
            //messageshow = MessageShow;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval=(1000*60*5);
            SaveXml saveXml = new SaveXml();
            saveXml.SetFolder();
            saveXml.AutoSetXml();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (onlineStatus)
                {
                    UdpChat.SendMessage("Offline");
                    UdpChat.ReceiveClose();
                 
                }
                else {

                }
            }
            catch (Exception)
            {
            }
            finally {
                SaveXml saveXml = new SaveXml();
                saveXml.SetXml();
                this.Close();

            }
        }

        private void MessageShow_TextChanged(object sender, EventArgs e)
        {
            BtnUpdate();
        }



        public delegate void DelAddTextHistory(string sMessage);

        public void AddTextHistory(string sMessage)
        {
            if (MessageShow.InvokeRequired)
            {
                DelAddTextHistory del = new DelAddTextHistory(AddTextHistory);
                MessageShow.Invoke(del, sMessage);
            }
            else
            {
                MessageShow.AppendText(sMessage + "\r\n");
            }
        }
        public delegate void DelAddUserName(string username);
        public DelAddUserName addname;


        public void AdddUserNAME(string username)
        {
            if (UserName.InvokeRequired)
            {
                DelAddUserName del = new DelAddUserName(AdddUserNAME);
                UserName.Invoke(del, username);
            }
            else
            {
                UserName.AppendText("\r\n" + username);
            }
        }
        public delegate void DelCancelUserName();
        public void CancelUserName()
        {
            if (UserName.InvokeRequired)
            {
                DelCancelUserName del = new DelCancelUserName(CancelUserName);
                UserName.Invoke(del);
            }
            else
            {
                UserName.Clear();
                UserName.Text = username;
            }
        }
        public delegate void DelRepeatUserName();
        public void RepeatUserName()
        {
            if (UserName.InvokeRequired)
            {
                DelRepeatUserName del = new DelRepeatUserName(RepeatUserName);
                UserName.Invoke(del);
            }
            else
            {
                UserName.Text = "";

            }
        }
    }
}
