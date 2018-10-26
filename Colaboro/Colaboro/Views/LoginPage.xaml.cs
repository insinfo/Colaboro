using Colaboro.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colaboro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;

            UsernameEntry.Completed += (sender, args) => { PasswordEntry.Focus(); };
            PasswordEntry.Completed += (sender, args) => { ViewModel.AuthenticateCommand.Execute(null); };
        }

        public LoginViewModel ViewModel { get; set; } = new LoginViewModel(App.NavigationService);

        #region Overrides of Page

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        #endregion
    }
}