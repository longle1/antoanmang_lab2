using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using userInfo;
using userListInfo;
using System.Deployment.Application;
using System.Diagnostics.Eventing.Reader;

namespace Question_4
{
    public partial class Client_Server : Form
    {
        private string userName;
        private int port;
        private TcpClient client = null;
        private byte[] sendingData = null;
        private byte[] receivingData = null;
        private NetworkStream stream = null;
        private Thread thread = null;
        public Client_Server()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Start();
            btnSend.Enabled = false;
            Client_contents.ReadOnly = true;
            CheckForIllegalCrossThreadCalls = false;
        }
        public void UdapteInterface()
        {
            listUserActive.Items.Clear();
            foreach (UserInfo user in UserListInfo.list)
            {
                if (user.status == "active")
                {
                    string text = user.userName;
                    if (string.Equals(user.userName.Trim(), userName.Trim())) text += "(YOU)";
                    listUserActive.Items.Add(text);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!UserListInfo.chatLanOrSinge)
            {
                //Dành cho việc cập nhật lại listView khi client mới được thêm vào
                if (listUserActive.Items.Count < UserListInfo.list.Count) UdapteInterface();
                //Dành cho việc cập nhật lại listView khi client thoát khỏi
                else if (listUserActive.Items.Count > UserListInfo.list.Count) UdapteInterface();
            }
        }
        public Client_Server(string username, string password, int port) : this()
        {
            this.userName = username;
            this.port = port;

            this.Text = userName;
            if (!UserListInfo.chatLanOrSinge) UdapteInterface();
        }
        public bool checkIpAddress(string ip)
        {
            try
            {
                IPAddress.Parse(ip);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                if (txtIpAdress.Text.Trim() == "")
                {
                    UserListInfo.chatLanOrSinge = false;
                    client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                }
                else
                {
                    if (!checkIpAddress(txtIpAdress.Text.Trim()))
                    {
                        MessageBox.Show("Địa chỉ IP không hợp lệ, vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    UserListInfo.chatLanOrSinge = true;
                    client.Connect(IPAddress.Parse(txtIpAdress.Text), 8080);
                }

                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                stream = client.GetStream();
                if(UserListInfo.chatLanOrSinge) { sendingData = Encoding.UTF8.GetBytes($"{userName}: đã tham gia phòng chat!!!"); }
                else sendingData = Encoding.UTF8.GetBytes($"{userName} đã tham gia phòng chat!!!");
                stream.Write(sendingData, 0, sendingData.Length);
                thread = new Thread(new ThreadStart(safeThread));
                thread.Start();


                MessageBox.Show("Đã kết nối thành công tới server", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối tới server thất bại, Vui lòng thử lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void safeThread()
        {
            while (true)
            {
                try
                {
                    receivingData = new byte[1024];
                    int length = stream.Read(receivingData, 0, receivingData.Length);
                    string data = Encoding.UTF8.GetString(receivingData, 0, length);
                    if (length == 0)
                    {
                        logOut();
                        break;
                    }
                    writeData(data);
                    Array.Clear(receivingData, 0, receivingData.Length);
                }
                catch (Exception ex)
                {
                    logOut();
                }
            }
        }
        private void writeData(string msg)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { Client_contents.Text += msg + Environment.NewLine; });
            this.Invoke(invoker);
        }
        private void logOut()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
            if (thread != null) thread.Abort();
            if (!UserListInfo.chatLanOrSinge)
            {
                UserListInfo.remove(userName);
            }
            timer1.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSendData.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung trước khi gửi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sendingData = Encoding.UTF8.GetBytes($"{userName}: {txtSendData.Text}");
            stream.Write(sendingData, 0, sendingData.Length);
            writeData("----->Me: " + txtSendData.Text);
            txtSendData.Clear();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!UserListInfo.chatLanOrSinge)
            {
                bool check = false;
                List<Client_Client> clientClientForm = Application.OpenForms.OfType<Client_Client>().ToList();
                foreach (Client_Client clientToClient in clientClientForm)
                {
                    if (clientToClient.Text == userName && clientToClient != null && !clientToClient.IsDisposed && clientToClient.Visible)
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    MessageBox.Show("Bạn đang thực hiện chat 1 - 1 nên không thể log out", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                sendingData = Encoding.UTF8.GetBytes($"{userName}:");
                stream.Write(sendingData, 0, sendingData.Length);
            }
            logOut();
            this.Close();
            Login lg = new Login();
            lg.Show();
        }
        //sự kiện click vào 1 giá trị bất kì ngoại trừ chính items đó thì sẽ tạo ra đoạn chat giữa client này và client sau khi click vào
        private void listUserActive_DoubleClick(object sender, EventArgs e)
        {
            if (!UserListInfo.chatLanOrSinge)
            {
                if (listUserActive.SelectedItems.Count > 0)
                {
                    try
                    {
                        ListViewItem view = listUserActive.SelectedItems[0];
                        if (view.ToString().Contains("YOU"))
                        {
                            MessageBox.Show("Vui lòng chọn user khác ngoài bạn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            string usernames = userName + ":" + view.Text;
                            if (ListClientChatTogether.checkEnable(userName, view.Text))
                            {
                                MessageBox.Show($"Bạn đang chat với {view.Text}, vui lòng chọn user khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ListClientChatTogether.list.Add(usernames);
                            int difPort = UserListInfo.getPort(view.Text);
                            Client_Client myChat = new Client_Client(userName, port, difPort, $"{port}:{difPort}");
                            myChat.Show();
                            Client_Client client = new Client_Client(view.Text, difPort, port, $"{difPort}:{port}");
                            client.Show();
                        }
                        listUserActive.SelectedItems.Clear();
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tính năng này hiện chỉ dùng trong cùng 1 máy, vui lòng thử lại sau");
                return;
            }
        }
        private void Client_Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(UserListInfo.chatLanOrSinge) {
                if(client != null)
                {
                    sendingData = Encoding.UTF8.GetBytes($"{userName}:");
                    stream.Write(sendingData, 0, sendingData.Length);
                }
            }
            logOut();
        }

    }
}
