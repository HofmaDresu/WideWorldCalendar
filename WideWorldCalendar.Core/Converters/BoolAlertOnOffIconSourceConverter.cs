using System;
using System.Globalization;
using WideWorldCalendar.Persistence;
using Xamarin.Forms;

namespace WideWorldCalendar.Converters
{
	public class BoolAlertOnOffIconSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var alertIsOn = (bool)value;
			return alertIsOn && Data.GetInstance().ShowGameNotifications() ? "icon_alarm.png" : "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
