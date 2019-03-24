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
    public class AddServerModel : DialogModel
    {
        public string IP;
        public int Port;
    }
    public partial class AddServerForm : Form
    {
        private AddServerModel _model;

        public AddServerForm(AddServerModel model)
        {
            this._model = model;

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIP.Text))
            {
                MessageBox.Show("IP пустой!");
                return;
            }

            if (string.IsNullOrEmpty(tbPort.Text))
            {
                MessageBox.Show("Port пустой!");
                return;
            }

            if (int.TryParse(tbPort.Text, out var port) == false)
            {
                MessageBox.Show("Port не является числом!");
                return;
            }

            _model.IP = tbIP.Text;
            _model.Port = port;
            _model.Success = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
