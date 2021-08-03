using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQClient.Model
{
    /* 开发者自定义协议 */

    class TestCmds : Cmds
    {
        public static byte[] CMD_GET_JPEG()
        {            
            byte[] data = new byte[8] { 0xA5, 0x5A, (byte)'S', 0x00, 0x00, 0x00, 0x00, 0x00 };
            return CheckData(data);            
        }
       
        public static byte[] CMD_SET_JPEG(UInt32 length)
        {
            byte[] data = new byte[8] { 0xA5, 0x5A, (byte)'R', 0x00, 0x00, 0x00, 0x00, 0x00 };           
            data[3] = (byte)((0xff << 24 & length) >> 24);
            data[4] = (byte)((0xff << 16 & length) >> 16);
            data[5] = (byte)((0xff << 8 & length) >> 8);
            data[6] = (byte)(0xff & length);
            return CheckData(data);    
        }

        public static byte[] CMD_RGB565()
        {
            byte[] data = new byte[8] { 0xA5, 0x5A, (byte)'T', 0x00, 0x00, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }

        public static byte[] CMD_JPEG_RGB565()
        {
            byte[] data = new byte[8] { 0xA5, 0x5A, (byte)'G', 0x00, 0x00, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }

        public static byte[] CMD_REGISTER()
        {
            byte[] data = new byte[8] { 0xA5, 0x5A, (byte)'C', 0x00, 0x00, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }
    }
}
