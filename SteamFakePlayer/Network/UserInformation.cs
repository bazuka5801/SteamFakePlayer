using System;
using RakNet.Network;
using SapphireEngine;

namespace SteamFakePlayer.Network
{
    public class UserInformation
    {
        public string Branch;
        public uint ConnectionProtocol;
        public string Os;
        public byte PacketProtocol;
        public ulong SteamId;
        public byte[] SteamToken;
        public string Username;

        public static UserInformation ParsePacket(Message message)
        {
            try
            {
                message.read.Position = 1;
                var userInformation = new UserInformation();
                userInformation.PacketProtocol = message.read.UInt8();
                userInformation.SteamId = message.read.UInt64();
                userInformation.ConnectionProtocol = message.read.UInt32();
                userInformation.Os = message.read.String();
                userInformation.Username = message.read.String();
                userInformation.Branch = message.read.String();
                userInformation.SteamToken = message.read.BytesWithSize();

                message.peer.read.Position = 0L;
                return userInformation;
            }
            catch (Exception ex)
            {
                ConsoleSystem.LogError("Error to Struct.UserInformation.ParsePacket(): " + ex.Message);
            }

            return default(UserInformation);
        }

        public void Write(NetworkPeer peer)
        {
            peer.write.UInt8(PacketProtocol);
            peer.write.UInt64(SteamId);
            peer.write.UInt32(ConnectionProtocol);
            peer.write.String(Os);
            peer.write.String(Username);
            peer.write.String(Branch);
            peer.write.BytesWithSize(SteamToken);
        }
    }
}