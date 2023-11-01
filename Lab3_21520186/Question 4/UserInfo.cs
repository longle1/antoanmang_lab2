using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace userInfo
{
    internal class UserInfo
    {
        public string password;
        public string userName;
        public string status;
        public int port;
        public UserInfo(string userName, string password, string status, int port)
        {
            this.userName = userName;
            this.password = password;
            this.status = status;
            this.port = port;
        }
        public bool checkLogin()
        {
            return password.Trim() == "" || userName.Trim() == "";
        }
    }
}
