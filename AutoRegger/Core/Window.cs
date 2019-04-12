using System;
using System.Drawing;

namespace AutoRegger.Core
{
    using HWND = IntPtr;

    public class Window
    {
        private HWND _hwnd;

        public Rect Bounds
        {
            get
            {
                var rect = new Rect();
                User32Native.GetWindowRect(_hwnd, ref rect);
                return rect;
            }
            set =>
                User32Native.MoveWindow(_hwnd, value.Left, value.Top,
                    value.Right - value.Left,
                    value.Bottom - value.Top,
                    true);
        }
        
        public Point Position
        {
            get
            {
                var rect = Bounds;
                return new Point(rect.Left, rect.Top);
            }
            set
            {
                var rect = Bounds;

                var sx = value.X - rect.Left;
                var sy = value.Y - rect.Top;

                rect.Left += sx;
                rect.Right += sx;
                rect.Top += sy;
                rect.Bottom += sy;

                Bounds = rect;
            }
        }

        public void Offset(Point point)
        {
            var position = Position;
            position.Offset(point);
            Position = position;
        }

        public Window(HWND hwnd)
        {
            this._hwnd = hwnd;
        }

        public void Click(Point point)
        {
            var pos = Position;
            pos.Offset(point);
            User32Native.LeftMouseClick(pos.X, pos.Y);
        }
    }
}