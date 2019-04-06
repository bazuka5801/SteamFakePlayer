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

    internal class ServerCore
    {
        private readonly ServerStats _serverStats;

        public readonly List<BotPlayer> Players = new List<BotPlayer>();

        public ServerData Data { get; }        

        public bool IsFull;

        public void StartSleeping()
        {
            IsFull = true;
            new Timeout(60000, () =>
            {
                IsFull = false;
            });
        }

        public ServerCore(ServerData serverData)
        {
            Data = serverData;
            _serverStats = new ServerStats();
        }

        public bool IsRunning { get; private set; }

        public event ServerStatsChanged StatsChanged;

        public int AddPlayer(BotPlayer player)
        {
            Players.Add(player);
            player.SetServer(this);
            return player.ConnectWithSettingsDelay();
        }

        public int RemovePlayer(BotPlayer player)
        {
            Players.Remove(player);
            return player.DisconnectWithSettingsDelay();
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

        internal void ForEach(Action<BotPlayer> action) => Players.ForEach(action);

        internal bool ConnectBots()
        {
            if (IsRunning == false)
            {
                IsRunning = true;

                ForEach(bot => bot.ConnectWithSettingsDelay());
                return true;
            }

            return false;
        }

        internal bool DisconnectBots()
        {
            if (IsRunning)
            {
                IsRunning = false;

                ForEach((bot) => bot.DisconnectWithSettingsDelay());
                return true;
            }

            return false;
        }
    }
}