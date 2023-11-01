using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using userListInfo;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Question_4
{
    public partial class Client_Client : Form
    {
        private string username;
        private int sourcePort;
        private int destinationPort;
        private TcpClient client = null;
        private NetworkStream stream = null;
        private Thread threadRcvDataFromDifClient = null;
        private byte[] publicKey = null;
        private byte[] privateKey = null;
        private byte[] publicDifKey = null;
        private byte[] sharedKey = null;
        ECDiffieHellmanCng dh = null;
        public Client_Client()
        {
            InitializeComponent();
            Client_contents.ReadOnly = true;
            CheckForIllegalCrossThreadCalls = false;
        }

        public Client_Client(string username, int SourcePort, int destinationPort, string text) : this()
        {
            try
            {
                this.username = username;
                this.sourcePort = SourcePort;
                this.destinationPort = destinationPort;
                this.Text = username;
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
               
                byte[] sendingData = new byte[1024];
                stream = client.GetStream();
                sendingData = Encoding.UTF8.GetBytes(text);
                stream.Write(sendingData, 0, sendingData.Length);
                dh = new ECDiffieHellmanCng();
                // Tạo khóa riêng và khóa công khai cho Client còn lại
                publicKey = dh.PublicKey.ToByteArray();
                privateKey = dh.Key.Export(CngKeyBlobFormat.EccPrivateBlob);



                threadRcvDataFromDifClient = new Thread(new ThreadStart(receivingDataToClient));
                threadRcvDataFromDifClient.Start();
            }
            catch (Exception ex)
            {
                ListClientChatTogether.list.Clear();
                this.Close();
                MessageBox.Show("Kết nối tới server thất bại, vui lòng thực hiện lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
        }
        private void writeData(string msg)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { Client_contents.Text += msg + Environment.NewLine; });
            this.Invoke(invoker);
        }
        private void receivingDataToClient()
        {
            while (true)
            {
                //nhận dữ liệu từ server

                byte[] receivingData = new byte[1024];

                int length = stream.Read(receivingData, 0, receivingData.Length);
                if (length == 0)
                {
                    client.Close();

                    threadRcvDataFromDifClient.Abort();

                    break;

                }
                string data = null;
                if (sharedKey == null)
                {
                    data = Encoding.UTF8.GetString(receivingData, 0, length);
                }else
                {
                    string encrypData = DecryptData(Convert.ToBase64String(receivingData, 0, length), sharedKey);

                    writeData($"{UserListInfo.list[UserListInfo.getUser(destinationPort)].userName} : {encrypData}");
                }
                if(data != null)
                {
                    if (data.Contains("#$KcZ@"))
                    {
                        string getPublicKey = data.Substring(0, data.Length - 6);

                        //chuyên đổi về dạng byte
                        publicDifKey = Convert.FromBase64String(getPublicKey);
                        //Tính toán khóa chung từ khóa riêng của Client và khóa công khai của Client còn lại

                        sharedKey = ConvertTo64BitKey(GenerateSharedKey(privateKey, publicDifKey));
                        string user1 = UserListInfo.list[UserListInfo.getUser(destinationPort)].userName;
                        string user2 = UserListInfo.list[UserListInfo.getUser(sourcePort)].userName;


                        writeData($"Khóa chia sẻ chung giữa {user1} và {user2} là: " + Convert.ToBase64String(sharedKey) + $"Có độ dài {sharedKey.Length} byte");
                    }
                }
            }
        }
        private void btnSendDif_Click(object sender, EventArgs e)
        {
            //gửi dữ liệu lên server
            byte[] sendingData = new byte[1024];
            stream = client.GetStream();
            sendingData = Encoding.UTF8.GetBytes(Convert.ToBase64String(publicKey) + "#$KcZ@");
            stream.Write(sendingData, 0, sendingData.Length);
            txtSendMessage.Clear();

            btnSendDif.Enabled = false;
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtSendMessage.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống, vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //gửi dữ liệu lên server
            stream = client.GetStream();
            string encryptionData = EncryptData(txtSendMessage.Text, sharedKey);
            byte[] encrypt = Convert.FromBase64String(encryptionData);
            stream.Write(encrypt, 0, encrypt.Length);
            Client_contents.Text += $"--->Me: {txtSendMessage.Text}\n";
            writeData("++++++++Chuỗi sau khi mã hóa: " + encryptionData);
            txtSendMessage.Clear();

        }

        private void Client_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
            if (threadRcvDataFromDifClient != null) threadRcvDataFromDifClient.Abort();
        }


        public string EncryptData(string text, byte[] key)
        {
            byte[] encryptedBytes;
            using (DES desAlg = DES.Create())
            {
                desAlg.Key = key;
                desAlg.Mode = CipherMode.ECB;
                desAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = desAlg.CreateEncryptor();

                byte[] textBytes = Encoding.UTF8.GetBytes(text);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(textBytes, 0, textBytes.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public string DecryptData(string encryptedText, byte[] key)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            string decryptedText = "";
            using (DES desAlg = DES.Create())
            {
                desAlg.Key = key;
                desAlg.Mode = CipherMode.ECB;
                desAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = desAlg.CreateDecryptor();

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[encryptedBytes.Length];
                        int decryptedByteCount = csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);
                        decryptedText = Encoding.UTF8.GetString(decryptedBytes, 0, decryptedByteCount);
                    }
                }
            }

            return decryptedText;
        }
        public byte[] ConvertTo64BitKey(byte[] sharedKey)
        {
            byte[] convertedKey = new byte[8];
            Buffer.BlockCopy(sharedKey, 0, convertedKey, 0, 8);
            return convertedKey;
        }



        public static byte[] GenerateSharedKey(byte[] privateKeyBytes, byte[] publicKeyBytes)
        {
            using (CngKey privateKey = CngKey.Import(privateKeyBytes, CngKeyBlobFormat.EccPrivateBlob))
            using (ECDiffieHellmanCng dh = new ECDiffieHellmanCng(privateKey))
            {
                // Khôi phục khóa công khai từ dạng byte
                CngKey publicKey = CngKey.Import(publicKeyBytes, CngKeyBlobFormat.EccPublicBlob);

                // Tính toán khóa chia sẻ chung
                byte[] sharedKey = dh.DeriveKeyMaterial(publicKey);

                return sharedKey;
            }
        }
    }
}
