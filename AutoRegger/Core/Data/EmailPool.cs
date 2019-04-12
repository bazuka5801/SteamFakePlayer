using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AutoRegger.Core.Data
{
    public static class EmailPool
    {
        private static List<EmailAccountData> _storage;
        
        public static EmailAccountData Get()
        {
            if (_storage.Count > 0)
            {
                var account = _storage[0];
                _storage.RemoveAt(0);
                Console.WriteLine($"[EmailPool] Take {account.Email}, <{_storage.Count}> remain.");
                return account;
            }

            File.WriteAllText("error.txt", "No email accounts in emails.txt");
            Process.GetCurrentProcess().Kill();
            return null;
        }

        public static void Load()
        {
            _storage = new List<EmailAccountData>();

            if (File.Exists("emails.txt") == false)
            {
                File.WriteAllText("error.txt", "File not found: emails.txt");
                Process.GetCurrentProcess().Kill();
                return;
            }

            foreach (var lineData in File.ReadLines("emails.txt"))
            {
                var lineDataArray = lineData.Split(';', ':');
                if (lineDataArray.Length != 2)
                {
                    continue;
                }

                var email = lineDataArray[0];
                var password = lineDataArray[1];

                _storage.Add(new EmailAccountData()
                {
                    Email = email, Password = password
                });
            }

            Console.WriteLine($"Loaded <{_storage.Count}> emails");
        }

        public static void Save()
        {
            File.WriteAllLines("emails.txt", _storage.Select(p=>$"{p.Email}:{p.Password}"));
        }
    }
}