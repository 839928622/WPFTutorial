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
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    /// <summary>
    /// NewContactWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NewContactWindow : Window
    {
       

        public NewContactWindow( )
        {
          
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //在保存联系人信息之后，立马关闭窗口。
            Contact contact = new Contact()
            {
                Name = NameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text,
            };


            
            using (
                SQLiteConnection connection = new SQLiteConnection(App.DatabasePath)
                )
            {
                connection.CreateTable<Contact>();//创建Contact表//如果表已经存在，则什么也不会发生
                connection.Insert(contact);//把初始化的数据 插入到sqlite数据库
            }
            // connection.Close();//关闭连接，但是并不是最好的实现方式。
            this. Close();
        }
    }
}
