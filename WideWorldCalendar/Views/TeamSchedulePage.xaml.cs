using System;
using System.Linq;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.UtilityInterfaces;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class TeamSchedulePage : ContentPage
    {
        public TeamSchedulePage(int selectedTeamId)
        {
            InitializeComponent();
            var selectedTeam = Data.GetInstance().GetTeam(selectedTeamId);

            Title = selectedTeam.TeamName;
            var vm = new TeamScheduleViewModel(selectedTeam.Id);
            BindingContext = vm;
            GamesList.ItemSelected += (sender, e) => 
            {
                GamesList.SelectedItem = null;
            };

            GamesList.ScrollTo(vm.InitialDisplayGame, ScrollToPosition.Start, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IUnifiedAnalytics>().SendScreenHitOnDefaultTracker("Saved Team Schedule");
            DependencyService.Get<IUnifiedAnalytics>().CreateAndSendEventOnDefaultTracker(Constants.AnalyticsCategoryUserAction, Constants.AnalyticsLabelViewTeamSchedule, Title);
        }
    }
}
