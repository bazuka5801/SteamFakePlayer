using System.Drawing;
using System.Threading;

namespace AutoRegger.Core.States
{
    public class SetupAccountState : ReggerState
    {
        public override void Execute()
        {
            Window.Click(new Point(480, 164));
            Thread.Sleep(2000);

            WriteText(new Point(64, 350), _reggerAccount.SteamAccount.Login);
            Thread.Sleep(500);
            Window.Click(new Point(300, 350));
            Thread.Sleep(500);
            WriteText(new Point(64, 400), _reggerAccount.SteamAccount.Password);
            Thread.Sleep(500);
            Window.Click(new Point(300, 400));
            Thread.Sleep(500);
            Window.Click(new Point(64, 485));
            Thread.Sleep(5000);

            Window.Click(new Point(800, 550));
            Thread.Sleep(2000);
            Window.Click(new Point(702, 450));
            Thread.Sleep(3000);
            Window.Click(new Point(200, 840));
            Thread.Sleep(3000);
            Window.Click(new Point(200, 860));
            Thread.Sleep(2000);
        }
    }
}