using System.Diagnostics;
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

			_vm.IsBusy = true;
			_scheduleFetcher.GetTeamSchedule(_teamId)
							.ContinueWith(data =>
							{
								if (data.IsFaulted || data.IsCanceled)
								{
									if (data.Exception != null) Debug.WriteLine(string.Join("\n", data.Exception.InnerExceptions.Select(e => e.Message)));
									//TODO: Notify user
									return;
								}

								_vm.Games.AddRange(data.Result);
								_vm.Title = data.Result.First()?.MyTeam.Name;
								_vm.IsBusy = false;
							});
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}
