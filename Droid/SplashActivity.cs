using Android.App;
using Android.Content;
using Android.OS;

namespace WideWorldCalendar.Droid
{
    [Activity(Theme = "@style/Theme.Splash", Icon = "@drawable/ic_launcher", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
        }
    }
}