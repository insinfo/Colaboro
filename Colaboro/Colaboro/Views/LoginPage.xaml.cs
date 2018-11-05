using Colaboro.Models;
using Colaboro.Services;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
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


            //await this.Navigation.PushModalAsync(new MainPage());

            //var dialog = UserDialogs.Instance;//.Loading("Carregando...",null,null,false);
            //dialog.ShowLoading();                     

            /*  RestClient rest = new RestClient();
              rest.DataToSender = new { userName = usernameEntry.Text, password = passwordEntry.Text };
              rest.SetMethodPOST();
              rest.ErrorCallbackFunction = (res) => {
                  // Utils.ShowAlert(this, res);
                  usernameEntry.Text = res;
                  Debug.WriteLine(res);
              };
              rest.SuccessCallbackFunction = (res) => {
                  usernameEntry.Text = res;
                  Debug.WriteLine(res);
                  /// Navigation.PushModalAsync(new MainPage());
              };           
              await rest.Exec("/api/auth/login");
            // dialog.HideLoading();
            //dialog.Alert(resp);*/

            App.Database.SetItem("token", "teste");

           

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