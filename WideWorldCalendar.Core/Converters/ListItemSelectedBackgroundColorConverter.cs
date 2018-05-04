using System;
using System.Globalization;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
    public class ListItemSelectedBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Colors.PrimarySelected : Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
