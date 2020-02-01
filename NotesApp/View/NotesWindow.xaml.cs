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

namespace NotesApp.View
{
    /// <summary>
    /// NotesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();
        }

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RichTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int ammountOfCharacters = (new TextRange(NoteContent.Document.ContentStart, NoteContent.Document.ContentEnd)).Text.Length;//获取富文本框下的字符长度，作为字符数
            AmountOfContent.Text = $"字数：{ ammountOfCharacters }"; //这种用法类似winform
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
             NoteContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty,FontWeights.Bold);//用户选中的文本 然后在其中作用fontweights.bold效果
        }
    }
}
