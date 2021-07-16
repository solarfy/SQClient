using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace SQClient.Model
{
    class LocalCamera
    {
        FilterInfoCollection videoDevices;
        FilterInfo selectedDevice;
        VideoCaptureDevice videoSource;

        public LocalCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDevice = videoDevices[0];
        }

        public void Open()
        {
            if (selectedDevice != null)
            {
                videoSource = new VideoCaptureDevice(selectedDevice.MonikerString);
                videoSource.NewFrame += VideoOnNewFrame;
                videoSource.Start();
            }
        }

        public void Close()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.NewFrame -= VideoOnNewFrame;
            }
        }

        public void TakePicture()
        {
            
        }

        private void VideoOnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //try
            //{
            //    BitmapImage bi;

            //    using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
            //    {
            //        bi = bitmap.ToBitmapImage();
            //    }
            //}
        }

    }
}
