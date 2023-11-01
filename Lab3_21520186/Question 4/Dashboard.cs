using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_4
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server sv = new Server();
            sv.Show();  
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void btnServerLan_Click(object sender, EventArgs e)
        {
            ServerLan svLan = new ServerLan();
            svLan.Show();
        }
    }
}
