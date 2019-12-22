using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string DatabaseName = "Contacts.db";//定义数据库的名字
        public static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//电脑中的我的文档文件夹
        public static string DatabasePath = System.IO.Path.Combine(FolderPath, DatabaseName);//数据库所在的文件夹
    }
}
