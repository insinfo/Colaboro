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

            MainPage = new  Views.LoginPage();
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
