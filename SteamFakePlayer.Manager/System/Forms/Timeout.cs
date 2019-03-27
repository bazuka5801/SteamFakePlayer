using System;

namespace SteamFakePlayer.Manager
{
    internal class Timeout : System.Timers.Timer
    {
        public Timeout(double delay, Action action)
        {
            this.AutoReset = false;
            this.Interval = delay;
            this.Elapsed += (sender, args) => action();
            this.Start();
        }
    }
}
