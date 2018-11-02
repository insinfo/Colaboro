
using Acr.UserDialogs;
using Colaboro.Models;
using Colaboro.Services;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
            btnCadastrar.Clicked += BtnCadastrar_Clicked;
            btnEntrar.Clicked += BtnEntrar_Clicked;
        }

        private async void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CadastroPage());
        }        

        private async void BtnEntrar_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameEntry.Text))
            {
                Utils.ShowAlert(this, "Digite o nome de usuário!");
                usernameEntry.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                Utils.ShowAlert(this, "Digite a senha!");
                passwordEntry.Focus();
                return;
            }

            var dialog = UserDialogs.Instance;//.Loading("Carregando...",null,null,false);
            dialog.ShowLoading();                     
          
            RestClient rest = new RestClient();
            rest.DataToSender = new { userName = usernameEntry.Text, password = passwordEntry.Text };
            rest.SetMethodPOST();
            rest.ErrorCallbackFunction = (res) => {  formValidationInfoLabel.Text = res; Utils.ShowAlert(this, res); };
            rest.SuccessCallbackFunction = (res) => {  Navigation.PushModalAsync(new MainPage()); };           
            await rest.Exec("/api/auth/login");
            dialog.HideLoading();
            //dialog.Alert(resp);
           
            //
        }        
        /*
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        */

    }
}