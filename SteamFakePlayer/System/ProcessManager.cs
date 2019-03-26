using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SapphireEngine;

namespace SteamFakePlayer.System
{
    public class ProcessManager
    {
        private static int _parentPID;

        public static void Init(int parentPID)
        {
            _parentPID = parentPID;

            RunWatchDog();
        }

        public static void RunWatchDog()
        {
            Task.Run(() =>
            {
                for (;;)
                {
                    Thread.Sleep(100);
                    if (Process.GetProcessById(_parentPID).HasExited)
                    {
                        Framework.Quit();
                        return;
                    }
                }
            });
        }
    }
}