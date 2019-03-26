using SteamFakePlayer.Manager.Core;
using SteamFakePlayer.Manager.Data;
using SteamFakePlayer.Manager.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public partial class ServerForm : Form
    {
        private ServerData _serverData;
        private ServerCore _serverCore;
        private bool _validated;        

        public ServerForm(ServerData serverdata)
        {
            _serverData = serverdata;
            _serverCore = new ServerCore(serverdata);
            _serverCore.StatsChanged += OnServerStatsChanged;

            InitializeComponent();

            LoadData(serverdata);
        }

        private void OnServerStatsChanged(ServerStats stats)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => OnServerStatsChanged(stats)));
                return;
            }
            lblActiveBots.Text = stats.ActiveBotsCount.ToString();
        }

        private void LoadData(ServerData serverData)
        {
            tbAccounts.Lines = serverData.Bots.Select(p => $"{p.Username}:{p.Password}").ToArray();

            lblLoaded.Text = _serverData.Bots.Count.ToString();
        }

        private void cbShowAccounts_CheckedChanged(object sender, EventArgs e)
        {
            tbAccounts.PasswordChar = ((CheckBox)sender).Checked ? '\0' : '*';
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
                            string[] accountData = account.Split(':');
                            string username = accountData[0];
                            string password = accountData[1];

                            accounts.Add(new BotAccountData() { Username = username, Password = password });
                        }

                        _serverData.Bots = accounts;
                        DataManager.Save();
                        LoadData(_serverData);
                    }
                    catch(IndexOutOfRangeException)
                    {
                        MessageUtils.Error("Файл имеет неверную структуру!");
                    }
                }
            }
        }

        private void btnCheckServerAvailable_Click(object sender, EventArgs e)
        {
            if (_serverData.Bots.Count == 0)
            {
                MessageUtils.Error("Нет аккаунта для проверки сервера!");
                return;
            }

            var checker = new ServerChecker(_serverData.Bots[0], _serverData);
            checker.Callback += OnServerValidatingResult;
            checker.Join();
        }

        private void OnServerValidatingResult(bool success, string data)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(()=> { OnServerValidatingResult(success, data); }));
                return;
            }

            if (!success)
            {
                MessageUtils.Error($"Не удалось установить соединение с сервером!\nОшибка: {data}");
                return;
            }

            _validated = true;
            _serverData.DisplayName = data.Truncate(30);            
            DataManager.Save();
            MessageUtils.Info($"Соединение с {_serverData.DisplayName} успешно установлено!");
        }

        private void btnConnectBots_Click(object sender, EventArgs e)
        {
            if (_validated)
            {
                _serverCore.ConnectBots();
            }
        }

        private void btnDisconnectBots_Click(object sender, EventArgs e)
        {
            if (_validated)
            {
                _serverCore.DisconnectBots();
            }
        }
    }
}
