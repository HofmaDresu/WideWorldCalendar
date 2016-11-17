using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.ViewModels;
using Xamarin.Forms;

namespace WideWorldCalendar.Views
{
    public partial class TeamSchedulePage : ContentPage
    {
        public TeamSchedulePage(MyTeam selectedTeam)
        {
            InitializeComponent();
            Title = selectedTeam.TeamName;
            BindingContext = new TeamScheduleViewModel(selectedTeam.Id);
        }
    }
}
