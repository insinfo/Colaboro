using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colaboro.Models
{
    public class Token
    {
        public override string ToString()
        {
            return AccessToken;
        }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

    }
}
