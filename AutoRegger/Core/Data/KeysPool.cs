using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AutoRegger.Core.Data
{
    public static class KeysPool
    {
        private static List<string> _storage;
        
        public static string Get()
        {
            if (_storage.Count > 0)
            {
                var account = _storage[0];
                _storage.RemoveAt(0);
                Console.WriteLine($"[KeysPool] Take {account}, <{_storage.Count}> remain.");
                return account;
            }

            File.WriteAllText("keys.txt", "No keys in keys.txt");
            Process.GetCurrentProcess().Kill();
            return null;
        }

        public static void Load()
        {
            _storage = new List<string>();

            if (File.Exists("keys.txt") == false)
            {
                File.WriteAllText("error.txt", "File not found: keys.txt");
                Process.GetCurrentProcess().Kill();
                return;
            }

            foreach (var lineData in File.ReadLines("keys.txt"))
            {
                _storage.Add(lineData);
            }

            Console.WriteLine($"Loaded <{_storage.Count}> keys");
        }

        public static void Save()
        {
            File.WriteAllLines("keys.txt", _storage);
        }
    }
}