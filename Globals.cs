using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQClient.Properties;

namespace SQClient
{
    class Globals
    {
        //波特率
        public static int BaundRate = Settings.Default.BaudRate;

        //协议版本 （0.4/1.0）
        public static string ProtocolVersion = Settings.Default.ProtocolVersion;
    }
}
