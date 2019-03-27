using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
