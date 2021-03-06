﻿using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using WideWorldCalendar.UtilityInterfaces;
using System.Collections.Generic;
using WideWorldCalendar.ScheduleFetcher;
using System;
using WideWorldCalendar.Utilities;
using System.Threading.Tasks;

namespace WideWorldCalendar.ViewModels
{
    public class CurrentTeamsViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly IScheduleFetcher _scheduleFetcher;
        private readonly Data _data;

        public CurrentTeamsViewModel(INavigation navigation, Page page)
        {
            _scheduleFetcher = DependencyService.Get<IScheduleFetcher>();
            _data = Data.GetInstance();
            _navigation = navigation;
            AddTeamsCommand = new Command(async _ =>
            {
                await _navigation.PushAsync(new SelectSchedulePage());
            });
            EditTeamCommand = new Command<MyTeam>(async t =>
            {
                var getReminders = await page.DisplayAlert("Game Notifications", $"Would you like game time reminders for {t.TeamName}?", "Yes", "No");

                if (getReminders && !_data.ShowGameNotifications())
                {
                    var activateReminders = await page.DisplayAlert("Game Notifications", $"Game notifications are turned off in settings. Would you like to turn them on?", "Yes", "No");
                    if (activateReminders)
                    {
                        _data.SetShowGameNotifications(true);
                        DependencyService.Get<ILocalNotification>().ScheduleGameNotifications();
                    }
                }

                t.SendGameTimeReminders = getReminders;
                _data.UpdateMyTeam(t);
                RefreshTeams();
            });
            DeleteTeamCommand = new Command<MyTeam>(async t =>
            {
                var confirmDelete = await page.DisplayAlert("Confirm Delete", $"Delete {t.TeamName}?", "Yes", "No");
                if (confirmDelete)
                {
                    _data.DeleteMyTeam(t.Id);
                    RefreshTeams();
                }
            });

            RefreshGamesCommand = new Command(async _ =>
            {
                IsBusy = true;
                await Task.Run(async () =>
                {
                    var teams = _data.GetRecentAndCurrentTeams();
                    var dataFetchTasks = teams.Select(team => _scheduleFetcher.GetTeamSchedule(team.Id)).ToList();
                    try
                    {
                        await Task.WhenAll(dataFetchTasks);
                    }
                    catch (Exception)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            IsBusy = false;
                            await page.DisplayAlert("Network Error", "An error occured while refreshing your teams. Please try again later.", "Ok");
                        });
                        return;
                    }

                    var serverGames = new List<ScheduleFetcher.Game>();
                    foreach (var task in dataFetchTasks)
                    {
                        var teamGames = task.Result;
                        var myTeamId = teamGames.FirstOrDefault()?.MyTeam?.Id;
                        if (!myTeamId.HasValue) continue;
                        
                        serverGames.AddRange(teamGames);
                    }
                    _data.UpdateSchedules(serverGames.Select(DataConverter.ConvertDtoToPersistence).ToList());
                });
                RefreshTeams();
                IsBusy = false;
            });
        }

        private ObservableCollection<Grouping<string, MyTeam>> _teams = new ObservableCollection<Grouping<string, MyTeam>>();
        public ObservableCollection<Grouping<string, MyTeam>> Teams => _teams;

        public ICommand AddTeamsCommand { protected set; get; }
        public ICommand EditTeamCommand { protected set; get; }
        public ICommand DeleteTeamCommand { protected set; get; }
        public ICommand RefreshGamesCommand { protected set; get; }

        public void RefreshTeams()
        {
            var currentTeams = _data.GetMyCurrentTeams().Select(CalculateRecord);

            foreach (var teamGroup in _teams)
            {
                teamGroup.Clear();
            }
            _teams.Clear();

            _teams.Add(new Grouping<string, MyTeam>("CURRENT TEAMS", currentTeams));
            var pastTeams = _data.GetMyPastTeams().OrderByDescending(t => t.LastGameDateTime).Select(CalculateRecord);
            if (pastTeams.Any())
            {
                _teams.Add(new Grouping<string, MyTeam>("PREVIOUS TEAMS", pastTeams));
            }
            OnPropertyChanged(nameof(Teams));
        }

        private MyTeam CalculateRecord(MyTeam t)
        {
            var games = _data.GetGames(t.Id);
            var winCount = games.Where(g => g.WinLoss == Constants.Win).Count();
            var lossCount = games.Where(g => g.WinLoss == Constants.Loss).Count();
            var tieCount = games.Where(g => g.WinLoss == Constants.Tie).Count();
            var team = new MyTeam
            {
                Division = t.Division,
                Id = t.Id,
                LastGameDateTime = t.LastGameDateTime,
                // Let user know record info is unavailable for seasons that predate this feature
                Record = $"{winCount} - {lossCount} - {tieCount}" + (t.LastGameDateTime < new System.DateTime(2017, 01, 06) ? " (record unavailable)" : string.Empty),
                SendGameTimeReminders = t.SendGameTimeReminders,
                Color = t.Color,
                TeamName = t.TeamName
            };
            return team;
        }

	    private MyTeam _selectedTeam;
	    public MyTeam SelectedTeam
	    {
	        get { return _selectedTeam; }
	        set
	        {
	            if (value == null) return;
	            _navigation.PushAsync(new TeamSchedulePage(value.Id));

                SetProperty(ref _selectedTeam, value);
                SetProperty(ref _selectedTeam, null);
	        }
	    }
    }
}
