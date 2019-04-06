using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SteamFakePlayer.Manager.Core;
using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager
{
    public partial class MainForm : Form
    {
        private BotSpreader _spreader = new BotSpreader();

        public MainForm()
        {
            CheckJoinerFile();

            InitializeComponent();

            DataManager.DataChanged += OnDataChanged;
            LoadData(DataManager.Data);
        }

        private void OnDataChanged(ManagerData data)
        {
            LoadData(data);
        }

        private void LoadData(ManagerData data)
        {
            lbServers.Items.Clear();
            foreach (var server in data.Servers)
            {
                lbServers.Items.Add(
                    string.IsNullOrEmpty(server.DisplayName)
                        ? $"<{server.ImportantIndex}> {server.IP}:{server.Port}"
                        : $"<{server.ImportantIndex}> {server.DisplayName} [{server.IP}:{server.Port}]"
                );
            }

            tbAccounts.Lines = data.Bots.Select(p => $"{p.Username}:{p.Password}").ToArray();
            lblLoaded.Text = data.Bots.Count.ToString();
            _spreader.OnDataChanged();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            var index = lbServers.SelectedIndex;
            if (index == -1)
            {
                MessageUtils.Error("Ничего не выбрано!");
                return;
            }

            var serverData = DataManager.Data.Servers[index];
            new ServerForm(_spreader.GetServerByData(serverData)).Show();
        }

        private void llRustyCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://vk.com/rustycode");
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            if (AddServerModel.TryGetModel(out var model))
            {
                var serverData = new ServerData
                {
                    IP = model.IP,
                    Port = model.Port
                };
                DataManager.Data.Servers.Add(serverData);
                DataManager.Save();
                LoadData(DataManager.Data);
            }
        }

        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            if (lbServers.SelectedIndex == -1)
            {
                MessageUtils.Error("Ничего не выбрано!");
                return;
            }

            if (MessageUtils.Confirm($"Вы действительно хотите удалить {lbServers.Items[lbServers.SelectedIndex]}"))
            {
                var serverData = DataManager.Data.Servers[lbServers.SelectedIndex];
                DataManager.Data.Servers.Remove(serverData);
                DataManager.Save();
                LoadData(DataManager.Data);

                _spreader.RemoveServerByData(serverData);
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

        private void btnLoadAccountsFile_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                fileDialog.Filter = "txt files(*.txt) | *.txt";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var accounts = new List<BotAccountData>();
                        var lines = File.ReadAllLines(fileDialog.FileName);

                        if (lines.Length == 0)
                        {
                            MessageUtils.Error("Файл пустой!");
                            return;
                        }

                        foreach (var account in lines)
                        {
                            var accountData = account.Split(':');
                            var username = accountData[0];
                            var password = accountData[1];

                            accounts.Add(new BotAccountData { Username = username, Password = password });
                        }

                        DataManager.Data.Bots = accounts;
                        _spreader.OnDataChanged();
                        DataManager.Save();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageUtils.Error("Файл имеет неверную структуру!");
                    }
                }
            }
        }

        private void cbShowAccounts_CheckedChanged(object sender, EventArgs e)
        {
            tbAccounts.PasswordChar = ((CheckBox)sender).Checked ? '\0' : '*';
        }

        private void btnBotOptions_Click(object sender, EventArgs e)
        {
            var model = new BotOptionsModel()
            {
                EnterMin = DataManager.Data.BotOptions.EnterMin,
                EnterMax = DataManager.Data.BotOptions.EnterMax,
                ExitMin = DataManager.Data.BotOptions.ExitMin,
                ExitMax = DataManager.Data.BotOptions.ExitMax,
                ReconnectMin = DataManager.Data.BotOptions.ReconnectMin,
                ReconnectMax = DataManager.Data.BotOptions.ReconnectMax,
            };

            if (BotOptionsModel.TryGetModel(model))
            {
                DataManager.Data.BotOptions.EnterMin = model.EnterMin;
                DataManager.Data.BotOptions.EnterMax = model.EnterMax;
                DataManager.Data.BotOptions.ExitMin = model.ExitMin;
                DataManager.Data.BotOptions.ExitMax = model.ExitMax;
                DataManager.Data.BotOptions.ReconnectMin = model.ReconnectMin;
                DataManager.Data.BotOptions.ReconnectMax = model.ReconnectMax;

                DataManager.Save();
            }
        }

        private void btnConnectBots_Click(object sender, EventArgs e)
        {
            _spreader.Run();
        }

        private void btnDisconnectBots_Click(object sender, EventArgs e)
        {
            _spreader.Stop();
        }
    }
}