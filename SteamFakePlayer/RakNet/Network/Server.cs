using System;
using System.Collections.Generic;
using Network;
using SapphireEngine;

namespace RakNet.Network
{
    public abstract class Server : NetworkPeer
    {
        private readonly Dictionary<ulong, Connection> _connectionByGuid = new Dictionary<ulong, Connection>();

        public bool CompressionEnabled;

        public List<Connection> Connections = new List<Connection>();


        public bool Debug;
        public string Ip = "";

        internal uint LastValueGiven = 1024;

        public bool Logging;

        public Action<string, Connection> onDisconnected;

        public int Port = 5678;

        public virtual void Cycle()
        {
        }

        public void SetEncryptionLevel(uint level)
        {
            for (var i = 0; i < Connections.Count; i++)
            {
                Connections[i].encryptionLevel = level;
                Connections[i].encryptOutgoing = true;
            }
        }

        protected Connection FindConnection(ulong guid)
        {
            Connection connection;
            if (_connectionByGuid.TryGetValue(guid, out connection))
            {
                return connection;
            }

            return null;
        }


        public abstract bool IsConnected();

        public abstract void Kick(Connection cn, string message);

        protected void OnDisconnected(string strReason, Connection cn)
        {
            if (cn == null)
            {
                return;
            }

            cn.connected = false;
            cn.active = false;
            if (onDisconnected != null)
            {
                onDisconnected(strReason, cn);
            }

            RemoveConnection(cn);
        }

        protected abstract void OnNewConnection();

        protected void OnNewConnection(Connection connection)
        {
            connection.connectionTime = DateTime.Now;
            Connections.Add(connection);
            _connectionByGuid.Add(connection.guid, connection);
        }

        protected void RemoveConnection(Connection connection)
        {
            _connectionByGuid.Remove(connection.guid);
            Connections.Remove(connection);
            connection.OnDisconnected();
        }

        public void Reset()
        {
            ResetUiDs();
        }

        internal void ResetUiDs()
        {
            LastValueGiven = 1024;
        }

        public void ReturnUid(uint uid)
        {
        }

        public abstract void SendUnconnected(uint netAddr, ushort netPort, byte[] steamResponseBuffer, int packetSize);

        public virtual bool Start() => true;

        public virtual void Stop(string shutdownMsg)
        {
        }

        public uint TakeUid()
        {
            if (LastValueGiven > 4294967263u)
            {
                ConsoleSystem.LogError(string.Concat("TakeUID - hitting ceiling limit!", LastValueGiven));
            }

            LastValueGiven++;
            return LastValueGiven;
        }
    }
}