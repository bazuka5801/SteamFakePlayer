using ProtoBuf;

namespace SteamFakePlayer.Manager.Data
{
    [ProtoContract]
    public class BotOptionsData
    {
        [ProtoMember(1)]
        public int EnterMin;

        [ProtoMember(2)]
        public int EnterMax;

        [ProtoMember(3)]
        public int ExitMin;

        [ProtoMember(4)]
        public int ExitMax;

        [ProtoMember(5)]
        public int ReconnectMin;

        [ProtoMember(6)]
        public int ReconnectMax;
    }
}