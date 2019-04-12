using System.Drawing;
using System.IO;
using System.Threading;
using AutoRegger.Core.Data;

namespace AutoRegger.Core.States
{
    public class EndRegisterState : ReggerState
    {
        public override void Execute()
        {
            var login = _reggerAccount.EmailAccount.Email.Split('@')[0];
            var password = _reggerAccount.EmailAccount.Password;

            WriteText(new Point(64, 366), login);
            Thread.Sleep(1000);
            WriteText(new Point(64,436), password);
            Window.Click(new Point(500,500));
            Thread.Sleep(1000);
            WriteText(new Point(64,497), password);
            Window.Click(new Point(500,500));
            Thread.Sleep(1000);

            Window.Click(new Point(483,566));

            _reggerAccount.SteamAccount.Login = login;
            _reggerAccount.SteamAccount.Password = password;
            File.AppendAllText("results.txt", $"{login};{password}\n");
            EmailPool.Save();
            Thread.Sleep(5000);
        }
    }
}