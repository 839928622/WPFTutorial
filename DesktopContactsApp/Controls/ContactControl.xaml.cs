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
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// ContactControl.xaml 的交互逻辑
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get => (Contact)GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new  Contact(){Name = "Name"},SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl contactControl = d as ContactControl;// d其实就是ContactControl，因为在Register方法里，ContactControl被传进来了

            if (contactControl != null) contactControl.NameTextBlock.Text = (e.NewValue as Contact)?.Name;
            throw new NotImplementedException();
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
