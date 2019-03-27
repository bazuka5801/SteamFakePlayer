using System;

namespace SteamFakePlayer.Manager
{
    public static class Rand
    {
        private static Random rand = new Random();

        public static Int32 Int32(Int32 min, Int32 max)
        {
            return rand.Next(min, max);
        }
    }
}
