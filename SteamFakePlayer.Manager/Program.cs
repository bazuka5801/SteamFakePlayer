using System;
using System.Windows.Forms;
using Sentry;
using SteamFakePlayer.Manager.Data;

namespace SteamFakePlayer.Manager
{
    static class Program
    {
        /// <summary>
        ///   Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (SentrySdk.Init("https://58667611cabc40e9b0cdae27fe35d132@sentry.io/1422485"))
            {
                DataManager.RunSaver();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
