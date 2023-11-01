using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using userInfo;
using userListInfo;

namespace Question_4
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            Server_contents.ReadOnly = true;
            timer1.Interval = 100;
            timer1.Start();
            CheckForIllegalCrossThreadCalls = false;
        }
        private List<TcpClient> ClientToCLient = null;
        private List<TcpClient> listTemp = null;
        private Hashtable listClients = null;
        private Hashtable listClientToClient = null;
        private TcpListener server = null;
        private TcpClient client = null;
        private NetworkStream stream = null;
        private Thread threadClientToServer = null;
        private int index = 0;
        private Thread threadRcvData = null;
        //tạo ra 1 hashtable để quản lý các thread giữa client và client và đảm bảo chỉ được tạo 1 lần duy nhất
        private Hashtable hashThread = null;
        //tạo 1 hashtable để quản lý các thread từng client trong chat multi client
        private Hashtable containsThreadMultiClients = new Hashtable();
        //tạo 1 list để chứa toàn bộ các cặp client riêng lẻ khi chat với nhau
        private List<Thread> threadChatBetweenClients = new List<Thread>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listClients != null && (listUserActive.Items.Count < listClients.Count)) UdapteInterface();
            else if (listClients != null && (listUserActive.Items.Count > listClients.Count)) UdapteInterface();
        }
        private void UdapteInterface()
        {
            listUserActive.Items.Clear();
            foreach (int key in listClients.Keys)
            {
                //lấy ra username
                string username = "";
                foreach (UserInfo user in UserListInfo.list)
                {
                    if (key == user.port)
                    {
                        username = user.userName;
                        break;
                    }
                }
                listUserActive.Items.Add(username);
            }
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
        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                //dùng TcpListner để lắng nghe kết nối từ client
                server = new TcpListener(IPAddress.Any, 8080);
                server.Start();
                btnListen.Enabled = false;
                MessageBox.Show("Đang bắt đầu lắng nghe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                //chứa danh sách các client (chat giữa các client)
                listClients = new Hashtable();
                //chứa danh sách các cặp client (chat giữa client và client)
                listClientToClient = new Hashtable();
                //dùng để lưu các cặp client và là values của hashtable(listClientToClient)
                ClientToCLient = new List<TcpClient>();
                //dùng để chứa các luồng thread mà client - client tạo ra
                hashThread = new Hashtable();
                //tạo ra 1 luồng thread dành cho chat multi client và client - client
                threadClientToServer = new Thread(new ThreadStart(threadChatServer));
                threadClientToServer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn chỉ được phép mở 1 server", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //luồng này giúp phân loại là chat giữa client-client hay multi client
        private void threadChatServer()
        {
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();

                    //tiến hành nhận và phân loại dữ liệu
                    NetworkStream streamClientToClient = client.GetStream();
                    byte[] checkingData = new byte[1024];
                    int length = streamClientToClient.Read(checkingData, 0, checkingData.Length);
                    string rcvData = Encoding.UTF8.GetString(checkingData, 0, length);
                    // chứa danh sách 1 cặp port (1920:1230)
                    string[] listPorts = rcvData.Split(':');
                    if (listPorts != null && listPorts.Length == 2 && UserListInfo.checkPortExist(int.Parse(listPorts[0])) && UserListInfo.checkPortExist(int.Parse(listPorts[1])))
                    {
                        //tách riêng từng port
                        string port1 = rcvData.Split(':')[0];
                        string port2 = rcvData.Split(':')[1];
                        //nếu lúc đầu mảng rỗng thì tạo ra 1 cặp key value 
                        if (listClientToClient.Count == 0)
                        {
                            // tiến hành thêm client đầu tiên vào list
                            ClientToCLient.Add(client);
                            listClientToClient.Add(rcvData, ClientToCLient);
                        }
                        else
                        {
                            Hashtable hashTemp = new Hashtable();
                            bool check = false;
                            //lặp qua từng cặp key-value trong hashtable để tìm dữ liệu
                            foreach (string port in listClientToClient.Keys)
                            {
                                //Nếu cặp key-value vào chứa đồng thời cả 2 port này thì tiến hành push vào list
                                if (port.Contains(port1) && port.Contains(port2))
                                {
                                    ClientToCLient.Add(client);
                                    // là kiểu dữ liệu cho phép copy mà không ảnh hưởng khi xóa giá trị gán
                                    List<TcpClient> listTemp = ClientToCLient.ToList();
                                    //tiến hành cập nhật lại list
                                    hashTemp.Add(port, listTemp);
                                    check = true;
                                }
                                else hashTemp.Add(port, listClientToClient[port]);
                            }
                            listClientToClient = hashTemp;
                            //Nếu lặp hết hash mà không có dữ liệu phù hợp thì thêm 1 cặp key-value mới
                            if (!check)
                            {
                                // tiến hành thêm client này vào list
                                ClientToCLient.Add(client);
                                listClientToClient.Add(rcvData, ClientToCLient);
                            }
                        }
                        ////nếu trong list đã có 2 phần tử thì tiến hành reset list
                        if (ClientToCLient.Count == 2) ClientToCLient.Clear();
                        //sau khi đã có các cặp key value thì ta tiến hành tạo luồng dữ liệu để chat
                        foreach (string port in listClientToClient.Keys)
                        {
                            List<TcpClient> countEle = (List<TcpClient>)listClientToClient[port];
                            if (countEle.Count == 2)
                            {
                                if (!hashThread.Contains(port))
                                {
                                    Thread newThread = new Thread(new ParameterizedThreadStart(threadForClientToClient));
                                    newThread.Start(port);
                                    hashThread.Add(port, newThread);
                                }
                            }
                        }
                    }
                    else
                    {

                        writeData(rcvData);
                        //// phần này dành cho việc chat tổng quát giữa các client
                        //đây là dữ liệu nhận được sau khi connect tới server
                        sendDataFromServerToClient(client, rcvData);
                        int getPort = UserListInfo.list[index].port;
                        //khi 1 người dùng tham gia vào danh sách thì index sẽ tăng lên 1
                        index++;
                        listClients.Add(getPort, client);
                        threadRcvData = new Thread(new ParameterizedThreadStart(handleRcvDataClientToServer));
                        threadRcvData.Start(getPort);

                        containsThreadMultiClients.Add(getPort, threadRcvData);
                    }
                }
                catch (Exception ex)
                {
                    server.Stop();
                    threadClientToServer.Abort();
                }
            }
        }
        private void handleRcvDataClientToServer(object port)
        {
            int portClient = (int)port;
            TcpClient currentClient = (TcpClient)listClients[portClient];

            while (true)
            {
                try
                {
                    stream = currentClient.GetStream();
                    byte[] rcvData1 = new byte[1024];
                    int length = stream.Read(rcvData1, 0, rcvData1.Length);
                    if (length == 0)
                    {
                        containsThreadMultiClients.Remove(portClient);
                        handleOutRoom(currentClient, portClient);
                    }
                    string data = Encoding.UTF8.GetString(rcvData1, 0, length);
                    writeData(data);
                    sendDataFromServerToClient(currentClient, data);
                    Array.Clear(rcvData1, 0, rcvData1.Length);
                }
                catch (Exception ex)
                {
                    server.Stop();
                    threadRcvData.Abort();
                }
            }
        }
        private void handleOutRoom(TcpClient currentClient, int portClient)
        {
            string userName = "";
            //lặp qua danh sách để lấy ra username
            foreach (UserInfo user in UserListInfo.list)
            {
                if (user.port == portClient)
                {
                    userName = user.userName;
                    break;
                }
            }
            //khi 1 người dùng thoát ra khỏi danh sách thì index sẽ giảm đi 1
            index--;
            string dataOutRoom = $"{userName} đã rời phòng chat!!!";
            writeData(dataOutRoom);
            sendDataFromServerToClient(currentClient, dataOutRoom);
            //lặp qua các luồng để tìm đúng luồng thread của client đó
            foreach (int key in containsThreadMultiClients.Keys)
            {
                if (key == portClient)
                {
                    //tiến hành lấy ra thread đó
                    Thread thread = (Thread)containsThreadMultiClients[key];
                    thread.Abort();
                    containsThreadMultiClients.Remove(key);
                }
            }
            listClients.Remove(portClient);
            threadChatServer();
        }

        private void sendDataFromServerToClient(TcpClient currentClient, string data)
        {
            foreach (TcpClient cl in listClients.Values)
            {
                if (cl != currentClient)
                {
                    byte[] sendingData = Encoding.UTF8.GetBytes(data);
                    NetworkStream newStream = cl.GetStream();
                    newStream.Write(sendingData, 0, sendingData.Length);
                }
            }
        }
        //luồng chat giữa client - client dùng để tạo ra các luồng thread cho từng cặp client riêng biệt
        private void threadForClientToClient(object port)
        {
            //chứa danh sách cặp port của 2 client có dạng (1922:1078)
            string ports = (string)port;
            int sourcePort = 0;
            //list chứa danh sách 2 client tương ứng với port nhận được
            List<TcpClient> listClients = (List<TcpClient>)listClientToClient[ports];
            TcpClient difClient = null;
            //tạo từng luồng gửi nhận dữ liệu riêng biệt
            foreach (TcpClient client in listClients)
            {
                int count = 0;
                foreach (TcpClient client1 in listClients)
                {
                    //lấy ra port tương ứng cho client cần chat (dùng để lấy tên username và gửi về client còn lại)
                    if (client == client1)
                    {
                        sourcePort = int.Parse(ports.Split(':')[count]);
                    }
                    else difClient = client1; //lấy ra client còn lại dùng để gửi dữ liệu
                    count++;

                }
                //tạo ra luồng dữ liệu cho từng cặp client
                Thread thread = new Thread(new ParameterizedThreadStart(handleRcvDataClientToClient));
                //tham số nhận được là client hiện tại và tham số thứ 2 là client gửi đi
                thread.Start(new object[] { sourcePort, client, difClient });
                threadChatBetweenClients.Add(thread);

            }

        }
        //luồng chat giữa client - client dùng để gửi nhận dữ liệu mà client gửi tới
        private void handleRcvDataClientToClient(object client)
        {
            byte[] rcvData = new byte[1024];
            object[] clients = (object[])client;
            int sourcePort = (int)clients[0];
            TcpClient currentClient = (TcpClient)clients[1];
            TcpClient difClient = (TcpClient)clients[2];
            while (true)
            {
                try
                {
                    NetworkStream stream = currentClient.GetStream();
                    int length = stream.Read(rcvData, 0, rcvData.Length);
                    //dữ liệu đã nhận được
                    string data = Encoding.UTF8.GetString(rcvData, 0, length);

                    if (data.Contains("#$KcZ@"))
                    {
                        byte[] sendData1 = Encoding.UTF8.GetBytes(data);
                        NetworkStream network = difClient.GetStream();
                        string getKey = data.Substring(0, data.Length - 6);
                        writeData($"Khóa công khai của {UserListInfo.list[UserListInfo.getUser(sourcePort)].userName}: {getKey}");
                        network.Write(sendData1, 0, sendData1.Length);
                    }
                    else
                    {
                        writeData($"{UserListInfo.list[UserListInfo.getUser(sourcePort)].userName}: {Convert.ToBase64String(rcvData, 0, length)}");
                        sendDataClientToClient(difClient, Convert.ToBase64String(rcvData, 0, length));
                    }
                    Array.Clear(rcvData, 0, rcvData.Length);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        //Hàm chat giữa client - client dùng để gửi dữ liệu đến client còn lại
        //đã kiểm tra
        private void sendDataClientToClient(TcpClient client, string data)
        {
            byte[] sendData = Convert.FromBase64String(data);

            NetworkStream network = client.GetStream();
            network.Write(sendData, 0, sendData.Length);
            Array.Clear(sendData, 0, sendData.Length);
        }
        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            //đóng các kết nối tcpclient
            if (client != null)
                foreach (TcpClient client in listClients.Values)
                    client.Close();
            if (listClientToClient != null)
                foreach (List<TcpClient> clients in listClientToClient.Values)
                    foreach (TcpClient cl in clients) cl.Close();
            if (listClientToClient != null) listClientToClient.Clear();
            if (listClients != null) listClients.Clear();
            //đóng các thread của từng việc nhận dữ liệu của mỗi client
            foreach (Thread thread in threadChatBetweenClients)
                thread.Abort();
            threadChatBetweenClients.Clear();

            //đóng các thread của từng client trong việc chat multi clients
            foreach (Thread thread in containsThreadMultiClients.Values)
                thread.Abort();
            containsThreadMultiClients.Clear();

            //đóng các thread của từng cặp chat client với nhau 
            if (hashThread != null)
            {
                foreach (Thread thread in hashThread.Values)
                    thread.Abort();
                hashThread.Clear();
            }
            //ngắt kết nối server
            if (server != null) server.Stop();
            //đóng luồng thread chính (không tính main)
            if (threadClientToServer != null) threadClientToServer.Abort();
        }
    }
}
