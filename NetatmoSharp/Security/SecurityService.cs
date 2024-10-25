using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetatmoSharp.Security
{
    public class SecurityService : NetatmoServiceBase
    {
        public SecurityService(string clientId, string clientSecret, string accessToken, string refreshToken) : base(clientId, clientSecret, accessToken, refreshToken)
        { }
        //TODO Implment the methods to get the data from the security module
        //https://dev.netatmo.com/apidocumentation/security
    }
}
