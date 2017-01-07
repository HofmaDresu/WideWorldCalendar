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
			return alertIsOn && Data.GetInstance().ShowGameNotifications() ? "ic_alarm_on.png" : "ic_alarm_off.png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
