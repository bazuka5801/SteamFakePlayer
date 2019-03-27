using ProtoBuf;

namespace SteamFakePlayer.Manager.Data
{
    [ProtoContract]
    public class BotOptionsData
    {
        [ProtoMember(2)]
        public int EnterMax;

        [ProtoMember(1)]
        public int EnterMin;

        [ProtoMember(4)]
        public int ExitMax;

        [ProtoMember(3)]
        public int ExitMin;
    }
}