using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AutoRegger.Utils
{
    public class ScreenshotUtils
    {
        public static string GetBase64(Point start, Point end)
        {
            var width = end.X - start.X;
            var height = end.Y - start.Y;
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(start, Point.Empty, new Size(width, height));
                }

                var file = Path.ChangeExtension(Path.GetTempFileName(),".jpg");
                bitmap.Save(file, ImageFormat.Jpeg);
                return Convert.ToBase64String(File.ReadAllBytes(file));
            }
        }
    }
}