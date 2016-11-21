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
                    //TargetType = typeof(TodoListPage)
                }
            };

            MenuList.ItemsSource = masterPageItems;
        }
    }

    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
