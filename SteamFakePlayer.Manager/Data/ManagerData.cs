using System.Collections.Generic;
using ProtoBuf;

namespace SteamFakePlayer.Manager.Data
{
    [ProtoContract]
    public class ManagerData
    {
        [ProtoMember(1)]
        public string LastKey;

        [ProtoMember(2)]
        public List<ServerData> Servers = new List<ServerData>();
    }
}