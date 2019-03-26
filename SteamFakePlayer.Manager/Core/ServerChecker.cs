using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager.Core
{
    public delegate void ServerCheckerCallback(bool success, string data);

    internal class ServerChecker : PlayerJoiner
    {
        private bool _connected;

        public ServerChecker(BotAccountData account, ServerData server) : base(account, server)
        {
        }

        public event ServerCheckerCallback Callback;

        protected override void OnConnectedToServer(string servername)
        {
            if (Callback != null)
            {
                // Pass servername
                Callback(true, servername);
            }

            _connected = true;
            base.OnConnectedToServer(servername);
        }

        protected override void OnDisconnectedFromServer(string reason)
        {
            if (_connected == false)
            {
                Callback(false, reason);
            }

            base.OnDisconnectedFromServer(reason);
        }

        protected override string GenerateJoinerArguments() =>
            base.GenerateJoinerArguments() + "\"-quit-after-connected\" ";
    }
}