using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AutoRegger.Core.Data
{
    public static class NicknamePool
    {
        private static List<string> _storage;
        
        public static string Get()
        {
            if (_storage.Count > 0)
            {
                var account = _storage[0];
                _storage.RemoveAt(0);
                Console.WriteLine($"[NicknamePool] Take {account}, <{_storage.Count}> remain.");
                return account;
            }

            File.WriteAllText("error.txt", "No nickname in nicknames.txt");
            Process.GetCurrentProcess().Kill();
            return null;
        }

        public static void Load()
        {
            _storage = new List<string>();

            if (File.Exists("nicknames.txt") == false)
            {
                File.WriteAllText("error.txt", "File not found: nicknames.txt");
                Process.GetCurrentProcess().Kill();
                return;
            }

            foreach (var lineData in File.ReadLines("nicknames.txt"))
            {
                _storage.Add(lineData);
            }

            Console.WriteLine($"[NicknamePool] Loaded <{_storage.Count}> nicknames");
        }

        public static void Save()
        {
            File.WriteAllLines("nicknames.txt", _storage);
        }
    }
}