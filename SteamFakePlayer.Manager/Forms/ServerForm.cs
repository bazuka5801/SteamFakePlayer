using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void cbShowAccounts_CheckedChanged(object sender, EventArgs e)
        {
            tbAccounts.PasswordChar = ((CheckBox)sender).Checked ? '\0' : '*';
        }
    }
}
