using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TreeViews
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class ConvertHelper : IValueConverter
    {
        public static ConvertHelper sInstance = new ConvertHelper();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
