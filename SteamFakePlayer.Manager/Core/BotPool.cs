using SteamFakePlayer.Manager.Data;
using System.Collections.Generic;
using System.Linq;

namespace SteamFakePlayer.Manager.Core
{
    internal class BotPool
    {
        private Queue<BotPlayer> _bots = new Queue<BotPlayer>();
        public List<BotPlayer> BotsTaked = new List<BotPlayer>();
        public object botsListReference;

        public void Push(BotPlayer player)
        {
            _bots.Enqueue(player);
            BotsTaked.Remove(player);
        }

        public bool Get(out BotPlayer player)
        {
            if (_bots.Count > 0)
            {
                player = _bots.Dequeue();
                BotsTaked.Add(player);
                return true;
            }

            player = null;
            return false;
        }

        public void Setup()
        {
            // If changed then reload
            if (botsListReference != DataManager.Data.Bots)
            {
                botsListReference = DataManager.Data.Bots;

                foreach (var player in BotsTaked)
                {
                    new Timeout(player.DisconnectWithSettingsDelay(), ()=>
                    {
                        _bots.Enqueue(player);
                    });
                }

                BotsTaked.Clear();
                _bots.Clear();

                foreach (var account in DataManager.Data.Bots)
                {
                    var bot = new BotPlayer(account);
                    _bots.Enqueue(bot);
                }
            }
        }
    }
}
