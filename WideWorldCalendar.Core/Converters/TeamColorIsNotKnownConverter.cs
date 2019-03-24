using System;
using System.Globalization;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
    public class TeamColorIsNotKnownConverter : TeamColorIsKnownConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)base.Convert(value, targetType, parameter, culture);
        }
    }
}
