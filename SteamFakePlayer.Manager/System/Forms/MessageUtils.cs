using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public static class MessageUtils
    {
        public static void Error(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}