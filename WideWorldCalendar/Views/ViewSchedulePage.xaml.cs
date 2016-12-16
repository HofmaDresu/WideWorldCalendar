using System.Diagnostics;
using System.Linq;
using WideWorldCalendar.ScheduleFetcher;
using WideWorldCalendar.UtilityInterfaces;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar
{
	public partial class ViewSchedulePage : ContentPage
	{
		private readonly IScheduleFetcher _scheduleFetcher;
		private readonly int _teamId;
		private readonly ScheduleViewModel _vm;

		public ViewSchedulePage(int teamId)
		{
			InitializeComponent();
            _scheduleFetcher = DependencyService.Get<IScheduleFetcher>();
            Title = "Schedule";
			_teamId = teamId;
		    _vm = new ScheduleViewModel(this);


            BindingContext = _vm;

			_vm.IsBusy = true;
			_scheduleFetcher.GetTeamSchedule(_teamId)
							.ContinueWith(data =>
							{
								if (data.IsFaulted || data.IsCanceled)
								{
									if (data.Exception != null) Debug.WriteLine(string.Join("\n", data.Exception.InnerExceptions.Select(e => e.Message)));
                                    Device.BeginInvokeOnMainThread(async () => {
                                        await DisplayAlert("Network Error", "There was a problem communicating with the Wide World server. Please try again later", "OK");
                                        _vm.IsBusy = false;
                                    });
                                    return;
								}

								_vm.Games.AddRange(data.Result);
								_vm.Title = data.Result.First()?.MyTeam.Name;
                                DependencyService.Get<IUnifiedAnalytics>().CreateAndSendEventOnDefaultTracker(Constants.AnalyticsCategoryUserAction, Constants.AnalyticsLabelViewTeamSchedule, _vm.Title);
                                _vm.IsBusy = false;
							});
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            DependencyService.Get<IUnifiedAnalytics>().SendScreenHitOnDefaultTracker("Server Team Schedule");
        }
	}
}
