using Colaboro.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Diagnostics;
using Colaboro.Data;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Colaboro
{         
    public partial class App : Application
    {      

        public App()
        {
            InitializeComponent();

            Resources = new ResourceDictionary();
            Resources.Add("secundary", Color.FromHex("3b4455"));
            Resources.Add("primary", Color.FromHex("FFFFFF"));


            //PushModalAsync()
            /* var nav = new NavigationPage(new Views.LoginPage());
             nav.BarBackgroundColor = (Color)App.Current.Resources["secundary"];
             nav.BarTextColor = (Color)App.Current.Resources["primary"];
             MainPage = nav;*/
            MainPage = new Views.LoginPage();

        }              

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
    
}
