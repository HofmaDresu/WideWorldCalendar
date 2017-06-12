using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
    public class LastGameBarIsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            var list = ((ListView)parameter).ItemsSource.Cast<object>().ToList();
            var index = list.IndexOf(value);
            return index == list.Count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
