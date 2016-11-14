using System;
using System.Collections.Generic;
using System.Linq;
using WideWorldCalendar.ScheduleFetcher;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar
{
	public partial class ViewSchedulePage : ContentPage
	{
		private readonly IScheduleFetcher _scheduleFetcher;
		private int _teamId;
		private ScheduleViewModel _vm = new ScheduleViewModel();

		public ViewSchedulePage(int teamId)
		{
			InitializeComponent();
			_scheduleFetcher = new RestScheduleFetcher();
			Title = "Schedule";
			_teamId = teamId;

			BindingContext = _vm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_scheduleFetcher.GetTeamSchedule(_teamId)
							.ContinueWith(data =>
							{
								if (data.IsFaulted || data.IsCanceled)
								{
									//TODO
									return;
								}

								_vm.Games.AddRange(data.Result);
								_vm.Title = data.Result.First()?.MyTeam.Name;
							});
		}
	}
}
