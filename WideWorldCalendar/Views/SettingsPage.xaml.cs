using WideWorldCalendar.UtilityInterfaces;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            var vm = new SettingsViewModel();
            InitializeComponent();

            foreach (var hour in vm.HourOptions)
            {
                HourPicker.Items.Add(hour.ToString());
            }
            foreach (var meridian in vm.MeridianDisplayOptions)
            {
                MeridianPicker.Items.Add(meridian);
            }
            foreach (var day in vm.DayDisplayOptions)
            {
                DayPicker.Items.Add(day);
            }

            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
