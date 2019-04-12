using System;
using System.Drawing;
using System.Threading;
using AutoRegger.Core.Data;
using AutoRegger.Utils;

namespace AutoRegger.Core.States
{
    public class RegisterState : ReggerState
    {
        public override void Execute()
        {
            // Load steam registration page
            GoToUrl("https://store.steampowered.com/join/");

            // Scroll up
            Window.Click(new Point(976, 160));
            Thread.Sleep(300);

            // Email
            WriteText(new Point(64,355), _reggerAccount.EmailAccount.Email);
            WriteText(new Point(64,409), _reggerAccount.EmailAccount.Email);

            // Captha
            var captchaImage = ScreenshotBase64(new Point(30, 509), new Point(237, 549));
            var captchaAnswer = AntiCapthaUtils.GetCapthaAnswer(captchaImage);
            WriteText(new Point(64,610), captchaAnswer);

            Window.Click(new Point(976, 947));
            Thread.Sleep(1000);
            Window.Click(new Point(42, 622));
            Thread.Sleep(500);
            Window.Click(new Point(562, 655));
            
            Thread.Sleep(5000);
        }
    }
}