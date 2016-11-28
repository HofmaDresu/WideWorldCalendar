using System;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using WideWorldCalendar.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MainButtonEffect = WideWorldCalendar.Droid.Effects.MainButtonEffect;

[assembly: ResolutionGroupName(EffectIds.EffectGroupName)]
[assembly: ExportEffect(typeof(MainButtonEffect), EffectIds.MainButtonEffectName)]
namespace WideWorldCalendar.Droid.Effects
{
    public class MainButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var cornerRadius = Forms.Context.ToPixels(4);
                var primaryColor = Colors.PrimaryColor.ToAndroid();
                var disabledColor = Colors.PrimaryDisabledColor.ToAndroid();

                var enabledBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { primaryColor, primaryColor });
                enabledBackground.SetCornerRadius(cornerRadius);

                var disabledBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { disabledColor, disabledColor });
                disabledBackground.SetCornerRadius(cornerRadius);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    var stateList = new StateListDrawable();
                    var rippleItem = new RippleDrawable(ColorStateList.ValueOf(Color.White.ToAndroid()),
                                                        enabledBackground,
                                                        null);

                    stateList.AddState(new [] { Android.Resource.Attribute.StateEnabled }, rippleItem);
                    stateList.AddState(new int[] { }, disabledBackground);
                    Control.Background = stateList;
                }
                else
                {
                    var pressedColor = Colors.PrimaryHightlightColor.ToAndroid();
                    var pressedBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { pressedColor, pressedColor });
                    pressedBackground.SetCornerRadius(cornerRadius);

                    var stateList = new StateListDrawable();
                    stateList.AddState(new [] { Android.Resource.Attribute.StateEnabled, Android.Resource.Attribute.StatePressed }, pressedBackground);
                    stateList.AddState(new [] { Android.Resource.Attribute.StateEnabled }, enabledBackground);
                    stateList.AddState(new int[] { }, disabledBackground);
                    Control.Background = stateList;
                }
            }
            catch (Exception)
            {
                //IGNORE
            }
        }

        protected override void OnDetached()
        {
            //Not Needed
        }
    }
}