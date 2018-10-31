using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Colaboro.Services
{
    public class RestClient
    {
        public string Method { get; set; } = "POST";
        public string WebserviceURL { get; set; } = null;    
        public string DataTypeFormat { get; set; } = "json";
        public object DataToSender { get; set; } = null;
        public string SenderDataFormat { get; set; } = "application/json";
        public string Header { get; set; } = null;

        public Action<string> SuccessCallbackFunction { get; set; } = null;
        public Action<string> ErrorCallbackFunction { get; set; } = null;
        public Action<string> ProgressCallbackFunction { get; set; } = null;

        public void SetMethodGET()
        {
            this.Method = "GET";
        }

        public void SetMethodPOST()
        {
            this.Method = "POST";
        }

        public void SetMethoddDELETE()
        {
            this.Method = "DELETE";
        }

        public void SetMethodPUT()
        {
            this.Method = "PUT";
        }

        public void SetSenderMultipartFormat()
        {
            this.SenderDataFormat = "multipart/form-data";
        }

        public void SetSenderFormUrlEncodedFormat()
        {
            this.SenderDataFormat = "application/x-www-form-urlencoded";
        }

        public void SetSenderJsonFormat ()
        {
            this.SenderDataFormat = "application/json";
        }

        public void SenderTextPlainFormatFormat ()
        {
            this.SenderDataFormat = "text/plain";
        }

        public void SetReceiverDataTypeFormat (string dataTypeFormat)
        {
            this.DataTypeFormat = dataTypeFormat;
        }

        public void SetDataToSender(object dataToSender)
        {
            this.DataToSender = dataToSender;
        }

        public async void Exec(string rota)
        {
            var resp = string.Empty;
            var client = new HttpClient();
            client.BaseAddress = new Uri(this.WebserviceURL);
            var rec = new HttpRequestMessage();

            if (this.Method == "POST")
            {               
                var jsonRequest = JsonConvert.SerializeObject(this.DataToSender);
                var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, this.SenderDataFormat);
                rec.Content = httpContent;
                rec.Method = HttpMethod.Post;
            }else if (this.Method == "PUT")
            {
                var jsonRequest = JsonConvert.SerializeObject(this.DataToSender);
                var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, this.SenderDataFormat);
                rec.Content = httpContent;
                rec.Method = HttpMethod.Put;
            }
            else if (this.Method == "GET")
            {
                rec.Method = HttpMethod.Get;
            }
           
            var result = await client.SendAsync(rec);

            if (result.IsSuccessStatusCode)
            {
                resp = await result.Content.ReadAsStringAsync();
                if (SuccessCallbackFunction != null)
                {
                    SuccessCallbackFunction(resp);
                }
            }
            else
            {
                if (ErrorCallbackFunction != null)
                {
                    ErrorCallbackFunction(result.StatusCode.ToString());
                }
            }
        }               
    }
}
