using System.Globalization;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal _lastNumber,_result;
        private SelectedOperator _selectedOperator;
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
            _result = 0;
            _lastNumber = 0;
        }

        // 所有运算符被单击触发的方法
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(ResultLabel.Content.ToString(),out  _lastNumber))//如果label上的字符可以转换为decimal，那么把值赋给_lastNumber，同时显示0
            {
                ResultLabel.Content = "0";
            }
            //运算符按键点击触发的方法
            if (Equals(sender, MultiButton))
            {
                _selectedOperator = SelectedOperator.Multiplication;
            }

            if (Equals(sender,DivideButton))
            {
                _selectedOperator = SelectedOperator.Division;
            }

            if (Equals(sender,PlusButton))
            {
                _selectedOperator = SelectedOperator.Addition;

            }

            if (Equals(sender,MinusButton))
            {
                _selectedOperator = SelectedOperator.Subtraction;
            }
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(ResultLabel.Content.ToString(), out _lastNumber)) return;
            _lastNumber *= -1;
            ResultLabel.Content = _lastNumber;
        }

        //等于号 被点击
        private void EqualButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(ResultLabel.Content.ToString(), out var newNumber))//如果label上的字符可以转换为decimal，那么把值赋给_lastNumber，同时显示0
            {
                switch (_selectedOperator)
                {
                    case SelectedOperator.Addition:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        _result = SimpleMath.Subtraction(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        _result = SimpleMath.Multiply(_lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        _result = SimpleMath.Divide(_lastNumber, newNumber);
                        break;

                }

                ResultLabel.Content = _result.ToString(CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// 数学符号"."被点击的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString().Contains("."))//确保之前没有输入.
            {
                //如果之前已经输入“.”,我们什么也不做
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}.";//在当前内容后加.
                
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,//加法
        Subtraction,//减法
        Multiplication,//乘法
        Division //除法
    }

    /// <summary>
    /// 封装基本运算 的对象 方法使用静态方法，好处是可以直接使用对象名点出，无需new
    /// </summary>
    public class SimpleMath
    {
        public static decimal Add(decimal n1, decimal n2)
        {
            return n1 + n2;
        }

        public static decimal Subtraction(decimal n1,decimal n2)
        {
            return n1 - n2;
        }

        public static decimal Multiply(decimal n1, decimal n2)
        {
            return n1 * n2;
        }

        public  static decimal Divide(decimal n1, decimal n2)
        {
            if (n2 != 0) return n1 / n2;
            MessageBox.Show("0作为分母是非法的", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            return 0;
        }
    }
}
