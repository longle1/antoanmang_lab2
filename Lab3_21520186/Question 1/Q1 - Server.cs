using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_1
{
    public partial class Q1_Server : Form
    {
        UdpClient Server;
        Thread thread;
        public Q1_Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Server_Content.Enabled = false; ;
        }
        private void WriteMessage(string Client_Content)
        {
            // Ưu tiên chạy luồng 
            MethodInvoker invoker = new MethodInvoker(delegate { Server_Content.Items.Add(Client_Content); });
            this.BeginInvoke(invoker);
        }
        public void serverThread()
        {
            // lúc nào cũng ngồi chờ thông tin
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = Server.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string mess = RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString();
                WriteMessage(mess);
            }

        }
        
        private void Listen_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int port = int.Parse(Port.Text);
                    if (port < 1000)
                    {
                        MessageBox.Show("Vui lòng nhập giá trị Port >= 1000, vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Server = new UdpClient(port);
                    thread = new Thread(new ThreadStart(serverThread));
                    thread.Start();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Lắng nghe thất bại, vui lòng thực hiện lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Port không hợp lệ, vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if(Server != null) Server.Close();
            if(thread != null) thread.Abort();
            this.Close();
        }
    }
}
    

