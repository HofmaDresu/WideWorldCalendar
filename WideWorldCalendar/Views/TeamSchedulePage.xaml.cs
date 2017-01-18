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
            BindingContext = new TeamScheduleViewModel(selectedTeam.Id);
            GamesList.ItemSelected += (sender, e) => 
            {
                GamesList.SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IUnifiedAnalytics>().SendScreenHitOnDefaultTracker("Saved Team Schedule");
            DependencyService.Get<IUnifiedAnalytics>().CreateAndSendEventOnDefaultTracker(Constants.AnalyticsCategoryUserAction, Constants.AnalyticsLabelViewTeamSchedule, Title);
        }
    }
}
