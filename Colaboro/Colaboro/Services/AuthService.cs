using Colaboro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Colaboro.Services
{
    public class AuthService
    {
        private const string WebServiceURL = "";

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

      /*  private async void retornoJsonAsync(string token, string baseUrl)
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
