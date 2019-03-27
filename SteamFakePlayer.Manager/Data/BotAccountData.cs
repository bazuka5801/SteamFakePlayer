using ProtoBuf;

namespace SteamFakePlayer.Manager.Data
{
    [ProtoContract]
    public class BotAccountData
    {
        [ProtoMember(2)]
        public string Password;

        [ProtoMember(1)]
        public string Username;
    }
}