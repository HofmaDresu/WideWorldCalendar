﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class MenuPage : MasterDetailPage
    {
        private const string MyTeamsTitle = "My Teams";
        private readonly Stack<Page> _pageHistory = new Stack<Page>();
        private readonly MasterPageItem _currentPage;

        public MenuPage()
        {
            InitializeComponent();
			Detail = new NavigationPage(new CurrentTeamsPage())
			{
				BarTextColor = Color.White
			};

            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = MyTeamsTitle,
                    TargetType = typeof (CurrentTeamsPage)
                },
                new MasterPageItem
                {
                    Title = "Settings",
                    TargetType = typeof(SettingsPage)
                }
            };

            MenuList.SelectedItem = masterPageItems.First();

            BindingContext = _currentPage;

            MenuList.ItemsSource = masterPageItems;
            MenuList.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            
            if (item != null)
            {
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

    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
