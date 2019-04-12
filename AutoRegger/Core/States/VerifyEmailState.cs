using System.Drawing;
using System.Threading;

namespace AutoRegger.Core.States
{
    public class VerifyEmailState : ReggerState
    {
        public override void Execute()
        {
            // Load steam registration page
            GoToUrl("https://mail.ru/", tab: 2);
            Thread.Sleep(2000);
            
            WriteText(new Point(76, 274), _reggerAccount.EmailAccount.Email);
            Thread.Sleep(500);
            WriteText(new Point(76, 315), _reggerAccount.EmailAccount.Password);
            Thread.Sleep(1000);
            Window.Click(new Point(180, 300));
            Thread.Sleep(5000);
            Window.Click(new Point(547, 432));
            Thread.Sleep(5000);
            Window.Click(new Point(600, 800));
            Thread.Sleep(5000);
            Window.Click(new Point(710, 23));

            Thread.Sleep(1000);
            Window.Click(new Point(960, 125));
            GoToTab(1);
            Thread.Sleep(2000);
        }
    }
}