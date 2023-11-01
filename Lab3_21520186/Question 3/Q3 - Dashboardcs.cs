using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_3
{
    public partial class Q3___Dashboardcs : Form
    {
        public Q3___Dashboardcs()
        {
            InitializeComponent();
        }

        private void btnTCPServer_Click(object sender, EventArgs e)
        {
            Server sv = new Server();
            sv.Show();
        }

        private void btnTCPClient_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
        }
    }
}
