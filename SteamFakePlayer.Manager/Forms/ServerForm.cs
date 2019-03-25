using SteamFakePlayer.Manager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void LoadData(ServerData serverData)
        {
            tbAccounts.Lines = serverData.Bots.Select(p => $"{p.Username}:{p.Password}").ToArray();
        }

        private void cbShowAccounts_CheckedChanged(object sender, EventArgs e)
        {
            tbAccounts.PasswordChar = ((CheckBox)sender).Checked ? '\0' : '*';
        }

        private void btnLoadAccountsFile_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                fileDialog.Filter = "txt files(*.txt) | *.txt";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var accounts = new List<BotAccountData>();
                        var lines = File.ReadAllLines(fileDialog.FileName);

                        if (lines.Length == 0)
                        {
                            MessageUtils.Error("Файл пустой!");
                            return;
                        }

                        foreach (var account in lines)
                        {
                            string[] accountData = account.Split(':');
                            string username = accountData[0];
                            string password = accountData[1];

                            accounts.Add(new BotAccountData() { Username = username, Password = password });
                        }

                        _serverData.Bots = accounts;
                        DataManager.Save();
                        LoadData(_serverData);
                    }
                    catch(IndexOutOfRangeException)
                    {
                        MessageUtils.Error("Файл имеет неверную структуру!");
                    }
                }
            }
        }
    }
}
