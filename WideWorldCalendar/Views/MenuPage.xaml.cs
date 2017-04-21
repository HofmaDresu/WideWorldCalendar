using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        private const string MyTeamsTitle = "My Teams";
        private readonly Stack<Page> _pageHistory = new Stack<Page>();
        private readonly ObservableCollection<MasterPageItemViewModel> _masterPageItems = new ObservableCollection<MasterPageItemViewModel>
        {
            new MasterPageItemViewModel
            {
                Title = MyTeamsTitle,
                TargetType = typeof (CurrentTeamsPage),
                IsSelected = true
            },
            new MasterPageItemViewModel
            {
                Title = "Settings",
                TargetType = typeof(SettingsPage),
                IsSelected = false
            }
        };

        public MenuPage()
        {
            InitializeComponent();
			Detail = new NavigationPage(new CurrentTeamsPage())
			{
				BarTextColor = Color.White
			};            

            MenuList.SelectedItem = _masterPageItems.First();

            MenuList.ItemsSource = _masterPageItems;
            MenuList.ItemSelected += OnItemSelected;
            MenuList.SelectedItem = null;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItemViewModel;
            MenuList.SelectedItem = null;
            
            if (item != null)
            {
                SetSelectedItem(item);

                Page targetPage;
                if (item.Title == MyTeamsTitle)
                {
                    targetPage = _pageHistory.ElementAtOrDefault(0) ?? Detail;
                    _pageHistory.Clear();
                }
                else
                {
                    targetPage = new NavigationPage((Page)Activator.CreateInstance(item.TargetType))
                    {
                        BarTextColor = Color.White
                    };
                    _pageHistory.Push(Detail);
                }

                Detail = targetPage;
                IsPresented = false;
            }
        }

        private void SetSelectedItem(MasterPageItemViewModel item)
        {
            foreach (var page in _masterPageItems)
            {
                page.IsSelected = item.Title == page.Title;
            }

            // ********************************************
            // HACK: Horrible hack to make iOS work
            MenuList.ItemsSource = null;
            MenuList.ItemsSource = _masterPageItems;
            // ********************************************
        }

        protected override bool OnBackButtonPressed()
        {
            if (IsPresented)
            {
                IsPresented = false;
                return true;
            }
            if (_pageHistory.Count == 0)
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                var previousPage = _pageHistory.Pop();
                Detail = previousPage;
                return true;
            }
        }
    }
}
