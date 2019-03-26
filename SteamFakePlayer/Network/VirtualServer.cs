using System;
using System.Collections.Generic;
using System.IO;
using Network;
using ProtoBuf;
using SapphireEngine;
using Message = RakNet.Network.Message;
using NetworkPeer = RakNet.Network.NetworkPeer;

namespace SteamFakePlayer.Network
{
    public class VirtualServer : SapphireType
    {
        private Dictionary<uint, string> _pooledStrings = new Dictionary<uint, string>();

        private ulong _steamId;
        private byte[] _token;
        private string _username;
        private bool _quitAfterConnected;
        public RakNet.Client BaseClient;

        public UserInformation ConnectionInformation { get; private set; }
        public bool IsHaveConnection => ConnectionInformation != null;

        public override void OnAwake()
        {
            InitializationNetwork();
            ConsoleSystem.Log("[VirtualServer]: Все службы готовы к работе!");
        }

        public void Init(ulong steamid, string username, byte[] token, bool quitAfterConnected)
        {
            _steamId = steamid;
            _username = username;
            _token = token;
            _quitAfterConnected = quitAfterConnected;
        }

        public override void OnUpdate()
        {
            CycleNetwork();
        }

        public override void OnDestroy()
        {
            if (BaseClient.IsConnected())
            {
                BaseClient.Disconnect("Disconnected", true);
            }
        }

        #region [Method] [Example] CycleNetwork

        private void CycleNetwork()
        {
            BaseClient.Cycle();
        }

        #endregion


        #region [Method] [Example] InitializationNetwork

        private void InitializationNetwork()
        {
            try
            {
                ConsoleSystem.Log("[VirtualServer]: Служба Network запускается...");

                BaseClient = new RakNet.Client
                {
                    OnMessage = IN_OnNetworkMessage,
                    onDisconnected = IN_OnDisconnected,
                    Cryptography = new NetworkCryptographyClient()
                };

                ConsoleSystem.Log("[VirtualServer]: Служба Network успешно запущена!");
            }
            catch (Exception ex)
            {
                ConsoleSystem.LogError("[VirtualServer]: Исключение в InitializationNetwork(): " + ex.Message);
            }
        }

        #endregion

        #region [Method] [Example] Connect

        public void Connect(string ip, int port)
        {
            try
            {
                ConsoleSystem.Log($"[VirtualServer]: Подключаемся к игровому серверу [{ip}:{port}]");
                if (BaseClient.Connect(ip, port))
                {
                    if (BaseClient.write.Start())
                    {
                        BaseClient.write.UInt8(19);
                        BaseClient.write.Send(new SendInfo(BaseClient.Connection));
                    }

                    ConsoleSystem.Log("[VirtualServer]: Инициализация подключения успешно завершена!");
                }
                else
                {
                    ConsoleSystem.LogError("[VirtualServer]: В попытке подключения отказано!");
                }
            }
            catch (Exception ex)
            {
                ConsoleSystem.LogError("[VirtualServer]: Исключение в OnNewConnection(): " + ex.Message);
            }
        }

        #endregion


        #region [Method] [Example] IN_OnDisconnected

        public void IN_OnDisconnected(string reason)
        {
            ConsoleSystem.LogWarning("[VirtualServer]: Соеденение с игровым сервером разорвано: " + reason);
        }

        #endregion

        #region [Method] [Example] IN_OnNetworkMessage

        public void IN_OnNetworkMessage(Message packet)
        {
//            if (packet.type != Message.Type.Entities && packet.type != Message.Type.Tick &&
//                packet.type != Message.Type.EAC
//                && packet.type != Message.Type.EntityPosition && packet.type != Message.Type.GroupEnter &&
//                packet.type != Message.Type.GroupDestroy && packet.type != Message.Type.GroupLeave)
//            {
//                
//                if (packet.type == Message.Type.RPCMessage)
//                {
//                    UInt32 UID = packet.read.EntityID();
//                    UInt32 rpcId = packet.read.UInt32();
//                    packet.read.UInt64();
//                    ConsoleSystem.Log($"IN RPC => {pooledStrings[rpcId]} - {rpcId}");
//                }else if (packet.type == Message.Type.ConsoleCommand)
//                {
////                    ConsoleSystem.Log($"IN COMMAND => {packet.read.String()}");
//                }else
//                ConsoleSystem.Log($"IN => {packet.type}");
//            }
            switch (packet.type)
            {
                case Message.Type.Approved:
                    OnApproved(packet);
                    break;
                case Message.Type.RequestUserInformation:
                    ConnectionInformation = new UserInformation
                    {
                        Branch = "",
                        ConnectionProtocol = 2155,
                        Os = "editor",
                        PacketProtocol = 228,
                        SteamId = _steamId,
                        Username = _username,
                        SteamToken = _token
                    };
                    if (BaseClient.write.Start())
                    {
                        BaseClient.write.PacketId(Message.Type.GiveUserInformation);
                        ConnectionInformation.Write(BaseClient);
                        BaseClient.Send();
                    }

                    break;
                case Message.Type.ConsoleCommand:
                    break;
                case Message.Type.DisconnectReason:
                    packet.read.Position = 1L;
                    var reasone = packet.read.String();
                    ConsoleSystem.LogWarning("[VirtualServer]: От игрового сервера получена причина дисконнекта: " +
                                             reasone);
                    break;
            }
        }

        #endregion

        #region [Method] [Example] OnApproved

        private void OnApproved(Message packet)
        {
            try
            {
                using (var approval = Approval.Deserialize(packet.read))
                {
                    ConsoleSystem.LogWarning(
                        $"[VirtualServer]: Подключились к: {(approval.official ? "[Oficial] " : "")}" +
                        approval.hostname);

                    if (_quitAfterConnected)
                    {
                        BaseClient.Disconnect("", true);
                        Framework.Quit();
                    }
                    BaseClient.Connection.encryptionLevel = approval.encryption;
                    BaseClient.Connection.decryptIncoming = true;

                    if (BaseClient.write.Start())
                    {
                        BaseClient.write.PacketId(Message.Type.Ready);
                        BaseClient.write.Send(new SendInfo(BaseClient.Connection));
                    }

                    packet.connection.encryptOutgoing = true;
                }
            }
            catch (Exception ex)
            {
                ConsoleSystem.LogError("[VirtualServer]: Исключение в OnApproved(): " + ex.Message);
            }
        }

        #endregion

        #region [Methods] [Example] RakNet Unconnected

        public void OUT_OnRakNetMessage(byte uid)
        {
            if (BaseClient == null || !BaseClient.IsConnected())
            {
                return;
            }

            if (BaseClient.write.Start())
            {
                BaseClient.write.UInt8(uid);
                BaseClient.Send();
            }
        }

        #endregion

        #region [Method] [Example] SendPacket

        public byte[] GetPacketBytes(Message message)
        {
            byte[] buffer = null;
            var startPos = message.read.Position;
            message.peer.read.Position = 0L;
            using (var br = new BinaryReader(message.peer.read))
            {
                buffer = br.ReadBytes((int) message.peer.read.Length);
            }

            message.read.Position = startPos;
            return buffer;
        }

        public void SendPacket(NetworkPeer peer, Message message)
        {
            message.peer.read.Position = 0L;
            using (var br = new BinaryReader(message.peer.read))
            {
                peer.write.Start();
                peer.write.Write(br.ReadBytes((int) message.peer.read.Length), 0, (int) message.peer.read.Length);
                peer.write.Send(new SendInfo(BaseClient.Connection));
            }
        }

        public void SendPacket(NetworkPeer peer, byte[] message)
        {
            peer.write.Start();
            peer.write.Write(message, 0, message.Length);
            peer.write.Send(new SendInfo(BaseClient.Connection));
        }

        #endregion
    }
}