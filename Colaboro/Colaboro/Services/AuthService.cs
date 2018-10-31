using Acr.UserDialogs;
using Colaboro.Models;
using Colaboro.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Web;
using Xamarin.Forms;

namespace Colaboro.Services
{
    public class AuthService
    {
        private const string WebServiceBaseURL = "https://jubarte2.riodasostras.rj.gov.br";
        private const string RotaLogin = "/api/auth/login";

        public async void AtenticarUsuario(Page context,string userName, string password)
        {
            var objDialog = UserDialogs.Instance.Loading("Carregando...", null, null, false);
            objDialog.Show();

            var loginData = new LoginData()
            {
                userName = userName,
                password = password,
                ipPrivado = DependencyService.Get<IIPAddressManager>().GetPrivateIPAddress(),
                ipPublico = "177.130.8.90"
            };

            var jsonRequest = JsonConvert.SerializeObject(loginData);
            var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var resp = string.Empty;

            var client = new HttpClient();
            client.BaseAddress = new Uri(WebServiceBaseURL);
           
            var result = await client.PostAsync(RotaLogin, httpContent);
            objDialog.Hide();

            if (result.IsSuccessStatusCode)
            {
                resp = await result.Content.ReadAsStringAsync();
                await context.Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                Utils.ShowAlert(context, "Erro ao entrar, verifique se você esta conectado a internet!");
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

        /*
        private static Token Login(string username, string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(WebServiceURL);
            HttpResponseMessage response =
              client.PostAsync("Token",
                new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                  HttpUtility.UrlEncode(username),
                  HttpUtility.UrlEncode(password)), Encoding.UTF8,
                  "application/x-www-form-urlencoded")).Result;
            string resultJSON = response.Content.ReadAsStringAsync().Result;
            Token result = JsonConvert.DeserializeObject<Token>(resultJSON);
            return result;
        }

        private async void retornoJsonAsync(string token, string baseUrl)
        {
            bool validar = false;
            ModeloCliente cliente = new ModeloCliente();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://clienteapi.azurewebsites.net/");

            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            HttpResponseMessage response = await client.GetAsync("api/Cliente");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
                validar = true;
            }
        }*/
    }
}
