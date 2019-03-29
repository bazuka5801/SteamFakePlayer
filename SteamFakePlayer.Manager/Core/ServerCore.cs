using System;
using System.Collections.Generic;
using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager.Core
{
    public class ServerStats
    {
        public int ActiveBotsCount;
    }

    public delegate void ServerStatsChanged(ServerStats stats);

    public class ServerCore
    {
        private readonly List<Timeout> _enterTimeouts = new List<Timeout>();
        private readonly List<Timeout> _exitTimeouts = new List<Timeout>();
        private readonly List<BotPlayer> _players = new List<BotPlayer>();
        private readonly ServerData _serverData;
        private readonly ServerStats _serverStats;

        public ServerCore(ServerData serverData)
        {
            _serverData = serverData;
            _serverStats = new ServerStats();

            SetupPlayers();
        }

        public bool IsRunning { get; private set; }

        public event ServerStatsChanged StatsChanged;

        public void SetupPlayers()
        {
            foreach (var account in _serverData.Bots)
            {
                var bot = new BotPlayer(account, _serverData);
                bot.StateChanged += OnBot_StateChanged;
                _players.Add(bot);
            }
        }

        private void OnBot_StateChanged(ConnectionState state)
        {
            if (state == ConnectionState.Disconnected)
            {
                _serverStats.ActiveBotsCount--;
                StatsChanged?.Invoke(_serverStats);
            }
            else if (state == ConnectionState.Playing)
            {
                _serverStats.ActiveBotsCount++;
                StatsChanged?.Invoke(_serverStats);
            }
        }

        internal void ForEach(Action<BotPlayer> action) => _players.ForEach(action);

        internal bool ConnectBots()
        {
            if (IsRunning == false)
            {
                IsRunning = true;

                _exitTimeouts.ForEach(p => p.Stop());
                _exitTimeouts.Clear();

                ForEach(bot =>
                {
                    var delay = 1000 * Rand.Int32(_serverData.BotOptions.EnterMin, _serverData.BotOptions.EnterMax);
                    Console.WriteLine($"Enter delay for {bot.Account.Username}: {delay}");
                    _enterTimeouts.Add(new Timeout(delay, bot.Join));
                });
                return true;
            }

            return false;
        }

        internal bool DisconnectBots()
        {
            if (IsRunning)
            {
                IsRunning = false;

                _enterTimeouts.ForEach(p => p.Stop());
                _enterTimeouts.Clear();

                ForEach(bot =>
                {
                    var delay = 1000 * Rand.Int32(_serverData.BotOptions.ExitMin, _serverData.BotOptions.ExitMax);
                    Console.WriteLine($"Exit delay for {bot.Account.Username}: {delay}");
                    _exitTimeouts.Add(new Timeout(delay, bot.Disconnect));
                });
                return true;
            }

            return false;
        }
    }
}