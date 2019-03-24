using System;
using System.Runtime.InteropServices;

namespace SteamFakePlayer.Steam.Core
{
    public static class Platform
    {
        public static DateTime LoadTime { get; set; } = DateTime.Now;

        public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static bool IsOSX() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static string AssemblyExtension() => ".dll";

        public static int MilisecondTime() => (DateTime.Now - LoadTime).Milliseconds;

        public static uint ToUnixTime(DateTime t) => (uint) new DateTimeOffset(t).ToUnixTimeSeconds();
    }
}