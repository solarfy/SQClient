using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQClient.Model;

namespace SQClient.Pages
{
    /// <summary>
    /// DisplayDataStream.xaml 的交互逻辑
    /// </summary>
    public partial class DisplayDataStream : BaseUart
    {
        public DisplayDataStream()
        {
            InitializeComponent();          
        }

        private void RTX(string tag, byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString(@"HH:mm:ss.fff"));
            sb.Append("  ");
            sb.Append($"{tag}: ");
            foreach (byte b in data)
            {
                sb.Append("0x");
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }
            sb.Append(Cmds.ExplainCMD(data));

            this.Dispatcher.Invoke(new Action(() =>
            {
                TextBlock txtblk = new TextBlock() { Text = sb.ToString() };
                txtblk.Foreground = (tag == "TX") ? Brushes.Green : Brushes.Orange;
                this.lstboxHis.Items.Add(txtblk);
                this.lstboxHis.ScrollIntoView(txtblk);
            }));

            if (tag == "TX")
            {                
                Write(data);
            }
        }

        protected override void OnDataReceived()
        {
            base.OnDataReceived();

            byte[] dvalue = new byte[8];

            if (ListRead.Count > 7)     //分割数据包
            {
                for (int i = 0; i < ListRead.Count; i++)
                {
                    if ((ListRead[i] == 0xA5) && (ListRead[i + 1] == 0x5A) && ((i + 7) < ListRead.Count))
                    {
                        Array.Copy(ListRead.ToArray(), i, dvalue, 0, 8);
                        RTX("RX", dvalue);

                        ListRead.RemoveRange(0, i + 8);
                    }
                }
            }

            System.Threading.Thread.Sleep(200);
        }

        protected override void PageOnLoaded(object sender, RoutedEventArgs e)
        {
            base.PageOnLoaded(sender, e);

            this.comboPort.ItemsSource = GetPortNames();
            this.comboPort.SelectedIndex = GetPortNames().Length - 1;
        }

        private void ConnectOnClick(object sender, RoutedEventArgs e)
        {
            bool isDoConnect = this.tglbtnConnect.IsChecked == true;

            if (isDoConnect) //连接
            {
                if (this.comboPort.SelectedItem == null)
                {
                    MessageBox.Show("请先选择端口", this.Title, MessageBoxButton.OK);
                    this.tglbtnConnect.IsChecked = false;
                    return;
                }

                try
                {
                    Connect(this.comboPort.SelectedItem.ToString());
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"串口初始化出错：{exc.Message}", this.Title, MessageBoxButton.OK);
                    this.tglbtnConnect.IsChecked = false;
                    return;
                }

                this.tglbtnConnect.Content = "断开";
                this.tglbtnRecognize.IsEnabled = true;
                this.btnRegister.IsEnabled = true;
                this.btnDelete.IsEnabled = true;
            }
            else //断开
            {
                Disconnect();

                this.tglbtnConnect.Content = "连接";
                this.tglbtnRecognize.IsEnabled = false;
                this.btnRegister.IsEnabled = false;
                this.btnDelete.IsEnabled = false;
            }
        }

        //开关AI识别
        private void RecognizeOnClick(object sender, RoutedEventArgs e)
        {
            bool isDoStart = this.tglbtnRecognize.IsChecked == true;

            if (AssertPortNull() < 0)
            {
                return;
            }

            if (isDoStart)
            {
                RTX("TX", Cmds.CMD_START_RECOGNIZE());
                this.tglbtnRecognize.Content = "关闭识别";
            }
            else
            {
                RTX("TX", Cmds.CMD_STOP_RECOGNIZE());
                this.tglbtnRecognize.Content = "开启识别";
            }
        }

        //录入人脸
        private void RegisterOnClick(object sender, RoutedEventArgs e)
        {
            if (this.cbxPeople.SelectedIndex == 8 || this.cbxFace.SelectedIndex == 8)
            {
                MessageBox.Show("人脸录入不支持‘F’段录入", this.Title, MessageBoxButton.OK);
                return;
            }

            if (AssertPortNull() < 0)
            {
                return;
            }

            RTX("TX", Cmds.CMD_REGISTER_ID((byte)this.cbxPeople.SelectedIndex, (byte)this.cbxFace.SelectedIndex));
        }

        //删除人脸
        private void DeleteOnClick(object sender, RoutedEventArgs e)
        {
            if (AssertPortNull() < 0)
            {
                return;
            }

            byte idxP = (byte)this.cbxPeople.SelectedIndex;
            byte idxF = (byte)this.cbxFace.SelectedIndex;

            if (idxP > 7)
                idxP = 0x0F;
            if (idxF > 7)
                idxF = 0x0F;

            RTX("TX", Cmds.CMD_DELETE_ID(idxP, idxF));
        }

        private void ClearOnClick(object sender, RoutedEventArgs e)
        {
            this.lstboxHis.BeginInit();
            this.lstboxHis.Items.Clear();
            this.lstboxHis.EndInit();
        }

      
    }
}
