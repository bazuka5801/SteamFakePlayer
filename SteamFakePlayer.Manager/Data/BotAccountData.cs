using ProtoBuf;

namespace SteamFakePlayer.Manager.Data
{
    [ProtoContract]
    public class BotAccountData
    {
        [ProtoMember(1)]
        public string Username;

        [ProtoMember(2)]
        public string Password;
    }
}