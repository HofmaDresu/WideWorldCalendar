using System;
using MvvmHelpers;

namespace WideWorldCalendar.ViewModels
{
	public class SelectScheduleViewModel : BaseViewModel
	{
		private string _schedulePageHtml;
		public string SchedulePageHtml
		{
			get
			{
				return _schedulePageHtml;
			}
			set
			{
				SetProperty(ref _schedulePageHtml, value);
			}
		}
	}
}
