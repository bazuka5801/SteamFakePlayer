using System.Drawing;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using AutoRegger.Core.Data;
using AutoRegger.Utils;

namespace AutoRegger.Core.States
{
    public abstract class ReggerState : IReggerState
    {
        protected ReggerAccountData _reggerAccount;

        protected Window Window => _reggerAccount?.Window;
        protected IKeyboardSimulator Keyboard => _reggerAccount?.Keyboard;
        
        public virtual void Setup(ReggerAccountData data)
        {
            _reggerAccount = data;
        }

        public abstract void Execute();

        public void GoToTab(int tabIndex)
        {
            Window.Click(new Point(200 * tabIndex, 26));
        }
        
        public void GoToUrl(string url, int tab = 1, int waitSeconds = 4)
        {
            GoToTab(tab);

            var urlTextBoxPoint = new Point(320, 67);
            Window.Click(urlTextBoxPoint);
            Window.Click(urlTextBoxPoint);
            Window.Click(urlTextBoxPoint);
            Keyboard.KeyPress(VirtualKeyCode.DELETE);
            Keyboard.TextEntry(url);
            Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(waitSeconds * 1000);
        }

        public void WriteText(Point point, string text)
        {
            Window.Click(point);
            Window.Click(point);
            Window.Click(point);
            Keyboard.KeyPress(VirtualKeyCode.DELETE);
            
            Window.Click(point);
            Keyboard.TextEntry(text);
        }

        public string ScreenshotBase64(Point start, Point end)
        {
            start.Offset(Window.Position);
            end.Offset(Window.Position);

            return ScreenshotUtils.GetBase64(start, end);
        }
    }
}