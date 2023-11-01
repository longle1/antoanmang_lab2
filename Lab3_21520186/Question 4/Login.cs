using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using userInfo;
using userListInfo;

namespace Question_4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string userName;
        string password;
        UserInfo uf;
        Client_Server newClient;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            userName = txtUserName.Text;
            password = txtPassword.Text;
            Random rd = new Random();
            int port = rd.Next(1000, 1999);
            uf = new UserInfo(userName, password, "active", port);
            newClient = new Client_Server(uf.userName, uf.password, port);
            if (uf.checkLogin())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi Login", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (UserListInfo.checkInfo(uf) == true)
            {

                MessageBox.Show("Username đã tồn tại, vui lòng chọn 1 username khác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserListInfo.addElement(uf);
            MessageBox.Show("Login thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);



            newClient.Show();
            this.Close();
        }
    }
}
