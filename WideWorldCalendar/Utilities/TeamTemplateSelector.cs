using System;
using WideWorldCalendar.Persistence.Models;
using Xamarin.Forms;

namespace WideWorldCalendar.Utilities
{
    public class TeamTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CurrentTeamTemplate { get; set; }
        public DataTemplate PreviousTeamTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((MyTeam)item).LastGameDateTime.Date >= DateTime.Now.Date ? CurrentTeamTemplate : PreviousTeamTemplate;
        }
    }
}
