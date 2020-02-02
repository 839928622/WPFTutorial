using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
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
        private readonly SpeechRecognitionEngine recognizer;
        public NotesWindow()
        {
            InitializeComponent();
            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            Grammar grammar = new Grammar(builder);
            var culture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
                           where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                           select r).FirstOrDefault();//获取当前地区
             recognizer = new SpeechRecognitionEngine(culture);
             recognizer.LoadGrammar(grammar);
             recognizer.SetInputToDefaultAudioDevice();
             recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //在这里获取识别的结果
            string recognizedText = e.Result.Text;//语音转文字的结果
            //把结果新起一个段落并附加到富文本框里
            NoteContent.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));
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

        //语音转文字按钮
        bool isRecognizing = false;//是否正在识别的状态
        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRecognizing == false)
            {

                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                isRecognizing = true;
            }
            else
            {
                recognizer.RecognizeAsyncStop();
                isRecognizing = false;
            }
        }
    }
}
