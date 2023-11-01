using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_2
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            btnStop.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
        }
        Thread thread;
        Socket client;
        Socket server;
        private void btnListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            thread = new Thread(new ThreadStart(StartUnsafeThread));
            thread.Start();
        }

        public void StartUnsafeThread()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 8080);
            server.Bind(ipEndPoint);
            //chấp nhận kết nối
            server.Listen(3);
            MessageBox.Show("Đang bắt đầu việc lắng nghe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            btnListen.Enabled = false;
            btnStop.Enabled = true;
            // tạo tcp client để nhận thông tin
            Socket client = server.Accept();
            writeData("Telnet running on 127.0.0.1:8080" + Environment.NewLine);
            byte[] rcvData = new byte[1024];
            string data;
            while (true)
            {
                int length = client.Receive(rcvData);
                data = Encoding.UTF8.GetString(rcvData, 0, length);
                writeData(data);
            }
        }
        public void writeData(string msg)
        {
            MethodInvoker methodInvoker = new MethodInvoker(delegate { Server_contents.Text += msg; });
            this.BeginInvoke(methodInvoker);
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã ngừng việc kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (thread != null) thread.Abort();
            if (client != null) client.Close();
            if (server != null) server.Close();
            btnStop.Enabled = false;
            btnListen.Enabled = true;
        }

    }
}
