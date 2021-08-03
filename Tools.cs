using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;

namespace SQClient
{
    static class Tools
    {
        public static BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            BitmapImage bmp;
            
            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(byteArray);
                bmp.EndInit();
            }
            catch
            {
                bmp = null;
            }

            return bmp;
        }


        public static Bitmap BytesRGB565ToBitmap(int width, int height, byte[] rgb565)
        {
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
            IntPtr ptrToFirstPixel = bmpData.Scan0;

            Marshal.Copy(rgb565, 0, ptrToFirstPixel, rgb565.Length);
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        public static BitmapSource BitmapToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            System.Windows.Media.Imaging.BitmapSource bs =
                Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return bs;
        }
    }
}
