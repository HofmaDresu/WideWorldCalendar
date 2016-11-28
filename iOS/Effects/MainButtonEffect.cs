using System;
using System.ComponentModel;
using UIKit;
using WideWorldCalendar.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MainButtonEffect = WideWorldCalendar.iOS.Effects.MainButtonEffect;

[assembly: ResolutionGroupName(EffectIds.EffectGroupName)]
[assembly: ExportEffect(typeof(MainButtonEffect), EffectIds.MainButtonEffectName)]
namespace WideWorldCalendar.iOS.Effects
{
    public class MainButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var uiButton = Control as UIButton;
                if (uiButton == null) return;

                Control.BackgroundColor = uiButton.Enabled ? Colors.PrimaryColor.ToUIColor() : Colors.PrimaryDisabledColor.ToUIColor();
                Control.Layer.CornerRadius = 4.0f;
            }
            catch (Exception)
            {
                //IGNORE
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            var uiButton = Control as UIButton;
            if (uiButton == null) return;

            try
            {
                if (args.PropertyName == "IsEnabled")
                {
                    Control.BackgroundColor = uiButton.Enabled ? Colors.PrimaryDisabledColor.ToUIColor() : Colors.PrimaryColor.ToUIColor();
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
