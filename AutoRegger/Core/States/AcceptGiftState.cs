using System.Drawing;
using System.Threading;
using WindowsInput.Native;
using AutoRegger.Core.Data;

namespace AutoRegger.Core.States
{
    public class AcceptGiftState : ReggerState
    {
        public override void Execute()
        {
            GoToUrl(KeysPool.Get(), waitSeconds: 6);
            Window.Click(new Point(580, 860));
            Thread.Sleep( 3000);
            Window.Click(new Point(400, 600));
            Thread.Sleep( 5000);
            
            GoToUrl("javascript:Logout();");
            
            KeysPool.Save();
        }
    }
}