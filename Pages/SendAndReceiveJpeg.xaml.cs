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
using System.IO;
using Microsoft.Win32;
using SQClient.Model;
using System.Windows.Threading;

namespace SQClient.Pages
{
    /// <summary>
    /// SendAndReceiveJpeg.xaml 的交互逻辑
    /// </summary>
    public partial class SendAndReceiveJpeg : BaseUart
    {
        const string strFilter = "JPEG files (*.jpg *.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*";
        const uint RGB565Length = 320 * 240 * 2;

        bool? isInReceive = false, isReceiveRgb565 = false;
        uint receiveLen;
        DispatcherTimer timer;
        DateTime startTime;
        string rgb565path;


        public SendAndReceiveJpeg()
        {
            InitializeComponent();
        }

        protected override void PageOnLoaded(object sender, RoutedEventArgs e)
        {
            base.PageOnLoaded(sender, e);

            this.comboPort.ItemsSource = GetPortNames();
            this.comboPort.SelectedIndex = GetPortNames().Length - 1;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (arg1, arg2) =>
            {
                this.textblkTimer.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss\.fff");
                if (receiveLen > 0)
                {
                    this.procbar.Value = 100.0 * ListRead.Count / receiveLen;
                    Application.Current.MainWindow.TaskbarItemInfo.ProgressValue = this.procbar.Value / 100;        //ProgressValue: 0 - 1
                }

                if (this.procbar.Value == this.procbar.Maximum)
                {
                    StopReceive();

                    if (isInReceive == null)
                    {
                        this.img.Source = Tools.ByteArrayToBitmapImage(ListRead.ToArray());
                    }
                    else
                    {
                        System.Drawing.Bitmap bitmap = Tools.BytesRGB565ToBitmap(320, 240, ListRead.ToArray());
                        this.img.Source = Tools.BitmapToBitmapSource(bitmap);
                    }                    
                }
            };
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
                this.btnReceive.IsEnabled = true;                
            }
            else //断开
            {
                Disconnect();

                this.tglbtnConnect.Content = "连接";
                this.btnReceive.IsEnabled = false;                
            }
        }

        private void ReceiveOnClick(object sender, RoutedEventArgs e)
        {            
            ListRead.Clear();
            isInReceive = false;
            Write(TestCmds.CMD_GET_JPEG());            
        }

        private async void SendOnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = strFilter;

            if ((bool)dlg.ShowDialog(Application.Current.MainWindow))
            {
                UInt32 fileLength;
                byte[] read;

                try
                {
                    FileStream file = new FileStream(dlg.FileName, FileMode.Open);
                    fileLength = (UInt32)file.Length;
                    read = new byte[fileLength];
                    file.Read(read, 0, (int)file.Length);
                    this.img.Source = Tools.ByteArrayToBitmapImage(read);
                    file.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"打开文件出错：{exc.Message}", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                Write(TestCmds.CMD_SET_JPEG(fileLength));   //JPE发送G命令
                await Task.Delay(100);
                Write(read);    //JPEG文件流
            }
        }

        void StartReceive()
        {
            startTime = DateTime.Now;
            timer.Start();
            this.btnSaveAs.Dispatcher.Invoke(() => this.btnSaveAs.Visibility = Visibility.Hidden);            
        }

        void StopReceive()
        {
            timer.Stop();

            if (isInReceive == null)
            {
                this.btnSaveAs.Dispatcher.Invoke(() => this.btnSaveAs.Visibility = Visibility.Visible);
            }
        }

        protected override void OnDataReceived()
        {
            base.OnDataReceived();

            if (isReceiveRgb565.Value)
            {
                if (ListRead.Count == RGB565Length)
                {
                    File.WriteAllBytes(rgb565path, ListRead.ToArray());
                    isReceiveRgb565 = null;                    
                }
                return;
            }

            if (isInReceive != null && !isInReceive.Value && ListRead.Count > 7)
            {
                for (int i = 0; i < ListRead.Count; i++)
                {
                    if (i + 7 < ListRead.Count && ListRead[i] == 0xA5 && ListRead[i+1] == 0x5A && ListRead[i+2] == 'S')
                    {
                        receiveLen = (uint)((ListRead[i+3] << 24) | (ListRead[i+4] << 16) | (ListRead[i+5] << 8) | (ListRead[i+6]));    
                        isInReceive = null;
                        ListRead.RemoveRange(0, i + 8); //最后一位为校验位
                        StartReceive();                                            
                        break;
                    }
                }
            }
        }

        private void SaveAsFileOnClick(object sender, RoutedEventArgs e)
        {                
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = strFilter;

            if ((bool)dlg.ShowDialog(Application.Current.MainWindow))
            {
                try
                {
                    FileStream file = new FileStream(dlg.FileName, FileMode.OpenOrCreate);
                    file.Seek(0, SeekOrigin.Begin);
                    file.Write(ListRead.ToArray(), 0, ListRead.Count);
                    file.Flush();
                    file.Close();                     
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"写入文件出错：{exc.Message}", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }                
            }
        }

        private void RegisterOnClick(object sender, RoutedEventArgs e)
        {
            //Write(TestCmds.CMD_REGISTER());
            
            OpenFileDialog dlg = new OpenFileDialog();

            if ((bool)dlg.ShowDialog(Application.Current.MainWindow))
            {               
                Write(TestCmds.CMD_REGISTER());

                //TODO: 发送rbg565流
                //FileStream stream = new FileStream(dlg.FileName, FileMode.Open);

                //byte[] readBuf = new byte[stream.Length];
                //stream.Read(readBuf, 0, readBuf.Length);

                //Write(readBuf);
                //stream.Close();

                byte[] buf = RGB565.GetRGB565Image(dlg.FileName);
                Write(buf);
            }
        }

        private void RGB565OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "txt file|*.txt";

            if ((bool)dlg.ShowDialog(Application.Current.MainWindow))
            {
                rgb565path = dlg.FileName;
                ListRead.Clear();
                isReceiveRgb565 = true;
                StartReceive();
                receiveLen = RGB565Length;

                if ((sender as Button).Tag.ToString() == "JPEG")
                {
                    Write(TestCmds.CMD_JPEG_RGB565());
                }
                else
                {
                    Write(TestCmds.CMD_RGB565());
                }
            }
        }
    }
}
