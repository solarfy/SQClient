using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;

namespace SQClient.Pages
{
    /// <summary>
    /// BaseUart.xaml 的交互逻辑
    /// </summary>
    public abstract partial class BaseUart : Page
    {
        SerialPort SP;
        protected List<byte> ListRead;

        public BaseUart()
        {
            this.Loaded += PageOnLoaded;
            this.Unloaded += PageOnUnloaded;
        }

        public string[] GetPortNames() => SerialPort.GetPortNames();

        public short AssertPortNull()
        {
            if (SP == null || !SP.IsOpen)
            {
                MessageBox.Show("串口未初始化", this.Title, MessageBoxButton.OK);
                return -1;
            }

            return 1;
        }

        public void Connect(string protName)
        {
            SP = new SerialPort();
            SP.PortName = protName;
            //SP.BaudRate = 9600;            
            SP.BaudRate = Globals.BaundRate;
            SP.DataBits = 8;
            SP.Parity = Parity.None;
            SP.StopBits = StopBits.One;
            SP.Open();
            SP.DataReceived += Sp_DataReceived;
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len = SP.BytesToRead;
            byte[] readBuf = new byte[len];

            SP.Read(readBuf, 0, len);

            foreach (byte b in readBuf)
            {
                ListRead.Add(b);    //将读取到的数据加入至ListRead集合中
            }

            OnDataReceived();
        }

        protected virtual void OnDataReceived() { }

        public void Disconnect()
        {
            SP?.Close();
            SP?.Dispose();
            SP = null;
        }

        public void Write(byte[] buffer)
        {
            SP.Write(buffer, 0, buffer.Length);
        }

        public void WritePerByte(byte[] buffer, int cout)
        {
            for (int i = 0; i < buffer.Length; )
            {                
                if (buffer.Length - i < cout)
                    cout = buffer.Length - i;

                SP.Write(buffer, i, cout);
                i += cout;

                System.Threading.Thread.Sleep(10);
            }
        }

        public void DiscardOutBuffer()
        {
            SP.DiscardOutBuffer();
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            SP?.Write(buffer, offset, count);
        }

        private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
        {
            PageOnUnloaded(null, null);
        }

        protected virtual void PageOnLoaded(object sender, RoutedEventArgs e)
        {
            ListRead = new List<byte> { };
            Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;   //Windows在关闭时不会触发Unload事件，此处在ShutdownStarted事件中强制处理
        }

        protected virtual void PageOnUnloaded(object sender, RoutedEventArgs e)
        {
            SP?.Close();
        }
    }
}
