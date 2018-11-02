using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colaboro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();           
        }
        /*
       protected override void OnAppearing()
       {
          if (!App.IsUserLoggedIn)
           {
               App.NavigationService.NavigateModalAsync(PageNames.LoginPage, false);
           }
           base.OnAppearing();
        }*/


    }
}
