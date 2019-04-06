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
    internal delegate void Disconnected(PlayerJoiner joiner, string reason);

    internal abstract class PlayerJoiner
    {
        private ServerCore _server;
        private Process _joinerProcess;

        private bool _running;

        private ConnectionState state = ConnectionState.Disconnected;

        private Timeout _connectingTask, _disconnectingTask;

        public bool BlockReconnect;

        public PlayerJoiner(BotAccountData account)
        {
            Account = account;
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

        public void SetServer(ServerCore server)
        {
            _server = server;
        }

        public ServerCore GetServer() => _server;

        public BotAccountData Account { get; }

        internal event StateChanged StateChanged;

        protected virtual void OnStateChanged(ConnectionState state)
        {
            StateChanged?.Invoke(state);
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
                //WorkingDirectory = Path.GetDirectoryName(DataManager.Data.JoinerFile)
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

        internal int ConnectWithSettingsDelay()
        {
            BlockReconnect = false;
            var delay = 1000 * Rand.Int32(DataManager.Data.BotOptions.EnterMin, DataManager.Data.BotOptions.EnterMax);
            ConnectWithDelay(delay);
            return delay;
        }

        internal void ConnectWithDelay(int delay)
        {
            ReplaceTask(ref _connectingTask, new Timeout(delay, Connect));
        }

        private void Connect()
        {
            if (_running)
            {
                new Timeout(100, Connect);
                return;
            }

            _running = true;
            Task.Run(() => RunJoiner());
        }

        internal int DisconnectWithSettingsDelay()
        {
            var delay = 1000 * Rand.Int32(DataManager.Data.BotOptions.ExitMin, DataManager.Data.BotOptions.ExitMax);
            DisconnectWithDelay(delay);
            return delay;
        }

        internal void DisconnectWithDelay(int delay)
        {
            ReplaceTask(ref _disconnectingTask, new Timeout(delay, DisconnectWithBlocking));
        }

        private void DisconnectWithBlocking()
        {
            if (State != ConnectionState.Disconnected)
            {
                BlockReconnect = true;
                KillJoiner();
            }
        }

        private void KillJoiner()
        {
            _joinerProcess.Kill();
        }

        private void ReplaceTask(ref Timeout currentTimeout, Timeout newTimeout)
        {
            if (currentTimeout != null)
            {
                currentTimeout.Stop();
                currentTimeout.Dispose();
                currentTimeout = null;
            }

            currentTimeout = newTimeout;
        }        

        protected virtual void OnConnectedToServer(string servername)
        {
            State = ConnectionState.Playing;
            Console.WriteLine($"'{Account.Username}' connected to '{_server.Data.DisplayName}'");
        }

        protected virtual void OnDisconnectedFromServer(string reason)
        {
            State = ConnectionState.Disconnected;
            Console.WriteLine($"'{Account.Username}' disconnected from '{_server.Data.DisplayName}' reason: {reason}");
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
                Reconnect();
            }
            else if (e.Data.Contains("От игрового сервера получена причина дисконнекта: Server Restarting"))
            {
                OnDisconnectedFromServer("Server Restarting");
                Reconnect();
            }else if (e.Data.EndsWith("[GOSLEEP]"))
            {
                _server.StartSleeping();
                BotSpreader.Instance.PushPlayer((BotPlayer)this);
            }

            Console.WriteLine($"[{Account.Username}] {e.Data}");
        }

        internal void Reconnect()
        {
            if (BlockReconnect == false)
            {
                KillJoiner();
                var delay = 1000 * Rand.Int32(DataManager.Data.BotOptions.ReconnectMin, DataManager.Data.BotOptions.ReconnectMax);
                ConnectWithDelay(delay);
            }
        }

        protected virtual string GenerateJoinerArguments()
        {
            return $"\"{Account.Username}\" " +
                   $"\"{Account.Password}\" " +
                   $"\"{_server.Data.IP}\" " +
                   $"\"{_server.Data.Port}\" \" \" " +
                   $"\"-pid\" \"{Process.GetCurrentProcess().Id}\" "
#if !DEBUG
                   + $"\"-hide\" "
#endif
                ;
        }
    }
}