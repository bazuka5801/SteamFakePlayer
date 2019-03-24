using System;
using System.Runtime.InteropServices;

namespace SteamFakePlayer.System
{
    public static class ConsoleView
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Hide() => ShowWindow(GetConsoleWindow(), SW_HIDE);
        public static void Show() => ShowWindow(GetConsoleWindow(), SW_SHOW);
    }
}