using WindowsInput;

namespace AutoRegger.Core.Data
{
    public class ReggerAccountData
    {
        public EmailAccountData EmailAccount = new EmailAccountData();
        public SteamAccountData SteamAccount = new SteamAccountData();

        public Window Window;
        public IKeyboardSimulator Keyboard;
    }
}