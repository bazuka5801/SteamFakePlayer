using System;
using System.Windows.Forms;
using SteamFakePlayer.Manager.Core;
using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager
{
    internal partial class ServerForm : Form
    {
        private readonly ServerCore _server;

        public ServerForm(ServerCore server)
        {
            _server = server;
            server.StatsChanged += OnServerStatsChanged;

            InitializeComponent();

            DataManager.DataChanged += OnDataChanged;
            LoadData(_server.Data);
        }

        private void OnDataChanged(ManagerData data)
        {
            // Local because ref did'nt changed
            LoadData(_server.Data);
        }

        private void OnServerStatsChanged(ServerStats stats)
        {
            if (InvokeRequired)
            {
                Invoke((Action) (() => OnServerStatsChanged(stats)));
                return;
            }

            lblActiveBots.Text = stats.ActiveBotsCount.ToString();
        }

        private void LoadData(ServerData serverData)
        {
            Text = $"{serverData.DisplayName} [{serverData.IP}:{serverData.Port}]";
        }

        private void btnConnectBots_Click(object sender, EventArgs e)
        {
            if (_server.ConnectBots() == false)
            {
                MessageUtils.Error("Стадо уже играет!");
            }
        }

        private void btnDisconnectBots_Click(object sender, EventArgs e)
        {
            if (_server.DisconnectBots() == false)
            {
                MessageUtils.Error("Стадо уже спит!");
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var model = new ServerOptionsModel
            {
                IP = _server.Data.IP,
                Port = _server.Data.Port
            };

            if (ServerOptionsModel.TryGetModel(model))
            {
                _server.Data.IP = model.IP;
                _server.Data.Port = model.Port;
                
                DataManager.Save();
            }
        }
    }
}