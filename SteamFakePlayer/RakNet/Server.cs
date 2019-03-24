using System;
using System.Diagnostics;
using Facepunch;
using Network;
using SapphireEngine;
using Message = RakNet.Network.Message;

namespace RakNet
{
    public class Server : Network.Server
    {
        public static float MaxReceiveTime;

        public static ulong MaxPacketsPerSecond;

        private Peer _peer;

        public Action<Connection> OnNewConnectionCallback;

        public Action<byte> OnRakNetPacket;

        static Server()
        {
            MaxReceiveTime = 20f;
            MaxPacketsPerSecond = 1500;
        }

        internal void ConnectedPacket(Connection connection)
        {
            if (connection.GetPacketsPerSecond(0) >= MaxPacketsPerSecond)
            {
                Kick(connection, "Kicked: Packet Flooding");
                ConsoleSystem.LogWarning(string.Concat(connection.ToString(), " was kicked for packet flooding"));
                return;
            }

            connection.AddPacketsPerSecond(0);
            read.Start(connection);
            var num = read.PacketId();
            if (HandleRaknetPacket(num, connection))
            {
                return;
            }

            num = (byte) (num - 140);
            var message = StartMessage((Message.Type) num, connection);
            if (OnMessage != null)
            {
                OnMessage(message);
            }

            message.Clear();
            Pool.Free(ref message);
        }

        public override void Cycle()
        {
            base.Cycle();
            if (!IsConnected())
            {
                return;
            }

            var stopwatch = Pool.Get<Stopwatch>();
            stopwatch.Reset();
            stopwatch.Start();
            do
            {
                if (!_peer.Receive())
                {
                    break;
                }

                var connection = FindConnection(_peer.IncomingGuid);
                if (connection != null)
                {
                    using (var timeWarning = TimeWarning.New("ConnectedPacket", 20))
                    {
                        ConnectedPacket(connection);
                    }
                }
                else
                {
                    using (var timeWarning = TimeWarning.New("UnconnectedPacket", 20))
                    {
                        UnconnectedPacket();
                    }
                }
            } while (stopwatch.Elapsed.TotalMilliseconds <= MaxReceiveTime);

            Pool.Free(ref stopwatch);
        }


        internal bool HandleRaknetPacket(byte type, Connection connection)
        {
            if (type >= 140)
            {
                return false;
            }

            OnRakNetPacket?.Invoke(type);
            switch (type)
            {
                case 19:
                {
                    using (var timeWarning = TimeWarning.New("OnNewConnection", 20))
                    {
                        OnNewConnection();
                    }

                    return true;
                }
                case 20:
                {
                    return true;
                }
                case 21:
                {
                    if (connection != null)
                    {
                        using (var timeWarning = TimeWarning.New("OnDisconnected", 20))
                        {
                            OnDisconnected("Disconnected", connection);
                        }
                    }

                    return true;
                }
                case 22:
                {
                    if (connection != null)
                    {
                        using (var timeWarning = TimeWarning.New("OnDisconnected (timed out)", 20))
                        {
                            OnDisconnected("Timed Out", connection);
                        }
                    }

                    return true;
                }
                default:
                {
                    return true;
                }
            }
        }

        public override bool IsConnected() => _peer != null;

        public override void Kick(Connection cn, string message)
        {
            if (_peer == null)
            {
                return;
            }

            if (this.write.Start())
            {
                this.write.PacketId(Message.Type.DisconnectReason);
                this.write.String(message);
                var write = this.write;
                var sendInfo = new SendInfo(cn)
                {
                    method = SendMethod.ReliableUnordered,
                    priority = Priority.Immediate
                };
                write.Send(sendInfo);
            }

            ConsoleSystem.Log(string.Concat(cn.ToString(), " kicked: ", message));
            _peer.Kick(cn);
            OnDisconnected(string.Concat("Kicked: ", message), cn);
        }

        protected override void OnNewConnection()
        {
            var connection = new Connection
            {
                guid = _peer.IncomingGuid,
                ipaddress = _peer.IncomingAddress,
                active = true
            };
            base.OnNewConnection(connection);
            OnNewConnectionCallback?.Invoke(connection);
        }


        public override unsafe void SendUnconnected(uint netAddr, ushort netPort, byte[] data, int size)
        {
            fixed (byte* ptr = data)
            {
                _peer.SendUnconnectedMessage(ptr, size, netAddr, netPort);
            }
        }

        public override bool Start()
        {
            _peer = Peer.CreateServer(Ip, Port, 1024);
            if (_peer == null)
            {
                return false;
            }

            write = new StreamWrite(this, _peer);
            read = new StreamRead(this, _peer);
            return true;
        }

        public override void Stop(string shutdownMsg)
        {
            if (_peer == null)
            {
                return;
            }

            ConsoleSystem.Log(string.Concat("[Raknet] Server Shutting Down (", shutdownMsg, ")"));
            (write as StreamWrite).Shutdown();
            (read as StreamRead).Shutdown();
            using (var timeWarning = TimeWarning.New("ServerStop", 0.1f))
            {
                _peer.Close();
                _peer = null;
                base.Stop(shutdownMsg);
            }
        }

        internal void UnconnectedPacket()
        {
            var num = _peer.ReadByte();
            if (OnUnconnectedMessage != null &&
                OnUnconnectedMessage(num, read, _peer.IncomingAddressInt, (int) _peer.IncomingPort))
            {
                return;
            }

            HandleRaknetPacket(num, null);
        }


        public override void Send()
        {
            write.Send(new SendInfo(Connections));
        }
    }
}