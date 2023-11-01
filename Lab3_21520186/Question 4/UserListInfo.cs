using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using userInfo;

namespace userListInfo
{
    internal class UserListInfo
    {
        public static bool chatLanOrSinge { get; set; }
        public static List<UserInfo> list = new List<UserInfo>();
        public static void addElement(UserInfo user)
        {
            list.Add(user);
        }
        public static bool checkInfo(UserInfo user)
        {
            foreach (UserInfo item in list)
                if (string.Equals(item.userName.Trim(), user.userName.Trim())) return true;
            return false;
        }
        public static void remove(string username)
        {
            foreach (UserInfo user in list)
            {
                if (string.Equals(user.userName, username))
                {
                    list.Remove(user);
                    break;
                }
            }
        }
        public static bool checkActive()
        {
            foreach (UserInfo user in list)
                if (user.status == "inactive") return false;
            return true;
        }
        public static int getUser(string userName)
        {
            int i = 0;
            foreach (UserInfo user in list)
            {
                if (string.Equals(user.userName, userName)) return i;
                i++;
            }
            return -1;
        }
        public static int getUser(int port)
        {
            int i = 0;
            foreach (UserInfo user in list)
            {
                if (string.Equals(user.port, port)) return i;
                i++;
            }
            return -1;
        }
        public static bool checkExist(string username, string password)
        {
            foreach (UserInfo user in list)
                if (string.Equals(user.userName, username) && string.Equals(password, user.password)) return true;
            return false;
        }
        public static bool checkPassword(string username, string password)
        {
            return list[getUser(username)].password == password;
        }
        public static int getPort(string name)
        {
            foreach (UserInfo user in list) if (name == user.userName) return user.port;
            return -1;
        }
        public static bool checkPortExist(int port)
        {
            foreach (UserInfo user in list) if (port == user.port) return true;
            return false;
        }
        public static string inText()
        {
            string text = "";
            foreach (UserInfo user in list)
            {
                text += "username: " + user.userName + "\t port: " + user.port + "\t";
            }
            text += '\n';
            return text;
        }
    }
    internal class ListClientChatTogether
    {
        public static List<string> list = new List<string>();
        public static bool checkEnable(string username1, string username2)
        {
            foreach (string usernames in list)
                if (usernames.Contains(username1) && usernames.Contains(username2)) return true;
            return false;
        }
    }
}
