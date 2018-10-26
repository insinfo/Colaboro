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
        private static readonly FormsNavigationService _navigationService =
            new FormsNavigationService();

        static ColaboroDatabase database;

        public App()
        {
            InitializeComponent();
            //IsUserLoggedIn = true;

            var t = AsyncHelpers.RunSync<bool>(() => Database.IsUser());
            
            if (t)
            {
                IsUserLoggedIn = true;
                
            }

             _navigationService.Configure(PageNames.LoginPage, typeof(Views.LoginPage));
            _navigationService.Configure(PageNames.MainPage, typeof(Views.MainPage));

            MainPage = _navigationService.SetRootPage(nameof(Views.MainPage));
        }

        public static ColaboroDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ColaboroDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ColaboroSQLite.db3"));
                }
                return database;
            }
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
