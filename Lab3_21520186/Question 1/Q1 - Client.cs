using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_1
{
    public partial class Q1_Client : Form
    {
        UdpClient client;
        public Q1_Client()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (IP_Remote_Host.Text != "127.0.0.1")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ đúng địa chỉ IP Loopback", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int port = int.Parse(Port.Text);
                if (port < 1000)
                {
                    MessageBox.Show("Vui lòng nhập giá trị cổng trên 1000, vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                client = new UdpClient();
                IPEndPoint ipRemote = new IPEndPoint(IPAddress.Parse(IP_Remote_Host.Text), port);


                if (Client_Content.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung! Vui lòng nhập nội dung.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                byte[] sendByteData = Encoding.UTF8.GetBytes(Client_Content.Text);
                client.Send(sendByteData, sendByteData.Length, ipRemote);
                Client_Content.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Cổng nhập vào không đúng! Vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if(client != null) { client.Close(); }
            this.Close();
        }
    }
}
        