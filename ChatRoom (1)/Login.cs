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
    public partial class Login : Form
    {
        public  int port1 = 0;
        public  int port2 = 0;


        public Login()
        {
            InitializeComponent();
        }
       
        public void btnEnabled()
        {
            string input = UserNameText.Text;
            if (input == "" )
            {
                OkBtn.Enabled = false;
            } 
            else if(input!="" && portA.Checked==true||portB.Checked==true)
            {
                OkBtn.Enabled = true;

            }
        }
        public string GetName() {
            return UserNameText.Text;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {

            ChatRoom chatRoom =(ChatRoom)this.Owner;
            chatRoom.SetText(UserNameText.Text);
            this.Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserNameText_TextChanged(object sender, EventArgs e)
        {
            btnEnabled();
        }

       
        private void OnRadioButtonChanged(object sender, EventArgs e)
        {
            btnEnabled();

            if (portA.Checked)
            {
                port1 = 11000;
                port2 = 11001;
            }
            else if (portB.Checked)
            {
                port1 = 11001;
                port2 = 11000;
            }
            else
            {
                // Never goes here.
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
