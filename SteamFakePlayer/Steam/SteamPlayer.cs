using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using SapphireEngine;
using SteamFakePlayer.Network;
using SteamFakePlayer.Steam.Core;
using SteamFakePlayer.Steam.Core.Extensions;
using SteamKit2;
using SteamKit2.Internal;
using Buffer = SteamFakePlayer.Steam.Core.Buffer;

namespace SteamFakePlayer
{
    internal class Handler<T> : ClientMsgHandler
    {
        public delegate void OnMessage(IPacketMsg packetMsg);

        private readonly OnMessage _del;

        public Handler(OnMessage del)
        {
            _del = del;
        }

        public override void HandleMsg(IPacketMsg packetMsg)
        {
            _del(packetMsg);
        }
    }

    public class SteamPlayer
    {
        public static List<SteamPlayer> All = new List<SteamPlayer>();


        private readonly List<AuthTicket> _authTicketStore = new List<AuthTicket>();

        private readonly Dictionary<uint, byte[]> _ownershipTicketStore = new Dictionary<uint, byte[]>();
        private readonly string _password;

        private readonly string _user;
        private string _authCode;

        private readonly string _ip;

        private bool _isRunning;
        private CallbackManager _manager;
        private readonly int _port;
        private readonly bool _quitAfterConnected;

        private IPAddress _publicIp;
        private SteamApps _steamApps;

        private SteamKit2.SteamClient _steamClient;
        private SteamFriends _steamFriends;
        private SteamUser _steamUser;

        private string _twoFactorAuth;

        private string _username;
        public uint AuthSequence;

        private bool _quitAfterDisconnect = true;
        
        public List<byte[]> GameConnectTokens = new List<byte[]>();

        public uint TicketRequestCount;

        public SteamPlayer(string user, string password, string ip, int port, bool quitAfterConnected)
        {
            _user = user;
            _password = password;
            _ip = ip;
            _port = port;
            _quitAfterConnected = quitAfterConnected;
        }


        public void Connect()
        {
            // create our steamclient instance
            _steamClient = new SteamKit2.SteamClient();
            // create the callback manager which will route callbacks to function calls
            _manager = new CallbackManager(_steamClient);

            // get the steamuser handler, which is used for logging on after successfully connecting
            _steamUser = _steamClient.GetHandler<SteamUser>();
            _steamApps = _steamClient.GetHandler<SteamApps>();
            _steamFriends = _steamClient.GetHandler<SteamFriends>();

            // register a few callbacks we're interested in
            // these are registered upon creation to a callback manager, which will then route the callbacks
            // to the functions specified
            _manager.Subscribe<SteamKit2.SteamClient.ConnectedCallback>(OnConnected);
            _manager.Subscribe<SteamKit2.SteamClient.DisconnectedCallback>(OnDisconnected);

            _manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            _manager.Subscribe<SteamUser.LoggedOffCallback>(OnLoggedOff);

            _manager.Subscribe<SteamApps.AppOwnershipTicketCallback>(OnAppOwnershipTicketCallback);
            _manager.Subscribe<SteamApps.GameConnectTokensCallback>(OnGameConnectTokens);
            _steamClient.AddHandler(new Handler<SteamPlayer>(OnMessage));

            _isRunning = true;

            ConsoleSystem.Log("Connecting to Steam...");

            // initiate the connection
            _steamClient.Connect();

            // create our callback handling loop
            while (_isRunning)
            {
                // in order for the callbacks to get routed, they need to be handled by the manager
                _manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
        }

        public void OnMessage(IPacketMsg packetMsg)
        {
            if (packetMsg.MsgType == EMsg.ClientAuthListAck)
            {
                var pb = new ClientMsgProtobuf<CMsgClientAuthListAck>(packetMsg);
            }
        }

        private void LaunchRust()
        {
            _username = _steamFriends.GetPersonaName();
            ConsoleSystem.Log("Logged in! Launching Rust...");

            // we've logged into the account
            // now we need to inform the steam server that we're playing dota (in order to receive GC messages)

            // steamkit doesn't expose the "play game" message through any handler, so we'll just send the message manually
            var playGame = new ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);

            playGame.Body.games_played.Add(new CMsgClientGamesPlayed.GamePlayed
            {
                game_id = new GameID(252490) // or game_id = APPID,
            });

            // send it off
            // notice here we're sending this message directly using the SteamClient
            _steamClient.Send(playGame);

            // delay a little to give steam some time to establish a GC connection to us
            Thread.Sleep(5000);

            var index = GetAuthSessionTicket(252490, 327684);
            var bytes = GetAuthTicket(index);

            Framework.RunToMainThread(o =>
            {
                _quitAfterDisconnect = false;
                var server = Framework.Bootstraper.AddType<VirtualServer>();
                server.Init(_steamUser.SteamID.ConvertToUInt64(), _username, bytes.Ticket, _quitAfterConnected);
                server.Connect(_ip, _port);
            }, null);
        }

        private void OnConnected(SteamKit2.SteamClient.ConnectedCallback callback)
        {
            ConsoleSystem.Log("Connected to Steam! Logging in '{0}'...", _user);

            _steamUser.LogOn(new SteamUser.LogOnDetails
            {
                Username = _user,
                Password = _password,

                AuthCode = _authCode,
                TwoFactorCode = _twoFactorAuth
            });
        }

        private void OnDisconnected(SteamKit2.SteamClient.DisconnectedCallback callback)
        {
            if (_quitAfterDisconnect)
            {
                ConsoleSystem.Log("Disconnected from Steam, quiting...");
                Framework.Quit();
            }
            else
            {
                ConsoleSystem.Log("Disconnected from Steam!");
            }
        }

        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            var isSteamGuard = callback.Result == EResult.AccountLogonDenied;
            var is2Fa = callback.Result == EResult.AccountLoginDeniedNeedTwoFactor;

            if (isSteamGuard || is2Fa)
            {
                ConsoleSystem.Log("This account is SteamGuard protected!");

                if (is2Fa)
                {
                    Console.Write("Please enter your 2 factor auth code from your authenticator app: ");
                    _twoFactorAuth = Console.ReadLine();
                }
                else
                {
                    Console.Write("Please enter the auth code sent to the email at {0}: ", callback.EmailDomain);
                    _authCode = Console.ReadLine();
                }

                return;
            }

            if (callback.Result != EResult.OK)
            {
                if (callback.Result == EResult.AccountLogonDenied)
                {
                    // if we recieve AccountLogonDenied or one of it's flavors (AccountLogonDeniedNoMailSent, etc)
                    // then the account we're logging into is SteamGuard protected
                    // see sample 5 for how SteamGuard can be handled

                    ConsoleSystem.Log("Unable to logon to Steam: This account is SteamGuard protected.");

                    _isRunning = false;
                    return;
                }

                ConsoleSystem.Log("Unable to logon to Steam: {0} / {1}", callback.Result, callback.ExtendedResult);

                _isRunning = false;
                return;
            }

            _publicIp = callback.PublicIP;
            ConsoleSystem.Log("Successfully logged on!");

            GetAppOwnershipTicketAsync(252490);
        }

        private void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            ConsoleSystem.Log("Logged off of Steam: {0}", callback.Result);
        }

        private void OnAppOwnershipTicketCallback(SteamApps.AppOwnershipTicketCallback cb)
        {
            switch (cb.Result)
            {
                case EResult.OK:
                {
                    ConsoleSystem.Log("Got app ticket for {0} successfully", cb.AppID);
                    _ownershipTicketStore[cb.AppID] = cb.Ticket;

                    LaunchRust();
                    return;
                }
                default:
                {
                    ConsoleSystem.Log("GetAppOwnershipTicket for appid {0} failed {1}", cb.AppID,
                        cb.Result.ExtendedString());
                    return;
                }
            }
        }

        private byte[] GetAppOwnershipTicket(uint appId)
        {
            if (_ownershipTicketStore.TryGetValue(appId, out var result))
            {
                return result;
            }

            ConsoleSystem.Log("Waiting for app ownership ticket...");

            // Request an app ownership ticket from steam
            var job = _steamApps.GetAppOwnershipTicket(appId);
            var res = job.GetAwaiter().GetResult().Result;
            // Get the now stored ticket
            return _ownershipTicketStore[appId];
        }

        private byte[] GetAppOwnershipTicketAsync(uint appId)
        {
            if (_ownershipTicketStore.TryGetValue(appId, out var result))
            {
                return result;
            }

            // Request an app ownership ticket from steam
            var job = _steamApps.GetAppOwnershipTicket(appId);

            return null;
        }

        private void OnGameConnectTokens(SteamApps.GameConnectTokensCallback cb)
        {
            GameConnectTokens.AddRange(cb.Tokens);

            while (GameConnectTokens.Count > cb.TokensToKeep)
            {
                GameConnectTokens.RemoveAt(0);
            }
        }

        public int RemainingGameConnectTokens() => GameConnectTokens.Count;

        private byte[] GetGameConnectToken()
        {
            var token = GameConnectTokens[0];
            GameConnectTokens.RemoveAt(0);
            return token;
        }

        public void WriteGameConnectTokenToStream(StreamWriter s)
        {
            s.Write(GetGameConnectToken());
        }

        private AuthTicket GetAuthTicket(int handle) => _authTicketStore[handle - 1];

        private int GetAuthSessionTicket(int appId, int pipe)
        {
            ConsoleSystem.Log("GetAuthSessionTicket for app_id {0}", appId);
            var ownershipTicket = GetAppOwnershipTicket((uint) appId);

            var clientTicketBuffer = new Buffer();

            // Write the token into the ticket
            var token = GetGameConnectToken();
            clientTicketBuffer.WriteUInt((uint) token.Length);
            clientTicketBuffer.Write(token);

            // Size of header
            clientTicketBuffer.WriteUInt(24);


            // This is all copied from what the steamclient method does
            clientTicketBuffer.WriteUInt(1);
            clientTicketBuffer.WriteUInt(2);

            var ipBytes = _publicIp.GetAddressBytes();
            Array.Reverse(ipBytes);
            clientTicketBuffer.Write(ipBytes);

            // Filter
            clientTicketBuffer.WriteUInt(0);

            clientTicketBuffer.WriteUInt((uint) Platform.MilisecondTime());
            clientTicketBuffer.WriteUInt(++TicketRequestCount);

            var clientTicketCrc = BitConverter.ToUInt32(CryptoHelper.CRCHash(clientTicketBuffer.GetBuffer()), 0);

            _authTicketStore.Add(new AuthTicket
            {
                AppId = appId,
                PipeId = pipe,
                Crc32 = clientTicketCrc,
                Handle = _authTicketStore.Count + 1,
                Ticket = clientTicketBuffer.GetBuffer(),
                Cancelled = false
            });

            // Resend the auth list with our new ticket
            SendClientAuthList();


            // Create the ticket that will actually be sent to the server

            var serverTicketBuffer = new Buffer();

            serverTicketBuffer.Write(clientTicketBuffer.GetBuffer());

            // Write the ownership ticket data in here
            // We are just going to assume that our tickets are 100% correct...
            serverTicketBuffer.WriteUInt((uint) ownershipTicket.Length);


            serverTicketBuffer.Write(ownershipTicket);

            var serverTicketCrc = BitConverter.ToUInt32(CryptoHelper.CRCHash(serverTicketBuffer.GetBuffer()), 0);

            _authTicketStore.Add(new AuthTicket
            {
                IsServerTicket = true,
                AppId = appId,
                PipeId = pipe,
                Crc32 = serverTicketCrc,
                Handle = _authTicketStore.Count + 1,
                Ticket = serverTicketBuffer.GetBuffer(),
                Cancelled = false
            });

            return _authTicketStore.Count;
        }

        private void SendClientAuthList()
        {
            var authListMsg = new ClientMsgProtobuf<CMsgClientAuthList>(EMsg.ClientAuthList);

            // Add all our non-cancelled tickets to this auth list
            foreach (var ticket in _authTicketStore)
            {
                if (ticket.Cancelled || ticket.IsServerTicket)
                {
                    continue;
                }

                authListMsg.Body.tickets.Add(new CMsgAuthTicket
                {
                    gameid = (uint) ticket.AppId,
                    h_steam_pipe = (uint) ticket.PipeId,
                    ticket_crc = ticket.Crc32,
                    ticket = ticket.Ticket
                });

                authListMsg.Body.app_ids.Add((uint) ticket.AppId);
            }

            // Update the authlist and send it to the server

            authListMsg.Body.tokens_left = (uint) GameConnectTokens.Count;
            authListMsg.Body.message_sequence = ++AuthSequence;

            _steamClient.Send(authListMsg);
        }
    }
}