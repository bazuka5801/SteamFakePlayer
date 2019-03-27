using System;
using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public partial class AddServerForm : Form
    {
        private readonly AddServerModel _model;

        public AddServerForm(AddServerModel model)
        {
            _model = model;

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

    public class AddServerModel : DialogModel<AddServerModel, AddServerForm>
    {
        public string IP;
        public int Port;

        public override string ToString() => $"{IP}:{Port}";
    }
}