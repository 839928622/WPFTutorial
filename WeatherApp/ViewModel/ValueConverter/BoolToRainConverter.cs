using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverter
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //从model向视图层传递
            bool IsRaining = (bool)value;
            if (IsRaining)
                return "当前有雨";
            return "当前无降水";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //有些场景下，并不需要这个方法，但是，我们也可以实现以下
            string IsRaining = (string)value;
            return IsRaining == "当前有雨" ? true : (object)false;
        }
    }
}
