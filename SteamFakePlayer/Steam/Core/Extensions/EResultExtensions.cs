using SteamKit2;

namespace SteamFakePlayer.Steam.Core.Extensions
{
    public static class EResultExtensions
    {
        public static string ExtendedString(this EResult result) => $"EResult.{result} [{(uint) result}]";
    }
}