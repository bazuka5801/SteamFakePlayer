using System;
using System.Linq;
using System.Threading.Tasks;
using SapphireEngine;
using Sentry;
using SteamFakePlayer.System;

namespace SteamFakePlayer
{
    internal class Program : SapphireType
    {
        private static string _username;
        private static string _password;
        private static string _ip;
        private static int _port;
        private static bool _quitAfterConnected;

        public override void OnAwake()
        {
            ConsoleSystem.IsOutputToFile = false;
            Task.Run(() =>
            {
                using (SentrySdk.PushScope("SteamPlayer"))
                {
                    try
                    {
                        new SteamPlayer(_username, _password, _ip, _port, _quitAfterConnected).Connect();
                    }
                    catch (Exception e)
                    {
                        SentrySdk.CaptureException(e);
                    }
                }
            });
        }

        /// <summary>
        ///     Entry point of the program
        /// </summary>
        /// <param name="args">username, password, server ip, server port[, -hide]</param>
        public static void Main(string[] args)
        {
            using (SentrySdk.Init("https://da1197128b894279a68360e77d2a3afa@sentry.io/1422492"))
            {
                _username = args[0];
                _password = args[1];
                _ip = args[2];
                _port = int.Parse(args[3]);
                if (args[4] == "-hide")
                {
                    ConsoleView.Hide();
                }
                if (args.Contains("-quit-after-connected"))
                {
                    _quitAfterConnected = true;
                }

                if (args.Contains("-pid"))
                {
                    var parentPID = int.Parse(args[1+args.ToList().FindIndex(p => p == "-pid")]);
                    ProcessManager.Init(parentPID);
                }

                Framework.Initialization<Program>();
            }
        }
    }
}