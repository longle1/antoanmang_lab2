using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_1
{
    public partial class Q1_Dashboard : Form
    {
        public Q1_Dashboard()
        {
            InitializeComponent();
        }

        private void UDPServer_Click(object sender, EventArgs e)
        {
            Q1_Server UDPServer = new Q1_Server();
            UDPServer.Show();
        }

        private void UDPClient_Click(object sender, EventArgs e)
        {
            Q1_Client UDPClient = new Q1_Client();
            UDPClient.Show();
        }
    }
}
