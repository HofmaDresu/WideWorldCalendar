using System;
using WideWorldCalendar.UtilityInterfaces;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class CurrentTeamsPage : ContentPage
    {
        private readonly CurrentTeamsViewModel _vm;

        public CurrentTeamsPage()
        {
            InitializeComponent();
            Title = "My Teams";
            _vm = new CurrentTeamsViewModel(Navigation, this);
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm.RefreshTeams();
        }
    }
}
