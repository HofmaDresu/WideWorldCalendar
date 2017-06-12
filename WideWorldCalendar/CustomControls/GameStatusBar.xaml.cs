using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WideWorldCalendar.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameStatusBar : StackLayout
    {
        public object GamesList { get; set; }

        public GameStatusBar(object gamesList)
            : base()
        {
            GamesList = gamesList;
            InitializeComponent();
        }
    }
}