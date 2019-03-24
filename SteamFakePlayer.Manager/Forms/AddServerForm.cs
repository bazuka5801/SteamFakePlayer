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
                MessageUtils.Error("IP пустой!");
                return;
            }

            if (string.IsNullOrEmpty(tbPort.Text))
            {
                MessageUtils.Error("Port пустой!");
                return;
            }

            if (int.TryParse(tbPort.Text, out var port) == false)
            {
                MessageUtils.Error("Port не является числом!");
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

    public class AddServerModel : DialogModel
    {
        public string IP;
        public int Port;

        public override string ToString()
        {
            return $"{IP}:{Port}";
        }
    }
}
