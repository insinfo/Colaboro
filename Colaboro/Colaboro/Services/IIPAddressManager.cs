using System;
using System.Collections.Generic;
using System.Text;

namespace Colaboro.Services
{
    public interface IIPAddressManager
    {
        String GetPrivateIPAddress();
        String GetPublicIPAddress();
    }
}
