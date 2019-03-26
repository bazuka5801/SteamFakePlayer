using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager.Core
{
    internal class BotPlayer : PlayerJoiner
    {
        public BotPlayer(BotAccountData account, ServerData server) : base(account, server)
        {
        }

        protected override void OnConnectedToServer(string servername)
        {
            base.OnConnectedToServer(servername);
        }

        protected override void OnDisconnectedFromServer(string reason)
        {
            base.OnDisconnectedFromServer(reason);
        }
    }
}