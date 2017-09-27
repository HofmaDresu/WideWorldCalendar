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

            var vm = new TeamScheduleViewModel(selectedTeamId);
            Title = "Schedule";
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
        }
    }
}
