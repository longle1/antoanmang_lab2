using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_3
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            btnDisconnect.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            btnSend.Enabled = false;
        }
        TcpClient client;
        NetworkStream stream;
        byte[] sendData;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSend.Enabled = true;
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                sendData = Encoding.UTF8.GetBytes("Connect Accept from 127.0.0.1:8080");
                stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng lắng nghe trên server trước khi Connect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung trước khi gửi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sendData = Encoding.UTF8.GetBytes("From 172.0.0.1: " + txtSend.Text);
            stream.Write(sendData, 0, sendData.Length);
            txtSend.Clear();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            MessageBox.Show("Đã ngừng kết nối tới Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }
}
