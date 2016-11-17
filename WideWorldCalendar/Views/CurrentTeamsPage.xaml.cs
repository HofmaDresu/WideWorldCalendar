using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class CurrentTeamsPage : ContentPage
    {
        public CurrentTeamsPage()
        {
            InitializeComponent();
            BindingContext = new CurrentTeamsViewModel(Navigation);
        }
    }
}
