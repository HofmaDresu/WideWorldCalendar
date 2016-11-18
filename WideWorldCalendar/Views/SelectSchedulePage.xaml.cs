using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.ScheduleFetcher;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar
{
	public partial class SelectSchedulePage : ContentPage
	{
		private readonly IScheduleFetcher _scheduleFetcher;
		private List<string> _seasons;
		private List<string> _leagues;
		private List<NavigationOption> _divisions;
		private List<NavigationOption> _teams;
		private readonly SelectScheduleViewModel _vm = new SelectScheduleViewModel();

		public SelectSchedulePage()
		{
			InitializeComponent();
			_scheduleFetcher = new RestScheduleFetcher();
			Title = "Select Team";
		    BindingContext = _vm;

			GetScheduleButton.Clicked += (sender, e) => Navigation.PushAsync(new ViewSchedulePage(_teams[TeamPicker.SelectedIndex].Id));
			_vm.IsBusy = true;
			_scheduleFetcher.GetSchedulesPage()
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

					_vm.SchedulePageHtml = data.Result;

					_seasons = _scheduleFetcher.GetSeasons(_vm.SchedulePageHtml);
                    Data.GetInstance().UpdateDivisions(_seasons);


                    Device.BeginInvokeOnMainThread(() => 
					{
						foreach (var season in _seasons)
						{
							SeasonPicker.Items.Add(season);
						}
					});

					if (_seasons.Count == 1)
					{
						_leagues = _scheduleFetcher.GetScheduleGroupings(_vm.SchedulePageHtml, _seasons.Last());
						foreach (var league in _leagues)
						{
							LeaguePicker.Items.Add(league);
						}

					    _vm.LeagueSelected = true;
					}
					_vm.IsBusy = false;
				});
		}

		void SeasonChanged(object sender, EventArgs e)
		{
			if (SeasonPicker.SelectedIndex == -1) return;

		    _vm.LeagueSelected = false;
		    _vm.DivisionSelected = false;
            DivisionPicker.SelectedIndex = -1;
            _vm.TeamSelected = false;
			TeamPicker.SelectedIndex = -1;

			_leagues = _scheduleFetcher.GetScheduleGroupings(_vm.SchedulePageHtml, _seasons[SeasonPicker.SelectedIndex]);
			LeaguePicker.Items.Clear();
			foreach (var league in _leagues)
			{
				LeaguePicker.Items.Add(league);
            }
            _vm.SeasonSelected = true;
        }

		void LeagueChanged(object sender, EventArgs e)
		{
			if (LeaguePicker.SelectedIndex == -1) return;
            
            _vm.DivisionSelected = false;
            DivisionPicker.SelectedIndex = -1;
            _vm.TeamSelected = false;
            TeamPicker.SelectedIndex = -1;

            _divisions = _scheduleFetcher.GetDivisions(_vm.SchedulePageHtml, _seasons[SeasonPicker.SelectedIndex], _leagues[LeaguePicker.SelectedIndex]);
			DivisionPicker.Items.Clear();
			foreach (var division in _divisions)
			{
				DivisionPicker.Items.Add(division.Name);
			}

            _vm.LeagueSelected = true;
        }

		async void DivisionChanged(object sender, EventArgs e)
		{
			if (DivisionPicker.SelectedIndex == -1) return;
			_vm.IsBusy = true;
            
            _vm.TeamSelected = false;
            TeamPicker.SelectedIndex = -1;

            try
			{
				_teams = await _scheduleFetcher.GetTeams(_divisions[DivisionPicker.SelectedIndex].Id);
				TeamPicker.Items.Clear();
				foreach (var team in _teams)
				{
					TeamPicker.Items.Add(team.Name);
				}

                _vm.DivisionSelected = true;
            }
			catch (Exception ex)
            {
                await DisplayAlert("Network Error", "There was a problem communicating with the Wide World server. Please try again later", "OK");
            }
			finally
			{
                _vm.IsBusy = false;
			}
		}

		void TeamChanged(object sender, EventArgs e)
		{
			if (TeamPicker.SelectedIndex == -1) return;

            _vm.TeamSelected = true;
        }
	}
}
