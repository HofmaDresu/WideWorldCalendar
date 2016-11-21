using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;

namespace WideWorldCalendar.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly Data _data;

        public SettingsViewModel()
        {
            _data = Data.GetInstance();
            ShowGameNotifications = _data.ShowGameNotifications();
            ShowScheduleChangedNotifications = _data.ShowScheduleChangedNotifications();
            ShowNewSeasonAvailableNotifications = _data.ShowNewSeasonAvailableNotifications();
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
    }
}
