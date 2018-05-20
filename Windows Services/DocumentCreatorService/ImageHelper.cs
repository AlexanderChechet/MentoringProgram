using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentCreatorService
{
    public class ImageHelper
    {
        private static double maxWidth = 800;
        private static double maxHeight = 500;
        public static Image ResizeImage(Image image)
        {
            int width = image.Width;
            int height = image.Height;
            double scaleWidth = width / maxWidth;
            double scaleHeight = height / maxHeight;
            double scale = 1 / Math.Max(scaleWidth, scaleHeight);
            int newWidth = (int)Math.Round(scale * width);
            int newHeigth = (int)Math.Round(scale * height);
            var bitmap = new Bitmap(newWidth, newHeigth);
            using (var graphix = Graphics.FromImage(bitmap))
            {
                graphix.DrawImage(image, 0, 0, newWidth, newHeigth);
            }
            return bitmap;
        }
    }
}
