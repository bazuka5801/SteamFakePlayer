using System;
using System.Diagnostics;
using Facepunch;
using Network;
using SapphireEngine;
using Message = RakNet.Network.Message;

namespace RakNet
{
    public class Client : Network.Client
    {
        public const string DemoHeader = "RUST DEMO FORMAT";
        public static float MaxReceiveTime;

        private readonly Stopwatch _cycleTimer = Stopwatch.StartNew();

        private Peer _peer;

        public Action<byte> OnRakNetPacket;


        static Client()
        {
            MaxReceiveTime = 20f;
        }

        public override void Send()
        {
            write.Send(new SendInfo(Connection));
        }


        public override bool Connect(string strUrl, int port)
        {
            base.Connect(strUrl, port);
            _peer = Peer.CreateConnection(strUrl, port, 12, 400, 0);
            if (_peer == null)
            {
                return false;
            }

            write = new StreamWrite(this, _peer);
            read = new StreamRead(this, _peer);
            ConnectedAddress = strUrl;
            ConnectedPort = port;
            ServerName = "";
            Connection = new Connection();
            return true;
        }

        public override void Cycle()
        {
            using (TimeWarning.New("Raknet.Client.Cycle", 0.1f))
            {
                if (IsConnected())
                {
                    _cycleTimer.Reset();
                    _cycleTimer.Start();
                    while (_peer.Receive())
                    {
                        using (TimeWarning.New("HandleMessage", 0.1f))
                        {
                            HandleMessage();
                        }

                        if (_cycleTimer.Elapsed.TotalMilliseconds > MaxReceiveTime)
                        {
                            break;
                        }

                        if (!IsConnected())
                        {
                            break;
                        }
                    }
                }
            }
        }

        public override void Disconnect(string reason, bool sendReasonToServer)
        {
            if (sendReasonToServer && write != null && write.Start())
            {
                write.PacketId(Message.Type.DisconnectReason);
                write.String(reason);
                write.Send(new SendInfo(Connection)
                {
                    method = SendMethod.ReliableUnordered,
                    priority = Priority.Immediate
                });
            }

            if (_peer != null)
            {
                _peer.Close();
                _peer = null;
            }

            write = null;
            read = null;
            ConnectedAddress = "";
            ConnectedPort = 0;
            Connection = null;
            OnDisconnected(reason);
        }


        protected void HandleMessage()
        {
            read.Start(Connection);
            var b = read.PacketId();
            if (HandleRaknetPacket(b))
            {
                return;
            }

            b -= 140;
            if (b > 23)
            {
                ConsoleSystem.LogWarning("Invalid Packet (higher than " + Message.Type.EAC + ")");
                Disconnect(string.Concat("Invalid Packet (", b, ") ", _peer.IncomingBytes, "b"), true);
                return;
            }

            var message = StartMessage((Message.Type) b, Connection);
            if (OnMessage != null)
            {
                try
                {
                    using (TimeWarning.New("onMessage", 0.1f))
                    {
                        OnMessage(message);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleSystem.LogError(ex.Message);
                }
            }

            message.Clear();
            Pool.Free(ref message);
        }


        internal bool HandleRaknetPacket(byte type)
        {
            if (type >= 140)
            {
                return false;
            }

            OnRakNetPacket?.Invoke(type);
            switch (type)
            {
                case 16:
                    ConnectionAccepted = true;
                    if (Connection.guid != 0uL)
                    {
                        ConsoleSystem.Log("Multiple PacketType.CONNECTION_REQUEST_ACCEPTED");
                    }

                    Connection.guid = _peer.IncomingGuid;
                    return true;
                case 17:
                    Disconnect("Connection Attempt Failed", false);
                    return true;
                case 20:
                    Disconnect("Server is Full", false);
                    return true;
                case 21:
                    if (Connection != null && Connection.guid != _peer.IncomingGuid)
                    {
                        return true;
                    }

                    Disconnect(DisconnectReason, false);
                    return true;
                case 22:
                    if (Connection == null && Connection.guid != _peer.IncomingGuid)
                    {
                        return true;
                    }

                    Disconnect("Timed Out", false);
                    return true;
                case 23:
                    if (Connection == null && Connection.guid != _peer.IncomingGuid)
                    {
                        return true;
                    }

                    Disconnect("Connection Banned", false);
                    return true;
            }

            if (Connection != null && _peer.IncomingGuid != Connection.guid)
            {
                ConsoleSystem.LogWarning(string.Concat("[CLIENT] Unhandled Raknet packet ", type,
                    " from unknown source ", _peer.IncomingAddress));
                return true;
            }

            ConsoleSystem.LogWarning("Unhandled Raknet packet " + type);
            return true;
        }

        public override bool IsConnected() => _peer != null;
    }
}