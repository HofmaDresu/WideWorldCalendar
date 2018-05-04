using System;
using System.Globalization;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
	public class DateTimeDateStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((DateTime)value).ToString("d");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
