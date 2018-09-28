using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.ScheduleFetcher;
using WideWorldCalendar.UtilityInterfaces;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar
{
	public partial class SelectSchedulePage : ContentPage
	{
		private readonly IScheduleFetcher _scheduleFetcher;
		private List<NavigationOption> _seasons;
		private Dictionary<string, List<NavigationOption>> _leagueMappings;
		private List<string> _leagues;
		private List<NavigationOption> _teams;
		private readonly SelectScheduleViewModel _vm = new SelectScheduleViewModel();

		public SelectSchedulePage()
		{
			InitializeComponent();
			_scheduleFetcher = DependencyService.Get<IScheduleFetcher>();
			Title = "Select Team";
		    BindingContext = _vm;

			GetScheduleButton.Clicked += (sender, e) => Navigation.PushAsync(new ViewSchedulePage(_teams[TeamPicker.SelectedIndex].Id, _seasons[SeasonPicker.SelectedIndex].Name));
			_vm.IsBusy = true;
			_scheduleFetcher.GetSeasons()
				.ContinueWith(data =>
				{
					if (data.IsFaulted || data.IsCanceled)
					{
						if(data.Exception != null) Debug.WriteLine(string.Join("\n", data.Exception.InnerExceptions.Select(e => e.Message)));
                        Device.BeginInvokeOnMainThread(async () => {
                            await DisplayAlert("Network Error", "There was a problem communicating with the Wide World server. Please try again later", "OK");
                            _vm.IsBusy = false;
                        });
                        return;
					}

                    _seasons = data.Result;
                    Data.GetInstance().UpdateSeasons(_seasons.Select(s => new Season { ScheduleId = s.Id, Name = s.Name }).ToList());


                    Device.BeginInvokeOnMainThread(() => 
					{
						foreach (var season in _seasons)
						{
							SeasonPicker.Items.Add(season.Name);
						}

                        if (_seasons.Count == 1)
                        {
                            SeasonPicker.SelectedIndex = 1;
                        }
					});
                    _vm.IsBusy = false;
				});
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
        }

	    async void SeasonChanged(object sender, EventArgs e)
		{
			if (SeasonPicker.SelectedIndex == -1) return;
            _vm.IsBusy = true;

		    _vm.LeagueSelected = false;
            LeaguePicker.SelectedIndex = -1;
            _vm.TeamSelected = false;
			TeamPicker.SelectedIndex = -1;
            try
            {
                _leagueMappings = await _scheduleFetcher.GetLeagues(_seasons[SeasonPicker.SelectedIndex].Id);
                _leagues = _leagueMappings.Keys.ToList();

                LeaguePicker.Items.Clear();
                foreach (var league in _leagues)
                {
                    LeaguePicker.Items.Add(league);
                }
                _vm.SeasonSelected = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Device.BeginInvokeOnMainThread(async () => {
                    await DisplayAlert("Network Error", "There was a problem communicating with the Wide World server. Please try again later", "OK");
                    _vm.IsBusy = false;
                });
            }
            finally
            {
                _vm.IsBusy = false;
            }
        }

		void LeagueChanged(object sender, EventArgs e)
		{
			if (LeaguePicker.SelectedIndex == -1) return;
            
            _vm.TeamSelected = false;
            TeamPicker.SelectedIndex = -1;


            _teams = _leagueMappings[_leagues[LeaguePicker.SelectedIndex]];
            TeamPicker.Items.Clear();
            foreach (var team in _teams)
            {
                TeamPicker.Items.Add(team.Name);
            }

            _vm.LeagueSelected = true;
        }

		void TeamChanged(object sender, EventArgs e)
		{
			if (TeamPicker.SelectedIndex == -1) return;

            _vm.TeamSelected = true;
        }
	}
}
