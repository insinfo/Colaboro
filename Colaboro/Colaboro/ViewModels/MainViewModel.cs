using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Colaboro.Annotations;
using Colaboro.Services;
using Xamarin.Forms;

namespace Colaboro.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;

        public MainViewModel([NotNull] INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            LogoutCommand = new Command(Logout);
        }

        private void Logout()
        {
            App.IsUserLoggedIn = false;
            _navigationService.NavigateModalAsync(PageNames.LoginPage);
        }

        public ICommand LogoutCommand { private set; get; }
    }
}
