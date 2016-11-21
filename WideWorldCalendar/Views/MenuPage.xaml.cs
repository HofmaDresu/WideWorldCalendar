using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new CurrentTeamsPage());

            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "My Teams",
                    TargetType = typeof (CurrentTeamsPage)
                },
                new MasterPageItem
                {
                    Title = "Settings",
                    TargetType = typeof(SettingsPage)
                }
            };

            MenuList.ItemsSource = masterPageItems;
            MenuList.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MenuList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }

    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
