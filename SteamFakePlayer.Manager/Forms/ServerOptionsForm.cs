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
    public partial class ServerOptionsForm : Form
    {
        private ServerOptionsModel _model;

        public ServerOptionsForm(ServerOptionsModel model)
        {
            _model = model;

            InitializeComponent();

            LoadModel(model);
        }

        private void LoadModel(ServerOptionsModel model)
        {
            tbIP.Text = model.IP;
            tbPort.Text = model.Port.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void btnBotOptions_Click(object sender, EventArgs e)
        {
            BotOptionsModel.TryGetModel(_model.BotOptions);
        }
    }

    public class ServerOptionsModel : DialogModel<ServerOptionsModel, ServerOptionsForm>
    {
        public string IP;
        public int Port;

        public BotOptionsModel BotOptions = new BotOptionsModel();
    }
}
