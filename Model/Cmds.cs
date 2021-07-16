using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQClient.Model
{
    /* 骑管家协议 */

    class Cmds
    {
        //数据校验
        protected static byte[] CheckData(byte[] data)
        {
            data[data.Length - 1] = data[0];

            for (int i = 1; i < data.Length - 1; i++)
            {
                data[data.Length - 1] = (byte)(data[data.Length - 1] ^ data[i]);
            }

            return data;
        }

        //开启识别
        public static byte[] CMD_START_RECOGNIZE()
        {
            //byte[] data = new byte[8] { 0xA5, 0x5A, 0x04, 0x03, 0x00, 0x00, 0x00, 0x00 };
            byte[] data = new byte[8] { 0xA5, 0x5A, 0x01, 0x03, 0x00, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }

        //关闭识别
        public static byte[] CMD_STOP_RECOGNIZE()
        {
            //byte[] data = new byte[8] { 0xA5, 0x5A, 0x04, 0x05, 0x00, 0x00, 0x00, 0x00 };
            byte[] data = new byte[8] { 0xA5, 0x5A, 0x01, 0x05, 0x00, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }

        //人脸录入
        public static byte[] CMD_REGISTER_ID(byte idxP, byte idxF)
        {
            byte id = (byte)(idxP << 4 | idxF);
            byte[] data = new byte[8] { 0xA5, 0x5A, 0x01, 0x01, id, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }

        //人脸删除
        public static byte[] CMD_DELETE_ID(byte idxP, byte idxF)
        {
            byte id = (byte)(idxP << 4 | idxF);
            byte[] data = new byte[8] { 0xA5, 0x5A, 0x01, 0x02, id, 0x00, 0x00, 0x00 };
            return CheckData(data);
        }

        //JPEG人脸录入
        public static byte[] CMD_REGISTER_JPEG_ID(byte idxP, byte idxF, uint length)
        {
            byte id = (byte)(idxP << 4 | idxF);
            byte[] data = new byte[8] { 0xA5, 0x5A, 0x01, 0x06, id, 0x00, 0x00, 0x00 };
            data[5] = (byte)((length & 0xFF00) >> 8);
            data[6] = (byte)(length & 0x00FF);
            return CheckData(data);
        }

        public static string ExplainCMD(byte[] data)
        {
            string str = string.Empty;

            if (data.Length == 8 && data[0] == 0xA5 && data[1] == 0x5A)
            {
                byte check = data[0];
                for (int i = 1; i < 7; i++)
                {
                    check = (byte)(check ^ data[i]);
                }

                if (check == data[7])
                {
                    switch (data[2])
                    {
                        case 0x01:
                            switch (data[3])
                            {
                                case 0x01: str = $"录入人脸 ID=0x{data[4]:X2}"; break;
                                case 0x02: str = $"删除人脸 ID=0x{data[4]:X2}"; break;
                                case 0x03: str = $"开启人脸识别";break;
                                case 0x05: str = $"关闭人脸识别"; break;
                                case 0x06: str = $"JPEG人脸录入 ID=0x{data[4]:X2}";break;
                                default: break;
                            }
                            break;

                        case 0x02:
                            switch (data[3])
                            {
                                case 0x01: str = $"录入人脸 ID=0x{data[4]:X2}{string.Format(data[5] == 0 ? "成功" : "失败")}"; break;
                                case 0x02: str = $"删除人脸 {string.Format(data[4] == 0 ? "成功" : "失败")}"; break;
                                case 0x03: str = $"开启人脸识别{string.Format(data[4] == 0 ? "成功" : "失败")}"; break;
                                case 0x05: str = $"关闭人脸识别{string.Format(data[4] == 0 ? "成功" : "失败")}"; break;
                                case 0x06: str = $"AI模块JPEG人脸录入{string.Format(data[4] == 0 ? "已就绪" : "未就绪")}"; break;
                                default: break;
                            }
                            break;

                        case 0x04:
                            switch (data[3])
                            {
                                case 0x03: str = "开启人脸识别"; break;
                                case 0x04: str = $"识别到人脸 ID=0x{data[4]:X2}"; break;
                                case 0x05: str = "关闭人脸识别"; break;
                                case 0x07: str = $"人脸文件录入 ID=0x{data[4]:X2} {string.Format(data[5] == 0 ? "成功" : "失败")}"; break;
                                default: break;
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    str = "数据包校验包不匹配";
                }
            }
            else
            {
                str = "数据包格式不匹配";
            }

            return str;
        }
    }
}
