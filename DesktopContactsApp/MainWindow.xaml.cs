using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void NewContact(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();//实例化另一个窗口
            newContactWindow.ShowDialog();//展示窗口
            ReadDatabase();
        }

        void ReadDatabase()
        {
            List<Contact> contacts;
            using (SQLite.SQLiteConnection connection = new SQLite. SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                 contacts = connection.Table<Contact>().ToList();//从数据库中读取数据
            }

            foreach (var contact in contacts)
            {
                ContactsList.Items.Add(new ListViewItem()
                    {
                        Content = contact
                    }
                );
            }
        }
    }
}
