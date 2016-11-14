using System;
using System.Collections.Generic;
using System.Linq;
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
		private SelectScheduleViewModel _vm = new SelectScheduleViewModel();

		public SelectSchedulePage()
		{
			InitializeComponent();
			_scheduleFetcher = new RestScheduleFetcher();
			Title = "Select Team";

			GetScheduleButton.Clicked += (sender, e) => Navigation.PushAsync(new ViewSchedulePage(_teams[TeamPicker.SelectedIndex].Id));
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			_vm.SchedulePageHtml = await _scheduleFetcher.GetSchedulesPage();
			_seasons = _scheduleFetcher.GetSeasons(_vm.SchedulePageHtml);

			foreach (var season in _seasons)
			{
				SeasonPicker.Items.Add(season);
			}

			if (_seasons.Count == 1)
			{
				_leagues = _scheduleFetcher.GetScheduleGroupings(_vm.SchedulePageHtml, _seasons.Last());
				foreach (var league in _leagues)
				{
					LeaguePicker.Items.Add(league);
				}

				LeaguePicker.IsEnabled = true;
			}
		}

		void SeasonChanged(object sender, EventArgs e)
		{
			_leagues = _scheduleFetcher.GetScheduleGroupings(_vm.SchedulePageHtml, _seasons[SeasonPicker.SelectedIndex]);
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

		void LeagueChanged(object sender, EventArgs e)
		{
			_divisions = _scheduleFetcher.GetDivisions(_vm.SchedulePageHtml, _seasons[SeasonPicker.SelectedIndex], _leagues[LeaguePicker.SelectedIndex]);
			DivisionPicker.Items.Clear();
			foreach (var division in _divisions)
			{
				DivisionPicker.Items.Add(division.Name);
			}

			DivisionPicker.IsEnabled = true;
			TeamPicker.IsEnabled = false;
			GetScheduleButton.IsEnabled = false;
		}

		async void DivisionChanged(object sender, EventArgs e)
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

		void TeamChanged(object sender, EventArgs e)
		{
			GetScheduleButton.IsEnabled = true;
		}
	}
}
