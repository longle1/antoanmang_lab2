using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_3
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            Server_contents.ReadOnly = true;
        }
        TcpListener listener;
        TcpClient client;
        byte[] rcvData;
        NetworkStream stream;
        Thread thread;

        public void startThread()
        {
            client = listener.AcceptTcpClient();
            writeData("Server Start!!!");
            stream = client.GetStream();
            rcvData = new byte[1024];
            int i;
            string message;
            while (((i = stream.Read(rcvData, 0, rcvData.Length)) != 0) && client != null)
            {
                message = Encoding.UTF8.GetString(rcvData, 0, i);
                writeData(message);
            }
            thread.Abort();
        }
        public void writeData(string msg)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { Server_contents.AppendText(msg + Environment.NewLine); });
            this.BeginInvoke(invoker);
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();

            thread = new Thread(new ThreadStart(startThread));
            thread.Start();
        }
    }
}
