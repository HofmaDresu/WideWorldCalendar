using System;
using System.Globalization;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
	public class BoolHomeAwayConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var isHome = (bool)value;
			return isHome ? "HOME" : "AWAY";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
