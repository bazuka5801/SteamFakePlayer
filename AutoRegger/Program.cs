using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using WindowsInput;
using WindowsInput.Native;
using AutoRegger.Core;
using AutoRegger.Core.Data;
using HWND = System.IntPtr;

namespace AutoRegger
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailPool.Load();
            NicknamePool.Load();
            KeysPool.Load();
            
            var process = Process.GetProcessById(12864);
            HWND mainWindow = process.MainWindowHandle;

            var window = new Window(mainWindow);
            window.Bounds = new Rect() {Left = 2200, Top = 0, Right = 2200 + 1000, Bottom = 1000};
            
            var regger = new Regger(window);
            regger.NextState();
            
            Console.ReadKey();
        }
    }
}