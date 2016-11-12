using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace WideWorldCalendar
{
	public partial class WideWorldCalendarPage : ContentPage
	{
		private readonly IScheduleFetcher _scheduleFetcher;
		private List<string> _seasons;
		private List<string> _leagues;
		private List<NavigationOption> _divisions;
		private List<NavigationOption> _teams;
		private List<Game> _games;

		public WideWorldCalendarPage()
		{
			InitializeComponent();
		    _scheduleFetcher = new MockScheduleFetcher();
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


			/*
			var scheduleTypes = await scheduleFetcher.GetDivisions(_seasons.Last(), _scheduleGroupings.Last());
			var teams = await scheduleFetcher.GetTeams(scheduleTypes.Last().Id);
			var games = await scheduleFetcher.GetTeamSchedule(teams.Last().Id);
*/
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
		}

		async void TeamChanged(object sender, System.EventArgs e)
		{
		}
	}
}
