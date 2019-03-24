using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WideWorldCalendar.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamColorCircle : ContentView
    {
        public TeamColorCircle()
        {
            InitializeComponent();
        }
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create("Color", typeof(Color), typeof(TeamColorCircle), Color.Transparent);
    }
}