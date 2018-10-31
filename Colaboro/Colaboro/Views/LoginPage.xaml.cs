
using Acr.UserDialogs;
using Colaboro.Models;
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

        private async void ShowAlert(string mensagem)
        {
            await DisplayAlert("Atenção", mensagem, "Ok");
        }

        private async void BtnEntrar_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameEntry.Text))
            {
                ShowAlert("Digite o nome de usuario!");
                usernameEntry.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                ShowAlert("Digite a senha!");
                passwordEntry.Focus();
                return;
            }

            var objDialog =  UserDialogs.Instance.Loading("Carregando...",null,null,false);
             objDialog.Show();



            var loginData = new LoginData()
            {
                userName = usernameEntry.Text, password = passwordEntry.Text,ipPrivado= "10.0.0.4",
                ipPublico = "177.130.8.90"
            };
            var jsonRequest = JsonConvert.SerializeObject(loginData);
            var httpContent = new StringContent(jsonRequest,System.Text.Encoding.UTF8, "application/json");            
            var resp = string.Empty;

            
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://producao.riodasostras.rj.gov.br");
            var endpoint = "/api/auth/login";
            var result = await client.PostAsync(endpoint, httpContent);
            objDialog.Hide();


            if (result.IsSuccessStatusCode)
            {
                resp = await result.Content.ReadAsStringAsync();
            }


            /* try
             {
                 /using (var objDialog = UserDialogs.Instance.Loading("Carregando..", null, null, true, MaskType.Black))
                 {
                     await using Acr.UserDialogs;
                 }*

                 / Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.Loading("Carregando..", null, null, true, MaskType.Black));
                  await Task.Run(async () => { await Task.Delay(3000); })

                      .ContinueWith(result => Device.BeginInvokeOnMainThread(() => {
                      UserDialogs.Instance.HideLoading();
                  }               
                  ));*




                 const string KEY = "7Fsxc2A865V67"; // chave

                 var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpYXQiOjE1NDA5NTA4NjcsImlzcyI6Imp1YmFydGUucmlvZGFzb3N0cmFzLnJqLmdvdi5iciIsImV4cCI6MTU0MDk4MzI2NywibmJmIjoxNTQwOTUwODY2LCJkYXRhIjp7ImlkU2lzdGVtYSI6MSwiaWRQZXNzb2EiOjIsImlkT3JnYW5vZ3JhbWEiOjE5LCJsb2dpbk5hbWUiOiJpc2FxdWUubmV2ZXMiLCJpZFBlcmZpbCI6MiwicHdzIjoiM3FjWWRSWFZEblJBR25sUXZ2UUZDSEpSXC9ub1B3bzRDbVE9PSIsImlwQ2xpZW50UHJpdmF0ZSI6IjEwLjAuMC40IiwiaXBDbGllbnRQdWJsaWMiOiIxNzcuMTMwLjguOTAiLCJpcENsaWVudFZpc2libGVCeVNlcnZlciI6IjE5Mi4xNjguNjYuMjkiLCJob3N0IjoicHJvZHVjYW8ucmlvZGFzb3N0cmFzLnJqLmdvdi5iciIsIm9yaWdpbiI6Imh0dHA6XC9cL3Byb2R1Y2FvLnJpb2Rhc29zdHJhcy5yai5nb3YuYnIiLCJjcGZQZXNzb2EiOiIxMzEyODI1MDczMSIsInVzZXJBZ2VudCI6Ik1vemlsbGFcLzUuMCAoV2luZG93cyBOVCAxMC4wOyBXaW42NDsgeDY0KSBBcHBsZVdlYktpdFwvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lXC82OS4wLjM0OTcuMTAwIFNhZmFyaVwvNTM3LjM2In19.JcCmEYNzXeUZNqsWFlWXEupdDYeXazjzXlZmltHZAW8";
                 var json = new JwtBuilder()
                     .WithSecret(KEY)
                     .MustVerifySignature().WithAlgorithm(new HMACSHA256Algorithm())
                     .Decode(token);

                 ShowAlert(json);
             }
             catch (TokenExpiredException)
             {                
                 ShowAlert("Token has expired");
             }
             catch (SignatureVerificationException)
             {               
                 ShowAlert("Token has invalid signature");
             }*/
        }

        private void BtnCadastrar_Clicked(object sender, System.EventArgs e)
        {
           
        }

        /*
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        */

    }
}