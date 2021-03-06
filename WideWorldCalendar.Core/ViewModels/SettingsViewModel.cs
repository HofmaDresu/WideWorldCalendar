﻿using System;
using System.Collections.Generic;
using System.Linq;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;

namespace WideWorldCalendar.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly Data _data;
        private readonly List<Meridian> _meridianOptions = Enum.GetValues(typeof(Meridian)).Cast<Meridian>().ToList();
        private readonly List<DayPreference> _dayOptions = Enum.GetValues(typeof(DayPreference)).Cast<DayPreference>().ToList();

        public SettingsViewModel()
        {
            _data = Data.GetInstance();
            ShowGameNotifications = _data.ShowGameNotifications();
            ShowScheduleChangedNotifications = _data.ShowScheduleChangedNotifications();
            ShowNewSeasonAvailableNotifications = _data.ShowNewSeasonAvailableNotifications();

            var gameNotificationPreferences = _data.GetGameNotificationPreferences();

            _selectedHourIndex = gameNotificationPreferences.Hour - 1;
            _selectedMeridianIndex = _meridianOptions.IndexOf(gameNotificationPreferences.Meridian);
            _selectedDayIndex = _dayOptions.IndexOf(gameNotificationPreferences.Day);
        }

        private bool _showGameNotifications;
        public bool ShowGameNotifications
        {
            get
            {
                return _showGameNotifications;
            }
            set
            {
                SetProperty(ref _showGameNotifications, value);
                _data.SetShowGameNotifications(value);
            }
        }

        private bool _showScheduleChangedNotifications;
        public bool ShowScheduleChangedNotifications
        {
            get
            {
                return _showScheduleChangedNotifications;
            }
            set
            {
                SetProperty(ref _showScheduleChangedNotifications, value);
                _data.SetShowScheduleChangedNotifications(value);
            }
        }

        private bool _showNewSeasonAvailableNotifications;
        public bool ShowNewSeasonAvailableNotifications
        {
            get
            {
                return _showNewSeasonAvailableNotifications;
            }
            set
            {
                SetProperty(ref _showNewSeasonAvailableNotifications, value);
                _data.SetShowNewSeasonAvailableNotifications(value);
            }
        }

        private int _selectedHourIndex;
        public int SelectedHourIndex
        {
            get
            {
                return _selectedHourIndex;
            }
            set
            {
                SetProperty(ref _selectedHourIndex, value);
                SetGameNotificationPreference();
            }
        }

        private int _selectedMeridianIndex;
        public int SelectedMeridianIndex
        {
            get
            {
                return _selectedMeridianIndex;
            }
            set
            {
                SetProperty(ref _selectedMeridianIndex, value);
                SetGameNotificationPreference();
            }
        }

        private int _selectedDayIndex;
        public int SelectedDayIndex
        {
            get
            {
                return _selectedDayIndex;
            }
            set
            {
                SetProperty(ref _selectedDayIndex, value);
                SetGameNotificationPreference();
            }
        }

        public List<int> HourOptions { get; } = Enumerable.Range(1, 12).ToList();

        public List<string> MeridianDisplayOptions
        {
            get { return _meridianOptions.Select(m =>
            {
                switch (m)
                {
                    case Meridian.Am:
                        return "am";
                    case Meridian.Pm:
                        return "pm";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(m), m, null);
                }
            }).ToList();
            }
        }

        public List<string> DayDisplayOptions
        {
            get { return _dayOptions.Select(m =>
            {
                switch (m)
                {
                    case DayPreference.TheDayOfTheGame:
                        return "the day of the game";
                    case DayPreference.TheDayBeforeTheGame:
                        return "the day before the game";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(m), m, null);
                }
            }).ToList();
            }
        }

        private void SetGameNotificationPreference()
        {
            var currentGameNotificationPreferences = _data.GetGameNotificationPreferences();
            var preferencesHaveChanged = currentGameNotificationPreferences.Hour != HourOptions[_selectedHourIndex]
                || currentGameNotificationPreferences.Meridian != _meridianOptions[_selectedMeridianIndex]
                || currentGameNotificationPreferences.Day != _dayOptions[_selectedDayIndex];

            _data.SetGameNotificationPreferences(new GameNotificationPreference
            {
                Hour = HourOptions[_selectedHourIndex],
                Meridian = _meridianOptions[_selectedMeridianIndex],
                Day = _dayOptions[_selectedDayIndex]
            });

            if (preferencesHaveChanged) DependencyService.Get<ILocalNotification>().ScheduleGameNotifications();
        }
    }
}
