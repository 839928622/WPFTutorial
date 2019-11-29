using System.Windows;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal _lastNumber,result;
        private SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
        }

        //所有的数字键被点击将触发该事件
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
             var selectedValue = 0;
            if (Equals(sender, ZeroButton))
            {
                selectedValue = 0;
            }
            if (Equals(sender, OneButton))
            {
                selectedValue = 1;
            }
            if (Equals(sender, TwoButton))
            {
                selectedValue = 2;
            }
            if (Equals(sender, ThreeButton))
            {
                selectedValue = 3;
            }
            if (Equals(sender, FourButton))
            {
                selectedValue = 4;
            }
            if (Equals(sender, FiveButton))
            {
                selectedValue = 5;
            }
            if (Equals(sender, SixButton))
            {
                selectedValue = 6;
            }
            if (Equals(sender, SevenButton))
            {
                selectedValue = 7;
            }
            if (Equals(sender, EightButton))
            {
                selectedValue = 8;
            }
            if (Equals(sender, NineButton))
            {
                selectedValue = 9;
            }
         
            ResultLabel.Content = ResultLabel.Content.ToString() == "0" ? $"{selectedValue}" : $"{ResultLabel.Content}{selectedValue}";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(ResultLabel.Content.ToString(), out _lastNumber)) return;
            _lastNumber *= -1;
            ResultLabel.Content = _lastNumber;
        }
    }

    public enum SelectedOperator
    {
        Addition,//加法
        Subtraction,//减法
        Multiplication,//乘法
        Division //除法
    }
}
