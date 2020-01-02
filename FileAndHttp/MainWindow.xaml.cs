using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Microsoft.Win32;

namespace FileAndHttp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void SelectImageButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog  dialog = new OpenFileDialog();//调用win32 API
            dialog.Filter = "选择.jpg格式文件|*.jpg";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);//初始化目录
            if (dialog.ShowDialog() == true)
            {
                string fileNameWithFullPath = dialog.FileName;
                SelectedImage.Source = new BitmapImage(new Uri(fileNameWithFullPath));

                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Prediction_Key", "your key");//添加头部请求头
                byte[] fileBytes = File.ReadAllBytes(fileNameWithFullPath);

                using ByteArrayContent content = new ByteArrayContent(fileBytes);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");//按照要求，content type需要设置成这样。需要为文件字节流设置content type

           var response  =      client.PostAsync("请求的http Uri", content); //把
            }


         
        }
    }
}
