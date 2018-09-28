using System;
using MvvmHelpers;

namespace WideWorldCalendar.ViewModels
{
	public class SelectScheduleViewModel : BaseViewModel
	{
	    private bool _seasonSelected;
        public bool SeasonSelected
        {
            get
            {
                return _seasonSelected;
            }
            set
            {
                SetProperty(ref _seasonSelected, value);
            }
        }

        private bool _leagueSelected;
        public bool LeagueSelected
        {
            get
            {
                return _leagueSelected;
            }
            set
            {
                SetProperty(ref _leagueSelected, value);
            }
        }

        private bool _teamSelected;
        public bool TeamSelected
        {
            get
            {
                return _teamSelected;
            }
            set
            {
                SetProperty(ref _teamSelected, value);
            }
        }
    }
}
