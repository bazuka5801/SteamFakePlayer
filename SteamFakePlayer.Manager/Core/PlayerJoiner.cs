using SteamFakePlayer.Manager.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamFakePlayer.Manager.Core
{
    internal class PlayerJoiner
    {
        private BotAccountData _account;
        private ServerData _server;

        private bool _running;

        public PlayerJoiner(BotAccountData account, ServerData server)
        {
            _account = account;
            _server = server;
        }

        public void Join()
        {
            if (_running)
            {
                throw new Exception("Is Running");
            }

            _running = true;
            Task.Run(() => RunJoiner());
        }

        private void RunJoiner()
        {
            ProcessStartInfo processInfo;
            Process process;
            
            string args = GenerateJoinerArguments();

            processInfo = new ProcessStartInfo(DataManager.Data.JoinerFile, args)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                StandardErrorEncoding = Encoding.UTF8,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = Path.GetDirectoryName(DataManager.Data.JoinerFile)
            };
            
            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();


            _running = false;
        }

        private string GenerateJoinerArguments()
        {
            return $"\"{_account.Username}\" " +
                   $"\"{_account.Password}\" " +
                   $"\"{_server.IP}\" " +
                   $"\"{_server.Port}\" \" \""
#if !DEBUG
                   + $"\"-hide\""
#endif
                ;
        }
    }
}
