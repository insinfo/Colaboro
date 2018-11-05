using Colaboro.Models;
using Colaboro.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
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

            string page = "http://www.google.com/";     
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(page);
            HttpContent content = response.Content;      
            string result = await content.ReadAsStringAsync();
            Utils.ShowAlert(this, result);               
                
            
            //await this.Navigation.PushModalAsync(new MainPage());

            //var dialog = UserDialogs.Instance;//.Loading("Carregando...",null,null,false);
            //dialog.ShowLoading();                     
            /*
              RestClient rest = new RestClient();
              rest.DataToSender = new { userName = usernameEntry.Text, password = passwordEntry.Text };
              rest.SetMethodPOST();
              rest.ErrorCallbackFunction = (res) => {
                  // Utils.ShowAlert(this, res);
                  formValidationInfoLabel.Text = res;
              };
              rest.SuccessCallbackFunction = (res) => {
                  formValidationInfoLabel.Text = res;
                  /// Navigation.PushModalAsync(new MainPage());
              };           
              await rest.Exec("/api/auth/login");*/
            // dialog.HideLoading();
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