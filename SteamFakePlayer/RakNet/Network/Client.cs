using System;
using Network;

namespace RakNet.Network
{
    public abstract class Client : NetworkPeer
    {
        public string ConnectedAddress = "unset";

        public int ConnectedPort;
        public string DisconnectReason;

        public bool IsOfficialServer;

        public Action<string> onDisconnected;

        public string ServerName;


        public Connection Connection { get; protected set; }

        public bool ConnectionAccepted { get; protected set; }

        public virtual bool Connect(string strUrl, int port)
        {
            ConnectionAccepted = false;
            DisconnectReason = "Disconnected";
            return true;
        }

        public abstract void Cycle();

        public abstract void Disconnect(string reason, bool sendReasonToServer = true);


        public abstract bool IsConnected();

        protected void OnDisconnected(string str)
        {
            if (onDisconnected != null)
            {
                onDisconnected(str);
            }
        }
    }
}