using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public static class MessageUtils
    {
        public static void Error(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static bool Confirm(string text)
        {
            return DialogResult.Yes == MessageBox.Show(text, "Вы уверены?",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        public static void Info(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}