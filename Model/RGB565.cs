using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SQClient.Model
{
    class RGB565
    {
        const ushort RGB565_RED = 0xf800;
        const ushort RGB565_GREEN = 0x07e0;
        const ushort RGB565_BLUE = 0x001f;

        const uint RGB888_RED = 0x00ff0000;
        const uint RGB888_GREEN = 0x0000ff00;
        const uint RGB888_BLUE = 0x000000ff;

        static System.Drawing.Color RGB565ToRGB888(ushort rgb565color)
        {
            int cRed = (rgb565color & RGB565_RED) >> 8;
            int cGreen = (rgb565color & RGB565_GREEN) >> 3;
            int cBlue = (rgb565color & RGB565_BLUE) << 3;

            return System.Drawing.Color.FromArgb(cRed, cGreen, cBlue);
        }
        static ushort RGB888ToRgb565(uint n888Color)
        {
            // 获取RGB单色，并截取高位
            ushort cRed = (ushort)((n888Color & RGB888_RED) >> 19);
            ushort cGreen = (ushort)((n888Color & RGB888_GREEN) >> 10);
            ushort cBlue = (ushort)((n888Color & RGB888_BLUE) >> 3);

            ushort color = (ushort)((cRed << 11) + (cGreen << 5) + (cBlue << 0));            

            return color;
        }
        static void ReadRGB565Image(string path)
        {
            var txt = System.IO.File.ReadAllLines(path);
            StringBuilder sb = new StringBuilder();
            foreach (var v in txt)
                sb.Append(v);

            List<ushort> block = new List<ushort>();

            while (sb.Length > 4)
            {
                block.Add(Convert.ToUInt16(sb.ToString(0, 4), 16));
                sb.Remove(0, 4);
            }
            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(320, 240))
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                g.Clear(System.Drawing.Color.Black);

                int x = 0, y = 0;
                foreach (var v in block)
                {
                    bitmap.SetPixel(x, y, RGB565ToRGB888(v));
                    x++;
                    if (x == bitmap.Width)
                    {
                        x = 0;
                        y++;
                    }
                }
                bitmap.Save("picture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        static void ReadRGB565Image2(string path)
        {
            var bytes = System.IO.File.ReadAllBytes(path);

            List<ushort> block = new List<ushort>();

            for (int i = 0; i < bytes.Length - 2; i += 2)
            {
                block.Add(BitConverter.ToUInt16(bytes, i));
            }

            using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(320, 240))
            {
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                g.Clear(System.Drawing.Color.Black);

                int x = 0, y = 0;
                foreach (var v in block)
                {
                    bitmap.SetPixel(x, y, RGB565ToRGB888(v));
                    x++;
                    if (x == bitmap.Width)
                    {
                        x = 0;
                        y++;
                    }
                }
                bitmap.Save("picture.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public static void SaveToRGB565Image(string path)
        {

            uint rgb888;
            ushort rgb565;
            StringBuilder sb = new StringBuilder();
            Color color;
            using (Bitmap bitmap = new Bitmap(path))
            {
                for (int y = 0; y < bitmap.Height; y++)
                    for (int x = 0; x < bitmap.Width - 1; x += 2)
                    {
                        if (x % 16 == 0) sb.Append("\r\n");
                        sb.Append("0x");
                        color = bitmap.GetPixel(x, y);
                        rgb888 = (uint)(color.R << 16) + (uint)(color.G << 8) + (uint)(color.B << 0);
                        rgb565 = RGB888ToRgb565(rgb888);
                        sb.Append(string.Format("{0:X}", rgb565).PadLeft(4, '0'));


                        color = bitmap.GetPixel(x + 1, y);
                        rgb888 = (uint)(color.R << 16) + (uint)(color.G << 8) + (uint)(color.B << 0);
                        rgb565 = RGB888ToRgb565(rgb888);
                        sb.Append(string.Format("{0:X}", rgb565).PadLeft(4, '0'));

                        sb.Append(",");


                    }
            }
            System.IO.File.WriteAllText("liuyan.txt", sb.ToString());

        }

        public static byte[] GetRGB565Image(string path)
        {
            uint rgb888;
            ushort rgb565;
            Color color;
            List<byte> list = new List<byte> { };

            using (Bitmap bitmap = new Bitmap(path))
            {                
                for (int y = 0; y < bitmap.Height; y++)
                    for (int x = 0; x < bitmap.Width - 1; x += 2)
                    {                   
                        color = bitmap.GetPixel(x, y);
                        rgb888 = (uint)(color.R << 16) + (uint)(color.G << 8) + (uint)(color.B << 0);
                        rgb565 = RGB888ToRgb565(rgb888);
                        
                        list.Add((byte)(rgb565 & 0x00FF));
                        list.Add((byte)((rgb565 & 0xFF00) >> 8));
                       
                        color = bitmap.GetPixel(x + 1, y);
                        rgb888 = (uint)(color.R << 16) + (uint)(color.G << 8) + (uint)(color.B << 0);
                        rgb565 = RGB888ToRgb565(rgb888);

                        list.Add((byte)(rgb565 & 0x00FF));
                        list.Add((byte)((rgb565 & 0xFF00) >> 8));
                    }
            }

            return list.ToArray();
        }
    }
}
