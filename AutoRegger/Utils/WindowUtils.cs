using System;
using System.Text;

namespace AutoRegger.Utils
{
    using HWND = IntPtr;

    public static class WindowUtils
    {
        public static string GetWindowText(HWND window)
        {
            var length = User32Native.GetWindowTextLength(window) + 1;
            var sb = new StringBuilder(length);
            User32Native.GetWindowText(window, sb, length);
            try
            {
                return sb.ToString();
            }
            finally
            {
                sb.Clear();
            }
        }
    }
}