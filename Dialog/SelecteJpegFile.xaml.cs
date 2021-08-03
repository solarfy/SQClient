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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace SQClient.Dialog
{
    /// <summary>
    /// SelecteJpegFile.xaml 的交互逻辑
    /// </summary>
    public partial class SelecteJpegFile : Window
    {
        const string strFilter = "Jpeg files (*.jpeg; *.jpg)|*.jpeg; *.jpg|All files (*.*)|*.*";

        FileInfo tmpSelectFile;

        public FileInfo SelectedFile { private set; get; }        
        public byte[] SelectedFileStream { private set; get; }

        public SelecteJpegFile()
        {
            InitializeComponent();
        }

        private void SelecteFileOnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = strFilter;

            if ((bool)dlg.ShowDialog(Application.Current.MainWindow))
            {
                try
                {
                    FileStream stream = new FileStream(dlg.FileName, FileMode.Open);
                    SelectedFileStream = new byte[stream.Length];                    
                    stream.Read(SelectedFileStream, 0, SelectedFileStream.Length);
                    stream.Close();

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(SelectedFileStream);
                    bitmap.EndInit();
                    this.img.Source = bitmap;

                    tmpSelectFile = new FileInfo(dlg.FileName);                    
                    this.txtFile.Text = tmpSelectFile.FullName;
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"打开文件出错：{exc.Message}", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);                    
                }
            }
        }

        private void ConfirmOnClick(object sender, RoutedEventArgs e)
        {
            SelectedFile = tmpSelectFile;
            this.Close();
        }
    }
}
