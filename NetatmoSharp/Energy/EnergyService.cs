using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetatmoSharp.Energy
{
    public class EnergyService : NetatmoServiceBase
    {
        public EnergyService(string clientId, string clientSecret, string accessToken, string refreshToken) : base(clientId, clientSecret, accessToken, refreshToken)
        { }
        //TODO Implment the methods to get the data from the energy module
        //https://dev.netatmo.com/apidocumentation/energy
    }
}
