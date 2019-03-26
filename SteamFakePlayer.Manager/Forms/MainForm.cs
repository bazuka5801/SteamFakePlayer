using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            CheckJoinerFile();

            InitializeComponent();

            LoadData(DataManager.Data);
        }

        private void LoadData(ManagerData data)
        {
            lbServers.Items.Clear();
            foreach (var server in data.Servers)
            {
                lbServers.Items.Add(
                    string.IsNullOrEmpty(server.DisplayName)
                        ? $"{server.IP}:{server.Port}"
                        : $"{server.DisplayName} [{server.IP}:{server.Port}]"
                );
            }
        }

        private void btnOpenServer_Click(object sender, System.EventArgs e)
        {
            int index = lbServers.SelectedIndex;
            if (index == -1)
            {
                MessageUtils.Error("Ничего не выбрано!");
                return;
            }

            ServerData serverData = DataManager.Data.Servers[index];
            new ServerForm(serverData).Show();
        }

        private void llRustyCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://vk.com/rustycode");
        }

        private void btnAddServer_Click(object sender, System.EventArgs e)
        {
            if (AddServerModel.TryGetModel(out var model))
            {
                DataManager.Data.Servers.Add(new ServerData()
                {
                    IP = model.IP,
                    Port = model.Port
                });
                DataManager.Save();
                LoadData(DataManager.Data);
            }
        }

        private void btnDeleteServer_Click(object sender, System.EventArgs e)
        {
            if (lbServers.SelectedIndex == -1)
            {
                MessageUtils.Error("Ничего не выбрано!");
                return;
            }

            if (MessageUtils.Confirm($"Вы действительно хотите удалить {lbServers.Items[lbServers.SelectedIndex]}"))
            {
                DataManager.Data.Servers.RemoveAt(lbServers.SelectedIndex);
                DataManager.Save();
                LoadData(DataManager.Data);
            }
        }

        private void CheckJoinerFile()
        {
            var joinerFile = DataManager.Data.JoinerFile;
            if (string.IsNullOrEmpty(joinerFile) || File.Exists(joinerFile) == false)
            {
                MessageUtils.Info("Выберите файл SteamFakePlayer.exe");
                SelectJoinerPath();
            }
        }

        private void menuStripSettingsJoinerPath_Click(object sender, EventArgs e)
        {
            SelectJoinerPath();
        }

        private void SelectJoinerPath()
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                fileDialog.Filter = "exe files (*.exe) | *.exe";

                if (fileDialog.ShowDialog() != DialogResult.OK)
                {
                    Process.GetCurrentProcess().Kill();
                    return;
                }

                DataManager.Data.JoinerFile = fileDialog.FileName;
                DataManager.Save();

                MessageUtils.Info("Расположение файла успешно сохранено!");
            }
        }
    }
}
