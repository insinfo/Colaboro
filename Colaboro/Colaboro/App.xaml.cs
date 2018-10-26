using Colaboro.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Colaboro
{         
    public partial class App : Application
    {
        private static readonly FormsNavigationService _navigationService =
            new FormsNavigationService();

        public App()
        {
            InitializeComponent();

            _navigationService.Configure(PageNames.LoginPage, typeof(Views.LoginPage));
            _navigationService.Configure(PageNames.MainPage, typeof(Views.MainPage));

            MainPage = _navigationService.SetRootPage(nameof(Views.MainPage));
        }

        public static INavigationService NavigationService { get; } = _navigationService;

        // Use a service for providing this information
        public static bool IsUserLoggedIn { get; set; }

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
