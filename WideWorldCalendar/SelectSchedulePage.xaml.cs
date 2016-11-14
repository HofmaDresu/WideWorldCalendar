using System;
using System.Collections.Generic;
using System.Linq;
using WideWorldCalendar.ScheduleFetcher;
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
		public SelectSchedulePage()
		{
			InitializeComponent();
			_scheduleFetcher = new MockScheduleFetcher();
			Title = "Select Team";

			GetScheduleButton.Clicked += (sender, e) => Navigation.PushAsync(new ViewSchedulePage(_teams[TeamPicker.SelectedIndex].Id));
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			_seasons = await _scheduleFetcher.GetSeasons();

			foreach (var season in _seasons)
			{
				SeasonPicker.Items.Add(season);
			}

			if (_seasons.Count == 1)
			{
				_leagues = await _scheduleFetcher.GetScheduleGroupings(_seasons.Last());
				foreach (var league in _leagues)
				{
					LeaguePicker.Items.Add(league);
				}

				LeaguePicker.IsEnabled = true;
			}
		}

		async void SeasonChanged(object sender, System.EventArgs e)
		{
			_leagues = await _scheduleFetcher.GetScheduleGroupings(_seasons[SeasonPicker.SelectedIndex]);
			LeaguePicker.Items.Clear();
			foreach (var league in _leagues)
			{
				LeaguePicker.Items.Add(league);
			}
			LeaguePicker.IsEnabled = true;
			DivisionPicker.IsEnabled = false;
			TeamPicker.IsEnabled = false;
			GetScheduleButton.IsEnabled = false;
		}

		async void LeagueChanged(object sender, System.EventArgs e)
		{
			_divisions = await _scheduleFetcher.GetDivisions(_seasons[SeasonPicker.SelectedIndex], _leagues[LeaguePicker.SelectedIndex]);
			DivisionPicker.Items.Clear();
			foreach (var division in _divisions)
			{
				DivisionPicker.Items.Add(division.Name);
			}

			DivisionPicker.IsEnabled = true;
			TeamPicker.IsEnabled = false;
			GetScheduleButton.IsEnabled = false;
		}

		async void DivisionChanged(object sender, System.EventArgs e)
		{
			_teams = await _scheduleFetcher.GetTeams(_divisions[DivisionPicker.SelectedIndex].Id);
			TeamPicker.Items.Clear();
			foreach (var team in _teams)
			{
				TeamPicker.Items.Add(team.Name);
			}

			TeamPicker.IsEnabled = true;
			GetScheduleButton.IsEnabled = false;
		}

		void TeamChanged(object sender, System.EventArgs e)
		{
			GetScheduleButton.IsEnabled = true;
		}
	}
}
