using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WideWorldCalendar.CustomControls
{
    public class AdjustableWidthPicker : Picker
    {
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == SelectedIndexProperty.PropertyName)
            {
                this.InvalidateMeasure();
            }
        }
    }
}
