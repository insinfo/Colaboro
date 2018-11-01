using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        //public delegate void SuccessCallbackFunction(string s);
        public Action<string> SuccessCallbackFunction { get; set; } = null;
        public Action<string> ErrorCallbackFunction { get; set; } = null;
        public Action<string> ProgressCallbackFunction { get; set; } = null;
        private HttpClient client = null;

        public RestClient()
        {            
            this.client = new HttpClient(); 
            this.client.DefaultRequestHeaders.Add("User-Agent", "App Jubarte from "+ RuntimeInformation.OSDescription);
        }

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

        private StringContent GetHttpContent()
        {
            if (this.DataToSender != null)
            {
                var jsonRequest = JsonConvert.SerializeObject(this.DataToSender);
                var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, this.SenderDataFormat);
                return httpContent;
            }
            return null;
        }

        public async void Exec(string routeRest)
        {
           
            var resp = string.Empty;
           
           // client.BaseAddress = new Uri(this.WebserviceURL);
            var rec = new HttpRequestMessage();
            rec.RequestUri = new Uri(this.WebserviceURL+ routeRest);

            if (this.Method == "POST")
            {              
                rec.Content = GetHttpContent();
                rec.Method = HttpMethod.Post;
            }else if (this.Method == "PUT")
            {
                rec.Content = GetHttpContent();
                rec.Method = HttpMethod.Put;
            }
            else if (this.Method == "DELETE")
            {
                rec.Content = GetHttpContent();
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

        private async void Upload(string filePath,string rota)
        {
            //Guid.NewGuid().ToString(),
            var resp = string.Empty;
            this.client.DefaultRequestHeaders.Add("User-Agent", "CBS Brightcove API Service");

            using (var content = new MultipartFormDataContent())
            {               
                string assetName = Path.GetFileName(filePath);

                //Content-Disposition: form-data; name="json"
                if (this.DataToSender != null)
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(this.DataToSender));
                    stringContent.Headers.Add("Content-Disposition", "form-data; name=\"json\"");
                    content.Add(stringContent, "json");
                }

                FileStream fs = File.OpenRead(filePath);

                var streamContent = new StreamContent(fs);
                streamContent.Headers.Add("Content-Type", "application/octet-stream");
                //Content-Disposition: form-data; name="file"; filename="C:\B2BAssetRoot\files\596090\596090.1.mp4";
                streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + Path.GetFileName(filePath) + "\"");
                content.Add(streamContent, "file", Path.GetFileName(filePath));

                //content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                client.BaseAddress = new Uri(this.WebserviceURL);
               // Task<HttpResponseMessage> result = client.PostAsync(rota, content);
                var result = await client.PostAsync(rota, content);
                
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
}
