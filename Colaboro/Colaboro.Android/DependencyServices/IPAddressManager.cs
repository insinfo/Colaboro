using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(Colaboro.Droid.DependencyServices.IPAddressManager))]
namespace Colaboro.Droid.DependencyServices
{
    class IPAddressManager : Colaboro.Services.IIPAddressManager
    {
        public string GetPrivateIPAddress()
        {
            IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

            if (adresses != null && adresses[0] != null)
            {
                return adresses[0].ToString();
            }
            else
            {
                return null;
            }
        }

        public string GetPublicIPAddress()
        {
            IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

            if (adresses != null && adresses[0] != null)
            {
                return adresses[0].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}