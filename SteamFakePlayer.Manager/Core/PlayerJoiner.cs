using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager.Core
{
    internal enum ConnectionState
    {
        ConnectingToSteam,
        LaunchingRust,
        Joining,
        Playing,
        Disconnected
    }

    internal delegate void StateChanged(ConnectionState state);

    internal abstract class PlayerJoiner
    {
        private readonly BotAccountData _account;
        private Process _joinerProcess;

        private bool _running;
        private readonly ServerData _server;

        private ConnectionState state = ConnectionState.Disconnected;

        public PlayerJoiner(BotAccountData account, ServerData server)
        {
            _account = account;
            _server = server;
        }

        internal ConnectionState State
        {
            get => state;
            set
            {
                if (state != value)
                {
                    state = value;
                    OnStateChanged(state);
                }
            }
        }

        internal event StateChanged StateChanged;

        protected virtual void OnStateChanged(ConnectionState state)
        {
            if (StateChanged != null)
            {
                StateChanged(state);
            }
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

            var args = GenerateJoinerArguments();

            processInfo = new ProcessStartInfo(DataManager.Data.JoinerFile, args)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                StandardErrorEncoding = Encoding.UTF8,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = Path.GetDirectoryName(DataManager.Data.JoinerFile)
            };

            _joinerProcess = Process.Start(processInfo);
            _joinerProcess.OutputDataReceived += Joiner_OutputDataReceived;
            _joinerProcess.ErrorDataReceived += Joiner_ErrorDataReceived;
            _joinerProcess.BeginOutputReadLine();
            _joinerProcess.BeginErrorReadLine();
            _joinerProcess.WaitForExit();

            OnDisconnectedFromServer("Quiting...");


            _running = false;
        }

        private void Joiner_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        internal void Disconnect()
        {
            if (State != ConnectionState.Disconnected)
            {
                _joinerProcess.Kill();
            }
        }

        protected virtual void OnConnectedToServer(string servername)
        {
            State = ConnectionState.Playing;
        }

        protected virtual void OnDisconnectedFromServer(string reason)
        {
            State = ConnectionState.Disconnected;
        }

        private void Joiner_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }

            if (e.Data.Contains("Подключились к: "))
            {
                var servername = e.Data.Split(new[] {"Подключились к: "}, StringSplitOptions.RemoveEmptyEntries)[1];
                OnConnectedToServer(servername);
            }
            else if (e.Data.Contains("Соеденение с игровым сервером разорвано: Connection Attempt Failed"))
            {
                OnDisconnectedFromServer("Connection Attempt Failed");
            }

            Console.WriteLine(e.Data);
        }

        protected virtual string GenerateJoinerArguments()
        {
            return $"\"{_account.Username}\" " +
                   $"\"{_account.Password}\" " +
                   $"\"{_server.IP}\" " +
                   $"\"{_server.Port}\" \" \" " +
                   $"\"-pid\" \"{Process.GetCurrentProcess().Id}\" "
#if !DEBUG
                   + $"\"-hide\" "
#endif
                ;
        }
    }
}