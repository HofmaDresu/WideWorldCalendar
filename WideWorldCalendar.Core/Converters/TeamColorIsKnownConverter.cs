using System;
using System.Globalization;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
    public class TeamColorIsKnownConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var xamColor = value as Color?;
            var systemColor = value as System.Drawing.Color?;
            return (xamColor.HasValue && xamColor.Value.A != 0)
                || (systemColor.HasValue && systemColor.Value.A != 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
