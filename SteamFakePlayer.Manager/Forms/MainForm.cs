using System.Diagnostics;
using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            new ServerForm().Show();
        }

        private void llRustyCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://vk.com/rustycode");
        }

        private void btnAddServer_Click(object sender, System.EventArgs e)
        {
            var model = new AddServerModel();
            var form = new AddServerForm(model);
            form.ShowDialog();
            form.Dispose();
            if (model.Success)
            {
                lbServers.Items.Add(model.ToString());
            }
        }

        private void btnDeleteServer_Click(object sender, System.EventArgs e)
        {
            if (lbServers.SelectedIndex == -1)
            {
                MessageUtils.Error("Ничего не выбрано!");
            }

            lbServers.Items.RemoveAt(lbServers.SelectedIndex);
        }
    }
}
