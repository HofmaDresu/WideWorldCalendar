using WideWorldCalendar.Persistence.Models;
using Xamarin.Forms;

namespace WideWorldCalendar.Utilities
{
    public class GameTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ScoredGameTemplate { get; set; }
        public DataTemplate UnscoredGameTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return string.IsNullOrEmpty(((Game)item).GameScore) ? UnscoredGameTemplate : ScoredGameTemplate;
        }
    }
}
