namespace SteamFakePlayer
{
    public class AuthTicket
    {
        public int AppId;
        public bool Cancelled = false;
        public uint Crc32;
        public int Handle;
        public bool IsServerTicket = false;
        public int PipeId;
        public byte[] Ticket;
    }
}