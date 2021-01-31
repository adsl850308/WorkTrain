using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChatRoom
{
    class UdpChat
    {
        public MessageCheck messageCheck;

        private Thread myThread;
        public UdpClient sendUdpClient;


        private int _localPort;
        private int _remtoePort;


        public UdpChat(int localPort, int remotePort)
        {
            _localPort = localPort;
            _remtoePort = remotePort;
        }

        public void ReceiveData() {
            UdpClient listener = new UdpClient(_localPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (true)
                {
                    byte[] receivebytes = listener.Receive(ref groupEP);
                    string receiveMessage = Encoding.Unicode.GetString(receivebytes, 0, receivebytes.Length);
                    messageCheck.MessageJudgment(receiveMessage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("傳送失敗");

            }
        }
            public void SendMessage(object obj) {
            

            sendUdpClient = new UdpClient();

            string message = (string)obj;
            byte[] bytes = Encoding.Unicode.GetBytes(message);
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, _remtoePort);
            sendUdpClient.EnableBroadcast = true;
            sendUdpClient.Send(bytes, bytes.Length, iep);
        }

        public void ReceiveStart() {
            myThread = new Thread(ReceiveData);
            myThread.IsBackground = true;
            myThread.Start();
        }
        public void ReceiveClose()
        {
            if (myThread.IsAlive)
            {
                myThread.Abort();
            }
        }
    }
}
