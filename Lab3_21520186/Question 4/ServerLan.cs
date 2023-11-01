using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Question_4
{
    public partial class ServerLan : Form
    {
        public ServerLan()
        {
            InitializeComponent();
            listClients = new Hashtable();
            Server_contents.ReadOnly = true;
            threadContainsChatClient = new Hashtable();
        }
        TcpListener server = null;
        TcpClient client = null;
        Thread thread;// thread lắng nghe chat
        Thread newThread = null;
        NetworkStream stream = null;
        Hashtable listClients = null;
        Hashtable threadContainsChatClient = null;
        delegate void ClearCacheListViewData(string data);
        void sendData(string userName, string data)
        {
            foreach (string key in listClients.Keys)
            {
                if (userName != key)
                {
                    TcpClient cl = (TcpClient)listClients[key];
                    byte[] sendingData = Encoding.UTF8.GetBytes(data);
                    NetworkStream newStream = cl.GetStream();
                    newStream.Write(sendingData, 0, sendingData.Length);
                }
            }
        }
        private void handleOutRoom(string userName)
        {
            string dataOutRoom = $"{userName} đã rời phòng chat!!!";
            writeData(dataOutRoom);
            sendData(userName, dataOutRoom);
            removeItemsUserActive(userName);
            listClients.Remove(userName);
            //lặp qua các luồng để tìm đúng luồng thread của client đó
            //tiến hành lấy ra thread đó
            Thread thread = null;
            foreach(string key in threadContainsChatClient.Keys)
            {
                if(key == userName)
                {
                    thread = (Thread)threadContainsChatClient[key];
                    break;
                }
            }
            threadContainsChatClient.Remove(userName);
            thread.Abort();
        }
        private void writeData(string msg)
        {
            try
            {
                MethodInvoker invoker = new MethodInvoker(delegate { Server_contents.Text += msg + Environment.NewLine; });
                this.Invoke(invoker);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ghi dữ liệu thất bại, vui lòng thực hiện lại");
            }
        }
        void removeItemsUserActive(string userName)
        {
            if (listUserActive.InvokeRequired)
            {
                ClearCacheListViewData clearCacheListViewData = new ClearCacheListViewData(removeItemsUserActive);
                listUserActive.Invoke(clearCacheListViewData, new object[] { userName });
            }
            else
            {
                foreach (ListViewItem item in listUserActive.Items)
                {
                    if (item.Text == userName)
                        listUserActive.Items.Remove(item);
                }
            }
        }
        void rcvData(object client)
        {
            TcpClient client1 = (TcpClient)client;
            while (true)
            {
                stream = client1.GetStream();
                byte[] rcvData = new byte[1024];
                int length = stream.Read(rcvData, 0, rcvData.Length);
                string data = Encoding.UTF8.GetString(rcvData, 0, length);
                string userName = data.Split(':')[0].Trim();
                if (data.Split(':')[1].Trim().Length == 0)
                {
                    handleOutRoom(userName);
                    return;
                }
                writeData(data);
                sendData(userName, data);
            }
        }
        private bool IsAttributeExists(string userName)
        {
            if (listUserActive.InvokeRequired)
            {
                return (bool)listUserActive.Invoke(new Func<string, bool>(IsAttributeExists), new object[] { userName });
            }
            else
            {
                foreach (ListViewItem item in listUserActive.Items)
                {
                    if (item.Text.Equals(userName))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public void containsListUserActive(string userName)
        {
            //thêm vào listView
            if (!IsAttributeExists(userName))
                addListUserActive(userName);
        }
        public void addListUserActive(string userName)
        {
            if (listUserActive.InvokeRequired)
            {
                ClearCacheListViewData clearCacheListViewData = new ClearCacheListViewData(addListUserActive);
                listUserActive.Invoke(clearCacheListViewData, new object[] { userName });
            }
            else
                listUserActive.Items.Add(userName);
        }
        void chat()
        {
            while (true)
            {
                client = server.AcceptTcpClient();
                NetworkStream nwStream = client.GetStream();
                byte[] rcvData1 = new byte[1024];
                int length = nwStream.Read(rcvData1, 0, rcvData1.Length);
                string data = Encoding.UTF8.GetString(rcvData1, 0, length);
                string userName = data.Split(':')[0].Trim();
                writeData(data);
                sendData(userName, data);
                if (listClients.Count == 0)
                {
                    listClients.Add(userName, client);  // thêm client hiện tại vào danh sách
                }
                else
                {
                    //kiểm tra xem client hiện tại đã có trong danh sách hay chưa
                    if (!listClients.ContainsKey(userName))
                    {
                        listClients.Add(userName, client);
                    }
                }
                containsListUserActive(userName);

                thread = new Thread(new ParameterizedThreadStart(rcvData));
                thread.Start(client);
                if (threadContainsChatClient.Count == 0)
                {
                    threadContainsChatClient.Add(userName, thread);  // thêm client hiện tại vào danh sách
                }
                else
                {
                    //kiểm tra xem client hiện tại đã có trong danh sách hay chưa
                    if (!threadContainsChatClient.ContainsKey(userName))
                    {
                        threadContainsChatClient.Add(userName, thread);
                    }
                }
            }
        }
        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                btnListen.Enabled = false;
                server = new TcpListener(IPAddress.Any, 8080);
                server.Start();
                MessageBox.Show("Đang bắt đầu lắng nghe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                newThread = new Thread(new ThreadStart(chat));
                newThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ServerLan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (server != null) server.Stop();
            if (listClients != null)
            {
                listClients.Clear();
            }
            if (threadContainsChatClient != null)
            {
                threadContainsChatClient.Clear();
            }
            if (newThread != null)
                newThread.Abort();
        }
    }
}
