using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;

namespace Colaboro.Droid
{
    [Activity(Label = "MainActivity", Theme = "@style/SplashTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //[Activity(Label = "Colaboro", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //inicializa o Acr.UserDialogs  caixa de dialogo
            UserDialogs.Init(() => (Activity)this);
            //fim do Acr.UserDialogs

            LoadApplication(new App());

            // Disable activity slide-in animation
          //  OverridePendingTransition(0, 0);
        }
    }
}